using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace BMSKneeboarder.Bms.Model
{
    public class FeatureEntryDataTable
    {
        // Token: 0x060000B7 RID: 183 RVA: 0x00019580 File Offset: 0x00017780
        public BmsStructs.FeatureEntry[] LoadFED(string DefaultDir, string fName, ref bool ReadXml, int DataReadMode)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            string text = Path.GetDirectoryName(fName) + "\\ObjectiveRelatedData";
            BmsStructs.FeatureEntry[] array = null;
            if (ReadXml)
            {
                if (DataReadMode == 0)
                {
                    array = this.ReadXmlSeparateFED(text);
                    if (array != null)
                    {
                        return array;
                    }
                }
                if (File.Exists(fName))
                {
                    array = this.ReadXmlFED_DOM(fName);
                }
                else
                {
                    fName = Strings.LCase(fName);
                    fName = fName.Replace("falcon4_fed.xml", "falcon4.fed");
                    if (File.Exists(fName))
                    {
                        array = this.ReadFeatureEntryDataTable(fName);
                        ReadXml = false;
                    }
                    else
                    {
                        fName = DefaultDir + "falcon4_fed.xml";
                        if (File.Exists(fName))
                        {
                            array = this.ReadXmlFED_DOM(fName);
                        }
                        else
                        {
                            fName = Strings.LCase(fName);
                            fName = fName.Replace("falcon4_fed.xml", "falcon4.fed");
                            if (File.Exists(fName))
                            {
                                array = this.ReadFeatureEntryDataTable(fName);
                                ReadXml = false;
                            }
                        }
                    }
                }
            }
            else
            {
                if (File.Exists(fName))
                {
                    try
                    {
                        array = this.ReadFeatureEntryDataTable(fName);
                        goto IL_012F;
                    }
                    catch (Exception ex)
                    {
                        goto IL_012F;
                    }
                }
                fName = DefaultDir + "falcon4.fed";
                if (File.Exists(fName))
                {
                    array = this.ReadFeatureEntryDataTable(fName);
                }
            }
        IL_012F:
            array = array;
            return array;
        }

        // Token: 0x060000B8 RID: 184 RVA: 0x000196D0 File Offset: 0x000178D0
        public bool SaveFED(BmsStructs.FeatureEntry[] FeatureEntryDataTable, string fName, ref bool ReadXml)
        {
            bool flag = false;
            bool flag2;
            if (Information.IsNothing(FeatureEntryDataTable))
            {
                flag2 = false;
            }
            else
            {
                if (ReadXml)
                {
                    flag = this.WriteXmlFED(FeatureEntryDataTable, fName);
                }
                else
                {
                    byte[] array = new byte[1];
                    array = this.WriteFalconFED(FeatureEntryDataTable);
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

        // Token: 0x060000B9 RID: 185 RVA: 0x00019764 File Offset: 0x00017964
        public BmsStructs.FeatureEntry CopyFeatureEntry(ref BmsStructs.FeatureEntry src)
        {
            BmsStructs.FeatureEntry featureEntry;
            featureEntry.eClass = new byte[checked(src.eClass.Count<byte>() - 1 + 1)];
            Array.Copy(src.eClass, featureEntry.eClass, src.eClass.Length);
            featureEntry.Facing = src.Facing;
            featureEntry.Flags = src.Flags;
            featureEntry.Index = src.Index;
            featureEntry.Offset.x = src.Offset.x;
            featureEntry.Offset.y = src.Offset.y;
            featureEntry.Offset.z = src.Offset.z;
            featureEntry.unk1 = src.unk1;
            featureEntry.unk2 = src.unk2;
            featureEntry.Value = src.Value;
            featureEntry.Value2 = src.Value2;
            return featureEntry;
        }

        // Token: 0x060000BA RID: 186 RVA: 0x00019848 File Offset: 0x00017A48
        public BmsStructs.FeatureEntry[] ReadFeatureEntryDataTable(string DatabaseFile)
        {
            checked
            {
                BmsStructs.FeatureEntry[] array;
                if (!File.Exists(DatabaseFile))
                {
                    array = null;
                }
                else
                {
                    FileStream fileStream = new FileStream(DatabaseFile, FileMode.Open, FileAccess.Read);
                    byte[] array2 = new byte[(int)fileStream.Length + 1];
                    fileStream.Read(array2, 0, (int)fileStream.Length);
                    fileStream.Close();
                    int num = 0;
                    short num2 = BitConverter.ToInt16(array2, num);
                    num += 2;
                    BmsStructs.FeatureEntry[] array3 = new BmsStructs.FeatureEntry[(int)(num2 - 1 + 1)];
                    int num3 = (int)(num2 - 1);
                    for (int i = 0; i <= num3; i++)
                    {
                        BmsStructs.FeatureEntry featureEntry = default(BmsStructs.FeatureEntry);
                        featureEntry.Index = BitConverter.ToInt16(array2, num);
                        num += 2;
                        featureEntry.Flags = BitConverter.ToUInt16(array2, num);
                        num += 2;
                        Array.Resize<byte>(ref featureEntry.eClass, 8);
                        int num4 = featureEntry.eClass.Length - 1;
                        for (int j = 0; j <= num4; j++)
                        {
                            featureEntry.eClass[j] = array2[num];
                            num++;
                        }
                        featureEntry.Value = array2[num];
                        num++;
                        featureEntry.Value2 = array2[num];
                        num++;
                        featureEntry.unk1 = BitConverter.ToInt16(array2, num);
                        num += 2;
                        featureEntry.Offset = default(BmsStructs.vector);
                        featureEntry.Offset.x = BitConverter.ToSingle(array2, num);
                        num += 4;
                        featureEntry.Offset.y = BitConverter.ToSingle(array2, num);
                        num += 4;
                        featureEntry.Offset.z = BitConverter.ToSingle(array2, num);
                        num += 4;
                        featureEntry.Facing = (float)BitConverter.ToInt16(array2, num);
                        num += 2;
                        featureEntry.unk2 = BitConverter.ToInt16(array2, num);
                        num += 2;
                        array3[i] = featureEntry;
                    }
                    array = array3;
                }
                return array;
            }
        }

        // Token: 0x060000BB RID: 187 RVA: 0x000199E4 File Offset: 0x00017BE4
        public byte[] WriteFalconFED(BmsStructs.FeatureEntry[] FED)
        {
            byte[] array = new byte[1];
            int num = 0;
            
            Array bytes = BitConverter.GetBytes(FED.Length);
            Array.Resize<byte>(ref array, 2);
            Array.Copy(bytes, 0, array, num, 2);
            checked
            {
                num += 2;
                int num2 = FED.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    byte[] array2 = this.WriteFED(FED[i]);
                    Array.Resize<byte>(ref array, array.Length + array2.Length);
                    Array.Copy(array2, 0, array, num, array2.Length);
                    num += array2.Length;
                }
                return array;
            }
        }

        // Token: 0x060000BC RID: 188 RVA: 0x00019A64 File Offset: 0x00017C64
        public byte[] WriteFED(BmsStructs.FeatureEntry FED)
        {
            byte[] array = new byte[1];
            int num = 0;
            
            Array bytes = BitConverter.GetBytes(FED.Index);
            Array.Resize<byte>(ref array, 2);
            Array.Copy(bytes, 0, array, num, 2);
            checked
            {
                num += 2;
                Array bytes2 = BitConverter.GetBytes(FED.Flags);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes2, 0, array, num, 2);
                num += 2;
                int num2 = 0;
                do
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = FED.eClass[num2];
                    num++;
                    num2++;
                }
                while (num2 <= 7);
                Array.Resize<byte>(ref array, array.Length + 1);
                array[num] = Convert.ToByte(FED.Value);
                num++;
                Array.Resize<byte>(ref array, array.Length + 1);
                array[num] = Convert.ToByte(FED.Value2);
                num++;
                Array bytes3 = BitConverter.GetBytes(FED.unk1);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes3, 0, array, num, 2);
                num += 2;
                Array bytes4 = BitConverter.GetBytes(FED.Offset.x);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes4, 0, array, num, 4);
                num += 4;
                Array bytes5 = BitConverter.GetBytes(FED.Offset.y);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes5, 0, array, num, 4);
                num += 4;
                Array bytes6 = BitConverter.GetBytes(FED.Offset.z);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes6, 0, array, num, 4);
                num += 4;
                Array bytes7 = BitConverter.GetBytes((int)Math.Round((double)FED.Facing));
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes7, 0, array, num, 2);
                num += 2;
                Array bytes8 = BitConverter.GetBytes(FED.unk2);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes8, 0, array, num, 2);
                num += 2;
                return array;
            }
        }

        // Token: 0x060000BD RID: 189 RVA: 0x00019C48 File Offset: 0x00017E48
        public BmsStructs.FeatureEntry[] ReadXmlFED_DOM(string fName)
        {
            checked
            {
                BmsStructs.FeatureEntry[] array;
                if (!File.Exists(fName))
                {
                    array = null;
                }
                else
                {
                    BmsStructs.FeatureEntry[] array2 = new BmsStructs.FeatureEntry[0];
                    XmlDocument xmlDocument = new XmlDocument();
                    DateTime now = DateTime.Now;
                    xmlDocument.Load(fName);
                    XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/FEDRecords/FED");
                    int count = xmlNodeList.Count;
                    Array.Resize<BmsStructs.FeatureEntry>(ref array2, count);
                    int num = array2.Length - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        Array.Resize<byte>(ref array2[i].eClass, 8);
                    }
                    try
                    {
                        foreach (object obj in xmlNodeList)
                        {
                            XmlNode xmlNode = (XmlNode)obj;
                            string value = xmlNode.Attributes.GetNamedItem("Num").Value;
                            int num2 = xmlNode.ChildNodes.Count - 1;
                            int j = 0;
                            while (j <= num2)
                            {
                                string text;
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "FeatureCtIdx", false) == 0)
                                {
                                    text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].Index = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Flags", false) == 0)
                                {
                                    text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].Flags = Conversions.ToUShort(text);
                                    }
                                }
                                int num3 = 0;
                                do
                                {
                                    if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "EntityClass_" + Conversions.ToString(num3), false) == 0)
                                    {
                                        text = xmlNode.ChildNodes.Item(j).InnerText;
                                        if (Versioned.IsNumeric(text))
                                        {
                                            goto Block_9;
                                        }
                                    }
                                    num3++;
                                }
                                while (num3 <= 8);
                            IL_01D8:
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Value", false) == 0)
                                {
                                    text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].Value = Conversions.ToByte(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "OffsetX", false) == 0)
                                {
                                    text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].Offset.x = Conversions.ToSingle(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "OffsetY", false) == 0)
                                {
                                    text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].Offset.y = Conversions.ToSingle(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "OffsetZ", false) == 0)
                                {
                                    text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].Offset.z = Conversions.ToSingle(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Heading", false) == 0)
                                {
                                    text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].Facing = Conversions.ToSingle(text);
                                    }
                                }
                                j++;
                                continue;
                            Block_9:
                                array2[Conversions.ToInteger(value)].eClass[num3] = Conversions.ToByte(text);
                                goto IL_01D8;
                            }
                        }
                    }
                    finally
                    {
                        
                    }
                    
                    array = array2;
                }
                return array;
            }
        }

        // Token: 0x060000BE RID: 190 RVA: 0x0001A040 File Offset: 0x00018240
        public BmsStructs.FeatureEntry[] ReadXmlFED(string fName)
        {
            checked
            {
                BmsStructs.FeatureEntry[] array;
                if (!File.Exists(fName))
                {
                    array = null;
                }
                else
                {
                    BmsStructs.FeatureEntry[] array2 = new BmsStructs.FeatureEntry[0];
                    DateTime now = DateTime.Now;
                    using (XmlReader xmlReader = XmlReader.Create(fName))
                    {
                        while (xmlReader.Read())
                        {
                            int num = 0;
                            if (xmlReader.IsStartElement() && Operators.CompareString(xmlReader.Name, "FEDRecords", false) != 0 && Operators.CompareString(xmlReader.Name, "FED", false) == 0)
                            {
                                string text = xmlReader["Num"];
                                num++;
                                Array.Resize<BmsStructs.FeatureEntry>(ref array2, num);
                                Array.Resize<byte>(ref array2[num - 1].eClass, 8);
                            }
                            if (xmlReader.NodeType == XmlNodeType.Element)
                            {
                                string name = xmlReader.Name;
                                xmlReader.Read();
                                string text2 = ((string.IsNullOrEmpty(xmlReader.Value) || xmlReader.Value.Contains(Environment.NewLine)) ? "" : xmlReader.Value);
                                if (Operators.CompareString(name, "FeatureCtIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].Index = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "Flags", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].Flags = Conversions.ToUShort(text2);
                                }
                                int num2 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "EntityClass_" + Conversions.ToString(num2), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].eClass[num2] = Conversions.ToByte(text2);
                                    }
                                    num2++;
                                }
                                while (num2 <= 7);
                                if (Operators.CompareString(name, "Value", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].Value = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "OffsetX", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].Offset.x = Conversions.ToSingle(text2);
                                }
                                if (Operators.CompareString(name, "OffsetY", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].Offset.y = Conversions.ToSingle(text2);
                                }
                                if (Operators.CompareString(name, "OffsetZ", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].Offset.z = Conversions.ToSingle(text2);
                                }
                                if (Operators.CompareString(name, "Heading", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].Facing = Conversions.ToSingle(text2);
                                }
                            }
                        }
                    }
                    
                    array = array2;
                }
                return array;
            }
        }

        // Token: 0x060000BF RID: 191 RVA: 0x0001A2F0 File Offset: 0x000184F0
        public bool WriteXmlFED(BmsStructs.FeatureEntry[] FeatureEntryDataTable, string fName)
        {
            checked
            {
                bool flag;
                if (FeatureEntryDataTable == null)
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
                        xmlWriter.WriteStartElement("FEDRecords");
                        NumberFormatInfo numberFormat = new CultureInfo("en-US", false).NumberFormat;
                        int num = FeatureEntryDataTable.Length - 1;
                        for (int i = 0; i <= num; i++)
                        {
                            xmlWriter.WriteStartElement("FED");
                            xmlWriter.WriteAttributeString("Num", Conversions.ToString(i));
                            xmlWriter.WriteElementString("FeatureCtIdx", FeatureEntryDataTable[i].Index.ToString());
                            if (FeatureEntryDataTable[i].Flags != 0)
                            {
                                xmlWriter.WriteElementString("Flags", FeatureEntryDataTable[i].Flags.ToString());
                            }
                            if (FeatureEntryDataTable[i].Value != 0)
                            {
                                xmlWriter.WriteElementString("Value", FeatureEntryDataTable[i].Value.ToString());
                            }
                            numberFormat.NumberDecimalDigits = 3;
                            double num2 = Math.Pow(10.0, (double)numberFormat.NumberDecimalDigits);
                            double num3 = (double)FeatureEntryDataTable[i].Offset.x;
                            unchecked
                            {
                                num3 *= num2;
                                num3 = Math.Round(num3, MidpointRounding.AwayFromZero);
                                xmlWriter.WriteElementString("OffsetX", (num3 / num2).ToString("F", numberFormat));
                                numberFormat.NumberDecimalDigits = 3;
                                num2 = Math.Pow(10.0, (double)numberFormat.NumberDecimalDigits);
                                num3 = (double)FeatureEntryDataTable[i].Offset.y;
                                num3 *= num2;
                                num3 = Math.Round(num3, MidpointRounding.AwayFromZero);
                                xmlWriter.WriteElementString("OffsetY", (num3 / num2).ToString("F", numberFormat));
                                numberFormat.NumberDecimalDigits = 3;
                                num2 = Math.Pow(10.0, (double)numberFormat.NumberDecimalDigits);
                                num3 = (double)FeatureEntryDataTable[i].Offset.z;
                                num3 *= num2;
                                num3 = Math.Round(num3, MidpointRounding.AwayFromZero);
                                xmlWriter.WriteElementString("OffsetZ", (num3 / num2).ToString("F", numberFormat));
                                numberFormat.NumberDecimalDigits = 1;
                                num3 = (double)FeatureEntryDataTable[i].Facing;
                                xmlWriter.WriteElementString("Heading", Math.Round(num3, MidpointRounding.AwayFromZero).ToString("F", numberFormat));
                                xmlWriter.WriteEndElement();
                            }
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

        // Token: 0x060000C0 RID: 192 RVA: 0x0001A5FC File Offset: 0x000187FC
        public BmsStructs.FeatureEntry[] ReadXmlSeparateFED(string NewDirPath)
        {
            checked
            {
                BmsStructs.FeatureEntry[] array;
                if (!Directory.Exists(NewDirPath))
                {
                    array = null;
                }
                else
                {
                    BmsStructs.FeatureEntry[] array2 = new BmsStructs.FeatureEntry[0];
                    DirectoryInfo[] directories = new DirectoryInfo(NewDirPath).GetDirectories();
                    DateTime now = DateTime.Now;
                    int num = directories.Length - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        string text = directories[i].Name.ToString();
                        text = text.Replace("OCD", "FED");
                        string text2 = directories[i].FullName + "\\" + text + ".xml";
                        if (File.Exists(text2))
                        {
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.Load(text2);
                            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/FEDRecords/FED");
                            int count = xmlNodeList.Count;
                            int num2 = array2.Length;
                            Array.Resize<BmsStructs.FeatureEntry>(ref array2, array2.Length + count);
                            int num3 = array2.Length - 1;
                            for (int j = 0; j <= num3; j++)
                            {
                                Array.Resize<byte>(ref array2[j].eClass, 8);
                            }
                            try
                            {
                                foreach (object obj in xmlNodeList)
                                {
                                    XmlNode xmlNode = (XmlNode)obj;
                                    int num4 = Conversions.ToInteger(xmlNode.Attributes.GetNamedItem("Num").Value);
                                    int num5 = num2 + num4;
                                    int num6 = xmlNode.ChildNodes.Count - 1;
                                    int k = 0;
                                    while (k <= num6)
                                    {
                                        string text3;
                                        if (Operators.CompareString(xmlNode.ChildNodes[k].Name, "FeatureCtIdx", false) == 0)
                                        {
                                            text3 = xmlNode.ChildNodes.Item(k).InnerText;
                                            if (Versioned.IsNumeric(text3))
                                            {
                                                array2[num5].Index = Conversions.ToShort(text3);
                                            }
                                        }
                                        if (Operators.CompareString(xmlNode.ChildNodes[k].Name, "Flags", false) == 0)
                                        {
                                            text3 = xmlNode.ChildNodes.Item(k).InnerText;
                                            if (Versioned.IsNumeric(text3))
                                            {
                                                array2[num5].Flags = Conversions.ToUShort(text3);
                                            }
                                        }
                                        int num7 = 0;
                                        do
                                        {
                                            if (Operators.CompareString(xmlNode.ChildNodes[k].Name, "EntityClass_" + Conversions.ToString(num7), false) == 0)
                                            {
                                                text3 = xmlNode.ChildNodes.Item(k).InnerText;
                                                if (Versioned.IsNumeric(text3))
                                                {
                                                    goto Block_11;
                                                }
                                            }
                                            num7++;
                                        }
                                        while (num7 <= 8);
                                    IL_0249:
                                        if (Operators.CompareString(xmlNode.ChildNodes[k].Name, "Value", false) == 0)
                                        {
                                            text3 = xmlNode.ChildNodes.Item(k).InnerText;
                                            if (Versioned.IsNumeric(text3))
                                            {
                                                array2[num5].Value = Conversions.ToByte(text3);
                                            }
                                        }
                                        if (Operators.CompareString(xmlNode.ChildNodes[k].Name, "OffsetX", false) == 0)
                                        {
                                            text3 = xmlNode.ChildNodes.Item(k).InnerText;
                                            if (Versioned.IsNumeric(text3))
                                            {
                                                array2[num5].Offset.x = Conversions.ToSingle(text3);
                                            }
                                        }
                                        if (Operators.CompareString(xmlNode.ChildNodes[k].Name, "OffsetY", false) == 0)
                                        {
                                            text3 = xmlNode.ChildNodes.Item(k).InnerText;
                                            if (Versioned.IsNumeric(text3))
                                            {
                                                array2[num5].Offset.y = Conversions.ToSingle(text3);
                                            }
                                        }
                                        if (Operators.CompareString(xmlNode.ChildNodes[k].Name, "OffsetZ", false) == 0)
                                        {
                                            text3 = xmlNode.ChildNodes.Item(k).InnerText;
                                            if (Versioned.IsNumeric(text3))
                                            {
                                                array2[num5].Offset.z = Conversions.ToSingle(text3);
                                            }
                                        }
                                        if (Operators.CompareString(xmlNode.ChildNodes[k].Name, "Heading", false) == 0)
                                        {
                                            text3 = xmlNode.ChildNodes.Item(k).InnerText;
                                            if (Versioned.IsNumeric(text3))
                                            {
                                                array2[num5].Facing = Conversions.ToSingle(text3);
                                            }
                                        }
                                        k++;
                                        continue;
                                    Block_11:
                                        array2[num5].eClass[num7] = Conversions.ToByte(text3);
                                        goto IL_0249;
                                    }
                                }
                            }
                            finally
                            {
                                
                            }
                        }
                    }
                    
                    array = array2;
                }
                return array;
            }
        }

        // Token: 0x060000C1 RID: 193 RVA: 0x0001AA5C File Offset: 0x00018C5C
        public BmsStructs.ItemCountVec[] ReadXmlFedItemCount(string NewDirPath)
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
                    BmsStructs.FeatureEntry[] array3 = new BmsStructs.FeatureEntry[0];
                    DirectoryInfo[] directories = new DirectoryInfo(NewDirPath).GetDirectories();
                    DateTime now = DateTime.Now;
                    Array.Resize<BmsStructs.ItemCountVec>(ref array2, directories.Length);
                    int num = directories.Length - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        string text = directories[i].Name.ToString();
                        text = text.Replace("OCD", "FED");
                        string text2 = directories[i].FullName + "\\" + text + ".xml";
                        if (File.Exists(text2))
                        {
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.Load(text2);
                            int count = xmlDocument.SelectNodes("/FEDRecords/FED").Count;
                            array2[i].First = array3.Length;
                            array2[i].Count = count;
                            Array.Resize<BmsStructs.FeatureEntry>(ref array3, array3.Length + count);
                        }
                    }
                    
                    array = array2;
                }
                return array;
            }
        }
    }
}
