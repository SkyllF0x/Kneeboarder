using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model.Terrain
{
    public class ColumnAndRowElevationPostRecordRetriever
    {
        // Token: 0x060001A0 RID: 416 RVA: 0x00032C7C File Offset: 0x00030E7C
        public TheaterDotLxFileRecord GetElevationPostRecordByColumnAndRow(int postColumn, int postRow, uint lod, TerrainDB terrainDB)
        {
            ElevationPostCoordinateClamper elevationPostCoordinateClamper = new ElevationPostCoordinateClamper();
            TheaterDotMapFileInfo theaterDotMap = terrainDB.TheaterDotMap;
            checked
            {
                TheaterDotLxFileInfo theaterDotLxFileInfo = terrainDB.TheaterDotLxFiles[(int)lod];
                int num = 16;
                elevationPostCoordinateClamper.ClampElevationPostCoordinates(ref postColumn, ref postRow, theaterDotLxFileInfo.LoDLevel, terrainDB);
                long num2 = (long)((int)Math.Floor((double)postRow / (double)num));
                int num3 = (int)Math.Floor((double)postColumn / (double)num);
                int num4 = (int)(num2 * (long)(unchecked((ulong)theaterDotMap.LODMapHeights[checked((int)theaterDotLxFileInfo.LoDLevel)])) + unchecked((long)num3));
                TheaterDotOxFileRecord ptr = theaterDotLxFileInfo.O[num4];
                int num5 = postColumn % num;
                int num6 = postRow % num;
                int num7 = (int)Math.Round(unchecked(ptr.LRecordStartingOffset / (double)(checked(unchecked((ulong)theaterDotLxFileInfo.LRecordSizeBytes) * (ulong)(unchecked((long)num)) * (ulong)(unchecked((long)num)))) * (double)num * (double)num + (double)(checked(num6 * num + num5))));
                TheaterDotLxFileRecord theaterDotLxFileRecord = null;
                if (num7 < theaterDotLxFileInfo.L.Length)
                {
                    theaterDotLxFileRecord = theaterDotLxFileInfo.L[num7];
                    theaterDotLxFileRecord.Elevation = theaterDotLxFileInfo.L[num7].Elevation;
                }
                else
                {
                    theaterDotLxFileRecord.Elevation = 0;
                }
                return theaterDotLxFileRecord;
            }
        }

        // Token: 0x060001A1 RID: 417 RVA: 0x00032D6C File Offset: 0x00030F6C
        public int GetlIndex(int postColumn, int postRow, uint lod, TerrainDB terrainDB)
        {
            ElevationPostCoordinateClamper elevationPostCoordinateClamper = new ElevationPostCoordinateClamper();
            TheaterDotMapFileInfo theaterDotMap = terrainDB.TheaterDotMap;
            checked
            {
                TheaterDotLxFileInfo theaterDotLxFileInfo = terrainDB.TheaterDotLxFiles[(int)lod];
                int num = 16;
                elevationPostCoordinateClamper.ClampElevationPostCoordinates(ref postColumn, ref postRow, theaterDotLxFileInfo.LoDLevel, terrainDB);
                long num2 = (long)((int)Math.Floor((double)postRow / (double)num));
                int num3 = (int)Math.Floor((double)postColumn / (double)num);
                int num4 = (int)(num2 * (long)(unchecked((ulong)theaterDotMap.LODMapHeights[checked((int)theaterDotLxFileInfo.LoDLevel)])) + unchecked((long)num3));
                TheaterDotOxFileRecord ptr = theaterDotLxFileInfo.O[num4];
                int num5 = postColumn % num;
                int num6 = postRow % num;
                return (int)Math.Round(unchecked(ptr.LRecordStartingOffset / (double)(checked(unchecked((ulong)theaterDotLxFileInfo.LRecordSizeBytes) * (ulong)(unchecked((long)num)) * (ulong)(unchecked((long)num)))) * (double)num * (double)num + (double)(checked(num6 * num + num5))));
            }
        }

        // Token: 0x060001A2 RID: 418 RVA: 0x00032E1C File Offset: 0x0003101C
        public int GetlIndex(int postColumn, int postRow, uint lod, TerrainDB terrainDB, uint[] StartingOffset)
        {
            ElevationPostCoordinateClamper elevationPostCoordinateClamper = new ElevationPostCoordinateClamper();
            TheaterDotMapFileInfo theaterDotMap = terrainDB.TheaterDotMap;
            checked
            {
                TheaterDotLxFileInfo theaterDotLxFileInfo = terrainDB.TheaterDotLxFiles[(int)lod];
                int num = 16;
                elevationPostCoordinateClamper.ClampElevationPostCoordinates(ref postColumn, ref postRow, theaterDotLxFileInfo.LoDLevel, terrainDB);
                long num2 = (long)((int)Math.Floor((double)postRow / (double)num));
                int num3 = (int)Math.Floor((double)postColumn / (double)num);
                int num4 = (int)(num2 * (long)(unchecked((ulong)theaterDotMap.LODMapHeights[checked((int)theaterDotLxFileInfo.LoDLevel)])) + unchecked((long)num3));
                int num5 = postColumn % num;
                int num6 = postRow % num;
                return (int)Math.Round(unchecked(StartingOffset[num4] / (double)(checked(unchecked((ulong)theaterDotLxFileInfo.LRecordSizeBytes) * (ulong)(unchecked((long)num)) * (ulong)(unchecked((long)num)))) * (double)num * (double)num + (double)(checked(num6 * num + num5))));
            }
        }

        // Token: 0x060001A3 RID: 419 RVA: 0x00032EBC File Offset: 0x000310BC
        public int GetBlock(int postColumn, int postRow, uint lod, TerrainDB terrainDB, ref int blockCol, ref int blockRow)
        {
            ElevationPostCoordinateClamper elevationPostCoordinateClamper = new ElevationPostCoordinateClamper();
            TheaterDotMapFileInfo theaterDotMap = terrainDB.TheaterDotMap;
            checked
            {
                TheaterDotLxFileInfo theaterDotLxFileInfo = terrainDB.TheaterDotLxFiles[(int)lod];
                int num = 16;
                elevationPostCoordinateClamper.ClampElevationPostCoordinates(ref postColumn, ref postRow, theaterDotLxFileInfo.LoDLevel, terrainDB);
                blockRow = (int)Math.Floor((double)postRow / (double)num);
                blockCol = (int)Math.Floor((double)postColumn / (double)num);
                int num2 = (int)(unchecked((long)blockRow) * (long)(unchecked((ulong)theaterDotMap.LODMapHeights[checked((int)theaterDotLxFileInfo.LoDLevel)])) + unchecked((long)blockCol));
                return (int)theaterDotLxFileInfo.O[num2].LRecordStartingOffset;
            }
        }
    }
}
