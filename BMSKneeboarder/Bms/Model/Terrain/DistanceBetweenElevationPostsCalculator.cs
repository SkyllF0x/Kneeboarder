using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model.Terrain
{
    public class DistanceBetweenElevationPostsCalculator
    {
        // Token: 0x060001A6 RID: 422 RVA: 0x00032F44 File Offset: 0x00031144
        public float GetNumFeetBetweenElevationPosts(int lod, TerrainDB terrainDB)
        {
            checked
            {
                float num;
                if (terrainDB.TheaterDotLxFiles.Length < 1)
                {
                    num = 0f;
                }
                else
                {
                    TheaterDotLxFileInfo ptr = terrainDB.TheaterDotLxFiles[lod];
                    float num2 = terrainDB.TheaterDotMap.FeetBetweenL0Posts;
                    int num3 = (int)(unchecked((ulong)ptr.LoDLevel) - 1UL);
                    for (int i = 0; i <= num3; i++)
                    {
                        unchecked
                        {
                            num2 *= 2f;
                        }
                    }
                    num = num2;
                }
                return num;
            }
        }
    }
}
