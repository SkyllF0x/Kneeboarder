using BMSKneeboarder.Bms.Json;
using BMSKneeboarder.Bms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.UI
{
    public class MapSettings : IDisposable
    {
        
        public PointF Center { get; set; }
        public double ScaleRatio { get; set; }
        public double GetScale(int size)
        {
            return ScaleRatio * size;
        }
        [JsonConverter(typeof(JsonPenConverter))]
        public Pen WptPen { get; set; } = new Pen(Color.Black, 2);
        [JsonConverter(typeof(JsonPenConverter))]
        public Pen WptLinePen { get; set; } = new Pen(Color.Black, 2);
        public bool ShowWptLines { get; set; } = true;

        public bool ShowBE { get; set; } = true;

        [JsonConverter(typeof(JsonColorConverter))]
        public Color BEColor { get; set; } = Color.Blue;
        public int BESize { get; set; } = 40;

        [JsonConverter(typeof(JsonPenConverter))]
        public Pen BEPen { get; set; } = Pens.LightGray;
        public bool ShowBEGrid { get; set; } = true;
        [JsonConverter(typeof(JsonPenConverter))]
        public Pen BEGridPen { get; set; } = new Pen(Color.Green);
        public bool ShowSTPTLine1 { get; set; } = true;
        public bool ShowSTPTLine2 { get; set; } = true;
        public bool ShowSTPTLine3 { get; set; } = true;
        public bool ShowSTPTLine4 { get; set; } = true;
        [JsonConverter(typeof(JsonPenConverter))]
        public Pen STPTLine1Pen { get; set; }
        [JsonConverter(typeof(JsonPenConverter))]
        public Pen STPTLine2Pen { get; set; }
        [JsonConverter(typeof(JsonPenConverter))]
        public Pen STPTLine3Pen { get; set; }
        [JsonConverter(typeof(JsonPenConverter))]
        public Pen STPTLine4Pen { get; set; }

        
        
        [JsonConverter(typeof(JsonColorConverter))]
        public Color WptLabelColor { get; set; } = Color.Gray;
        public int WptLabelSize { get; set; } = 40;
        public bool ShowWptLabels { get; set; } = true;

        [JsonConverter(typeof(JsonColorConverter))]
        public Color BackgroundColor { get; set; } = Color.White;
        public int MapIndex { get; set; } = 0;
        public int MapSaturation { get; set; } = 100;
        public int MapBrightness{ get; set; } = 0;
        public List<int> ShowPptNums { get; set; } = new List<int>();
        [JsonConverter(typeof(JsonPenConverter))]
        public Pen PPTPen { get; set; } = new Pen(Color.Red, 2);
        [JsonConverter(typeof(JsonBrushConverter))]
        public Brush PPTBrush { get; set; } = new SolidBrush(Color.FromArgb(30, Color.Red));
        public int PPTNamesSize { get; set; } = 40;
        [JsonConverter(typeof(JsonColorConverter))]
        public Color PPTNamesColor { get; set; } = Color.Red;
        public bool ShowPptNames { get; set; } = true;
        public bool ShowPptNumbers { get; set; } = true;
        [JsonConverter(typeof(JsonColorConverter))]
        public Color PPTNumbersColor { get; set; } = Color.Gray;
        public int PPTNumbersSize { get; set; } = 30;
        [JsonIgnore]
        public List<FlightMapSettings> OtherFlights { get; set; } = new List<FlightMapSettings>();
        public bool ShowAirports { get; set; } = true;
        public bool ShowAirstrips{ get; set; } = true;
        public int AirportIconSize { get; set; } = 100;
        [JsonIgnore]
        public Bitmap DrawingBitmap { get; set; } = null;
        [JsonIgnore]
        public Pen PencilPen { get; set; } = new Pen(Color.Red, 8);
        [JsonIgnore]
        public int EraserSize { get; set; } = 80;


        public MapSettings() 
        {
            Center = new PointF(0, 0);
            ScaleRatio = 1.0f;
            STPTLine1Pen = new Pen(Color.Black, 2);
            STPTLine1Pen.DashPattern = [8, 4];
            STPTLine2Pen = new Pen(Color.Black, 2);
            STPTLine2Pen.DashPattern = [8, 4];
            STPTLine3Pen = new Pen(Color.Black, 2);
            STPTLine3Pen.DashPattern = [8, 4];
            STPTLine4Pen = new Pen(Color.Black, 2);
            STPTLine4Pen.DashPattern = [8, 4];
            PencilPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            PencilPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        public void Fit(MissionData missionData, MapSettings mapSettings, int controlWidth, int controlHeight)
        {
            Flight currentFlight = missionData.GetCurrentFlight();
            if (currentFlight != null && currentFlight.waypoints.Length > 0)
            {
                double max_dx = 0;
                double max_dy = 0;

                int minX = int.MaxValue;
                int maxX = 0;
                int minY = int.MaxValue;
                int maxY = 0;

                for (int i = 0; i < currentFlight.waypoints.Length; i++)
                {
                    Waypoint w = currentFlight.waypoints[i];

                    int wx = w.GridX;
                    int wy = w.GridY;

                    minX = Math.Min(minX, wx);
                    maxX = Math.Max(maxX, wx);
                    minY = Math.Min(minY, wy);
                    maxY = Math.Max(maxY, wy);
                }

                Center = new PointF((float)(maxX + minX) / 2f, (float)(maxY + minY) / 2f);

                for (int i = 0; i < currentFlight.waypoints.Length; i++)
                {
                    double dx = Math.Abs(currentFlight.waypoints[i].GridX - Center.X);
                    double dy = Math.Abs(currentFlight.waypoints[i].GridY - Center.Y);
                    if (dx > max_dx)
                        max_dx = dx;
                    if (dy > max_dy)
                        max_dy = dy;
                    max_dx = Math.Max(max_dx, 10);
                    max_dy = Math.Max(max_dy, 10);
                }

                ScaleRatio = Math.Min((controlWidth / 2 - 20) / max_dx, (controlHeight / 2 - 20) / max_dy) / controlWidth;

            }
        }

        public void Dispose()
        {
            if (DrawingBitmap != null)
                DrawingBitmap.Dispose();
        }


        public MapSettings(MapSettings from) : this()
        {
            Center = new PointF(from.Center.X, from.Center.Y);
            ScaleRatio = from.ScaleRatio;
            WptPen = (Pen)from.WptPen.Clone();
            WptLinePen = (Pen)from.WptLinePen.Clone();
            ShowWptLines = from.ShowWptLines;
            ShowBE = from.ShowBE;
            BEColor = Color.FromArgb(from.BEColor.ToArgb());
            BESize = from.BESize;
            BEPen = (Pen)from.BEPen.Clone();
            ShowBEGrid = from.ShowBEGrid;
            BEGridPen = (Pen)from.BEGridPen.Clone();
            ShowSTPTLine1 = from.ShowSTPTLine1;
            ShowSTPTLine2 = from.ShowSTPTLine2;
            ShowSTPTLine3 = from.ShowSTPTLine3;
            ShowSTPTLine4 = from.ShowSTPTLine4;
            STPTLine1Pen = (Pen)from.STPTLine1Pen.Clone();
            STPTLine2Pen = (Pen)from.STPTLine2Pen.Clone();
            STPTLine3Pen = (Pen)from.STPTLine3Pen.Clone();
            STPTLine4Pen = (Pen)from.STPTLine4Pen.Clone();
            WptLabelColor = Color.FromArgb(from.WptLabelColor.ToArgb());
            WptLabelSize = from.WptLabelSize;
            ShowWptLabels = from.ShowWptLabels;
            BackgroundColor = Color.FromArgb(from.BackgroundColor.ToArgb());
            MapIndex = from.MapIndex;
            MapSaturation = from.MapSaturation;
            MapBrightness = from.MapBrightness;
            ShowPptNums = new List<int>(from.ShowPptNums);
            PPTPen = (Pen)from.PPTPen.Clone();
            PPTBrush = (Brush)from.PPTBrush.Clone();
            PPTNamesSize = from.PPTNamesSize;
            PPTNamesColor = Color.FromArgb(from.PPTNamesColor.ToArgb());
            ShowPptNames = from.ShowPptNames;
            ShowPptNumbers = from.ShowPptNumbers;
            PPTNumbersColor = Color.FromArgb(from.PPTNumbersColor.ToArgb());
            PPTNumbersSize = from.PPTNumbersSize;
            OtherFlights = new List<FlightMapSettings>(from.OtherFlights);
            ShowAirports = from.ShowAirports;
            ShowAirstrips = from.ShowAirstrips;
            AirportIconSize = from.AirportIconSize;
        }

        public void Paste(MapSettings from)
        {
            Center = new PointF(from.Center.X, from.Center.Y);
            ScaleRatio = from.ScaleRatio;
            WptPen = (Pen)from.WptPen.Clone();
            WptLinePen = (Pen)from.WptLinePen.Clone();
            ShowWptLines = from.ShowWptLines;
            ShowBE = from.ShowBE;
            BEColor = Color.FromArgb(from.BEColor.ToArgb());
            BESize = from.BESize;
            BEPen = (Pen)from.BEPen.Clone();
            ShowBEGrid = from.ShowBEGrid;
            BEGridPen = (Pen)from.BEGridPen.Clone();
            ShowSTPTLine1 = from.ShowSTPTLine1;
            ShowSTPTLine2 = from.ShowSTPTLine2;
            ShowSTPTLine3 = from.ShowSTPTLine3;
            ShowSTPTLine4 = from.ShowSTPTLine4;
            STPTLine1Pen = (Pen)from.STPTLine1Pen.Clone();
            STPTLine2Pen = (Pen)from.STPTLine2Pen.Clone();
            STPTLine3Pen = (Pen)from.STPTLine3Pen.Clone();
            STPTLine4Pen = (Pen)from.STPTLine4Pen.Clone();
            WptLabelColor = Color.FromArgb(from.WptLabelColor.ToArgb());
            WptLabelSize = from.WptLabelSize;
            ShowWptLabels = from.ShowWptLabels;
            BackgroundColor = Color.FromArgb(from.BackgroundColor.ToArgb());
            MapIndex = from.MapIndex;
            MapSaturation = from.MapSaturation;
            MapBrightness = from.MapBrightness;
            ShowPptNums = new List<int>(from.ShowPptNums);
            PPTPen = (Pen)from.PPTPen.Clone();
            PPTBrush = (Brush)from.PPTBrush.Clone();
            PPTNamesSize = from.PPTNamesSize;
            PPTNamesColor = Color.FromArgb(from.PPTNamesColor.ToArgb());
            ShowPptNames = from.ShowPptNames;
            ShowPptNumbers = from.ShowPptNumbers;
            PPTNumbersColor = Color.FromArgb(from.PPTNumbersColor.ToArgb());
            PPTNumbersSize = from.PPTNumbersSize;
            OtherFlights = new List<FlightMapSettings>(from.OtherFlights);
            ShowAirports = from.ShowAirports;
            ShowAirstrips = from.ShowAirstrips;
            AirportIconSize = from.AirportIconSize;
        }
        public void PasteObjAppearance(MapSettings from)
        {
            WptPen = (Pen)from.WptPen.Clone();
            WptLinePen = (Pen)from.WptLinePen.Clone();
            ShowWptLines = from.ShowWptLines;
            ShowBE = from.ShowBE;
            BEColor = Color.FromArgb(from.BEColor.ToArgb());
            BESize = from.BESize;
            BEPen = (Pen)from.BEPen.Clone();
            ShowBEGrid = from.ShowBEGrid;
            BEGridPen = (Pen)from.BEGridPen.Clone();
            ShowSTPTLine1 = from.ShowSTPTLine1;
            ShowSTPTLine2 = from.ShowSTPTLine2;
            ShowSTPTLine3 = from.ShowSTPTLine3;
            ShowSTPTLine4 = from.ShowSTPTLine4;
            STPTLine1Pen = (Pen)from.STPTLine1Pen.Clone();
            STPTLine2Pen = (Pen)from.STPTLine2Pen.Clone();
            STPTLine3Pen = (Pen)from.STPTLine3Pen.Clone();
            STPTLine4Pen = (Pen)from.STPTLine4Pen.Clone();
            WptLabelColor = Color.FromArgb(from.WptLabelColor.ToArgb());
            WptLabelSize = from.WptLabelSize;
            ShowWptLabels = from.ShowWptLabels;
            ShowPptNums = new List<int>(from.ShowPptNums);
            PPTPen = (Pen)from.PPTPen.Clone();
            PPTBrush = (Brush)from.PPTBrush.Clone();
            PPTNamesSize = from.PPTNamesSize;
            PPTNamesColor = Color.FromArgb(from.PPTNamesColor.ToArgb());
            ShowPptNames = from.ShowPptNames;
            ShowPptNumbers = from.ShowPptNumbers;
            PPTNumbersColor = Color.FromArgb(from.PPTNumbersColor.ToArgb());
            PPTNumbersSize = from.PPTNumbersSize;
            OtherFlights = new List<FlightMapSettings>(from.OtherFlights);
            ShowAirports = from.ShowAirports;
            ShowAirstrips = from.ShowAirstrips;
            AirportIconSize = from.AirportIconSize;
        }
    }
}
