using BMSKneeboarder.Bms;
using BMSKneeboarder.Bms.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMSKneeboarder
{
    public partial class SettingsForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger("default");
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SaveSettings()
        {
            log.Debug(">> SaveSettings");
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection section = (AppSettingsSection)config.GetSection("appSettings");
            section.Settings["Pilot"].Value = cbPilot.Text;
            section.Settings["BmsDir"].Value = tbBmsDir.Text;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            log.Debug("<< SaveSettings");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveSettings();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void LoadTheaterList()
        {
            lbTheaters.Items.Clear();
            foreach (TheaterRow row in BMSKneeboarderDB.Instance.ReadTheaters())
            {
                lbTheaters.Items.Add(row);
            }
        }

        private void LoadPilots()
        {
            log.Debug(">> LoadPilots");
            string dir = BmsUtils.GetBmsDir();

            cbPilot.Items.Clear();

            if (!string.IsNullOrEmpty(dir))
            {
                cbPilot.Text = ConfigurationManager.AppSettings.Get("Pilot");

                log.InfoFormat("Load pilots from {0}", dir + "User" + Path.DirectorySeparatorChar + "Config");
                if (Directory.Exists(dir + "User" + Path.DirectorySeparatorChar + "Config"))
                {
                    foreach (string filepath in Directory.GetFiles(dir + "User" + Path.DirectorySeparatorChar + "Config", "*.plc"))
                    {
                        log.InfoFormat("Found pilot file {0}", filepath);
                        cbPilot.Items.Add(Path.GetFileNameWithoutExtension(filepath));
                    }
                }
            }
            log.Debug("<< LoadPilots");
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            string dir = BmsUtils.GetBmsDir();

            tbBmsDir.Text = dir;

            if (!string.IsNullOrWhiteSpace(dir))
            {

                LoadPilots();
            }

            LoadTheaterList();

        }

        private void lbTheaters_SelectedIndexChanged(object sender, EventArgs e)
        {
            pTheaterEdit.Visible = (lbTheaters.SelectedIndex >= 0);
            if (pTheaterEdit.Visible)
            {
                pbTheaterMap.Invalidate();
                pbTheaterMap2.Invalidate();
            }
        }

        private void pbTheaterMap_Paint(object sender, PaintEventArgs e)
        {
            Bitmap b = null;
            if (lbTheaters.SelectedIndex >= 0)
                b = ((TheaterRow)lbTheaters.SelectedItem).TheaterMap;

            if (b == null)
            {
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawLine(Pens.Black, 0, 0, pbTheaterMap.Width, pbTheaterMap.Height);
                e.Graphics.DrawLine(Pens.Black, 0, pbTheaterMap.Height, pbTheaterMap.Width, 0);
            }
            else
            {
                e.Graphics.DrawImage(b, new Rectangle(0, 0, pbTheaterMap.Width, pbTheaterMap.Height));
            }
        }

        private void btnSelectMap_Click(object sender, EventArgs e)
        {
            if (dlgSelectMapFile.ShowDialog() == DialogResult.OK)
            {
                
                TheaterRow row = (TheaterRow)lbTheaters.SelectedItem;
                //Bitmap map = new Bitmap(Image.FromFile(dlgSelectMapFile.FileName));

                log.InfoFormat("Map selected {0} for theater {1}", dlgSelectMapFile.FileName, row.Name);
                using (System.IO.FileStream fs = new System.IO.FileStream(dlgSelectMapFile.FileName, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite))
                {
                    try
                    {
                        using (Bitmap bitmap = (Bitmap)Image.FromStream(fs, true, false))
                        {
                            try
                            {
                                /*Bitmap b2 = new Bitmap(2048, 2048);
                                Graphics g2 = Graphics.FromImage(b2);
                                g2.DrawImage(bitmap, 0, 0, b2.Width, b2.Height);*/
                                BMSKneeboarderDB.Instance.UpdateTheaterMap(row.Id, bitmap);
                                //b2.Dispose();
                                GC.Collect();
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex.Message, ex);
                                throw ex;
                            }
                        }
                    }
                    catch (ArgumentException aex)
                    {
                        log.Error(aex.Message, aex);
                        throw new Exception("The file received from the Map Server is not a valid jpeg image", aex);
                    }
                }

                int i = lbTheaters.SelectedIndex;
                LoadTheaterList();
                lbTheaters.SelectedIndex = i;
            }
        }

        private void btnSelectMap2_Click(object sender, EventArgs e)
        {
            if (dlgSelectMapFile.ShowDialog() == DialogResult.OK)
            {
                TheaterRow row = (TheaterRow)lbTheaters.SelectedItem;

                log.InfoFormat("Map 2 selected {0} for theater {1}", dlgSelectMapFile.FileName, row.Name);
                using (System.IO.FileStream fs = new System.IO.FileStream(dlgSelectMapFile.FileName, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite))
                {
                    try
                    {
                        using (Bitmap bitmap = (Bitmap)Image.FromStream(fs, true, false))
                        {
                            try
                            {
                                /*Bitmap b2 = new Bitmap(2048, 2048);
                                Graphics g2 = Graphics.FromImage(b2);
                                g2.DrawImage(bitmap, 0, 0, b2.Width, b2.Height);*/
                                BMSKneeboarderDB.Instance.UpdateTheaterMap2(row.Id, bitmap);
                                //b2.Dispose();
                                GC.Collect();
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex.Message, ex);
                                throw ex;
                            }
                        }
                    }
                    catch (ArgumentException aex)
                    {
                        log.Error(aex.Message, aex);
                        throw new Exception("The file received from the Map Server is not a valid jpeg image", aex);
                    }
                }

                int i = lbTheaters.SelectedIndex;
                LoadTheaterList();
                lbTheaters.SelectedIndex = i;
            }
        }

        private void pbTheaterMap2_Paint(object sender, PaintEventArgs e)
        {
            Bitmap b = null;
            if (lbTheaters.SelectedIndex >= 0)
                b = ((TheaterRow)lbTheaters.SelectedItem).TheaterMap2;

            if (b == null)
            {
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawLine(Pens.Black, 0, 0, pbTheaterMap2.Width, pbTheaterMap2.Height);
                e.Graphics.DrawLine(Pens.Black, 0, pbTheaterMap2.Height, pbTheaterMap2.Width, 0);
            }
            else
            {
                e.Graphics.DrawImage(b, new Rectangle(0, 0, pbTheaterMap2.Width, pbTheaterMap2.Height));
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveSettings();

            LoadPilots();
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (TheaterRow r in lbTheaters.Items)
            {
                r.Dispose();
            }
        }

        private void btnBrowseDir_Click(object sender, EventArgs e)
        {
            if (dlgSelectDir.ShowDialog() == DialogResult.OK)
            {
                tbBmsDir.Text = dlgSelectDir.SelectedPath;
            }
        }
    }
}
