using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class CampaignManager
    {
        // Token: 0x06000027 RID: 39 RVA: 0x00002127 File Offset: 0x00000327
        protected CampaignManager()
        {
        }

        // Token: 0x06000028 RID: 40 RVA: 0x000031EC File Offset: 0x000013EC
        public CampaignManager(byte[] bytes, ref int offset, int version)
        {
            this.id.num = BitConverter.ToUInt32(bytes, offset);
            checked
            {
                offset += 4;
                this.id.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.entityType = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.managerFlags = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.owner = bytes[offset];
                offset++;
            }
        }

        // Token: 0x04000036 RID: 54
        public BmsStructs.BmsId id;

        // Token: 0x04000037 RID: 55
        public BmsStructs.BmsId ownerId;

        // Token: 0x04000038 RID: 56
        public ushort entityType;

        // Token: 0x04000039 RID: 57
        public short managerFlags;

        // Token: 0x0400003A RID: 58
        public byte owner;
    }
}
