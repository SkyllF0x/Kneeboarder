using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class GroundTaskingManager : CampaignManager
    {
        // Token: 0x060000C5 RID: 197 RVA: 0x00002A48 File Offset: 0x00000C48
        protected GroundTaskingManager()
        {
        }

        // Token: 0x060000C6 RID: 198 RVA: 0x0001B5A2 File Offset: 0x000197A2
        public GroundTaskingManager(byte[] bytes, ref int offset, int version)
            : base(bytes, ref offset, version)
        {
            this.flags = BitConverter.ToInt16(bytes, offset);
            checked
            {
                offset += 2;
            }
        }

        // Token: 0x040000BB RID: 187
        public short flags;
    }
}
