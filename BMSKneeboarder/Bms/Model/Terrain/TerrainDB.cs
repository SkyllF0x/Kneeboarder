using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model.Terrain
{
    public class TerrainDB
    {
        // Token: 0x060001B8 RID: 440 RVA: 0x00034020 File Offset: 0x00032220
        public TerrainDB()
        {
            this.TheaterDotLxFiles = new TheaterDotLxFileInfo[0];
        }

        // Token: 0x040001AD RID: 429
        public TheaterDotMapFileInfo TheaterDotMap;

        // Token: 0x040001AE RID: 430
        public TheaterDotLxFileInfo[] TheaterDotLxFiles;
    }
}
