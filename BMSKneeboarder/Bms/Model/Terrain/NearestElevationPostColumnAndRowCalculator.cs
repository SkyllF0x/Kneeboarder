using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model.Terrain
{
    public class NearestElevationPostColumnAndRowCalculator
    {
        // Token: 0x060001AA RID: 426 RVA: 0x00033050 File Offset: 0x00031250
        public void GetNearestElevationPostColumnAndRowForNorthEastCoordinates(float feetNorth, float feetEast, ref int col, ref int row, TerrainDB terrainDB)
        {
            int num = 2;
            DistanceBetweenElevationPostsCalculator distanceBetweenElevationPostsCalculator = new DistanceBetweenElevationPostsCalculator();
            ElevationPostCoordinateClamper elevationPostCoordinateClamper = new ElevationPostCoordinateClamper();
            checked
            {
                int num2 = (int)Math.Round((double)distanceBetweenElevationPostsCalculator.GetNumFeetBetweenElevationPosts(num, terrainDB));
                col = (int)Math.Floor((double)(feetEast / (float)num2));
                row = (int)Math.Floor((double)(feetNorth / (float)num2));
                elevationPostCoordinateClamper.ClampElevationPostCoordinates(ref col, ref row, (uint)num, terrainDB);
            }
        }
    }
}
