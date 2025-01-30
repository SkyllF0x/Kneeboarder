using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic;
using System.Xml;

namespace BMSKneeboarder.Bms.Model
{
    public class UnitTable
    {
        // Token: 0x0600013F RID: 319 RVA: 0x000269B3 File Offset: 0x00024BB3
        public UnitTable()
        {
        }

        // Token: 0x06000140 RID: 320 RVA: 0x000269C8 File Offset: 0x00024BC8
        public BmsStructs.UnitClassDataType[] LoadUCD(string DefaultDir, string fName, ref bool ReadXml)
        {
            BmsStructs.UnitClassDataType[] array = null;
            if (ReadXml)
            {
                int num = 0;
                if (File.Exists(fName))
                {
                    try
                    {
                        array = this.ReadXmlUCD(fName, ref num);
                        goto IL_0125;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Concat(new string[]
                        {
                            "This file contains errors!!!\r\n\r\nPossible illegal charaters are used.\r\nCheck UCD: ",
                            Conversions.ToString(num),
                            "\r\n\r\n",
                            fName,
                            "\r\n\r\nTrying to load in an alternate slower way."
                        }), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        array = this.ReadXmlAsString(fName);
                        goto IL_0125;
                    }
                }
                fName = (fName.ToLower());
                fName = fName.Replace("falcon4_ucd.xml", "falcon4.ucd");
                if (File.Exists(fName))
                {
                    array = this.ReadUnitTable(fName);
                    ReadXml = false;
                }
                else
                {
                    fName = DefaultDir + "falcon4_ucd.xml";
                    if (File.Exists(fName))
                    {
                        array = this.ReadXmlUCD_DOM(fName, ref num);
                    }
                    else
                    {
                        fName = fName.ToLower();
                        fName = fName.Replace("falcon4_ucd.xml", "falcon4.ucd");
                        if (File.Exists(fName))
                        {
                            array = this.ReadUnitTable(fName);
                            ReadXml = false;
                        }
                    }
                }
            }
            else if (File.Exists(fName))
            {
                array = this.ReadUnitTable(fName);
            }
            else
            {
                fName = DefaultDir + "falcon4.ucd";
                if (File.Exists(fName))
                {
                    array = this.ReadUnitTable(fName);
                }
            }
        IL_0125:
            return array;
        }

