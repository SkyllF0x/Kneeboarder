using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model.Terrain
{
    public struct TheaterDotMapFileInfo
    {
        // Token: 0x0400019C RID: 412
        public float FeetBetweenL0Posts;

        // Token: 0x0400019D RID: 413
        public float FeetToMeaCellConversionFactor;

        // Token: 0x0400019E RID: 414
        public Color[] GreenPallete;

        // Token: 0x0400019F RID: 415
        public uint[] LODMapHeights;

        // Token: 0x040001A0 RID: 416
        public uint[] LODMapWidths;

        // Token: 0x040001A1 RID: 417
        public uint LastFarTiledLOD;

        // Token: 0x040001A2 RID: 418
        public uint LastNearTiledLOD;

        // Token: 0x040001A3 RID: 419
        public uint MEAMapHeight;

        // Token: 0x040001A4 RID: 420
        public uint MEAMapWidth;

        // Token: 0x040001A5 RID: 421
        public uint NumLODs;

        // Token: 0x040001A6 RID: 422
        public Color[] Pallete;

        // Token: 0x040001A7 RID: 423
        public float baseLat;

        // Token: 0x040001A8 RID: 424
        public float baseLong;

        // Token: 0x040001A9 RID: 425
        public uint flags;
    }
}
