using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using System.Xml;

namespace BMSKneeboarder.Bms.Model
{
    public class ObjectTable
    {
        // Token: 0x060000DC RID: 220 RVA: 0x0001C616 File Offset: 0x0001A816
        public ObjectTable()
        {
        }

        // Token: 0x060000DD RID: 221 RVA: 0x0001C62C File Offset: 0x0001A82C
        public List<BmsStructs.ObjClassDataType> LoadOCD(string DefaultDir, string fName, ref bool ReadXml, int DataReadMode)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            string text = Path.GetDirectoryName(fName) + "\\ObjectiveRelatedData";
            List<BmsStructs.ObjClassDataType> array = new List<BmsStructs.ObjClassDataType>();
            if (ReadXml)
            {
                if (DataReadMode == 0)
                {
                    array = this.ReadXmlSeparateOCD(text);
                    if (array != null)
                    {
                        return array;
                    }
                }
                if (File.Exists(fName))
                {
                    array = this.ReadXmlOCD(fName);
                }
                else
                {
                    fName = Strings.LCase(fName);
                    fName = fName.Replace("falcon4_ocd.xml", "falcon4.ocd");
                    if (File.Exists(fName))
                    {
                        array = this.ReadObjectTable(fName);
                        ReadXml = false;
                    }
                    else
                    {
                        fName = DefaultDir + "falcon4_ocd.xml";
                        if (File.Exists(fName))
                        {
                            array = this.ReadXmlOCD(fName);
                        }
                        else
                        {
                            fName = Strings.LCase(fName);
                            fName = fName.Replace("falcon4_ocd.xml", "falcon4.ocd");
                            if (File.Exists(fName))
                            {
                                array = this.ReadObjectTable(fName);
                                ReadXml = false;
                            }
                        }
                    }
                }
            }
            else if (File.Exists(fName))
            {
                array = this.ReadObjectTable(fName);
            }
            else
            {
                fName = DefaultDir + "falcon4.ocd";
                if (File.Exists(fName))
                {
                    array = this.ReadObjectTable(fName);
                }
            }
            return array;
        }