        // Token: 0x06000141 RID: 321 RVA: 0x00026B10 File Offset: 0x00024D10
        public bool SaveUCD(BmsStructs.UnitClassDataType[] UnitDataEntries, string fName, ref bool ReadXml, int Minor, int Build)
        {
            bool flag = false;
            bool flag2;
            if (Information.IsNothing(UnitDataEntries))
            {
                flag2 = false;
            }
            else
            {
                if (ReadXml)
                {
                    flag = this.WriteXmlUCD(UnitDataEntries, fName, Minor, Build);
                }
                else
                {
                    byte[] array = new byte[1];
                    array = this.WriteFalconUCD(UnitDataEntries);
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

        // Token: 0x06000142 RID: 322 RVA: 0x00026BA8 File Offset: 0x00024DA8
        public BmsStructs.UnitClassDataType CopyUnitClassDataType(ref BmsStructs.UnitClassDataType src)
        {
            checked
            {
                BmsStructs.UnitClassDataType unitClassDataType;
                unitClassDataType.DamageMod = new byte[src.DamageMod.Count<byte>() - 1 + 1];
                Array.Copy(src.DamageMod, unitClassDataType.DamageMod, src.DamageMod.Length);
                unitClassDataType.Description = src.Description;
                unitClassDataType.Detection = new float[src.Detection.Count<float>() - 1 + 1];
                Array.Copy(src.Detection, unitClassDataType.Detection, src.Detection.Length);
                unitClassDataType.ElementFlags = new short[src.ElementFlags.Count<short>() - 1 + 1];
                Array.Copy(src.ElementFlags, unitClassDataType.ElementFlags, src.ElementFlags.Length);
                unitClassDataType.ElementName = new string[src.ElementName.Count<string>() - 1 + 1];
                Array.Copy(src.ElementName, unitClassDataType.ElementName, src.ElementName.Length);
                unitClassDataType.ElementTexSetIdx = new short[src.ElementTexSetIdx.Count<short>() - 1 + 1];
                Array.Copy(src.ElementTexSetIdx, unitClassDataType.ElementTexSetIdx, src.ElementTexSetIdx.Length);
                unitClassDataType.Flags = src.Flags;
                unitClassDataType.Fuel = src.Fuel;
                unitClassDataType.FuelRate = src.FuelRate;
                unitClassDataType.HitChance = new byte[src.HitChance.Count<byte>() - 1 + 1];
                Array.Copy(src.HitChance, unitClassDataType.HitChance, src.HitChance.Length);
                unitClassDataType.IconIndex = src.IconIndex;
                unitClassDataType.Index = src.Index;
                unitClassDataType.MaxRange = src.MaxRange;
                unitClassDataType.MovementSpeed = src.MovementSpeed;
                unitClassDataType.MoveType = src.MoveType;
                unitClassDataType.Name = new char[src.Name.Count<char>() - 1 + 1];
                Array.Copy(src.Name, unitClassDataType.Name, src.Name.Length);
                unitClassDataType.NumElements = new int[src.NumElements.Count<int>() - 1 + 1];
                Array.Copy(src.NumElements, unitClassDataType.NumElements, src.NumElements.Length);
                unitClassDataType.PtDataIndex = src.PtDataIndex;
                unitClassDataType.RadarVehicle = src.RadarVehicle;
                unitClassDataType.Range = new byte[src.Range.Count<byte>() - 1 + 1];
                Array.Copy(src.Range, unitClassDataType.Range, src.Range.Length);
                unitClassDataType.Role = src.Role;
                unitClassDataType.Scores = new byte[src.Scores.Count<byte>() - 1 + 1];
                Array.Copy(src.Scores, unitClassDataType.Scores, src.Scores.Length);
                unitClassDataType.SpecialIndex = src.SpecialIndex;
                unitClassDataType.Strength = new byte[src.Strength.Count<byte>() - 1 + 1];
                Array.Copy(src.Strength, unitClassDataType.Strength, src.Strength.Length);
                unitClassDataType.VehicleClass = new byte[Constants.VEHICLES_PER_UNIT + 1, 9];
                int num = Constants.VEHICLES_PER_UNIT - 1;
                for (int i = 0; i <= num; i++)
                {
                    int num2 = 0;
                    do
                    {
                        byte b = src.VehicleClass[i, num2];
                        unitClassDataType.VehicleClass[i, num2] = b;
                        num2++;
                    }
                    while (num2 <= 7);
                }
                unitClassDataType.VehicleType = new short[src.VehicleType.Count<short>() - 1 + 1];
                Array.Copy(src.VehicleType, unitClassDataType.VehicleType, src.VehicleType.Length);
                unitClassDataType.Description = src.Description;
                unitClassDataType.InServiceStart = src.InServiceStart;
                unitClassDataType.InServiceEnd = src.InServiceEnd;
                return unitClassDataType;
            }
        }

        // Token: 0x06000143 RID: 323 RVA: 0x00026F58 File Offset: 0x00025158
        public BmsStructs.UnitClassDataType[] ReadUnitTable(string UnitTableFilePath)
        {
            checked
            {
                BmsStructs.UnitClassDataType[] array;
                if (!File.Exists(UnitTableFilePath))
                {
                    array = null;
                }
                else
                {
                    FileStream fileStream = new FileStream(UnitTableFilePath, FileMode.Open, FileAccess.Read);
                    byte[] array2 = new byte[(int)fileStream.Length + 1];
                    fileStream.Read(array2, 0, (int)fileStream.Length);
                    fileStream.Close();
                    int num = 0;
                    short num2 = BitConverter.ToInt16(array2, num);
                    num += 2;
                    BmsStructs.UnitClassDataType[] array3 = new BmsStructs.UnitClassDataType[(int)(num2 - 1 + 1)];
                    int num3 = (int)(num2 - 1);
                    for (int i = 0; i <= num3; i++)
                    {
                        BmsStructs.UnitClassDataType unitClassDataType = default(BmsStructs.UnitClassDataType);
                        unitClassDataType.Index = BitConverter.ToInt16(array2, num);
                        num += 3;
                        Array.Resize<int>(ref unitClassDataType.NumElements, Constants.VEHICLES_PER_UNIT);
                        int num4 = Constants.VEHICLES_PER_UNIT - 1;
                        for (int j = 0; j <= num4; j++)
                        {
                            unitClassDataType.NumElements[j] = BitConverter.ToInt32(array2, num);
                            num += 4;
                        }
                        num++;
                        Array.Resize<short>(ref unitClassDataType.VehicleType, Constants.VEHICLES_PER_UNIT);
                        int num5 = Constants.VEHICLES_PER_UNIT - 1;
                        for (int k = 0; k <= num5; k++)
                        {
                            unitClassDataType.VehicleType[k] = BitConverter.ToInt16(array2, num);
                            num += 2;
                        }
                        unitClassDataType.VehicleClass = new byte[Constants.VEHICLES_PER_UNIT + 1, 9];
                        int num6 = Constants.VEHICLES_PER_UNIT - 1;
                        for (int l = 0; l <= num6; l++)
                        {
                            int num7 = 0;
                            do
                            {
                                unitClassDataType.VehicleClass[l, num7] = Buffer.GetByte(array2, num);
                                num++;
                                num7++;
                            }
                            while (num7 <= 7);
                        }
                        unitClassDataType.Flags = BitConverter.ToUInt16(array2, num);
                        num += 2;
                        Array.Resize<char>(ref unitClassDataType.Name, 20);
                        unitClassDataType.Name = Conversions.ToCharArrayRankOne(Encoding.Default.GetString(array2, num, 20));
                        num += 20;
                        num += 2;
                        unitClassDataType.MoveType = BitConverter.ToInt16(array2, num);
                        num += 4;
                        unitClassDataType.MovementSpeed = BitConverter.ToInt16(array2, num);
                        num += 2;
                        unitClassDataType.MaxRange = BitConverter.ToInt16(array2, num);
                        num += 2;
                        unitClassDataType.Fuel = unchecked((long)BitConverter.ToInt32(array2, num));
                        num += 4;
                        unitClassDataType.FuelRate = BitConverter.ToInt16(array2, num);
                        num += 2;
                        unitClassDataType.PtDataIndex = BitConverter.ToInt16(array2, num);
                        num += 2;
                        Array.Resize<byte>(ref unitClassDataType.Scores, Constants.MAXIMUM_ROLES);
                        int num8 = Constants.MAXIMUM_ROLES - 1;
                        for (int m = 0; m <= num8; m++)
                        {
                            unitClassDataType.Scores[m] = Buffer.GetByte(array2, num);
                            num++;
                        }
                        unitClassDataType.Role = Buffer.GetByte(array2, num);
                        num++;
                        Array.Resize<byte>(ref unitClassDataType.HitChance, 8);
                        int num9 = 0;
                        do
                        {
                            unitClassDataType.HitChance[num9] = Buffer.GetByte(array2, num);
                            num++;
                            num9++;
                        }
                        while (num9 <= 7);
                        Array.Resize<byte>(ref unitClassDataType.Strength, 8);
                        int num10 = 0;
                        do
                        {
                            unitClassDataType.Strength[num10] = Buffer.GetByte(array2, num);
                            num++;
                            num10++;
                        }
                        while (num10 <= 7);
                        Array.Resize<byte>(ref unitClassDataType.Range, 8);
                        int num11 = 0;
                        do
                        {
                            unitClassDataType.Range[num11] = Buffer.GetByte(array2, num);
                            num++;
                            num11++;
                        }
                        while (num11 <= 7);
                        Array.Resize<float>(ref unitClassDataType.Detection, 8);
                        int num12 = 0;
                        do
                        {
                            unitClassDataType.Detection[num12] = (float)Buffer.GetByte(array2, num);
                            num++;
                            num12++;
                        }
                        while (num12 <= 7);
                        Array.Resize<byte>(ref unitClassDataType.DamageMod, 11);
                        int num13 = 0;
                        do
                        {
                            unitClassDataType.DamageMod[num13] = Buffer.GetByte(array2, num);
                            num++;
                            num13++;
                        }
                        while (num13 <= 10);
                        unitClassDataType.RadarVehicle = Buffer.GetByte(array2, num);
                        num++;
                        num++;
                        unitClassDataType.SpecialIndex = BitConverter.ToInt16(array2, num);
                        num += 2;
                        unitClassDataType.IconIndex = BitConverter.ToInt16(array2, num);
                        num += 2;
                        num += 2;
                        array3[i] = unitClassDataType;
                    }
                    array = array3;
                }
                return array;
            }
        }

        // Token: 0x06000144 RID: 324 RVA: 0x00027340 File Offset: 0x00025540
        public byte[] WriteFalconUCD(BmsStructs.UnitClassDataType[] UCD)
        {
            byte[] array = new byte[1];
            int num = 0;
            
            Array bytes = BitConverter.GetBytes(UCD.Length);
            Array.Resize<byte>(ref array, 2);
            Array.Copy(bytes, 0, array, num, 2);
            checked
            {
                num += 2;
                int num2 = UCD.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    byte[] array2 = this.WriteUCD(UCD[i]);
                    Array.Resize<byte>(ref array, array.Length + array2.Length);
                    Array.Copy(array2, 0, array, num, array2.Length);
                    num += array2.Length;
                }
                return array;
            }
        }

        // Token: 0x06000145 RID: 325 RVA: 0x000273C0 File Offset: 0x000255C0
        public byte[] WriteUCD(BmsStructs.UnitClassDataType UCD)
        {
            byte[] array = new byte[1];
            int num = 0;
            
            Array bytes = BitConverter.GetBytes(UCD.Index);
            Array.Resize<byte>(ref array, 2);
            Array.Copy(bytes, 0, array, num, 2);
            checked
            {
                num += 2;
                Array.Resize<byte>(ref array, array.Length + 1);
                num++;
                int num2 = Constants.VEHICLES_PER_UNIT - 1;
                for (int i = 0; i <= num2; i++)
                {
                    Array bytes2 = BitConverter.GetBytes(UCD.NumElements[i]);
                    Array.Resize<byte>(ref array, array.Length + 4);
                    Array.Copy(bytes2, 0, array, num, 4);
                    num += 4;
                }
                Array.Resize<byte>(ref array, array.Length + 1);
                num++;
                int num3 = Constants.VEHICLES_PER_UNIT - 1;
                for (int j = 0; j <= num3; j++)
                {
                    Array bytes3 = BitConverter.GetBytes(UCD.VehicleType[j]);
                    Array.Resize<byte>(ref array, array.Length + 2);
                    Array.Copy(bytes3, 0, array, num, 2);
                    num += 2;
                }
                int num4 = Constants.VEHICLES_PER_UNIT - 1;
                for (int k = 0; k <= num4; k++)
                {
                    int num5 = 0;
                    do
                    {
                        Array.Resize<byte>(ref array, array.Length + 1);
                        array[num] = UCD.VehicleClass[k, num5];
                        num++;
                        num5++;
                    }
                    while (num5 <= 7);
                }
                Array bytes4 = BitConverter.GetBytes(UCD.Flags);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes4, 0, array, num, 2);
                num += 2;
                Array.Resize<char>(ref UCD.Name, 20);
                int num6 = 0;
                do
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(UCD.Name[num6]);
                    num++;
                    num6++;
                }
                while (num6 <= 19);
                Array.Resize<byte>(ref array, array.Length + 2);
                num += 2;
                Array bytes5 = BitConverter.GetBytes(UCD.MoveType);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes5, 0, array, num, 2);
                num += 2;
                Array.Resize<byte>(ref array, array.Length + 2);
                num += 2;
                Array bytes6 = BitConverter.GetBytes(UCD.MovementSpeed);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes6, 0, array, num, 2);
                num += 2;
                Array bytes7 = BitConverter.GetBytes(UCD.MaxRange);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes7, 0, array, num, 2);
                num += 2;
                Array bytes8 = BitConverter.GetBytes(UCD.Fuel);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes8, 0, array, num, 4);
                num += 4;
                Array bytes9 = BitConverter.GetBytes(UCD.FuelRate);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes9, 0, array, num, 2);
                num += 2;
                Array bytes10 = BitConverter.GetBytes(UCD.PtDataIndex);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes10, 0, array, num, 2);
                num += 2;
                int num7 = Constants.MAXIMUM_ROLES - 1;
                for (int l = 0; l <= num7; l++)
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(UCD.Scores[l]);
                    num++;
                }
                Array.Resize<byte>(ref array, array.Length + 1);
                array[num] = Convert.ToByte(UCD.Role);
                num++;
                int num8 = 0;
                do
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(UCD.HitChance[num8]);
                    num++;
                    num8++;
                }
                while (num8 <= 7);
                int num9 = 0;
                do
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(UCD.Strength[num9]);
                    num++;
                    num9++;
                }
                while (num9 <= 7);
                int num10 = 0;
                do
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(UCD.Range[num10]);
                    num++;
                    num10++;
                }
                while (num10 <= 7);
                int num11 = 0;
                do
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(UCD.Detection[num11]);
                    num++;
                    num11++;
                }
                while (num11 <= 7);
                int num12 = 0;
                do
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(UCD.DamageMod[num12]);
                    num++;
                    num12++;
                }
                while (num12 <= 10);
                Array.Resize<byte>(ref array, array.Length + 1);
                array[num] = Convert.ToByte(UCD.RadarVehicle);
                num++;
                Array.Resize<byte>(ref array, array.Length + 1);
                num++;
                Array bytes11 = BitConverter.GetBytes(UCD.SpecialIndex);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes11, 0, array, num, 2);
                num += 2;
                Array bytes12 = BitConverter.GetBytes(UCD.IconIndex);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes12, 0, array, num, 2);
                num += 2;
                Array.Resize<byte>(ref array, array.Length + 2);
                num += 2;
                return array;
            }
        }

        // Token: 0x06000146 RID: 326 RVA: 0x00027874 File Offset: 0x00025A74
        public BmsStructs.UnitClassDataType[] ReadXmlUCD_DOM(string fName, ref int LastUcd)
        {
            checked
            {
                BmsStructs.UnitClassDataType[] array;
                if (!File.Exists(fName))
                {
                    array = null;
                }
                else
                {
                    BmsStructs.UnitClassDataType[] array2 = new BmsStructs.UnitClassDataType[0];
                    XmlDocument xmlDocument = new XmlDocument();
                    DateTime now = DateTime.Now;
                    xmlDocument.Load(fName);
                    XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/UCDRecords/UCD");
                    int count = xmlNodeList.Count;
                    Array.Resize<BmsStructs.UnitClassDataType>(ref array2, count);
                    int num = array2.Length - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        Array.Resize<int>(ref array2[i].NumElements, Constants.VEHICLES_PER_UNIT);
                        Array.Resize<short>(ref array2[i].VehicleType, Constants.VEHICLES_PER_UNIT);
                        array2[i].VehicleClass = new byte[Constants.VEHICLES_PER_UNIT + 1, 9];
                        Array.Resize<short>(ref array2[i].ElementFlags, Constants.VEHICLES_PER_UNIT);
                        Array.Resize<string>(ref array2[i].ElementName, Constants.VEHICLES_PER_UNIT);
                        Array.Resize<short>(ref array2[i].ElementTexSetIdx, Constants.VEHICLES_PER_UNIT);
                        Array.Resize<byte>(ref array2[i].Scores, Constants.MAXIMUM_ROLES);
                        Array.Resize<byte>(ref array2[i].HitChance, 8);
                        Array.Resize<byte>(ref array2[i].Strength, 8);
                        Array.Resize<byte>(ref array2[i].Range, 8);
                        Array.Resize<float>(ref array2[i].Detection, 8);
                        Array.Resize<byte>(ref array2[i].DamageMod, 11);
                        array2[i].Description = "";
                    }
                    try
                    {
                        foreach (object obj in xmlNodeList)
                        {
                            XmlNode xmlNode = (XmlNode)obj;
                            string value = xmlNode.Attributes.GetNamedItem("Num").Value;
                            LastUcd = Conversions.ToInteger(value);
                            int num2 = 0;
                            int num3 = 0;
                            int num4 = 0;
                            int num5 = 0;
                            int num6 = 0;
                            int num7 = 0;
                            int num8 = 0;
                            int num9 = 0;
                            int num10 = xmlNode.ChildNodes.Count - 1;
                            for (int j = 0; j <= num10; j++)
                            {
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "CtIdx", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].Index = Conversions.ToShort(text);
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[j].Name, "ElementCount", CompareMethod.Binary) > 0)
                                {
                                    int num11 = num7;
                                    int vehicles_PER_UNIT = Constants.VEHICLES_PER_UNIT;
                                    for (int k = num11; k <= vehicles_PER_UNIT; k++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "ElementCount_" + Conversions.ToString(k), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(j).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                int num12 = (int)Math.Round(unchecked(Conversions.ToDouble(text) * 256.0));
                                                array2[Conversions.ToInteger(value)].NumElements[k] = num12;
                                                num7 = k;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[j].Name, "VehicleCtIdx", CompareMethod.Binary) > 0)
                                {
                                    int num13 = num9;
                                    int vehicles_PER_UNIT2 = Constants.VEHICLES_PER_UNIT;
                                    for (int l = num13; l <= vehicles_PER_UNIT2; l++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "VehicleCtIdx_" + Conversions.ToString(l), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(j).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                array2[Conversions.ToInteger(value)].VehicleType[l] = Conversions.ToShort(text);
                                                num9 = l;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[j].Name, "VehicleClass", CompareMethod.Binary) > 0)
                                {
                                    int num14 = num2;
                                    int vehicles_PER_UNIT3 = Constants.VEHICLES_PER_UNIT;
                                    for (int m = num14; m <= vehicles_PER_UNIT3; m++)
                                    {
                                        int num15 = 0;
                                        do
                                        {
                                            if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "VehicleClass_" + Conversions.ToString(m) + "_" + Conversions.ToString(num15), false) == 0)
                                            {
                                                string text = xmlNode.ChildNodes.Item(j).InnerText;
                                                if (Versioned.IsNumeric(text))
                                                {
                                                    array2[Conversions.ToInteger(value)].VehicleClass[m, num15] = Conversions.ToByte(text);
                                                    num2 = m;
                                                }
                                            }
                                            num15++;
                                        }
                                        while (num15 <= 7);
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[j].Name, "ElementFlags", CompareMethod.Binary) > 0)
                                {
                                    int num16 = num3;
                                    int vehicles_PER_UNIT4 = Constants.VEHICLES_PER_UNIT;
                                    for (int n = num16; n <= vehicles_PER_UNIT4; n++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "ElementFlags_" + Conversions.ToString(n), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(j).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                array2[Conversions.ToInteger(value)].ElementFlags[n] = Conversions.ToShort(text);
                                                num3 = n;
                                            }
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[j].Name, "ElementName", CompareMethod.Binary) > 0)
                                {
                                    int num17 = num4;
                                    int vehicles_PER_UNIT5 = Constants.VEHICLES_PER_UNIT;
                                    for (int num18 = num17; num18 <= vehicles_PER_UNIT5; num18++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "ElementName_" + Conversions.ToString(num18), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(j).InnerText;
                                            string text2 = Strings.Trim(text);
                                            array2[Conversions.ToInteger(value)].ElementName[num18] = text2;
                                            num4 = num18;
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[j].Name, "ElementTexSetIdx", CompareMethod.Binary) > 0)
                                {
                                    int num19 = num5;
                                    int vehicles_PER_UNIT6 = Constants.VEHICLES_PER_UNIT;
                                    for (int num20 = num19; num20 <= vehicles_PER_UNIT6; num20++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "ElementTexSetIdx_" + Conversions.ToString(num20), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(j).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                array2[Conversions.ToInteger(value)].ElementTexSetIdx[num20] = Conversions.ToShort(text);
                                                num5 = num20;
                                            }
                                        }
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Description", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    array2[Conversions.ToInteger(value)].Description = text;
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Flags", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].Flags = Conversions.ToUShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Name", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    string text3 = Strings.Trim(text);
                                    if (text3.Length <= 20)
                                    {
                                        array2[Conversions.ToInteger(value)].Name = Conversions.ToCharArrayRankOne(text3);
                                    }
                                    else
                                    {
                                        array2[Conversions.ToInteger(value)].Name = Conversions.ToCharArrayRankOne(Strings.Mid(text3, 1, 20));
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "MoveType", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].MoveType = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "MoveSpeed", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].MovementSpeed = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "MaxRange", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].MaxRange = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Fuel", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].Fuel = Conversions.ToLong(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "FuelRate", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].FuelRate = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "PtDataIdx", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].PtDataIndex = Conversions.ToShort(text);
                                    }
                                }
                                int num21 = num8;
                                int maximum_ROLES = Constants.MAXIMUM_ROLES;
                                for (int num22 = num21; num22 <= maximum_ROLES; num22++)
                                {
                                    if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "RoleScore_" + Conversions.ToString(num22), false) == 0)
                                    {
                                        string text = xmlNode.ChildNodes.Item(j).InnerText;
                                        if (Versioned.IsNumeric(text))
                                        {
                                            array2[Conversions.ToInteger(value)].Scores[num22] = Conversions.ToByte(text);
                                            num8 = num22;
                                            break;
                                        }
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "MainRole", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].Role = Conversions.ToByte(text);
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[j].Name, "Hit_", CompareMethod.Binary) > 0)
                                {
                                    for (int num23 = 0; num23 <= 8; num23++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Hit_" + BmsUtils.MoveTypeText(num23), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(j).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                array2[Conversions.ToInteger(value)].HitChance[num23] = Conversions.ToByte(text);
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[j].Name, "Str_", CompareMethod.Binary) > 0)
                                {
                                    for (int num24 = 0; num24 <= 8; num24++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Str_" + BmsUtils.MoveTypeText(num24), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(j).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                array2[Conversions.ToInteger(value)].Strength[num24] = Conversions.ToByte(text);
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[j].Name, "Rng_", CompareMethod.Binary) > 0)
                                {
                                    for (int num25 = 0; num25 <= 8; num25++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Rng_" + BmsUtils.MoveTypeText(num25), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(j).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                array2[Conversions.ToInteger(value)].Range[num25] = Conversions.ToByte(text);
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[j].Name, "Det_", CompareMethod.Binary) > 0)
                                {
                                    for (int num26 = 0; num26 <= 8; num26++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Det_" + BmsUtils.MoveTypeText(num26), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(j).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                array2[Conversions.ToInteger(value)].Detection[num26] = Conversions.ToSingle(text);
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[j].Name, "Dam_", CompareMethod.Binary) > 0)
                                {
                                    for (int num27 = num6; num27 <= 11; num27++)
                                    {
                                        string text4;
                                        if (num27 == 0)
                                        {
                                            text4 = "None";
                                        }
                                        else
                                        {
                                            text4 = BmsUtils.DamageDataTypeText(num27);
                                            text4 = text4.Replace("Dam", "");
                                        }
                                        if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Dam_" + text4, false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(j).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                array2[Conversions.ToInteger(value)].DamageMod[num27] = Conversions.ToByte(text);
                                                num6 = num27;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "RadarVehicle", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].RadarVehicle = Conversions.ToByte(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "SquadronStoresIdx", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].SpecialIndex = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "UnitIcon", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].IconIndex = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "InServiceStart", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].InServiceStart = Conversions.ToUShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "InServiceEnd", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].InServiceEnd = Conversions.ToUShort(text);
                                    }
                                }
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

        // Token: 0x06000147 RID: 327 RVA: 0x000288D8 File Offset: 0x00026AD8
        public BmsStructs.UnitClassDataType ReadXmlUCD_DOM_Single(string fName)
        {
            checked
            {
                BmsStructs.UnitClassDataType unitClassDataType;
                if (!File.Exists(fName))
                {
                    unitClassDataType = default(BmsStructs.UnitClassDataType);
                }
                else
                {
                    BmsStructs.UnitClassDataType unitClassDataType2 = default(BmsStructs.UnitClassDataType);
                    unitClassDataType2.NumElements = null;
                    unitClassDataType2.VehicleType = null;
                    unitClassDataType2.VehicleClass = null;
                    unitClassDataType2.ElementFlags = null;
                    unitClassDataType2.ElementName = null;
                    unitClassDataType2.ElementTexSetIdx = null;
                    unitClassDataType2.Scores = null;
                    unitClassDataType2.HitChance = null;
                    unitClassDataType2.Strength = null;
                    unitClassDataType2.Range = null;
                    unitClassDataType2.Detection = null;
                    unitClassDataType2.DamageMod = null;
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(fName);
                    XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/UCDRecords/UCD");
                    int count = xmlNodeList.Count;
                    Array.Resize<int>(ref unitClassDataType2.NumElements, Constants.VEHICLES_PER_UNIT);
                    Array.Resize<short>(ref unitClassDataType2.VehicleType, Constants.VEHICLES_PER_UNIT);
                    unitClassDataType2.VehicleClass = new byte[Constants.VEHICLES_PER_UNIT + 1, 9];
                    Array.Resize<short>(ref unitClassDataType2.ElementFlags, Constants.VEHICLES_PER_UNIT);
                    Array.Resize<string>(ref unitClassDataType2.ElementName, Constants.VEHICLES_PER_UNIT);
                    Array.Resize<short>(ref unitClassDataType2.ElementTexSetIdx, Constants.VEHICLES_PER_UNIT);
                    Array.Resize<byte>(ref unitClassDataType2.Scores, Constants.MAXIMUM_ROLES);
                    Array.Resize<byte>(ref unitClassDataType2.HitChance, 8);
                    Array.Resize<byte>(ref unitClassDataType2.Strength, 8);
                    Array.Resize<byte>(ref unitClassDataType2.Range, 8);
                    Array.Resize<float>(ref unitClassDataType2.Detection, 8);
                    Array.Resize<byte>(ref unitClassDataType2.DamageMod, 11);
                    try
                    {
                        foreach (object obj in xmlNodeList)
                        {
                            XmlNode xmlNode = (XmlNode)obj;
                            string value = xmlNode.Attributes.GetNamedItem("Num").Value;
                            int num = 0;
                            int num2 = 0;
                            int num3 = 0;
                            int num4 = 0;
                            int num5 = 0;
                            int num6 = 0;
                            int num7 = 0;
                            int num8 = 0;
                            int num9 = xmlNode.ChildNodes.Count - 1;
                            for (int i = 0; i <= num9; i++)
                            {
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "CtIdx", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        unitClassDataType2.Index = Conversions.ToShort(text);
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[i].Name, "ElementCount", CompareMethod.Binary) > 0)
                                {
                                    int num10 = num6;
                                    int vehicles_PER_UNIT = Constants.VEHICLES_PER_UNIT;
                                    for (int j = num10; j <= vehicles_PER_UNIT; j++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "ElementCount_" + Conversions.ToString(j), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(i).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                int num11 = (int)Math.Round(unchecked(Conversions.ToDouble(text) * 256.0));
                                                unitClassDataType2.NumElements[j] = num11;
                                                num6 = j;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[i].Name, "VehicleCtIdx", CompareMethod.Binary) > 0)
                                {
                                    int num12 = num8;
                                    int vehicles_PER_UNIT2 = Constants.VEHICLES_PER_UNIT;
                                    for (int k = num12; k <= vehicles_PER_UNIT2; k++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "VehicleCtIdx_" + Conversions.ToString(k), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(i).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                unitClassDataType2.VehicleType[k] = Conversions.ToShort(text);
                                                num8 = k;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[i].Name, "VehicleClass", CompareMethod.Binary) > 0)
                                {
                                    int num13 = num;
                                    int vehicles_PER_UNIT3 = Constants.VEHICLES_PER_UNIT;
                                    for (int l = num13; l <= vehicles_PER_UNIT3; l++)
                                    {
                                        int num14 = 0;
                                        do
                                        {
                                            if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "VehicleClass_" + Conversions.ToString(l) + "_" + Conversions.ToString(num14), false) == 0)
                                            {
                                                string text = xmlNode.ChildNodes.Item(i).InnerText;
                                                if (Versioned.IsNumeric(text))
                                                {
                                                    unitClassDataType2.VehicleClass[l, num14] = Conversions.ToByte(text);
                                                    num = l;
                                                }
                                            }
                                            num14++;
                                        }
                                        while (num14 <= 7);
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[i].Name, "ElementFlags", CompareMethod.Binary) > 0)
                                {
                                    int num15 = num2;
                                    int vehicles_PER_UNIT4 = Constants.VEHICLES_PER_UNIT;
                                    for (int m = num15; m <= vehicles_PER_UNIT4; m++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "ElementFlags_" + Conversions.ToString(m), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(i).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                unitClassDataType2.ElementFlags[m] = Conversions.ToShort(text);
                                                num2 = m;
                                            }
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[i].Name, "ElementName", CompareMethod.Binary) > 0)
                                {
                                    int num16 = num3;
                                    int vehicles_PER_UNIT5 = Constants.VEHICLES_PER_UNIT;
                                    for (int n = num16; n <= vehicles_PER_UNIT5; n++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "ElementName_" + Conversions.ToString(n), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(i).InnerText;
                                            string text2 = Strings.Trim(text);
                                            unitClassDataType2.ElementName[n] = text2;
                                            num3 = n;
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[i].Name, "ElementTexSetIdx", CompareMethod.Binary) > 0)
                                {
                                    int num17 = num4;
                                    int vehicles_PER_UNIT6 = Constants.VEHICLES_PER_UNIT;
                                    for (int num18 = num17; num18 <= vehicles_PER_UNIT6; num18++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "ElementTexSetIdx_" + Conversions.ToString(num18), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(i).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                unitClassDataType2.ElementTexSetIdx[num18] = Conversions.ToShort(text);
                                                num4 = num18;
                                            }
                                        }
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "Description", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    unitClassDataType2.Description = text;
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "Flags", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        unitClassDataType2.Flags = Conversions.ToUShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "Name", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    string text3 = Strings.Trim(text);
                                    if (text3.Length <= 20)
                                    {
                                        unitClassDataType2.Name = Conversions.ToCharArrayRankOne(text3);
                                    }
                                    else
                                    {
                                        unitClassDataType2.Name = Conversions.ToCharArrayRankOne(Strings.Mid(text3, 1, 20));
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "MoveType", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        unitClassDataType2.MoveType = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "MoveSpeed", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        unitClassDataType2.MovementSpeed = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "MaxRange", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        unitClassDataType2.MaxRange = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "Fuel", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        unitClassDataType2.Fuel = Conversions.ToLong(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "FuelRate", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        unitClassDataType2.FuelRate = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "PtDataIdx", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        unitClassDataType2.PtDataIndex = Conversions.ToShort(text);
                                    }
                                }
                                int num19 = num7;
                                int maximum_ROLES = Constants.MAXIMUM_ROLES;
                                for (int num20 = num19; num20 <= maximum_ROLES; num20++)
                                {
                                    if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "RoleScore_" + Conversions.ToString(num20), false) == 0)
                                    {
                                        string text = xmlNode.ChildNodes.Item(i).InnerText;
                                        if (Versioned.IsNumeric(text))
                                        {
                                            unitClassDataType2.Scores[num20] = Conversions.ToByte(text);
                                            num7 = num20;
                                            break;
                                        }
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "MainRole", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        unitClassDataType2.Role = Conversions.ToByte(text);
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[i].Name, "Hit_", CompareMethod.Binary) > 0)
                                {
                                    for (int num21 = 0; num21 <= 8; num21++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "Hit_" + BmsUtils.MoveTypeText(num21), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(i).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                unitClassDataType2.HitChance[num21] = Conversions.ToByte(text);
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[i].Name, "Str_", CompareMethod.Binary) > 0)
                                {
                                    for (int num22 = 0; num22 <= 8; num22++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "Str_" + BmsUtils.MoveTypeText(num22), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(i).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                unitClassDataType2.Strength[num22] = Conversions.ToByte(text);
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[i].Name, "Rng_", CompareMethod.Binary) > 0)
                                {
                                    for (int num23 = 0; num23 <= 8; num23++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "Rng_" + BmsUtils.MoveTypeText(num23), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(i).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                unitClassDataType2.Range[num23] = Conversions.ToByte(text);
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[i].Name, "Det_", CompareMethod.Binary) > 0)
                                {
                                    for (int num24 = 0; num24 <= 8; num24++)
                                    {
                                        if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "Det_" + BmsUtils.MoveTypeText(num24), false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(i).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                unitClassDataType2.Detection[num24] = Conversions.ToSingle(text);
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (Strings.InStr(xmlNode.ChildNodes[i].Name, "Dam_", CompareMethod.Binary) > 0)
                                {
                                    for (int num25 = num5; num25 <= 11; num25++)
                                    {
                                        string text4;
                                        if (num25 == 0)
                                        {
                                            text4 = "None";
                                        }
                                        else
                                        {
                                            text4 = BmsUtils.DamageDataTypeText(num25);
                                            text4 = text4.Replace("Dam", "");
                                        }
                                        if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "Dam_" + text4, false) == 0)
                                        {
                                            string text = xmlNode.ChildNodes.Item(i).InnerText;
                                            if (Versioned.IsNumeric(text))
                                            {
                                                unitClassDataType2.DamageMod[num25] = Conversions.ToByte(text);
                                                num5 = num25;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "RadarVehicle", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        unitClassDataType2.RadarVehicle = Conversions.ToByte(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "SquadronStoresIdx", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        unitClassDataType2.SpecialIndex = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "UnitIcon", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        unitClassDataType2.IconIndex = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "InServiceStart", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        unitClassDataType2.InServiceStart = Conversions.ToUShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[i].Name, "InServiceEnd", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(i).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        unitClassDataType2.InServiceEnd = Conversions.ToUShort(text);
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        
                    }
                    unitClassDataType = unitClassDataType2;
                }
                return unitClassDataType;
            }
        }

        // Token: 0x06000148 RID: 328 RVA: 0x00029784 File Offset: 0x00027984
        public BmsStructs.UnitClassDataType[] ReadXmlUCD(string fName, ref int LastUcd)
        {
            checked
            {
                BmsStructs.UnitClassDataType[] array;
                if (!File.Exists(fName))
                {
                    array = null;
                }
                else
                {
                    BmsStructs.UnitClassDataType[] array2 = new BmsStructs.UnitClassDataType[0];
                    XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
                    xmlReaderSettings.CheckCharacters = false;
                    DateTime now = DateTime.Now;
                    using (XmlReader xmlReader = XmlReader.Create(fName, xmlReaderSettings))
                    {
                        int num = 0;
                        while (xmlReader.Read())
                        {
                            
                            if (xmlReader.IsStartElement() && Operators.CompareString(xmlReader.Name, "UCDRecords", false) != 0 && Operators.CompareString(xmlReader.Name, "UCD", false) == 0)
                            {
                                string text = xmlReader["Num"];
                                LastUcd = Conversions.ToInteger(text);
                                num++;
                                Array.Resize<BmsStructs.UnitClassDataType>(ref array2, num);
                                Array.Resize<int>(ref array2[num - 1].NumElements, Constants.VEHICLES_PER_UNIT);
                                Array.Resize<short>(ref array2[num - 1].VehicleType, Constants.VEHICLES_PER_UNIT);
                                array2[num - 1].VehicleClass = new byte[Constants.VEHICLES_PER_UNIT + 1, 9];
                                Array.Resize<short>(ref array2[num - 1].ElementFlags, Constants.VEHICLES_PER_UNIT);
                                Array.Resize<string>(ref array2[num - 1].ElementName, Constants.VEHICLES_PER_UNIT);
                                Array.Resize<short>(ref array2[num - 1].ElementTexSetIdx, Constants.VEHICLES_PER_UNIT);
                                Array.Resize<byte>(ref array2[num - 1].Scores, Constants.MAXIMUM_ROLES);
                                Array.Resize<byte>(ref array2[num - 1].HitChance, 8);
                                Array.Resize<byte>(ref array2[num - 1].Strength, 8);
                                Array.Resize<byte>(ref array2[num - 1].Range, 8);
                                Array.Resize<float>(ref array2[num - 1].Detection, 8);
                                Array.Resize<byte>(ref array2[num - 1].DamageMod, 11);
                            }
                            if (xmlReader.NodeType == XmlNodeType.Element)
                            {
                                string name = xmlReader.Name;
                                string text2;
                                try
                                {
                                    int lineNumber = ((IXmlLineInfo)xmlReader).LineNumber;
                                    xmlReader.Read();
                                    text2 = ((string.IsNullOrEmpty(xmlReader.Value) || xmlReader.Value.Contains(Environment.NewLine)) ? "" : xmlReader.Value);
                                }
                                catch (Exception ex)
                                {
                                    text2 = "";
                                }
                                if (Operators.CompareString(name, "CtIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].Index = Conversions.ToShort(text2);
                                }
                                int num2 = Constants.VEHICLES_PER_UNIT - 1;
                                for (int i = 0; i <= num2; i++)
                                {
                                    if (Operators.CompareString(name, "ElementCount_" + Conversions.ToString(i), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        int num3 = (int)Math.Round(unchecked(Conversions.ToDouble(text2) * 256.0));
                                        array2[num - 1].NumElements[i] = num3;
                                    }
                                }
                                int num4 = Constants.VEHICLES_PER_UNIT - 1;
                                for (int j = 0; j <= num4; j++)
                                {
                                    if (Operators.CompareString(name, "VehicleCtIdx_" + Conversions.ToString(j), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].VehicleType[j] = Conversions.ToShort(text2);
                                    }
                                }
                                int num5 = Constants.VEHICLES_PER_UNIT - 1;
                                for (int k = 0; k <= num5; k++)
                                {
                                    int num6 = 0;
                                    do
                                    {
                                        if (Operators.CompareString(name, "VehicleClass_" + Conversions.ToString(k) + "_" + Conversions.ToString(num6), false) == 0 && Versioned.IsNumeric(text2))
                                        {
                                            array2[num - 1].VehicleClass[k, num6] = Conversions.ToByte(text2);
                                        }
                                        num6++;
                                    }
                                    while (num6 <= 7);
                                }
                                int vehicles_PER_UNIT = Constants.VEHICLES_PER_UNIT;
                                for (int l = 0; l <= vehicles_PER_UNIT; l++)
                                {
                                    if (Operators.CompareString(name, "ElementFlags_" + Conversions.ToString(l), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].ElementFlags[l] = Conversions.ToShort(text2);
                                    }
                                }
                                int vehicles_PER_UNIT2 = Constants.VEHICLES_PER_UNIT;
                                for (int m = 0; m <= vehicles_PER_UNIT2; m++)
                                {
                                    if (Operators.CompareString(name, "ElementName_" + Conversions.ToString(m), false) == 0)
                                    {
                                        string text3 = Strings.Trim(text2);
                                        array2[num - 1].ElementName[m] = text3;
                                    }
                                }
                                int vehicles_PER_UNIT3 = Constants.VEHICLES_PER_UNIT;
                                for (int n = 0; n <= vehicles_PER_UNIT3; n++)
                                {
                                    if (Operators.CompareString(name, "ElementTexSetIdx_" + Conversions.ToString(n), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].ElementTexSetIdx[n] = Conversions.ToShort(text2);
                                    }
                                }
                                if (Operators.CompareString(name, "Description", false) == 0)
                                {
                                    array2[num - 1].Description = text2;
                                }
                                if (Operators.CompareString(name, "Flags", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].Flags = Conversions.ToUShort(text2);
                                }
                                if (Operators.CompareString(name, "Name", false) == 0)
                                {
                                    string text4 = Strings.Trim(text2);
                                    if (name.Length <= 20)
                                    {
                                        array2[num - 1].Name = Conversions.ToCharArrayRankOne(text4);
                                    }
                                    else
                                    {
                                        array2[num - 1].Name = Conversions.ToCharArrayRankOne(Strings.Mid(text4, 1, 20));
                                    }
                                }
                                if (Operators.CompareString(name, "MoveType", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].MoveType = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "MoveSpeed", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].MovementSpeed = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "MaxRange", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].MaxRange = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "Fuel", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].Fuel = Conversions.ToLong(text2);
                                }
                                if (Operators.CompareString(name, "FuelRate", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].FuelRate = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "PtDataIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].PtDataIndex = Conversions.ToShort(text2);
                                }
                                int num7 = Constants.MAXIMUM_ROLES - 1;
                                for (int num8 = 0; num8 <= num7; num8++)
                                {
                                    if (Operators.CompareString(name, "RoleScore_" + Conversions.ToString(num8), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].Scores[num8] = Conversions.ToByte(text2);
                                    }
                                }
                                if (Operators.CompareString(name, "MainRole", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].Role = Conversions.ToByte(text2);
                                }
                                int num9 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "Hit_" + BmsUtils.MoveTypeText(num9), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].HitChance[num9] = Conversions.ToByte(text2);
                                    }
                                    num9++;
                                }
                                while (num9 <= 7);
                                int num10 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "Str_" + BmsUtils.MoveTypeText(num10), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].Strength[num10] = Conversions.ToByte(text2);
                                    }
                                    num10++;
                                }
                                while (num10 <= 7);
                                int num11 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "Rng_" + BmsUtils.MoveTypeText(num11), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].Range[num11] = Conversions.ToByte(text2);
                                    }
                                    num11++;
                                }
                                while (num11 <= 7);
                                int num12 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "Det_" + BmsUtils.MoveTypeText(num12), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].Detection[num12] = Conversions.ToSingle(text2);
                                    }
                                    num12++;
                                }
                                while (num12 <= 7);
                                int num13 = 0;
                                do
                                {
                                    string text5;
                                    if (num13 == 0)
                                    {
                                        text5 = "None";
                                    }
                                    else
                                    {
                                        text5 = BmsUtils.DamageDataTypeText(num13);
                                        text5 = text5.Replace("Dam", "");
                                    }
                                    if (Operators.CompareString(name, "Dam_" + text5, false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].DamageMod[num13] = Conversions.ToByte(text2);
                                    }
                                    num13++;
                                }
                                while (num13 <= 10);
                                if (Operators.CompareString(name, "RadarVehicle", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].RadarVehicle = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "SquadronStoresIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].SpecialIndex = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "UnitIcon", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].IconIndex = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "InServiceStart", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].InServiceStart = Conversions.ToUShort(text2);
                                }
                                if (Operators.CompareString(name, "InServiceEnd", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].InServiceEnd = Conversions.ToUShort(text2);
                                }
                            }
                        }
                    }
                    array = array2;
                }
                return array;
            }
        }

        // Token: 0x06000149 RID: 329 RVA: 0x0002A190 File Offset: 0x00028390
        private BmsStructs.UnitClassDataType[] ReadXmlAsString(string fName)
        {
            FileStream fileStream = new FileStream(fName, FileMode.Open);
            StreamReader streamReader = new StreamReader(fileStream);
            BmsStructs.UnitClassDataType[] array = new BmsStructs.UnitClassDataType[0];
            DateTime now = DateTime.Now;
            checked
            {
                try
                {
                    int num = 0;
                    while (!streamReader.EndOfStream)
                    {
                        string text = streamReader.ReadLine();
                        if (Strings.InStr(Strings.LCase(text), "<ucd num=", CompareMethod.Binary) > 0)
                        {
                            
                            num++;
                            Array.Resize<BmsStructs.UnitClassDataType>(ref array, num);
                            Array.Resize<int>(ref array[num - 1].NumElements, Constants.VEHICLES_PER_UNIT);
                            Array.Resize<short>(ref array[num - 1].VehicleType, Constants.VEHICLES_PER_UNIT);
                            array[num - 1].VehicleClass = new byte[Constants.VEHICLES_PER_UNIT + 1, 9];
                            Array.Resize<short>(ref array[num - 1].ElementFlags, Constants.VEHICLES_PER_UNIT);
                            Array.Resize<string>(ref array[num - 1].ElementName, Constants.VEHICLES_PER_UNIT);
                            Array.Resize<short>(ref array[num - 1].ElementTexSetIdx, Constants.VEHICLES_PER_UNIT);
                            Array.Resize<byte>(ref array[num - 1].Scores, Constants.MAXIMUM_ROLES);
                            Array.Resize<byte>(ref array[num - 1].HitChance, 8);
                            Array.Resize<byte>(ref array[num - 1].Strength, 8);
                            Array.Resize<byte>(ref array[num - 1].Range, 8);
                            Array.Resize<float>(ref array[num - 1].Detection, 8);
                            Array.Resize<byte>(ref array[num - 1].DamageMod, 11);
                        }
                        else
                        {
                            string name = this.GetName(text);
                            string value = this.GetValue(text);
                            
                            if (Operators.CompareString(name, "CtIdx", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].Index = Conversions.ToShort(value);
                            }
                            int num2 = Constants.VEHICLES_PER_UNIT - 1;
                            for (int i = 0; i <= num2; i++)
                            {
                                if (Operators.CompareString(name, "ElementCount_" + Conversions.ToString(i), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    int num3 = (int)Math.Round(unchecked(Conversions.ToDouble(value) * 256.0));
                                    array[num - 1].NumElements[i] = num3;
                                }
                            }
                            int num4 = Constants.VEHICLES_PER_UNIT - 1;
                            for (int j = 0; j <= num4; j++)
                            {
                                if (Operators.CompareString(name, "VehicleCtIdx_" + Conversions.ToString(j), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].VehicleType[j] = Conversions.ToShort(value);
                                }
                            }
                            int num5 = Constants.VEHICLES_PER_UNIT - 1;
                            for (int k = 0; k <= num5; k++)
                            {
                                int num6 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "VehicleClass_" + Conversions.ToString(k) + "_" + Conversions.ToString(num6), false) == 0 && Versioned.IsNumeric(value))
                                    {
                                        array[num - 1].VehicleClass[k, num6] = Conversions.ToByte(value);
                                    }
                                    num6++;
                                }
                                while (num6 <= 7);
                            }
                            int vehicles_PER_UNIT = Constants.VEHICLES_PER_UNIT;
                            for (int l = 0; l <= vehicles_PER_UNIT; l++)
                            {
                                if (Operators.CompareString(name, "ElementFlags_" + Conversions.ToString(l), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].ElementFlags[l] = Conversions.ToShort(value);
                                }
                            }
                            int vehicles_PER_UNIT2 = Constants.VEHICLES_PER_UNIT;
                            for (int m = 0; m <= vehicles_PER_UNIT2; m++)
                            {
                                if (Operators.CompareString(name, "ElementName_" + Conversions.ToString(m), false) == 0)
                                {
                                    string text2 = Strings.Trim(value);
                                    array[num - 1].ElementName[m] = text2;
                                }
                            }
                            int vehicles_PER_UNIT3 = Constants.VEHICLES_PER_UNIT;
                            for (int n = 0; n <= vehicles_PER_UNIT3; n++)
                            {
                                if (Operators.CompareString(name, "ElementTexSetIdx_" + Conversions.ToString(n), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].ElementTexSetIdx[n] = Conversions.ToShort(value);
                                }
                            }
                            if (Operators.CompareString(name, "Description", false) == 0)
                            {
                                array[num - 1].Description = value;
                            }
                            if (Operators.CompareString(name, "Flags", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].Flags = Conversions.ToUShort(value);
                            }
                            if (Operators.CompareString(name, "Name", false) == 0)
                            {
                                string text3 = Strings.Trim(value);
                                if (name.Length <= 20)
                                {
                                    array[num - 1].Name = Conversions.ToCharArrayRankOne(text3);
                                }
                                else
                                {
                                    array[num - 1].Name = Conversions.ToCharArrayRankOne(Strings.Mid(text3, 1, 20));
                                }
                            }
                            if (Operators.CompareString(name, "MoveType", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].MoveType = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "MoveSpeed", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].MovementSpeed = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "MaxRange", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].MaxRange = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "Fuel", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].Fuel = Conversions.ToLong(value);
                            }
                            if (Operators.CompareString(name, "FuelRate", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].FuelRate = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "PtDataIdx", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].PtDataIndex = Conversions.ToShort(value);
                            }
                            int num7 = Constants.MAXIMUM_ROLES - 1;
                            for (int num8 = 0; num8 <= num7; num8++)
                            {
                                if (Operators.CompareString(name, "RoleScore_" + Conversions.ToString(num8), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].Scores[num8] = Conversions.ToByte(value);
                                }
                            }
                            if (Operators.CompareString(name, "MainRole", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].Role = Conversions.ToByte(value);
                            }
                            int num9 = 0;
                            do
                            {
                                if (Operators.CompareString(name, "Hit_" + BmsUtils.MoveTypeText(num9), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].HitChance[num9] = Conversions.ToByte(value);
                                }
                                num9++;
                            }
                            while (num9 <= 7);
                            int num10 = 0;
                            do
                            {
                                if (Operators.CompareString(name, "Str_" + BmsUtils.MoveTypeText(num10), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].Strength[num10] = Conversions.ToByte(value);
                                }
                                num10++;
                            }
                            while (num10 <= 7);
                            int num11 = 0;
                            do
                            {
                                if (Operators.CompareString(name, "Rng_" + BmsUtils.MoveTypeText(num11), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].Range[num11] = Conversions.ToByte(value);
                                }
                                num11++;
                            }
                            while (num11 <= 7);
                            int num12 = 0;
                            do
                            {
                                if (Operators.CompareString(name, "Det_" + BmsUtils.MoveTypeText(num12), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].Detection[num12] = Conversions.ToSingle(value);
                                }
                                num12++;
                            }
                            while (num12 <= 7);
                            int num13 = 0;
                            do
                            {
                                string text4;
                                if (num13 == 0)
                                {
                                    text4 = "None";
                                }
                                else
                                {
                                    text4 = BmsUtils.DamageDataTypeText(num13);
                                    text4 = text4.Replace("Dam", "");
                                }
                                if (Operators.CompareString(name, "Dam_" + text4, false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].DamageMod[num13] = Conversions.ToByte(value);
                                }
                                num13++;
                            }
                            while (num13 <= 10);
                            if (Operators.CompareString(name, "RadarVehicle", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].RadarVehicle = Conversions.ToByte(value);
                            }
                            if (Operators.CompareString(name, "SquadronStoresIdx", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].SpecialIndex = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "UnitIcon", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].IconIndex = Conversions.ToShort(value);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                fileStream.Flush();
                fileStream.Close();
                return array;
            }
        }

        // Token: 0x0600014A RID: 330 RVA: 0x0002AAB8 File Offset: 0x00028CB8
        private string GetName(string Line)
        {
            string text = "";
            Line = Line.Replace("\t", "");
            Line = Strings.Trim(Line);
            checked
            {
                int num = Line.IndexOf("<") + 2;
                int num2 = Line.IndexOf(">") + 1 - num;
                if (num2 > 1)
                {
                    text = Strings.Mid(Line, num, num2);
                }
                return text;
            }
        }

        // Token: 0x0600014B RID: 331 RVA: 0x0002AB14 File Offset: 0x00028D14
        private string GetValue(string Line)
        {
            string text = "";
            Line = this.RemoveIllegalXMLCharacters(Line);
            Line = Line.Replace("\t", "");
            Line = Strings.Trim(Line);
            int num = checked(Line.IndexOf(">") + 2);
            Line = Strings.Mid(Line, num, Line.Length);
            int num2 = Line.IndexOf("<");
            if (num2 >= 1)
            {
                text = Strings.Mid(Line, 1, num2);
            }
            return text;
        }

        // Token: 0x0600014C RID: 332 RVA: 0x0002AB84 File Offset: 0x00028D84
        private string RemoveIllegalXMLCharacters(string Line)
        {
            StringBuilder stringBuilder = new StringBuilder();
            checked
            {
                int num = Line.Length - 1;
                for (int i = 0; i <= num; i++)
                {
                    char c = Line[i];
                    if (c == '\t' || c == '\n' || c == '\r' || (c >= ' ' && c <= '\ud7ff') || (c >= '\ue000' && c <= '\ufffd') || ((int)c >= 65536 && (int)c <= 1114111))
                    {
                        stringBuilder.Append(c);
                    }
                }
                return stringBuilder.ToString();
            }
        }

        // Token: 0x0600014D RID: 333 RVA: 0x0002AC00 File Offset: 0x00028E00
        public bool WriteXmlUCD(BmsStructs.UnitClassDataType[] UnitDataEntries, string fName, int Minor, int Build)
        {
            checked
            {
                bool flag;
                if (UnitDataEntries == null)
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
                        xmlWriter.WriteStartElement("UCDRecords");
                        int num = UnitDataEntries.Length - 1;
                        for (int i = 0; i <= num; i++)
                        {
                            string text2 = new string(UnitDataEntries[i].Name);
                            text2 = text2.Replace('\0', ' ');
                            text2 = Strings.Trim(text2);
                            if (Operators.CompareString(text2, null, false) == 0)
                            {
                                text2 = " ";
                            }
                            string text3;
                            if (UnitDataEntries[i].Description == null)
                            {
                                text3 = "";
                            }
                            else
                            {
                                text3 = UnitDataEntries[i].Description;
                                text3 = text3.Replace('\0', ' ');
                                text3 = Strings.Trim(text3);
                                if (Operators.CompareString(text3, null, false) == 0)
                                {
                                    text3 = "";
                                }
                            }
                            xmlWriter.WriteStartElement("UCD");
                            xmlWriter.WriteAttributeString("Num", Conversions.ToString(i));
                            xmlWriter.WriteElementString("CtIdx", UnitDataEntries[i].Index.ToString());
                            int num2 = Constants.VEHICLES_PER_UNIT - 1;
                            for (int j = 0; j <= num2; j++)
                            {
                                int num3 = (int)Math.Round((double)UnitDataEntries[i].NumElements[j] / 256.0);
                                if ((num3 > 0) & (UnitDataEntries[i].VehicleType[j] != 0))
                                {
                                    xmlWriter.WriteElementString("ElementCount_" + Conversions.ToString(j), num3.ToString());
                                }
                            }
                            int num4 = Constants.VEHICLES_PER_UNIT - 1;
                            for (int k = 0; k <= num4; k++)
                            {
                                if (UnitDataEntries[i].VehicleType[k] != 0)
                                {
                                    xmlWriter.WriteElementString("VehicleCtIdx_" + Conversions.ToString(k), UnitDataEntries[i].VehicleType[k].ToString());
                                }
                            }
                            int num5 = Constants.VEHICLES_PER_UNIT - 1;
                            for (int l = 0; l <= num5; l++)
                            {
                                int num6 = 0;
                                do
                                {
                                    bool flag2 = (UnitDataEntries[i].VehicleClass[l, num6] > 0) & ((double)UnitDataEntries[i].NumElements[l] / 256.0 != 0.0);
                                    num6++;
                                }
                                while (num6 <= 7);
                            }
                            int num7 = Constants.VEHICLES_PER_UNIT - 1;
                            for (int m = 0; m <= num7; m++)
                            {
                                if (UnitDataEntries[i].ElementFlags == null)
                                {
                                    Array.Resize<short>(ref UnitDataEntries[i].ElementFlags, Constants.VEHICLES_PER_UNIT);
                                }
                                if ((UnitDataEntries[i].ElementFlags[m] != 0) & ((double)UnitDataEntries[i].NumElements[m] / 256.0 != 0.0))
                                {
                                    xmlWriter.WriteElementString("ElementFlags_" + Conversions.ToString(m), UnitDataEntries[i].ElementFlags[m].ToString());
                                }
                            }
                            int num8 = Constants.VEHICLES_PER_UNIT - 1;
                            for (int n = 0; n <= num8; n++)
                            {
                                if (UnitDataEntries[i].ElementName != null && (double)UnitDataEntries[i].NumElements[n] / 256.0 != 0.0)
                                {
                                    string text4 = UnitDataEntries[i].ElementName[n];
                                    if (text4 != null && text4.Length >= 1)
                                    {
                                        xmlWriter.WriteElementString("ElementName_" + Conversions.ToString(n), text4);
                                    }
                                }
                            }
                            int num9 = Constants.VEHICLES_PER_UNIT - 1;
                            for (int num10 = 0; num10 <= num9; num10++)
                            {
                                if (UnitDataEntries[i].ElementTexSetIdx != null && ((UnitDataEntries[i].ElementTexSetIdx[num10] != 0) & ((double)UnitDataEntries[i].NumElements[num10] / 256.0 != 0.0)))
                                {
                                    xmlWriter.WriteElementString("ElementTexSetIdx_" + Conversions.ToString(num10), UnitDataEntries[i].ElementTexSetIdx[num10].ToString());
                                }
                            }
                            if (Operators.CompareString(text3, "", false) != 0)
                            {
                                xmlWriter.WriteElementString("Description", text3);
                            }
                            xmlWriter.WriteElementString("Flags", UnitDataEntries[i].Flags.ToString());
                            xmlWriter.WriteElementString("Name", text2);
                            xmlWriter.WriteElementString("MoveType", UnitDataEntries[i].MoveType.ToString());
                            xmlWriter.WriteElementString("MoveSpeed", UnitDataEntries[i].MovementSpeed.ToString());
                            xmlWriter.WriteElementString("MaxRange", UnitDataEntries[i].MaxRange.ToString());
                            xmlWriter.WriteElementString("Fuel", UnitDataEntries[i].Fuel.ToString());
                            xmlWriter.WriteElementString("FuelRate", UnitDataEntries[i].FuelRate.ToString());
                            xmlWriter.WriteElementString("PtDataIdx", UnitDataEntries[i].PtDataIndex.ToString());
                            int num11 = Constants.MAXIMUM_ROLES - 1;
                            for (int num12 = 0; num12 <= num11; num12++)
                            {
                                if (UnitDataEntries[i].Scores[num12] != 0)
                                {
                                    xmlWriter.WriteElementString("RoleScore_" + Conversions.ToString(num12), UnitDataEntries[i].Scores[num12].ToString());
                                }
                            }
                            xmlWriter.WriteElementString("MainRole", UnitDataEntries[i].Role.ToString());
                            int num13 = 0;
                            do
                            {
                                xmlWriter.WriteElementString("Hit_" + BmsUtils.MoveTypeText(num13), UnitDataEntries[i].HitChance[num13].ToString());
                                num13++;
                            }
                            while (num13 <= 7);
                            int num14 = 0;
                            do
                            {
                                xmlWriter.WriteElementString("Str_" + BmsUtils.MoveTypeText(num14), UnitDataEntries[i].Strength[num14].ToString());
                                num14++;
                            }
                            while (num14 <= 7);
                            int num15 = 0;
                            do
                            {
                                xmlWriter.WriteElementString("Rng_" + BmsUtils.MoveTypeText(num15), UnitDataEntries[i].Range[num15].ToString());
                                num15++;
                            }
                            while (num15 <= 7);
                            int num16 = 0;
                            do
                            {
                                float num17 = UnitDataEntries[i].Detection[num16];
                                string text5;
                                if ((Minor >= 36) & (Build >= 21419))
                                {
                                    text5 = Strings.Format(num17, "#0.0");
                                }
                                else
                                {
                                    if (num17 > 256f)
                                    {
                                        num17 = 256f;
                                    }
                                    if (num17 < 0f)
                                    {
                                        num17 = 0f;
                                    }
                                    text5 = Strings.Format(num17, "#0");
                                }
                                xmlWriter.WriteElementString("Det_" + BmsUtils.MoveTypeText(num16), text5.ToString());
                                num16++;
                            }
                            while (num16 <= 7);
                            int num18 = 0;
                            do
                            {
                                string text6;
                                if (num18 == 0)
                                {
                                    text6 = "None";
                                }
                                else
                                {
                                    text6 = BmsUtils.DamageDataTypeText(num18).Replace("Dam", "").ToString();
                                }
                                xmlWriter.WriteElementString("Dam_" + text6, UnitDataEntries[i].DamageMod[num18].ToString());
                                num18++;
                            }
                            while (num18 <= 10);
                            xmlWriter.WriteElementString("RadarVehicle", UnitDataEntries[i].RadarVehicle.ToString());
                            xmlWriter.WriteElementString("SquadronStoresIdx", UnitDataEntries[i].SpecialIndex.ToString());
                            xmlWriter.WriteElementString("UnitIcon", UnitDataEntries[i].IconIndex.ToString());
                            if (UnitDataEntries[i].InServiceStart != 0)
                            {
                                xmlWriter.WriteElementString("InServiceStart", UnitDataEntries[i].InServiceStart.ToString());
                            }
                            if ((UnitDataEntries[i].InServiceEnd > 0) & (UnitDataEntries[i].InServiceEnd < 9999))
                            {
                                xmlWriter.WriteElementString("InServiceEnd", UnitDataEntries[i].InServiceEnd.ToString());
                            }
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

        // Token: 0x04000169 RID: 361
    }
}
