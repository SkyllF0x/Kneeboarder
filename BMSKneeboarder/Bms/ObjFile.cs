using BMSKneeboarder.Bms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms
{
    public class ObjFile
    {
        // Token: 0x060000E5 RID: 229 RVA: 0x0001D6CC File Offset: 0x0001B8CC
        protected ObjFile()
        {
            this._version = 0;
        }

        // Token: 0x060000E6 RID: 230 RVA: 0x0001D6E8 File Offset: 0x0001B8E8
        public ObjFile(byte[] compressed, int version, ref int SubVer)
            : this()
        {
            this._version = version;
            short num = 0;
            byte[] array = ObjFile.Expand(compressed, ref num);
            if (array != null)
            {
                this.Decode(array, version, num, SubVer);
            }
            num = checked((short)this.objectives.Length);
        }

        // Token: 0x060000E7 RID: 231 RVA: 0x0001D728 File Offset: 0x0001B928
        protected void Decode(byte[] bytes, int version, short numObjectives, int SubVer)
        {
            checked
            {
                this.objectives = new Objective[(int)(numObjectives - 1 + 1)];
                int num = 0;
                int i = 0;
                while (i < (int)numObjectives)
                {
                    try
                    {
                        BitConverter.ToInt16(bytes, num);
                        num += 2;
                        Objective objective = new Objective(bytes, ref num, version, SubVer);
                        this.objectives[i] = objective;
                        i++;
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
            }
        }

        // Token: 0x060000E8 RID: 232 RVA: 0x0001D7A0 File Offset: 0x0001B9A0
        protected static byte[] Expand(byte[] compressed, ref short numObjectives)
        {
            int num = 0;
            numObjectives = BitConverter.ToInt16(compressed, num);
            checked
            {
                num += 2;
                int num2 = BitConverter.ToInt32(compressed, num);
                num += 4;
                BitConverter.ToInt32(compressed, num);
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

        // Token: 0x040000E0 RID: 224
        public Objective[] objectives;

        // Token: 0x040000E1 RID: 225
        protected int _version;
    }
}
