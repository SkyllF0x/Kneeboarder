using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class Brigade : GroundUnit
    {
        // Token: 0x06000021 RID: 33 RVA: 0x00002EE7 File Offset: 0x000010E7
        protected Brigade()
        {
        }

        // Token: 0x06000022 RID: 34 RVA: 0x00003044 File Offset: 0x00001244
        public Brigade(byte[] bytes, ref int offset, int version)
            : base(bytes, ref offset, version)
        {
            this.elements = bytes[offset];
            checked
            {
                offset++;
                this.element = new BmsStructs.BmsId[(int)(this.elements - 1 + 1)];
                int num = (int)(this.elements - 1);
                for (int i = 0; i <= num; i++)
                {
                    BmsStructs.BmsId vu_ID = default(BmsStructs.BmsId);
                    vu_ID.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    vu_ID.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.element[i] = vu_ID;
                }
            }
        }

        // Token: 0x0400002A RID: 42
        public BmsStructs.BmsId[] element;

        // Token: 0x0400002B RID: 43
        public byte elements;
    }
}
