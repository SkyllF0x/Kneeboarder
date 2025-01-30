using log4net;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace BMSKneeboarder.Bms
{
    public class BmsConfig
    {
        private static readonly ILog log = LogManager.GetLogger("default");
        public string BmsDir { get; set; } = BmsUtils.GetBmsDir();
        public string BmsDataDir { get { return BmsDir + "Data" + Path.DirectorySeparatorChar; } }
        public string DefaultObjectDir { get; set; } = string.Empty;
        public string ObjectDir { get; set; } = string.Empty;
        public string KBFilesDir { get; set; } = string.Empty;
        public string CampaignDir { get; set; } = string.Empty;
        public string TerrainDir { get; set; } = string.Empty;
        public string ArtDir { get; set; } = string.Empty;
        public bool IsValid { get; set; } = false;

        public string g_sTileSet { get; set; } = string.Empty;
        public bool g_bEnableNewTerrain { get; set; } = false;
        public int g_nObjectiveDataReadMode { get; set; } = 0;
        public void ReadBmsCfg()
        {
            
            IsValid = false;
            string text = BmsDir + "User\\Config\\Falcon BMS.cfg";
            if (File.Exists(text))
            {
                //this.g_bUseXmlDatabase = clsBmsConfig.ReadBmsCfgBool(text, "g_bUseXmlDatabase", ref flag);
                g_sTileSet = ReadBmsCfgString(text, "g_sTileSet", g_sTileSet);
                g_bEnableNewTerrain = ReadBmsCfgBool(text, "g_bEnableNewTerrain", g_bEnableNewTerrain);
                g_nObjectiveDataReadMode = ReadBmsCfgInteger(text, "g_nObjectiveDataReadMode", g_nObjectiveDataReadMode);

                ReadBmsUserCfg();

                IsValid = true;
            }
            else
                MessageBox.Show("Cfg file not found at: " + text + " Check settings.", "Config error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ReadBmsUserCfg()
        {
            BmsConfig bmsConfig = new BmsConfig();
            string text = BmsDir + "User\\Config\\Falcon BMS User.cfg";

            //bool flag2 = bmsConfig.ReadBmsCfgBool(text, "g_bUseXmlDatabase");
            g_bEnableNewTerrain = bmsConfig.ReadBmsCfgBool(text, "g_bEnableNewTerrain", g_bEnableNewTerrain);
            g_nObjectiveDataReadMode = bmsConfig.ReadBmsCfgInteger(text, "g_nObjectiveDataReadMode", g_nObjectiveDataReadMode);
            g_sTileSet = bmsConfig.ReadBmsCfgString(text, "g_sTileSet", g_sTileSet);
        }

        public bool ReadBmsCfgBool(string fName, string Setting, bool def)
        {
            string[] array = new string[0];
            checked
            {
                bool flag = def;
                if (File.Exists(fName))
                {
                    FileStream fileStream = new FileStream(fName, FileMode.Open, FileAccess.Read);
                    StreamReader streamReader = new StreamReader(fileStream);
                    try
                    {
                        while (!streamReader.EndOfStream)
                        {
                            Array.Resize<string>(ref array, array.Length + 1);
                            array[array.Length - 1] = streamReader.ReadLine();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    Setting = Strings.LCase(Setting);
                    if (array.Length >= 1)
                    {
                        int num = array.Length - 1;
                        int i = 0;
                        while (i <= num)
                        {
                            if (Strings.InStr(Strings.LCase(array[i]), Setting, CompareMethod.Binary) > 0)
                            {
                                string text = Strings.LCase(array[i]);
                                text = text.Replace("set ", "");
                                text = Strings.Trim(text);
                                string text2 = Strings.Mid(text, 1, 3);
                                text = text.Replace(Setting, "");
                                int num2 = text.IndexOf("/");
                                if (num2 > 0)
                                {
                                    text = Strings.Mid(text, 1, num2);
                                }
                                text = Strings.Trim(text);
                                if (Operators.CompareString(text2, "g_b", false) == 0)
                                {
                                    flag = Conversions.ToBoolean(text);
                                    break;
                                }
                                if (Operators.CompareString(text2, "g_f", false) == 0)
                                {
                                    flag = def;
                                    break;
                                }
                                if (Operators.CompareString(text2, "g_n", false) == 0)
                                {
                                    flag = def;
                                    break;
                                }
                                Operators.CompareString(text2, "g_s", false);
                                flag = def;
                                break;
                            }
                            else
                            {
                                i++;
                            }
                        }
                    }
                }
                else
                {
                }
                return flag;
            }
        }

        // Token: 0x06000011 RID: 17 RVA: 0x000022A0 File Offset: 0x000004A0
        public float ReadBmsCfgFloat(string fName, string Setting, float def)
        {
            string[] array = new string[0];
            checked
            {
                float num3 = def;
                if (File.Exists(fName))
                {
                    FileStream fileStream = new FileStream(fName, FileMode.Open, FileAccess.Read);
                    StreamReader streamReader = new StreamReader(fileStream);
                    try
                    {
                        while (!streamReader.EndOfStream)
                        {
                            Array.Resize<string>(ref array, array.Length + 1);
                            array[array.Length - 1] = streamReader.ReadLine();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    Setting = Strings.LCase(Setting);
                    if (array.Length >= 1)
                    {
                        int num = array.Length - 1;
                        int i = 0;
                        while (i <= num)
                        {
                            if (Strings.InStr(Strings.LCase(array[i]), Setting, CompareMethod.Binary) > 0)
                            {
                                string text = Strings.LCase(array[i]);
                                text = text.Replace("set ", "");
                                text = Strings.Trim(text);
                                string text2 = Strings.Mid(text, 1, 3);
                                text = text.Replace(Setting, "");
                                int num2 = text.IndexOf("/");
                                if (num2 > 0)
                                {
                                    text = Strings.Mid(text, 1, num2);
                                }
                                text = Strings.Trim(text);
                                if (Operators.CompareString(text2, "g_b", false) == 0)
                                {
                                    num3 = def;
                                    break;
                                }
                                if (Operators.CompareString(text2, "g_f", false) == 0)
                                {
                                    if (Versioned.IsNumeric(text))
                                    {
                                        num3 = Conversions.ToSingle(text);
                                        break;
                                    }
                                    num3 = def;
                                    break;
                                }
                                else
                                {
                                    if (Operators.CompareString(text2, "g_n", false) == 0)
                                    {
                                        num3 = def;
                                        break;
                                    }
                                    Operators.CompareString(text2, "g_s", false);
                                    num3 = def;
                                    break;
                                }
                            }
                            else
                            {
                                i++;
                            }
                        }
                    }
                }
                else
                {
                }
                return num3;
            }
        }

        // Token: 0x06000012 RID: 18 RVA: 0x0000242C File Offset: 0x0000062C
        public int ReadBmsCfgInteger(string fName, string Setting, int def)
        {
            string[] array = new string[0];
            checked
            {
                float num3 = def;
                if (File.Exists(fName))
                {
                    FileStream fileStream = new FileStream(fName, FileMode.Open, FileAccess.Read);
                    StreamReader streamReader = new StreamReader(fileStream);
                    try
                    {
                        while (!streamReader.EndOfStream)
                        {
                            Array.Resize<string>(ref array, array.Length + 1);
                            array[array.Length - 1] = streamReader.ReadLine();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    Setting = Strings.LCase(Setting);
                    if (array.Length >= 1)
                    {
                        int num = array.Length - 1;
                        int i = 0;
                        while (i <= num)
                        {
                            if (Strings.InStr(Strings.LCase(array[i]), Setting, CompareMethod.Binary) > 0)
                            {
                                string text = Strings.LCase(array[i]);
                                text = text.Replace("set ", "");
                                text = Strings.Trim(text);
                                string text2 = Strings.Mid(text, 1, 3);
                                text = text.Replace(Setting, "");
                                int num2 = text.IndexOf("/");
                                if (num2 > 0)
                                {
                                    text = Strings.Mid(text, 1, num2);
                                }
                                text = Strings.Trim(text);
                                if (Operators.CompareString(text2, "g_b", false) == 0)
                                {
                                    num3 = def;
                                    break;
                                }
                                if (Operators.CompareString(text2, "g_f", false) == 0)
                                {
                                    num3 = def;
                                    break;
                                }
                                if (Operators.CompareString(text2, "g_n", false) != 0)
                                {
                                    Operators.CompareString(text2, "g_s", false);
                                    num3 = def;
                                    break;
                                }
                                if (Versioned.IsNumeric(text))
                                {
                                    num3 = Conversions.ToSingle(text);
                                    break;
                                }
                                num3 = def;
                                break;
                            }
                            else
                            {
                                i++;
                            }
                        }
                    }
                }
                else
                {
                }
                return (int)Math.Round((double)num3);
            }
        }

        // Token: 0x06000013 RID: 19 RVA: 0x000025C0 File Offset: 0x000007C0
        public string ReadBmsCfgString(string fName, string Setting, string def)
        {
            string text = def;
            string[] array = new string[0];
            checked
            {
                if (File.Exists(fName))
                {
                    FileStream fileStream = new FileStream(fName, FileMode.Open, FileAccess.Read);
                    StreamReader streamReader = new StreamReader(fileStream);
                    try
                    {
                        while (!streamReader.EndOfStream)
                        {
                            Array.Resize<string>(ref array, array.Length + 1);
                            array[array.Length - 1] = streamReader.ReadLine();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    Setting = Strings.LCase(Setting);
                    if (array.Length >= 1)
                    {
                        int num = array.Length - 1;
                        int i = 0;
                        while (i <= num)
                        {
                            if (Strings.InStr(Strings.LCase(array[i]), Setting, CompareMethod.Binary) > 0)
                            {
                                string text2 = Strings.LCase(array[i]);
                                text2 = text2.Replace("set ", "");
                                text2 = Strings.Trim(text2);
                                string text3 = Strings.Mid(text2, 1, 3);
                                text2 = text2.Replace(Setting, "");
                                int num2 = text2.IndexOf("/");
                                if (num2 > 0)
                                {
                                    text2 = Strings.Mid(text2, 1, num2);
                                }
                                text2 = Strings.Trim(text2);
                                if (Operators.CompareString(text3, "g_b", false) == 0)
                                {
                                    text = def;
                                    break;
                                }
                                if (Operators.CompareString(text3, "g_f", false) == 0)
                                {
                                    text = def;
                                    break;
                                }
                                if (Operators.CompareString(text3, "g_n", false) == 0)
                                {
                                    text = def;
                                    break;
                                }
                                if (Operators.CompareString(text3, "g_s", false) == 0)
                                {
                                    num2 = text2.IndexOf('"') + 2;
                                    text2 = Strings.Mid(text2, num2, text2.Length);
                                    num2 = text2.IndexOf('"');
                                    text = Strings.Mid(text2, 1, num2);
                                    break;
                                }
                                text = def;
                                break;
                            }
                            else
                            {
                                i++;
                            }
                        }
                    }
                }
                else
                {
                }
                return text;
            }
        }

        public void Log()
        {
            log.InfoFormat("BmsDir {0}", BmsDir);
            log.InfoFormat("BmsDataDir {0}", BmsDataDir);
            log.InfoFormat("DefaultObjectDir {0}", DefaultObjectDir);
            log.InfoFormat("ObjectDir {0}", ObjectDir);
            log.InfoFormat("KBFilesDir {0}", KBFilesDir);
            log.InfoFormat("CampaignDir {0}", CampaignDir);
            log.InfoFormat("TerrainDir {0}", TerrainDir);
            log.InfoFormat("ArtDir {0}", ArtDir);
            log.InfoFormat("g_sTileSet {0}", g_sTileSet);
            log.InfoFormat("g_bEnableNewTerrain {0}", g_bEnableNewTerrain);
            log.InfoFormat("g_nObjectiveDataReadMode {0}", g_nObjectiveDataReadMode);
        }
    }
}
