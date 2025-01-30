using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class GroundUnit : Unit
    {
        // Token: 0x060000C7 RID: 199 RVA: 0x00002E59 File Offset: 0x00001059
        protected GroundUnit()
        {
        }

        // Token: 0x060000C8 RID: 200 RVA: 0x0001B5C4 File Offset: 0x000197C4
        public GroundUnit(byte[] bytes, ref int offset, int version)
            : base(bytes, ref offset, version)
        {
            this.orders = bytes[offset];
            checked
            {
                offset++;
                this.division = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.aobj = default(BmsStructs.BmsId);
                this.aobj.num = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.aobj.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
            }
        }

        // Token: 0x040000BC RID: 188
        public byte orders;

        // Token: 0x040000BD RID: 189
        public short division;

        // Token: 0x040000BE RID: 190
        public BmsStructs.BmsId aobj;
    }
}
