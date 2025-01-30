using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace BMSKneeboarder.Bms.Model.Terrain
{
    public class TheaterDotLxFileReader
    {
        // Token: 0x060001BC RID: 444 RVA: 0x00034178 File Offset: 0x00032378
        public virtual TheaterDotLxFileInfo LoadTheaterDotLxFile(uint lodLevel, string theaterDotMapFilePath, string tileSet)
        {
            TheaterDotLxFileInfo theaterDotLxFileInfo = default(TheaterDotLxFileInfo);
            theaterDotLxFileInfo.MinElevation = ushort.MaxValue;
            theaterDotLxFileInfo.MaxElevation = 0;
            theaterDotLxFileInfo.LoDLevel = lodLevel;
            string text;
            string text2;
            if (Operators.CompareString(tileSet, "", false) != 0)
            {
                text = string.Concat(new string[]
                {
                    Path.GetDirectoryName(theaterDotMapFilePath),
                    Conversions.ToString(Path.DirectorySeparatorChar),
                    "theater_",
                    tileSet,
                    ".L",
                    Conversions.ToString(lodLevel)
                });
                text2 = string.Concat(new string[]
                {
                    Path.GetDirectoryName(theaterDotMapFilePath),
                    Conversions.ToString(Path.DirectorySeparatorChar),
                    "theater_",
                    tileSet,
                    ".O",
                    Conversions.ToString(lodLevel)
                });
            }
            else
            {
                text = Path.GetDirectoryName(theaterDotMapFilePath) + Conversions.ToString(Path.DirectorySeparatorChar) + "theater.L" + Conversions.ToString(lodLevel);
                text2 = Path.GetDirectoryName(theaterDotMapFilePath) + Conversions.ToString(Path.DirectorySeparatorChar) + "theater.O" + Conversions.ToString(lodLevel);
            }
            bool flag = true;
            List<TheaterDotOxFileRecord> list = new List<TheaterDotOxFileRecord>();
            checked
            {
                if (File.Exists(text2))
                {
                    int num = (int)new FileInfo(text2).Length;
                    byte[] array = new byte[num + 1];
                    using (FileStream fileStream = new FileStream(text2, FileMode.Open))
                    {
                        fileStream.Seek(0L, SeekOrigin.Begin);
                        fileStream.Read(array, 0, array.Length);
                    }
                    int i;
                    for (i = 0; i < num; i += 4)
                    {
                        uint num2 = BitConverter.ToUInt32(array, i);
                        if (unchecked((ulong)num2) % 2304UL != 0UL)
                        {
                            flag = false;
                            break;
                        }
                        TheaterDotOxFileRecord theaterDotOxFileRecord = new TheaterDotOxFileRecord
                        {
                            LRecordStartingOffset = num2
                        };
                        list.Add(theaterDotOxFileRecord);
                    }
                    i = 0;
                    if (!flag)
                    {
                        list.Clear();
                        while (i < num)
                        {
                            uint num3 = (uint)BitConverter.ToUInt16(array, i);
                            TheaterDotOxFileRecord theaterDotOxFileRecord2 = new TheaterDotOxFileRecord
                            {
                                LRecordStartingOffset = num3
                            };
                            list.Add(theaterDotOxFileRecord2);
                            i += 2;
                        }
                    }
                }
                if (File.Exists(text))
                {
                    int i = 0;
                    int num = (int)new FileInfo(text).Length;
                    byte[] array2 = new byte[num + 1];
                    using (FileStream fileStream2 = new FileStream(text, FileMode.Open))
                    {
                        fileStream2.Seek(0L, SeekOrigin.Begin);
                        fileStream2.Read(array2, 0, array2.Length);
                    }
                    uint num4 = 0U;
                    uint num5 = 65535U;
                    List<TheaterDotLxFileRecord> list2 = new List<TheaterDotLxFileRecord>();
                    if (flag)
                    {
                        theaterDotLxFileInfo.LRecordSizeBytes = 9U;
                        while (i < num)
                        {
                            TheaterDotLxFileRecord theaterDotLxFileRecord = new TheaterDotLxFileRecord();
                            theaterDotLxFileRecord.TextureId = BitConverter.ToUInt32(array2, i);
                            if (theaterDotLxFileRecord.TextureId > num4)
                            {
                                num4 = theaterDotLxFileRecord.TextureId;
                            }
                            if (theaterDotLxFileRecord.TextureId < num5)
                            {
                                num5 = theaterDotLxFileRecord.TextureId;
                            }
                            theaterDotLxFileRecord.Elevation = BitConverter.ToUInt16(array2, i + 4);
                            if (theaterDotLxFileRecord.Elevation < theaterDotLxFileInfo.MinElevation)
                            {
                                theaterDotLxFileInfo.MinElevation = theaterDotLxFileRecord.Elevation;
                            }
                            if (theaterDotLxFileRecord.Elevation > theaterDotLxFileInfo.MaxElevation)
                            {
                                theaterDotLxFileInfo.MaxElevation = theaterDotLxFileRecord.Elevation;
                            }
                            theaterDotLxFileRecord.Pallete = array2[i + 6];
                            theaterDotLxFileRecord.X1 = array2[i + 7];
                            theaterDotLxFileRecord.X2 = array2[i + 8];
                            list2.Add(theaterDotLxFileRecord);
                            i += 9;
                        }
                    }
                    else
                    {
                        theaterDotLxFileInfo.LRecordSizeBytes = 7U;
                        while (i < num)
                        {
                            TheaterDotLxFileRecord theaterDotLxFileRecord2 = new TheaterDotLxFileRecord();
                            theaterDotLxFileRecord2.TextureId = BitConverter.ToUInt32(array2, i);
                            if (theaterDotLxFileRecord2.TextureId > num4)
                            {
                                num4 = theaterDotLxFileRecord2.TextureId;
                            }
                            if (theaterDotLxFileRecord2.TextureId < num5)
                            {
                                num5 = theaterDotLxFileRecord2.TextureId;
                            }
                            theaterDotLxFileRecord2.Elevation = BitConverter.ToUInt16(array2, i + 2);
                            if (theaterDotLxFileRecord2.Elevation < theaterDotLxFileInfo.MinElevation)
                            {
                                theaterDotLxFileInfo.MinElevation = theaterDotLxFileRecord2.Elevation;
                            }
                            if (theaterDotLxFileRecord2.Elevation > theaterDotLxFileInfo.MaxElevation)
                            {
                                theaterDotLxFileInfo.MaxElevation = theaterDotLxFileRecord2.Elevation;
                            }
                            theaterDotLxFileRecord2.Pallete = array2[i + 4];
                            theaterDotLxFileRecord2.X1 = array2[i + 5];
                            theaterDotLxFileRecord2.X2 = array2[i + 6];
                            list2.Add(theaterDotLxFileRecord2);
                            i += 7;
                        }
                    }
                    theaterDotLxFileInfo.minTexOffset = num5;
                    theaterDotLxFileInfo.maxTexOffset = num4;
                    theaterDotLxFileInfo.O = list.ToArray();
                    theaterDotLxFileInfo.L = list2.ToArray();
                    list.Clear();
                    list2.Clear();
                }
                GC.Collect();
                return theaterDotLxFileInfo;
            }
        }
    }
}
