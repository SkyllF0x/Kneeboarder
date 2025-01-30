using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class AirUnit : Unit
    {
        // Token: 0x0600001A RID: 26 RVA: 0x00002E59 File Offset: 0x00001059
        protected AirUnit()
        {
        }

        // Token: 0x0600001B RID: 27 RVA: 0x00002E61 File Offset: 0x00001061
        public AirUnit(byte[] bytes, ref int offset, int version)
            : base(bytes, ref offset, version)
        {
        }
    }
}
