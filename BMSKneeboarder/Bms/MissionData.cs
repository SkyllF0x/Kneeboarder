using BMSKneeboarder.Bms.Model;
using BMSKneeboarder.Bms.Model.Res;
using BMSKneeboarder.Bms.Model.Terrain;
using BMSKneeboarder.Bms.UI;
using log4net;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NETGeographicLib;
using System.Configuration;
using System.Numerics;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;


namespace BMSKneeboarder.Bms
{
    public class MissionData : IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger("default");
        public class CommsItem
        {
            public CommsItem() {
                Channel = 0;
                Freq = "---";
                Comment = "";
            }
            public int Channel { get; set; }
            public string Freq { get; set; }
            public string Comment { get; set; }
        };
        private BmsConfig bmsConfig;
        public BmsStructs.CampaignClassDataType[] CampaignTable;
        public BmsStructs.TeamBasicInfo[] TeamBasicInfoTable;
        public BmsStructs.EntityClassType[] classTableEntries;
        public List<Flight> FlightList = new List<Flight>();
        public List<Package> PackageList = new List<Package>();
        public List<Brigade> BrigadeList = new List<Brigade>();
        public List<Battalion> BattalionList = new List<Battalion>();
        public List<TaskForce> TaskForceList = new List<TaskForce>();
        public List<Squadron> SquadronList = new List<Squadron>();
        public List<Unit> UnitList = new List<Unit>();
        public List<BmsStructs.Callsigns> CallsignList = new List<BmsStructs.Callsigns>();
        public List<BmsStructs.Pilots> PilotList = new List<BmsStructs.Pilots>();
        public List<Objective> ObjectiveList = new List<Objective>();
        public List<BmsStructs.ObjClassDataType> ObjectDataEntries = new List<BmsStructs.ObjClassDataType>();
        public List<Team> TeamTable = new List<Team>();
        public List<BmsStructs.PtHeaderDataType> PtHeaderDataEntries = new List<BmsStructs.PtHeaderDataType>();
        public string[] StringText;
        public string[] ObjectsText;
        public int[] ObjectsIndex;
        public string ObjectsIdxFile;
        public string ObjectsWchFile;
        public StationsILSData[] arrStatIls;
        public FltRad[] FltRadio;
        public BmsStructs.FeatureEntry[] FeatureEntryDataTable;
        public BmsStructs.UnitClassDataType[] UnitDataEntries;
        public Dictionary<string, L16File> L16Files { get; set; } = new Dictionary<string, L16File>(new KeyValuePair<string, L16File>[] { new KeyValuePair<string, L16File>("A", new L16File()), new KeyValuePair<string, L16File>("B", new L16File()) });
        public string BriefingText { get; set; } = string.Empty;
        public List<ObjectiveDeltas> ObjectiveDeltaTable = new List<ObjectiveDeltas>();

        public int NumEmbeddedFiles { get; set; } = 0;
        public List<BmsStructs.EmbeddedFileInfo> EmbeddedFileInfoTabel = new List<BmsStructs.EmbeddedFileInfo>();

        public BmsStructs.BmsId CurrPackageId;
        public short CurrPackageNo;
        private BmsStructs.BmsId _currFlightId;
        public BmsStructs.BmsId CurrFlightId 
        { 
            get
            {
                return _currFlightId;
            }
            set
            {
                _currFlightId = value;
                IsF15Mode = GetFlightVehName(GetFlightNr(_currFlightId)).ToLower().Contains("f-15");
            } 
        }
        public string CurrFlightCallsign;
        public BmsStructs.VehicleClassDataType[] VehicleDataEntries;
        public TerrainDB TerrainDB { get; set; }
        private bool useTerrainDB = true;
        public bool IsNewTerrain { get; set; }
        public double FALCON_ORIGIN_LONG {  get; set; }
        public double FALCON_ORIGIN_LAT { get; set; }
        public string TileSet { get; set; }
        
        public uint HEIGHTMAP_SAMPLES_UINT { get; set; }
        public float HEIGHTMAP_SAMPLES { get; set; }
        public uint HEIGHTMAP_TOTAL_SAMPLES {  get; set; }
        public float THEATER_SIZE_KM { get; set; }
        public float THEATER_SIZE_M { get; set; }
        public float GRID_TO_KM { get; set; }
        public float KM_TO_GRID {  get; set; }
        public double CampW { get; set; } = 3358699.5;
        public double CampH { get; set; } = 3358699.5;
        public Dictionary<IconColor, List<BmsStructs.IconIDs>> Icons = new Dictionary<IconColor, List<BmsStructs.IconIDs>>();
        public List<BmsStructs.ImageId> ImageIds = new List<BmsStructs.ImageId>();

        public BmsStructs.TransverseMercatorMeta TransverseMercatorMeta = new BmsStructs.TransverseMercatorMeta();


        private Regex reRadioMap = new Regex("(?'cs'\\w+),\\s+(?'UHF'\\d+),\\s+(?'VHF'\\d+),\\s+(?'UHF_Ex'\\d+)");

        private Regex reUhf = new Regex("^UHF_(\\d+)=(\\d+)$");
        private Regex reUhfComment = new Regex("^UHF_COMMENT_(\\d+)=(.*)$");
        private Regex reVhf = new Regex("^VHF_(\\d+)=(\\d+)$");
        private Regex reVhfComment = new Regex("^VHF_COMMENT_(\\d+)=(.*)$");
        private Regex reStptLine = new Regex("^lineSTPT_(\\d+)=([\\d\\.\\-]+), ([\\d\\.\\-]+), ([\\d\\.\\-]+)$");
        private Regex reStpt = new Regex("^target_(\\d+)=([\\d\\.\\-]+), ([\\d\\.\\-]+), ([\\d\\.\\-]+), \\d+, .*$");
        private Regex rePpt = new Regex("^ppt_(\\d+)=([\\d\\.\\-]+), ([\\d\\.\\-]+), ([\\d\\.\\-]+), ([\\d\\.\\-]+), (.*)$");
        private Regex reBingo = new Regex("^Bingo_Fuel=([\\d\\.]*)$");

        private Regex reF_VoiceAChnl = new Regex("^FILE_([AB])_VOICE_GROUP_A_CHANNEL=(\\d+)$");
        private Regex reF_VoiceBChnl = new Regex("^FILE_([AB])_VOICE_GROUP_B_CHANNEL=(\\d+)$");
        private Regex reF_MsnChnl = new Regex("^FILE_([AB])_MISSION_CHANNEL=(\\d+)$");
        private Regex reF_FighterChnl = new Regex("^FILE_([AB])_FIGHTER_CHANNEL=(\\d+)$");
        private Regex reF_SpecChnl = new Regex("^FILE_([AB])_SPECIAL_CHANNEL=(\\d+)$");
        private Regex reF_Callsign = new Regex("^FILE_([AB])_CALLSIGN=([a-zA-Z]*)$");
        private Regex reF_CallsignNum = new Regex("^FILE_([AB])_CALLSIGN_NUMBER=(\\d+)$");
        private Regex reF_FLead = new Regex("^FILE_([AB])_FLIGHT_LEAD=(\\d+)$");
        private Regex reF_ETR = new Regex("^FILE_([AB])_EXT_TIME_REFERENCE=(\\d+)$");
        private Regex reF_TcnChnl = new Regex("^FILE_([AB])_TACAN_CHANNEL=(\\d+)$");
        private Regex reF_TcnBand = new Regex("^FILE_([AB])_TACAN_BAND=([XY]+)$");
        private Regex reF_FlightSTN = new Regex("^FILE_([AB])_FLIGHT_(\\d+)_STN=([\\d]+)$");
        private Regex reF_TeamSTN = new Regex("^FILE_([AB])_TEAM_(\\d+)_STN=([\\d]+)$");
        private Regex reF_DonorSTN = new Regex("^FILE_([AB])_DONOR_(\\d+)_STN=([\\d]+)$");

        public List<CommsItem> PilotCommsUHF { get; set; }
        public List<CommsItem> PilotCommsVHF { get; set; }
        public Point2[] PilotStptLines { get; set; }
        public Point2[] PilotStpts { get; set; }
        public DTC_PPT[] PilotPpts { get; set; }

        public int PilotBingo { get; set; } = 3000;
        public int PilotJoker { get; set; } = 4500;
        public string MissionDTCFileName { get; set; }

        public string HeightmapFile { get; set; }

        private bool _f15mode = false;
        public bool IsF15Mode
        {
            get { return _f15mode; }
            set { _f15mode = value; }
        }

        public MissionData(BmsConfig bmsConfig)
        {
            this.bmsConfig = bmsConfig;

            PilotCommsUHF = new List<CommsItem>();
            PilotCommsVHF = new List<CommsItem>();

            Reset();

            ResetDTC();
        }

