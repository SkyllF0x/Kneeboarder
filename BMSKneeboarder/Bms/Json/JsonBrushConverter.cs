using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Json
{
    internal class JsonBrushConverter : JsonConverter<Brush>
    {
        public override Brush? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(Convert.ToInt32(reader.GetString())));
            return brush;
        }

        public override void Write(Utf8JsonWriter writer, Brush value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(((SolidBrush)value).Color.ToArgb().ToString());
        }
    }
}
