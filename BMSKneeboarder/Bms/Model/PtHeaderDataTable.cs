using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace BMSKneeboarder.Bms.Model
{
    public class PtHeaderDataTable
    {
        // Token: 0x060000ED RID: 237 RVA: 0x0001E3D2 File Offset: 0x0001C5D2
        public PtHeaderDataTable()
        {
            //this.L = new CampLib();
        }

        // Token: 0x060000EE RID: 238 RVA: 0x0001E3E8 File Offset: 0x0001C5E8
        public List<BmsStructs.PtHeaderDataType> LoadPHD(string DefaultDir, string fName, ref bool ReadXml, int DataReadMode)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            string text = Path.GetDirectoryName(fName) + "\\ObjectiveRelatedData";
            List<BmsStructs.PtHeaderDataType> array = new List<BmsStructs.PtHeaderDataType>();
            if (ReadXml)
            {
                if (DataReadMode == 0)
                {
                    array = this.ReadXmlSeparatePHD(text);
                    if (array != null)
                    {
                        return array;
                    }
                }
                if (File.Exists(fName))
                {
                    array = this.ReadXmlPHD(fName);
                }
                else
                {
                    fName = Strings.LCase(fName);
                    fName = fName.Replace("falcon4_phd.xml", "falcon4.phd");
                    if (File.Exists(fName))
                    {
                        array = this.ReadPtHeaderTable(fName);
                        ReadXml = false;
                    }
                    else
                    {
                        fName = DefaultDir + "falcon4_phd.xml";
                        if (File.Exists(fName))
                        {
                            array = this.ReadXmlPHD(fName);
                        }
                        else
                        {
                            fName = Strings.LCase(fName);
                            fName = fName.Replace("falcon4_phd.xml", "falcon4.phd");
                            if (File.Exists(fName))
                            {
                                array = this.ReadPtHeaderTable(fName);
                                ReadXml = false;
                            }
                        }
                    }
                }
            }
            else if (File.Exists(fName))
            {
                array = this.ReadPtHeaderTable(fName);
            }
            else
            {
                fName = DefaultDir + "falcon4.phd";
                if (File.Exists(fName))
                {
                    array = this.ReadPtHeaderTable(fName);
                }
            }
            return array;
        }

        // Token: 0x060000EF RID: 239 RVA: 0x0001E518 File Offset: 0x0001C718
        public bool SavePHD(BmsStructs.PtHeaderDataType[] PtHeaderDataEntries, string fName, ref bool ReadXml)
        {
            bool flag = false;
            bool flag2;
            if (Information.IsNothing(PtHeaderDataEntries))
            {
                flag2 = false;
            }
            else
            {
                if (ReadXml)
                {
                    flag = this.WriteXmlPHD(PtHeaderDataEntries, fName);
                }
                else
                {
                    byte[] array = new byte[1];
                    array = this.WriteFalconPHD(PtHeaderDataEntries);
                    try
                    {
                        using (FileStream fileStream = new FileStream(fName, FileMode.OpenOrCreate))
                        {
                            fileStream.Write(array, 0, array.Length);
                            fileStream.Close();
                            flag = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        flag = false;
                    }
                }
                flag2 = flag;
            }
            return flag2;
        }

        // Token: 0x060000F0 RID: 240 RVA: 0x0001E5AC File Offset: 0x0001C7AC
        public List<BmsStructs.PtHeaderDataType> ReadPtHeaderTable(string PtHeaderTableFilePath)
        {
            checked
            {
                List<BmsStructs.PtHeaderDataType> array = new List<BmsStructs.PtHeaderDataType>();
                if (!File.Exists(PtHeaderTableFilePath))
                {
                }
                else
                {
                    FileStream fileStream = new FileStream(PtHeaderTableFilePath, FileMode.Open, FileAccess.Read);
                    byte[] array2 = new byte[(int)fileStream.Length + 1];
                    fileStream.Read(array2, 0, (int)fileStream.Length);
                    fileStream.Close();
                    int num = 0;
                    short num2 = BitConverter.ToInt16(array2, num);
                    num += 2;
                    //BmsStructs.PtHeaderDataType[] array3 = new BmsStructs.PtHeaderDataType[(int)(num2 - 1 + 1)];
                    int num3 = (int)(num2 - 1);
                    for (int i = 0; i <= num3; i++)
                    {
                        BmsStructs.PtHeaderDataType ptHeaderDataType = default(BmsStructs.PtHeaderDataType);
                        ptHeaderDataType.objID = BitConverter.ToInt16(array2, num);
                        num += 2;
                        ptHeaderDataType.type = array2[num];
                        num++;
                        ptHeaderDataType.count = array2[num];
                        num++;
                        Array.Resize<byte>(ref ptHeaderDataType.features, Constants.MAX_FEAT_DEPEND_LEGACY);
                        int num4 = ptHeaderDataType.features.Length - 1;
                        for (int j = 0; j <= num4; j++)
                        {
                            ptHeaderDataType.features[j] = array2[num];
                            num++;
                        }
                        num++;
                        ptHeaderDataType.data = (float)BitConverter.ToInt16(array2, num);
                        num += 2;
                        ptHeaderDataType.sinHeading = BitConverter.ToSingle(array2, num);
                        num += 4;
                        ptHeaderDataType.cosHeading = BitConverter.ToSingle(array2, num);
                        num += 4;
                        ptHeaderDataType.first = (int)BitConverter.ToInt16(array2, num);
                        num += 2;
                        ptHeaderDataType.texIdx = BitConverter.ToInt16(array2, num);
                        num += 2;
                        ptHeaderDataType.runwayNum = array2[num];
                        num++;
                        ptHeaderDataType.ltrt = (sbyte)Math.Min(127, (int)array2[num]);
                        num++;
                        ptHeaderDataType.nextHeader = BitConverter.ToInt16(array2, num);
                        num += 2;
                        array.Add(ptHeaderDataType);
                    }
                }
                return array;
            }
        }

        // Token: 0x060000F1 RID: 241 RVA: 0x0001E74C File Offset: 0x0001C94C
        public byte[] WriteFalconPHD(BmsStructs.PtHeaderDataType[] PHD)
        {
            byte[] array = new byte[1];
            int num = 0;
            Array bytes = BitConverter.GetBytes(PHD.Length);
            Array.Resize<byte>(ref array, 2);
            Array.Copy(bytes, 0, array, num, 2);
            checked
            {
                num += 2;
                int num2 = PHD.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    byte[] array2 = this.WritePHD(PHD[i]);
                    Array.Resize<byte>(ref array, array.Length + array2.Length);
                    Array.Copy(array2, 0, array, num, array2.Length);
                    num += array2.Length;
                }
                return array;
            }
        }

        // Token: 0x060000F2 RID: 242 RVA: 0x0001E7CC File Offset: 0x0001C9CC
        public byte[] WritePHD(BmsStructs.PtHeaderDataType PHD)
        {
            byte[] array = new byte[1];
            int num = 0;
            
            Array bytes = BitConverter.GetBytes(PHD.objID);
            Array.Resize<byte>(ref array, 2);
            Array.Copy(bytes, 0, array, num, 2);
            checked
            {
                num += 2;
                Array.Resize<byte>(ref array, array.Length + 1);
                array[num] = PHD.type;
                num++;
                Array.Resize<byte>(ref array, array.Length + 1);
                array[num] = PHD.count;
                num++;
                int num2 = PHD.features.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(PHD.features[i]);
                    num++;
                }
                Array.Resize<byte>(ref array, array.Length + 1);
                num++;
                Array bytes2 = BitConverter.GetBytes(PHD.data);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes2, 0, array, num, 2);
                num += 2;
                Array bytes3 = BitConverter.GetBytes(PHD.sinHeading);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes3, 0, array, num, 4);
                num += 4;
                Array bytes4 = BitConverter.GetBytes(PHD.cosHeading);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes4, 0, array, num, 4);
                num += 4;
                Array bytes5 = BitConverter.GetBytes(PHD.first);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes5, 0, array, num, 2);
                num += 2;
                Array bytes6 = BitConverter.GetBytes(PHD.texIdx);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes6, 0, array, num, 2);
                num += 2;
                Array.Resize<byte>(ref array, array.Length + 1);
                array[num] = PHD.runwayNum;
                num++;
                Array.Resize<byte>(ref array, array.Length + 1);
                if (PHD.ltrt >= 0)
                {
                    array[num] = (byte)PHD.ltrt;
                }
                else
                {
                    array[num] = 2;
                }
                num++;
                Array bytes7 = BitConverter.GetBytes(PHD.nextHeader);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes7, 0, array, num, 2);
                num += 2;
                return array;
            }
        }

        // Token: 0x060000F3 RID: 243 RVA: 0x0001E9C8 File Offset: 0x0001CBC8
        public List<BmsStructs.PtHeaderDataType> ReadXmlPHD(string PtHeaderTableFilePath)
        {
            checked
            {
                List<BmsStructs.PtHeaderDataType> array = new List<BmsStructs.PtHeaderDataType>();
                if (!File.Exists(PtHeaderTableFilePath))
                {
                }
                else
                {
                    BmsStructs.PtHeaderDataType el = null;
                    
                    using (XmlReader xmlReader = XmlReader.Create(PtHeaderTableFilePath))
                    {
                        int num = 0;
                        while (xmlReader.Read())
                        {
                            
                            if (xmlReader.IsStartElement() && Operators.CompareString(xmlReader.Name, "PHDRecords", false) != 0 && Operators.CompareString(xmlReader.Name, "PHD", false) == 0)
                            {
                                string text = xmlReader["Num"];
                                num++;
                                if (el != null)
                                    array.Add(el);
                                el = new BmsStructs.PtHeaderDataType();
                                el.features = new byte[Constants.MAX_FEAT_DEPEND];
                                int num2 = Constants.MAX_FEAT_DEPEND - 1;
                                for (int i = 0; i <= num2; i++)
                                {
                                    el.features[i] = byte.MaxValue;
                                }
                            }
                            if (xmlReader.NodeType == XmlNodeType.Element)
                            {
                                string name = xmlReader.Name;
                                xmlReader.Read();
                                string text2 = ((string.IsNullOrEmpty(xmlReader.Value) || xmlReader.Value.Contains(Environment.NewLine)) ? "" : xmlReader.Value);
                                if (Operators.CompareString(name, "ObjIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    el.objID = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "Type", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    el.type = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "FeaturesDependencieCount", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    el.count = Conversions.ToByte(text2);
                                }
                                int num3 = Constants.MAX_FEAT_DEPEND - 1;
                                for (int j = 0; j <= num3; j++)
                                {
                                    if (Operators.CompareString(name, "FeaturesDependencieIdx_" + Conversions.ToString(j), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        el.features[j] = Conversions.ToByte(text2);
                                    }
                                }
                                if (Operators.CompareString(name, "PointCount", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    el.count = Conversions.ToByte(text2);
                                }
                                int num4 = Constants.MAX_FEAT_DEPEND - 1;
                                for (int k = 0; k <= num4; k++)
                                {
                                    if (Operators.CompareString(name, "FeatureDependencyIdx_" + Conversions.ToString(k), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        el.features[k] = Conversions.ToByte(text2);
                                    }
                                }
                                if (Operators.CompareString(name, "Data", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    el.data = Conversions.ToSingle(text2);
                                }
                                if (Operators.CompareString(name, "SinHeading", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    el.sinHeading = Conversions.ToSingle(text2);
                                }
                                if (Operators.CompareString(name, "CosHeading", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    el.cosHeading = Conversions.ToSingle(text2);
                                }
                                if (Operators.CompareString(name, "FirstPtIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    el.first = Conversions.ToInteger(text2);
                                }
                                if (Operators.CompareString(name, "RunwayTexture", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    el.texIdx = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "RunwayNumber", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    if (Operators.CompareString(text2, "-1", false) == 0)
                                    {
                                        el.runwayNum = byte.MaxValue;
                                    }
                                    else
                                    {
                                        el.runwayNum = Conversions.ToByte(text2);
                                    }
                                }
                                if (Operators.CompareString(name, "LandingPattern", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    if (Operators.CompareString(text2, "-1", false) == 0)
                                    {
                                        el.ltrt = Conversions.ToSByte(text2);
                                    }
                                    else
                                    {
                                        el.ltrt = Conversions.ToSByte(text2);
                                    }
                                }
                                if (Operators.CompareString(name, "NextHeaderIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    el.nextHeader = Conversions.ToShort(text2);
                                }
                            }
                        }
                    }
                    
                    
                }
                return array;
            }
        }

        // Token: 0x060000F4 RID: 244 RVA: 0x0001EE48 File Offset: 0x0001D048
        public bool WriteXmlPHD(BmsStructs.PtHeaderDataType[] PtHeaderDataEntries, string fName)
        {
            checked
            {
                bool flag;
                if (PtHeaderDataEntries == null)
                {
                    flag = false;
                }
                else
                {
                    string text = Path.GetDirectoryName(fName) + "\\" + Path.GetFileNameWithoutExtension(fName) + "_Temp.xml";
                    if (!File.Exists(text))
                    {
                        XmlWriter xmlWriter = XmlWriter.Create(text, new XmlWriterSettings
                        {
                            Indent = true,
                            IndentChars = "    "
                        });
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("PHDRecords");
                        int num = PtHeaderDataEntries.Length - 1;
                        for (int i = 0; i <= num; i++)
                        {
                            new CultureInfo("en-US", false).NumberFormat.NumberDecimalDigits = 9;
                            xmlWriter.WriteStartElement("PHD");
                            xmlWriter.WriteAttributeString("Num", Conversions.ToString(i));
                            xmlWriter.WriteElementString("ObjIdx", PtHeaderDataEntries[i].objID.ToString());
                            xmlWriter.WriteElementString("Type", PtHeaderDataEntries[i].type.ToString());
                            xmlWriter.WriteElementString("PointCount", PtHeaderDataEntries[i].count.ToString());
                            int num2 = Constants.MAX_FEAT_DEPEND - 1;
                            for (int j = 0; j <= num2; j++)
                            {
                                if (j <= PtHeaderDataEntries[i].features.Length - 1 && PtHeaderDataEntries[i].features[j] != 255)
                                {
                                    xmlWriter.WriteElementString("FeatureDependencyIdx_" + Conversions.ToString(j), PtHeaderDataEntries[i].features[j].ToString());
                                }
                            }
                            xmlWriter.WriteElementString("Data", PtHeaderDataEntries[i].data.ToString());
                            xmlWriter.WriteElementString("FirstPtIdx", PtHeaderDataEntries[i].first.ToString());
                            xmlWriter.WriteElementString("RunwayTexture", PtHeaderDataEntries[i].texIdx.ToString());
                            if (PtHeaderDataEntries[i].runwayNum == 255)
                            {
                                xmlWriter.WriteElementString("RunwayNumber", "-1");
                            }
                            else
                            {
                                xmlWriter.WriteElementString("RunwayNumber", PtHeaderDataEntries[i].runwayNum.ToString());
                            }
                            if (Conversions.ToDouble(PtHeaderDataEntries[i].ltrt.ToString()) == 255.0)
                            {
                                xmlWriter.WriteElementString("LandingPattern", "-1");
                            }
                            else
                            {
                                xmlWriter.WriteElementString("LandingPattern", PtHeaderDataEntries[i].ltrt.ToString());
                            }
                            xmlWriter.WriteElementString("NextHeaderIdx", PtHeaderDataEntries[i].nextHeader.ToString());
                            xmlWriter.WriteEndElement();
                        }
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Close();
                        using (StreamWriter streamWriter = File.AppendText(text))
                        {
                            streamWriter.WriteLine("");
                        }
                    }
                    if (File.Exists(fName))
                    {
                        File.Delete(fName);
                    }
                    File.Copy(text, fName);
                    if (File.Exists(text))
                    {
                        File.Delete(text);
                    }
                    flag = true;
                }
                return flag;
            }
        }

        // Token: 0x060000F5 RID: 245 RVA: 0x0001F150 File Offset: 0x0001D350
        public List<BmsStructs.PtHeaderDataType> ReadXmlSeparatePHD(string NewDirPath)
        {
            checked
            {
                List<BmsStructs.PtHeaderDataType> array = new List<BmsStructs.PtHeaderDataType>();
                if (!Directory.Exists(NewDirPath))
                {
                }
                else
                {
                    //BmsStructs.PtHeaderDataType[] array2 = new BmsStructs.PtHeaderDataType[0];
                    //DateTime now = DateTime.Now;
                    DirectoryInfo[] directories = new DirectoryInfo(NewDirPath).GetDirectories();
                    int num = directories.Length - 1;
                    int num2 = 0;
                    BmsStructs.PtHeaderDataType el = null;
                    for (int i = 0; i <= num; i++)
                    {
                        

                        string text = directories[i].Name.ToString();
                        text = text.Replace("OCD", "PHD");
                        string text2 = directories[i].FullName + "\\" + text + ".xml";
                        if (File.Exists(text2))
                        {
                            

                            using (XmlReader xmlReader = XmlReader.Create(text2))
                            {
                                while (xmlReader.Read())
                                {
                                    if (xmlReader.IsStartElement() && Operators.CompareString(xmlReader.Name, "PHDRecords", false) != 0 && Operators.CompareString(xmlReader.Name, "PHD", false) == 0)
                                    {
                                        string text3 = xmlReader["Num"];
                                        num2++;

                                        //Array.Resize<BmsStructs.PtHeaderDataType>(ref array2, num2);
                                        //Array.Resize<byte>(ref el.features, Constants.MAX_FEAT_DEPEND);

                                        if (el != null)
                                            array.Add(el);
                                        el = new BmsStructs.PtHeaderDataType();
                                        el.features = new byte[Constants.MAX_FEAT_DEPEND];
                                        for (int j = 0; j < Constants.MAX_FEAT_DEPEND; j++)
                                        {
                                            el.features[j] = byte.MaxValue;
                                        }

                                    }
                                    if (xmlReader.NodeType == XmlNodeType.Element)
                                    {
                                        string name = xmlReader.Name;
                                        xmlReader.Read();
                                        string text4 = ((string.IsNullOrEmpty(xmlReader.Value) || xmlReader.Value.Contains(Environment.NewLine)) ? "" : xmlReader.Value);
                                        if (Operators.CompareString(name, "ObjIdx", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.objID = Conversions.ToShort(text4);
                                        }
                                        if (Operators.CompareString(name, "Type", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.type = Conversions.ToByte(text4);
                                        }
                                        if (Operators.CompareString(name, "FeaturesDependencieCount", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.count = Conversions.ToByte(text4);
                                        }
                                        int num4 = Constants.MAX_FEAT_DEPEND - 1;
                                        for (int k = 0; k <= num4; k++)
                                        {
                                            if (Operators.CompareString(name, "FeaturesDependencieIdx_" + Conversions.ToString(k), false) == 0 && Versioned.IsNumeric(text4))
                                            {
                                                el.features[k] = Conversions.ToByte(text4);
                                            }
                                        }
                                        if (Operators.CompareString(name, "PointCount", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.count = Conversions.ToByte(text4);
                                        }
                                        int num5 = Constants.MAX_FEAT_DEPEND - 1;
                                        for (int l = 0; l <= num5; l++)
                                        {
                                            if (Operators.CompareString(name, "FeatureDependencyIdx_" + Conversions.ToString(l), false) == 0 && Versioned.IsNumeric(text4))
                                            {
                                                el.features[l] = Conversions.ToByte(text4);
                                            }
                                        }
                                        if (Operators.CompareString(name, "Data", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.data = Conversions.ToSingle(text4);
                                        }
                                        if (Operators.CompareString(name, "SinHeading", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.sinHeading = Conversions.ToSingle(text4);
                                        }
                                        if (Operators.CompareString(name, "CosHeading", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.cosHeading = Conversions.ToSingle(text4);
                                        }
                                        if (Operators.CompareString(name, "FirstPtIdx", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.first = Conversions.ToInteger(text4);
                                            el.nextHeader = (short)num2;
                                        }
                                        if (Operators.CompareString(name, "RunwayTexture", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.texIdx = Conversions.ToShort(text4);
                                        }
                                        if (Operators.CompareString(name, "RunwayNumber", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            if (Operators.CompareString(text4, "-1", false) == 0)
                                            {
                                                el.runwayNum = byte.MaxValue;
                                            }
                                            else
                                            {
                                                el.runwayNum = Conversions.ToByte(text4);
                                            }
                                        }
                                        if (Operators.CompareString(name, "LandingPattern", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            if (Operators.CompareString(text4, "-1", false) == 0)
                                            {
                                                el.ltrt = Conversions.ToSByte(text4);
                                            }
                                            else
                                            {
                                                el.ltrt = Conversions.ToSByte(text4);
                                            }
                                        }
                                        if (Operators.CompareString(name, "NextHeaderIdx", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.nextHeader = Conversions.ToShort(text4);
                                        }
                                    }
                                }
                            }

                        }
                        el.nextHeader = 0;
                    }
                    el.nextHeader = 0;
                    array.Add(el);

                }
                return array;
            }
        }

        // Token: 0x060000F6 RID: 246 RVA: 0x0001F678 File Offset: 0x0001D878
        public BmsStructs.ItemCountVec[] ReadXmlPhdItemCount(string NewDirPath)
        {
            checked
            {
                BmsStructs.ItemCountVec[] array;
                if (!Directory.Exists(NewDirPath))
                {
                    array = null;
                }
                else
                {
                    BmsStructs.ItemCountVec[] array2 = new BmsStructs.ItemCountVec[0];
                    DirectoryInfo[] directories = new DirectoryInfo(NewDirPath).GetDirectories();
                    Array.Resize<BmsStructs.ItemCountVec>(ref array2, directories.Length);
                    int num = directories.Length - 1;
                    int num2 = 0;
                    for (int i = 0; i <= num; i++)
                    {
                        string text = directories[i].Name.ToString();
                        text = text.Replace("OCD", "PHD");
                        string text2 = directories[i].FullName + "\\" + text + ".xml";
                        if (File.Exists(text2))
                        {
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.Load(text2);
                            int count = xmlDocument.SelectNodes("/PHDRecords/PHD").Count;
                            
                            array2[i].First = num2;
                            array2[i].Count = count;
                            num2 += count;
                        }
                    }
                    array = array2;
                }
                return array;
            }
        }

        
    }
}
