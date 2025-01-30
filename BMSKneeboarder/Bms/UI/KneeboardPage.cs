using BMSKneeboarder.Bms;
using BMSKneeboarder.Bms.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using System.Globalization;
using System.Drawing.Imaging;
using System.Runtime.Intrinsics.Arm;

namespace BMSKneeboarder.Bms.UI
{
    public enum PageType { Blank, Datacard, Image, Comms, Map, Briefing };
    public class KneeboardPage : IDisposable
    {
        public int PageNo { get; set; }
        public Bitmap Bitmap { get; set; }
        public ImageAttributes ImageAttributes { get; set; }
        public int Saturation { get; set; }
        private PageType pageType;
        public PageType PageType
        {
            get
            {
                return pageType;
            }
            set
            {
                if (pageType != value && value == PageType.Datacard)
                {
                    DatacardFlights = new List<Flight>();

                    foreach (Flight f in missionData.FlightList)
                    {
                        if (missionData.CurrPackageId == f.package)
                            DatacardFlights.Add(f);

                        if (f.id == missionData.CurrFlightId)
                        {
                            Package p = missionData.PackageList.FirstOrDefault(x => x.id == f.package);
                            if (p != null)
                            {
                                Flight awacs = missionData.FlightList.FirstOrDefault(x => x.id == p.awacs);
                                if (awacs != null)
                                    DatacardSupportFlights.Add(awacs);
                                /*Flight jstar = missionData.FlightTable.FirstOrDefault(x => x.id == p.jstar);
                                if (jstar != null)
                                    DatacardSupportFlights.Add(jstar);*/
                                Flight tanker = missionData.FlightList.FirstOrDefault(x => x.id == p.tanker);
                                if (tanker != null)
                                    DatacardSupportFlights.Add(tanker);

                            }
                        }
                    }

                    DatacardFlights.Sort(delegate (Flight a, Flight b) { return a.campId.CompareTo(b.campId); });
                }
                if (pageType != value && value == PageType.Map)
                {
                    MapSettings.Fit(missionData, MapSettings, Bitmap.Width, Bitmap.Height);
                }
                pageType = value;
                Update();
            }
        }

        private MissionData missionData;

        public MapSettings MapSettings { get; set; } = new MapSettings();

        private List<Flight> datacardFlights = new List<Flight>();
        public List<Flight> DatacardFlights
        {
            get { return datacardFlights; }
            set { datacardFlights = value; Update(); }
        }

        private List<Flight> datacardSupportFlights = new List<Flight>();
        public List<Flight> DatacardSupportFlights
        {
            get { return datacardSupportFlights; }
            set { datacardSupportFlights = value; Update(); }
        }

        public KneeboardPage(int pageNo, PageType pt, MissionData missionData)
        {
            ImageAttributes = new ImageAttributes();
            Saturation = 100;
            Bitmap = new Bitmap(1280, 2048, PixelFormat.Format32bppArgb);
            PageNo = pageNo;
            
            this.missionData = missionData;

            PageType = pt;

            Update();
        }

        private Font GetCallsignFont()
        {
            return new Font("Agency FB", 25, FontStyle.Bold, GraphicsUnit.Point);
        }

        private PointF GetDatacardFlightsPos()
        {
            return new PointF(5, 50);
        }

        private PointF GetCommsPagePos()
        {
            return new PointF(5, 50);
        }

        private Font GetDatacardFont(bool bold)
        {
            return new Font("Agency FB", 25, bold ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point);
        }

        private Font GetBriefingFont(bool bold)
        {
            return new Font("Agency FB", 35, bold ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point);
        }

        private float DrawTableHead(Graphics graphics, PointF pos, float[] colWidths, string[] titles)
        {
            Font fntDC = GetDatacardFont(true);
            float x = pos.X;
            float y = pos.Y;
            float tableWidth = 0;
            foreach (float w in colWidths)
                tableWidth += w;

            x = (1280 - tableWidth) / 2;

            graphics.FillRectangle(Brushes.LightSlateGray, x, y, tableWidth, 50);

            Pen pen = new Pen(Color.Black, 2);

            graphics.DrawLine(pen, x, y, x + tableWidth, y);
            graphics.DrawLine(pen, x, y, x, y + 50);
            graphics.DrawLine(pen, x, y + 50, x + tableWidth, y + 50);

            for (int i = 0; i < colWidths.Length; i++)
            {
                graphics.DrawString(titles[i], fntDC, Brushes.Black, x, y);
                x += colWidths[i];
                graphics.DrawLine(pen, x, y, x, y + 50);
            }
            y += 50;
            
            return y;
        }

