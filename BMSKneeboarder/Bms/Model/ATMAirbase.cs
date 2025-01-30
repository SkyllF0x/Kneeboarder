using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class ATMAirbase
    {
        // Token: 0x0600001C RID: 28 RVA: 0x00002127 File Offset: 0x00000327
        protected ATMAirbase()
        {
        }

        // Token: 0x0600001D RID: 29 RVA: 0x00002E6C File Offset: 0x0000106C
        public ATMAirbase(byte[] bytes, ref int offset, int version)
        {
            this.id.num = BitConverter.ToUInt32(bytes, offset);
            checked
            {
                offset += 4;
                this.id.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                Array.Resize<byte>(ref this.schedule, 32);
                int num = this.schedule.Length - 1;
                for (int i = 0; i <= num; i++)
                {
                    this.schedule[i] = bytes[offset];
                    offset++;
                }
            }
        }

        // Token: 0x04000011 RID: 17
        public BmsStructs.BmsId id;

        // Token: 0x04000012 RID: 18
        public byte[] schedule;
    }
}
