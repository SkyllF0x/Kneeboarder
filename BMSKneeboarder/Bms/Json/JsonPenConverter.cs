using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Json
{
    internal class JsonPenConverter : JsonConverter<Pen>
    {
        public override Pen? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string s = reader.GetString();
            string[] parts = s.Split("|");
            Pen p = null;
            if (parts.Length >= 2)
            {
                p = new Pen(Color.FromArgb(Convert.ToInt32(parts[0])));
                p.Width = Convert.ToSingle(parts[1]);
            }
            if (parts.Length >= 3)
            {
                p.DashPattern = parts[2].Split(',').Select(x => Convert.ToSingle(x)).ToArray();
            }
            return p;
        }

        private float[] string2arr(string s)
        {
            string[] p = s.Split(',');
            float[] arr = new float[p.Length];
            for (int i = 0; i < p.Length; i++)
                arr[i] = Convert.ToSingle(p[i]);
            return arr;
        }
        private string arr2string(float[] arr)
        {
            List<string> p = new List<string>();
            foreach (float f in arr)
                p.Add(f.ToString());
            string r = string.Join(",", p.ToArray());
            GC.Collect();
            return r;
        }
        public override void Write(Utf8JsonWriter writer, Pen value, JsonSerializerOptions options)
        {
            string s = value.Color.ToArgb().ToString() + "|" + value.Width.ToString();
            string d = null;
            if (value.DashStyle == System.Drawing.Drawing2D.DashStyle.Custom && value.DashPattern != null)
            {
                List<string> dv = new List<string>();
                foreach (float f in value.DashPattern)
                    dv.Add(f.ToString());
                d = string.Join(",", dv.ToArray());
            }
            writer.WriteStringValue(d == null ? s : (s + "|" + d));
        }
    }
}
