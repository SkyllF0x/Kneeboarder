using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Common;
using BCnEncoder.Shared.ImageFiles;
using BMSKneeboarder.Bms.UI;
using System.Drawing.Imaging;
using System.DirectoryServices;
using BMSKneeboarder.Bms.Model;
using System.Text.Json;
using System.ComponentModel;

namespace BMSKneeboarder.Bms
{
    public class BMSKneeboarderDB : IDisposable
    {
        private string dbFileName = "BMSKneeboarder.db3";
        private SQLiteConnection connection = null;
        private Dictionary<string, Bitmap> mapsCache2 = new Dictionary<string, Bitmap>();

        private BMSKneeboarderDB() { }

        private static BMSKneeboarderDB instance = null;

        public static BMSKneeboarderDB Instance
        {
            get
            {
                if (instance == null)
                    instance = new BMSKneeboarderDB();
                return instance;
            }
        }

        
        private SQLiteConnection GetConnection()
        {
            if (connection == null)
            {
                if (!File.Exists(dbFileName))
                    SQLiteConnection.CreateFile(dbFileName);

                DbProviderFactories.RegisterFactory("System.Data.SQLite", System.Data.SQLite.SQLiteFactory.Instance);

                SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");

                connection = (SQLiteConnection)factory.CreateConnection();
                connection.ConnectionString = "Data Source = " + dbFileName;
                connection.Open();

            }
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            return connection;
        }

