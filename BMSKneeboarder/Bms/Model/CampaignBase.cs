using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class CampaignBase
    {
        // Token: 0x06000025 RID: 37 RVA: 0x00002127 File Offset: 0x00000327
        protected CampaignBase()
        {
        }

        // Token: 0x06000026 RID: 38 RVA: 0x000030D8 File Offset: 0x000012D8
        public CampaignBase(byte[] bytes, ref int offset, int version)
            : this()
        {
            id = default;
            id.num = BitConverter.ToUInt32(bytes, offset);
            checked
            {
                offset += 4;
                id.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                entityType = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                x = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                y = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                if (version < 70)
                {
                    z = 0f;
                }
                else
                {
                    z = BitConverter.ToSingle(bytes, offset);
                    offset += 4;
                }
                spotTime = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                spotted = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                baseFlags = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                owner = bytes[offset];
                offset++;
                campId = BitConverter.ToInt16(bytes, offset);
                offset += 2;
            }
        }

        // Token: 0x0400002C RID: 44
        public BmsStructs.BmsId id;

        // Token: 0x0400002D RID: 45
        public ushort entityType;

        // Token: 0x0400002E RID: 46
        public short x;

        // Token: 0x0400002F RID: 47
        public short y;

        // Token: 0x04000030 RID: 48
        public float z;

        // Token: 0x04000031 RID: 49
        public uint spotTime;

        // Token: 0x04000032 RID: 50
        public short spotted;

        // Token: 0x04000033 RID: 51
        public short baseFlags;

        // Token: 0x04000034 RID: 52
        public byte owner;

        // Token: 0x04000035 RID: 53
        public short campId;
    }
}