        public void Reset()
        {
            log.Info("MissionData Reset");
            PilotCommsUHF.Clear();
            PilotCommsVHF.Clear();
            PilotStptLines = new Point2[24];
            PilotStpts = new Point2[24];
            PilotPpts = new DTC_PPT[15];
            EmbeddedFileInfoTabel.Clear();

            for (int i = 0; i < 21; i++)
                EmbeddedFileInfoTabel.Add(new BmsStructs.EmbeddedFileInfo());

            CampaignTable = null;
            TeamBasicInfoTable = null;
            classTableEntries = null;

            FlightList.Clear();
            PackageList.Clear();
            BrigadeList.Clear();
            BattalionList.Clear();
            TaskForceList.Clear();
            SquadronList.Clear();
            UnitList.Clear();
            CallsignList.Clear();
            PilotList.Clear();
            ObjectiveList.Clear();
            ObjectDataEntries.Clear();
            TeamTable.Clear();
            PtHeaderDataEntries.Clear();

            StringText = null;
            ObjectsText = null;
            ObjectsIndex = null;
            ObjectsIdxFile = null;
            ObjectsWchFile = null;
            arrStatIls = null;
            FltRadio = null;
            FeatureEntryDataTable = null;
            UnitDataEntries = null;

            ObjectiveDeltaTable.Clear();
            NumEmbeddedFiles = 0;
            VehicleDataEntries = null;
            TerrainDB = null;

            foreach (List<BmsStructs.IconIDs> list in Icons.Values)
            {
                foreach (BmsStructs.IconIDs icId in list)
                {
                    icId.Dispose();
                }
                list.Clear();

            }
            Icons.Clear();
            ImageIds.Clear();

            BriefingText = BMSKneeboarderDB.Instance.GetSettings("briefing");
            PilotBingo = Convert.ToInt32(BMSKneeboarderDB.Instance.GetSettings("bingo", "3000"));
            PilotJoker = Convert.ToInt32(BMSKneeboarderDB.Instance.GetSettings("joker", "4500"));

            GC.Collect();
        }

        public void ResetDTC()
        {
            log.Debug("MissionData ResetDTC");
            PilotCommsUHF.Clear();
            PilotCommsVHF.Clear();

            for (int i = 0; i < 20; i++)
            {
                PilotCommsUHF.Add(new CommsItem());
                PilotCommsVHF.Add(new CommsItem());
            }
            for (int i = 0; i < 24; i++)
            {
                PilotStptLines[i] = new Point2(0, 0);
                PilotStpts[i] = new Point2(0, 0);
            }
            for (int i = 0; i < 15; i++)
                PilotPpts[i] = new DTC_PPT(i + 56);
            GC.Collect();
        }

        public string GetFlightCallsign(Flight f)
        {
            if (f == null)
                return null;
            return CallsignList[f.callsign_id].Name + f.callsign_num;
        }

        public string GetFlightMission(Flight f)
        {
            return StringText[f.mission + 300];
        }

        public string GetPkgMission(Package p)
        {
            return StringText[p.mis_request.mission + 300];
        }

        public string GetTOT(Package p)
        {
            for (int i = 0; i < p.elements; i++)
            {
                Flight f = FlightList.FirstOrDefault(x => x.id == p.element[i]);
                if (f != null && f.mission == p.mis_request.mission)
                    return GetTOT(f);
            }
            return "---";
        }

        public IEnumerable<Objective> GetAirbasesAndAirstrips()
        {
            return ObjectiveList.Where(x =>
            {
                if (x.entityType > 100 && x.entityType - 100 < classTableEntries.Length)
                {
                    var ct = classTableEntries[x.entityType - 100];
                    if (BmsUtils.TypeToString(ct.vuClassData.classInfo_[0], ct.vuClassData.classInfo_[1], ct.vuClassData.classInfo_[2]) == "Airbase" || BmsUtils.TypeToString(ct.vuClassData.classInfo_[0], ct.vuClassData.classInfo_[1], ct.vuClassData.classInfo_[2]) == "AirStrip")
                        return true;
                }
                return false;
            });
        }

        public IEnumerable<Objective> GetAirbases()
        {
            return ObjectiveList.Where(x =>
            {
                if (x.entityType > 100 && x.entityType - 100 < classTableEntries.Length)
                {
                    var ct = classTableEntries[x.entityType - 100];
                    if (BmsUtils.TypeToString(ct.vuClassData.classInfo_[0], ct.vuClassData.classInfo_[1], ct.vuClassData.classInfo_[2]) == "Airbase")
                        return true;
                }
                return false;
            });
        }

        public IEnumerable<Objective> GetAirstrips()
        {
            return ObjectiveList.Where(x =>
            {
                if (x.entityType > 100 && x.entityType - 100 < classTableEntries.Length)
                {
                    var ct = classTableEntries[x.entityType - 100];
                    if (BmsUtils.TypeToString(ct.vuClassData.classInfo_[0], ct.vuClassData.classInfo_[1], ct.vuClassData.classInfo_[2]) == "AirStrip")
                        return true;
                }
                return false;
            });
        }

        public string FormatFreq(string freq, bool appendChannelFromDTC = false)
        {
            if (freq.Length > 3)
            {
                string s = freq.Substring(0, freq.Length - 3) + "." + freq.Substring(freq.Length - 3);
                if (appendChannelFromDTC)
                {
                    foreach (CommsItem item in PilotCommsUHF)
                    {
                        if (item.Freq == s)
                            return s + " (U" + item.Channel + ")";
                    }
                    foreach (CommsItem item in PilotCommsVHF)
                    {
                        if (item.Freq == s)
                            return s + " (V" + item.Channel + ")";
                    }
                }
                return s;
            }
            return freq;
        }
        public string FormatFreq(int freq, bool appendChannelFromDTC = false)
        {
            if (freq == 0)
                return "---";
            string s = freq.ToString();
            if (s.Length > 3)
            {
                string r = s.Substring(0, s.Length - 3) + "." + s.Substring(s.Length - 3);
                if (appendChannelFromDTC)
                {
                    foreach (CommsItem item in PilotCommsUHF)
                    {
                        if (item.Freq == r)
                            return r + " (U" + item.Channel + ")";
                    }
                    foreach (CommsItem item in PilotCommsVHF)
                    {
                        if (item.Freq == r)
                            return r + " (V" + item.Channel + ")";
                    }
                }
                return r;
            }
            return s;
        }

        public string GetTOT(Flight f)
        {
            foreach (Waypoint w in f.waypoints)
            {
                if (w.Action == 4 || (w.Action >= 9 && w.Action <= 26) || w.Action == 30)
                    return BmsUtils.GetTimeString(w.Arrive);
            }
            return "---";
        }
        public string GetTacticalFreq(Flight f, bool appendChannelFromDTC = false)
        {
            Package p = PackageList.FirstOrDefault(x => x.id == f.package);
            if (p == null)
                return "---";
            return GetTacticalFreq(p, appendChannelFromDTC);
        }
        public string GetTacticalFreq(Package p, bool appendChannelFromDTC = false)
        {
            if (p.elements > 0)
            {
                string callsign = GetFlightCallsign(FlightList.FirstOrDefault(x => x.id == p.element[0]));
                if (callsign != null)
                {
                    FltRad radio = FltRadio.FirstOrDefault(x => x.Callsign == callsign);
                    if (radio != null)
                        return FormatFreq(radio.Uhf, appendChannelFromDTC);
                }
            }
            return "---";
        }

        public (string VHF, string UHF_BU) GetFlightFreq(string callsign) {

            
            FltRad radio = FltRadio.FirstOrDefault(x => x.Callsign == callsign);
            if (radio != null)
                return (VHF: FormatFreq(radio.Vhf, true), UHF_BU: FormatFreq(radio.UhfBackup, true));
            return (VHF: "---", UHF_BU: "---");
        }

