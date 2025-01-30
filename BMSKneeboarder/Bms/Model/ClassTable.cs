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
    public class ClassTable
    {
        // Token: 0x06000063 RID: 99 RVA: 0x0000B728 File Offset: 0x00009928
        public BmsStructs.EntityClassType[] LoadCT(string DefaultDir, string fName, ref bool ReadXML)
        {
            BmsStructs.EntityClassType[] array = null;
            if (ReadXML)
            {
                if (File.Exists(fName))
                {
                    array = this.ReadXmlCt_DOM(fName);
                }
                else
                {
                    fName = Strings.LCase(fName);
                    fName = fName.Replace("falcon4_ct.xml", "falcon4.ct");
                    if (File.Exists(fName))
                    {
                        array = this.ReadClassTable(fName);
                        ReadXML = false;
                    }
                    else
                    {
                        fName = DefaultDir + "falcon4_ct.xml";
                        if (File.Exists(fName))
                        {
                            array = this.ReadXmlCt_DOM(fName);
                        }
                        else
                        {
                            fName = Strings.LCase(fName);
                            fName = fName.Replace("falcon4_ct.xml", "falcon4.ct");
                            if (File.Exists(fName))
                            {
                                array = this.ReadClassTable(fName);
                                ReadXML = false;
                            }
                        }
                    }
                }
            }
            else if (File.Exists(fName))
            {
                array = this.ReadClassTable(fName);
            }
            else
            {
                fName = DefaultDir + "falcon4.ct";
                if (File.Exists(fName))
                {
                    array = this.ReadClassTable(fName);
                }
            }
            return array;
        }

        // Token: 0x06000064 RID: 100 RVA: 0x0000B804 File Offset: 0x00009A04
        public bool SaveCT(BmsStructs.EntityClassType[] classTableEntries, string fName, ref bool ReadXml)
        {
            bool flag = false;
            bool flag2;
            if (Information.IsNothing(classTableEntries))
            {
                flag2 = false;
            }
            else
            {
                if (ReadXml)
                {
                    flag = this.WriteXmlCT(classTableEntries, fName);
                }
                else
                {
                    byte[] array = new byte[1];
                    array = this.WriteClassTable(classTableEntries);
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

        // Token: 0x06000065 RID: 101 RVA: 0x0000B898 File Offset: 0x00009A98
        public BmsStructs.EntityClassType CopyFalcon4EntityClassType(ref BmsStructs.EntityClassType src)
        {
            BmsStructs.EntityClassType falcon4EntityClassType;
            falcon4EntityClassType.dataPtr = src.dataPtr;
            falcon4EntityClassType.dataType = src.dataType;
            falcon4EntityClassType.vehicleDataIndex = src.vehicleDataIndex;
            checked
            {
                falcon4EntityClassType.visType = new short[src.visType.Count<short>() - 1 + 1];
                Array.Copy(src.visType, falcon4EntityClassType.visType, src.visType.Length);
                falcon4EntityClassType.vuClassData.classInfo_ = new byte[src.vuClassData.classInfo_.Count<byte>() - 1 + 1];
                Array.Copy(src.vuClassData.classInfo_, falcon4EntityClassType.vuClassData.classInfo_, src.vuClassData.classInfo_.Length);
                falcon4EntityClassType.vuClassData.collidable_ = src.vuClassData.collidable_;
                falcon4EntityClassType.vuClassData.collisionRadius_ = src.vuClassData.collisionRadius_;
                falcon4EntityClassType.vuClassData.collisionType_ = src.vuClassData.collisionType_;
                falcon4EntityClassType.vuClassData.CreatePriority_ = src.vuClassData.CreatePriority_;
                falcon4EntityClassType.vuClassData.DamageSeed_ = src.vuClassData.DamageSeed_;
                falcon4EntityClassType.vuClassData.FineUpdateForceRange_ = src.vuClassData.FineUpdateForceRange_;
                falcon4EntityClassType.vuClassData.FineUpdateMultiplier_ = src.vuClassData.FineUpdateMultiplier_;
                falcon4EntityClassType.vuClassData.FineUpdateRange_ = src.vuClassData.FineUpdateRange_;
                falcon4EntityClassType.vuClassData.FType_ = src.vuClassData.FType_;
                falcon4EntityClassType.vuClassData.global_ = src.vuClassData.global_;
                falcon4EntityClassType.vuClassData.GrphBothDestroyed_ = src.vuClassData.GrphBothDestroyed_;
                falcon4EntityClassType.vuClassData.GrphDamaged_ = src.vuClassData.GrphDamaged_;
                falcon4EntityClassType.vuClassData.GrphDestroyed_ = src.vuClassData.GrphDestroyed_;
                falcon4EntityClassType.vuClassData.GrphLeftDestroyed_ = src.vuClassData.GrphLeftDestroyed_;
                falcon4EntityClassType.vuClassData.GrphNormal_ = src.vuClassData.GrphNormal_;
                falcon4EntityClassType.vuClassData.GrphRepaired_ = src.vuClassData.GrphRepaired_;
                falcon4EntityClassType.vuClassData.GrphRightDestroyed_ = src.vuClassData.GrphRightDestroyed_;
                falcon4EntityClassType.vuClassData.Hitpoints_ = src.vuClassData.Hitpoints_;
                falcon4EntityClassType.vuClassData.id_ = src.vuClassData.id_;
                falcon4EntityClassType.vuClassData.majorRevisionNumber_ = src.vuClassData.majorRevisionNumber_;
                falcon4EntityClassType.vuClassData.managementDomain_ = src.vuClassData.managementDomain_;
                falcon4EntityClassType.vuClassData.minorRevisionNumber_ = src.vuClassData.minorRevisionNumber_;
                falcon4EntityClassType.vuClassData.persistent_ = src.vuClassData.persistent_;
                falcon4EntityClassType.vuClassData.private_ = src.vuClassData.private_;
                falcon4EntityClassType.vuClassData.tangible_ = src.vuClassData.tangible_;
                falcon4EntityClassType.vuClassData.transferable_ = src.vuClassData.transferable_;
                falcon4EntityClassType.vuClassData.Unknown_ = src.vuClassData.Unknown_;
                falcon4EntityClassType.vuClassData.UpdateRate_ = src.vuClassData.UpdateRate_;
                falcon4EntityClassType.vuClassData.UpdateTolerance_ = src.vuClassData.UpdateTolerance_;
                return falcon4EntityClassType;
            }
        }

        // Token: 0x06000066 RID: 102 RVA: 0x0000BBEC File Offset: 0x00009DEC
        public BmsStructs.EntityClassType[] ReadClassTable(string classTableFilePath)
        {
            checked
            {
                BmsStructs.EntityClassType[] array;
                if (!File.Exists(classTableFilePath))
                {
                    array = null;
                }
                else
                {
                    FileStream fileStream = new FileStream(classTableFilePath, FileMode.Open, FileAccess.Read);
                    byte[] array2 = new byte[(int)fileStream.Length + 1];
                    fileStream.Read(array2, 0, (int)fileStream.Length);
                    fileStream.Close();
                    int num = 0;
                    short num2 = BitConverter.ToInt16(array2, num);
                    num += 2;
                    BmsStructs.EntityClassType[] array3 = new BmsStructs.EntityClassType[(int)(num2 - 1 + 1)];
                    int num3 = (int)(num2 - 1);
                    for (int i = 0; i <= num3; i++)
                    {
                        BmsStructs.EntityClassType falcon4EntityClassType = default(BmsStructs.EntityClassType);
                        falcon4EntityClassType.vuClassData = default(BmsStructs.VuEntityType);
                        falcon4EntityClassType.vuClassData.id_ = BitConverter.ToUInt16(array2, num);
                        num += 2;
                        falcon4EntityClassType.vuClassData.collisionType_ = BitConverter.ToUInt16(array2, num);
                        num += 2;
                        falcon4EntityClassType.vuClassData.collisionRadius_ = BitConverter.ToSingle(array2, num);
                        num += 4;
                        Array.Resize<byte>(ref falcon4EntityClassType.vuClassData.classInfo_, 8);
                        int num4 = 0;
                        do
                        {
                            falcon4EntityClassType.vuClassData.classInfo_[num4] = Buffer.GetByte(array2, num);
                            num++;
                            num4++;
                        }
                        while (num4 <= 7);
                        falcon4EntityClassType.vuClassData.UpdateRate_ = unchecked((ulong)BitConverter.ToUInt32(array2, num));
                        num += 4;
                        falcon4EntityClassType.vuClassData.UpdateTolerance_ = unchecked((ulong)BitConverter.ToUInt32(array2, num));
                        num += 4;
                        falcon4EntityClassType.vuClassData.FineUpdateRange_ = BitConverter.ToSingle(array2, num);
                        num += 4;
                        falcon4EntityClassType.vuClassData.FineUpdateForceRange_ = BitConverter.ToSingle(array2, num);
                        num += 4;
                        falcon4EntityClassType.vuClassData.FineUpdateMultiplier_ = BitConverter.ToSingle(array2, num);
                        num += 4;
                        falcon4EntityClassType.vuClassData.DamageSeed_ = BitConverter.ToUInt32(array2, num);
                        num += 4;
                        falcon4EntityClassType.vuClassData.Hitpoints_ = BitConverter.ToInt32(array2, num);
                        num += 4;
                        falcon4EntityClassType.vuClassData.majorRevisionNumber_ = BitConverter.ToUInt16(array2, num);
                        num += 2;
                        falcon4EntityClassType.vuClassData.minorRevisionNumber_ = BitConverter.ToUInt16(array2, num);
                        num += 2;
                        falcon4EntityClassType.vuClassData.CreatePriority_ = BitConverter.ToUInt16(array2, num);
                        num += 2;
                        falcon4EntityClassType.vuClassData.managementDomain_ = Buffer.GetByte(array2, num);
                        num++;
                        falcon4EntityClassType.vuClassData.transferable_ = Buffer.GetByte(array2, num) > 0;
                        num++;
                        falcon4EntityClassType.vuClassData.private_ = Buffer.GetByte(array2, num) > 0;
                        num++;
                        falcon4EntityClassType.vuClassData.tangible_ = Buffer.GetByte(array2, num) > 0;
                        num++;
                        falcon4EntityClassType.vuClassData.collidable_ = Buffer.GetByte(array2, num) > 0;
                        num++;
                        falcon4EntityClassType.vuClassData.global_ = Buffer.GetByte(array2, num) > 0;
                        num++;
                        falcon4EntityClassType.vuClassData.persistent_ = Buffer.GetByte(array2, num) > 0;
                        num++;
                        num += 3;
                        Array.Resize<short>(ref falcon4EntityClassType.visType, 7);
                        int num5 = 0;
                        do
                        {
                            falcon4EntityClassType.visType[num5] = BitConverter.ToInt16(array2, num);
                            num += 2;
                            num5++;
                        }
                        while (num5 <= 6);
                        falcon4EntityClassType.vehicleDataIndex = BitConverter.ToInt16(array2, num);
                        num += 2;
                        falcon4EntityClassType.vuClassData.FType_ = Buffer.GetByte(array2, num);
                        num++;
                        falcon4EntityClassType.dataType = BitConverter.ToInt16(array2, num);
                        num += 2;
                        falcon4EntityClassType.dataPtr = BitConverter.ToInt16(array2, num);
                        num += 2;
                        array3[i] = falcon4EntityClassType;
                    }
                    array = array3;
                }
                return array;
            }
        }

        // Token: 0x06000067 RID: 103 RVA: 0x0000BF2C File Offset: 0x0000A12C
        public byte[] WriteClassTable(BmsStructs.EntityClassType[] CT)
        {
            byte[] array = new byte[1];
            int num = 0;
            
            Array bytes = BitConverter.GetBytes(CT.Length);
            Array.Resize<byte>(ref array, 2);
            Array.Copy(bytes, 0, array, num, 2);
            checked
            {
                num += 2;
                int num2 = CT.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    byte[] array2 = this.WriteCT(CT[i]);
                    Array.Resize<byte>(ref array, array.Length + array2.Length);
                    Array.Copy(array2, 0, array, num, array2.Length);
                    num += array2.Length;
                }
                return array;
            }
        }

        // Token: 0x06000068 RID: 104 RVA: 0x0000BFAC File Offset: 0x0000A1AC
        public byte[] WriteCT(BmsStructs.EntityClassType CT)
        {
            byte[] array = new byte[1];
            int num = 0;
            
            Array bytes = BitConverter.GetBytes(CT.vuClassData.id_);
            Array.Resize<byte>(ref array, 2);
            Array.Copy(bytes, 0, array, num, 2);
            checked
            {
                num += 2;
                Array bytes2 = BitConverter.GetBytes(CT.vuClassData.collisionType_);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes2, 0, array, num, 2);
                num += 2;
                Array bytes3 = BitConverter.GetBytes(CT.vuClassData.collisionRadius_);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes3, 0, array, num, 4);
                num += 4;
                int num2 = 0;
                do
                {
                    Array.Resize<byte>(ref array, array.Length + 1);
                    array[num] = CT.vuClassData.classInfo_[num2];
                    num++;
                    num2++;
                }
                while (num2 <= 7);
                Array bytes4 = BitConverter.GetBytes(CT.vuClassData.UpdateRate_);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes4, 0, array, num, 4);
                num += 4;
                Array bytes5 = BitConverter.GetBytes(CT.vuClassData.UpdateTolerance_);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes5, 0, array, num, 4);
                num += 4;
                Array bytes6 = BitConverter.GetBytes(CT.vuClassData.FineUpdateRange_);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes6, 0, array, num, 4);
                num += 4;
                Array bytes7 = BitConverter.GetBytes(CT.vuClassData.FineUpdateForceRange_);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes7, 0, array, num, 4);
                num += 4;
                Array bytes8 = BitConverter.GetBytes(CT.vuClassData.FineUpdateMultiplier_);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes8, 0, array, num, 4);
                num += 4;
                Array bytes9 = BitConverter.GetBytes(CT.vuClassData.DamageSeed_);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes9, 0, array, num, 4);
                num += 4;
                Array bytes10 = BitConverter.GetBytes(CT.vuClassData.Hitpoints_);
                Array.Resize<byte>(ref array, array.Length + 4);
                Array.Copy(bytes10, 0, array, num, 4);
                num += 4;
                Array bytes11 = BitConverter.GetBytes(CT.vuClassData.majorRevisionNumber_);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes11, 0, array, num, 2);
                num += 2;
                Array bytes12 = BitConverter.GetBytes(CT.vuClassData.minorRevisionNumber_);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes12, 0, array, num, 2);
                num += 2;
                Array bytes13 = BitConverter.GetBytes(CT.vuClassData.CreatePriority_);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes13, 0, array, num, 2);
                num += 2;
                Array.Resize<byte>(ref array, array.Length + 1);
                array[num] = CT.vuClassData.managementDomain_;
                num++;
                Array.Resize<byte>(ref array, array.Length + 1);
                if (CT.vuClassData.transferable_)
                {
                    array[num] = 1;
                }
                else
                {
                    array[num] = 0;
                }
                num++;
                Array.Resize<byte>(ref array, array.Length + 1);
                if (CT.vuClassData.private_)
                {
                    array[num] = 1;
                }
                else
                {
                    array[num] = 0;
                }
                num++;
                Array.Resize<byte>(ref array, array.Length + 1);
                if (CT.vuClassData.tangible_)
                {
                    array[num] = 1;
                }
                else
                {
                    array[num] = 0;
                }
                num++;
                Array.Resize<byte>(ref array, array.Length + 1);
                if (CT.vuClassData.collidable_)
                {
                    array[num] = 1;
                }
                else
                {
                    array[num] = 0;
                }
                num++;
                Array.Resize<byte>(ref array, array.Length + 1);
                if (CT.vuClassData.global_)
                {
                    array[num] = 1;
                }
                else
                {
                    array[num] = 0;
                }
                num++;
                Array.Resize<byte>(ref array, array.Length + 1);
                if (CT.vuClassData.persistent_)
                {
                    array[num] = 1;
                }
                else
                {
                    array[num] = 0;
                }
                num++;
                Array.Resize<byte>(ref array, array.Length + 3);
                num += 3;
                int num3 = 0;
                do
                {
                    
                    Array bytes14 = BitConverter.GetBytes(CT.visType[num3]);
                    Array.Resize<byte>(ref array, array.Length + 2);
                    Array.Copy(bytes14, 0, array, num, 2);
                    num += 2;
                    num3++;
                }
                while (num3 <= 6);
                Array bytes15 = BitConverter.GetBytes(CT.vehicleDataIndex);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes15, 0, array, num, 2);
                num += 2;
                Array.Resize<byte>(ref array, array.Length + 1);
                array[num] = CT.vuClassData.FType_;
                num++;
                Array bytes16 = BitConverter.GetBytes(CT.dataType);
                Array.Resize<byte>(ref array, array.Length + 2);
                Array.Copy(bytes16, 0, array, num, 2);
                num += 2;
                Array.Resize<byte>(ref array, array.Length + 2);
                num += 2;
                return array;
            }
        }

        
        // Token: 0x06000069 RID: 105 RVA: 0x0000C42C File Offset: 0x0000A62C
        public BmsStructs.EntityClassType[] ReadXmlCt_DOM(string fName)
        {
            checked
            {
                BmsStructs.EntityClassType[] array;
                if (!File.Exists(fName))
                {
                    array = null;
                }
                else
                {
                    BmsStructs.EntityClassType[] array2 = new BmsStructs.EntityClassType[0];
                    XmlDocument xmlDocument = new XmlDocument();
                    DateTime now = DateTime.Now;
                    xmlDocument.Load(fName);
                    XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/CTRecords/CT");
                    int count = xmlNodeList.Count;
                    Array.Resize<BmsStructs.EntityClassType>(ref array2, count);
                    int num = array2.Length - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        Array.Resize<byte>(ref array2[i].vuClassData.classInfo_, 8);
                        Array.Resize<short>(ref array2[i].visType, 7);
                    }
                    try
                    {
                        foreach (object obj in xmlNodeList)
                        {
                            XmlNode xmlNode = (XmlNode)obj;
                            string value = xmlNode.Attributes.GetNamedItem("Num").Value;
                            int num2 = xmlNode.ChildNodes.Count - 1;
                            for (int j = 0; j <= num2; j++)
                            {
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Id", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.id_ = Conversions.ToUShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "CollisionType", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.collisionType_ = Conversions.ToUShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "CollisionRadius", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.collisionRadius_ = Conversions.ToSingle(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Domain", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.classInfo_[0] = Conversions.ToByte(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Class", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.classInfo_[1] = Conversions.ToByte(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Type", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.classInfo_[2] = Conversions.ToByte(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "SubType", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.classInfo_[3] = Conversions.ToByte(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Specific", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.classInfo_[4] = Conversions.ToByte(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Owner", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.classInfo_[5] = Conversions.ToByte(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Class_6", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.classInfo_[6] = Conversions.ToByte(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Class_7", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.classInfo_[7] = Conversions.ToByte(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "UpdateRate", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.UpdateRate_ = Conversions.ToULong(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "UpdateTolerance", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.UpdateTolerance_ = Conversions.ToULong(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "FineUpdateRange", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.FineUpdateRange_ = Conversions.ToSingle(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "FineUpdateForceRange", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.FineUpdateForceRange_ = Conversions.ToSingle(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "FineUpdateMultiplier", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.FineUpdateMultiplier_ = Conversions.ToSingle(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "DamageSeed", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.DamageSeed_ = Conversions.ToSingle(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "HitPoints", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.Hitpoints_ = Conversions.ToInteger(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "MajorRev", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.majorRevisionNumber_ = Conversions.ToUShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "MinRev", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.minorRevisionNumber_ = Conversions.ToUShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "CreatePriority", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.CreatePriority_ = Conversions.ToUShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "ManagementDomain", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.managementDomain_ = Conversions.ToByte(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Transferable", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if ((Operators.CompareString(text, "True", false) == 0) | (Operators.CompareString(text, "1", false) == 0))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.transferable_ = true;
                                    }
                                    else
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.transferable_ = false;
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Private", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if ((Operators.CompareString(text, "True", false) == 0) | (Operators.CompareString(text, "1", false) == 0))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.private_ = true;
                                    }
                                    else
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.private_ = false;
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Tangible", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if ((Operators.CompareString(text, "True", false) == 0) | (Operators.CompareString(text, "1", false) == 0))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.tangible_ = true;
                                    }
                                    else
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.tangible_ = false;
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Collidable", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if ((Operators.CompareString(text, "True", false) == 0) | (Operators.CompareString(text, "1", false) == 0))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.collidable_ = true;
                                    }
                                    else
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.collidable_ = false;
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Global", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if ((Operators.CompareString(text, "True", false) == 0) | (Operators.CompareString(text, "1", false) == 0))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.global_ = true;
                                    }
                                    else
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.global_ = false;
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "Persistent", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if ((Operators.CompareString(text, "True", false) == 0) | (Operators.CompareString(text, "1", false) == 0))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.persistent_ = true;
                                    }
                                    else
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.persistent_ = false;
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "GraphicsNormal", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].visType[0] = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "GraphicsRepaired", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].visType[1] = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "GraphicsDamaged", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].visType[2] = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "GraphicsDestroyed", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].visType[3] = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "GraphicsLeftDestroyed", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].visType[4] = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "GraphicsRightDestroyed", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].visType[5] = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "GraphicsBothDestroyed", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].visType[6] = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "MoverDefinitionData", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vehicleDataIndex = Conversions.ToShort(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "EntityType", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].vuClassData.FType_ = Conversions.ToByte(text);
                                    }
                                }
                                if (Operators.CompareString(xmlNode.ChildNodes[j].Name, "EntityIdx", false) == 0)
                                {
                                    string text = xmlNode.ChildNodes.Item(j).InnerText;
                                    if (Versioned.IsNumeric(text))
                                    {
                                        array2[Conversions.ToInteger(value)].dataType = Conversions.ToShort(text);
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                    }
                    //DateTime.Now - now;
                    array = array2;
                }
                return array;
            }
        }

        // Token: 0x0600006A RID: 106 RVA: 0x0000D3A8 File Offset: 0x0000B5A8
        public BmsStructs.EntityClassType[] ReadXmlCt(string fName)
        {
            checked
            {
                BmsStructs.EntityClassType[] array;
                if (!File.Exists(fName))
                {
                    array = null; 
                }
                else
                {
                    BmsStructs.EntityClassType[] array2 = new BmsStructs.EntityClassType[0];
                    DateTime now = DateTime.Now;
                    using (XmlReader xmlReader = XmlReader.Create(fName))
                    {
                        while (xmlReader.Read())
                        {
                            int num = 0;
                            if (xmlReader.IsStartElement() && Operators.CompareString(xmlReader.Name, "CTRecords", false) != 0 && Operators.CompareString(xmlReader.Name, "CT", false) == 0)
                            {
                                string text = xmlReader["Num"];
                                num++;
                                Array.Resize<BmsStructs.EntityClassType>(ref array2, num);
                                Array.Resize<byte>(ref array2[num - 1].vuClassData.classInfo_, 8);
                                Array.Resize<short>(ref array2[num - 1].visType, 7);
                            }
                            if (xmlReader.NodeType == XmlNodeType.Element)
                            {
                                string name = xmlReader.Name;
                                xmlReader.Read();
                                string text2 = ((string.IsNullOrEmpty(xmlReader.Value) || xmlReader.Value.Contains(Environment.NewLine)) ? "" : xmlReader.Value);
                                if (Operators.CompareString(name, "Id", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.id_ = Conversions.ToUShort(text2);
                                }
                                if (Operators.CompareString(name, "CollisionType", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.collisionType_ = Conversions.ToUShort(text2);
                                }
                                if (Operators.CompareString(name, "CollisionRadius", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.collisionRadius_ = Conversions.ToSingle(text2);
                                }
                                if (Operators.CompareString(name, "Domain", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.classInfo_[0] = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "Class", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.classInfo_[1] = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "Type", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.classInfo_[2] = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "SubType", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.classInfo_[3] = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "Specific", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.classInfo_[4] = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "Owner", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.classInfo_[5] = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "Class_6", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.classInfo_[6] = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "Class_7", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.classInfo_[7] = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "UpdateRate", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.UpdateRate_ = Conversions.ToULong(text2);
                                }
                                if (Operators.CompareString(name, "UpdateTolerance", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.UpdateTolerance_ = Conversions.ToULong(text2);
                                }
                                if (Operators.CompareString(name, "FineUpdateRange", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.FineUpdateRange_ = Conversions.ToSingle(text2);
                                }
                                if (Operators.CompareString(name, "FineUpdateForceRange", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.FineUpdateForceRange_ = Conversions.ToSingle(text2);
                                }
                                if (Operators.CompareString(name, "FineUpdateMultiplier", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.FineUpdateMultiplier_ = Conversions.ToSingle(text2);
                                }
                                if (Operators.CompareString(name, "DamageSeed", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.DamageSeed_ = Conversions.ToSingle(text2);
                                }
                                if (Operators.CompareString(name, "HitPoints", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.Hitpoints_ = Conversions.ToInteger(text2);
                                }
                                if (Operators.CompareString(name, "MajorRev", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.majorRevisionNumber_ = Conversions.ToUShort(text2);
                                }
                                if (Operators.CompareString(name, "MinRev", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.minorRevisionNumber_ = Conversions.ToUShort(text2);
                                }
                                if (Operators.CompareString(name, "CreatePriority", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.CreatePriority_ = Conversions.ToUShort(text2);
                                }
                                if (Operators.CompareString(name, "ManagementDomain", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.managementDomain_ = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "Transferable", false) == 0)
                                {
                                    if ((Operators.CompareString(text2, "True", false) == 0) | (Operators.CompareString(text2, "1", false) == 0))
                                    {
                                        array2[num - 1].vuClassData.transferable_ = true;
                                    }
                                    else
                                    {
                                        array2[num - 1].vuClassData.transferable_ = false;
                                    }
                                }
                                if (Operators.CompareString(name, "Private", false) == 0)
                                {
                                    if ((Operators.CompareString(text2, "True", false) == 0) | (Operators.CompareString(text2, "1", false) == 0))
                                    {
                                        array2[num - 1].vuClassData.private_ = true;
                                    }
                                    else
                                    {
                                        array2[num - 1].vuClassData.private_ = false;
                                    }
                                }
                                if (Operators.CompareString(name, "Tangible", false) == 0)
                                {
                                    if ((Operators.CompareString(text2, "True", false) == 0) | (Operators.CompareString(text2, "1", false) == 0))
                                    {
                                        array2[num - 1].vuClassData.tangible_ = true;
                                    }
                                    else
                                    {
                                        array2[num - 1].vuClassData.tangible_ = false;
                                    }
                                }
                                if (Operators.CompareString(name, "Collidable", false) == 0)
                                {
                                    if ((Operators.CompareString(text2, "True", false) == 0) | (Operators.CompareString(text2, "1", false) == 0))
                                    {
                                        array2[num - 1].vuClassData.collidable_ = true;
                                    }
                                    else
                                    {
                                        array2[num - 1].vuClassData.collidable_ = false;
                                    }
                                }
                                if (Operators.CompareString(name, "Global", false) == 0)
                                {
                                    if ((Operators.CompareString(text2, "True", false) == 0) | (Operators.CompareString(text2, "1", false) == 0))
                                    {
                                        array2[num - 1].vuClassData.global_ = true;
                                    }
                                    else
                                    {
                                        array2[num - 1].vuClassData.global_ = false;
                                    }
                                }
                                if (Operators.CompareString(name, "Persistent", false) == 0)
                                {
                                    if ((Operators.CompareString(text2, "True", false) == 0) | (Operators.CompareString(text2, "1", false) == 0))
                                    {
                                        array2[num - 1].vuClassData.persistent_ = true;
                                    }
                                    else
                                    {
                                        array2[num - 1].vuClassData.persistent_ = false;
                                    }
                                }
                                if (Operators.CompareString(name, "GraphicsNormal", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].visType[0] = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "GraphicsRepaired", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].visType[1] = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "GraphicsDamaged", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].visType[2] = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "GraphicsDestroyed", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].visType[3] = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "GraphicsLeftDestroyed", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].visType[4] = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "GraphicsRightDestroyed", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].visType[5] = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "GraphicsBothDestroyed", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].visType[6] = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "MoverDefinitionData", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vehicleDataIndex = Conversions.ToShort(text2);
                                }
                                if (Operators.CompareString(name, "EntityType", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].vuClassData.FType_ = Conversions.ToByte(text2);
                                }
                                if (Operators.CompareString(name, "EntityIdx", false) == 0 && Versioned.IsNumeric(text2))
                                {
                                    array2[num - 1].dataType = Conversions.ToShort(text2);
                                }
                            }
                        }
                    }
                    //DateTime.Now - now;
                    array = array2;
                }
                return array;
            }
        }

        // Token: 0x0600006B RID: 107 RVA: 0x0000DCD0 File Offset: 0x0000BED0
        public bool WriteXmlCT(BmsStructs.EntityClassType[] classTableEntries, string fName)
        {
            checked
            {
                bool flag;
                if (classTableEntries == null)
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
                        xmlWriter.WriteStartElement("CTRecords");
                        NumberFormatInfo numberFormat = new CultureInfo("en-US", false).NumberFormat;
                        int num = classTableEntries.Length - 1;
                        for (int i = 0; i <= num; i++)
                        {
                            xmlWriter.WriteStartElement("CT");
                            xmlWriter.WriteAttributeString("Num", Conversions.ToString(i));
                            xmlWriter.WriteElementString("Id", classTableEntries[i].vuClassData.id_.ToString());
                            xmlWriter.WriteElementString("CollisionType", classTableEntries[i].vuClassData.collisionType_.ToString());
                            numberFormat.NumberDecimalDigits = 3;
                            double num2 = Math.Pow(10.0, (double)numberFormat.NumberDecimalDigits);
                            double num3 = (double)classTableEntries[i].vuClassData.collisionRadius_;
                            unchecked
                            {
                                num3 *= num2;
                                num3 = Math.Round(num3, MidpointRounding.AwayFromZero);
                                xmlWriter.WriteElementString("CollisionRadius", (num3 / num2).ToString("F", numberFormat));
                                xmlWriter.WriteElementString("Domain", classTableEntries[i].vuClassData.classInfo_[0].ToString());
                                xmlWriter.WriteElementString("Class", classTableEntries[i].vuClassData.classInfo_[1].ToString());
                                xmlWriter.WriteElementString("Type", classTableEntries[i].vuClassData.classInfo_[2].ToString());
                                xmlWriter.WriteElementString("SubType", classTableEntries[i].vuClassData.classInfo_[3].ToString());
                                xmlWriter.WriteElementString("Specific", classTableEntries[i].vuClassData.classInfo_[4].ToString());
                                xmlWriter.WriteElementString("Owner", classTableEntries[i].vuClassData.classInfo_[5].ToString());
                                xmlWriter.WriteElementString("Class_6", classTableEntries[i].vuClassData.classInfo_[6].ToString());
                                xmlWriter.WriteElementString("Class_7", classTableEntries[i].vuClassData.classInfo_[6].ToString());
                                xmlWriter.WriteElementString("UpdateRate", classTableEntries[i].vuClassData.UpdateRate_.ToString());
                                xmlWriter.WriteElementString("UpdateTolerance", classTableEntries[i].vuClassData.UpdateTolerance_.ToString());
                                numberFormat.NumberDecimalDigits = 3;
                                num2 = Math.Pow(10.0, (double)numberFormat.NumberDecimalDigits);
                                num3 = (double)classTableEntries[i].vuClassData.FineUpdateRange_;
                                num3 *= num2;
                                num3 = Math.Round(num3, MidpointRounding.AwayFromZero);
                                xmlWriter.WriteElementString("FineUpdateRange", (num3 / num2).ToString("F", numberFormat));
                                numberFormat.NumberDecimalDigits = 3;
                                num2 = Math.Pow(10.0, (double)numberFormat.NumberDecimalDigits);
                                num3 = (double)classTableEntries[i].vuClassData.FineUpdateForceRange_;
                                num3 *= num2;
                                num3 = Math.Round(num3, MidpointRounding.AwayFromZero);
                                xmlWriter.WriteElementString("FineUpdateForceRange", (num3 / num2).ToString("F", numberFormat));
                                numberFormat.NumberDecimalDigits = 3;
                                num2 = Math.Pow(10.0, (double)numberFormat.NumberDecimalDigits);
                                num3 = (double)classTableEntries[i].vuClassData.FineUpdateMultiplier_;
                                num3 *= num2;
                                num3 = Math.Round(num3, MidpointRounding.AwayFromZero);
                                xmlWriter.WriteElementString("FineUpdateMultiplier", (num3 / num2).ToString("F", numberFormat));
                                xmlWriter.WriteElementString("DamageSeed", classTableEntries[i].vuClassData.DamageSeed_.ToString());
                                xmlWriter.WriteElementString("HitPoints", classTableEntries[i].vuClassData.Hitpoints_.ToString());
                                xmlWriter.WriteElementString("MajorRev", classTableEntries[i].vuClassData.majorRevisionNumber_.ToString());
                                xmlWriter.WriteElementString("MinRev", classTableEntries[i].vuClassData.minorRevisionNumber_.ToString());
                                xmlWriter.WriteElementString("CreatePriority", classTableEntries[i].vuClassData.CreatePriority_.ToString());
                                xmlWriter.WriteElementString("ManagementDomain", classTableEntries[i].vuClassData.managementDomain_.ToString());
                                if (classTableEntries[i].vuClassData.transferable_)
                                {
                                    xmlWriter.WriteElementString("Transferable", "1");
                                }
                                else
                                {
                                    xmlWriter.WriteElementString("Transferable", "0");
                                }
                                if (classTableEntries[i].vuClassData.private_)
                                {
                                    xmlWriter.WriteElementString("Private", "1");
                                }
                                else
                                {
                                    xmlWriter.WriteElementString("Private", "0");
                                }
                                if (classTableEntries[i].vuClassData.tangible_)
                                {
                                    xmlWriter.WriteElementString("Tangible", "1");
                                }
                                else
                                {
                                    xmlWriter.WriteElementString("Tangible", "0");
                                }
                                if (classTableEntries[i].vuClassData.collidable_)
                                {
                                    xmlWriter.WriteElementString("Collidable", "1");
                                }
                                else
                                {
                                    xmlWriter.WriteElementString("Collidable", "0");
                                }
                                if (classTableEntries[i].vuClassData.global_)
                                {
                                    xmlWriter.WriteElementString("Global", "1");
                                }
                                else
                                {
                                    xmlWriter.WriteElementString("Global", "0");
                                }
                                if (classTableEntries[i].vuClassData.persistent_)
                                {
                                    xmlWriter.WriteElementString("Persistent", "1");
                                }
                                else
                                {
                                    xmlWriter.WriteElementString("Persistent", "0");
                                }
                                xmlWriter.WriteElementString("GraphicsNormal", classTableEntries[i].visType[0].ToString());
                                xmlWriter.WriteElementString("GraphicsRepaired", classTableEntries[i].visType[1].ToString());
                                xmlWriter.WriteElementString("GraphicsDamaged", classTableEntries[i].visType[2].ToString());
                                xmlWriter.WriteElementString("GraphicsDestroyed", classTableEntries[i].visType[3].ToString());
                                xmlWriter.WriteElementString("GraphicsLeftDestroyed", classTableEntries[i].visType[4].ToString());
                                xmlWriter.WriteElementString("GraphicsRightDestroyed", classTableEntries[i].visType[5].ToString());
                                xmlWriter.WriteElementString("GraphicsBothDestroyed", classTableEntries[i].visType[6].ToString());
                                xmlWriter.WriteElementString("MoverDefinitionData", classTableEntries[i].vehicleDataIndex.ToString());
                                xmlWriter.WriteElementString("EntityType", classTableEntries[i].vuClassData.FType_.ToString());
                                xmlWriter.WriteElementString("EntityIdx", classTableEntries[i].dataType.ToString());
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
    }
}
