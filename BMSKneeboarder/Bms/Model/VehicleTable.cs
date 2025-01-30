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
    public class VehicleTable
    {
        // Token: 0x0600014E RID: 334 RVA: 0x0002B538 File Offset: 0x00029738
        public VehicleTable()
        {
        }

        // Token: 0x0600014F RID: 335 RVA: 0x0002B54C File Offset: 0x0002974C
        public BmsStructs.VehicleClassDataType[] LoadVCD(string DefaultDir, string fName, ref bool ReadXml)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            BmsStructs.VehicleClassDataType[] array = null;
            if (ReadXml)
            {
                int num = 0;
                if (File.Exists(fName))
                {
                    try
                    {
                        array = this.ReadXmlVCD(fName, ref num);
                        goto IL_0152;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Concat(new string[]
                        {
                            "This file contains errors!!!\r\n\r\nPossible illegal charaters are used.\r\nCheck VCD: ",
                            Conversions.ToString(num),
                            "\r\n\r\n",
                            fName,
                            "\r\n\r\nTrying to load in an alternate slower way."
                        }), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        array = this.ReadXmlAsString(fName);
                        goto IL_0152;
                    }
                }
                fName = Strings.LCase(fName);
                fName = fName.Replace("falcon4_vcd.xml", "falcon4.vcd");
                if (File.Exists(fName))
                {
                    array = this.ReadVehicleTable(fName);
                    ReadXml = false;
                }
                else
                {
                    fName = DefaultDir + "falcon4_vcd.xml";
                    if (File.Exists(fName))
                    {
                        array = this.ReadXmlVCD(fName, ref num);
                    }
                    else
                    {
                        fName = Strings.LCase(fName);
                        fName = fName.Replace("falcon4_vcd.xml", "falcon4.vcd");
                        if (File.Exists(fName))
                        {
                            array = this.ReadVehicleTable(fName);
                            ReadXml = false;
                        }
                    }
                }
            }
            else if (File.Exists(fName))
            {
                array = this.ReadVehicleTable(fName);
            }
            else
            {
                fName = DefaultDir + "falcon4.vcd";
                if (File.Exists(fName))
                {
                    array = this.ReadVehicleTable(fName);
                }
            }
        IL_0152:
            return array;
        }

        // Token: 0x06000150 RID: 336 RVA: 0x0002B6C0 File Offset: 0x000298C0
        public bool SaveVCD(BmsStructs.VehicleClassDataType[] VehicleDataEntries, string fName, ref bool ReadXml)
        {
            bool flag = false;
            bool flag2;
            if (Information.IsNothing(VehicleDataEntries))
            {
                flag2 = false;
            }
            else
            {
                if (ReadXml)
                {
                    flag = this.WriteXmlVCD(VehicleDataEntries, fName);
                }
                else
                {
                    byte[] array = new byte[1];
                    array = this.WriteFalconVCD(VehicleDataEntries);
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

        // Token: 0x06000151 RID: 337 RVA: 0x0002B754 File Offset: 0x00029954
        public BmsStructs.VehicleClassDataType CopyVehicleClassDataType(ref BmsStructs.VehicleClassDataType src)
        {
            BmsStructs.VehicleClassDataType vehicleClassDataType;
            vehicleClassDataType.CallsignIndex = src.CallsignIndex;
            vehicleClassDataType.CallsignSlots = src.CallsignSlots;
            vehicleClassDataType.CruiseAlt = src.CruiseAlt;
            checked
            {
                vehicleClassDataType.DamageMod = new byte[src.DamageMod.Count<byte>() - 1 + 1];
                Array.Copy(src.DamageMod, vehicleClassDataType.DamageMod, src.DamageMod.Length);
                vehicleClassDataType.Detection = new byte[src.Detection.Count<byte>() - 1 + 1];
                Array.Copy(src.Detection, vehicleClassDataType.Detection, src.Detection.Length);
                vehicleClassDataType.EmptyWt = src.EmptyWt;
                vehicleClassDataType.EngineSound = src.EngineSound;
                vehicleClassDataType.Flags = src.Flags;
                vehicleClassDataType.FuelEcon = src.FuelEcon;
                vehicleClassDataType.FuelWt = src.FuelWt;
                vehicleClassDataType.HighAlt = src.HighAlt;
                vehicleClassDataType.HitChance = new byte[src.HitChance.Count<byte>() - 1 + 1];
                Array.Copy(src.HitChance, vehicleClassDataType.HitChance, src.HitChance.Length);
                vehicleClassDataType.HitPoints = src.HitPoints;
                vehicleClassDataType.Index = src.Index;
                vehicleClassDataType.LowAlt = src.LowAlt;
                vehicleClassDataType.MaxSpeed = src.MaxSpeed;
                vehicleClassDataType.MaxWt = src.MaxWt;
                vehicleClassDataType.Name = new char[src.Name.Count<char>() - 1 + 1];
                Array.Copy(src.Name, vehicleClassDataType.Name, src.Name.Length);
                vehicleClassDataType.NCTR = new char[src.NCTR.Count<char>() - 1 + 1];
                Array.Copy(src.NCTR, vehicleClassDataType.NCTR, src.NCTR.Length);
                vehicleClassDataType.NumberOfPilots = src.NumberOfPilots;
                vehicleClassDataType.RackFlags = src.RackFlags;
                vehicleClassDataType.RadarType = src.RadarType;
                vehicleClassDataType.Range = new byte[src.Range.Count<byte>() - 1 + 1];
                Array.Copy(src.Range, vehicleClassDataType.Range, src.Range.Length);
                vehicleClassDataType.RCSfactor = src.RCSfactor;
                vehicleClassDataType.Strength = new byte[src.Strength.Count<byte>() - 1 + 1];
                Array.Copy(src.Strength, vehicleClassDataType.Strength, src.Strength.Length);
                vehicleClassDataType.VisibleFlags = src.VisibleFlags;
                vehicleClassDataType.Weapon = new short[src.Weapon.Count<short>() - 1 + 1];
                Array.Copy(src.Weapon, vehicleClassDataType.Weapon, src.Weapon.Length);
                vehicleClassDataType.Weapons = new byte[src.Weapons.Count<byte>() - 1 + 1];
                Array.Copy(src.Weapons, vehicleClassDataType.Weapons, src.Weapons.Length);
                vehicleClassDataType.ptType = src.ptType;
                vehicleClassDataType.Description = src.Description;
                vehicleClassDataType.InServiceStart = src.InServiceStart;
                vehicleClassDataType.InServiceEnd = src.InServiceEnd;
                return vehicleClassDataType;
            }
        }

        // Token: 0x06000152 RID: 338 RVA: 0x0002BA64 File Offset: 0x00029C64
        public BmsStructs.VehicleClassDataType[] ReadVehicleTable(string VehicleTableFilePath)
        {
            checked
            {
                BmsStructs.VehicleClassDataType[] array;
                if (!File.Exists(VehicleTableFilePath))
                {
                    array = null;
                }
                else
                {
                    FileStream fileStream = new FileStream(VehicleTableFilePath, FileMode.Open, FileAccess.Read);
                    byte[] array2 = new byte[(int)fileStream.Length + 1];
                    fileStream.Read(array2, 0, (int)fileStream.Length);
                    fileStream.Close();
                    bool flag = false;
                    int num2 = 0;
                    int num = (int)BitConverter.ToInt16(array2, num2);
                    if (num < 10)
                    {
                        num2 += 4;
                        num = (int)BitConverter.ToInt16(array2, num2);
                        num2 += 2;
                        flag = true;
                    }
                    num2 += 2;
                    BmsStructs.VehicleClassDataType[] array3 = new BmsStructs.VehicleClassDataType[num - 1 + 1];
                    int num3 = num - 1;
                    for (int i = 0; i <= num3; i++)
                    {
                        BmsStructs.VehicleClassDataType vehicleClassDataType = default(BmsStructs.VehicleClassDataType);
                        vehicleClassDataType.Index = BitConverter.ToInt16(array2, num2);
                        num2 += 2;
                        vehicleClassDataType.HitPoints = BitConverter.ToInt16(array2, num2);
                        num2 += 2;
                        vehicleClassDataType.Flags = BitConverter.ToUInt32(array2, num2);
                        num2 += 4;
                        Array.Resize<char>(ref vehicleClassDataType.Name, 15);
                        vehicleClassDataType.Name = Conversions.ToCharArrayRankOne(Encoding.Default.GetString(array2, num2, 15));
                        num2 += 15;
                        Array.Resize<char>(ref vehicleClassDataType.NCTR, 5);
                        vehicleClassDataType.NCTR = Conversions.ToCharArrayRankOne(Encoding.Default.GetString(array2, num2, 5));
                        num2 += 5;
                        vehicleClassDataType.RCSfactor = BitConverter.ToSingle(array2, num2);
                        num2 += 4;
                        vehicleClassDataType.MaxWt = unchecked((long)BitConverter.ToInt32(array2, num2));
                        num2 += 4;
                        vehicleClassDataType.EmptyWt = unchecked((long)BitConverter.ToInt32(array2, num2));
                        num2 += 4;
                        vehicleClassDataType.FuelWt = unchecked((long)BitConverter.ToInt32(array2, num2));
                        num2 += 4;
                        vehicleClassDataType.FuelEcon = BitConverter.ToInt16(array2, num2);
                        num2 += 2;
                        vehicleClassDataType.EngineSound = BitConverter.ToInt16(array2, num2);
                        num2 += 2;
                        vehicleClassDataType.HighAlt = BitConverter.ToInt16(array2, num2);
                        num2 += 2;
                        vehicleClassDataType.LowAlt = BitConverter.ToInt16(array2, num2);
                        num2 += 2;
                        vehicleClassDataType.CruiseAlt = BitConverter.ToInt16(array2, num2);
                        num2 += 2;
                        vehicleClassDataType.MaxSpeed = BitConverter.ToInt16(array2, num2);
                        num2 += 2;
                        vehicleClassDataType.RadarType = BitConverter.ToInt16(array2, num2);
                        num2 += 2;
                        vehicleClassDataType.NumberOfPilots = BitConverter.ToInt16(array2, num2);
                        num2 += 2;
                        vehicleClassDataType.RackFlags = BitConverter.ToUInt16(array2, num2);
                        num2 += 2;
                        vehicleClassDataType.VisibleFlags = BitConverter.ToUInt16(array2, num2);
                        num2 += 2;
                        vehicleClassDataType.CallsignIndex = Buffer.GetByte(array2, num2);
                        num2++;
                        vehicleClassDataType.CallsignSlots = Buffer.GetByte(array2, num2);
                        num2++;
                        Array.Resize<byte>(ref vehicleClassDataType.HitChance, 8);
                        int num4 = 0;
                        do
                        {
                            vehicleClassDataType.HitChance[num4] = Buffer.GetByte(array2, num2);
                            num2++;
                            num4++;
                        }
                        while (num4 <= 7);
                        Array.Resize<byte>(ref vehicleClassDataType.Strength, 8);
                        int num5 = 0;
                        do
                        {
                            vehicleClassDataType.Strength[num5] = Buffer.GetByte(array2, num2);
                            num2++;
                            num5++;
                        }
                        while (num5 <= 7);
                        Array.Resize<byte>(ref vehicleClassDataType.Range, 8);
                        int num6 = 0;
                        do
                        {
                            vehicleClassDataType.Range[num6] = Buffer.GetByte(array2, num2);
                            num2++;
                            num6++;
                        }
                        while (num6 <= 7);
                        Array.Resize<byte>(ref vehicleClassDataType.Detection, 8);
                        int num7 = 0;
                        do
                        {
                            vehicleClassDataType.Detection[num7] = Buffer.GetByte(array2, num2);
                            num2++;
                            num7++;
                        }
                        while (num7 <= 7);
                        Array.Resize<short>(ref vehicleClassDataType.Weapon, Constants.HARDPOINTS_MAX);
                        int num8 = Constants.HARDPOINTS_MAX - 1;
                        for (int j = 0; j <= num8; j++)
                        {
                            vehicleClassDataType.Weapon[j] = BitConverter.ToInt16(array2, num2);
                            num2 += 2;
                        }
                        Array.Resize<byte>(ref vehicleClassDataType.Weapons, Constants.HARDPOINTS_MAX);
                        int num9 = Constants.HARDPOINTS_MAX - 1;
                        for (int k = 0; k <= num9; k++)
                        {
                            vehicleClassDataType.Weapons[k] = Buffer.GetByte(array2, num2);
                            num2++;
                        }
                        Array.Resize<byte>(ref vehicleClassDataType.DamageMod, 11);
                        int num10 = 0;
                        do
                        {
                            vehicleClassDataType.DamageMod[num10] = Buffer.GetByte(array2, num2);
                            num2++;
                            num10++;
                        }
                        while (num10 <= 10);
                        num2 += 2;
                        if (flag)
                        {
                            num2 += 17;
                        }
                        else
                        {
                            num2++;
                        }
                        array3[i] = vehicleClassDataType;
                    }
                    array = array3;
                }
                return array;
            }
        }

        // Token: 0x06000153 RID: 339 RVA: 0x0002BE68 File Offset: 0x0002A068
        public byte[] WriteFalconVCD(BmsStructs.VehicleClassDataType[] VCD)
        {
            byte[] array = new byte[1];
            int num = 0;
            
            Array bytes = BitConverter.GetBytes(VCD.Length);
            Array.Resize<byte>(ref array, 2);
            Array.Copy(bytes, 0, array, num, 2);
            checked
            {
                num += 2;
                int num2 = VCD.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    byte[] array2 = this.WriteVCD(VCD[i]);
                    Array.Resize<byte>(ref array, array.Length + array2.Length);
                    Array.Copy(array2, 0, array, num, array2.Length);
                    num += array2.Length;
                }
                return array;
            }
        }

        // Token: 0x06000154 RID: 340 RVA: 0x0002BEE8 File Offset: 0x0002A0E8
        public byte[] WriteVCD(BmsStructs.VehicleClassDataType VCD)
        {
            byte[] array = new byte[1];
            int num = 0;
            
            Array bytes = BitConverter.GetBytes(VCD.Index);
            Array.Resize<byte>(ref array, 2);
            Array.Copy(bytes, 0, array, num, 2);
            checked
            {
                num += 2;
                Array bytes2 = BitConverter.GetBytes(VCD.HitPoints);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes2, 0, array, num, 2);
                num += 2;
                Array bytes3 = BitConverter.GetBytes(VCD.Flags);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes3, 0, array, num, 4);
                num += 4;
                Array.Resize<char>(ref VCD.Name, 15);
                int num2 = VCD.Name.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(VCD.Name[i]);
                    num++;
                }
                Array.Resize<char>(ref VCD.NCTR, 5);
                int num3 = VCD.NCTR.Length - 1;
                for (int j = 0; j <= num3; j++)
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(VCD.NCTR[j]);
                    num++;
                }
                Array bytes4 = BitConverter.GetBytes(VCD.RCSfactor);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes4, 0, array, num, 4);
                num += 4;
                Array bytes5 = BitConverter.GetBytes(VCD.MaxWt);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes5, 0, array, num, 4);
                num += 4;
                Array bytes6 = BitConverter.GetBytes(VCD.EmptyWt);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes6, 0, array, num, 4);
                num += 4;
                Array bytes7 = BitConverter.GetBytes(VCD.FuelWt);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes7, 0, array, num, 4);
                num += 4;
                Array bytes8 = BitConverter.GetBytes(VCD.FuelEcon);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes8, 0, array, num, 2);
                num += 2;
                Array bytes9 = BitConverter.GetBytes(VCD.EngineSound);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes9, 0, array, num, 2);
                num += 2;
                Array bytes10 = BitConverter.GetBytes(VCD.HighAlt);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes10, 0, array, num, 2);
                num += 2;
                Array bytes11 = BitConverter.GetBytes(VCD.LowAlt);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes11, 0, array, num, 2);
                num += 2;
                Array bytes12 = BitConverter.GetBytes(VCD.CruiseAlt);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes12, 0, array, num, 2);
                num += 2;
                Array bytes13 = BitConverter.GetBytes(VCD.MaxSpeed);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes13, 0, array, num, 2);
                num += 2;
                Array bytes14 = BitConverter.GetBytes(VCD.RadarType);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes14, 0, array, num, 2);
                num += 2;
                Array bytes15 = BitConverter.GetBytes(VCD.NumberOfPilots);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes15, 0, array, num, 2);
                num += 2;
                Array bytes16 = BitConverter.GetBytes(VCD.RackFlags);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes16, 0, array, num, 2);
                num += 2;
                Array bytes17 = BitConverter.GetBytes(VCD.VisibleFlags);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes17, 0, array, num, 2);
                num += 2;
                Array.Resize<byte>(ref array, array.Length + 1);
                array[num] = Convert.ToByte(VCD.CallsignIndex);
                num++;
                Array.Resize<byte>(ref array, array.Length + 1);
                array[num] = Convert.ToByte(VCD.CallsignSlots);
                num++;
                int num4 = 0;
                do
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(VCD.HitChance[num4]);
                    num++;
                    num4++;
                }
                while (num4 <= 7);
                int num5 = 0;
                do
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(VCD.Strength[num5]);
                    num++;
                    num5++;
                }
                while (num5 <= 7);
                int num6 = 0;
                do
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(VCD.Range[num6]);
                    num++;
                    num6++;
                }
                while (num6 <= 7);
                int num7 = 0;
                do
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(VCD.Detection[num7]);
                    num++;
                    num7++;
                }
                while (num7 <= 7);
                int num8 = Constants.HARDPOINTS_MAX - 1;
                for (int k = 0; k <= num8; k++)
                {
                    Array bytes18 = BitConverter.GetBytes(VCD.Weapon[k]);
                    Array.Resize<byte>(ref array, array.Length + 2);
                    Array.Copy(bytes18, 0, array, num, 2);
                    num += 2;
                }
                int num9 = Constants.HARDPOINTS_MAX - 1;
                for (int l = 0; l <= num9; l++)
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(VCD.Weapons[l]);
                    num++;
                }
                int num10 = 0;
                do
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = Convert.ToByte(VCD.DamageMod[num10]);
                    num++;
                    num10++;
                }
                while (num10 <= 10);
                Array.Resize<byte>(ref array, array.Length + 3);
                num += 3;
                return array;
            }
        }

        // Token: 0x06000155 RID: 341 RVA: 0x0002C430 File Offset: 0x0002A630
        public BmsStructs.VehicleClassDataType[] ReadXmlVCD(string VehicleTableFilePath, ref int LastVcd)
        {
            checked
            {
                BmsStructs.VehicleClassDataType[] array;
                if (!File.Exists(VehicleTableFilePath))
                {
                    array = null;
                }
                else
                {
                    BmsStructs.VehicleClassDataType[] array2 = new BmsStructs.VehicleClassDataType[0];
                    
                    DateTime now = DateTime.Now;
                    using (XmlReader xmlReader = XmlReader.Create(VehicleTableFilePath))
                    {
                        int num = 0;
                        while (xmlReader.Read())
                        {
                            
                            if (xmlReader.IsStartElement() && Operators.CompareString(xmlReader.Name, "VCDRecords", false) != 0 && Operators.CompareString(xmlReader.Name, "VCD", false) == 0)
                            {
                                string text = xmlReader["Num"];
                                LastVcd = Conversions.ToInteger(text);
                                num++;
                                Array.Resize<BmsStructs.VehicleClassDataType>(ref array2, num);
                                Array.Resize<byte>(ref array2[num - 1].HitChance, 8);
                                Array.Resize<byte>(ref array2[num - 1].Strength, 8);
                                Array.Resize<byte>(ref array2[num - 1].Range, 8);
                                Array.Resize<byte>(ref array2[num - 1].Detection, 8);
                                Array.Resize<short>(ref array2[num - 1].Weapon, Constants.HARDPOINTS_MAX);
                                Array.Resize<byte>(ref array2[num - 1].Weapons, Constants.HARDPOINTS_MAX);
                                Array.Resize<byte>(ref array2[num - 1].DamageMod, 11);
                                array2[num - 1].Description = "";
                            }
                            if (xmlReader.NodeType == XmlNodeType.Element)
                            {
                                string name = xmlReader.Name;
                                xmlReader.Read();
                                string text2 = ((string.IsNullOrEmpty(xmlReader.Value) || xmlReader.Value.Contains(Environment.NewLine)) ? "" : xmlReader.Value);
                                if (Operators.CompareString(name, "CtIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].Index = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "HitPoints", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].HitPoints = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "Flags", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].Flags = Conversions.ToUInteger(text2);
                                }
                                if (Operators.CompareString(name, "Name", false) == 0)
                                {
                                    string text3 = Strings.Trim(text2);
                                    array2[num - 1].Name = Conversions.ToCharArrayRankOne(text3);
                                }
                                if (Operators.CompareString(name, "NCTR", false) == 0)
                                {
                                    string text4 = Strings.Trim(text2);
                                    if (text4.Length <= 5)
                                    {
                                        array2[num - 1].NCTR = Conversions.ToCharArrayRankOne(text4);
                                    }
                                    else
                                    {
                                        array2[num - 1].NCTR = Conversions.ToCharArrayRankOne(Strings.Mid(text4, 1, 5));
                                    }
                                }
                                if (Operators.CompareString(name, "RadarCs", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].RCSfactor = Conversions.ToSingle(text2);
                                }
                                if (Operators.CompareString(name, "MaxWeight", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].MaxWt = Conversions.ToLong(text2);
                                }
                                if (Operators.CompareString(name, "EmptyWeight", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].EmptyWt = Conversions.ToLong(text2);
                                }
                                if (Operators.CompareString(name, "FuelWeight", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].FuelWt = Conversions.ToLong(text2);
                                }
                                if (Operators.CompareString(name, "FuelRate", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].FuelEcon = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "EngineSound", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].EngineSound = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "MaxAlt", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].HighAlt = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "MinAlt", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].LowAlt = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "CruiseAlt", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].CruiseAlt = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "MaxSpeed", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].MaxSpeed = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "RadarIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].RadarType = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "NumberOfCrew", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].NumberOfPilots = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "RackFlags", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].RackFlags = Conversions.ToUShort(text2);
                                }
                                if (Operators.CompareString(name, "VisibleFlags", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].VisibleFlags = Conversions.ToUShort(text2);
                                }
                                if (Operators.CompareString(name, "CallsignIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].CallsignIndex = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "CallsignSlots", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].CallsignSlots = Conversions.ToByte(text2);
                                }
                                int num2 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "Hit_" + BmsUtils.MoveTypeText(num2), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].HitChance[num2] = Conversions.ToByte(text2);
                                    }
                                    num2++;
                                }
                                while (num2 <= 7);
                                int num3 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "Str_" + BmsUtils.MoveTypeText(num3), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].Strength[num3] = Conversions.ToByte(text2);
                                    }
                                    num3++;
                                }
                                while (num3 <= 7);
                                int num4 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "Rng_" + BmsUtils.MoveTypeText(num4), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].Range[num4] = Conversions.ToByte(text2);
                                    }
                                    num4++;
                                }
                                while (num4 <= 7);
                                int num5 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "Det_" + BmsUtils.MoveTypeText(num5), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].Detection[num5] = Conversions.ToByte(text2);
                                    }
                                    num5++;
                                }
                                while (num5 <= 7);
                                int num6 = Constants.HARDPOINTS_MAX - 1;
                                for (int i = 0; i <= num6; i++)
                                {
                                    if (Operators.CompareString(name, "WpnOrHpIdx_" + Conversions.ToString(i), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].Weapon[i] = Conversions.ToShort(text2);
                                    }
                                }
                                int num7 = Constants.HARDPOINTS_MAX - 1;
                                for (int j = 0; j <= num7; j++)
                                {
                                    if (Operators.CompareString(name, "WpnCount_" + Conversions.ToString(j), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].Weapons[j] = Conversions.ToByte(text2);
                                    }
                                }
                                int num8 = 0;
                                do
                                {
                                    string text5;
                                    if (num8 == 0)
                                    {
                                        text5 = "None";
                                    }
                                    else
                                    {
                                        text5 = BmsUtils.DamageDataTypeText(num8);
                                        text5 = text5.Replace("Dam", "");
                                    }
                                    if (Operators.CompareString(name, "Dam_" + text5, false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        array2[num - 1].DamageMod[num8] = Conversions.ToByte(text2);
                                    }
                                    num8++;
                                }
                                while (num8 <= 10);
                                if (Operators.CompareString(name, "PtType", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].ptType = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "Description", false) == 0)
                                {
                                    string text6 = Strings.Trim(text2);
                                    array2[num - 1].Description = text6;
                                }
                                if (Operators.CompareString(name, "InServiceStart", false) == 0)
                                {
                                    array2[num - 1].InServiceStart = Conversions.ToUShort(Strings.Trim(text2));
                                }
                                if (Operators.CompareString(name, "InServiceEnd", false) == 0)
                                {
                                    array2[num - 1].InServiceEnd = Conversions.ToUShort(Strings.Trim(text2));
                                }
                            }
                        }
                    }
                    
                    array = array2;
                }
                return array;
            }
        }

        // Token: 0x06000156 RID: 342 RVA: 0x0002CD0C File Offset: 0x0002AF0C
        public BmsStructs.VehicleClassDataType ReadXmlVCD_Single(string VehicleFilePath)
        {
            checked
            {
                BmsStructs.VehicleClassDataType vehicleClassDataType;
                if (!File.Exists(VehicleFilePath))
                {
                    vehicleClassDataType = default(BmsStructs.VehicleClassDataType);
                }
                else
                {
                    BmsStructs.VehicleClassDataType vehicleClassDataType2 = default(BmsStructs.VehicleClassDataType);
                    
                    vehicleClassDataType2.HitChance = null;
                    vehicleClassDataType2.Strength = null;
                    vehicleClassDataType2.Range = null;
                    vehicleClassDataType2.Detection = null;
                    vehicleClassDataType2.Weapon = null;
                    vehicleClassDataType2.Weapons = null;
                    vehicleClassDataType2.DamageMod = null;
                    using (XmlReader xmlReader = XmlReader.Create(VehicleFilePath))
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.IsStartElement() && Operators.CompareString(xmlReader.Name, "VCDRecords", false) != 0 && Operators.CompareString(xmlReader.Name, "VCD", false) == 0)
                            {
                                string text = xmlReader["Num"];
                                int num = 0;
                                num++;
                                Array.Resize<byte>(ref vehicleClassDataType2.HitChance, 8);
                                Array.Resize<byte>(ref vehicleClassDataType2.Strength, 8);
                                Array.Resize<byte>(ref vehicleClassDataType2.Range, 8);
                                Array.Resize<byte>(ref vehicleClassDataType2.Detection, 8);
                                Array.Resize<short>(ref vehicleClassDataType2.Weapon, Constants.HARDPOINTS_MAX);
                                Array.Resize<byte>(ref vehicleClassDataType2.Weapons, Constants.HARDPOINTS_MAX);
                                Array.Resize<byte>(ref vehicleClassDataType2.DamageMod, 11);
                                vehicleClassDataType2.Description = "";
                            }
                            if (xmlReader.NodeType == XmlNodeType.Element)
                            {
                                string name = xmlReader.Name;
                                xmlReader.Read();
                                string text2 = ((string.IsNullOrEmpty(xmlReader.Value) || xmlReader.Value.Contains(Environment.NewLine)) ? "" : xmlReader.Value);
                                if (Operators.CompareString(name, "CtIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.Index = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "HitPoints", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.HitPoints = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "Flags", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.Flags = Conversions.ToUInteger(text2);
                                }
                                if (Operators.CompareString(name, "Name", false) == 0)
                                {
                                    string text3 = Strings.Trim(text2);
                                    vehicleClassDataType2.Name = Conversions.ToCharArrayRankOne(text3);
                                }
                                if (Operators.CompareString(name, "NCTR", false) == 0)
                                {
                                    string text4 = Strings.Trim(text2);
                                    if (text4.Length <= 5)
                                    {
                                        vehicleClassDataType2.NCTR = Conversions.ToCharArrayRankOne(text4);
                                    }
                                    else
                                    {
                                        vehicleClassDataType2.NCTR = Conversions.ToCharArrayRankOne(Strings.Mid(text4, 1, 5));
                                    }
                                }
                                if (Operators.CompareString(name, "RadarCs", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.RCSfactor = Conversions.ToSingle(text2);
                                }
                                if (Operators.CompareString(name, "MaxWeight", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.MaxWt = Conversions.ToLong(text2);
                                }
                                if (Operators.CompareString(name, "EmptyWeight", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.EmptyWt = Conversions.ToLong(text2);
                                }
                                if (Operators.CompareString(name, "FuelWeight", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.FuelWt = Conversions.ToLong(text2);
                                }
                                if (Operators.CompareString(name, "FuelRate", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.FuelEcon = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "EngineSound", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.EngineSound = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "MaxAlt", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.HighAlt = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "MinAlt", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.LowAlt = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "CruiseAlt", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.CruiseAlt = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "MaxSpeed", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.MaxSpeed = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "RadarIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.RadarType = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "NumberOfCrew", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.NumberOfPilots = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "RackFlags", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.RackFlags = Conversions.ToUShort(text2);
                                }
                                if (Operators.CompareString(name, "VisibleFlags", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.VisibleFlags = Conversions.ToUShort(text2);
                                }
                                if (Operators.CompareString(name, "CallsignIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.CallsignIndex = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "CallsignSlots", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.CallsignSlots = Conversions.ToByte(text2);
                                }
                                int num2 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "Hit_" + BmsUtils.MoveTypeText(num2), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        vehicleClassDataType2.HitChance[num2] = Conversions.ToByte(text2);
                                    }
                                    num2++;
                                }
                                while (num2 <= 7);
                                int num3 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "Str_" + BmsUtils.MoveTypeText(num3), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        vehicleClassDataType2.Strength[num3] = Conversions.ToByte(text2);
                                    }
                                    num3++;
                                }
                                while (num3 <= 7);
                                int num4 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "Rng_" + BmsUtils.MoveTypeText(num4), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        vehicleClassDataType2.Range[num4] = Conversions.ToByte(text2);
                                    }
                                    num4++;
                                }
                                while (num4 <= 7);
                                int num5 = 0;
                                do
                                {
                                    if (Operators.CompareString(name, "Det_" + BmsUtils.MoveTypeText(num5), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        vehicleClassDataType2.Detection[num5] = Conversions.ToByte(text2);
                                    }
                                    num5++;
                                }
                                while (num5 <= 7);
                                int num6 = Constants.HARDPOINTS_MAX - 1;
                                for (int i = 0; i <= num6; i++)
                                {
                                    if (Operators.CompareString(name, "WpnOrHpIdx_" + Conversions.ToString(i), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        vehicleClassDataType2.Weapon[i] = Conversions.ToShort(text2);
                                    }
                                }
                                int num7 = Constants.HARDPOINTS_MAX - 1;
                                for (int j = 0; j <= num7; j++)
                                {
                                    if (Operators.CompareString(name, "WpnCount_" + Conversions.ToString(j), false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        vehicleClassDataType2.Weapons[j] = Conversions.ToByte(text2);
                                    }
                                }
                                int num8 = 0;
                                do
                                {
                                    string text5;
                                    if (num8 == 0)
                                    {
                                        text5 = "None";
                                    }
                                    else
                                    {
                                        text5 = BmsUtils.DamageDataTypeText(num8);
                                        text5 = text5.Replace("Dam", "");
                                    }
                                    if (Operators.CompareString(name, "Dam_" + text5, false) == 0 && Versioned.IsNumeric(text2))
                                    {
                                        vehicleClassDataType2.DamageMod[num8] = Conversions.ToByte(text2);
                                    }
                                    num8++;
                                }
                                while (num8 <= 10);
                                if (Operators.CompareString(name, "PtType", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    vehicleClassDataType2.ptType = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "Description", false) == 0)
                                {
                                    string text6 = Strings.Trim(text2);
                                    vehicleClassDataType2.Description = text6;
                                }
                                if (Operators.CompareString(name, "InServiceStart", false) == 0)
                                {
                                    vehicleClassDataType2.InServiceStart = Conversions.ToUShort(Strings.Trim(text2));
                                }
                                if (Operators.CompareString(name, "InServiceEnd", false) == 0)
                                {
                                    vehicleClassDataType2.InServiceEnd = Conversions.ToUShort(Strings.Trim(text2));
                                }
                            }
                        }
                    }
                    vehicleClassDataType = vehicleClassDataType2;
                }
                return vehicleClassDataType;
            }
        }

        // Token: 0x06000157 RID: 343 RVA: 0x0002D4B8 File Offset: 0x0002B6B8
        private BmsStructs.VehicleClassDataType[] ReadXmlAsString(string fName)
        {
            FileStream fileStream = new FileStream(fName, FileMode.Open);
            StreamReader streamReader = new StreamReader(fileStream);
            BmsStructs.VehicleClassDataType[] array = new BmsStructs.VehicleClassDataType[0];
            
            DateTime now = DateTime.Now;
            checked
            {
                try
                {
                    while (!streamReader.EndOfStream)
                    {
                        string text = streamReader.ReadLine();
                        if (Strings.InStr(Strings.LCase(text), "<vcd num=", CompareMethod.Binary) > 0)
                        {
                            int num = 0;
                            num++;
                            Array.Resize<BmsStructs.VehicleClassDataType>(ref array, num);
                            Array.Resize<byte>(ref array[num - 1].HitChance, 8);
                            Array.Resize<byte>(ref array[num - 1].Strength, 8);
                            Array.Resize<byte>(ref array[num - 1].Range, 8);
                            Array.Resize<byte>(ref array[num - 1].Detection, 8);
                            Array.Resize<short>(ref array[num - 1].Weapon, Constants.HARDPOINTS_MAX);
                            Array.Resize<byte>(ref array[num - 1].Weapons, Constants.HARDPOINTS_MAX);
                            Array.Resize<byte>(ref array[num - 1].DamageMod, 11);
                            array[num - 1].Description = "";
                        }
                        else
                        {
                            string name = this.GetName(text);
                            string value = this.GetValue(text);
                            int num = 0; ;
                            if (Operators.CompareString(name, "CtIdx", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].Index = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "HitPoints", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].HitPoints = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "Flags", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].Flags = Conversions.ToUInteger(value);
                            }
                            if (Operators.CompareString(name, "Name", false) == 0)
                            {
                                string text2 = Strings.Trim(value);
                                array[num - 1].Name = Conversions.ToCharArrayRankOne(text2);
                            }
                            if (Operators.CompareString(name, "NCTR", false) == 0)
                            {
                                string text3 = Strings.Trim(value);
                                if (text3.Length <= 5)
                                {
                                    array[num - 1].NCTR = Conversions.ToCharArrayRankOne(text3);
                                }
                                else
                                {
                                    array[num - 1].NCTR = Conversions.ToCharArrayRankOne(Strings.Mid(text3, 1, 5));
                                }
                            }
                            if (Operators.CompareString(name, "RadarCs", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].RCSfactor = Conversions.ToSingle(value);
                            }
                            if (Operators.CompareString(name, "MaxWeight", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].MaxWt = Conversions.ToLong(value);
                            }
                            if (Operators.CompareString(name, "EmptyWeight", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].EmptyWt = Conversions.ToLong(value);
                            }
                            if (Operators.CompareString(name, "FuelWeight", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].FuelWt = Conversions.ToLong(value);
                            }
                            if (Operators.CompareString(name, "FuelRate", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].FuelEcon = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "EngineSound", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].EngineSound = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "MaxAlt", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].HighAlt = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "MinAlt", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].LowAlt = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "CruiseAlt", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].CruiseAlt = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "MaxSpeed", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].MaxSpeed = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "RadarIdx", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].RadarType = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "NumberOfCrew", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].NumberOfPilots = Conversions.ToShort(value);
                            }
                            if (Operators.CompareString(name, "RackFlags", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].RackFlags = Conversions.ToUShort(value);
                            }
                            if (Operators.CompareString(name, "VisibleFlags", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].VisibleFlags = Conversions.ToUShort(value);
                            }
                            if (Operators.CompareString(name, "CallsignIdx", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].CallsignIndex = Conversions.ToByte(value);
                            }
                            if (Operators.CompareString(name, "CallsignSlots", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].CallsignSlots = Conversions.ToByte(value);
                            }
                            int num2 = 0;
                            do
                            {
                                if (Operators.CompareString(name, "Hit_" + BmsUtils.MoveTypeText(num2), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].HitChance[num2] = Conversions.ToByte(value);
                                }
                                num2++;
                            }
                            while (num2 <= 7);
                            int num3 = 0;
                            do
                            {
                                if (Operators.CompareString(name, "Str_" + BmsUtils.MoveTypeText(num3), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].Strength[num3] = Conversions.ToByte(value);
                                }
                                num3++;
                            }
                            while (num3 <= 7);
                            int num4 = 0;
                            do
                            {
                                if (Operators.CompareString(name, "Rng_" + BmsUtils.MoveTypeText(num4), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].Range[num4] = Conversions.ToByte(value);
                                }
                                num4++;
                            }
                            while (num4 <= 7);
                            int num5 = 0;
                            do
                            {
                                if (Operators.CompareString(name, "Det_" + BmsUtils.MoveTypeText(num5), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].Detection[num5] = Conversions.ToByte(value);
                                }
                                num5++;
                            }
                            while (num5 <= 7);
                            int num6 = Constants.HARDPOINTS_MAX - 1;
                            for (int i = 0; i <= num6; i++)
                            {
                                if (Operators.CompareString(name, "WpnOrHpIdx_" + Conversions.ToString(i), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].Weapon[i] = Conversions.ToShort(value);
                                }
                            }
                            int num7 = Constants.HARDPOINTS_MAX - 1;
                            for (int j = 0; j <= num7; j++)
                            {
                                if (Operators.CompareString(name, "WpnCount_" + Conversions.ToString(j), false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].Weapons[j] = Conversions.ToByte(value);
                                }
                            }
                            int num8 = 0;
                            do
                            {
                                string text4;
                                if (num8 == 0)
                                {
                                    text4 = "None";
                                }
                                else
                                {
                                    text4 = BmsUtils.DamageDataTypeText(num8);
                                    text4 = text4.Replace("Dam", "");
                                }
                                if (Operators.CompareString(name, "Dam_" + text4, false) == 0 && Versioned.IsNumeric(value))
                                {
                                    array[num - 1].DamageMod[num8] = Conversions.ToByte(value);
                                }
                                num8++;
                            }
                            while (num8 <= 10);
                            if (Operators.CompareString(name, "PtType", false) == 0 && Versioned.IsNumeric(value))
                            {
                                array[num - 1].ptType = Conversions.ToByte(value);
                            }
                            if (Operators.CompareString(name, "Description", false) == 0)
                            {
                                string text5 = Strings.Trim(value);
                                array[num - 1].Description = text5;
                            }
                            if (Operators.CompareString(name, "InServiceStart", false) == 0)
                            {
                                array[num - 1].InServiceStart = Conversions.ToUShort(Strings.Trim(value));
                            }
                            if (Operators.CompareString(name, "InServiceEnd", false) == 0)
                            {
                                array[num - 1].InServiceEnd = Conversions.ToUShort(Strings.Trim(value));
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

        // Token: 0x06000158 RID: 344 RVA: 0x0002DD58 File Offset: 0x0002BF58
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

        // Token: 0x06000159 RID: 345 RVA: 0x0002DDB4 File Offset: 0x0002BFB4
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

        // Token: 0x0600015A RID: 346 RVA: 0x0002DE24 File Offset: 0x0002C024
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

        // Token: 0x0600015B RID: 347 RVA: 0x0002DEA0 File Offset: 0x0002C0A0
        public bool WriteXmlVCD(BmsStructs.VehicleClassDataType[] VehicleDataEntries, string fName)
        {
            checked
            {
                bool flag;
                if (VehicleDataEntries == null)
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
                        NumberFormatInfo numberFormat = new CultureInfo("en-US", false).NumberFormat;
                        
                        XmlWriter xmlWriter2 = xmlWriter;
                        xmlWriter2.WriteStartDocument();
                        xmlWriter2.WriteStartElement("VCDRecords");
                        int num = VehicleDataEntries.Length - 1;
                        for (int i = 0; i <= num; i++)
                        {
                            string text2 = new string(VehicleDataEntries[i].Name);
                            text2 = text2.Replace('\0', ' ');
                            text2 = Strings.Trim(text2);
                            if (Operators.CompareString(text2, null, false) == 0)
                            {
                                if (i != 0)
                                {
                                    text2 = "Empty slot";
                                }
                                else
                                {
                                    text2 = " ";
                                }
                            }
                            string text3 = new string(VehicleDataEntries[i].NCTR);
                            text3 = text3.Replace('\0', ' ');
                            text3 = Strings.Trim(text3);
                            if (Operators.CompareString(text3, null, false) == 0)
                            {
                                text3 = " ";
                            }
                            xmlWriter2.WriteStartElement("VCD");
                            xmlWriter2.WriteAttributeString("Num", Conversions.ToString(i));
                            xmlWriter2.WriteElementString("CtIdx", VehicleDataEntries[i].Index.ToString());
                            xmlWriter2.WriteElementString("HitPoints", VehicleDataEntries[i].HitPoints.ToString());
                            xmlWriter2.WriteElementString("Flags", VehicleDataEntries[i].Flags.ToString());
                            xmlWriter2.WriteElementString("Name", text2);
                            xmlWriter2.WriteElementString("NCTR", text3);
                            numberFormat.NumberDecimalDigits = 6;
                            double num2 = Math.Pow(10.0, (double)numberFormat.NumberDecimalDigits);
                            double num3 = (double)VehicleDataEntries[i].RCSfactor;
                            int num4;
                            unchecked
                            {
                                num3 *= num2;
                                num3 = Math.Round(num3, MidpointRounding.AwayFromZero);
                                xmlWriter2.WriteElementString("RadarCs", (num3 / num2).ToString("F", numberFormat));
                                xmlWriter2.WriteElementString("MaxWeight", VehicleDataEntries[i].MaxWt.ToString());
                                xmlWriter2.WriteElementString("EmptyWeight", VehicleDataEntries[i].EmptyWt.ToString());
                                xmlWriter2.WriteElementString("FuelWeight", VehicleDataEntries[i].FuelWt.ToString());
                                xmlWriter2.WriteElementString("FuelRate", VehicleDataEntries[i].FuelEcon.ToString());
                                xmlWriter2.WriteElementString("EngineSound", VehicleDataEntries[i].EngineSound.ToString());
                                xmlWriter2.WriteElementString("MaxAlt", VehicleDataEntries[i].HighAlt.ToString());
                                xmlWriter2.WriteElementString("MinAlt", VehicleDataEntries[i].LowAlt.ToString());
                                xmlWriter2.WriteElementString("CruiseAlt", VehicleDataEntries[i].CruiseAlt.ToString());
                                xmlWriter2.WriteElementString("MaxSpeed", VehicleDataEntries[i].MaxSpeed.ToString());
                                xmlWriter2.WriteElementString("RadarIdx", VehicleDataEntries[i].RadarType.ToString());
                                xmlWriter2.WriteElementString("NumberOfCrew", VehicleDataEntries[i].NumberOfPilots.ToString());
                                xmlWriter2.WriteElementString("RackFlags", VehicleDataEntries[i].RackFlags.ToString());
                                xmlWriter2.WriteElementString("VisibleFlags", VehicleDataEntries[i].VisibleFlags.ToString());
                                xmlWriter2.WriteElementString("CallsignIdx", VehicleDataEntries[i].CallsignIndex.ToString());
                                xmlWriter2.WriteElementString("CallsignSlots", VehicleDataEntries[i].CallsignSlots.ToString());
                                num4 = 0;
                            }
                            do
                            {
                                xmlWriter2.WriteElementString("Hit_" + BmsUtils.MoveTypeText(num4), VehicleDataEntries[i].HitChance[num4].ToString());
                                num4++;
                            }
                            while (num4 <= 7);
                            int num5 = 0;
                            do
                            {
                                xmlWriter2.WriteElementString("Str_" + BmsUtils.MoveTypeText(num5), VehicleDataEntries[i].Strength[num5].ToString());
                                num5++;
                            }
                            while (num5 <= 7);
                            int num6 = 0;
                            do
                            {
                                xmlWriter2.WriteElementString("Rng_" + BmsUtils.MoveTypeText(num6), VehicleDataEntries[i].Range[num6].ToString());
                                num6++;
                            }
                            while (num6 <= 7);
                            int num7 = 0;
                            do
                            {
                                xmlWriter2.WriteElementString("Det_" + BmsUtils.MoveTypeText(num7), VehicleDataEntries[i].Detection[num7].ToString());
                                num7++;
                            }
                            while (num7 <= 7);
                            int num8 = Constants.HARDPOINTS_MAX - 1;
                            for (int j = 0; j <= num8; j++)
                            {
                                if (VehicleDataEntries[i].Weapon[j] != 0)
                                {
                                    xmlWriter2.WriteElementString("WpnOrHpIdx_" + Conversions.ToString(j), VehicleDataEntries[i].Weapon[j].ToString());
                                }
                            }
                            int num9 = Constants.HARDPOINTS_MAX - 1;
                            for (int k = 0; k <= num9; k++)
                            {
                                if ((VehicleDataEntries[i].Weapons[k] > 0) & (VehicleDataEntries[i].Weapon[k] != 0))
                                {
                                    xmlWriter2.WriteElementString("WpnCount_" + Conversions.ToString(k), VehicleDataEntries[i].Weapons[k].ToString());
                                }
                            }
                            int num10 = 0;
                            do
                            {
                                string text4;
                                if (num10 == 0)
                                {
                                    text4 = "None";
                                }
                                else
                                {
                                    text4 = BmsUtils.DamageDataTypeText(num10).Replace("Dam", "").ToString();
                                }
                                xmlWriter2.WriteElementString("Dam_" + text4, VehicleDataEntries[i].DamageMod[num10].ToString());
                                num10++;
                            }
                            while (num10 <= 10);
                            xmlWriter2.WriteElementString("PtType", VehicleDataEntries[i].ptType.ToString());
                            if (Operators.CompareString(VehicleDataEntries[i].Description, "", false) != 0)
                            {
                                xmlWriter2.WriteElementString("Description", VehicleDataEntries[i].Description.ToString());
                            }
                            if (VehicleDataEntries[i].InServiceStart != 0)
                            {
                                xmlWriter2.WriteElementString("InServiceStart", VehicleDataEntries[i].InServiceStart.ToString());
                            }
                            if ((VehicleDataEntries[i].InServiceEnd > 0) & (VehicleDataEntries[i].InServiceEnd < 9999))
                            {
                                xmlWriter2.WriteElementString("InServiceEnd", VehicleDataEntries[i].InServiceEnd.ToString());
                            }
                            xmlWriter2.WriteEndElement();
                        }
                        xmlWriter2.WriteEndDocument();
                        xmlWriter2.Close();
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

    }
}
