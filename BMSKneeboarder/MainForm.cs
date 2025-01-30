using BMSKneeboarder.Bms;
using BMSKneeboarder.Bms.Model;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Text;
using BCnEncoder.Encoder;
using BCnEncoder.Shared;
using System.Text.RegularExpressions;
using BMSKneeboarder.Bms.UI;
using System.Globalization;
using BMSKneeboarder.Bms.Model.Terrain;
using log4net;
using System.Xml.Linq;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Imaging;

namespace BMSKneeboarder
{
    public partial class MainForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger("default");
        public MainForm()
        {
            InitializeComponent();
        }

        private BmsStringUtils SH = new BmsStringUtils();

        MissionData missionData;
        BmsConfig bmsConfig = new BmsConfig();
        public int intObjFileVer;
        private int g_nObectiveDataReadMode = 0;
        private int intFileVer = 200;
        private string missionFileName = string.Empty;

        private Regex L16_Data = new Regex(@"flight_number: (?<flight>\d+)\n*\s*stn_number: (?<stn_ch>\d+)\n*\s*f2f_channel: (?<f2f_ch>\d*)\n*\s*mission_channel: (?<msn_ch>\d*)\n*\s*ew_channel: (?<ew_ch>-?\d*)");

        private void TheaterSelected()
        {
            log.Debug(">> TheaterSelected");
            TheaterListItem item = cbTheater.SelectedItem as TheaterListItem;
            log.InfoFormat("TheaterSelected {0}", item == null ? "null" : item.Name);
            if (item != null)
            {
                if (missionData != null)
                    missionData.TileSet = "";

                string[] lines = File.ReadAllLines(bmsConfig.BmsDataDir + item.TheaterFile);
                foreach (string line in lines)
                {
                    string s = line.Trim();
                    if (s.ToLower().StartsWith("campaigndir"))
                        bmsConfig.CampaignDir = bmsConfig.BmsDataDir + s.Substring(12) + Path.DirectorySeparatorChar;
                    if (s.ToLower().StartsWith("objectdir"))
                    {
                        bmsConfig.DefaultObjectDir = bmsConfig.BmsDataDir + s.Substring(10) + Path.DirectorySeparatorChar;
                        bmsConfig.ObjectDir = bmsConfig.BmsDataDir + s.Substring(10) + Path.DirectorySeparatorChar;
                    }
                    if (s.ToLower().StartsWith("3ddatadir"))
                    {
                        bmsConfig.KBFilesDir = bmsConfig.BmsDataDir + s.Substring(10) + Path.DirectorySeparatorChar;
                    }
                    if (s.ToLower().StartsWith("terraindir"))
                        bmsConfig.TerrainDir = bmsConfig.BmsDataDir + s.Substring(11) + Path.DirectorySeparatorChar;
                    if (s.ToLower().StartsWith("artdir"))
                    {
                        bmsConfig.ArtDir = bmsConfig.BmsDataDir + s.Substring(7);
                        if (bmsConfig.ArtDir.ToLower().EndsWith("art"))
                            bmsConfig.ArtDir += Path.DirectorySeparatorChar;
                        else
                            bmsConfig.ArtDir += Path.DirectorySeparatorChar + "Art" + Path.DirectorySeparatorChar;
                    }
                    if (missionData != null && s.ToLower().StartsWith("tileset"))
                    {
                        missionData.TileSet = s.Substring(8).Trim().Replace("\"", "");
                        log.InfoFormat("TileSet {0}", missionData.TileSet);
                    }
                }

                bmsConfig.Log();
                
            }
            log.Debug("<< TheaterSelected");
        }

        private void ReadPlt(byte[] PilotCampFile)
        {
            log.Debug(">> ReadPlt");
            int num = 0;
            int numPltEntries = (int)BitConverter.ToInt16(PilotCampFile, num);
            log.InfoFormat("numPltEntries = {0}", numPltEntries);
            checked
            {
                num += 2;
                for (int i = 0; i <= numPltEntries - 1; i++)
                {
                    BmsStructs.Pilots p = new BmsStructs.Pilots();
                    p.Usage = BitConverter.ToUInt16(PilotCampFile, num);
                    num += 2;
                    p.Photo = Buffer.GetByte(PilotCampFile, num);
                    num++;
                    p.Voice = Buffer.GetByte(PilotCampFile, num);
                    num++;
                    p.Name = this.missionData.StringText[2300 + i];

                    missionData.PilotList.Add(p);
                }
                int numCallEntries = (int)BitConverter.ToInt16(PilotCampFile, num);
                //Array.Resize<F4Structs.Callsigns>(ref this.missionData.CallsignTable, this.NumCallEntries);
                num += 2;
                num++;
                for (int j = 0; j <= numCallEntries - 1; j++)
                {
                    BmsStructs.Callsigns cs = new BmsStructs.Callsigns();
                    cs.No = (short)Buffer.GetByte(PilotCampFile, num);
                    num++;
                    cs.Name = this.missionData.StringText[2000 + j];
                    missionData.CallsignList.Add(cs);
                }
            }
            log.Debug("<< ReadPlt");
        }