        // Token: 0x060000DE RID: 222 RVA: 0x0001C75C File Offset: 0x0001A95C
        public bool SaveOCD(BmsStructs.ObjClassDataType[] ObjectDataEntries, string fName, ref bool ReadXml)
        {
            bool flag = false;
            bool flag2;
            if (Information.IsNothing(ObjectDataEntries))
            {
                flag2 = false;
            }
            else
            {
                if (ReadXml)
                {
                    flag = this.WriteXmlOCD(ObjectDataEntries, fName);
                }
                else
                {
                    byte[] array = new byte[1];
                    array = this.WriteFalconOCD(ObjectDataEntries);
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

        // Token: 0x060000DF RID: 223 RVA: 0x0001C7F0 File Offset: 0x0001A9F0
        public List<BmsStructs.ObjClassDataType> ReadObjectTable(string ObjectTableFilePath)
        {
            checked
            {
                List<BmsStructs.ObjClassDataType> array = new List<BmsStructs.ObjClassDataType>();
                if (!File.Exists(ObjectTableFilePath))
                {
                }
                else
                {
                    FileStream fileStream = new FileStream(ObjectTableFilePath, FileMode.Open, FileAccess.Read);
                    byte[] array2 = new byte[(int)fileStream.Length + 1];
                    fileStream.Read(array2, 0, (int)fileStream.Length);
                    fileStream.Close();
                    int num = 0;
                    short num2 = BitConverter.ToInt16(array2, num);
                    num += 2;
                    //BmsStructs.ObjClassDataType[] array3 = new BmsStructs.ObjClassDataType[(int)(num2 - 1 + 1)];
                    int num3 = (int)(num2 - 1);
                    for (int i = 0; i <= num3; i++)
                    {
                        BmsStructs.ObjClassDataType objClassDataType = new BmsStructs.ObjClassDataType();
                        objClassDataType.Index = BitConverter.ToInt16(array2, num);
                        num += 2;
                        Array.Resize<char>(ref objClassDataType.Name, 20);
                        objClassDataType.Name = Conversions.ToCharArrayRankOne(Encoding.Default.GetString(array2, num, 20));
                        num += 20;
                        objClassDataType.DataRate = BitConverter.ToInt16(array2, num);
                        num += 2;
                        objClassDataType.DeagDistance = BitConverter.ToInt16(array2, num);
                        num += 2;
                        objClassDataType.PtDataIndex = BitConverter.ToInt16(array2, num);
                        num += 2;
                        Array.Resize<byte>(ref objClassDataType.Detection, 8);
                        int num4 = 0;
                        do
                        {
                            objClassDataType.Detection[num4] = Buffer.GetByte(array2, num);
                            num++;
                            num4++;
                        }
                        while (num4 <= 7);
                        Array.Resize<byte>(ref objClassDataType.DamageMod, 12);
                        int num5 = 0;
                        do
                        {
                            objClassDataType.DamageMod[num5] = Buffer.GetByte(array2, num);
                            num++;
                            num5++;
                        }
                        while (num5 <= 11);
                        objClassDataType.IconIndex = BitConverter.ToInt16(array2, num);
                        num += 2;
                        objClassDataType.Features = array2[num];
                        num++;
                        objClassDataType.RadarFeature = array2[num];
                        num++;
                        objClassDataType.FirstFeature = (int)BitConverter.ToInt16(array2, num);
                        num += 2;
                        //array3[i] = objClassDataType;
                        array.Add(objClassDataType);
                    }
                }
                return array;
            }
        }

        // Token: 0x060000E0 RID: 224 RVA: 0x0001C99C File Offset: 0x0001AB9C
        public byte[] WriteFalconOCD(BmsStructs.ObjClassDataType[] OCD)
        {
            byte[] array = new byte[1];
            int num = 0;
            
            Array bytes = BitConverter.GetBytes(OCD.Length);
            Array.Resize<byte>(ref array, 2);
            Array.Copy(bytes, 0, array, num, 2);
            checked
            {
                num += 2;
                int num2 = OCD.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    byte[] array2 = this.WriteOCD(OCD[i]);
                    Array.Resize<byte>(ref array, array.Length + array2.Length);
                    Array.Copy(array2, 0, array, num, array2.Length);
                    num += array2.Length;
                }
                return array;
            }
        }

        // Token: 0x060000E1 RID: 225 RVA: 0x0001CA1C File Offset: 0x0001AC1C
        public byte[] WriteOCD(BmsStructs.ObjClassDataType OCD)
        {
            byte[] array = new byte[1];
            int num = 0;
            
            Array bytes = BitConverter.GetBytes(OCD.Index);
            Array.Resize<byte>(ref array, 2);
            Array.Copy(bytes, 0, array, num, 2);
            checked
            {
                num += 2;
                Array.Resize<char>(ref OCD.Name, 20);
                int num2 = 0;
                do
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(OCD.Name[num2]);
                    num++;
                    num2++;
                }
                while (num2 <= 19);
                Array bytes2 = BitConverter.GetBytes(OCD.DataRate);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes2, 0, array, num, 2);
                num += 2;
                Array bytes3 = BitConverter.GetBytes(OCD.DeagDistance);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes3, 0, array, num, 2);
                num += 2;
                Array bytes4 = BitConverter.GetBytes(OCD.PtDataIndex);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes4, 0, array, num, 2);
                num += 2;
                int num3 = OCD.Detection.Length - 1;
                for (int i = 0; i <= num3; i++)
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = OCD.Detection[i];
                    num++;
                }
                int num4 = OCD.DamageMod.Length - 1;
                for (int j = 0; j <= num4; j++)
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = OCD.DamageMod[j];
                    num++;
                }
                Array bytes5 = BitConverter.GetBytes(OCD.IconIndex);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes5, 0, array, num, 2);
                num += 2;
                Array.Resize<byte>(ref array, array.Length + 1);
                array[num] = OCD.Features;
                num++;
                Array.Resize<byte>(ref array, array.Length + 1);
                array[num] = OCD.RadarFeature;
                num++;
                Array bytes6 = BitConverter.GetBytes(OCD.FirstFeature);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes6, 0, array, num, 2);
                num += 2;
                return array;
            }
        }

        // Token: 0x060000E2 RID: 226 RVA: 0x0001CC14 File Offset: 0x0001AE14
        public List<BmsStructs.ObjClassDataType> ReadXmlOCD(string ObjectTableFilePath)
        {
            checked
            {
                List<BmsStructs.ObjClassDataType> array = new List<BmsStructs.ObjClassDataType>();
                if (!File.Exists(ObjectTableFilePath))
                {
                }
                else
                {
                    DateTime now = DateTime.Now;
                    using (XmlReader xmlReader = XmlReader.Create(ObjectTableFilePath))
                    {
                        while (xmlReader.Read())
                        {
                            int num = 0;
                            if (xmlReader.IsStartElement() && Operators.CompareString(xmlReader.Name, "OCDRecords", false) != 0 && Operators.CompareString(xmlReader.Name, "OCD", false) == 0)
                            {
                                string text = xmlReader["Num"];
                                num++;
                                BmsStructs.ObjClassDataType el = new BmsStructs.ObjClassDataType();
                                el.Detection = new byte[8];
                                el.DamageMod = new byte[12];
                                array.Add(el);
                            }
                            if (xmlReader.NodeType == XmlNodeType.Element)
                            {
                                string name = xmlReader.Name;
                                xmlReader.Read();
                                string text2 = ((string.IsNullOrEmpty(xmlReader.Value) || xmlReader.Value.Contains(Environment.NewLine)) ? "" : xmlReader.Value);
                                if (Operators.CompareString(name, "CtIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array[num - 1].Index = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "Name", false) == 0)
                                {
                                    string text3 = Strings.Trim(text2);
                                    if (text3.Length <= 20)
                                    {
                                        array[num - 1].Name = Conversions.ToCharArrayRankOne(text3);
                                    }
                                    else
                                    {
                                        array[num - 1].Name = Conversions.ToCharArrayRankOne(Strings.Mid(text3, 1, 20));
                                    }
                                }
                                if (Operators.CompareString(name, "DataRate", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array[num - 1].DataRate = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "DeaggDistance", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array[num - 1].DeagDistance = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "PtDataIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array[num - 1].PtDataIndex = Conversions.ToShort(text2);
                                }
                                int num2 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "Det_" + BmsUtils.MoveTypeText(num2), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array[num - 1].Detection[num2] = Conversions.ToByte(text2);
                                    }
                                    num2++;
                                }
                                while (num2 <= 7);
                                int num3 = 0;
                                do
                                {
                                    string text4;
                                    if (num3 == 0)
                                    {
                                        text4 = "None";
                                    }
                                    else
                                    {
                                        text4 = BmsUtils.DamageDataTypeText(num3);
                                        text4 = text4.Replace("Dam", "");
                                    }
                                    if (Operators.CompareString(name, "Dam_" + text4, false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array[num - 1].DamageMod[num3] = Conversions.ToByte(text2);
                                    }
                                    num3++;
                                }
                                while (num3 <= 10);
                                if (Operators.CompareString(name, "ObjectiveIcon", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array[num - 1].IconIndex = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "FeatureCount", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array[num - 1].Features = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "RadarFeature", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array[num - 1].RadarFeature = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "FirstFeature", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array[num - 1].FirstFeature = Conversions.ToInteger(text2);
                                }
                            }
                        }
                    }
                }
                return array;
            }
        }

        // Token: 0x060000E3 RID: 227 RVA: 0x0001CFC4 File Offset: 0x0001B1C4
        public bool WriteXmlOCD(BmsStructs.ObjClassDataType[] ObjectDataEntries, string fName)
        {
            checked
            {
                bool flag;
                if (ObjectDataEntries == null)
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
                        xmlWriter.WriteStartElement("OCDRecords");
                        int num = ObjectDataEntries.Length - 1;
                        for (int i = 0; i <= num; i++)
                        {
                            string text2 = new string(ObjectDataEntries[i].Name);
                            text2 = text2.Replace('\0', ' ');
                            text2 = Strings.Trim(text2);
                            if (Operators.CompareString(text2, null, false) == 0)
                            {
                                text2 = " ";
                            }
                            new CultureInfo("en-US", false).NumberFormat.NumberDecimalDigits = 9;
                            xmlWriter.WriteStartElement("OCD");
                            xmlWriter.WriteAttributeString("Num", Conversions.ToString(i));
                            xmlWriter.WriteElementString("CtIdx", ObjectDataEntries[i].Index.ToString());
                            xmlWriter.WriteElementString("Name", text2.ToString());
                            xmlWriter.WriteElementString("DataRate", ObjectDataEntries[i].DataRate.ToString());
                            xmlWriter.WriteElementString("DeaggDistance", ObjectDataEntries[i].DeagDistance.ToString());
                            xmlWriter.WriteElementString("PtDataIdx", ObjectDataEntries[i].PtDataIndex.ToString());
                            int num2 = 0;
                            do
                            {
                                xmlWriter.WriteElementString("Det_" + BmsUtils.MoveTypeText(num2), ObjectDataEntries[i].Detection[num2].ToString());
                                num2++;
                            }
                            while (num2 <= 7);
                            int num3 = 0;
                            do
                            {
                                string text3;
                                if (num3 == 0)
                                {
                                    text3 = "None";
                                }
                                else
                                {
                                    text3 = BmsUtils.DamageDataTypeText(num3).Replace("Dam", "").ToString();
                                }
                                xmlWriter.WriteElementString("Dam_" + text3, ObjectDataEntries[i].DamageMod[num3].ToString());
                                num3++;
                            }
                            while (num3 <= 10);
                            xmlWriter.WriteElementString("ObjectiveIcon", ObjectDataEntries[i].IconIndex.ToString());
                            xmlWriter.WriteElementString("FeatureCount", ObjectDataEntries[i].Features.ToString());
                            xmlWriter.WriteElementString("RadarFeature", ObjectDataEntries[i].RadarFeature.ToString());
                            xmlWriter.WriteElementString("FirstFeature", ObjectDataEntries[i].FirstFeature.ToString());
                            xmlWriter.WriteEndElement();
                        }
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Close();
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

        // Token: 0x060000E4 RID: 228 RVA: 0x0001D2B8 File Offset: 0x0001B4B8
        public List<BmsStructs.ObjClassDataType> ReadXmlSeparateOCD(string NewDirPath)
        {
            checked
            {
                List<BmsStructs.ObjClassDataType> array = new List<BmsStructs.ObjClassDataType>();
                if (!Directory.Exists(NewDirPath))
                {
                }
                else
                {
                    //BmsStructs.ObjClassDataType[] array2 = new BmsStructs.ObjClassDataType[0];
                    DirectoryInfo[] directories = new DirectoryInfo(NewDirPath).GetDirectories();
                    for (int i = 0; i < directories.Length; i++)
                    {
                        string text = directories[i].Name.ToString();
                        string text2 = directories[i].FullName + "\\" + text + ".xml";
                        if (File.Exists(text2))
                        {
                            int num2 = 0;
                            BmsStructs.ObjClassDataType el = null;
                            using (XmlReader xmlReader = XmlReader.Create(text2))
                            {
                                
                                while (xmlReader.Read())
                                {
                                    
                                    if (xmlReader.IsStartElement() && Operators.CompareString(xmlReader.Name, "OCDRecords", false) != 0 && Operators.CompareString(xmlReader.Name, "OCD", false) == 0)
                                    {
                                        string text3 = xmlReader["Num"];
                                        num2++;
                                            
                                        el = new BmsStructs.ObjClassDataType();
                                        el.Detection = new byte[8];
                                        el.DamageMod = new byte[12];
                                    }
                                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name != "OCDRecords")
                                    {
                                        string name = xmlReader.Name;
                                        xmlReader.Read();
                                        string text4 = ((string.IsNullOrEmpty(xmlReader.Value) || xmlReader.Value.Contains(Environment.NewLine)) ? "" : xmlReader.Value);
                                        if (Operators.CompareString(name, "CtIdx", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.Index = Conversions.ToShort(text4);
                                        }
                                        if (Operators.CompareString(name, "Name", false) == 0)
                                        {
                                            string text5 = Strings.Trim(text4);
                                            if (text5.Length <= 20)
                                            {
                                                el.Name = Conversions.ToCharArrayRankOne(text5);
                                            }
                                            else
                                            {
                                                el.Name = Conversions.ToCharArrayRankOne(Strings.Mid(text5, 1, 20));
                                            }
                                        }
                                        if (Operators.CompareString(name, "DataRate", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.DataRate = Conversions.ToShort(text4);
                                        }
                                        if (Operators.CompareString(name, "DeaggDistance", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.DeagDistance = Conversions.ToShort(text4);
                                        }
                                        if (Operators.CompareString(name, "PtDataIdx", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.PtDataIndex = Conversions.ToShort(text4);
                                        }
                                        int num3 = 0;
                                        do
                                        {
                                            if (Operators.CompareString(name, "Det_" + BmsUtils.MoveTypeText(num3), false) == 0 && Versioned.IsNumeric(text4))
                                            {
                                                el.Detection[num3] = Conversions.ToByte(text4);
                                            }
                                            num3++;
                                        }
                                        while (num3 <= 7);
                                        int num4 = 0;
                                        do
                                        {
                                            string text6;
                                            if (num4 == 0)
                                            {
                                                text6 = "None";
                                            }
                                            else
                                            {
                                                text6 = BmsUtils.DamageDataTypeText(num4);
                                                text6 = text6.Replace("Dam", "");
                                            }
                                            if (Operators.CompareString(name, "Dam_" + text6, false) == 0 && Versioned.IsNumeric(text4))
                                            {
                                                el.DamageMod[num4] = Conversions.ToByte(text4);
                                            }
                                            num4++;
                                        }
                                        while (num4 <= 10);
                                        if (Operators.CompareString(name, "ObjectiveIcon", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.IconIndex = Conversions.ToShort(text4);
                                        }
                                        if (Operators.CompareString(name, "FeatureCount", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.Features = Conversions.ToByte(text4);
                                        }
                                        if (Operators.CompareString(name, "RadarFeature", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.RadarFeature = Conversions.ToByte(text4);
                                        }
                                        if (Operators.CompareString(name, "FirstFeature", false) == 0 && Versioned.IsNumeric(text4))
                                        {
                                            el.FirstFeature = Conversions.ToInteger(text4);
                                        }
                                    }
                                }
                            }
                            array.Add(el);
                        }
                    }
                }
                return array;
            }
        }

    }
}
