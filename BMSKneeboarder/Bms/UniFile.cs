using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMSKneeboarder.Bms.Model;

namespace BMSKneeboarder.Bms
{
    public class UniFile
    {
        // Token: 0x06000137 RID: 311 RVA: 0x000262F5 File Offset: 0x000244F5
        protected UniFile()
        {
            units = new Unit[0];
            _version = 0;
        }

        // Token: 0x06000138 RID: 312 RVA: 0x00026310 File Offset: 0x00024510
        public UniFile(byte[] compressed, int version, BmsStructs.EntityClassType[] classTable, bool Export)
            : this()
        {
            _version = version;
            short num = 0;
            if (version == 72)
            {

            }
            byte[] array = Expand(compressed, ref num);
            if (array != null)
            {
                Decode(array, version, num, classTable, Export);
            }
        }

        // Token: 0x06000139 RID: 313 RVA: 0x00026344 File Offset: 0x00024544
        protected void Decode(byte[] bytes, int version, short numUnits, BmsStructs.EntityClassType[] classTable, bool Export)
        {
            int num = 0;
            checked
            {
                this.units = new Unit[(int)(numUnits - 1 + 1)];
                int num2 = 0;
                while (num2 < (int)numUnits && num < bytes.Length)
                {
                    short num3 = BitConverter.ToInt16(bytes, num);
                    num += 2;
                    if ((int)num3 > classTable.Length + 100)
                    {
                        //break;
                    }
                    if (num3 >= 100)
                    {
                        BmsStructs.EntityClassType ect = classTable[(int)(num3 - 100)];
                        Unit unit;
                        if (ect.vuClassData.classInfo_[0] == 2)
                        {
                            if (ect.vuClassData.classInfo_[2] == 1)
                            {
                                unit = new Flight(bytes, ref num, version);
                            }
                            else if (ect.vuClassData.classInfo_[2] == 3)
                            {
                                unit = new Squadron(bytes, ref num, version, Export);
                            }
                            else if (ect.vuClassData.classInfo_[2] == 2)
                            {
                                unit = new Package(bytes, ref num, version);
                            }
                            else
                            {
                                unit = null;
                            }
                        }
                        else if (ect.vuClassData.classInfo_[0] == 3)
                        {
                            if (ect.vuClassData.classInfo_[2] == 2)
                            {
                                unit = new Brigade(bytes, ref num, version);
                            }
                            else if (ect.vuClassData.classInfo_[2] == 1)
                            {
                                unit = new Battalion(bytes, ref num, version);
                            }
                            else
                            {
                                unit = null;
                            }
                        }
                        else if (ect.vuClassData.classInfo_[0] == 4)
                        {
                            if (ect.vuClassData.classInfo_[2] == 1)
                            {
                                unit = new TaskForce(bytes, ref num, version);
                            }
                            else
                            {
                                unit = null;
                            }
                        }
                        else
                        {
                            unit = null;
                        }
                        if (unit != null)
                        {
                            this.units[num2] = unit;
                            num2++;
                        }
                    }
                    else if (num3 > 3707)
                    {
                        BmsStructs.EntityClassType falcon4EntityClassType2 = classTable[3607];
                        Unit unit;
                        if (falcon4EntityClassType2.vuClassData.classInfo_[0] == 2)
                        {
                            if (falcon4EntityClassType2.vuClassData.classInfo_[2] == 1)
                            {
                                unit = new Flight(bytes, ref num, version);
                            }
                            else if (falcon4EntityClassType2.vuClassData.classInfo_[2] == 3)
                            {
                                unit = new Squadron(bytes, ref num, version, Export);
                            }
                            else if (falcon4EntityClassType2.vuClassData.classInfo_[2] == 2)
                            {
                                unit = new Package(bytes, ref num, version);
                            }
                            else
                            {
                                unit = null;
                            }
                        }
                        else if (falcon4EntityClassType2.vuClassData.classInfo_[0] == 3)
                        {
                            if (falcon4EntityClassType2.vuClassData.classInfo_[2] == 2)
                            {
                                unit = new Brigade(bytes, ref num, version);
                            }
                            else if (falcon4EntityClassType2.vuClassData.classInfo_[2] == 1)
                            {
                                unit = new Battalion(bytes, ref num, version);
                            }
                            else
                            {
                                unit = null;
                            }
                        }
                        else if (falcon4EntityClassType2.vuClassData.classInfo_[0] == 4)
                        {
                            if (falcon4EntityClassType2.vuClassData.classInfo_[2] == 1)
                            {
                                unit = new TaskForce(bytes, ref num, version);
                            }
                            else
                            {
                                unit = null;
                            }
                        }
                        else
                        {
                            unit = null;
                        }
                        if (unit != null)
                        {
                            this.units[num2] = unit;
                            num2++;
                        }
                    }
                    else
                    {
                        BmsStructs.EntityClassType falcon4EntityClassType3 = classTable[430];
                        Unit unit;
                        if (falcon4EntityClassType3.vuClassData.classInfo_[0] == 2)
                        {
                            if (falcon4EntityClassType3.vuClassData.classInfo_[2] == 1)
                            {
                                unit = new Flight(bytes, ref num, version);
                            }
                            else if (falcon4EntityClassType3.vuClassData.classInfo_[2] == 3)
                            {
                                unit = new Squadron(bytes, ref num, version, Export);
                            }
                            else if (falcon4EntityClassType3.vuClassData.classInfo_[2] == 2)
                            {
                                unit = new Package(bytes, ref num, version);
                            }
                            else
                            {
                                unit = null;
                            }
                        }
                        else if (falcon4EntityClassType3.vuClassData.classInfo_[0] == 3)
                        {
                            if (falcon4EntityClassType3.vuClassData.classInfo_[2] == 2)
                            {
                                unit = new Brigade(bytes, ref num, version);
                            }
                            else if (falcon4EntityClassType3.vuClassData.classInfo_[2] == 1)
                            {
                                unit = new Battalion(bytes, ref num, version);
                            }
                            else
                            {
                                unit = null;
                            }
                        }
                        else if (falcon4EntityClassType3.vuClassData.classInfo_[0] == 4)
                        {
                            if (falcon4EntityClassType3.vuClassData.classInfo_[2] == 1)
                            {
                                unit = new TaskForce(bytes, ref num, version);
                            }
                            else
                            {
                                unit = null;
                            }
                        }
                        else
                        {
                            unit = null;
                        }
                        if (unit != null)
                        {
                            this.units[num2] = unit;
                            num2++;
                        }
                    }
                }
                int num4 = bytes.Length - 1;
            }
        }

        // Token: 0x0600013A RID: 314 RVA: 0x00026710 File Offset: 0x00024910
        protected static byte[] Expand(byte[] compressed, ref short numUnits)
        {
            int num = 0;
            BitConverter.ToInt32(compressed, num);
            checked
            {
                num += 4;
                numUnits = BitConverter.ToInt16(compressed, num);
                num += 2;
                int num2 = BitConverter.ToInt32(compressed, num);
                num += 4;
                byte[] array;
                if (num2 == 0)
                {
                    array = null;
                }
                else
                {
                    byte[] array2 = new byte[compressed.Length - 11 + 1];
                    Array.Copy(compressed, 10, array2, 0, array2.Length);
                    array = Codec.Decompress(array2, num2);
                }
                return array;
            }
        }

        // Token: 0x04000157 RID: 343
        public Unit[] units;

        // Token: 0x04000158 RID: 344
        protected int _version;
    }
}
