using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class TaskForce : Unit
    {
        // Token: 0x06000131 RID: 305 RVA: 0x00002E59 File Offset: 0x00001059
        protected TaskForce()
        {
        }

        // Token: 0x06000132 RID: 306 RVA: 0x00025608 File Offset: 0x00023808
        public TaskForce(byte[] bytes, ref int offset, int version)
            : base(bytes, ref offset, version)
        {
            this.orders = bytes[offset];
            checked
            {
                offset++;
                this.supply = bytes[offset];
                offset++;
                if (version < 100)
                {
                    if ((version >= 83) & (version < 85))
                    {
                        offset += 9;
                        return;
                    }
                    if (version >= 85)
                    {
                        offset += 9;
                    }
                }
            }
        }

        // Token: 0x04000124 RID: 292
        public byte orders;

        // Token: 0x04000125 RID: 293
        public byte supply;
    }
}
