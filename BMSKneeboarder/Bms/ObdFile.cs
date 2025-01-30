using BMSKneeboarder.Bms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms
{
    public class ObdFile
    {
        // Token: 0x060000D4 RID: 212 RVA: 0x0001C03B File Offset: 0x0001A23B
        protected ObdFile()
        {
            this._version = 0;
        }

        // Token: 0x060000D5 RID: 213 RVA: 0x0001C04C File Offset: 0x0001A24C
        public ObdFile(byte[] compressed, int version)
            : this()
        {
            this._version = version;
            short num = 0;
            byte[] array = ObdFile.Expand(compressed, ref num);
            if (array != null)
            {
                this.Decode(array, version, num);
            }
        }

        // Token: 0x060000D6 RID: 214 RVA: 0x0001C080 File Offset: 0x0001A280
        protected void Decode(byte[] bytes, int version, short numObjectiveDeltas)
        {
            checked
            {
                this.deltas = new ObjectiveDeltas[(int)(numObjectiveDeltas - 1 + 1)];
                int num = 0;
                for (int i = 0; i < (int)numObjectiveDeltas; i++)
                {
                    ObjectiveDeltas objectiveDeltas = new ObjectiveDeltas(bytes, ref num, version);
                    this.deltas[i] = objectiveDeltas;
                }
            }
        }

        // Token: 0x060000D7 RID: 215 RVA: 0x0001C0C0 File Offset: 0x0001A2C0
        protected static byte[] Expand(byte[] compressed, ref short numObjectiveDeltas)
        {
            int num = 0;
            BitConverter.ToInt32(compressed, num);
            checked
            {
                num += 4;
                numObjectiveDeltas = BitConverter.ToInt16(compressed, num);
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

        // Token: 0x040000C0 RID: 192
        public ObjectiveDeltas[] deltas;

        // Token: 0x040000C1 RID: 193
        protected int _version;
    }
}
