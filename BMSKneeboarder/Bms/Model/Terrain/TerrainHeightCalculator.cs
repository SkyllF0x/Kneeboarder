using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model.Terrain
{
    public class TerrainHeightCalculator
    {
        // Token: 0x060001BA RID: 442 RVA: 0x00034034 File Offset: 0x00032234
        public float CalculateTerrainHeight(float feetNorth, float feetEast, TerrainDB terrainDB)
        {
            float num;
            if (terrainDB.TheaterDotLxFiles.Length < 1)
            {
                num = 0f;
            }
            else
            {
                DistanceBetweenElevationPostsCalculator distanceBetweenElevationPostsCalculator = new DistanceBetweenElevationPostsCalculator();
                NearestElevationPostColumnAndRowCalculator nearestElevationPostColumnAndRowCalculator = new NearestElevationPostColumnAndRowCalculator();
                ColumnAndRowElevationPostRecordRetriever columnAndRowElevationPostRecordRetriever = new ColumnAndRowElevationPostRecordRetriever();
                float numFeetBetweenElevationPosts = distanceBetweenElevationPostsCalculator.GetNumFeetBetweenElevationPosts(2, terrainDB);
                int num2 = 0;
                int num3 = 0;
                nearestElevationPostColumnAndRowCalculator.GetNearestElevationPostColumnAndRowForNorthEastCoordinates(feetNorth, feetEast, ref num2, ref num3, terrainDB);
                TheaterDotLxFileRecord elevationPostRecordByColumnAndRow = columnAndRowElevationPostRecordRetriever.GetElevationPostRecordByColumnAndRow(num2, num3, 2U, terrainDB);
                TheaterDotLxFileRecord elevationPostRecordByColumnAndRow2;
                TheaterDotLxFileRecord elevationPostRecordByColumnAndRow3;
                TheaterDotLxFileRecord elevationPostRecordByColumnAndRow4;
                checked
                {
                    elevationPostRecordByColumnAndRow2 = columnAndRowElevationPostRecordRetriever.GetElevationPostRecordByColumnAndRow(num2 + 1, num3, 2U, terrainDB);
                    elevationPostRecordByColumnAndRow3 = columnAndRowElevationPostRecordRetriever.GetElevationPostRecordByColumnAndRow(num2 + 1, num3 + 1, 2U, terrainDB);
                    elevationPostRecordByColumnAndRow4 = columnAndRowElevationPostRecordRetriever.GetElevationPostRecordByColumnAndRow(num2, num3 + 1, 2U, terrainDB);
                }
                float num4 = (float)num3 * numFeetBetweenElevationPosts;
                float num5 = (float)num2 * numFeetBetweenElevationPosts;
                float num6 = (float)elevationPostRecordByColumnAndRow.Elevation;
                float num7 = (float)(checked(num2 + 1)) * numFeetBetweenElevationPosts;
                float num8 = (float)elevationPostRecordByColumnAndRow2.Elevation;
                float num9 = (float)elevationPostRecordByColumnAndRow3.Elevation;
                float num10 = (float)(checked(num3 + 1)) * numFeetBetweenElevationPosts;
                float num11 = (float)elevationPostRecordByColumnAndRow4.Elevation;
                float num12 = num5;
                float num13 = num7;
                float num14 = num4;
                float num15 = num10;
                num = num6 / ((num13 - num12) * (num15 - num14)) * (num13 - feetEast) * (num15 - feetNorth) + num8 / ((num13 - num12) * (num15 - num14)) * (feetEast - num12) * (num15 - feetNorth) + num11 / ((num13 - num12) * (num15 - num14)) * (num13 - feetEast) * (feetNorth - num14) + num9 / ((num13 - num12) * (num15 - num14)) * (feetEast - num12) * (feetNorth - num14);
            }
            return num;
        }
    }
}