        private float DrawTableRow(Graphics graphics, PointF pos, float[] colWidths, string[] row, bool isOdd)
        {
            return DrawTableRow(graphics, pos, colWidths, 1, row,isOdd);
        }
        private float DrawTableRow(Graphics graphics, PointF pos, float[] colWidths, int linesNum, string[] row, bool isOdd)
        {
            Font fntDC = GetDatacardFont(false);
            Font fntDCBold = GetDatacardFont(true);
            float x = pos.X;
            float y = pos.Y;
            float rowHeight = 10 + Math.Max(1, linesNum) * 40;
            float tableWidth = 0;
            foreach (float w in colWidths)
                tableWidth += w;

            x = (1280 - tableWidth) / 2;

            Pen pen = new Pen(Color.Black, 2);

            if (isOdd)
            {
                graphics.FillRectangle(Brushes.LightGray, x, y, tableWidth, rowHeight);
            }

            graphics.DrawLine(pen, x, y, x, y + rowHeight);
            graphics.DrawLine(pen, x, y + rowHeight, x + tableWidth, y + rowHeight);

            for (int i = 0; i < colWidths.Length; i++)
            {
                if (row[i] != null && row[i].StartsWith("<b>"))
                    graphics.DrawString(row[i].Substring(3), fntDCBold, Brushes.Black, x, y);
                else
                    graphics.DrawString(row[i], fntDC, Brushes.Black, x, y);
                x += colWidths[i];
                graphics.DrawLine(pen, x, y, x, y + rowHeight);
            }
            y += rowHeight;
            

            return y;
        }

        public void SetImage(Bitmap bmp)
        {
            if (Bitmap != null)
                Bitmap.Dispose();
            Bitmap = bmp;
            PageType = PageType.Image;
        }

