using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class NavalTaskingManager : CampaignManager
    {
        // Token: 0x060000D2 RID: 210 RVA: 0x00002A48 File Offset: 0x00000C48
        protected NavalTaskingManager()
        {
        }

        // Token: 0x060000D3 RID: 211 RVA: 0x0001C01C File Offset: 0x0001A21C
        public NavalTaskingManager(byte[] bytes, ref int offset, int version)
            : base(bytes, ref offset, version)
        {
            this.flags = BitConverter.ToInt16(bytes, offset);
            checked
            {
                offset += 2;
            }
        }

        // Token: 0x040000BF RID: 191
        public short flags;
    }
}
