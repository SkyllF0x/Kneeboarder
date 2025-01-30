using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class Pilot
    {
        // Token: 0x04000100 RID: 256
        public short pilot_id;

        // Token: 0x04000101 RID: 257
        public byte pilot_skill_and_rating;

        // Token: 0x04000102 RID: 258
        public byte pilot_status;

        // Token: 0x04000103 RID: 259
        public byte aa_kills;

        // Token: 0x04000104 RID: 260
        public byte ag_kills;

        // Token: 0x04000105 RID: 261
        public byte as_kills;

        // Token: 0x04000106 RID: 262
        public byte an_kills;

        // Token: 0x04000107 RID: 263
        public short missions_flown;
    }
}