        public void LoadDatabase()
        {
            log.Debug(">> LoadDatabase");
            //AcDefTable acDefTable = new AcDefTable();
            ClassTable classTable = new ClassTable();
            bool flag = true;
            this.missionData.classTableEntries = classTable.LoadCT(bmsConfig.DefaultObjectDir, bmsConfig.ObjectDir + "FALCON4_CT.xml", ref flag);
            log.InfoFormat("Loaded {0} class table rows", missionData.classTableEntries.Length);

            VehicleTable vehicleTable = new VehicleTable();
            ObjectTable objectTable = new ObjectTable();
            UnitTable unitTable = new UnitTable();
            PtHeaderDataTable ptHeaderDataTable = new PtHeaderDataTable();
            FeatureEntryDataTable featureEntryDataTable = new FeatureEntryDataTable();
            missionData.ObjectDataEntries = objectTable.LoadOCD(bmsConfig.DefaultObjectDir, bmsConfig.ObjectDir + "FALCON4_OCD.xml", ref flag, this.g_nObectiveDataReadMode);
            log.InfoFormat("Loaded {0} object data entries", missionData.ObjectDataEntries.Count);

            missionData.PtHeaderDataEntries = ptHeaderDataTable.LoadPHD(bmsConfig.DefaultObjectDir, bmsConfig.ObjectDir + "FALCON4_PHD.xml", ref flag, this.g_nObectiveDataReadMode);
            log.InfoFormat("Loaded {0} header data entries", missionData.PtHeaderDataEntries.Count);

            missionData.FeatureEntryDataTable = featureEntryDataTable.LoadFED(bmsConfig.DefaultObjectDir, bmsConfig.ObjectDir + "FALCON4_FED.xml", ref flag, this.g_nObectiveDataReadMode);
            log.InfoFormat("Loaded {0} feature entries", missionData.FeatureEntryDataTable.Length);

            /*new DirtyDataTable();
            FeatureTable featureTable = new FeatureTable();
            
            new IRSTTable();
            ObjectTable objectTable = new ObjectTable();
            PtDataTable ptDataTable = new PtDataTable();
            PtHeaderDataTable ptHeaderDataTable = new PtHeaderDataTable();
            new RadarTable();
            new RocketDataTable();
            new RwrTable();
            new SquadronStoresTable();
            SimWeaponTable simWeaponTable = new SimWeaponTable();
            
            
            new VisualDataTable();
            WeaponTable weaponTable = new WeaponTable();
            WeaponListData weaponListData = new WeaponListData();
            HDRTable hdrtable = new HDRTable();
            if (Operators.CompareString(Strings.Mid(this.objectdir, this.objectdir.Length, 1), "\\", false) != 0)
            {
                this.objectdir += "\\";
            }
            this.ClearDbAll();
            if ((this.MinorPart >= 34) & (this.Build > 17364))
            {
                this.blnReadFromXml = true;
            }
            else if (this.g_bUseXmlDatabase)
            {
                this.blnReadFromXml = true;
            }
            else if (this.blnReadFromXml)
            {
                this.blnReadFromXml = true;
            }
            else
            {
                this.blnReadFromXml = false;
            }
            this.LoadErrorText = "";
            DateTime now = DateTime.Now;
            checked
            {
                //if (this.blnReadFromXml)
                {
                    bool flag = this.blnReadFromXml;
                    this.Cursor = Cursors.WaitCursor;
                    fclsWait fclsWait = new fclsWait();
                    fclsWait.pgbWait.Maximum = 200;
                    fclsWait.StartPosition = FormStartPosition.Manual;
                    fclsWait.MainLoc = base.Location;
                    fclsWait.MainWidth = base.Width;
                    fclsWait.MainHeight = base.Height;
                    fclsWait.Width = 700;
                    fclsWait.Height = 116;
                    fclsWait.Show();
                    fclsWait.pgbWait.Value = 10;
                    fclsWait.Text = "Standby... Loading Falcon4_ACD.xml";
                    fclsWait.lblInfo.Text = this.objectdir;
                    fclsWait.Refresh();
                    this.SimACDefEntries = acDefTable.LoadACD(this.DefaultObjectdir, this.objectdir + "FALCON4_ACD.xml", ref flag);
                    if (!flag)
                    {
                        ref string ptr = ref this.LoadErrorText;
                        this.LoadErrorText = ptr + "ACD XML not found, reverting to binary.\r\n";
                        flag = this.blnReadFromXml;
                    }
                    fclsWait.pgbWait.Value = 20;
                    fclsWait.Text = "Standby... Loading Falcon4_CT.xml";
                    fclsWait.Refresh();
                    this.classTableEntries = classTable.LoadCT(this.DefaultObjectdir, this.objectdir + "FALCON4_CT.xml", ref flag);
                    if (!flag)
                    {
                        ref string ptr = ref this.LoadErrorText;
                        this.LoadErrorText = ptr + "CT XML not found, reverting to binary.\r\n";
                        flag = this.blnReadFromXml;
                    }
                    fclsWait.pgbWait.Value = 30;
                    fclsWait.Text = "Standby... Loading Falcon4_DDP.xml";
                    fclsWait.Refresh();
                    fclsWait.pgbWait.Value = 40;
                    fclsWait.Text = "Standby... Loading Falcon4_FCD.xml";
                    fclsWait.Refresh();
                    this.FeatureDataEntries = featureTable.LoadFCD(this.DefaultObjectdir, this.objectdir + "FALCON4_FCD.xml", ref flag);
                    if (!flag)
                    {
                        ref string ptr = ref this.LoadErrorText;
                        this.LoadErrorText = ptr + "FCD XML not found, reverting to binary.\r\n";
                        flag = this.blnReadFromXml;
                    }
                    fclsWait.pgbWait.Value = 50;
                    fclsWait.Text = "Standby... Loading Falcon4_FED.xml";
                    fclsWait.Refresh();
                    
                    if (!flag)
                    {
                        ref string ptr = ref this.LoadErrorText;
                        this.LoadErrorText = ptr + "FED XML not found, reverting to binary.\r\n";
                        flag = this.blnReadFromXml;
                    }
                    fclsWait.pgbWait.Value = 60;
                    fclsWait.Text = "Standby... Loading Falcon4_ICD.xml";
                    fclsWait.Refresh();
                    fclsWait.pgbWait.Value = 70;
                    fclsWait.Text = "Standby... Loading Falcon4_OCD.xml";
                    fclsWait.Refresh();
                    this.ObjectDataEntries = objectTable.LoadOCD(this.DefaultObjectdir, this.objectdir + "FALCON4_OCD.xml", ref flag, this.g_nObectiveDataReadMode);
                    if (!flag)
                    {
                        ref string ptr = ref this.LoadErrorText;
                        this.LoadErrorText = ptr + "OCD XML not found, reverting to binary.\r\n";
                        flag = this.blnReadFromXml;
                    }
                    fclsWait.pgbWait.Value = 80;
                    fclsWait.Text = "Standby... Loading Falcon4_PDX.xml";
                    fclsWait.Refresh();
                    this.PtDataEntriesExtended = ptDataTable.LoadPDX(this.DefaultObjectdir, this.objectdir + "FALCON4_PDX.xml", ref flag, this.g_nObectiveDataReadMode);
                    if (!flag)
                    {
                        ref string ptr = ref this.LoadErrorText;
                        this.LoadErrorText = ptr + "PDX XML not found, reverting to binary.\r\n";
                        flag = this.blnReadFromXml;
                    }
                    fclsWait.pgbWait.Value = 100;
                    fclsWait.Text = "Standby... Loading Falcon4_PHD.xml";
                    fclsWait.Refresh();
                    this.PtHeaderDataEntries = ptHeaderDataTable.LoadPHD(this.DefaultObjectdir, this.objectdir + "FALCON4_PHD.xml", ref flag, this.g_nObjectiveDataReadMode);
                    if (!flag)
                    {
                        ref string ptr = ref this.LoadErrorText;
                        this.LoadErrorText = ptr + "PHD XML not found, reverting to binary.\r\n";
                        flag = this.blnReadFromXml;
                    }
                    fclsWait.pgbWait.Value = 110;
                    fclsWait.Text = "Standby... Loading Falcon4_RCD.xml";
                    fclsWait.Refresh();
                    fclsWait.pgbWait.Value = 120;
                    fclsWait.Text = "Standby... Loading Falcon4_RKT.xml";
                    fclsWait.Refresh();
                    fclsWait.pgbWait.Value = 130;
                    fclsWait.Text = "Standby... Loading Falcon4_RWD.xml";
                    fclsWait.Refresh();
                    fclsWait.pgbWait.Value = 140;
                    fclsWait.Text = "Standby... Loading Falcon4_SSD.xml";
                    fclsWait.Refresh();
                    fclsWait.pgbWait.Value = 150;
                    fclsWait.Text = "Standby... Loading Falcon4_SWD.xml";
                    fclsWait.Refresh();
                    this.SimWeaponDataEntries = simWeaponTable.LoadSWD(this.DefaultObjectdir, this.objectdir + "FALCON4_SWD.xml", ref flag);
                    if (!flag)
                    {
                        ref string ptr = ref this.LoadErrorText;
                        this.LoadErrorText = ptr + "SWD XML not found, reverting to binary.\r\n";
                        flag = this.blnReadFromXml;
                    }
                    fclsWait.pgbWait.Value = 160;
                    fclsWait.Text = "Standby... Loading Falcon4_UCD.xml";
                    fclsWait.Refresh();
                    this.UnitDataEntries = unitTable.LoadUCD(this.DefaultObjectdir, this.objectdir + "FALCON4_UCD.xml", ref flag);
                    if (!flag)
                    {
                        ref string ptr = ref this.LoadErrorText;
                        this.LoadErrorText = ptr + "UCD XML not found, reverting to binary.\r\n";
                        flag = this.blnReadFromXml;
                    }
                    fclsWait.pgbWait.Value = 170;
                    fclsWait.Text = "Standby... Loading Falcon4_VCD.xml";
                    fclsWait.Refresh();*/
            this.missionData.UnitDataEntries = unitTable.LoadUCD(bmsConfig.DefaultObjectDir, bmsConfig.ObjectDir + "FALCON4_UCD.xml", ref flag);
            log.InfoFormat("Loaded {0} unit data entries", missionData.UnitDataEntries.Length);
            this.missionData.VehicleDataEntries = vehicleTable.LoadVCD(bmsConfig.DefaultObjectDir, bmsConfig.ObjectDir + "FALCON4_VCD.xml", ref flag);
            log.InfoFormat("Loaded {0} vehicle data entries", missionData.VehicleDataEntries.Length);
            /*fclsWait.pgbWait.Value = 180;
            fclsWait.Text = "Standby... Loading Falcon4_VSD.xml";
            fclsWait.Refresh();
            fclsWait.pgbWait.Value = 190;
            fclsWait.Text = "Standby... Loading Falcon4_WCD.xml";
            fclsWait.Refresh();
            this.WeaponDataEntries = weaponTable.LoadWCD(this.DefaultObjectdir, this.objectdir + "FALCON4_WCD.xml", ref flag);
            if (!flag)
            {
                ref string ptr = ref this.LoadErrorText;
                this.LoadErrorText = ptr + "WCD XML not found, reverting to binary.\r\n";
                flag = this.blnReadFromXml;
            }
            fclsWait.pgbWait.Value = 200;
            fclsWait.Text = "Standby... Loading Falcon4_WLD.xml";
            fclsWait.Refresh();
            this.WeaponListDataTable = weaponListData.LoadWLD(this.DefaultObjectdir, this.objectdir + "FALCON4_WLD.xml", ref flag);
            if (!flag)
            {
                ref string ptr = ref this.LoadErrorText;
                this.LoadErrorText = ptr + "WLD XML not found, reverting to binary.\r\n";
                flag = this.blnReadFromXml;
            }*/
            if (this.g_nObectiveDataReadMode == 0)
            {
                string text = bmsConfig.ObjectDir + "ObjectiveRelatedData";
                BmsStructs.ItemCountVec[] array = featureEntryDataTable.ReadXmlFedItemCount(text);
                if (array != null)
                {
                    int num = missionData.ObjectDataEntries.Count - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        missionData.ObjectDataEntries[i].FirstFeature = array[i].First;
                        missionData.ObjectDataEntries[i].Features = (byte)array[i].Count;
                    }
                }
                BmsStructs.ItemCountVec[] array2 = ptHeaderDataTable.ReadXmlPhdItemCount(text);
                if (array2 != null)
                {
                    int num2 = missionData.ObjectDataEntries.Count - 1;
                    for (int j = 0; j <= num2; j++)
                    {
                        missionData.ObjectDataEntries[j].PtDataIndex = (short)array2[j].First;
                    }
                }
                if (missionData.PtHeaderDataEntries != null)
                {
                    int num3 = missionData.PtHeaderDataEntries.Count - 1;
                    for (int k = 1; k <= num3; k++)
                    {
                        int num4 = k - 1;
                        num4 = Math.Max(0, num4);
                        missionData.PtHeaderDataEntries[k].first = missionData.PtHeaderDataEntries[num4].first + (int)missionData.PtHeaderDataEntries[num4].count;
                        if (k == 1)
                        {
                            List<BmsStructs.PtHeaderDataType> ptHeaderDataEntries = missionData.PtHeaderDataEntries;
                            int num5 = k;
                            ref int ptr2 = ref ptHeaderDataEntries[num5].first;
                            ptHeaderDataEntries[num5].first = ptr2 + 1;
                        }
                    }
                }
            }
            /*fclsWait.pgbWait.Value = fclsWait.pgbWait.Maximum;
            fclsWait.Text = "Done";
            fclsWait.Refresh();
            fclsWait.Dispose();
            this.Cursor = Cursors.Arrow;
        }
        else
        {
            bool flag = this.blnReadFromXml;
            this.SimACDefEntries = acDefTable.LoadACD(this.DefaultObjectdir, this.objectdir + "FALCON4.acd", ref flag);
            this.classTableEntries = classTable.LoadCT(this.DefaultObjectdir, this.objectdir + "FALCON4.ct", ref flag);
            this.FeatureDataEntries = featureTable.LoadFCD(this.DefaultObjectdir, this.objectdir + "FALCON4.fcd", ref flag);
            this.FeatureEntryDataTable = featureEntryDataTable.LoadFED(this.DefaultObjectdir, this.objectdir + "FALCON4.fed", ref flag, this.g_nObectiveDataReadMode);
            his.ObjectDataEntries = objectTable.LoadOCD(this.DefaultObjectdir, this.objectdir + "FALCON4.ocd", ref flag, this.g_nObectiveDataReadMode);
            this.SimWeaponDataEntries = simWeaponTable.LoadSWD(this.DefaultObjectdir, this.objectdir + "FALCON4.swd", ref flag);
            this.UnitDataEntries = unitTable.LoadUCD(this.DefaultObjectdir, this.objectdir + "FALCON4.ucd", ref flag);
            this.VehicleDataEntries = vehicleTable.LoadVCD(this.DefaultObjectdir, this.objectdir + "FALCON4.vcd", ref flag);
            this.WeaponDataEntries = weaponTable.LoadWCD(this.DefaultObjectdir, this.objectdir + "FALCON4.wcd", ref flag);
            this.WeaponListDataTable = weaponListData.LoadWLD(this.DefaultObjectdir, this.objectdir + "FALCON4.wld", ref flag);
        }
        this.LoadDatabaseChanges();
        DateTime.Now - now;
        string text2 = this.threeddatadir + "KoreaObj.hdr";
        this.HDRTable = default(F4Structs.HDR);
        if ((this.MinorPart >= 38) & (this.Build >= 24465))
        {
            if (!this.bgwCreateNewHDR.IsBusy)
            {
                this.bgwCreateNewHDR.WorkerSupportsCancellation = true;
                this.bgwCreateNewHDR.WorkerReportsProgress = true;
                this.bgwCreateNewHDR.RunWorkerAsync();
            }
        }
        else if (File.Exists(text2))
        {
            this.HDRTable = hdrtable.ReadHDRTable(text2);
        }
        else
        {
            int num6 = -1;
            int num7 = this.arrTheaters.Length - 1;
            for (int l = 0; l <= num7; l++)
            {
                if (Operators.CompareString(this.arrTheaters[l].Name, "Korea", false) == 0)
                {
                    break;
                }
                if (num6 != -1)
                {
                    this.DefObjDir = this.arrTheaters[num6].objectdir;
                }
                else
                {
                    this.DefObjDir = this.strFalconDir + "\\data\\terrdata\\objects\\";
                }
                if (File.Exists(this.DefObjDir + "KoreaObj.hdr"))
                {
                    this.HDRTable = hdrtable.ReadHDRTable(this.DefObjDir + "KoreaObj.hdr");
                }
            }
        }
        if (Operators.CompareString(this.LoadErrorText, "", false) != 0)
        {
            MessageBox.Show(this.objectdir + "\r\n" + this.LoadErrorText, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        this.blnCT = false;
        this.blnUCD = false;
        this.blnVCD = false;
        if (this.classTableEntries != null)
        {
            this.blnCT = true;
        }
        if (this.UnitDataEntries != null)
        {
            this.blnUCD = true;
        }
        if (this.VehicleDataEntries != null)
        {
            this.blnVCD = true;
        }
        if (!this.blnCT & !this.blnUCD & !this.blnVCD)
        {
            this.blnFalconFound = true;
            this.blnFalconDb = true;
            this.mnuOpenMission.Enabled = true;
            this.cntDataCard.btnWeather.Enabled = true;
            this.cntPerformance.btnLoadout.Enabled = true;
            base.Update();
        }
        if (!this.blnFalconFound)
        {
            MessageBox.Show("No Falcon install found, reverted to default Falcon database");
        }
        this.OpenRackData();
        this.Cursor = Cursors.Arrow;
    }*/
            log.Debug("<< LoadDatabase");
        }

        private void ReadCampaign(byte[] uncompressedCampFile)
        {
            log.Debug(">> ReadCampaign");
            missionData.CampaignTable = new BmsStructs.CampaignClassDataType[5];
            missionData.TeamBasicInfoTable = new BmsStructs.TeamBasicInfo[15];

            int num = 0;
            this.missionData.CampaignTable[0].CurrentTime = BitConverter.ToUInt32(uncompressedCampFile, num);
            checked
            {
                num += 4;
                this.missionData.CampaignTable[0].StartTime = BitConverter.ToUInt32(uncompressedCampFile, num);
                //this.L.CampaignHours = this.missionData.CampaignTable[0].StartTime;
                num += 4;
                this.missionData.CampaignTable[0].TimeLimit = BitConverter.ToUInt32(uncompressedCampFile, num);
                num += 4;
                this.missionData.CampaignTable[0].TE_VictoryPoints = BitConverter.ToInt32(uncompressedCampFile, num);
                num += 4;
                this.missionData.CampaignTable[0].TE_Type = BitConverter.ToInt32(uncompressedCampFile, num);
                num += 4;
                this.missionData.CampaignTable[0].TE_number_teams = BitConverter.ToInt32(uncompressedCampFile, num);
                num += 4;
                Array.Resize<int>(ref this.missionData.CampaignTable[0].TE_number_aircraft, 8);
                int num2 = 0;
                do
                {
                    this.missionData.CampaignTable[0].TE_number_aircraft[num2] = BitConverter.ToInt32(uncompressedCampFile, num);
                    num += 4;
                    num2++;
                }
                while (num2 <= 7);
                Array.Resize<int>(ref this.missionData.CampaignTable[0].TE_number_f16s, 8);
                int num3 = 0;
                do
                {
                    this.missionData.CampaignTable[0].TE_number_f16s[num3] = BitConverter.ToInt32(uncompressedCampFile, num);
                    num += 4;
                    num3++;
                }
                while (num3 <= 7);
                this.missionData.CampaignTable[0].TE_team = BitConverter.ToInt32(uncompressedCampFile, num);
                num += 4;
                Array.Resize<int>(ref this.missionData.CampaignTable[0].TE_team_pts, 8);
                int num4 = 0;
                do
                {
                    this.missionData.CampaignTable[0].TE_team_pts[num4] = BitConverter.ToInt32(uncompressedCampFile, num);
                    num += 4;
                    num4++;
                }
                while (num4 <= 7);
                this.missionData.CampaignTable[0].TE_flags = BitConverter.ToInt32(uncompressedCampFile, num);
                num += 4;
                int num5 = 0;
                do
                {
                    this.missionData.TeamBasicInfoTable[num5].teamFlag = Buffer.GetByte(uncompressedCampFile, num);
                    num++;
                    this.missionData.TeamBasicInfoTable[num5].teamColor = Buffer.GetByte(uncompressedCampFile, num);
                    num++;
                    this.missionData.TeamBasicInfoTable[num5].teamName = Strings.Trim(Encoding.Default.GetString(uncompressedCampFile, num, 20));
                    num += 20;
                    this.missionData.TeamBasicInfoTable[num5].teamMotto = Strings.Trim(new string(Encoding.Default.GetChars(uncompressedCampFile, num, 200)));
                    num += 200;
                    num5++;
                }
                while (num5 <= 7);
                this.missionData.CampaignTable[0].LastMajorEvent = BitConverter.ToUInt32(uncompressedCampFile, num);
                num += 4;
                this.missionData.CampaignTable[0].LastResupply = BitConverter.ToUInt32(uncompressedCampFile, num);
                num += 4;
                this.missionData.CampaignTable[0].LastRepair = BitConverter.ToUInt32(uncompressedCampFile, num);
                num += 4;
                this.missionData.CampaignTable[0].LastReinforcement = BitConverter.ToUInt32(uncompressedCampFile, num);
                num += 4;
                this.missionData.CampaignTable[0].TimeStamp = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                this.missionData.CampaignTable[0].Group = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                this.missionData.CampaignTable[0].GroundRatio = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                this.missionData.CampaignTable[0].AirRatio = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                this.missionData.CampaignTable[0].AirDefenseRatio = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                this.missionData.CampaignTable[0].NavalRatio = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                this.missionData.CampaignTable[0].Brief = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                this.missionData.CampaignTable[0].TheaterSizeX = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                this.missionData.CampaignTable[0].TheaterSizeY = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                this.missionData.CampaignTable[0].CurrentDay = Buffer.GetByte(uncompressedCampFile, num);
                num++;
                this.missionData.CampaignTable[0].ActiveTeam = Buffer.GetByte(uncompressedCampFile, num);
                num++;
                this.missionData.CampaignTable[0].DayZero = Buffer.GetByte(uncompressedCampFile, num);
                num++;
                this.missionData.CampaignTable[0].EndgameResult = Buffer.GetByte(uncompressedCampFile, num);
                num++;
                this.missionData.CampaignTable[0].Situation = Buffer.GetByte(uncompressedCampFile, num);
                num++;
                this.missionData.CampaignTable[0].EnemyAirExp = Buffer.GetByte(uncompressedCampFile, num);
                num++;
                this.missionData.CampaignTable[0].EnemyADExp = Buffer.GetByte(uncompressedCampFile, num);
                num++;
                this.missionData.CampaignTable[0].BullseyeName = Buffer.GetByte(uncompressedCampFile, num);
                num++;
                this.missionData.CampaignTable[0].BullseyeX = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                this.missionData.CampaignTable[0].BullseyeY = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                this.missionData.CampaignTable[0].TheaterName = BmsUtils.FixName(new string(Encoding.Default.GetChars(uncompressedCampFile, num, 40)));
                num += 40;
                this.missionData.CampaignTable[0].Scenario = BmsUtils.FixName(new string(Encoding.Default.GetChars(uncompressedCampFile, num, 40)));
                num += 40;
                this.missionData.CampaignTable[0].SaveFile = BmsUtils.FixName(Encoding.Default.GetString(uncompressedCampFile, num, 40));
                num += 40;
                this.missionData.CampaignTable[0].UIName = BmsUtils.FixName(new string(Encoding.Default.GetChars(uncompressedCampFile, num, 40)));
                num += 40;
                this.missionData.CampaignTable[0].PlayerSquadronID.num = BitConverter.ToUInt32(uncompressedCampFile, num);
                num += 4;
                this.missionData.CampaignTable[0].PlayerSquadronID.creator = BitConverter.ToUInt32(uncompressedCampFile, num);
                num += 4;
                this.missionData.CampaignTable[0].NumRecentEventEntries = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                Array.Resize<BmsStructs.EventNode>(ref this.missionData.CampaignTable[0].RecentEventEntries, (int)this.missionData.CampaignTable[0].NumRecentEventEntries);
                if (this.missionData.CampaignTable[0].NumRecentEventEntries > 0)
                {
                    int num6 = (int)(this.missionData.CampaignTable[0].NumRecentEventEntries - 1);
                    for (int i = 0; i <= num6; i++)
                    {
                        BmsStructs.EventNode eventNode = default(BmsStructs.EventNode);
                        eventNode.x = BitConverter.ToInt16(uncompressedCampFile, num);
                        num += 2;
                        eventNode.y = BitConverter.ToInt16(uncompressedCampFile, num);
                        num += 2;
                        eventNode.time = BitConverter.ToUInt32(uncompressedCampFile, num);
                        num += 4;
                        eventNode.flags = Buffer.GetByte(uncompressedCampFile, num);
                        num++;
                        eventNode.Team = Buffer.GetByte(uncompressedCampFile, num);
                        num++;
                        num += 2;
                        num += 4;
                        num += 4;
                        eventNode.eventTextSize = BitConverter.ToUInt16(uncompressedCampFile, num);
                        num += 2;
                        eventNode.eventText = Encoding.Default.GetString(uncompressedCampFile, num, (int)eventNode.eventTextSize);
                        num += (int)eventNode.eventTextSize;
                        this.missionData.CampaignTable[0].RecentEventEntries[i] = eventNode;
                    }
                }
                this.missionData.CampaignTable[0].NumPriorityEventEntries = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                Array.Resize<BmsStructs.EventNode>(ref this.missionData.CampaignTable[0].PriorityEventEntries, (int)this.missionData.CampaignTable[0].NumPriorityEventEntries);
                if (this.missionData.CampaignTable[0].NumPriorityEventEntries > 0)
                {
                    int num7 = (int)(this.missionData.CampaignTable[0].NumPriorityEventEntries - 1);
                    for (int j = 0; j <= num7; j++)
                    {
                        BmsStructs.EventNode eventNode2 = default(BmsStructs.EventNode);
                        eventNode2.x = BitConverter.ToInt16(uncompressedCampFile, num);
                        num += 2;
                        eventNode2.y = BitConverter.ToInt16(uncompressedCampFile, num);
                        num += 2;
                        eventNode2.time = BitConverter.ToUInt32(uncompressedCampFile, num);
                        num += 4;
                        eventNode2.flags = Buffer.GetByte(uncompressedCampFile, num);
                        num++;
                        eventNode2.Team = Buffer.GetByte(uncompressedCampFile, num);
                        num++;
                        num += 2;
                        num += 4;
                        num += 4;
                        eventNode2.eventTextSize = BitConverter.ToUInt16(uncompressedCampFile, num);
                        num += 2;
                        eventNode2.eventText = Encoding.Default.GetString(uncompressedCampFile, num, (int)eventNode2.eventTextSize);
                        num += (int)eventNode2.eventTextSize;
                        this.missionData.CampaignTable[0].PriorityEventEntries[j] = eventNode2;
                    }
                }
                this.missionData.CampaignTable[0].CampMapSize = BitConverter.ToUInt16(uncompressedCampFile, num);
                num += 2;
                Array.Resize<byte>(ref this.missionData.CampaignTable[0].CampMap, (int)this.missionData.CampaignTable[0].CampMapSize);
                int num8 = (int)(this.missionData.CampaignTable[0].CampMapSize - 1);
                for (int k = 0; k <= num8; k++)
                {
                    this.missionData.CampaignTable[0].CampMap[k] = Buffer.GetByte(uncompressedCampFile, num);
                    num++;
                }
                this.missionData.CampaignTable[0].LastIndexNum = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                this.missionData.CampaignTable[0].NumAvailableSquadrons = BitConverter.ToInt16(uncompressedCampFile, num);
                num += 2;
                Array.Resize<BmsStructs.SquadInfo>(ref this.missionData.CampaignTable[0].SquadInfo, (int)this.missionData.CampaignTable[0].NumAvailableSquadrons);
                int num9 = (int)(this.missionData.CampaignTable[0].NumAvailableSquadrons - 1);
                for (int l = 0; l <= num9; l++)
                {
                    this.missionData.CampaignTable[0].SquadInfo[l].X = BitConverter.ToSingle(uncompressedCampFile, num);
                    num += 4;
                    this.missionData.CampaignTable[0].SquadInfo[l].Y = BitConverter.ToSingle(uncompressedCampFile, num);
                    num += 4;
                    this.missionData.CampaignTable[0].SquadInfo[l].id.num = BitConverter.ToUInt32(uncompressedCampFile, num);
                    num += 4;
                    this.missionData.CampaignTable[0].SquadInfo[l].id.creator = BitConverter.ToUInt32(uncompressedCampFile, num);
                    num += 4;
                    this.missionData.CampaignTable[0].SquadInfo[l].descriptionIndex = BitConverter.ToInt16(uncompressedCampFile, num);
                    num += 2;
                    this.missionData.CampaignTable[0].SquadInfo[l].nameId = BitConverter.ToInt16(uncompressedCampFile, num);
                    num += 2;
                    this.missionData.CampaignTable[0].SquadInfo[l].airbaseIcon = BitConverter.ToInt16(uncompressedCampFile, num);
                    num += 2;
                    this.missionData.CampaignTable[0].SquadInfo[l].squadronPath = BitConverter.ToInt16(uncompressedCampFile, num);
                    num += 2;
                    this.missionData.CampaignTable[0].SquadInfo[l].specialty = Buffer.GetByte(uncompressedCampFile, num);
                    num++;
                    this.missionData.CampaignTable[0].SquadInfo[l].currentStrength = Buffer.GetByte(uncompressedCampFile, num);
                    num++;
                    this.missionData.CampaignTable[0].SquadInfo[l].country = Buffer.GetByte(uncompressedCampFile, num);
                    num++;
                    if (true /*this.intFileVer >= 102*/)
                    {
                        Array.Resize<char>(ref this.missionData.CampaignTable[0].SquadInfo[l].airbaseName, 80);
                        this.missionData.CampaignTable[0].SquadInfo[l].airbaseName = Conversions.ToCharArrayRankOne(BmsUtils.FixName(Encoding.Default.GetString(uncompressedCampFile, num, 80)));
                        num += 80;
                        this.missionData.CampaignTable[0].SquadInfo[l].padding = Buffer.GetByte(uncompressedCampFile, num);
                        num++;
                        this.missionData.CampaignTable[0].SquadInfo[l].flags = BitConverter.ToInt32(uncompressedCampFile, num);
                        num += 4;
                        this.missionData.CampaignTable[0].SquadInfo[l].campId = BitConverter.ToInt16(uncompressedCampFile, num);
                        num += 2;
                        this.missionData.CampaignTable[0].SquadInfo[l].texSet = BitConverter.ToInt16(uncompressedCampFile, num);
                        num += 2;
                        Array.Resize<char>(ref this.missionData.CampaignTable[0].SquadInfo[l].squadronName, 80);
                        this.missionData.CampaignTable[0].SquadInfo[l].squadronName = Conversions.ToCharArrayRankOne(BmsUtils.FixName(Encoding.Default.GetString(uncompressedCampFile, num, 80)));
                        num += 80;
                    }
                    else
                    {
                        Array.Resize<char>(ref this.missionData.CampaignTable[0].SquadInfo[l].airbaseName, 40);
                        this.missionData.CampaignTable[0].SquadInfo[l].airbaseName = Conversions.ToCharArrayRankOne(BmsUtils.FixName(Encoding.Default.GetString(uncompressedCampFile, num, 40)));
                        num += 40;
                        this.missionData.CampaignTable[0].SquadInfo[l].squadronName = Conversions.ToCharArrayRankOne("");
                        this.missionData.CampaignTable[0].SquadInfo[l].padding = Buffer.GetByte(uncompressedCampFile, num);
                        num++;
                    }
                }
                this.missionData.CampaignTable[0].Tempo = Buffer.GetByte(uncompressedCampFile, num);
                num++;
                this.missionData.CampaignTable[0].CreatorIP = BitConverter.ToUInt32(uncompressedCampFile, num);
                num += 4;
                this.missionData.CampaignTable[0].CreationTime = BitConverter.ToUInt32(uncompressedCampFile, num);
                num += 4;
                this.missionData.CampaignTable[0].CreationRand = BitConverter.ToUInt32(uncompressedCampFile, num);
                num += 4;
                //this.CorrectTeamName();
            }

            missionData.CampW = 3358699.5;
            missionData.CampH = 3358699.5;

            if (missionData.CampaignTable.Length > 0 && missionData.CampaignTable[0].TheaterSizeX == 2048)
            {
                missionData.CampW = 6717399.0;
                missionData.CampH = 6717399.0;
            }

            log.InfoFormat("CampW = {0}", missionData.CampW);
            log.InfoFormat("CampH = {0}", missionData.CampH);

            log.Debug("<< ReadCampaign");
        }

        private void GetTheater(string teFile)
        {
            log.DebugFormat(">> GetTheater {0}", teFile);
            checked
            {
                if (File.Exists(teFile))
                {
                    this.Cursor = Cursors.WaitCursor;
                    byte[] array = new byte[(int)(new FileInfo(teFile).Length - 1L) + 1];
                    using (FileStream fileStream = new FileStream(teFile, FileMode.Open))
                    {
                        fileStream.Seek(0L, SeekOrigin.Begin);
                        fileStream.Read(array, 0, array.Length);
                        fileStream.Close();
                    }
                    int num = BitConverter.ToInt32(array, 0);
                    int num2 = BitConverter.ToInt32(array, num);
                    num += 4;
                    int num3 = num2 - 1;
                    for (int i = 0; i <= num3; i++)
                    {
                        byte b = array[num];
                        num++;
                        string @string = Encoding.Default.GetString(array, num, (int)b);
                        num += (int)b;
                        uint num4 = BitConverter.ToUInt32(array, num);
                        num += 4;
                        BitConverter.ToUInt32(array, num);
                        num += 4;
                        if (new FileInfo(@string).Extension.ToUpperInvariant() == ".CMP")
                        {
                            int num5 = (int)num4;
                            int num6 = BitConverter.ToInt32(array, num5);
                            num5 += 4;
                            int num7 = BitConverter.ToInt32(array, num5);
                            num5 += 4;
                            byte[] array2 = new byte[num6 + 1];
                            Array.Copy(array, num5, array2, 0, num6);
                            byte[] array3 = Codec.Decompress(array2, num7);
                            try
                            {
                                this.ReadCampaign(array3);
                                break;
                            }
                            catch (Exception ex)
                            {
                                log.Error("Could not read Campaign data. Your mission might be corrupted");
                                MessageBox.Show("Could not read Campaign data\r\nYour mission might be corrupted", "Caution", MessageBoxButtons.OK);
                                //this.ClearTables();
                                return;
                            }
                        }
                    }
                    //this.blnMissionLoaded = true;
                    //this.SetTheater();
                }
            }
            log.Debug("<< GetTheater");
        }

        private void ReadUniFile(BmsStructs.EntityClassType[] classTableEntries, int version, byte[] contents, string l16filename)
        {
            log.Debug(">> ReadUniFile");
            log.InfoFormat("l16filename = {0}", l16filename);

            string l16text = string.Empty;
            if (Path.Exists(l16filename))
            {
                l16text = File.ReadAllText(l16filename);
            }

            Unit[] units = new UniFile(contents, version, classTableEntries, false).units;
            log.InfoFormat("Loaded {0} units", units.Length);
            checked
            {
                MatchCollection LinkEntries = L16_Data.Matches(l16text);

                if (units != null)
                {
                    foreach (Unit unit in units)
                    {
                        if (unit is AirUnit)
                        {
                            if (unit is Flight)
                            {
                                Flight flight = unit as Flight;

                                /*foreach (Match match in Regex.Matches(l16text, @"flights\s*\{\s*flight_number:\s*" + flight.campId + @"\s*stn_number:\s*(?<stn>\d+)"))
                                {
                                    if (match.Success && match.Groups.Count > 0)
                                    {
                                        flight.STN = match.Groups["stn"].Value;
                                    }
                                }*/
                                try
                                {
                                    Match res = LinkEntries.FirstOrDefault(x => x.Groups["flight"].Value == flight.campId.ToString());
                                    if (res != null && res.Success)
                                    {
                                        flight.STN = res.Groups["stn_ch"].Value;
                                        flight.F2F_ch = res.Groups["f2f_ch"].Value;
                                        flight.MSN_ch = res.Groups["msn_ch"].Value;
                                        flight.EW_ch = res.Groups["ew_ch"].Value == "-1" ? "000" : res.Groups["ew_ch"].Value;
                                    }
                                    //Array.Resize<Flight>(ref this.missionData.FlightTable, this.FlightNR + 1);
                                    missionData.FlightList.Add(flight);
                                }
                                catch (Exception) { 
                                
                                }
                            }
                            else if (unit is Package)
                            {
                                Package package = unit as Package;
                                missionData.PackageList.Add(package);
                            }
                            else if (unit is Squadron)
                            {
                                Squadron squadron = unit as Squadron;
                                missionData.SquadronList.Add(squadron);
                            }
                        }
                        else if (unit is GroundUnit)
                        {
                            GroundUnit groundUnit = unit as GroundUnit;
                            byte orders = groundUnit.orders;
                            short division = groundUnit.division;
                            BmsStructs.BmsId aobj = groundUnit.aobj;
                            if (unit is Battalion)
                            {
                                Battalion battalion = unit as Battalion;
                                this.missionData.BattalionList.Add(battalion);
                            }
                            else if (unit is Brigade)
                            {
                                Brigade brigade = unit as Brigade;
                                missionData.BrigadeList.Add(brigade);
                            }
                        }
                        else if (unit is TaskForce)
                        {
                            TaskForce taskForce = unit as TaskForce;
                            missionData.TaskForceList.Add(taskForce);
                        }
                        missionData.UnitList.Add(unit);
                    }
                    log.InfoFormat("missionData units = {0}", missionData.UnitList.Count);
                }
            }
            log.Debug("<< ReadUniFile");
        }

        private void SortFiles(string teFile)
        {
            log.Debug(">> SortFiles");
            checked
            {
                if (File.Exists(teFile))
                {
                    string l16filename = Path.GetDirectoryName(teFile) + "\\" + Path.GetFileNameWithoutExtension(teFile) + ".l16.txtpb";

                    byte[] array = new byte[(int)(new FileInfo(teFile).Length - 1L) + 1];
                    using (FileStream fileStream = new FileStream(teFile, FileMode.Open))
                    {
                        fileStream.Seek(0L, SeekOrigin.Begin);
                        fileStream.Read(array, 0, array.Length);
                    }
                    int num = BitConverter.ToInt32(array, 0);
                    int num2 = BitConverter.ToInt32(array, num);
                    num += 4;
                    int num3 = num2 - 1;
                    for (int i = 0; i <= num3; i++)
                    {
                        byte b = array[num];
                        num++;
                        string @string = Encoding.Default.GetString(array, num, (int)b);
                        num += (int)b;
                        uint num4 = BitConverter.ToUInt32(array, num);
                        num += 4;
                        uint num5 = BitConverter.ToUInt32(array, num);
                        num += 4;
                        FileInfo fileInfo = new FileInfo(@string);
                        if (Operators.CompareString(fileInfo.Extension.ToUpperInvariant(), ".CMP", false) == 0)
                        {
                            log.InfoFormat("Processing CMP file {0}", fileInfo.FullName);
                            int num6 = (int)num4;
                            int num7 = BitConverter.ToInt32(array, num6);
                            num6 += 4;
                            int num8 = BitConverter.ToInt32(array, num6);
                            num6 += 4;
                            byte[] array2 = new byte[num7 + 1];
                            Array.Copy(array, num6, array2, 0, num7);
                            byte[] array3 = Codec.Decompress(array2, num8);
                            try
                            {
                                this.ReadCampaign(array3);
                            }
                            catch (Exception ex)
                            {
                                log.Error("Could not read Campaign data. Your mission might be corrupted");
                                MessageBox.Show("Could not read Campaign data\r\nYour mission might be corrupted", "Caution", MessageBoxButtons.OK);
                                //this.ClearTables();
                                return;
                            }
                        }
                        if (Operators.CompareString(fileInfo.Extension.ToUpperInvariant(), ".OBD", false) == 0)
                        {
                            log.InfoFormat("Processing OBD file {0}", fileInfo.FullName);
                            int num9 = (int)num4;
                            int num10 = BitConverter.ToInt32(array, num9);
                            num9 += 4;
                            int num11 = (int)BitConverter.ToInt16(array, num9);
                            num9 += 2;
                            BitConverter.ToInt32(array, num9);
                            num9 += 4;
                            int embNr = missionData.GetEmbNr(".obd");
                            int num12 = (int)missionData.EmbeddedFileInfoTabel[embNr].FileSizeBytes;
                            //Array.Resize<ObjectiveDeltas>(ref missionData.ObjectiveDeltaTable, num11);
                            byte[] array4 = new byte[num10 + 10 + 1];
                            unchecked
                            {
                                Array.Copy(array, (long)((ulong)num4), array4, 0L, (long)num12);
                                byte[] array5 = new byte[checked(num12 + 1)];
                                Array.Copy(array, (long)((ulong)num4), array5, 0L, (long)array5.Length);
                                try
                                {
                                    missionData.ReadObdFile(array4, this.intFileVer, num11);
                                }
                                catch (Exception ex2)
                                {
                                    log.Error("Could not read Objectsdeltas data. Your mission might be corrupted");
                                    MessageBox.Show("Could not read Objectsdeltas data\r\nYour mission might be corrupted", "Caution", MessageBoxButtons.OK);
                                    this.ClearTables();
                                    return;
                                }
                            }
                        }
                        if (Operators.CompareString(fileInfo.Extension.ToUpperInvariant(), ".EVT", false) == 0)
                        {
                            log.InfoFormat("Processing EVT file {0}", fileInfo.FullName);
                            int num13 = (int)num4;
                            BitConverter.ToInt16(array, num13 + 2);
                        }
                        if (Operators.CompareString(fileInfo.Extension.ToUpperInvariant(), ".TEA", false) == 0)
                        {
                            log.InfoFormat("Processing TEA file {0}", fileInfo.FullName);
                            byte[] array6 = new byte[(int)num5 + 1];
                            unchecked
                            {
                                Array.Copy(array, (long)((ulong)num4), array6, 0L, (long)((ulong)num5));
                                try
                                {
                                    missionData.ReadTea(array6, this.intFileVer);
                                }
                                catch (Exception ex3)
                                {
                                    log.Error("Could not read Team data. Your mission might be corrupted");
                                    MessageBox.Show("Could not read Team data\r\nYour mission might be corrupted", "Caution", MessageBoxButtons.OK);
                                    this.ClearTables();
                                    return;
                                }
                            }
                        }
                        if (Operators.CompareString(fileInfo.Extension.ToUpperInvariant(), ".UNI", false) == 0)
                        {
                            log.InfoFormat("Processing UNI file {0}", fileInfo.FullName);
                            int num14 = (int)num4;
                            int num15 = BitConverter.ToInt32(array, num14);
                            num14 += 4;
                            BitConverter.ToInt16(array, num14);
                            num14 += 2;
                            BitConverter.ToInt32(array, num14);
                            num14 += 4;
                            byte[] array7 = new byte[num15 + 10 + 1];
                            int num16;
                            bool flag;
                            unchecked
                            {
                                Array.Copy(array, (long)((ulong)num4), array7, 0L, (long)(checked(num15 + 10)));
                                num16 = this.intFileVer;
                                try
                                {
                                    this.ReadUniFile(this.missionData.classTableEntries, this.intFileVer, array7, l16filename);
                                    flag = true;
                                }
                                catch (Exception ex4)
                                {
                                    //this.ClearTables();
                                    //num16 = this.maxFileVer;
                                    flag = false;
                                }
                            }
                            if (!flag)
                            {
                                for (; ; )
                                {
                                    try
                                    {
                                        if (num16 <= 73)
                                        {
                                            int k = 2;
                                            this.ReadUniFile(this.missionData.classTableEntries, num16, array7, l16filename);
                                        }
                                        else this.ReadUniFile(this.missionData.classTableEntries, num16, array7, l16filename);

                                    }
                                    catch (Exception ex5)
                                    {
                                        this.ClearTables();
                                        num16--;
                                        if (num16 == 99)
                                        {
                                            num16 = 73;
                                        }
                                        if (num16 != 72)
                                        {
                                            continue;
                                        }
                                        log.Error("Could not read Unit data. Your mission might be corrupted");
                                        MessageBox.Show("Could not read Unit data\r\nYour mission might be corrupted", "Caution", MessageBoxButtons.OK);
                                    }
                                    break;
                                }
                            }
                        }
                        if (Operators.CompareString(fileInfo.Extension.ToUpperInvariant(), ".PLT", false) == 0)
                        {
                            log.InfoFormat("Processing PLT file {0}", fileInfo.FullName);
                            byte[] array8 = new byte[(int)num5 + 1];
                            unchecked
                            {
                                Array.Copy(array, (long)((ulong)num4), array8, 0L, (long)((ulong)num5));
                                try
                                {
                                    this.ReadPlt(array8);
                                }
                                catch (Exception ex6)
                                {
                                    log.Error("Could not read Pilot data. Your mission might be corrupted");
                                    MessageBox.Show("Could not read Pilot data\r\nYour mission might be corrupted", "Caution", MessageBoxButtons.OK);
                                    this.ClearTables();
                                    return;
                                }
                            }
                        }
                        /*if (Operators.CompareString(fileInfo.Extension.ToUpperInvariant(), ".WTH", false) == 0)
                        {
                            byte[] array9 = new byte[(int)num5 + 1];
                            unchecked
                            {
                                Array.Copy(array, (long)((ulong)num4), array9, 0L, (long)((ulong)num5));
                                try
                                {
                                    this.ReadWeather(array9);
                                    this.cntDataCard.blnWth = true;
                                }
                                catch (Exception ex7)
                                {
                                }
                            }
                        }
                    }*/
                        /*if (this.intFileVer >= 102 && this.CampaignTable[0].SquadInfo.Length > 0)
                        {
                            int num17 = this.SquadronTable.Length - 1;
                            for (int j = 0; j <= num17; j++)
                            {
                                int squadNrinInfoTable = this.GetSquadNrinInfoTable(this.SquadronTable[j].id);
                                if ((squadNrinInfoTable >= 0) & (squadNrinInfoTable < this.CampaignTable[0].SquadInfo.Length))
                                {
                                    if (this.CampaignTable[0].SquadInfo[squadNrinInfoTable].campId != this.SquadronTable[j].campId)
                                    {
                                        this.CampaignTable[0].SquadInfo[squadNrinInfoTable].campId = this.SquadronTable[j].campId;
                                    }
                                    if (this.CampaignTable[0].SquadInfo[squadNrinInfoTable].flags != this.SquadronTable[j].unit_flags)
                                    {
                                        this.CampaignTable[0].SquadInfo[squadNrinInfoTable].flags = this.SquadronTable[j].unit_flags;
                                    }
                                    this.SquadronTable[j].squadronName = new string(this.CampaignTable[0].SquadInfo[squadNrinInfoTable].squadronName);
                                    this.SquadronTable[j].texSet = unchecked((long)this.CampaignTable[0].SquadInfo[squadNrinInfoTable].texSet);
                                }
                            }
                        }*/
                        this.Refresh();
                        string text = Path.GetExtension(teFile);
                        if (Operators.CompareString(text, ".trn", false) == 0)
                        {
                            text = ".tac";
                        }
                        string text2 = bmsConfig.CampaignDir + missionData.CampaignTable[0].Scenario + text;
                        this.GetObj(text2);
                        //this.Bullseye();
                        if ((this.intObjFileVer > 0) & (this.intObjFileVer < 106))
                        {
                            missionData.ReadObjString((cbTheater.SelectedItem as TheaterListItem).Name);
                        }
                        else
                        {
                            Array.Resize<string>(ref this.missionData.ObjectsText, 0);
                            Array.Resize<int>(ref this.missionData.ObjectsIndex, 0);
                        }

                    }

                    missionData.ReadStationsIls();
                    missionData.ReadRadio(bmsConfig.CampaignDir);

                    this.Cursor = Cursors.Arrow;
                }
            }
            log.Debug("<< SortFiles");
        }

        private void ReadFile(string teFile)
        {
            log.Debug(">> ReadFile " + teFile);
            if (!File.Exists(teFile))
            {
                log.Error("File not found: " + teFile);
                MessageBox.Show("File not found: " + teFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            byte[] array = new byte[checked((int)(new FileInfo(teFile).Length - 1L) + 1)];
            using (FileStream fileStream = new FileStream(teFile, FileMode.Open))
            {
                fileStream.Seek(0L, SeekOrigin.Begin);
                fileStream.Read(array, 0, array.Length);
                fileStream.Close();
            }
            ulong directorOffset = (ulong)BitConverter.ToUInt32(array, 0);
            checked
            {
                missionData.NumEmbeddedFiles = (int)BitConverter.ToUInt32(array, (int)directorOffset);
                missionData.NumEmbeddedFiles = Math.Min(missionData.NumEmbeddedFiles, 12);
                int num = Convert.ToInt32(decimal.Add(new decimal(directorOffset), 4m));
                int num2 = missionData.NumEmbeddedFiles;
                for (int i = 1; i <= num2; i++)
                {
                    int @byte = (int)Buffer.GetByte(array, num);
                    num++;
                    missionData.EmbeddedFileInfoTabel[i].fileName = Encoding.Default.GetString(array, num, @byte);
                    num += @byte;
                    missionData.EmbeddedFileInfoTabel[i].FileOffset = BitConverter.ToUInt32(array, num);
                    num += 4;
                    missionData.EmbeddedFileInfoTabel[i].FileSizeBytes = BitConverter.ToUInt32(array, num);
                    num += 4;
                }
                int num3 = missionData.NumEmbeddedFiles;
                for (int j = 1; j <= num3; j++)
                {
                    missionData.EmbeddedFileInfoTabel[j].Ext = Path.GetExtension(missionData.EmbeddedFileInfoTabel[j].fileName);
                }
            }
            log.Debug("<< ReadFile " + teFile);
        }

        private int ReadFileVersion(string fName)
        {
            log.Debug(">> ReadFileVersion " + fName);
            int num = -1;
            checked
            {
                int num2;
                if (!File.Exists(fName))
                {
                    log.Error("File not found: " + fName);
                    MessageBox.Show("File not found: " + fName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    num2 = num;
                }
                else
                {
                    byte[] array = new byte[(int)(new FileInfo(fName).Length - 1L) + 1];
                    using (FileStream fileStream = new FileStream(fName, FileMode.Open))
                    {
                        fileStream.Seek(0L, SeekOrigin.Begin);
                        fileStream.Read(array, 0, array.Length);
                        fileStream.Close();
                    }
                    BmsStructs.EmbeddedFileInfo[] array2 = new BmsStructs.EmbeddedFileInfo[21];
                    for (int i = 0; i < 21; i++)
                        array2[i] = new BmsStructs.EmbeddedFileInfo();
                    int num3 = BitConverter.ToInt32(array, 0);
                    int num4 = BitConverter.ToInt32(array, num3);
                    int num5 = num3 + 4;
                    Array.Resize<BmsStructs.EmbeddedFileInfo>(ref array2, num4);
                    int num6 = num4 - 1;
                    for (int i = 0; i <= num6; i++)
                    {
                        if (num5 < array.Length)
                        {
                            int @byte = (int)Buffer.GetByte(array, num5);
                            num5++;
                            array2[i].fileName = Encoding.Default.GetString(array, num5, @byte);
                            array2[i].Ext = Path.GetExtension(array2[i].fileName);
                            num5 += @byte;
                            array2[i].FileOffset = BitConverter.ToUInt32(array, num5);
                            num5 += 4;
                            array2[i].FileSizeBytes = BitConverter.ToUInt32(array, num5);
                            num5 += 4;
                        }
                    }
                    int num7 = num4 - 1;
                    int num8 = 0;
                    for (int j = 0; j <= num7; j++)
                    {
                        if (Operators.CompareString(array2[j].Ext, ".ver", false) == 0)
                        {
                            num8 = j;
                        }
                    }
                    if (num8 == 0)
                    {
                        log.Error("No .Ver file found");
                        MessageBox.Show("No .Ver file found");
                        num2 = num;
                    }
                    else
                    {
                        uint fileOffset = array2[num8].FileOffset;
                        uint fileSizeBytes = array2[num8].FileSizeBytes;
                        string text = Encoding.Default.GetString(array, (int)fileOffset, (int)(unchecked((ulong)fileSizeBytes) + 5UL));
                        text = Strings.Mid(text, 1, 3);
                        if (Versioned.IsNumeric(text))
                        {
                            num = Conversions.ToInteger(text);
                        }
                        else
                        {
                            text = Strings.Mid(text, 1, 2);
                            if (Versioned.IsNumeric(text))
                            {
                                num = Conversions.ToInteger(text);
                            }
                        }
                        num2 = num;
                    }
                }
                return num2;
            }
            log.Debug("<< ReadFileVersion " + fName);
        }

        public void GetObj(string fName)
        {
            log.Debug(">> GetObj " + fName);
            if (!File.Exists(fName))
            {
                log.Error("Could not find: " + fName);
                MessageBox.Show("Could not find: " + fName);
                return;
            }
            this.intObjFileVer = this.ReadFileVersion(fName);
            if (this.intObjFileVer == -1)
            {
                this.intObjFileVer = 73;
            }
            checked
            {
                byte[] array = new byte[(int)(new FileInfo(fName).Length - 1L) + 1];
                using (FileStream fileStream = new FileStream(fName, FileMode.Open))
                {
                    fileStream.Seek(0L, SeekOrigin.Begin);
                    fileStream.Read(array, 0, array.Length);
                    fileStream.Close();
                }
                int num = BitConverter.ToInt32(array, 0);
                int num2 = BitConverter.ToInt32(array, num);
                num += 4;
                int num3 = num2 - 1;
                for (int i = 0; i <= num3; i++)
                {
                    byte b = array[num];
                    num++;
                    string @string = Encoding.Default.GetString(array, num, (int)b);
                    num += (int)b;
                    uint num4 = BitConverter.ToUInt32(array, num);
                    num += 4;
                    BitConverter.ToUInt32(array, num);
                    num += 4;
                    if (Operators.CompareString(new FileInfo(@string).Extension.ToUpperInvariant(), ".OBJ", false) == 0)
                    {
                        int num5 = (int)num4;
                        int num6 = (int)BitConverter.ToInt16(array, num5);
                        num5 += 2;
                        BitConverter.ToInt32(array, num5);
                        num5 += 4;
                        int num7 = BitConverter.ToInt32(array, num5);
                        num5 += 4;
                        //Array.Resize<Objective>(ref this.missionData.ObjectiveTable, num6);
                        byte[] array2 = new byte[num7 + 10 + 1];
                        int num8;
                        unchecked
                        {
                            Array.Copy(array, (long)((ulong)num4), array2, 0L, (long)(checked(num7 + 10)));
                            num8 = 0;
                            if (this.intObjFileVer == 0)
                            {
                                this.intObjFileVer = 73;
                            }
                        }
                        for (; ; )
                        {
                            try
                            {
                                this.ReadObjFile(array2, this.intObjFileVer, num8);
                                //this.blnTheaterInstalled = true;
                                if (this.intObjFileVer >= 107)
                                {
                                    try
                                    {
                                        int num9 = this.missionData.ObjectiveList.Count - 1;
                                        for (int j = 0; j <= num9; j++)
                                        {
                                            int num10 = (int)(this.missionData.ObjectiveList[j].entityType - 100);
                                            if ((num10 >= 0) & (num10 < this.missionData.classTableEntries.Length))
                                            {
                                                int dataType = (int)this.missionData.classTableEntries[num10].dataType;
                                                if ((dataType >= 0) & (dataType < this.missionData.ObjectDataEntries.Count))
                                                {
                                                    int features = (int)this.missionData.ObjectDataEntries[dataType].Features;
                                                    if (features != (int)this.missionData.ObjectiveList[j].numStatuses)
                                                    {
                                                        this.missionData.ObjectiveList[j].numStatuses = (byte)features;
                                                        Array.Resize<byte>(ref this.missionData.ObjectiveList[j].fstatus, features);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }
                            }
                            catch (Exception ex2)
                            {
                                num8++;
                                if (num8 < 5)
                                {
                                    continue;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            log.Debug("<< GetObj " + fName);
        }

        private void ReadObjFile(byte[] contents, int version, int subVer)
        {
            log.Debug(">> ReadObjFile");
            Objective[] objectives = new ObjFile(contents, version, ref subVer).objectives;
            if (objectives != null)
            {
                
                foreach (Objective objective in objectives)
                {
                    uint lastRepair = objective.lastRepair;
                    uint obj_flags = objective.obj_flags;
                    byte supply = objective.supply;
                    byte fuel = objective.fuel;
                    byte losses = objective.losses;
                    byte[] fstatus = objective.fstatus;
                    byte priority = objective.priority;
                    short nameId = objective.nameId;
                    BmsStructs.BmsId parent = objective.parent;
                    byte first_owner = objective.first_owner;
                    byte links = objective.links;
                    BmsStructs.CampObjectiveLinkDataType[] link_data = objective.link_data;
                    float[] detect_ratio = objective.detect_ratio;
                    missionData.ObjectiveList.Add(objective);
                }
                log.InfoFormat("Loaded {0} objectives", missionData.ObjectiveList.Count);
            }
            log.Debug("<< ReadObjFile");
        }

        private bool ReadStringFromTxt(ref string fName)
        {
            log.Debug(">> ReadStringFromTxt " + fName);
            bool flag = false;
            string[] array = new string[0];
            char c = '\t';
            char c2 = ' ';
            checked
            {
                bool flag2;
                if (!File.Exists(fName))
                {
                    flag2 = flag;
                }
                else
                {
                    try
                    {
                        FileStream fileStream = new FileStream(fName, FileMode.Open);
                        StreamReader streamReader = new StreamReader(fileStream);
                        while (!streamReader.EndOfStream)
                        {
                            string text = streamReader.ReadLine();
                            Array.Resize<string>(ref array, array.Length + 1);
                            array[array.Length - 1] = text;
                        }
                        fileStream.Flush();
                        fileStream.Close();
                        fileStream.Dispose();
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    int num = array.Length - 1;
                    int num3 = 0;
                    int num4 = 0;
                    for (int i = 0; i <= num; i++)
                    {
                        string text = array[i];
                        text = text.Replace(c, c2);
                        text = Strings.Trim(text);
                        text = text.Replace("\t", " ");
                        int num2 = BmsStringUtils.FirstSpace(text);
                        if ((num2 > 1) & (num2 < 6))
                        {
                            string text2 = Strings.Mid(text, 1, num2 - 1);
                            if (Versioned.IsNumeric(text2))
                            {
                                num3 = Conversions.ToInteger(text2);
                            }
                        }
                        if (num3 > num4)
                        {
                            num4 = num3;
                        }
                    }
                    Array.Resize<string>(ref this.missionData.StringText, num4 + 1);
                    int num5 = this.missionData.StringText.Length - 1;
                    for (int j = 0; j <= num5; j++)
                    {
                        this.missionData.StringText[j] = "";
                    }
                    int num6 = array.Length - 1;
                    for (int k = 0; k <= num6; k++)
                    {
                        string text = array[k];
                        text = text.Replace(c, c2);
                        text = Strings.Trim(text);
                        text = text.Replace("\t", " ");
                        int num2 = BmsStringUtils.FirstSpace(text);
                        if ((num2 > 1) & (num2 < 6))
                        {
                            string text2 = Strings.Mid(text, 1, num2 - 1);
                            if (Versioned.IsNumeric(text2))
                            {
                                num3 = Conversions.ToInteger(text2);
                            }
                            text2 = Strings.Mid(text, num2 + 1, text.Length);
                            text2 = Strings.Trim(text2);
                            this.missionData.StringText[num3] = text2;
                        }
                    }
                    flag = true;
                    flag2 = flag;
                }
                return flag2;
            }
            log.Debug("<< ReadStringFromTxt " + fName);
        }

        private void ClearTables()
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";

            BMSKneeboarderDB.Instance.CreateTables();
            if (Directory.Exists(bmsConfig.BmsDataDir))
                dlgOpen.InitialDirectory = bmsConfig.BmsDataDir;

            kneeboardLayout = BMSKneeboarderDB.Instance.LoadKBLayout();
            /*if (File.Exists(kbLayoutFile))
                kneeboardLayout = JsonSerializer.Deserialize<KneeboardLayout>(File.ReadAllText(kbLayoutFile));
            else
                kneeboardLayout = new KneeboardLayout();*/
            splitContainer1.Visible = false;
            toolStripButton1.Enabled = false;
            btnSaveKB.Enabled = false;
            btnLink16.Enabled = false;
            btnReloadMission.Enabled = false;
            btnDTCDropdown.Enabled = false;
            cbLeftType.Items.Clear();
            cbRightType.Items.Clear();
            foreach (PageType pt in Enum.GetValues<PageType>())
            {
                cbLeftType.Items.Add(pt.ToString());
                cbRightType.Items.Add(pt.ToString());
            }
            mnuPasteMap.Enabled = false;
            mnuPasteMapSettings.Enabled = false;

            LoadTheaterList();
        }

        private void LoadTheaterList()
        {
            log.Debug(">> LoadTheaterList");
            cbTheater.Items.Clear();
            string theaterListFilename = bmsConfig.BmsDataDir + "TerrData\\TheaterDefinition\\theater.lst";
            log.InfoFormat("Theater list file: {0}", theaterListFilename);

            if (!string.IsNullOrWhiteSpace(bmsConfig.BmsDataDir) && File.Exists(theaterListFilename))
            {
                string[] theaterLines = File.ReadAllLines(theaterListFilename);
                foreach (string line in theaterLines)
                {
                    string[] parts = line.Split("\\");
                    StringBuilder theaterDir = new StringBuilder("");
                    foreach (string p in parts)
                    {
                        if (p.ToLower() == "terrdata" || p.ToLower() == "theaterdefinition")
                            break;
                        theaterDir.Append(p).Append(Path.DirectorySeparatorChar);
                    }
                    string theaterName = Path.GetFileNameWithoutExtension(line);
                    if (theaterName == "Korea KTO")
                        theaterName = "Korea";
                    log.InfoFormat("Found theater {0} in {1}", theaterName, theaterDir.ToString());
                    TheaterListItem item = new TheaterListItem(line, theaterName, theaterDir.ToString());
                    cbTheater.Items.Add(item);
                }
                if (cbTheater.Items.Count > 0)
                    cbTheater.SelectedIndex = 0;

                TheaterSelected();
            }
            else
            {
                //   ShowSettingsForm();
            }
            log.Debug("<< LoadTheaterList");
        }

        private void LoadMission(string filename, bool keepCurrFlight)
        {
            log.DebugFormat(">> LoadMission {0}", filename);
            BMSKneeboarderDB.Cleanup();

            string currFlightCallsign = null;
            BmsStructs.BmsId currFlightId = new BmsStructs.BmsId();
            BmsStructs.BmsId currPackageId = new BmsStructs.BmsId();
            short currPackageNo = 0;

            if (missionData != null && keepCurrFlight)
            {
                currFlightCallsign = missionData.CurrFlightCallsign;
                currFlightId = missionData.CurrFlightId;
                currPackageId = missionData.CurrPackageId;
                currPackageNo = missionData.CurrPackageNo;
            }

            bmsConfig.ReadBmsCfg();
            GC.Collect();

            if (!bmsConfig.IsValid)
                return;

            if (missionData != null)
            {
                missionData.Reset();
                missionData.ResetDTC();
            } else
                missionData = new MissionData(bmsConfig);

            bmsConfig.Log();

            LoadTheaterList();

            //Array.Resize<BmsStructs.SimACDefType>(ref this.SimACDefEntries, 0);
            Array.Resize<BmsStructs.EntityClassType>(ref this.missionData.classTableEntries, 0);
            missionData.UnitList.Clear();
            //Array.Resize<F4Structs.DirtyDataClassType>(ref this.DirtyDataEntries, 0);
            //Array.Resize<F4Structs.FeatureEntry>(ref this.FeatureEntryDataTable, 0);
            //Array.Resize<F4Structs.FeatureClassDataType>(ref this.FeatureDataEntries, 0);
            //Array.Resize<F4Structs.IRDataType>(ref this.IRSTDataTable, 0);
            //Array.Resize<F4Structs.ObjClassDataType>(ref this.ObjectDataEntries, 0);
            //Array.Resize<F4Structs.RadarDataType>(ref this.RadarDataTable, 0);
            //Array.Resize<F4Structs.PtHeaderDataType>(ref this.PtHeaderDataEntries, 0);
            //Array.Resize<F4Structs.RocketClassDataType>(ref this.RocketDataTable, 0);
            //Array.Resize<F4Structs.RwrDataType>(ref this.RwrDataTable, 0);
            //Array.Resize<F4Structs.SimWeaponDataType>(ref this.SimWeaponDataEntries, 0);
            //Array.Resize<F4Structs.SquadronStoresDataType>(ref this.SquadronStoresDataTable, 0);
            //Array.Resize<F4Structs.UnitClassDataType>(ref this.UnitDataEntries, 0);
            //Array.Resize<F4Structs.VehicleClassDataType>(ref this.VehicleDataEntries, 0);
            //Array.Resize<F4Structs.VisualDataType>(ref this.VisualDataTable, 0);
            //Array.Resize<F4Structs.WeaponClassDataType>(ref this.WeaponDataEntries, 0);
            //Array.Resize<F4Structs.WeaponListDataType>(ref this.WeaponListDataTable, 0);

            missionFileName = filename;

            log.InfoFormat("missionFileName = {0}", missionFileName);

            for (int i = 0; i < cbTheater.Items.Count; i++)
            {
                if (string.IsNullOrEmpty((cbTheater.Items[i] as TheaterListItem).TheaterDir))
                    cbTheater.SelectedIndex = i;
            }
            for (int i = 0; i < cbTheater.Items.Count; i++)
            {
                TheaterListItem item = cbTheater.Items[i] as TheaterListItem;
                if (!string.IsNullOrEmpty(item.TheaterDir) && filename.ToLower().Contains(Path.DirectorySeparatorChar + item.TheaterDir.ToLower()))
                    cbTheater.SelectedIndex = i;
            }

            TheaterSelected();


            missionData.MissionDTCFileName = Path.GetDirectoryName(filename) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(filename) + ".ini";
            log.InfoFormat("MissionDTCFileName = {0}", missionData.MissionDTCFileName);

            missionData.LoadMissionDTC();

            LoadDatabase();

            string text8 = bmsConfig.CampaignDir + "Strings.txt";
            if (!this.ReadStringFromTxt(ref text8))
            {
                log.Error("Failed to load: " + text8 + ". Loading Strings.IDX/WCH");
                MessageBox.Show("Failed to load: " + text8 + "\r\nLoading Strings.IDX/WCH");
                //this.ReadString();
            }

            ReadFile(filename);

            GetTheater(filename);
            SortFiles(filename);

            //bmsConfig.TerrainDir = bmsConfig.TerrainDir;

            missionData.LoadTerrain();
            missionData.InitNewTerrain();

            toolStripButton1.Enabled = true;

            missionData.ReadImageIds();
            missionData.LoadIcons();

            if (currFlightCallsign != null && keepCurrFlight)
            {
                missionData.CurrFlightCallsign = currFlightCallsign;
                missionData.CurrFlightId = currFlightId;
                missionData.CurrPackageId = currPackageId;
                missionData.CurrPackageNo = currPackageNo;
            } else
                SelectFlight();

            btnReloadMission.Enabled = true;
            log.DebugFormat("<< LoadMission {0}", filename);
        }
        private void OpenMission()
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                LoadMission(dlgOpen.FileName, false);
            }
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            OpenMission();
        }

        private List<KneeboardPage> leftPages = new List<KneeboardPage>();
        private List<KneeboardPage> rightPages = new List<KneeboardPage>();
        private KneeboardLayout kneeboardLayout = null;

        private void SaveKneeboardLayout()
        {
            //string json = JsonSerializer.Serialize(kneeboardLayout);
            //File.WriteAllText(kbLayoutFile, json);

            BMSKneeboarderDB.Instance.SaveKBLayout(kneeboardLayout);
        }

        private void UpdateContextMenuLeft(int i)
        {
            switch (leftPages[i].PageType)
            {
                case PageType.Datacard: tabControlLeft.TabPages[i].ContextMenuStrip = ctxMnuDatacard; break;
                case PageType.Map: tabControlLeft.TabPages[i].ContextMenuStrip = ctxMnuMap; break;
                case PageType.Briefing: tabControlLeft.TabPages[i].ContextMenuStrip = ctxMnuBriefing; break;
                default: tabControlLeft.TabPages[i].ContextMenuStrip = null; break;
            }
        }

        private void UpdateContextMenuRight(int i)
        {
            switch (rightPages[i].PageType)
            {
                case PageType.Datacard: tabControlRight.TabPages[i].ContextMenuStrip = ctxMnuDatacard; break;
                case PageType.Map: tabControlRight.TabPages[i].ContextMenuStrip = ctxMnuMap; break;
                case PageType.Briefing: tabControlRight.TabPages[i].ContextMenuStrip = ctxMnuBriefing; break;
                default: tabControlRight.TabPages[i].ContextMenuStrip = null; break;
            }
        }

        private void SetRadiosForCurrentFlight(Flight currentFlight) {
            missionData.LoadRadiosFromDTC();

            if (currentFlight == null) {
                return;
            }

            (Objective? abDep, Objective? abArr, Objective? abAlt) = missionData.FindFlightAirbases(currentFlight);


            if (abDep != null)
            {
                StationsILSData siData = missionData.arrStatIls.FirstOrDefault(x => x.CampId == abDep.campId);

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
                       
                    //load to DTC UHF
                    missionData.PilotCommsUHF[9].Freq = missionData.FormatFreq(siData.ApproachUHF);
                    missionData.PilotCommsUHF[10].Freq = missionData.FormatFreq(siData.UHF);
                    missionData.PilotCommsUHF[11].Freq = missionData.FormatFreq(siData.GroundUHF);
                    //VHF channels
                    missionData.PilotCommsVHF[10].Freq = missionData.FormatFreq(siData.VHF);
                }
            }

            //Tanker UHF
            Package p = missionData.PackageList.FirstOrDefault(x => x.id == currentFlight.package);
            if (p != null)
            {
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
                if (tanker != null)
                {
                    //add current package tanker
                    missionData.PilotCommsUHF[12].Freq = missionData.GetTacticalFreq(tanker);
                }

                //package flights VHF
                for (int i = 0; i < p.element.Length; ++i)
                {
                    string CS = missionData.GetFlightCallsign(missionData.FlightList.FirstOrDefault(x => x.id == p.element[i]));

                    if (CS != null)
                    {
                        (string VHF, string UHF_BU) = missionData.GetFlightFreq(CS);
                        missionData.PilotCommsUHF[14 + i].Freq = UHF_BU;
                        missionData.PilotCommsVHF[14 + i].Freq = VHF;
                        missionData.PilotCommsVHF[14 + i].Comment = "Flight " + (i + 1).ToString();
                        missionData.PilotCommsUHF[14 + i].Comment = "Intra Flight " + (i + 1).ToString();
                    }
                }
            }
        }

        private void SelectFlight()
        {
            log.Debug(">> SelectFlight");
            SelectFlightForm selectFlightForm = new SelectFlightForm(missionData);

            if (selectFlightForm.ShowDialog() == DialogResult.OK)
            {
                missionData.CurrPackageId = selectFlightForm.SelectedFlight.PackageId;
                missionData.CurrPackageNo = selectFlightForm.SelectedFlight.PackageNo;
                missionData.CurrFlightId = selectFlightForm.SelectedFlight.FlightId;
                missionData.CurrFlightCallsign = selectFlightForm.SelectedFlight.FlightCallsign;

                SetRadiosForCurrentFlight(missionData.FlightList.FirstOrDefault(x => x.id == missionData.CurrFlightId));

                log.InfoFormat("Selected package id {0}/{1}", missionData.CurrPackageId.creator, missionData.CurrPackageId.num);
                log.InfoFormat("Selected package No {0}", missionData.CurrPackageNo);
                log.InfoFormat("Selected flight id {0}/{1}", missionData.CurrFlightId.creator, missionData.CurrFlightId.num);
                log.InfoFormat("Selected flight callsign {0}", missionData.CurrFlightCallsign);

                foreach (KneeboardPage p in leftPages)
                    p.Dispose();
                foreach (KneeboardPage p in rightPages)
                    p.Dispose();

                leftPages.Clear();
                rightPages.Clear();

                for (int i = 0; i < 16; i++)
                {
                    leftPages.Add(new KneeboardPage(i, (kneeboardLayout.LeftPages.Count > i) ? kneeboardLayout.LeftPages[i].PageType : PageType.Blank, missionData));
                    if (leftPages[i].PageType == PageType.Image && kneeboardLayout.LeftPages.Count > i && kneeboardLayout.LeftPages[i].Image != null)
                    {
                        leftPages[i].SetImage((Bitmap)kneeboardLayout.LeftPages[i].Image.Clone());
                    }
                    if (leftPages[i].PageType == PageType.Map && kneeboardLayout.LeftPages.Count > i && kneeboardLayout.LeftPages[i].MapSettings != null)
                        leftPages[i].MapSettings = kneeboardLayout.LeftPages[i].MapSettings;

                    leftPages[i].Saturation = kneeboardLayout.LeftPages[i].Saturation;
                    UpdateContextMenuLeft(i);


                    rightPages.Add(new KneeboardPage(i, (kneeboardLayout.RightPages.Count > i) ? kneeboardLayout.RightPages[i].PageType : PageType.Blank, missionData));
                    if (rightPages[i].PageType == PageType.Image && kneeboardLayout.RightPages.Count > i && kneeboardLayout.RightPages[i].Image != null)
                    {
                        rightPages[i].SetImage((Bitmap)kneeboardLayout.RightPages[i].Image.Clone());
                    }
                    if (rightPages[i].PageType == PageType.Map && kneeboardLayout.RightPages.Count > i && kneeboardLayout.RightPages[i].MapSettings != null)
                        rightPages[i].MapSettings = kneeboardLayout.RightPages[i].MapSettings;
                    rightPages[i].Saturation = kneeboardLayout.RightPages[i].Saturation;
                    UpdateContextMenuRight(i);

                    leftPages[i].Update();
                    rightPages[i].Update();
                }

                btnSaveKB.Enabled = true;
                btnLink16.Enabled = true;
                btnDTCDropdown.Enabled = true;
                splitContainer1.Visible = true;

                tabControlLeft.TabPages[tabControlLeft.TabIndex].Invalidate();
                tabControlRight.TabPages[tabControlRight.TabIndex].Invalidate();

                cbLeftType.SelectedIndex = cbLeftType.Items.IndexOf(leftPages[tabControlLeft.SelectedIndex].PageType.ToString());
                cbRightType.SelectedIndex = cbRightType.Items.IndexOf(rightPages[tabControlRight.SelectedIndex].PageType.ToString());
                trbRightSat.Value = rightPages[tabControlRight.SelectedIndex].Saturation;
                trbLeftSat.Value = leftPages[tabControlLeft.SelectedIndex].Saturation;

                BMSKneeboarderDB.Instance.InsertTheaterIfNotExists(missionData.CampaignTable[0].TheaterName);
            }
            selectFlightForm.Dispose();
            log.Debug("<< SelectFlight");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SelectFlight();
        }

        private void DrawKBPage(TabPage control, Graphics g, KneeboardPage kbPage)
        {
            if (kbPage == null)
                return;
            Bitmap b = kbPage.Bitmap;


            if (b != null)
            {
                double ratio = (double)control.Width / b.Width;
                if ((double)control.Height / b.Height < ratio)
                    ratio = (double)control.Height / b.Height;

                g.DrawImage(b,
                    new Rectangle(
                        Convert.ToInt32(Math.Floor(control.Width - b.Width * ratio) / 2),
                        Convert.ToInt32(Math.Floor(control.Height - b.Height * ratio) / 2),
                        Convert.ToInt32(Math.Floor(b.Width * ratio)),
                        Convert.ToInt32(Math.Floor(b.Height * ratio))
                    ),
                    0, 0, b.Width, b.Height,
                    GraphicsUnit.Pixel,
                    BmsUtils.GetImageAttributes(kbPage.Saturation)
                );
            }
        }

        List<string> GetKneeboardFilenames(int pageNo)
        {
            switch (pageNo)
            {
                case 0: return new List<string>(["7982.dds", "1403.dds"]);
                case 1: return new List<string>(["7983.dds", "1404.dds"]);
                case 2: return new List<string>(["7984.dds", "1405.dds"]);
                case 3: return new List<string>(["7985.dds", "1406.dds"]);
                case 4: return new List<string>(["7986.dds", "1407.dds"]);
                case 5: return new List<string>(["7987.dds", "1408.dds"]);
                case 6: return new List<string>(["7988.dds", "1409.dds"]);
                case 7: return new List<string>(["7989.dds", "1410.dds"]);
                case 8: return new List<string>(["7990.dds", "1411.dds"]);
                case 9: return new List<string>(["7991.dds", "1412.dds"]);
                case 10: return new List<string>(["7992.dds", "1413.dds"]);
                case 11: return new List<string>(["7993.dds", "1414.dds"]);
                case 12: return new List<string>(["7994.dds", "1415.dds"]);
                case 13: return new List<string>(["7995.dds", "1416.dds"]);
                case 14: return new List<string>(["7996.dds", "1417.dds"]);
                case 15: return new List<string>(["7997.dds", "1418.dds"]);
            }
            return null;
        }

        private void SaveImage(object state) {
            try
            {
                BcEncoder encoder = new BcEncoder();
                encoder.OutputOptions.GenerateMipMaps = false;
                encoder.OutputOptions.Quality = CompressionQuality.BestQuality;
                encoder.OutputOptions.Format = CompressionFormat.Bc1;
                encoder.OutputOptions.FileFormat = OutputFileFormat.Dds;

                object[] vals = state as object[];
                int i = Convert.ToInt32(vals[0]);

                List<string> filenames = GetKneeboardFilenames(i);

                for (int j = 0; j < filenames.Count; ++j)
                {
                    log.InfoFormat("filename = {0}", filenames[j]);
                    Bitmap b = new Bitmap(2048, 2048);

                    //leftPages[i].Update();
                    //rightPages[i].Update();

                    using (Graphics g = Graphics.FromImage(b))
                    {
                        //if (leftPages[i].PageType != PageType.NoChange) { 
                        g.DrawImage(leftPages[i].Bitmap, new Rectangle(0, 0, 1024, 2048), 0, 0, leftPages[i].Bitmap.Width, leftPages[i].Bitmap.Height, GraphicsUnit.Pixel, BmsUtils.GetImageAttributes(leftPages[i].Saturation));
                        //}
                        ///if (rightPages[i].PageType != PageType.NoChange)
                        //{
                        g.DrawImage(rightPages[i].Bitmap, new Rectangle(1024, 0, 1024, 2048), 0, 0, rightPages[i].Bitmap.Width, rightPages[i].Bitmap.Height, GraphicsUnit.Pixel, BmsUtils.GetImageAttributes(rightPages[i].Saturation));
                        //}
                    }

                    b.RotateFlip(RotateFlipType.RotateNoneFlipX);

                    FileStream fs = File.OpenWrite(bmsConfig.KBFilesDir + "KoreaObj" + Path.DirectorySeparatorChar + filenames[j]);
                    MemoryStream ms = new MemoryStream();
                    b.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    byte[] arr = ms.ToArray().Reverse().ToArray();
                    encoder.EncodeToDds(arr, b.Width, b.Height, BCnEncoder.Encoder.PixelFormat.Argb32).Write(fs);
                    fs.Close();
                }
            }
            finally { 
            
            }
        }

        private void btnSaveKB_Click(object sender, EventArgs e)
        {
            log.Debug(">> btnSaveKB_Click");
            missionData.TerrainDB = null;
            UseWaitCursor = true;
            this.Cursor = Cursors.WaitCursor;
            progressBar.Value = 0;
            progressBar.Maximum = 16;
            progressBar.Visible = true;

            try
            {
                //ImageConverter c = new ImageConverter();

                /*for (int i = 0; i < 16; i++)
                {
                    log.InfoFormat("Saving kb page {0}", i);
                    BcEncoder encoder = new BcEncoder();
                    encoder.OutputOptions.GenerateMipMaps = false;
                    encoder.OutputOptions.Quality = CompressionQuality.BestQuality;
                    encoder.OutputOptions.Format = CompressionFormat.Bc1;
                    encoder.OutputOptions.FileFormat = OutputFileFormat.Dds;

                    List<string> filenames = GetKneeboardFilenames(i);
                    for (int j = 0; j < filenames.Count; j++)
                    {
                        log.InfoFormat("filename = {0}", filenames[j]);
                        Bitmap b = new Bitmap(2048, 2048);

                        leftPages[i].Update();
                        rightPages[i].Update();

                        using (Graphics g = Graphics.FromImage(b))
                        {
                            //if (leftPages[i].PageType != PageType.NoChange) { 
                            g.DrawImage(leftPages[i].Bitmap, new Rectangle(0, 0, 1024, 2048), 0, 0, leftPages[i].Bitmap.Width, leftPages[i].Bitmap.Height, GraphicsUnit.Pixel, BmsUtils.GetImageAttributes(leftPages[i].Saturation));
                            //}
                            ///if (rightPages[i].PageType != PageType.NoChange)
                            //{
                            g.DrawImage(rightPages[i].Bitmap, new Rectangle(1024, 0, 1024, 2048), 0, 0, rightPages[i].Bitmap.Width, rightPages[i].Bitmap.Height, GraphicsUnit.Pixel, BmsUtils.GetImageAttributes(rightPages[i].Saturation));
                            //}
                        }

                        b.RotateFlip(RotateFlipType.RotateNoneFlipX);

                        FileStream fs = File.OpenWrite(bmsConfig.KBFilesDir + "KoreaObj" + Path.DirectorySeparatorChar + filenames[j]);
                        MemoryStream ms = new MemoryStream();
                        b.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        byte[] arr = ms.ToArray().Reverse().ToArray();
                        encoder.EncodeToDds(arr, b.Width, b.Height, BCnEncoder.Encoder.PixelFormat.Argb32).Write(fs);
                        fs.Close();
                    }

                    progressBar.Value++;
                }*/

                for (int i = 0; i < 16; i += 2) {

                    Thread t = new Thread(SaveImage);
                    t.Start(new object[] { i });
                    SaveImage(new object[] { i + 1 });
                    t.Join(); 

                    progressBar.Value += 2;
                }

                this.Invalidate(true);
                progressBar.Invalidate();
            }
            finally
            {
                UseWaitCursor = false;
                progressBar.Visible = false;
                this.Cursor = Cursors.Arrow;
            }
            log.Debug("<< btnSaveKB_Click");
        }


        #region Paints
        private void tabLeft1_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[0] : null);
        }

        private void tabLeft2_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[1] : null);
        }

        private void tabLeft3_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[2] : null);
        }

        private void tabLeft4_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[3] : null);
        }

        private void tabLeft5_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[4] : null);
        }

        private void tabLeft6_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[5] : null);
        }

        private void tabLeft7_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[6] : null);
        }

        private void tabLeft8_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[7] : null);
        }

        private void tabLeft9_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[8] : null);
        }

        private void tabLeft10_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[9] : null);
        }

        private void tabLeft11_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[10] : null);
        }

        private void tabLeft12_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[11] : null);
        }

        private void tabLeft13_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[12] : null);
        }

        private void tabLeft14_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[13] : null);
        }

        private void tabLeft15_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[14] : null);
        }

        private void tabLeft16_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, leftPages.Count > 0 ? leftPages[15] : null);
        }

        private void tabRight1_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[0] : null);
        }

        private void tabRight2_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[1] : null);
        }

        private void tabRight3_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[2] : null);
        }

        private void tabRight4_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[3] : null);
        }

        private void tabRight5_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[4] : null);
        }

        private void tabRight6_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[5] : null);
        }

        private void tabRight7_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[6] : null);
        }

        private void tabRight8_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[7] : null);
        }

        private void tabRight9_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[8] : null);
        }

        private void tabRight10_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[9] : null);
        }

        private void tabRight11_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[10] : null);
        }

        private void tabRight12_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[11] : null);
        }

        private void tabRight13_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[12] : null);
        }

        private void tabRight14_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[13] : null);
        }

        private void tabRight15_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[14] : null);
        }

        private void tabRight16_Paint(object sender, PaintEventArgs e)
        {
            DrawKBPage(sender as TabPage, e.Graphics, rightPages.Count > 0 ? rightPages[15] : null);
        }

        #endregion

        private void tabControlLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLeftType.SelectedIndex == cbLeftType.Items.IndexOf(leftPages[tabControlLeft.SelectedIndex].PageType.ToString()))
            {
                leftPages[tabControlLeft.SelectedIndex].Update();
                tabControlLeft.TabPages[tabControlLeft.SelectedIndex].Invalidate();
            }
            else
                cbLeftType.SelectedIndex = cbLeftType.Items.IndexOf(leftPages[tabControlLeft.SelectedIndex].PageType.ToString());
            trbLeftSat.Value = leftPages[tabControlLeft.SelectedIndex].Saturation;
        }

        private void tabControlRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRightType.SelectedIndex == cbRightType.Items.IndexOf(rightPages[tabControlRight.SelectedIndex].PageType.ToString()))
            {
                rightPages[tabControlRight.SelectedIndex].Update();
                tabControlRight.TabPages[tabControlRight.SelectedIndex].Invalidate();
            }
            else
                cbRightType.SelectedIndex = cbRightType.Items.IndexOf(rightPages[tabControlRight.SelectedIndex].PageType.ToString());
            trbRightSat.Value = rightPages[tabControlRight.SelectedIndex].Saturation;
        }

        private void cbLeftType_SelectedIndexChanged(object sender, EventArgs e)
        {
            log.DebugFormat(">> cbLeftType_SelectedIndexChanged {0}", cbLeftType.SelectedIndex);
            PageType pageType = Enum.Parse<PageType>(cbLeftType.SelectedItem.ToString());
            leftPages[tabControlLeft.SelectedIndex].PageType = pageType;
            leftPages[tabControlLeft.SelectedIndex].Update();
            //tabControlLeft.SelectedTab.ContextMenuStrip = pageType == PageType.Datacard ? ctxMnuDatacard : null;
            UpdateContextMenuLeft(tabControlLeft.SelectedIndex);
            kneeboardLayout.LeftPages[tabControlLeft.SelectedIndex].PageType = leftPages[tabControlLeft.SelectedIndex].PageType;
            //SaveKneeboardLayout();
            tabControlLeft.TabPages[tabControlLeft.SelectedIndex].Invalidate();
            log.DebugFormat("<< cbLeftType_SelectedIndexChanged {0}", cbLeftType.SelectedIndex);
        }

        private void cbRightType_SelectedIndexChanged(object sender, EventArgs e)
        {
            log.DebugFormat(">> cbRightType_SelectedIndexChanged {0}", cbLeftType.SelectedIndex);
            PageType pageType = Enum.Parse<PageType>(cbRightType.SelectedItem.ToString());
            rightPages[tabControlRight.SelectedIndex].PageType = pageType;
            rightPages[tabControlRight.SelectedIndex].Update();
            UpdateContextMenuRight(tabControlRight.SelectedIndex);
            kneeboardLayout.RightPages[tabControlRight.SelectedIndex].PageType = rightPages[tabControlRight.SelectedIndex].PageType;
            //SaveKneeboardLayout();
            tabControlRight.TabPages[tabControlRight.SelectedIndex].Invalidate();
            log.DebugFormat("<< cbRightType_SelectedIndexChanged {0}", cbLeftType.SelectedIndex);
        }

        private void cbTheater_SelectedIndexChanged(object sender, EventArgs e)
        {
            TheaterSelected();
        }

        private void btnRightClipboard_Click(object sender, EventArgs e)
        {
            log.Debug(">> btnRightClipboard_Click");
            Image image = Clipboard.GetImage();
            if (image != null)
            {
                using (PasteClipboardForm frm = new PasteClipboardForm(image))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        rightPages[tabControlRight.SelectedIndex].SetImage(frm.GetResultImage());
                        kneeboardLayout.RightPages[tabControlRight.SelectedIndex].Image = rightPages[tabControlRight.SelectedIndex].Bitmap;
                        SaveKneeboardLayout();
                        cbRightType.SelectedIndex = cbRightType.Items.IndexOf(rightPages[tabControlRight.SelectedIndex].PageType.ToString());
                        tabControlRight.TabPages[tabControlRight.SelectedIndex].Invalidate();

                    }
                }
                image.Dispose();
            }
            log.Debug("<< btnRightClipboard_Click");
        }

        private void btnRightFile_Click(object sender, EventArgs e)
        {
            if (dlgPasteFile.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(1280, 2048, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Image imgFile = Image.FromFile(dlgPasteFile.FileName);
                using (Graphics g = Graphics.FromImage(bmp))
                    g.DrawImage(imgFile, 0, 0, 1280, 2048);

                rightPages[tabControlRight.SelectedIndex].SetImage(bmp);

                kneeboardLayout.RightPages[tabControlRight.SelectedIndex].Image = rightPages[tabControlRight.SelectedIndex].Bitmap;
                SaveKneeboardLayout();
                cbRightType.SelectedIndex = cbRightType.Items.IndexOf(rightPages[tabControlRight.SelectedIndex].PageType.ToString());
                tabControlRight.TabPages[tabControlRight.SelectedIndex].Invalidate();
            }
        }

        private void btnLeftFile_Click(object sender, EventArgs e)
        {
            if (dlgPasteFile.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(1280, 2048, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Image imgFile = Image.FromFile(dlgPasteFile.FileName);
                using (Graphics g = Graphics.FromImage(bmp))
                    g.DrawImage(imgFile, 0, 0, 1280, 2048);

                leftPages[tabControlLeft.SelectedIndex].SetImage(bmp);

                kneeboardLayout.LeftPages[tabControlLeft.SelectedIndex].Image = (Bitmap)leftPages[tabControlLeft.SelectedIndex].Bitmap.Clone();
                SaveKneeboardLayout();
                cbLeftType.SelectedIndex = cbLeftType.Items.IndexOf(leftPages[tabControlLeft.SelectedIndex].PageType.ToString());
                tabControlLeft.TabPages[tabControlLeft.SelectedIndex].Invalidate();
            }
        }

        private void btnLeftClipboard_Click(object sender, EventArgs e)
        {
            log.Debug(">> btnLeftClipboard_Click");
            Image image = Clipboard.GetImage();
            if (image != null)
            {
                using (PasteClipboardForm frm = new PasteClipboardForm(image))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        leftPages[tabControlLeft.SelectedIndex].SetImage(frm.GetResultImage());
                        kneeboardLayout.LeftPages[tabControlLeft.SelectedIndex].Image = leftPages[tabControlLeft.SelectedIndex].Bitmap;
                        SaveKneeboardLayout();
                        cbLeftType.SelectedIndex = cbLeftType.Items.IndexOf(leftPages[tabControlLeft.SelectedIndex].PageType.ToString());
                        tabControlLeft.TabPages[tabControlLeft.SelectedIndex].Invalidate();

                    }
                }
                image.Dispose();
            }
            log.Debug("<< btnLeftClipboard_Click");
        }

        private void mnuItemSelectFlights_Click(object sender, EventArgs e)
        {
            log.Debug(">> mnuItemSelectFlights_Click");
            if (sender is ToolStripMenuItem)
            {
                ToolStrip ts = (sender as ToolStripMenuItem).GetCurrentParent();
                if (ts is ContextMenuStrip)
                {
                    Control sc = (ts as ContextMenuStrip).SourceControl;
                    if (sc is TabPage)
                    {
                        TabPage tabPage = sc as TabPage;
                        TabControl tabControl = tabPage.Parent as TabControl;
                        bool isRight = tabControl == tabControlRight;

                        using (SelectMultipleFlights frm = new SelectMultipleFlights(missionData))
                        {
                            if (isRight)
                                frm.SelectedFlights = rightPages[tabControlRight.SelectedIndex].DatacardFlights.ToArray();
                            else
                                frm.SelectedFlights = leftPages[tabControlLeft.SelectedIndex].DatacardFlights.ToArray();

                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                if (isRight)
                                    rightPages[tabControlRight.SelectedIndex].DatacardFlights = frm.SelectedFlights.ToList();
                                else
                                    leftPages[tabControlLeft.SelectedIndex].DatacardFlights = frm.SelectedFlights.ToList();

                                tabControlLeft.TabPages[tabControlLeft.SelectedIndex].Invalidate();
                                tabControlRight.TabPages[tabControlRight.SelectedIndex].Invalidate();
                            }
                        }
                    }
                }
            }
            log.Debug("<< mnuItemSelectFlights_Click");
        }

        private void btnOpenMission_Click(object sender, EventArgs e)
        {
            OpenMission();
        }

        private void mnuItemSelectSupportFlights_Click(object sender, EventArgs e)
        {
            log.Debug(">> mnuItemSelectSupportFlights_Click");
            if (sender is ToolStripMenuItem)
            {
                ToolStrip ts = (sender as ToolStripMenuItem).GetCurrentParent();
                if (ts is ContextMenuStrip)
                {
                    Control sc = (ts as ContextMenuStrip).SourceControl;
                    if (sc is TabPage)
                    {
                        TabPage tabPage = sc as TabPage;
                        TabControl tabControl = tabPage.Parent as TabControl;
                        bool isRight = tabControl == tabControlRight;

                        using (SelectMultipleFlights frm = new SelectMultipleFlights(missionData))
                        {
                            if (isRight)
                                frm.SelectedFlights = rightPages[tabControlRight.SelectedIndex].DatacardSupportFlights.ToArray();
                            else
                                frm.SelectedFlights = leftPages[tabControlLeft.SelectedIndex].DatacardSupportFlights.ToArray();

                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                if (isRight)
                                    rightPages[tabControlRight.SelectedIndex].DatacardSupportFlights = frm.SelectedFlights.ToList();
                                else
                                    leftPages[tabControlLeft.SelectedIndex].DatacardSupportFlights = frm.SelectedFlights.ToList();

                                tabControlLeft.TabPages[tabControlLeft.SelectedIndex].Invalidate();
                                tabControlRight.TabPages[tabControlRight.SelectedIndex].Invalidate();
                            }
                        }
                    }
                }
            }
            log.Debug("<< mnuItemSelectSupportFlights_Click");
        }

        private void trbRightSat_ValueChanged(object sender, EventArgs e)
        {
            rightPages[tabControlRight.SelectedIndex].Saturation = trbRightSat.Value;
            rightPages[tabControlRight.SelectedIndex].Update();
            tabControlRight.TabPages[tabControlRight.SelectedIndex].Invalidate();

            kneeboardLayout.RightPages[tabControlRight.SelectedIndex].Saturation = rightPages[tabControlRight.SelectedIndex].Saturation;
            //SaveKneeboardLayout();
        }

        private void trbLeftSat_ValueChanged(object sender, EventArgs e)
        {
            leftPages[tabControlLeft.SelectedIndex].Saturation = trbLeftSat.Value;
            leftPages[tabControlLeft.SelectedIndex].Update();
            tabControlLeft.TabPages[tabControlLeft.SelectedIndex].Invalidate();

            kneeboardLayout.LeftPages[tabControlLeft.SelectedIndex].Saturation = leftPages[tabControlLeft.SelectedIndex].Saturation;
            //SaveKneeboardLayout();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Debug(">> MainForm_FormClosed");
            GC.Collect();
            SaveKneeboardLayout();
            kneeboardLayout.Dispose();

            BMSKneeboarderDB.Cleanup();

            foreach (KneeboardPage p in leftPages)
                p.Dispose();
            foreach (KneeboardPage p in rightPages)
                p.Dispose();
            log.Debug("<< MainForm_FormClosed");
        }

        private void ShowSettingsForm()
        {
            using (SettingsForm frm = new SettingsForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadSettings();
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettingsForm();
        }

        private void LoadSettings()
        {
            bmsConfig.BmsDir = BmsUtils.GetBmsDir();
        }

        private void btnReloadDTC_Click(object sender, EventArgs e)
        {

        }

        private void ShowMapSettings(bool isRight)
        {
            using (MapSettingsForm frm = new MapSettingsForm(missionData, isRight ? rightPages[tabControlRight.SelectedIndex].MapSettings : leftPages[tabControlLeft.SelectedIndex].MapSettings))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (isRight)
                    {
                        kneeboardLayout.RightPages[tabControlRight.SelectedIndex].MapSettings = rightPages[tabControlRight.SelectedIndex].MapSettings;
                        rightPages[tabControlRight.SelectedIndex].Update();
                        tabControlRight.SelectedTab.Invalidate();
                    }
                    else
                    {
                        kneeboardLayout.LeftPages[tabControlLeft.SelectedIndex].MapSettings = leftPages[tabControlLeft.SelectedIndex].MapSettings;
                        leftPages[tabControlLeft.SelectedIndex].Update();
                        tabControlLeft.SelectedTab.Invalidate();
                    }
                }
            }
        }

        private void mnuItemMapSettings_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStrip ts = (sender as ToolStripMenuItem).GetCurrentParent();
                if (ts is ContextMenuStrip)
                {
                    Control sc = (ts as ContextMenuStrip).SourceControl;
                    if (sc is TabPage)
                    {
                        TabPage tabPage = sc as TabPage;
                        TabControl tabControl = tabPage.Parent as TabControl;
                        bool isRight = tabControl == tabControlRight;

                        ShowMapSettings(isRight);
                    }
                }
            }



        }

        private void mnuLoadPilotDTC_Click(object sender, EventArgs e)
        {
            log.Debug(">> mnuLoadPilotDTC_Click");
            if (missionData == null)
                return;

            missionData.LoadPilotDTC();

            leftPages[tabControlLeft.SelectedIndex].Update();
            tabControlLeft.SelectedTab.Invalidate();
            rightPages[tabControlRight.SelectedIndex].Update();
            tabControlRight.SelectedTab.Invalidate();
            log.Debug("<< mnuLoadPilotDTC_Click");
        }

        private void muLoadMissionDTC_Click(object sender, EventArgs e)
        {
            log.Debug(">> muLoadMissionDTC_Click");
            if (missionData == null)
                return;

            missionData.LoadMissionDTC();

            leftPages[tabControlLeft.SelectedIndex].Update();
            tabControlLeft.SelectedTab.Invalidate();
            rightPages[tabControlRight.SelectedIndex].Update();
            tabControlRight.SelectedTab.Invalidate();
            log.Debug("<< muLoadMissionDTC_Click");
        }

        private void tabRight_DoubleClick(object sender, EventArgs e)
        {
            log.Debug(">> tabRight_DoubleClick");
            PageType pt = rightPages[tabControlRight.SelectedIndex].PageType;
            if (pt == PageType.Map)
                ShowMapSettings(true);
            if (pt == PageType.Briefing)
                ShowBriefingSettings();
            log.Debug("<< tabRight_DoubleClick");
        }

        private void tabLeft_DoubleClick(object sender, EventArgs e)
        {
            log.Debug(">> tabLeft_DoubleClick");
            PageType pt = leftPages[tabControlLeft.SelectedIndex].PageType;
            if (pt == PageType.Map)
                ShowMapSettings(false);
            if (pt == PageType.Briefing)
                ShowBriefingSettings();
            log.Debug("<< tabLeft_DoubleClick");
        }

        public void ShowBriefingSettings()
        {
            log.Debug(">> ShowBriefingSettings");
            using (BriefingSettingsForm frm = new BriefingSettingsForm(missionData))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    kneeboardLayout.RightPages[tabControlRight.SelectedIndex].MapSettings = rightPages[tabControlRight.SelectedIndex].MapSettings;
                    rightPages[tabControlRight.SelectedIndex].Update();
                    tabControlRight.SelectedTab.Invalidate();
                    kneeboardLayout.LeftPages[tabControlLeft.SelectedIndex].MapSettings = leftPages[tabControlLeft.SelectedIndex].MapSettings;
                    leftPages[tabControlLeft.SelectedIndex].Update();
                    tabControlLeft.SelectedTab.Invalidate();
                }
            }
            log.Debug("<< ShowBriefingSettings");
        }
        private void editBriefingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowBriefingSettings();
        }

        private void btnLink16_Click(object sender, EventArgs e)
        {
            using (Link16SettingsForm frm = new Link16SettingsForm(missionData))
            {
                frm.ShowDialog();
            }
        }

        private MapSettings CopiedMapSettings { get; set; } = null;

        private void mnuCopyMapSettings_Click(object sender, EventArgs e)
        {
            log.Debug(">> mnuCopyMapSettings_Click");
            if (CopiedMapSettings != null)
            {
                CopiedMapSettings.Dispose();
                CopiedMapSettings = null;
            }

            if (sender is ToolStripMenuItem)
            {
                ToolStrip ts = (sender as ToolStripMenuItem).GetCurrentParent();
                if (ts is ContextMenuStrip)
                {
                    Control sc = (ts as ContextMenuStrip).SourceControl;
                    if (sc is TabPage)
                    {
                        TabPage tabPage = sc as TabPage;
                        TabControl tabControl = tabPage.Parent as TabControl;
                        bool isRight = tabControl == tabControlRight;

                        if (isRight)
                        {
                            CopiedMapSettings = new MapSettings(rightPages[tabControlRight.SelectedIndex].MapSettings);
                        }
                        else
                        {
                            CopiedMapSettings = new MapSettings(leftPages[tabControlLeft.SelectedIndex].MapSettings);
                        }

                        mnuPasteMap.Enabled = true;
                        mnuPasteMapSettings.Enabled = true;
                    }
                }
            }
            log.Debug("<< mnuCopyMapSettings_Click");
        }

        private void mnuPasteMapSettings_Click(object sender, EventArgs e)
        {
            log.Debug(">> mnuPasteMapSettings_Click");
            if (CopiedMapSettings == null)
                return;

            if (sender is ToolStripMenuItem)
            {
                ToolStrip ts = (sender as ToolStripMenuItem).GetCurrentParent();
                if (ts is ContextMenuStrip)
                {
                    Control sc = (ts as ContextMenuStrip).SourceControl;
                    if (sc is TabPage)
                    {
                        TabPage tabPage = sc as TabPage;
                        TabControl tabControl = tabPage.Parent as TabControl;
                        bool isRight = tabControl == tabControlRight;

                        if (isRight)
                        {
                            rightPages[tabControlRight.SelectedIndex].MapSettings.PasteObjAppearance(CopiedMapSettings);
                            rightPages[tabControlRight.SelectedIndex].Update();
                            tabControlRight.SelectedTab.Invalidate();
                        }
                        else
                        {
                            leftPages[tabControlLeft.SelectedIndex].MapSettings.PasteObjAppearance(CopiedMapSettings);
                            leftPages[tabControlLeft.SelectedIndex].Update();
                            tabControlLeft.SelectedTab.Invalidate();
                        }
                    }
                }
            }
            log.Debug("<< mnuPasteMapSettings_Click");
        }

        private void mnuPasteMap_Click(object sender, EventArgs e)
        {
            log.Debug(">> mnuPasteMap_Click");
            if (CopiedMapSettings == null)
                return;

            if (sender is ToolStripMenuItem)
            {
                ToolStrip ts = (sender as ToolStripMenuItem).GetCurrentParent();
                if (ts is ContextMenuStrip)
                {
                    Control sc = (ts as ContextMenuStrip).SourceControl;
                    if (sc is TabPage)
                    {
                        TabPage tabPage = sc as TabPage;
                        TabControl tabControl = tabPage.Parent as TabControl;
                        bool isRight = tabControl == tabControlRight;

                        if (isRight)
                        {
                            rightPages[tabControlRight.SelectedIndex].MapSettings.Paste(CopiedMapSettings);
                            rightPages[tabControlRight.SelectedIndex].Update();
                            tabControlRight.SelectedTab.Invalidate();
                        }
                        else
                        {
                            leftPages[tabControlLeft.SelectedIndex].MapSettings.Paste(CopiedMapSettings);
                            leftPages[tabControlLeft.SelectedIndex].Update();
                            tabControlLeft.SelectedTab.Invalidate();
                        }
                    }
                }
            }
            log.Debug("<< mnuPasteMap_Click");
        }

        private void btnReloadMission_Click(object sender, EventArgs e)
        {
            log.Debug(">> btnReloadMission_Click");
            LoadMission(missionFileName, true);
            log.Debug("<< btnReloadMission_Click");
        }
    }


}

