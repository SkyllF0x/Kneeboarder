using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model.Terrain
{
    public class TheaterDotMapFileReader
    {
        // Token: 0x060001B7 RID: 439 RVA: 0x00033CA8 File Offset: 0x00031EA8
        public virtual TheaterDotMapFileInfo ReadTheaterDotMapFile(string theaterDotMapFilePath)
        {
            TheaterDotMapFileInfo theaterDotMapFileInfo = new TheaterDotMapFileInfo
            {
                Pallete = new Color[256],
                GreenPallete = new Color[256]
            };
            checked
            {
                if (File.Exists(theaterDotMapFilePath))
                {
                    byte[] array = new byte[(int)new FileInfo(theaterDotMapFilePath).Length + 1];
                    using (FileStream fileStream = new FileStream(theaterDotMapFilePath, FileMode.Open))
                    {
                        fileStream.Seek(0L, SeekOrigin.Begin);
                        fileStream.Read(array, 0, array.Length);
                    }
                    theaterDotMapFileInfo.FeetBetweenL0Posts = BitConverter.ToSingle(array, 0);
                    theaterDotMapFileInfo.MEAMapWidth = BitConverter.ToUInt32(array, 4);
                    theaterDotMapFileInfo.MEAMapHeight = BitConverter.ToUInt32(array, 8);
                    theaterDotMapFileInfo.FeetToMeaCellConversionFactor = BitConverter.ToSingle(array, 12);
                    theaterDotMapFileInfo.NumLODs = BitConverter.ToUInt32(array, 16);
                    theaterDotMapFileInfo.LastNearTiledLOD = BitConverter.ToUInt32(array, 20);
                    theaterDotMapFileInfo.LastFarTiledLOD = BitConverter.ToUInt32(array, 24);
                    uint[] array2 = new uint[256];
                    int num = array2.Length - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        array2[i] = BitConverter.ToUInt32(array, 28 + i * 4);
                    }
                    int num2 = array2.Length - 1;
                    for (int j = 0; j <= num2; j++)
                    {
                        byte b = (byte)(unchecked((ulong)array2[j]) & 255UL);
                        byte b2 = (byte)(unchecked((ulong)(array2[j] >> 8)) & 255UL);
                        byte b3 = (byte)(unchecked((ulong)(array2[j] >> 16)) & 255UL);
                        Color color = Color.FromArgb((int)((byte)(unchecked((ulong)(array2[j] >> 24)) & 255UL)), (int)b, (int)b2, (int)b3);
                        theaterDotMapFileInfo.Pallete[j] = color;
                        byte b4 = 0;
                        byte b5 = 0;
                        byte b6 = (byte)Math.Round((double)(unchecked((float)color.R * 0.25f + (float)color.G * 0.5f + (float)color.B * 0.25f)));
                        Color color2 = Color.FromArgb((int)((byte)(unchecked((ulong)(array2[j] >> 24)) & 255UL)), (int)b4, (int)b6, (int)b5);
                        theaterDotMapFileInfo.GreenPallete[j] = color2;
                    }
                    theaterDotMapFileInfo.LODMapHeights = new uint[(int)theaterDotMapFileInfo.NumLODs + 1];
                    theaterDotMapFileInfo.LODMapWidths = new uint[(int)theaterDotMapFileInfo.NumLODs + 1];
                    int num3 = (int)(unchecked((ulong)theaterDotMapFileInfo.NumLODs) - 1UL);
                    for (int k = 0; k <= num3; k++)
                    {
                        theaterDotMapFileInfo.LODMapWidths[k] = BitConverter.ToUInt32(array, 1052 + k * 8);
                        theaterDotMapFileInfo.LODMapHeights[k] = BitConverter.ToUInt32(array, 1056 + k * 8);
                    }
                    theaterDotMapFileInfo.flags = 0U;
                    theaterDotMapFileInfo.baseLong = 119.114876f;
                    theaterDotMapFileInfo.baseLat = 33.775917f;
                    if (unchecked((long)array.Length) >= (long)(1056UL + (unchecked((ulong)theaterDotMapFileInfo.NumLODs) - 1UL) * 8UL + 4UL))
                    {
                        theaterDotMapFileInfo.flags = BitConverter.ToUInt32(array, (int)(1056UL + (unchecked((ulong)theaterDotMapFileInfo.NumLODs) - 1UL) * 8UL + 4UL));
                    }
                    if (unchecked((long)array.Length) >= (long)(1056UL + (unchecked((ulong)theaterDotMapFileInfo.NumLODs) - 1UL) * 8UL + 8UL))
                    {
                        theaterDotMapFileInfo.baseLong = BitConverter.ToSingle(array, (int)(1056UL + (unchecked((ulong)theaterDotMapFileInfo.NumLODs) - 1UL) * 8UL + 8UL));
                    }
                    if (unchecked((long)array.Length) >= (long)(1056UL + (unchecked((ulong)theaterDotMapFileInfo.NumLODs) - 1UL) * 8UL + 12UL))
                    {
                        theaterDotMapFileInfo.baseLat = BitConverter.ToSingle(array, (int)(1056UL + (unchecked((ulong)theaterDotMapFileInfo.NumLODs) - 1UL) * 8UL + 12UL));
                    }
                }
                return theaterDotMapFileInfo;
            }
        }
    }
}
