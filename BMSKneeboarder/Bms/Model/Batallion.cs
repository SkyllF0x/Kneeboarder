using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class Battalion : GroundUnit
    {
        // Token: 0x0600001F RID: 31 RVA: 0x00002EE7 File Offset: 0x000010E7
        protected Battalion()
        {
        }

        // Token: 0x06000020 RID: 32 RVA: 0x00002EF0 File Offset: 0x000010F0
        public Battalion(byte[] bytes, ref int offset, int version)
            : base(bytes, ref offset, version)
        {
            this.last_move = BitConverter.ToUInt32(bytes, offset);
            checked
            {
                offset += 4;
                this.last_combat = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.parent_id = default(BmsStructs.BmsId);
                this.parent_id.num = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.parent_id.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.last_obj = default(BmsStructs.BmsId);
                this.last_obj.num = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.last_obj.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.supply = bytes[offset];
                offset++;
                this.fatigue = bytes[offset];
                offset++;
                this.morale = bytes[offset];
                offset++;
                this.heading = bytes[offset];
                offset++;
                this.final_heading = bytes[offset];
                offset++;
                if (version < 15)
                {
                    this.dummy = bytes[offset];
                    offset++;
                }
                this.position = bytes[offset];
                offset++;
                if (version < 100 && version >= 83 && this.position > 0)
                {
                    this.extraAF = bytes[offset];
                    offset++;
                }
            }
        }

        // Token: 0x0400001A RID: 26
        public uint last_move;

        // Token: 0x0400001B RID: 27
        public uint last_combat;

        // Token: 0x0400001C RID: 28
        public BmsStructs.BmsId parent_id;

        // Token: 0x0400001D RID: 29
        public BmsStructs.BmsId last_obj;

        // Token: 0x0400001E RID: 30
        public short lfx;

        // Token: 0x0400001F RID: 31
        public short lfy;

        // Token: 0x04000020 RID: 32
        public short rfx;

        // Token: 0x04000021 RID: 33
        public short rfy;

        // Token: 0x04000022 RID: 34
        public byte supply;

        // Token: 0x04000023 RID: 35
        public byte fatigue;

        // Token: 0x04000024 RID: 36
        public byte morale;

        // Token: 0x04000025 RID: 37
        public byte heading;

        // Token: 0x04000026 RID: 38
        public byte final_heading;

        // Token: 0x04000027 RID: 39
        public byte dummy;

        // Token: 0x04000028 RID: 40
        public byte position;

        // Token: 0x04000029 RID: 41
        public byte extraAF;
    }
}