        public void CreateTables()
        {
            SQLiteConnection connection = GetConnection();
            //ExecuteSQL("DROP TABLE kb_theaters");

            using (SQLiteCommand cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS kb_layout (id INTEGER PRIMARY KEY AUTOINCREMENT, num INTEGER NOT NULL, page_type VARCHAR(100), image BLOB, saturation INTEGER, map_settings TEXT)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS kb_theaters (id INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR(100), theater_map BLOB, theater_map2 BLOB)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS kb_settings (id INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR(100), value TEXT)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }

        private int ExecuteSQL(string sql)
        {
            int r;
            using (SQLiteCommand cmd = new SQLiteCommand(GetConnection()))
            {
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;
                r = cmd.ExecuteNonQuery();
            }
            return r;
        }

        public void Close()
        {
            connection.Close();
        }

        private byte[] GetBitmapAsByteArray(Bitmap bitmap, ImageFormat format)
        {
            byte[] data = null;
            using (MemoryStream ms = new MemoryStream(5000))
            {
                bitmap.Save(ms, format);
                data = ms.ToArray();
                ms.Close();
            }
            GC.Collect();
            return data;
        }

        public void SaveKBLayout(KneeboardLayout layout)
        {
            ExecuteSQL("begin");
            ExecuteSQL("DELETE FROM kb_layout");
            for (int i = 0; i < 32; i++)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(GetConnection()))
                {
                    cmd.CommandText = "INSERT INTO kb_layout (num, page_type, image, saturation, map_settings) VALUES ($num,$pt,$image,$sat, $mapsettings)";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("$num", i);
                    if (layout.Pages.Count > i)
                    {
                        cmd.Parameters.AddWithValue("$pt", layout.Pages[i].PageType);
                        cmd.Parameters.AddWithValue("$image", (layout.Pages[i].PageType != PageType.Image || layout.Pages[i].Image == null) ? null : GetBitmapAsByteArray(layout.Pages[i].Image, ImageFormat.Png));
                        cmd.Parameters.AddWithValue("$sat", layout.Pages[i].Saturation);
                    
                        if (layout.Pages[i].PageType == PageType.Map)
                            cmd.Parameters.AddWithValue("$mapsettings", JsonSerializer.Serialize(layout.Pages[i].MapSettings));
                        else
                            cmd.Parameters.AddWithValue("$mapsettings", null);
                    } else
                    {
                        cmd.Parameters.AddWithValue("$pt","");
                        cmd.Parameters.AddWithValue("$image", null);
                        cmd.Parameters.AddWithValue("$sat", 100);
                        cmd.Parameters.AddWithValue("$mapsettings", null);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            ExecuteSQL("end");
        }

        private byte[] ReadBytes(int field, SQLiteDataReader reader)
        {
            const int CHUNK_SIZE = 2 * 1024;
            byte[] buffer = new byte[CHUNK_SIZE];
            long bytesRead;
            long fieldOffset = 0;
            using (MemoryStream stream = new MemoryStream())
            {
                while ((bytesRead = reader.GetBytes(field, fieldOffset, buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, (int)bytesRead);
                    fieldOffset += bytesRead;
                }
                return stream.ToArray();
            }
        }

        public KneeboardLayout LoadKBLayout()
        {
            KneeboardLayout layout = new KneeboardLayout();

            using (SQLiteCommand cmd = new SQLiteCommand(GetConnection()))
            {
                cmd.CommandText = "SELECT num, page_type, image, saturation, map_settings FROM kb_layout ORDER BY num";
                cmd.CommandType = System.Data.CommandType.Text;
                SQLiteDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.KeyInfo);
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        int num = reader.GetInt32(0);

                        layout.Pages[num].PageType = Enum.Parse<PageType>(reader.GetString(1));
                        if (!reader.IsDBNull(2))
                        {
                            byte[] imgdata = ReadBytes(2, reader);
                            if (imgdata != null)
                            {
                                MemoryStream ms = new MemoryStream(imgdata);
                                layout.Pages[num].Image = new Bitmap(ms);
                                ms.Close();
                            }
                        }
                        layout.Pages[num].Saturation = reader.GetInt32(3);
                        if (!reader.IsDBNull(4))
                        {
                            layout.Pages[num].MapSettings = JsonSerializer.Deserialize<MapSettings>(reader.GetString(4));
                        }
                    }
                }
            }

            return layout;
        }
        public Bitmap ReadTheaterMap(string name, int mapIndex)
        {
            Bitmap map = null;

            string key = name + mapIndex.ToString();

            if (mapsCache2.ContainsKey(key))
            {
                map = mapsCache2[key];
            }
            else
            {
                using (SQLiteCommand cmd = new SQLiteCommand(GetConnection()))
                {
                    cmd.CommandText = "SELECT " + (mapIndex == 1 ? "theater_map" : "theater_map2") + " FROM kb_theaters WHERE name=$name";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("$name", name.ToLower());
                    SQLiteDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.KeyInfo);
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                var imgdata = ReadBytes(0, reader);
                                //mapsCache[key] = imgdata;


                                using (MemoryStream ms = new MemoryStream(imgdata))
                                {
                                    map = new Bitmap(ms);
                                    ms.Close();
                                    mapsCache2[key] = map;
                                }
                                
                                
                            }
                            GC.Collect();
                        }
                    }
                }
            }

            return map;
        }
        

        public List<TheaterRow> ReadTheaters()
        {
            List<TheaterRow> res = new List<TheaterRow>();
            using (SQLiteCommand cmd = new SQLiteCommand(GetConnection()))
            {
                cmd.CommandText = "SELECT id, name, theater_map, theater_map2 FROM kb_theaters ORDER BY id";
                cmd.CommandType = System.Data.CommandType.Text;
                SQLiteDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.KeyInfo);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TheaterRow row = new TheaterRow();
                        row.Id = reader.GetInt32(0);
                        row.Name = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                        {
                            byte[] imgdata = ReadBytes(2, reader);
                            if (imgdata != null)
                            {
                                MemoryStream ms = new MemoryStream(imgdata);
                                try
                                {
                                    row.TheaterMap = new Bitmap(ms);
                                } catch { }
                                ms.Close();
                            }
                        }
                        if (!reader.IsDBNull(3))
                        {
                            byte[] imgdata = ReadBytes(3, reader);
                            if (imgdata != null)
                            {
                                MemoryStream ms = new MemoryStream(imgdata);
                                try
                                {
                                    row.TheaterMap2 = new Bitmap(ms);
                                }
                                catch { }
                                ms.Close();
                            }
                        }
                        res.Add(row);
                    }
                }
            }

            return res;
        }

        public void UpdateTheaterMap(int id, Bitmap map)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(GetConnection()))
            {
                cmd.CommandText = "UPDATE kb_theaters SET theater_map=$map WHERE id=$id";
                cmd.CommandType= System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("$map", map == null ? null : GetBitmapAsByteArray(map, ImageFormat.Jpeg));
                cmd.Parameters.AddWithValue("$id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateTheaterMap2(int id, Bitmap map)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(GetConnection()))
            {
                cmd.CommandText = "UPDATE kb_theaters SET theater_map2=$map WHERE id=$id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("$map", map == null ? null : GetBitmapAsByteArray(map, ImageFormat.Jpeg));
                cmd.Parameters.AddWithValue("$id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertTheaterIfNotExists(string name)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(GetConnection()))
            {
                cmd.CommandText = "SELECT COUNT(id) FROM kb_theaters WHERE name=$name";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("$name", name.ToLower());
                SQLiteDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.KeyInfo);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32(0) == 0)
                        {
                            using (SQLiteCommand cmdIns = new SQLiteCommand(GetConnection()))
                            {
                                cmdIns.CommandText = "INSERT INTO kb_theaters (name) VALUES ($name)";
                                cmdIns.CommandType = System.Data.CommandType.Text;
                                cmdIns.Parameters.AddWithValue("$name", name.ToLower());
                                cmdIns.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        public void SaveSettings(string name, string value)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(GetConnection())) 
            {
                cmd.CommandText = "UPDATE kb_settings SET value=$value WHERE name=$name";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("$name", name);
                cmd.Parameters.AddWithValue("$value", value);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    cmd.CommandText = "INSERT INTO kb_settings (name, value) VALUES ($name, $value)";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string GetSettings(string name)
        {
            return GetSettings(name, string.Empty);
        }
        public string GetSettings(string name, string def)
        {
            string r = def;
            using (SQLiteCommand cmd = new SQLiteCommand(GetConnection()))
            {
                cmd.CommandText = "SELECT value FROM kb_settings WHERE name=$name";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("$name", name);
                Object res = cmd.ExecuteScalar();
                if (res == null)
                    r = def;
                else
                    r = res.ToString();
            }
            return r;
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
            foreach (string k in mapsCache2.Keys)
            {
                mapsCache2[k].Dispose();
                mapsCache2.Remove(k);
            }
        }

        public static void Cleanup()
        {
            if (instance != null)
            {
                instance.Dispose();
                instance = null;
            }
        }
    }
}