        public void Update()
        {
            if (PageType == PageType.Image)
                return;

            NumberFormatInfo numFormatOneDecimal = new NumberFormatInfo();
            numFormatOneDecimal.NumberDecimalDigits = 1;

            if (Bitmap != null)
                Bitmap.Dispose();

            Bitmap = new Bitmap(1280, 2048);
            using (Graphics graphics = Graphics.FromImage(Bitmap))
            {
                graphics.Clear(Color.White);

                if (missionData == null)
                    return;

                graphics.DrawString(missionData.CurrFlightCallsign, GetCallsignFont(), Brushes.Gray, 22, 5);

                PointF pos;

                Flight currentFlight = null;
                string currentCallsign = "";
                FltRad currentRadio = null;

                foreach (Flight flight in missionData.FlightList)
                {
                    if (flight.id == missionData.CurrFlightId)
                    {
                        currentFlight = flight;
                        currentCallsign = missionData.GetFlightCallsign(currentFlight);
                        currentRadio = missionData.FltRadio.FirstOrDefault(x => x.Callsign == currentCallsign);
                        break;
                    }
                }

                switch (PageType)
                {
                    case PageType.Blank:
                        Font f = new Font("MS Sans Serif", 72, FontStyle.Bold, GraphicsUnit.Point);
                        graphics.DrawString("Page " + (PageNo + 1), f, Brushes.LightGray, 350, 500);
                        break;
                    case PageType.Map:
                        
                        BmsUtils.DrawMap(missionData, MapSettings, Bitmap.Width, Bitmap.Height, graphics);
                        if (MapSettings.DrawingBitmap != null)
                            graphics.DrawImage(MapSettings.DrawingBitmap, new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), new Rectangle(0, 0, MapSettings.DrawingBitmap.Width, MapSettings.DrawingBitmap.Height), GraphicsUnit.Pixel);
                        break;
                    case PageType.Briefing:
                        Font fntBold = GetBriefingFont(true);
                        Font fnt = GetBriefingFont(false);
                        pos = GetCommsPagePos();

                        Squadron sq = missionData.SquadronList.FirstOrDefault(x => x.id == currentFlight.squadron);
                        if (sq != null)
                        {
                            graphics.DrawString("Sqn: " + sq.name_id + BmsUtils.GetNumSuff(sq.name_id), fnt, Brushes.Black, 20, pos.Y);
                        }

                        pos.Y += 70;

                        Package package = missionData.PackageList.FirstOrDefault(x => x.id == currentFlight.package);
                        if (package != null)
                        {
                            graphics.DrawString("Package: " + package.name_id, fnt, Brushes.Black, 20, pos.Y);
                            graphics.DrawString("Pkg mission: " + missionData.GetPkgMission(package), fnt, Brushes.Black, 500, pos.Y);
                            graphics.DrawString("TOT: " + missionData.GetTOT(package), fnt, Brushes.Black, 980, pos.Y);
                        }
                        pos.Y += 70;

                        graphics.DrawString("Flight: " + missionData.GetFlightCallsign(currentFlight) + " - " + missionData.GetFlightMission(currentFlight), fnt, Brushes.Black, 20, pos.Y);
                        if (currentFlight.waypoints.Length > 0)
                            graphics.DrawString("T/O " + BmsUtils.GetTimeString(currentFlight.waypoints[0].Depart), fnt, Brushes.Black, 500, pos.Y);
                        graphics.DrawString("TOT: " + missionData.GetTOT(currentFlight), fnt, Brushes.Black, 980, pos.Y);

                        pos.Y += 100;

                        graphics.DrawString("BINGO: " + string.Format("{0:# 000}", missionData.PilotBingo), fntBold, Brushes.Black, 20, pos.Y);
                        graphics.DrawString("JOKER: " + string.Format("{0:# 000}", missionData.PilotJoker), fntBold, Brushes.Black, 400, pos.Y);

                        if (currentRadio != null && missionData.PilotCommsVHF[14].Channel > 0)
                        {
                            for (int i = 0; i < missionData.PilotCommsVHF.Count; i++)
                            {
                                if (missionData.PilotCommsVHF[i].Freq.Replace(".", "") == currentRadio.Vhf)
                                {
                                    graphics.DrawString("VHF: " + missionData.PilotCommsVHF[i].Channel + " (" + missionData.PilotCommsVHF[i].Freq + ")", fntBold, Brushes.Black, 800, pos.Y);
                                }
                            }
                        }

                        pos.Y += 70;

                        graphics.DrawString(missionData.BriefingText, fnt, Brushes.Black, new RectangleF(20, pos.Y, 1240, 2020 - pos.Y));

                        break;
                    case PageType.Comms:
                        pos = GetCommsPagePos();

                        //missionData.LoadRadiosFromDTC();

                        if (currentFlight != null)
                        {
                            /*(Objective? abDep, Objective? abArr, Objective? abAlt) = missionData.FindFlightAirbases(currentFlight);
                            

                            if (abDep != null)
                            {
                                float[] colWidths = [60, 630, 60, 160, 160, 160];

                                pos.Y = DrawTableHead(graphics, pos, colWidths, ["", "Airbase", "TCN", "ATIS", "Appr", "Ground"]);

                                StationsILSData siData = missionData.arrStatIls.FirstOrDefault(x => x.CampId == abDep.campId);
                                pos.Y = DrawTableRow(graphics, pos, colWidths, ["DEP",
                                ShortenABName(new string(abDep.CampName)),
                                siData == null ? "" : siData.TCN_Channel + siData.TCN_Band,
                                siData == null ? "" : missionData.FormatFreq(siData.ATIS_freq_VHF, true),
                                siData == null ? "" : missionData.FormatFreq(siData.ApproachUHF, true),
                                siData == null ? "" : missionData.FormatFreq(siData.GroundUHF, true)
                                ], false);

                                //load to DTC UHF
                                missionData.PilotCommsUHF[1].Freq = missionData.FormatFreq(siData.GroundUHF);
                                missionData.PilotCommsUHF[2].Freq = missionData.FormatFreq(siData.UHF);
                                missionData.PilotCommsUHF[3].Freq = missionData.FormatFreq(siData.ApproachUHF);
                                //VHF channels
                                missionData.PilotCommsVHF[1].Freq = missionData.FormatFreq(siData.ATIS_freq_VHF);
                                missionData.PilotCommsVHF[2].Freq = missionData.FormatFreq(siData.VHF);


                                if (abArr != null)
                                {
                                    siData = missionData.arrStatIls.FirstOrDefault(x => x.CampId == abArr.campId);
                                    pos.Y = DrawTableRow(graphics, pos, colWidths, ["ARR",
                                    ShortenABName(new string(abArr.CampName)),
                                    siData == null ? "" : siData.TCN_Channel + siData.TCN_Band,
                                    siData == null ? "" : missionData.FormatFreq(siData.ATIS_freq_VHF, true),
                                    siData == null ? "" : missionData.FormatFreq(siData.ApproachUHF, true),
                                    siData == null ? "" : missionData.FormatFreq(siData.GroundUHF, true)
                                    ], true);

                                    //load to DTC UHF
                                    missionData.PilotCommsUHF[6].Freq = missionData.FormatFreq(siData.ApproachUHF);
                                    missionData.PilotCommsUHF[7].Freq = missionData.FormatFreq(siData.UHF);
                                    missionData.PilotCommsUHF[8].Freq = missionData.FormatFreq(siData.GroundUHF);
                                    //VHF channels
                                    missionData.PilotCommsVHF[6].Freq = missionData.FormatFreq(siData.ATIS_freq_VHF);
                                    missionData.PilotCommsVHF[7].Freq = missionData.FormatFreq(siData.VHF);
                                }
                                if (abAlt != null)
                                {
                                    siData = missionData.arrStatIls.FirstOrDefault(x => x.CampId == abAlt.campId);
                                    pos.Y = DrawTableRow(graphics, pos, colWidths, ["ALT",
                                    ShortenABName(new string(abAlt.CampName)),
                                    siData == null ? "" : siData.TCN_Channel + siData.TCN_Band,
                                    siData == null ? "" : missionData.FormatFreq(siData.ATIS_freq_VHF),
                                    siData == null ? "" : missionData.FormatFreq(siData.ApproachUHF),
                                    siData == null ? "" : missionData.FormatFreq(siData.GroundUHF)
                                    ], false);

                                    //load to DTC UHF
                                    missionData.PilotCommsUHF[9].Freq = missionData.FormatFreq(siData.ApproachUHF);
                                    missionData.PilotCommsUHF[10].Freq = missionData.FormatFreq(siData.UHF);
                                    missionData.PilotCommsUHF[11].Freq = missionData.FormatFreq(siData.GroundUHF);
                                    //VHF channels
                                    missionData.PilotCommsVHF[10].Freq = missionData.FormatFreq(siData.VHF);
                                }

                                pos.Y += 100;
                            }

                        }

                        //Tanker UHF
                        Package p = missionData.PackageList.FirstOrDefault(x => x.id == currentFlight.package);
                        if (p != null) {
                            //tactical
                            missionData.PilotCommsUHF[5].Freq = missionData.GetTacticalFreq(p, true);

                            //check-in channel 5
                            Flight awacs = missionData.FlightList.FirstOrDefault(x => x.id == p.awacs);
                            if (awacs != null)
                            {
                                //add current package awacs
                                missionData.PilotCommsUHF[4].Freq = missionData.GetTacticalFreq(awacs);
                                missionData.PilotCommsUHF[4].Comment = "Awacs Check-in";
                            }

                            Flight tanker = missionData.FlightList.FirstOrDefault(x => x.id == p.tanker);
                            if (tanker != null){
                                //add current package tanker
                                missionData.PilotCommsUHF[12].Freq = missionData.GetTacticalFreq(tanker);
                            }

                            //package flights VHF
                            for (int i = 0; i < p.element.Length; ++i) {
                                string CS = missionData.GetFlightCallsign(missionData.FlightList.FirstOrDefault(x => x.id == p.element[i]));

                                if (CS != null) {
                                    (string VHF, string UHF_BU) = missionData.GetFlightFreq(CS);
                                    missionData.PilotCommsUHF[14 + i].Freq = UHF_BU;
                                    missionData.PilotCommsVHF[14 + i].Freq = VHF;
                                    missionData.PilotCommsVHF[14 + i].Comment = "Flight " + (i + 1).ToString();
                                    missionData.PilotCommsUHF[14 + i].Comment = "Intra Flight " + (i + 1).ToString();
                                }
                            }
                        }


                        pos.Y = DrawTableHead(graphics, pos, [615, 615], ["UHF", "VHF"]);

                        for (int i = 0; i < 20; i++)
                        {
                             string prefU = (i == 5) ? "<b>" : "";
                             string prefV = (currentRadio != null && missionData.FormatFreq(currentRadio.Vhf) == missionData.PilotCommsVHF[i].Freq) ? "<b>" : "";
                             pos.Y = DrawTableRow(graphics, pos, [100, 200, 315, 100, 200, 315], [
                                 prefU + missionData.PilotCommsUHF[i].Channel.ToString(),
                             prefU + missionData.PilotCommsUHF[i].Freq,
                             prefU + missionData.PilotCommsUHF[i].Comment,
                             prefV + missionData.PilotCommsVHF[i].Channel.ToString(),
                             prefV + missionData.PilotCommsVHF[i].Freq,
                             prefV + missionData.PilotCommsVHF[i].Comment], i % 2 == 1);
                         }*/
                        
                        (Objective? abDep, Objective? abArr, Objective? abAlt) = missionData.FindFlightAirbases(currentFlight);


                        if (abDep != null)
                        {
                            float[] colWidths = [60, 630, 60, 160, 160, 160];

                            pos.Y = DrawTableHead(graphics, pos, colWidths, ["", "Airbase", "TCN", "ATIS", "Appr", "Ground"]);

                            StationsILSData siData = missionData.arrStatIls.FirstOrDefault(x => x.CampId == abDep.campId);
                            pos.Y = DrawTableRow(graphics, pos, colWidths, ["DEP",
                                ShortenABName(new string(abDep.CampName)),
                                siData == null ? "" : siData.TCN_Channel + siData.TCN_Band,
                                siData == null ? "" : missionData.FormatFreq(siData.ATIS_freq_VHF, true),
                                siData == null ? "" : missionData.FormatFreq(siData.ApproachUHF, true),
                                siData == null ? "" : missionData.FormatFreq(siData.GroundUHF, true)
                            ], false);


                            if (abArr != null)
                            {
                                siData = missionData.arrStatIls.FirstOrDefault(x => x.CampId == abArr.campId);
                                pos.Y = DrawTableRow(graphics, pos, colWidths, ["ARR",
                                    ShortenABName(new string(abArr.CampName)),
                                    siData == null ? "" : siData.TCN_Channel + siData.TCN_Band,
                                    siData == null ? "" : missionData.FormatFreq(siData.ATIS_freq_VHF, true),
                                    siData == null ? "" : missionData.FormatFreq(siData.ApproachUHF, true),
                                    siData == null ? "" : missionData.FormatFreq(siData.GroundUHF, true)
                                ], true);

                            }
                            if (abAlt != null)
                            {
                                siData = missionData.arrStatIls.FirstOrDefault(x => x.CampId == abAlt.campId);
                                pos.Y = DrawTableRow(graphics, pos, colWidths, ["ALT",
                                    ShortenABName(new string(abAlt.CampName)),
                                    siData == null ? "" : siData.TCN_Channel + siData.TCN_Band,
                                    siData == null ? "" : missionData.FormatFreq(siData.ATIS_freq_VHF),
                                    siData == null ? "" : missionData.FormatFreq(siData.ApproachUHF),
                                    siData == null ? "" : missionData.FormatFreq(siData.GroundUHF)
                                ], false);
                            }

                            pos.Y += 100;
                        }

                        pos.Y = DrawTableHead(graphics, pos, [615, 615], ["UHF", "VHF"]);

                        for (int i = 0; i < 20; i++)
                        {
                            string prefU = (i == 5) ? "<b>" : "";
                            string prefV = (currentRadio != null && missionData.FormatFreq(currentRadio.Vhf) == missionData.PilotCommsVHF[i].Freq) ? "<b>" : "";
                            pos.Y = DrawTableRow(graphics, pos, [100, 200, 315, 100, 200, 315], [
                                prefU + missionData.PilotCommsUHF[i].Channel.ToString(),
                            prefU + missionData.PilotCommsUHF[i].Freq,
                            prefU + missionData.PilotCommsUHF[i].Comment,
                            prefV + missionData.PilotCommsVHF[i].Channel.ToString(),
                            prefV + missionData.PilotCommsVHF[i].Freq,
                            prefV + missionData.PilotCommsVHF[i].Comment], i % 2 == 1);
                            }
                        }
                        break;
                    case PageType.Datacard:
                        pos = GetDatacardFlightsPos();

                        if (currentFlight != null)
                        {
                            Objective abDep = null;
                            Objective abArr = null;
                            Objective abAlt = null;
                            int stptDep = -1;
                            int stptArr = -1;
                            int stptAlt = -1;

                            IEnumerable<Objective> abList = missionData.GetAirbasesAndAirstrips();

                            for (int i = 0; i < currentFlight.waypoints.Length; i++)
                            {
                                if (currentFlight.waypoints[i].Action == 1 || currentFlight.waypoints[i].Action == 7 || currentFlight.waypoints[i].Action == 27)
                                {
                                    Objective ab = null;
                                    float d = 10000;
                                    foreach (Objective o in abList)
                                    {
                                        float d1 = Math.Abs(o.x - currentFlight.waypoints[i].GridX) + Math.Abs(o.y - currentFlight.waypoints[i].GridY);
                                        if (d1 < d)
                                        {
                                            ab = o;
                                            d = d1;
                                        }
                                    }
                                    if (ab != null && currentFlight.waypoints[i].Action == 1)
                                    {
                                        abDep = ab;
                                        stptDep = i;
                                    }
                                    if (ab != null && (currentFlight.waypoints[i].Action == 7 || currentFlight.waypoints[i].Action == 27) && abArr == null)
                                    {
                                        abArr = ab;
                                        stptArr = i;
                                    }
                                    if (ab != null && (currentFlight.waypoints[i].Action == 7 || currentFlight.waypoints[i].Action == 27) && abArr != null)
                                    {
                                        abAlt = ab;
                                        stptAlt = i;
                                    }
                                }
                            }

                            if (abArr != null && abAlt != null && abArr.id == abAlt.id)
                                abAlt = null;

                            if (abDep != null)
                            {
                                float[] colWidths = [60, 60, 310, 100, 60, 160, 300, 160];

                                pos.Y = DrawTableHead(graphics, pos, colWidths, ["", "STP", "Airbase", "Elv", "TCN", "ATIS", "ILS", "Appr"]);

                                StationsILSData siData = missionData.arrStatIls.FirstOrDefault(x => x.CampId == abDep.campId);
                                pos.Y = DrawTableRow(graphics, pos, colWidths, ["DEP", missionData.IsF15Mode ? (stptDep == 0 ? "B" : stptDep.ToString()) : (stptDep + 1).ToString(),
                                ShortenABName(new string(abDep.CampName)),
                                missionData.GetTerrainHeight((float)abDep.simPostion.y, (float)abDep.simPostion.x).ToString(),
                                siData == null ? "" : siData.TCN_Channel + siData.TCN_Band,
                                siData == null ? "" : missionData.FormatFreq(siData.ATIS_freq_VHF, true),
                                "",
                                siData == null ? "" : missionData.FormatFreq(siData.ApproachUHF, true),
                            ], false);
                                if (abArr != null)
                                {

                                    siData = missionData.arrStatIls.FirstOrDefault(x => x.CampId == abArr.campId);
                                    string[] ils = missionData.GetILSLines(abArr, siData);
                                    pos.Y = DrawTableRow(graphics, pos, colWidths, ils.Length, ["ARR", missionData.IsF15Mode ? (stptArr == 0 ? "B" : stptArr.ToString() ) : (stptArr + 1).ToString(),
                                    ShortenABName(new string(abArr.CampName)),
                                    missionData.GetTerrainHeight((float)abArr.simPostion.y, (float)abArr.simPostion.x).ToString(),
                                    siData == null ? "" : siData.TCN_Channel + siData.TCN_Band,
                                    siData == null ? "" : missionData.FormatFreq(siData.ATIS_freq_VHF, true),
                                    siData == null ? "" : string.Join("\r\n", ils),
                                    siData == null ? "" : missionData.FormatFreq(siData.ApproachUHF, true),
                                ], true);
                                }
                                if (abAlt != null)
                                {

                                    siData = missionData.arrStatIls.FirstOrDefault(x => x.CampId == abAlt.campId);
                                    string[] ils = missionData.GetILSLines(abArr, siData);
                                    pos.Y = DrawTableRow(graphics, pos, colWidths, ["ALT", missionData.IsF15Mode ? (stptAlt == 0 ? "B" : stptAlt.ToString()) : (stptAlt + 1).ToString(),
                                    ShortenABName(new string(abAlt.CampName)),
                                    missionData.GetTerrainHeight((float)abAlt.simPostion.y, (float)abAlt.simPostion.x).ToString(),
                                    siData == null ? "" : siData.TCN_Channel + siData.TCN_Band,
                                    siData == null ? "" : missionData.FormatFreq(siData.ATIS_freq_VHF, true),
                                    siData == null ? "" : string.Join("\r\n", ils),
                                    siData == null ? "" : missionData.FormatFreq(siData.ApproachUHF, true),
                                ], false);
                                }

                                pos.Y += 100;
                            }

                        }

                        if (DatacardFlights != null)
                        {
                            float[] colWidths = [230, 240, 230, 80, 110, 170, 170];
                            pos.Y = DrawTableHead(graphics, pos, colWidths, ["Callsign", "Mission", "A/C", "STN", "TOT", "VHF", "Tact."]);

                            foreach (Flight flight in DatacardFlights)
                            {
                                string callsign = missionData.GetFlightCallsign(flight);

                                FltRad radio = missionData.FltRadio.FirstOrDefault(x => x.Callsign == callsign);

                                string pref = (flight.id == missionData.CurrFlightId) ? "<b>" : "";

                                pos.Y = DrawTableRow(graphics, pos, colWidths, [
                                    pref + callsign,
                                pref + missionData.GetFlightMission(flight),
                                pref + flight.PlanesNum.ToString() + "x" + missionData.GetFlightVehName(missionData.GetFlightNr(flight.id)),
                                pref + flight.STN,
                                pref + missionData.GetTOT(flight),
                                pref + (radio == null ? "---" : missionData.FormatFreq(radio.Vhf, true)),
                                pref + missionData.GetTacticalFreq(flight, true),

                            ], flight.id == missionData.CurrFlightId);

                            }
                            pos.Y += 50;
                        }

                        if (DatacardSupportFlights != null)
                        {
                            graphics.DrawString("Support", GetDatacardFont(true), Brushes.Black, 22, pos.Y);
                            pos.Y += 50;

                            float[] colWidths = [240, 380, 80, 220, 160, 150];
                            pos.Y = DrawTableHead(graphics, pos, colWidths, ["Mission", "Callsign", "STN", "TOS", "UHF", "Loc"]);

                            foreach (Flight flight in DatacardSupportFlights)
                            {
                                string callsign = missionData.GetFlightCallsign(flight);

                                FltRad radio = missionData.FltRadio.FirstOrDefault(x => x.Callsign == callsign);

                                int n = 0;
                                int locHdg = 0;
                                int locDist = 0;

                                foreach (Waypoint w in flight.waypoints)
                                {
                                    if (w.IsTgtWaypoint)
                                    {
                                        int[] arr = missionData.GetBELoc(w.GridX, w.GridY);
                                        if (arr != null)
                                        {
                                            locHdg += arr[0];
                                            locDist += arr[1];
                                            n++;
                                        }
                                    }
                                }

                                string loc = "---";
                                if (n > 0)
                                    loc = Convert.ToInt32((double)locHdg / n).ToString() + " / " + Convert.ToInt32((double)locDist / n).ToString();

                                pos.Y = DrawTableRow(graphics, pos, colWidths, [
                                    missionData.GetFlightMission(flight),
                                callsign,
                                flight.STN,
                                BmsUtils.GetTimeString(flight.time_on_target) + " - " + BmsUtils.GetTimeString(flight.mission_over_time),
                                (radio == null ? "---" : missionData.FormatFreq(radio.Uhf, true)),
                                loc
                                ], flight.id == missionData.CurrFlightId);

                            }
                        }

                        pos.Y += 100;
                        if (currentFlight != null)
                        {
                            Font fntDC = GetDatacardFont(false);

                            float[] colWidths = [100, 660, 160, 100, 100, 110];

                            float topY = pos.Y;
                            pos.Y = DrawTableHead(graphics, pos, colWidths, ["STPT", "Action", "TOS", "Alt.", "Dist.", "Gnd Elv"]);

                            for (int wIndex = 0; wIndex < currentFlight.waypoints.Length; wIndex++)
                            {
                                Waypoint w = currentFlight.waypoints[wIndex];

                                string pref = w.IsTgtWaypoint ? "<b>" : "";

                                pos.Y = DrawTableRow(graphics, pos, colWidths, [
                                    pref + (missionData.IsF15Mode ? (wIndex == 0 ? "Base" : wIndex.ToString()) : (wIndex + 1).ToString()),
                                pref + ActionString(w.Action),
                                pref + BmsUtils.GetTimeString(w.Arrive),
                                pref + (w.GridZ == 0 ? "0" : Conversions.ToString(Math.Abs(w.GridZ / 100)) + "k"),
                                pref + (wIndex > 0 && w.Action != 1 && currentFlight.waypoints[wIndex-1].Action != 4 && currentFlight.waypoints[wIndex-1].Action != 7 && currentFlight.waypoints[wIndex - 1].Action != 27 ? string.Format(numFormatOneDecimal, "{0:N}", BmsUtils.GridDistKm(w.GridX, w.GridY, currentFlight.waypoints[wIndex - 1].GridX, currentFlight.waypoints[wIndex - 1].GridY) * Constants.KM_TO_NM) : "---"),
                                missionData.GetTerrainHeight((float)w.GridY * Constants.KM_TO_FT, (float)w.GridX * Constants.KM_TO_FT).ToString()
                                ], wIndex % 2 == 1);
                            }
                        }
                        break;
                }
            }
        }

