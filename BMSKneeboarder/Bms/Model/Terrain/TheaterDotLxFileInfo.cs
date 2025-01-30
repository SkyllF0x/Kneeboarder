using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model.Terrain
{
    public struct TheaterDotLxFileInfo
    {
        // Token: 0x04000194 RID: 404
        public TheaterDotLxFileRecord[] L;

        // Token: 0x04000195 RID: 405
        public uint LRecordSizeBytes;

        // Token: 0x04000196 RID: 406
        public uint LoDLevel;

        // Token: 0x04000197 RID: 407
        public ushort MaxElevation;

        // Token: 0x04000198 RID: 408
        public ushort MinElevation;

        // Token: 0x04000199 RID: 409
        public TheaterDotOxFileRecord[] O;

        // Token: 0x0400019A RID: 410
        public uint maxTexOffset;

        // Token: 0x0400019B RID: 411
        public uint minTexOffset;
    }
}
