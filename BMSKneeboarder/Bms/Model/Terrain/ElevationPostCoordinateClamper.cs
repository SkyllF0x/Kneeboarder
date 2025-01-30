using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model.Terrain
{
    public class ElevationPostCoordinateClamper
    {
        // Token: 0x060001A8 RID: 424 RVA: 0x00032FA0 File Offset: 0x000311A0
        public void ClampElevationPostCoordinates(ref int postColumn, ref int postRow, uint lod, TerrainDB terrainDB)
        {
            if (Information.IsNothing(terrainDB.TheaterDotLxFiles))
            {
                postColumn = 0;
                postRow = 0;
                return;
            }
            TheaterDotMapFileInfo theaterDotMap = terrainDB.TheaterDotMap;
            checked
            {
                TheaterDotLxFileInfo theaterDotLxFileInfo = terrainDB.TheaterDotLxFiles[(int)lod];
                int num = 16;
                if (postColumn < 0)
                {
                    postColumn = 0;
                }
                if (postRow < 0)
                {
                    postRow = 0;
                }
                if (unchecked((long)postColumn) > (long)(unchecked((ulong)theaterDotMap.LODMapWidths[checked((int)theaterDotLxFileInfo.LoDLevel)]) * (ulong)(unchecked((long)num)) - 1UL))
                {
                    postColumn = (int)(unchecked((ulong)theaterDotMap.LODMapWidths[checked((int)theaterDotLxFileInfo.LoDLevel)]) * (ulong)(unchecked((long)num)) - 1UL);
                }
                if (unchecked((long)postRow) > (long)(unchecked((ulong)theaterDotMap.LODMapHeights[checked((int)theaterDotLxFileInfo.LoDLevel)]) * (ulong)(unchecked((long)num)) - 1UL))
                {
                    postRow = (int)(unchecked((ulong)theaterDotMap.LODMapHeights[checked((int)theaterDotLxFileInfo.LoDLevel)]) * (ulong)(unchecked((long)num)) - 1UL);
                }
            }
        }
    }
}