        public void ReadRadio(string campaignDir)
        {
            log.DebugFormat("MissionData ReadRadio {0}", campaignDir);
            string[] array = new string[1];
            string text = campaignDir + "radiomap.dat";
            log.InfoFormat("Radio file {0}", text);
            checked
            {
                if (File.Exists(text))
                {
                    Array.Resize<FltRad>(ref this.FltRadio, 0);
                    FileStream fileStream = new FileStream(text, FileMode.Open);
                    StreamReader streamReader = new StreamReader(fileStream);
                    try
                    {
                        while (!streamReader.EndOfStream)
                        {
                            array[array.Length - 1] = streamReader.ReadLine();
                            Array.Resize<string>(ref array, array.Length + 1);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error has occurred with reading file:\r\n" + text + "\r\nError: " + ex.Message, "Open File", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    fileStream.Flush();
                    fileStream.Close();
                    int num = array.Length - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        string text2 = array[i];
                        string text3 = "";
                        string text4 = "";
                        string text5 = "";
                        if (text2 != null && !BmsStringUtils.IsComment(text2))
                        {
                            int num2 = BmsStringUtils.FirstComma(text2);
                            if ((num2 > 1) & (num2 < text2.Length))
                            {
                                string text6 = Strings.Mid(text2, 1, num2 - 1);
                                text2 = Strings.Mid(text2, num2 + 1, text2.Length);
                                text2 = Strings.Trim(text2);
                                num2 = BmsStringUtils.FirstComma(text2);
                                if ((num2 > 1) & (num2 < text2.Length))
                                {
                                    text3 = Strings.Mid(text2, 1, num2 - 1);
                                    text3 = text3.Replace(",", "");
                                    text3 = Strings.Trim(text3);
                                    text2 = Strings.Mid(text2, num2 + 1, text2.Length);
                                    text2 = Strings.Trim(text2);
                                    num2 = BmsStringUtils.FirstComma(text2);
                                    if ((num2 > 1) & (num2 < text2.Length))
                                    {
                                        text4 = Strings.Mid(text2, 1, num2 - 1);
                                        text4 = text4.Replace(",", "");
                                        text4 = Strings.Trim(text4);
                                    }
                                    else
                                    {
                                        text4 = Strings.Mid(text2, 1, text2.Length);
                                        text4 = text4.Replace(",", "");
                                        text4 = Strings.Trim(text4);
                                    }
                                    //if ((this.MinorPart >= 36) & (this.Build >= 23140))
                                    {
                                        text2 = Strings.Mid(text2, num2 + 1, text2.Length);
                                        text2 = Strings.Trim(text2);
                                        text5 = Strings.Mid(text2, 1, text2.Length);
                                        text5 = text5.Replace(",", "");
                                        text5 = Strings.Trim(text5);
                                    }
                                }
                                if (Operators.CompareString(text6, "", false) != 0)
                                {
                                    Array.Resize<FltRad>(ref this.FltRadio, this.FltRadio.Length + 1);
                                    this.FltRadio[this.FltRadio.Length - 1] = new FltRad();
                                    this.FltRadio[this.FltRadio.Length - 1].Callsign = text6;
                                    this.FltRadio[this.FltRadio.Length - 1].Uhf = text3;
                                    this.FltRadio[this.FltRadio.Length - 1].Vhf = text4;
                                    this.FltRadio[this.FltRadio.Length - 1].UhfBackup = text5;
                                }
                            }
                        }
                    }
                }
            }
        }

        public int GetFlightNr(BmsStructs.BmsId ID)
        {
            int num = -1;
            checked
            {
                int num2 = this.FlightList.Count - 1;
                for (int i = 0; i <= num2; i++)
                {
                    if (this.FlightList[i].id == ID)
                    {
                        num = i;
                        break;
                    }
                }
                return num;
            }
        }

        public string GetFlightVehName(int FlightNr)
        {
            int dataType = (int)this.classTableEntries[(int)(checked(this.FlightList[FlightNr].entityType - 100))].dataType;
            int num = (int)this.UnitDataEntries[dataType].VehicleType[0];
            int dataType2 = (int)this.classTableEntries[num].dataType;
            return BmsUtils.FixName(new string(this.VehicleDataEntries[dataType2].Name));
        }

        public int GetHdg(short fromX, short fromY, short toX, short toY)
        {
            double rang;
            if (toX == fromX)
            {
                if (toY < fromY)
                    rang = -Math.PI / 2.0;
                else
                    rang = Math.PI / 2.0;
            } else
                rang = Math.Atan((double)(toY - fromY) / (toX - fromX));
            int ang = Convert.ToInt32(rang * 180 / Math.PI);
            int hdg = 90 - ang;
            if (toX < fromX)
                hdg += 180;

            return hdg;
        }

        public double GetDistNm(short fromX, short fromY, short toX, short toY)
        {
            return Math.Sqrt(Math.Pow(toX - fromX, 2) + Math.Pow(toY - fromY, 2)) * Constants.KM_TO_NM;
        }

        public int[] GetBELoc(short gridX, short gridY)
        {
            if (CampaignTable.Count() > 0)
            {
                short beX = CampaignTable[0].BullseyeX;
                short beY = CampaignTable[0].BullseyeY;

                return new int[] { GetHdg(beX, beY, gridX, gridY), Convert.ToInt32(GetDistNm(beX, beY, gridX, gridY)) };
                //return GetHdg(beX, beY, gridX, gridY).ToString() + " / " + Convert.ToInt32(GetDistNm(beX, beY, gridX, gridY)).ToString();
            }
            return null;
        }

        public void LoadRadiosFromDTC()
        {
            string pilot = ConfigurationManager.AppSettings.Get("Pilot");
            string filepath = BmsUtils.GetBmsDir() + "User" + Path.DirectorySeparatorChar + "Config" + Path.DirectorySeparatorChar + pilot + ".ini";

            log.InfoFormat("LoadDTCIni {0}", filepath);
            if (!File.Exists(filepath))
            {

                return;
            }

            foreach (string line in File.ReadAllLines(filepath))
            {
                MatchCollection mc = reUhf.Matches(line.Trim());
                if (mc.Count > 0)
                {
                    int chnl = Convert.ToInt32(mc[0].Groups[1].Value);
                    PilotCommsUHF[chnl - 1].Channel = chnl;
                    PilotCommsUHF[chnl - 1].Freq = FormatFreq(mc[0].Groups[2].Value);
                }
                mc = reUhfComment.Matches(line.Trim());
                if (mc.Count > 0)
                {
                    int chnl = Convert.ToInt32(mc[0].Groups[1].Value);
                    PilotCommsUHF[chnl - 1].Comment = mc[0].Groups[2].Value;
                }

                mc = reVhf.Matches(line.Trim());
                if (mc.Count > 0)
                {
                    int chnl = Convert.ToInt32(mc[0].Groups[1].Value);
                    PilotCommsVHF[chnl - 1].Channel = chnl;
                    PilotCommsVHF[chnl - 1].Freq = FormatFreq(mc[0].Groups[2].Value);
                }
                mc = reVhfComment.Matches(line.Trim());
                if (mc.Count > 0)
                {
                    int chnl = Convert.ToInt32(mc[0].Groups[1].Value);
                    PilotCommsVHF[chnl - 1].Comment = mc[0].Groups[2].Value;
                }
            }
        }

        private void LoadDTCIni(string filepath)
        {
            ResetDTC();
            log.InfoFormat("LoadDTCIni {0}", filepath);
            if (File.Exists(filepath))
            {
                foreach (string line in File.ReadAllLines(filepath))
                {
                    MatchCollection mc = reUhf.Matches(line.Trim());
                    if (mc.Count > 0)
                    {
                        int chnl = Convert.ToInt32(mc[0].Groups[1].Value);
                        PilotCommsUHF[chnl - 1].Channel = chnl;
                        PilotCommsUHF[chnl - 1].Freq = FormatFreq(mc[0].Groups[2].Value);
                    }
                    mc = reUhfComment.Matches(line.Trim());
                    if (mc.Count > 0)
                    {
                        int chnl = Convert.ToInt32(mc[0].Groups[1].Value);
                        PilotCommsUHF[chnl - 1].Comment = mc[0].Groups[2].Value;
                    }

                    mc = reVhf.Matches(line.Trim());
                    if (mc.Count > 0)
                    {
                        int chnl = Convert.ToInt32(mc[0].Groups[1].Value);
                        PilotCommsVHF[chnl - 1].Channel = chnl;
                        PilotCommsVHF[chnl - 1].Freq = FormatFreq(mc[0].Groups[2].Value);
                    }
                    mc = reVhfComment.Matches(line.Trim());
                    if (mc.Count > 0)
                    {
                        int chnl = Convert.ToInt32(mc[0].Groups[1].Value);
                        PilotCommsVHF[chnl - 1].Comment = mc[0].Groups[2].Value;
                    }
                    mc = reStptLine.Matches(line.Trim());
                    if (mc.Count > 0)
                    {
                        int n = Convert.ToInt32(mc[0].Groups[1].Value);
                        PilotStptLines[n] = new Point2(Convert.ToDouble(mc[0].Groups[3].Value), Convert.ToDouble(mc[0].Groups[2].Value));
                    }
                    mc = reStpt.Matches(line.Trim());
                    if (mc.Count > 0)
                    {
                        int n = Convert.ToInt32(mc[0].Groups[1].Value);
                        PilotStpts[n] = new Point2(Convert.ToDouble(mc[0].Groups[3].Value), Convert.ToDouble(mc[0].Groups[2].Value));
                    }
                    mc = rePpt.Matches(line.Trim());
                    if (mc.Count > 0)
                    {
                        int n = Convert.ToInt32(mc[0].Groups[1].Value);
                        PilotPpts[n].X = Convert.ToDouble(mc[0].Groups[3].Value);
                        PilotPpts[n].Y = Convert.ToDouble(mc[0].Groups[2].Value);
                        PilotPpts[n].R = Convert.ToDouble(mc[0].Groups[5].Value);
                        PilotPpts[n].Text = mc[0].Groups[6].Value;
                        PilotPpts[n].PptNum = (n + 56);
                    }
                    /*mc = reBingo.Matches(line.Trim());
                    if (mc.Count > 0)
                    {
                        PilotJoker = ((int)Convert.ToDouble(mc[0].Groups[1].Value));
                        PilotBingo = Math.Max(0, PilotJoker - 1500);
                    }*/
                    mc = reF_VoiceAChnl.Matches(line.Trim());
                    if (mc.Count > 0)
                        L16Files[mc[0].Groups[1].Value].VoiceAChannel = mc[0].Groups[2].Value;
                    mc = reF_VoiceBChnl.Matches(line.Trim());
                    if (mc.Count > 0)
                        L16Files[mc[0].Groups[1].Value].VoiceBChannel = mc[0].Groups[2].Value;
                    mc = reF_MsnChnl.Matches(line.Trim());
                    if (mc.Count > 0)
                        L16Files[mc[0].Groups[1].Value].MsnChannel= mc[0].Groups[2].Value;
                    mc = reF_FighterChnl.Matches(line.Trim());
                    if (mc.Count > 0)
                        L16Files[mc[0].Groups[1].Value].FighterChannel = mc[0].Groups[2].Value;
                    mc = reF_SpecChnl.Matches(line.Trim());
                    if (mc.Count > 0)
                        L16Files[mc[0].Groups[1].Value].SpecialChannel = mc[0].Groups[2].Value;
                    mc = reF_Callsign.Matches(line.Trim());
                    if (mc.Count > 0)
                        L16Files[mc[0].Groups[1].Value].Callsign = mc[0].Groups[2].Value;
                    mc = reF_CallsignNum.Matches(line.Trim());
                    if (mc.Count > 0)
                        L16Files[mc[0].Groups[1].Value].CallsignNumber = mc[0].Groups[2].Value;
                    mc = reF_FLead.Matches(line.Trim());
                    if (mc.Count > 0)
                        L16Files[mc[0].Groups[1].Value].FlightLead = (mc[0].Groups[2].Value == "1" ? true : false);
                    mc = reF_ETR.Matches(line.Trim());
                    if (mc.Count > 0)
                        L16Files[mc[0].Groups[1].Value].ETR = (mc[0].Groups[2].Value == "1" ? true : false);
                    mc = reF_TcnChnl.Matches(line.Trim());
                    if (mc.Count > 0)
                        L16Files[mc[0].Groups[1].Value].TcnChannel = Convert.ToInt32(mc[0].Groups[2].Value);
                    mc = reF_TcnBand.Matches(line.Trim());
                    if (mc.Count > 0)
                        L16Files[mc[0].Groups[1].Value].TcnBand = mc[0].Groups[2].Value;
                    mc = reF_FlightSTN.Matches(line.Trim());
                    if (mc.Count > 0)
                        L16Files[mc[0].Groups[1].Value].FlightSTNs[Convert.ToInt32(mc[0].Groups[2].Value)-1] = mc[0].Groups[3].Value;
                    mc = reF_TeamSTN.Matches(line.Trim());
                    if (mc.Count > 0)
                        L16Files[mc[0].Groups[1].Value].TeamSTNs[Convert.ToInt32(mc[0].Groups[2].Value) - 1] = mc[0].Groups[3].Value;
                    mc = reF_DonorSTN.Matches(line.Trim());
                    if (mc.Count > 0)
                        L16Files[mc[0].Groups[1].Value].DonorSTNs[Convert.ToInt32(mc[0].Groups[2].Value) - 1] = mc[0].Groups[3].Value;
                }
            }
        }

        public void LoadMissionDTC()
        {
            LoadDTCIni(MissionDTCFileName);
        }
        public void LoadPilotDTC()
        {
            string pilot = ConfigurationManager.AppSettings.Get("Pilot");
            if (!string.IsNullOrEmpty(pilot))
            {
                string pilotFile = BmsUtils.GetBmsDir() + "User" + Path.DirectorySeparatorChar + "Config" + Path.DirectorySeparatorChar + pilot + ".ini";
                
                LoadDTCIni(pilotFile);
                
            } else
                MessageBox.Show("Pilot not selected. Check Settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public Flight GetCurrentFlight()
        {
            Flight currentFlight = null;

            foreach (Flight f in FlightList)
            {
                if (f.id == CurrFlightId)
                {
                    currentFlight = f;
                    break;
                }
            }

            return currentFlight;
        }

        public List<Flight> GetCurrPackageFlights()
        {
            List<Flight> res = new List<Flight>();

            foreach (Flight f in FlightList)
            {
                if (CurrPackageId == f.package)
                    res.Add(f);
            }
            return res;
        }

        public int GetTerrainHeight(float feetNorth, float feetEast)
        {
            TerrainHeightCalculator terrainHeightCalculator = new TerrainHeightCalculator();
            float num = 0;
            if (TerrainDB != null)
            {
                if (this.IsNewTerrain)
                {
                    try
                    {
                        return Convert.ToInt32(this.ReadNewTerrainElvLoc(feetNorth, feetEast));
                    }
                    catch (Exception ex)
                    {
                        return 0;
                    }
                }
                try
                {
                    num = terrainHeightCalculator.CalculateTerrainHeight(feetNorth, feetEast, TerrainDB);
                }
                catch (Exception ex2)
                {
                    num = 0f;
                }
            }
            return Convert.ToInt32(num);
        }

        public int ReadNewTerrainElvLoc(float feetNorth, float feetEast)
        {
            int num = -999;
            string text = bmsConfig.TerrainDir + "NewTerrain\\Heightmaps\\Heightmap.raw";
            int num2;
            if (!File.Exists(text))
            {
                num2 = num;
            }
            else
            {
                this.HeightmapFile = text;
                try
                {
                    using (BinaryReader binaryReader = new BinaryReader(File.Open(text, FileMode.Open)))
                    {
                        binaryReader.ReadUInt16();
                        uint num6;
                        checked
                        {
                            uint num3 = (uint)Math.Round(Math.Sqrt((uint)binaryReader.BaseStream.Length / 2.0));
                            uint num4 = (uint)Math.Round(unchecked((this.CampH - (double)feetNorth) / this.CampH * num3));
                            uint num5 = (uint)Math.Round(unchecked((double)feetEast / this.CampW * num3));
                            if (num4 > num3)
                            {
                                num4 = num3;
                            }
                            if (num5 > num3)
                            {
                                num5 = num3;
                            }
                            num6 = (uint)(unchecked((ulong)(checked(num4 * num3))) * 2UL + unchecked((ulong)num5) * 2UL);
                        }
                        if (((ulong)num6 >= 0UL) & ((ulong)num6 < (ulong)binaryReader.BaseStream.Length))
                        {
                            binaryReader.BaseStream.Position = (long)((ulong)num6);
                            num = (int)binaryReader.ReadInt16();
                        }
                    }
                }
                catch (Exception ex)
                {
                    num = -998;
                }
                GC.Collect();
                num2 = num;
            }
            return num2;
        }

        public void InitNewTerrain()
        {
            if (this.HeightmapFile == null)
            {
                this.HeightmapFile = bmsConfig.TerrainDir + "NewTerrain\\Heightmaps\\HeightMap.raw";
            }
            if (File.Exists(this.HeightmapFile))
            {
                checked
                {
                    ulong num;
                    try
                    {
                        using (BinaryReader binaryReader = new BinaryReader(File.Open(this.HeightmapFile, FileMode.Open)))
                        {
                            num = (ulong)binaryReader.BaseStream.Length;
                            binaryReader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                    this.HEIGHTMAP_SAMPLES_UINT = (uint)Math.Round(Math.Sqrt(num / 2.0));
                    this.HEIGHTMAP_SAMPLES = this.HEIGHTMAP_SAMPLES_UINT;
                    this.HEIGHTMAP_TOTAL_SAMPLES = this.HEIGHTMAP_SAMPLES_UINT * this.HEIGHTMAP_SAMPLES_UINT;
                }
                TransverseMercatorMeta.HEIGHTMAP_SIZE = this.HEIGHTMAP_SAMPLES - 1f;
                TransverseMercatorMeta.METER_RES = 1024000f / this.HEIGHTMAP_SAMPLES;
                this.THEATER_SIZE_KM = this.HEIGHTMAP_SAMPLES * this.TransverseMercatorMeta.METER_RES / 1000f;
                this.THEATER_SIZE_M = this.THEATER_SIZE_KM * 1000f;
                this.GRID_TO_KM = this.THEATER_SIZE_KM / this.HEIGHTMAP_SAMPLES;
                this.KM_TO_GRID = 1f / this.GRID_TO_KM;
                this.TransverseMercatorMeta.GRID_TO_FT = this.TransverseMercatorMeta.METER_RES * Constants.METERS_TO_FT;
                this.TransverseMercatorMeta.FT_TO_GRID = 1f / this.TransverseMercatorMeta.GRID_TO_FT;
                this.TransverseMercatorMeta.GRID_OFFSET = this.TransverseMercatorMeta.HEIGHTMAP_SIZE / 2f;
                this.InitTransverseMercator();
            }
        }

        private void InitTransverseMercator()
        {
            string text = bmsConfig.TerrainDir + "NewTerrain\\Theater.txt";
            if (File.Exists(text))
            {
                FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader streamReader = new StreamReader(fileStream);
                try
                {
                    double ptr = 0;
                    checked
                    {
                        while (!streamReader.EndOfStream)
                        {
                            string text2 = streamReader.ReadLine();
                            if (!Information.IsNothing(text2))
                            {
                                int num = text2.IndexOf("=");
                                if (num > 0)
                                {
                                    string text3 = Strings.Mid(text2, 1, num);
                                    string text4 = Strings.Mid(text2, num + 2, text2.Length);
                                    if (Operators.CompareString(Strings.LCase(text3), "theater name", false) == 0)
                                    {
                                        this.TransverseMercatorMeta.theaterName = text4;
                                    }
                                    if (Operators.CompareString(Strings.LCase(text3), "theater size in km", false) == 0 && Versioned.IsNumeric(text4))
                                    {
                                        this.TransverseMercatorMeta.theaterSizeInMeters = (uint)Math.Round(unchecked(Conversions.ToDouble(text4) * 1000.0));
                                    }
                                    if (Operators.CompareString(Strings.LCase(text3), "center latitude", false) == 0 && Versioned.IsNumeric(text4))
                                    {
                                        this.TransverseMercatorMeta.centerLat = Conversions.ToDouble(text4);
                                    }
                                    if (Operators.CompareString(Strings.LCase(text3), "center longitude", false) == 0 && Versioned.IsNumeric(text4))
                                    {
                                        this.TransverseMercatorMeta.centerLon = Conversions.ToDouble(text4);
                                        this.TransverseMercatorMeta.Meridian = this.TransverseMercatorMeta.centerLon;
                                    }
                                    if (Operators.CompareString(Strings.LCase(text3), "projection string", false) == 0)
                                    {
                                        string[] array = text2.Split(new char[] { ' ' });
                                        int num2 = array.Length - 1;
                                        for (int i = 0; i <= num2; i++)
                                        {
                                            int num3 = array[i].IndexOf("=");
                                            if (num3 > 0)
                                            {
                                                string text5 = Strings.Mid(array[i], 1, num3);
                                                text4 = Strings.Mid(array[i], num3 + 2, array[i].Length);
                                                if (Operators.CompareString(text5, "+x_0", false) == 0 && Versioned.IsNumeric(text4))
                                                {
                                                    this.TransverseMercatorMeta.offsetX = Conversions.ToDouble(text4);
                                                }
                                                if (Operators.CompareString(text5, "+y_0", false) == 0 && Versioned.IsNumeric(text4))
                                                {
                                                    this.TransverseMercatorMeta.offsetY = Conversions.ToDouble(text4);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        new TransverseMercator().Forward(this.TransverseMercatorMeta.Meridian, this.TransverseMercatorMeta.centerLat, this.TransverseMercatorMeta.centerLon, out this.TransverseMercatorMeta.offsetX, out this.TransverseMercatorMeta.offsetY);
                        ptr = this.TransverseMercatorMeta.offsetX;
                    }
                    this.TransverseMercatorMeta.offsetX = ptr - this.TransverseMercatorMeta.theaterSizeInMeters / 2.0;
                    ptr = this.TransverseMercatorMeta.offsetY;
                    this.TransverseMercatorMeta.offsetY = ptr - this.TransverseMercatorMeta.theaterSizeInMeters / 2.0;
                }
                catch (Exception ex)
                {
                }
                fileStream.Flush();
                fileStream.Close();
                return;
            }
            MessageBox.Show("File not found:\r\n" + text);
        }

        public void CorrectTeaName()
        {
            checked
            {
                if (Operators.CompareString(CampaignTable[0].TheaterName, "Israel", false) == 0)
                {
                    int num = this.TeamTable.Count - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        if ((Operators.CompareString(Strings.Trim(this.TeamTable[i].name), "ATO", false) == 0) | Conversions.ToBoolean(Strings.Trim(Conversions.ToString(Operators.CompareString(this.TeamTable[i].name, "ATO l", false) == 0))))
                        {
                            this.TeamTable[i].name = "Israel";
                        }
                    }
                }
            }
        }

        public bool CheckOwnSideObj(Objective obj)
        {
            checked
            {
                byte owner = GetCurrentFlight().owner;
                byte b = (byte)this.GetObjectiveOwner(this.ObjectiveList.First(x => x.campId == obj.campId).id);
                byte b2;
                try
                {
                    b2 = (byte)this.TeamTable[(int)owner].stance[(int)b];
                }
                catch (Exception ex)
                {
                    b2 = 0;
                }
                bool flag2 = !((b2 == 0) | (b2 == 3) | (b2 == 4) | (b2 == 5));
                return flag2;
            }
        }

        public int GetObjectiveOwner(BmsStructs.BmsId id)
        {
            int objNr = this.GetObjNr(id);
            //int objDeltaNr = this.GetObjDeltaNr(ObjectiveList[objNr].id);
            int objDeltaNr = this.GetObjDeltaNr(id);
            if (objDeltaNr != -1)
                return (int)this.ObjectiveDeltaTable[objDeltaNr].owner;
            else
                return (int)this.ObjectiveList[objNr].owner;
            
        }

        public int GetObjNr(BmsStructs.BmsId ID)
        {
            int num = -1;
            checked
            {
                int num2;
                if (Information.IsNothing(this.ObjectiveList))
                {
                    num2 = num;
                }
                else
                {
                    int num3 = this.ObjectiveList.Count - 1;
                    for (int i = 0; i <= num3; i++)
                    {
                        if (this.ObjectiveList[i].id.num == ID.num)
                        {
                            num = i;
                            break;
                        }
                    }
                    num2 = num;
                }
                return num2;
            }
        }

        public int GetObjDeltaNr(BmsStructs.BmsId id)
        {
            checked
            {
                if (this.ObjectiveList.Count == 0)
                    return -1;
                else
                {
                    for (int i = 0; i < this.ObjectiveDeltaTable.Count; i++)
                    {
                        if (this.ObjectiveDeltaTable[i].id == id)
                            return i;
                    }
                    return -1;
                }
            }
        }

        public void SaveLink16DTC()
        {
            Regex reVal = new Regex("=[A-Z0-9\\-]*$");
            string pilot = ConfigurationManager.AppSettings.Get("Pilot");
            if (!string.IsNullOrEmpty(pilot))
            {
                string pilotFile = BmsUtils.GetBmsDir() + "User" + Path.DirectorySeparatorChar + "Config" + Path.DirectorySeparatorChar + pilot + ".ini";

                if (File.Exists(pilotFile))
                {
                    string[] lines = File.ReadAllLines(pilotFile);

                    using (StreamWriter sw = new StreamWriter(pilotFile))
                    {
                        foreach (string line in lines)
                        {
                            bool added = false;
                            MatchCollection mc;
                            
                            mc = reF_VoiceAChnl.Matches(line);
                            if (mc.Count > 0)
                            {
                                added = true;
                                sw.WriteLine(reVal.Replace(line, "=" + L16Files[mc[0].Groups[1].Value].VoiceAChannel));
                            }
                            mc = reF_VoiceBChnl.Matches(line);
                            if (mc.Count > 0)
                            {
                                added = true;
                                sw.WriteLine(reVal.Replace(line, "=" + L16Files[mc[0].Groups[1].Value].VoiceBChannel));
                            }
                            mc = reF_MsnChnl.Matches(line);
                            if (mc.Count > 0)
                            {
                                added = true;
                                sw.WriteLine(reVal.Replace(line, "=" + L16Files[mc[0].Groups[1].Value].MsnChannel));
                            }
                            mc = reF_FighterChnl.Matches(line);
                            if (mc.Count > 0)
                            {
                                added = true;
                                sw.WriteLine(reVal.Replace(line, "=" + L16Files[mc[0].Groups[1].Value].FighterChannel));
                            }
                            mc = reF_SpecChnl.Matches(line);
                            if (mc.Count > 0)
                            {
                                added = true;
                                sw.WriteLine(reVal.Replace(line, "=" + L16Files[mc[0].Groups[1].Value].SpecialChannel));
                            }
                            mc = reF_Callsign.Matches(line);
                            if (mc.Count > 0)
                            {
                                added = true;
                                sw.WriteLine(reVal.Replace(line, "=" + L16Files[mc[0].Groups[1].Value].Callsign));
                            }
                            mc = reF_CallsignNum.Matches(line);
                            if (mc.Count > 0)
                            {
                                added = true;
                                sw.WriteLine(reVal.Replace(line, "=" + L16Files[mc[0].Groups[1].Value].CallsignNumber));
                            }
                            mc = reF_FLead.Matches(line);
                            if (mc.Count > 0)
                            {
                                added = true;
                                sw.WriteLine(reVal.Replace(line, "=" + (L16Files[mc[0].Groups[1].Value].FlightLead ? "1" : "0")));
                            }
                            mc = reF_ETR.Matches(line);
                            if (mc.Count > 0)
                            {
                                added = true;
                                sw.WriteLine(reVal.Replace(line, "=" + (L16Files[mc[0].Groups[1].Value].ETR ? "1" : "0")));
                            }
                            mc = reF_TcnChnl.Matches(line);
                            if (mc.Count > 0)
                            {
                                added = true;
                                sw.WriteLine(reVal.Replace(line, "=" + L16Files[mc[0].Groups[1].Value].TcnChannel.ToString().PadLeft(2, '0')));
                            }
                            mc = reF_TcnBand.Matches(line);
                            if (mc.Count > 0)
                            {
                                added = true;
                                sw.WriteLine(reVal.Replace(line, "=" + L16Files[mc[0].Groups[1].Value].TcnBand));
                            }
                            mc = reF_FlightSTN.Matches(line);
                            if (mc.Count > 0)
                            {
                                added = true;
                                sw.WriteLine(reVal.Replace(line, "=" + L16Files[mc[0].Groups[1].Value].FlightSTNs[Convert.ToInt32(mc[0].Groups[2].Value) - 1]));
                            }
                            mc = reF_TeamSTN.Matches(line);
                            if (mc.Count > 0)
                            {
                                added = true;
                                sw.WriteLine(reVal.Replace(line, "=" + L16Files[mc[0].Groups[1].Value].TeamSTNs[Convert.ToInt32(mc[0].Groups[2].Value) - 1]));
                            }
                            mc = reF_DonorSTN.Matches(line);
                            if (mc.Count > 0)
                            {
                                added = true;
                                sw.WriteLine(reVal.Replace(line, "=" + L16Files[mc[0].Groups[1].Value].DonorSTNs[Convert.ToInt32(mc[0].Groups[2].Value) - 1]));
                            }

                            if (!added)
                                sw.WriteLine(line);
                        }

                        sw.Close();
                    }
                }

            }

            
        }

        public void LoadIcons()
        {
            Icons.Clear();
            GC.Collect();

            foreach (IconColor iconColor in Enum.GetValues(typeof(IconColor)))
            {
                LoadIconsList(iconColor, Constants.IconColors[iconColor]);
            }
        }

        public void LoadIconsList(IconColor iconColor, string resFilename)
        {
            log.DebugFormat(">> LoadIconsList {0}", resFilename);
            checked
            {
                {
                    if (!Icons.ContainsKey(iconColor))
                        Icons.Add(iconColor, new List<BmsStructs.IconIDs>());

                    string text = bmsConfig.ArtDir;
                    string text2;
                    if (text != null)
                    {
                        text2 = Strings.Mid(text, text.Length, 1);
                    }
                    else
                    {
                        text2 = "";
                    }
                    if (Operators.CompareString(text2, "\\", false) != 0)
                    {
                        text += "\\";
                    }
                    string text3 = text + "resource\\" + resFilename;
                    if (!File.Exists(text3))
                    {
                        text3 = bmsConfig.BmsDataDir + "art\\resource\\" + resFilename;
                    }
                    if (File.Exists(text3))
                    {
                        F4ResourceBundleReader f4ResourceBundleReader = new F4ResourceBundleReader();
                        f4ResourceBundleReader.Load(text3);
                        int num = f4ResourceBundleReader.NumResources - 1;
                        for (int i = 0; i <= num; i++)
                        {
                            try
                            {
                                if (f4ResourceBundleReader.GetResourceType(i) == F4ResourceType.ImageResource)
                                {
                                    Bitmap imageResource = f4ResourceBundleReader.GetImageResource(i);
                                    //Color color = Color.FromArgb(0, 248, 0, 248);
                                    //Color color = Color.FromArgb(255, 211, 211, 211); //original
                                    Color color = Color.FromArgb(255, 248, 0, 248); //Make transparent by default
                                    imageResource.MakeTransparent(color);
                                    if (imageResource != null)
                                    {
                                        BmsStructs.IconIDs d = new BmsStructs.IconIDs();
                                        d.Icon = imageResource;
                                        d.Name = f4ResourceBundleReader.GetResourceID(i);
                                        Icons[iconColor].Add(d);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }
            }
            log.DebugFormat("<< LoadIconsList {0}", resFilename);
        }

        public void ReadImageIds()
        {
            log.Debug(">> ReadImageIds");
            ImageIds.Clear();
            string text = bmsConfig.ArtDir + "main\\imageids.id";
            text = text.Replace("/", "\\");
            if (!File.Exists(text))
            {
               text = bmsConfig.BmsDataDir + "art\\main\\imageids.id";
            }
            checked
            {
                if (File.Exists(text))
                {
                    FileStream fileStream = new FileStream(text, FileMode.Open);
                    StreamReader streamReader = new StreamReader(fileStream);
                    char c = '\t';
                    char c2 = ' ';
                    while (!streamReader.EndOfStream)
                    {
                        string text2 = streamReader.ReadLine();
                        text2 = text2.Replace(c, c2);
                        text2 = text2.Replace("\t", " ");
                        text2 = Strings.Trim(text2);
                        int num = 0;
                        do
                        {
                            text2 = text2.Replace("  ", " ");
                            num++;
                        }
                        while (num <= 10);
                        string[] array = Strings.Split(text2, " ", -1, CompareMethod.Binary);
                        if (array.Length > 1 && Versioned.IsNumeric(array[1]))
                        {
                            BmsStructs.ImageId d = new BmsStructs.ImageId();
                            d.Name = array[0];
                            d.ID = Conversions.ToInteger(array[1]);
                            ImageIds.Add(d);
                        }
                    }
                    return;
                }
                log.Error("Could not find file: imageids.id");
                MessageBox.Show("Could not find file: imageids.id", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            log.Debug("<< ReadImageIds");
        }

        public int GetRwyPrio(List<BmsStructs.Runway> Rwys, int Rwy)
        {
            int num = -1;
            int num3 = 0;
            checked
            {
                if (Rwy == 1)
                {
                    for (int i = 0; i < Rwys.Count; i++)
                    {
                        if (Rwys[i].Prio == 0)
                        {
                            if (num3 >= 1)
                            {
                                num = i;
                                break;
                            }
                            num3++;
                        }
                    }
                }
                else if (Rwy == 2)
                {
                    for (int j = 0; j < Rwys.Count; j++)
                    {
                        if (Rwys[j].Prio == 0)
                        {
                            num = j;
                            break;
                        }
                    }
                }
                else if (Rwy == 3)
                {
                    for (int k = 0; k < Rwys.Count; k++)
                    {
                        if (Rwys[k].Prio == 1)
                        {
                            if (num3 >= 1)
                            {
                                num = k;
                                break;
                            }
                            num3++;
                        }
                    }
                }
                else if (Rwy == 4)
                {
                    for (int l = 0; l < Rwys.Count; l++)
                    {
                        if (Rwys[l].Prio == 1)
                        {
                            num = l;
                            break;
                        }
                    }
                }
                return num;
            }
        }

        public List<BmsStructs.Runway> GetRwys(Objective obj)
        {
            List<BmsStructs.Runway> array = new List<BmsStructs.Runway>();
            //int objNrFromCampId = this.GetObjNrFromCampId(CampId);
            checked
            {
                //if (objNrFromCampId != -1)
                {
                    int num = (int)(obj.entityType - 100);
                    if ((num > 0) & (num < this.classTableEntries.Length))
                    {
                        int num2 = (int)this.classTableEntries[num].vuClassData.classInfo_[2];
                        if ((num2 == 1) | (num2 == 2))
                        {
                            int dataType = (int)this.classTableEntries[num].dataType;
                            int ptDataIndex;
                            int num3 = (ptDataIndex = (int)this.ObjectDataEntries[dataType].PtDataIndex) + 10;
                            for (int i = ptDataIndex; i <= num3; i++)
                            {
                                bool nextHeader = this.PtHeaderDataEntries[i].nextHeader != 0;
                                if (this.PtHeaderDataEntries[i].type == 1)
                                {
                                    //Array.Resize<F4Structs.Runway>(ref array, array.Length + 1);
                                    //int num4 = array.Length - 1;
                                    //F4Structs.PtHeaderDataType[] ptHeaderDataEntries = this.PtHeaderDataEntries;
                                    byte count = this.PtHeaderDataEntries[i].count;
                                    BmsStructs.Runway r = new BmsStructs.Runway();
                                    r.Prio = (int)this.PtHeaderDataEntries[i].runwayNum;
                                    r.Heading = this.PtHeaderDataEntries[i].data;
                                    r.LtRt = this.PtHeaderDataEntries[i].ltrt;
                                    r.texIdx = (int)this.PtHeaderDataEntries[i].texIdx;
                                    array.Add(r);
                                }
                                if (!nextHeader)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                return array;
            }
        }

        public string[] GetILSLines(Objective ab, StationsILSData siData)
        {
            if (ab == null || siData == null)
                return [];

            List<BmsStructs.Runway> rwys = GetRwys(ab);
            List<string> lines = new List<string>();

            if (siData.ILS_1 > 0)
            {
                int i = GetRwyPrio(rwys, 1);
                if (i >= 0)
                    lines.Add(Convert.ToInt32(rwys[i].Heading).ToString().PadLeft(3, '0') + "° " + (rwys[i].LtRt == 1 ? "R " : "") + (rwys[i].LtRt == -1 ? "L " : "") + StationsILSData.FormatILS(siData.ILS_1));
            }
            if (siData.ILS_2 > 0)
            {
                int i = GetRwyPrio(rwys, 2);
                if (i >= 0)
                    lines.Add(Convert.ToInt32(rwys[i].Heading).ToString().PadLeft(3, '0') + "° " + (rwys[i].LtRt == 1 ? "R " : "") + (rwys[i].LtRt == -1 ? "L " : "") + StationsILSData.FormatILS(siData.ILS_2));
            }
            if (siData.ILS_3 > 0)
            {
                int i = GetRwyPrio(rwys, 3);
                if (i >= 0)
                    lines.Add(Convert.ToInt32(rwys[i].Heading).ToString().PadLeft(3, '0') + "° " + (rwys[i].LtRt == 1 ? "R " : "") + (rwys[i].LtRt == -1 ? "L " : "") + StationsILSData.FormatILS(siData.ILS_3));
            }
            if (siData.ILS_4 > 0)
            {
                int i = GetRwyPrio(rwys, 4);
                if (i >= 0)
                    lines.Add(Convert.ToInt32(rwys[i].Heading).ToString() + "° " + (rwys[i].LtRt == 1 ? "R " : "") + (rwys[i].LtRt == -1 ? "L " : "") + StationsILSData.FormatILS(siData.ILS_4));
            }

            return lines.ToArray();
        }

        public void Dispose()
        {
            foreach (List<BmsStructs.IconIDs> list in Icons.Values)
            {
                foreach (BmsStructs.IconIDs icId in list)
                {
                    icId.Dispose();
                }
                list.Clear();
                
            }
            Icons.Clear();
            GC.Collect();
        }

        public void ReadObdFile(byte[] contents, int version, int numObjectiveDeltas)
        {
            ObjectiveDeltas[] deltas = new ObdFile(contents, version).deltas;
            if (deltas != null)
            {
                foreach (ObjectiveDeltas objectiveDeltas in deltas)
                {
                    /*BmsStructs.BmsId id = objectiveDeltas.id;
                    ulong last_repair = objectiveDeltas.last_repair;
                    byte owner = objectiveDeltas.owner;
                    byte supply = objectiveDeltas.supply;
                    byte fuel = objectiveDeltas.fuel;
                    byte losses = objectiveDeltas.losses;
                    byte[] fStatus = objectiveDeltas.fStatus;*/
                    ObjectiveDeltaTable.Add(objectiveDeltas);
                }
            }
        }

        public void ReadObjString(string theaterName)
        {
            log.DebugFormat(">> ReadObjString {0}", theaterName);
            checked
            {
                //if (this.blnThrFound)
                {
                    bool flag = false;
                    bool flag2 = false;

                    ObjectsIdxFile = bmsConfig.CampaignDir + theaterName + ".idx";
                    ObjectsWchFile = bmsConfig.CampaignDir + theaterName + ".wch";
                    log.InfoFormat("idx file {0}", ObjectsIdxFile);
                    log.InfoFormat("wch file {0}", ObjectsWchFile);
                    while (!File.Exists(ObjectsIdxFile))
                    {
                        if (!flag)
                        {
                            ObjectsIdxFile = bmsConfig.CampaignDir + theaterName.Replace(" ", "") + ".idx";
                            flag = true;
                        }
                        else
                        {
                            throw new Exception("idx file not found");
                        }
                    }
                    if (File.Exists(ObjectsIdxFile))
                    {
                        FileStream fileStream = new FileStream(ObjectsIdxFile, FileMode.Open, FileAccess.Read);
                        byte[] array = new byte[(int)fileStream.Length + 1];
                        fileStream.Read(array, 0, (int)fileStream.Length);
                        ObjectsIndex = null;
                        Array.Resize<int>(ref ObjectsIndex, (int)fileStream.Length);
                        ObjectsText = null;
                        Array.Resize<string>(ref ObjectsText, (int)fileStream.Length);
                        fileStream.Close();
                        int num = BitConverter.ToInt32(array, 0);
                        int num2 = 4;
                        Array.Clear(ObjectsIndex, 0, ObjectsIndex.Length);
                        int num3 = num - 1;
                        for (int i = 0; i <= num3; i++)
                        {
                            ObjectsIndex[i] = (int)BitConverter.ToUInt16(array, num2);
                            num2 += 2;
                        }
                        while (!File.Exists(ObjectsWchFile))
                        {
                            if (!flag2)
                            {
                                ObjectsWchFile = bmsConfig.CampaignDir + theaterName.Replace(" ", "") + ".wch";
                                flag2 = true;
                            }
                            else
                            {
                                throw new Exception("wch file not found");
                            }
                        }
                        if (File.Exists(ObjectsWchFile))
                        {
                            FileStream fileStream2 = new FileStream(ObjectsWchFile, FileMode.Open, FileAccess.Read);
                            byte[] array2 = new byte[(int)fileStream2.Length + 1];
                            fileStream2.Read(array2, 0, (int)fileStream2.Length);
                            fileStream2.Close();
                            fileStream2.Dispose();
                            num2 = 0;
                            int num4 = ObjectsIndex.Length - 1;
                            for (int j = 0; j <= num4; j++)
                            {
                                if (ObjectsIndex[j] == 0)
                                {
                                    Array.Resize<string>(ref ObjectsText, ObjectsText.Length + 1);
                                }
                                else
                                {
                                    int num5;
                                    if (j == 0)
                                    {
                                        num5 = ObjectsIndex[0];
                                    }
                                    else
                                    {
                                        num5 = ObjectsIndex[j] - ObjectsIndex[j - 1];
                                    }
                                    if (num5 < 0)
                                    {
                                        num5 = 0;
                                    }
                                    Array.Resize<string>(ref ObjectsText, ObjectsText.Length + 1);
                                    if (j == 0)
                                    {
                                        ObjectsText[num2] = Encoding.Default.GetString(array2, 0, num5);
                                    }
                                    else
                                    {
                                        ObjectsText[num2] = Encoding.Default.GetString(array2, ObjectsIndex[j - 1], num5);
                                    }
                                }
                                num2++;
                            }
                        }
                    }
                }
            }
            log.DebugFormat("<< ReadObjString {0}", theaterName);
        }

        public void LoadTerrain()
        {
            log.Debug(">> LoadTerrain");
            if (!useTerrainDB)
                return;

            if (string.IsNullOrEmpty(bmsConfig.TerrainDir))
            {
                TerrainDB = null;
                return;
            }

            TerrainDB = new TerrainDB();

            TheaterDotMapFileReader theaterDotMapFileReader = new TheaterDotMapFileReader();
            TheaterDotLxFileReader theaterDotLxFileReader = new TheaterDotLxFileReader();
            checked
            {
                bool flag;
                {
                    string text = "";
                    string text22 = "";
                    try
                    {
                        TerrainDB.TheaterDotLxFiles = null;
                        TerrainDB.TheaterDotMap = default(TheaterDotMapFileInfo);
                    }
                    catch (Exception ex)
                    {
                    }
                    TerrainDB = new TerrainDB();
                    //PathName = Strings.LCase(PathName);
                    if (!bmsConfig.TerrainDir.ToLower().Contains(Path.DirectorySeparatorChar + "terrain" + Path.DirectorySeparatorChar))
                        bmsConfig.TerrainDir += "terrain" + Path.DirectorySeparatorChar;

                    string text3 = bmsConfig.TerrainDir + "theater.map";
                    TerrainDB.TheaterDotMap = theaterDotMapFileReader.ReadTheaterDotMapFile(text3);
                    FALCON_ORIGIN_LONG = (double)TerrainDB.TheaterDotMap.baseLong;
                    FALCON_ORIGIN_LAT = (double)TerrainDB.TheaterDotMap.baseLat;
                    if (TileSet != "")
                    {
                        text = string.Concat(new string[]
                        {
                            Path.GetDirectoryName(bmsConfig.TerrainDir),
                            Conversions.ToString(Path.DirectorySeparatorChar),
                            "theater_",
                            TileSet,
                            ".L2"
                        });
                        text22 = string.Concat(new string[]
                        {
                            Path.GetDirectoryName(bmsConfig.TerrainDir),
                            Conversions.ToString(Path.DirectorySeparatorChar),
                            "theater_",
                            TileSet,
                            ".O2"
                        });
                    }
                    if (!File.Exists(text))
                    {
                        if (bmsConfig.g_sTileSet != "")
                        {
                            TileSet = bmsConfig.g_sTileSet;
                            text = string.Concat(new string[]
                            {
                                Path.GetDirectoryName(bmsConfig.TerrainDir),
                                Conversions.ToString(Path.DirectorySeparatorChar),
                                "theater_",
                                TileSet,
                                ".L2"
                            });
                            text22 = string.Concat(new string[]
                            {
                                Path.GetDirectoryName(bmsConfig.TerrainDir),
                                Conversions.ToString(Path.DirectorySeparatorChar),
                                "theater_",
                                TileSet,
                                ".O2"
                            });
                        }
                        if (!File.Exists(text))
                        {
                            TileSet = "";
                            text = Path.GetDirectoryName(bmsConfig.TerrainDir) + Conversions.ToString(Path.DirectorySeparatorChar) + "theater.L2";
                            text22 = Path.GetDirectoryName(bmsConfig.TerrainDir) + Conversions.ToString(Path.DirectorySeparatorChar) + "theater.O2";
                        }
                    }
                    if (File.Exists(text))
                    {
                        Array.Resize<TheaterDotLxFileInfo>(ref TerrainDB.TheaterDotLxFiles, (int)TerrainDB.TheaterDotMap.NumLODs);
                        int num = (int)(unchecked((ulong)TerrainDB.TheaterDotMap.NumLODs) - 1UL);
                        for (int i = 0; i <= num; i++)
                        {
                            try
                            {
                                if (i == 2)
                                {
                                    TerrainDB.TheaterDotLxFiles[i] = theaterDotLxFileReader.LoadTheaterDotLxFile((uint)i, bmsConfig.TerrainDir, TileSet);
                                }
                            }
                            catch (Exception ex2)
                            {
                                if (i == 2)
                                {
                                    MessageBox.Show(string.Concat(new string[]
                                    {
                                        "Failed to load terrain files: L",
                                        Conversions.ToString(i),
                                        "/O",
                                        Conversions.ToString(i),
                                        "\r\n\r\nNo elevation data available"
                                    }), "Caution", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                        flag = true;
                    }
                    else
                    {
                        MessageBox.Show("Terrain elevation files not found", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        flag = false;
                    }
                }
                if (!flag)
                    TerrainDB = null;
            }

            IsNewTerrain = CheckNewTerrain();
            log.Debug("<< LoadTerrain");
        }

        private bool CheckNewTerrain()
        {
            return File.Exists(bmsConfig.TerrainDir + "NewTerrain\\Heightmaps\\Heightmap.raw");
        }

        public int GetEmbNr(string extention)
        {
            checked
            {
                for (int i = 0; i < NumEmbeddedFiles; i++)
                {
                    if (extention == EmbeddedFileInfoTabel[i].Ext)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        public void ReadTea(byte[] bytes, int Version)
        {
            TeaFile t = new TeaFile(bytes, Version);
            TeamTable.AddRange(t.Teams);
            CorrectTeaName();
        }

        public void ReadStationsIls()
        {
            log.Debug(">> ReadStationsIls");
            string[] array = new string[0];
            string text = bmsConfig.CampaignDir + "stations+ils.dat";
            log.InfoFormat("Load stations ils file {0}", text);
            Array.Resize<StationsILSData>(ref this.arrStatIls, 0);
            checked
            {
                if (File.Exists(text))
                {
                    try
                    {
                        FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        StreamReader streamReader = new StreamReader(fileStream);
                        int num = 0;
                        //string text2 = "";
                        while (!streamReader.EndOfStream)
                        {
                            Array.Resize<string>(ref array, array.Length + 1);
                            string text3 = streamReader.ReadLine();
                            text3 = text3.Replace("\t", " ");
                            text3 = text3.Replace("   ", " ");
                            text3 = text3.Replace("   ", " ");
                            text3 = text3.Replace("  ", " ");
                            text3 = text3.Replace("  ", " ");
                            array[num] = text3;
                            if ((Operators.CompareString(Strings.Mid(text3, 1, 1), "#", false) != 0) & (text3.Length > 3))
                            {
                                string[] array2 = Strings.Split(text3, " ", -1, CompareMethod.Binary);
                                if (array2.Count<string>() >= 12)
                                {
                                    Array.Resize<StationsILSData>(ref arrStatIls, arrStatIls.Length + 1);
                                    arrStatIls[arrStatIls.Length - 1] = new StationsILSData();
                                    arrStatIls[arrStatIls.Length - 1].CampId = Conversions.ToShort(array2[0]);
                                    arrStatIls[arrStatIls.Length - 1].TCN_Channel = Conversions.ToShort(array2[1]);
                                    arrStatIls[arrStatIls.Length - 1].TCN_Band = array2[2];
                                    arrStatIls[arrStatIls.Length - 1].TCN_Callsign = Conversions.ToShort(array2[3]);
                                    arrStatIls[arrStatIls.Length - 1].TCN_Range = Conversions.ToShort(array2[4]);
                                    arrStatIls[arrStatIls.Length - 1].TCN_Type = Conversions.ToShort(array2[5]);
                                    arrStatIls[arrStatIls.Length - 1].UHF = Conversions.ToInteger(array2[6]);
                                    arrStatIls[arrStatIls.Length - 1].VHF = Conversions.ToInteger(array2[7]);
                                    arrStatIls[arrStatIls.Length - 1].ILS_1 = Conversions.ToInteger(array2[8]);
                                    arrStatIls[arrStatIls.Length - 1].ILS_2 = Conversions.ToInteger(array2[9]);
                                    arrStatIls[arrStatIls.Length - 1].ILS_3 = Conversions.ToInteger(array2[10]);
                                    arrStatIls[arrStatIls.Length - 1].ILS_4 = Conversions.ToInteger(array2[11]);
                                    if (array2.Count<string>() >= 15)
                                    {
                                        arrStatIls[arrStatIls.Length - 1].OpsUHF = Conversions.ToInteger(array2[12]);
                                        arrStatIls[arrStatIls.Length - 1].GroundUHF = Conversions.ToInteger(array2[13]);
                                        arrStatIls[arrStatIls.Length - 1].ApproachUHF = Conversions.ToInteger(array2[14]);
                                        arrStatIls[arrStatIls.Length - 1].LsoUHF = Conversions.ToInteger(array2[15]);
                                    }
                                    if (array2.Count<string>() >= 17)
                                    {
                                        arrStatIls[arrStatIls.Length - 1].ATIS_freq_VHF = Conversions.ToInteger(array2[16]);
                                    }
                                }
                                if (num > 1 && Operators.CompareString(Strings.Mid(array[num - 2], 1, 1), "#", false) == 0)
                                {
                                    text3 = array[num - 2];
                                    text3 = text3.Replace("#", "");
                                    text3 = Strings.Trim(text3);
                                    arrStatIls[arrStatIls.Length - 1].Comment1 = text3;
                                }
                                if (num > 0 && Operators.CompareString(Strings.Mid(array[num - 1], 1, 1), "#", false) == 0)
                                {
                                    text3 = array[num - 1];
                                    text3 = text3.Replace("#", "");
                                    text3 = Strings.Trim(text3);
                                    arrStatIls[arrStatIls.Length - 1].Comment2 = text3;
                                }
                                /*int num2;
                                if (num2 == 0)
                                {
                                    int num3 = num - 3;
                                    for (int i = 0; i <= num3; i++)
                                    {
                                        //text2 = text2 + array[i] + "\r\n";
                                    }
                                }
                                num2 = num;*/
                            }
                            num++;
                        }
                        fileStream.Flush();
                        fileStream.Close();

                        //this.PopulateNavaids();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error has occurred with reading \r\n" + text + "\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        //this.PopulateNavaids();
                        return;
                    }
                }
            }
            log.Debug("<< ReadStationsIls");
        }


        public (Objective?, Objective?, Objective?) FindFlightAirbases(Flight currentFlight)
        {

            Objective abDep = null;
            Objective abArr = null;
            Objective abAlt = null;

            IEnumerable<Objective> abList = GetAirbasesAndAirstrips();

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
                    }
                    if (ab != null && (currentFlight.waypoints[i].Action == 7 || currentFlight.waypoints[i].Action == 27) && abArr == null)
                    {
                        abArr = ab;
                    }
                    if (ab != null && (currentFlight.waypoints[i].Action == 7 || currentFlight.waypoints[i].Action == 27) && abArr != null)
                    {
                        abAlt = ab;
                    }
                }
            }

            if (abArr != null && abAlt != null && abArr.id == abAlt.id)
                abAlt = null;

            return (abDep, abArr, abAlt);
        }
    }
}