        private string ShortenABName(string s)
        {
            return (" " + s.Replace("\0", "") + " ").Replace(" Highway AirStrip ", " ").Replace(" AB ", " ").Replace(" Airbase ", " ").Replace(" Intl Airport ", " ").Replace("  ", " ").Trim();
        }

        public string ActionString(int Action)
        {
            string text;
            switch (Action)
            {
                case -1:
                    text = "Precision";
                    break;
                case 0:
                    text = "Nav";
                    break;
                case 1:
                    text = "TakeOff";
                    break;
                case 2:
                    text = "Push";
                    break;
                case 3:
                    text = "Split";
                    break;
                case 4:
                    text = "Refuel";
                    break;
                case 5:
                    text = "Rearm";
                    break;
                case 6:
                    text = "PickUp";
                    break;
                case 7:
                    text = "Land";
                    break;
                case 8:
                    text = "Holding";
                    break;
                case 9:
                    text = "CASCAP";
                    break;
                case 10:
                    text = "Escort";
                    break;
                case 11:
                    text = "Sweep";
                    break;
                case 12:
                    text = "CAP";
                    break;
                case 13:
                    text = "Intrcpt";
                    break;
                case 14:
                    text = "GNDStrk";
                    break;
                case 15:
                    text = "NAVStrk";
                    break;
                case 16:
                    text = "S&D";
                    break;
                case 17:
                    text = "Strike";
                    break;
                case 18:
                    text = "Bomb";
                    break;
                case 19:
                    text = "SEAD";
                    break;
                case 20:
                    text = "ELINT";
                    break;
                case 21:
                    text = "RECON";
                    break;
                case 22:
                    text = "Rescue";
                    break;
                case 23:
                    text = "ASW";
                    break;
                case 24:
                    text = "Tanker";
                    break;
                case 25:
                    text = "Airdrop";
                    break;
                case 26:
                    text = "JAM";
                    break;
                case 27:
                    text = "Land 2";
                    break;
                case 28:
                    text = "B5";
                    break;
                case 29:
                    text = "B6";
                    break;
                case 30:
                    text = "FAC";
                    break;
                default:
                    text = Conversions.ToString(Action);
                    break;
            }
            return text;
        }

        public void Dispose()
        {
            Bitmap.Dispose();
            ImageAttributes.Dispose();
            MapSettings.Dispose();
        }
    }
}
