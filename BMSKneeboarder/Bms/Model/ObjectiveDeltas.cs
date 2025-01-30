using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class ObjectiveDeltas
    {
        // Token: 0x060000DA RID: 218 RVA: 0x00002127 File Offset: 0x00000327
        protected ObjectiveDeltas()
        {
        }

        // Token: 0x060000DB RID: 219 RVA: 0x0001C4E4 File Offset: 0x0001A6E4
        public ObjectiveDeltas(byte[] bytes, ref int offset, int version)
        {
            this.id.num = BitConverter.ToUInt32(bytes, offset);
            checked
            {
                offset += 4;
                this.id.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.last_repair = unchecked((ulong)BitConverter.ToUInt32(bytes, offset));
                offset += 4;
                this.owner = bytes[offset];
                offset++;
                this.supply = bytes[offset];
                offset++;
                this.fuel = bytes[offset];
                offset++;
                this.losses = bytes[offset];
                offset++;
                this.numFstatus = bytes[offset];
                offset++;
                Array.Resize<byte>(ref this.fStatus, (int)this.numFstatus);
                if (version < 64)
                {
                    this.fStatus[0] = bytes[offset];
                    offset++;
                }
                else
                {
                    int num = (int)(this.numFstatus - 1);
                    for (int i = 0; i <= num; i++)
                    {
                        this.fStatus[i] = bytes[offset];
                        offset++;
                    }
                }
                if (version < 100 && version >= 83)
                {
                    offset += 3;
                    this.owner = bytes[offset];
                    offset++;
                    offset += 3;
                    int num2 = (int)bytes[offset];
                    offset += num2;
                    offset++;
                }
            }
        }

        // Token: 0x040000D6 RID: 214
        public BmsStructs.BmsId id;

        // Token: 0x040000D7 RID: 215
        public ulong last_repair;

        // Token: 0x040000D8 RID: 216
        public byte owner;

        // Token: 0x040000D9 RID: 217
        public byte supply;

        // Token: 0x040000DA RID: 218
        public byte fuel;

        // Token: 0x040000DB RID: 219
        public byte losses;

        // Token: 0x040000DC RID: 220
        public byte numFstatus;

        // Token: 0x040000DD RID: 221
        public byte[] fStatus;
    }
}
