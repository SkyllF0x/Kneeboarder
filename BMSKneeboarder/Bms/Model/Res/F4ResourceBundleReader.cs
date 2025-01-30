using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace BMSKneeboarder.Bms.Model.Res
{
    public class F4ResourceBundleReader
    {
        // Token: 0x17000013 RID: 19
        // (get) Token: 0x0600018F RID: 399 RVA: 0x000320E8 File Offset: 0x000302E8
        public int NumResources
        {
            get
            {
                int num;
                if (this._resourceIndex == null)
                {
                    num = -1;
                }
                else
                {
                    num = checked((int)this._resourceIndex.NumResources);
                }
                return num;
            }
        }

        // Token: 0x06000190 RID: 400 RVA: 0x00032110 File Offset: 0x00030310
        public virtual void Load(string resourceBundleIndexPath)
        {
            FileInfo fileInfo = new FileInfo(resourceBundleIndexPath);
            checked
            {
                if (fileInfo.Exists)
                {
                    byte[] array = new byte[(int)(fileInfo.Length - 1L) + 1];
                    using (FileStream fileStream = new FileStream(resourceBundleIndexPath, FileMode.Open))
                    {
                        fileStream.Seek(0L, SeekOrigin.Begin);
                        fileStream.Read(array, 0, (int)fileInfo.Length);
                    }
                    this._resourceIndex = new F4ResourceBundleReader.F4ResourceBundleIndex();
                    int num = 0;
                    this._resourceIndex.Size = BitConverter.ToUInt32(array, num);
                    num += 4;
                    this._resourceIndex.ResourceIndexVersion = BitConverter.ToUInt32(array, num);
                    num += 4;
                    uint num2 = this._resourceIndex.Size;
                    List<F4ResourceBundleReader.F4ResourceHeader> list = new List<F4ResourceBundleReader.F4ResourceHeader>();
                    while (unchecked((ulong)num2) > 0UL)
                    {
                        F4ResourceBundleReader.F4ResourceBundleIndex resourceIndex = this._resourceIndex;
                        ref uint ptr = ref resourceIndex.NumResources;
                        resourceIndex.NumResources = (uint)(unchecked((ulong)ptr) + 1UL);
                        uint num3 = BitConverter.ToUInt32(array, num);
                        num += 4;
                        byte[] array2 = new byte[32];
                        int num4 = 0;
                        do
                        {
                            array2[num4] = array[num];
                            num++;
                            num4++;
                        }
                        while (num4 <= 31);
                        string text = Encoding.Default.GetString(array2);
                        int num5 = text.IndexOf('\0');
                        text = ((num5 > 0) ? text.Substring(0, num5) : null);
                        if (num3 == 100U)
                        {
                            F4ResourceBundleReader.F4ImageResourceHeader f4ImageResourceHeader = new F4ResourceBundleReader.F4ImageResourceHeader
                            {
                                Type = num3,
                                ID = text,
                                Flags = BitConverter.ToUInt32(array, num)
                            };
                            num += 4;
                            f4ImageResourceHeader.CenterX = BitConverter.ToUInt16(array, num);
                            num += 2;
                            f4ImageResourceHeader.CenterY = BitConverter.ToUInt16(array, num);
                            num += 2;
                            f4ImageResourceHeader.Width = BitConverter.ToUInt16(array, num);
                            num += 2;
                            f4ImageResourceHeader.Height = BitConverter.ToUInt16(array, num);
                            num += 2;
                            f4ImageResourceHeader.ImageOffset = BitConverter.ToUInt32(array, num);
                            num += 4;
                            f4ImageResourceHeader.PaletteSize = BitConverter.ToUInt32(array, num);
                            num += 4;
                            f4ImageResourceHeader.PaletteOffset = BitConverter.ToUInt32(array, num);
                            num += 4;
                            list.Add(f4ImageResourceHeader);
                            num2 = (uint)(unchecked((ulong)num2) - 60UL);
                        }
                        else if (num3 == 101U)
                        {
                            F4ResourceBundleReader.F4SoundResourceHeader f4SoundResourceHeader = new F4ResourceBundleReader.F4SoundResourceHeader
                            {
                                Type = num3,
                                ID = text,
                                Flags = BitConverter.ToUInt32(array, num)
                            };
                            num += 4;
                            f4SoundResourceHeader.Channels = BitConverter.ToUInt16(array, num);
                            num += 2;
                            f4SoundResourceHeader.SoundType = BitConverter.ToUInt16(array, num);
                            num += 2;
                            f4SoundResourceHeader.Offset = BitConverter.ToUInt32(array, num);
                            num += 4;
                            f4SoundResourceHeader.HeaderSize = BitConverter.ToUInt32(array, num);
                            num += 4;
                            list.Add(f4SoundResourceHeader);
                            num2 = (uint)(unchecked((ulong)num2) - 52UL);
                        }
                        else if (num3 == 102U)
                        {
                            F4ResourceBundleReader.F4FlatResourceHeader f4FlatResourceHeader = new F4ResourceBundleReader.F4FlatResourceHeader
                            {
                                Type = num3,
                                ID = text,
                                Offset = BitConverter.ToUInt32(array, num)
                            };
                            num += 4;
                            f4FlatResourceHeader.Size = BitConverter.ToUInt32(array, num);
                            num += 4;
                            list.Add(f4FlatResourceHeader);
                            num2 = (uint)(unchecked((ulong)num2) - 44UL);
                        }
                    }
                    this._resourceIndex.ResourceHeaders = list.ToArray();
                    FileInfo fileInfo2 = new FileInfo(Path.GetDirectoryName(fileInfo.FullName) + Conversions.ToString(Path.DirectorySeparatorChar) + Path.GetFileNameWithoutExtension(fileInfo.FullName) + ".rsc");
                    if (fileInfo2.Exists)
                    {
                        array = new byte[(int)(fileInfo2.Length - 1L) + 1];
                        try
                        {
                            using (FileStream fileStream2 = new FileStream(fileInfo2.FullName, FileMode.Open))
                            {
                                fileStream2.Seek(0L, SeekOrigin.Begin);
                                fileStream2.Read(array, 0, (int)fileInfo2.Length);
                            }
                            F4ResourceBundleReader.F4ResourceRawDataPackage f4ResourceRawDataPackage = new F4ResourceBundleReader.F4ResourceRawDataPackage();
                            num = 0;
                            f4ResourceRawDataPackage.Size = BitConverter.ToUInt32(array, num);
                            num += 4;
                            f4ResourceRawDataPackage.Version = BitConverter.ToUInt32(array, num);
                            num += 4;
                            f4ResourceRawDataPackage.Data = new byte[(int)(unchecked((ulong)f4ResourceRawDataPackage.Size) - 1UL) + 1];
                            int num6 = Math.Min(f4ResourceRawDataPackage.Data.Length, array.Length - num);
                            Array.Copy(array, num, f4ResourceRawDataPackage.Data, 0, num6);
                            num += num6;
                            this._resourceIndex.ResourceData = f4ResourceRawDataPackage;
                            return;
                        }
                        catch (Exception ex)
                        {
                            return;
                        }
                    }
                    throw new FileNotFoundException(fileInfo2.FullName);
                }
                throw new FileNotFoundException(resourceBundleIndexPath);
            }
        }

        // Token: 0x06000191 RID: 401 RVA: 0x0003254C File Offset: 0x0003074C
        public int LoadPictureWidth(string resourceBundleIndexPath, string picName)
        {
            FileInfo fileInfo = new FileInfo(resourceBundleIndexPath);
            checked
            {
                if (fileInfo.Exists)
                {
                    byte[] array = new byte[(int)(fileInfo.Length - 1L) + 1];
                    using (FileStream fileStream = new FileStream(resourceBundleIndexPath, FileMode.Open))
                    {
                        fileStream.Seek(0L, SeekOrigin.Begin);
                        fileStream.Read(array, 0, (int)fileInfo.Length);
                    }
                    this._resourceIndex = new F4ResourceBundleReader.F4ResourceBundleIndex();
                    int num = 0;
                    this._resourceIndex.Size = BitConverter.ToUInt32(array, num);
                    num += 4;
                    this._resourceIndex.ResourceIndexVersion = BitConverter.ToUInt32(array, num);
                    num += 4;
                    uint num2 = this._resourceIndex.Size;
                    while (unchecked((ulong)num2) > 0UL)
                    {
                        F4ResourceBundleReader.F4ResourceBundleIndex resourceIndex = this._resourceIndex;
                        ref uint ptr = ref resourceIndex.NumResources;
                        resourceIndex.NumResources = (uint)(unchecked((ulong)ptr) + 1UL);
                        uint num3 = BitConverter.ToUInt32(array, num);
                        num += 4;
                        byte[] array2 = new byte[32];
                        int num4 = 0;
                        do
                        {
                            array2[num4] = array[num];
                            num++;
                            num4++;
                        }
                        while (num4 <= 31);
                        string text = Encoding.Default.GetString(array2);
                        int num5 = text.IndexOf('\0');
                        text = ((num5 > 0) ? text.Substring(0, num5) : null);
                        if (num3 == 100U)
                        {
                            F4ResourceBundleReader.F4ImageResourceHeader f4ImageResourceHeader = new F4ResourceBundleReader.F4ImageResourceHeader
                            {
                                Type = num3,
                                ID = text,
                                Flags = BitConverter.ToUInt32(array, num)
                            };
                            num += 4;
                            f4ImageResourceHeader.CenterX = BitConverter.ToUInt16(array, num);
                            num += 2;
                            f4ImageResourceHeader.CenterY = BitConverter.ToUInt16(array, num);
                            num += 2;
                            f4ImageResourceHeader.Width = BitConverter.ToUInt16(array, num);
                            num += 2;
                            f4ImageResourceHeader.Height = BitConverter.ToUInt16(array, num);
                            num += 2;
                            f4ImageResourceHeader.ImageOffset = BitConverter.ToUInt32(array, num);
                            num += 4;
                            f4ImageResourceHeader.PaletteSize = BitConverter.ToUInt32(array, num);
                            num += 4;
                            f4ImageResourceHeader.PaletteOffset = BitConverter.ToUInt32(array, num);
                            num += 4;
                            num2 = (uint)(unchecked((ulong)num2) - 60UL);
                            if (Operators.CompareString(Strings.LCase(text), Strings.LCase(picName), false) == 0)
                            {
                                return (int)f4ImageResourceHeader.Width;
                            }
                        }
                    }
                    return -1;
                }
                throw new FileNotFoundException(resourceBundleIndexPath);
            }
        }

        // Token: 0x06000192 RID: 402 RVA: 0x00032770 File Offset: 0x00030970
        public virtual F4ResourceType GetResourceType(int resourceNum)
        {
            F4ResourceType f4ResourceType;
            if ((this._resourceIndex == null) | (resourceNum < 0))
            {
                f4ResourceType = F4ResourceType.Unknown;
            }
            else
            {
                f4ResourceType = (F4ResourceType)this._resourceIndex.ResourceHeaders[resourceNum].Type;
            }
            return f4ResourceType;
        }

        // Token: 0x06000193 RID: 403 RVA: 0x000327A8 File Offset: 0x000309A8
        public virtual string GetResourceID(int resourceNum)
        {
            string text;
            if (this._resourceIndex == null)
            {
                text = null;
            }
            else
            {
                text = this._resourceIndex.ResourceHeaders[resourceNum].ID;
            }
            return text;
        }

        // Token: 0x06000194 RID: 404 RVA: 0x000327D8 File Offset: 0x000309D8
        public virtual byte[] GetSoundResource(string resourceId)
        {
            F4ResourceBundleReader.F4SoundResourceHeader f4SoundResourceHeader = this.GetResourceHeader(resourceId) as F4ResourceBundleReader.F4SoundResourceHeader;
            return this.GetSoundResource(f4SoundResourceHeader);
        }

        // Token: 0x06000195 RID: 405 RVA: 0x000327FC File Offset: 0x000309FC
        public virtual byte[] GetSoundResource(int resourceNum)
        {
            byte[] array;
            if (this._resourceIndex == null || this._resourceIndex.ResourceHeaders == null || resourceNum >= this._resourceIndex.ResourceHeaders.Length)
            {
                array = null;
            }
            else
            {
                F4ResourceBundleReader.F4SoundResourceHeader f4SoundResourceHeader = this._resourceIndex.ResourceHeaders[resourceNum] as F4ResourceBundleReader.F4SoundResourceHeader;
                array = this.GetSoundResource(f4SoundResourceHeader);
            }
            return array;
        }

        // Token: 0x06000196 RID: 406 RVA: 0x00032850 File Offset: 0x00030A50
        protected virtual byte[] GetSoundResource(F4ResourceBundleReader.F4SoundResourceHeader resourceHeader)
        {
            checked
            {
                byte[] array;
                if (resourceHeader == null)
                {
                    array = null;
                }
                else
                {
                    int num = (int)resourceHeader.Offset;
                    num += 4;
                    uint num2 = BitConverter.ToUInt32(this._resourceIndex.ResourceData.Data, num);
                    num += 4;
                    byte[] array2 = new byte[(int)(unchecked((ulong)num2) + 7UL) + 1];
                    Array.Copy(this._resourceIndex.ResourceData.Data, unchecked((long)(checked(num - 8))), array2, 0L, (long)(unchecked((ulong)num2) + 8UL));
                    array = array2;
                }
                return array;
            }
        }

        // Token: 0x06000197 RID: 407 RVA: 0x000328C0 File Offset: 0x00030AC0
        public virtual byte[] GetFlatResource(int resourceNum)
        {
            byte[] array;
            if (this._resourceIndex == null || this._resourceIndex.ResourceHeaders == null || resourceNum >= this._resourceIndex.ResourceHeaders.Length)
            {
                array = null;
            }
            else
            {
                F4ResourceBundleReader.F4FlatResourceHeader f4FlatResourceHeader = this._resourceIndex.ResourceHeaders[resourceNum] as F4ResourceBundleReader.F4FlatResourceHeader;
                array = this.GetFlatResource(f4FlatResourceHeader);
            }
            return array;
        }

        // Token: 0x06000198 RID: 408 RVA: 0x00032914 File Offset: 0x00030B14
        public virtual byte[] GetFlatResource(string resourceId)
        {
            F4ResourceBundleReader.F4FlatResourceHeader f4FlatResourceHeader = this.GetResourceHeader(resourceId) as F4ResourceBundleReader.F4FlatResourceHeader;
            return this.GetFlatResource(f4FlatResourceHeader);
        }

        // Token: 0x06000199 RID: 409 RVA: 0x00032938 File Offset: 0x00030B38
        protected virtual byte[] GetFlatResource(F4ResourceBundleReader.F4FlatResourceHeader resourceHeader)
        {
            checked
            {
                byte[] array;
                if (resourceHeader == null)
                {
                    array = null;
                }
                else
                {
                    byte[] array2 = new byte[(int)(unchecked((ulong)resourceHeader.Size) - 1UL) + 1];
                    int num = (int)(unchecked((ulong)resourceHeader.Size) - 1UL);
                    for (int i = 0; i <= num; i++)
                    {
                        array2[i] = this._resourceIndex.ResourceData.Data[(int)(unchecked((ulong)resourceHeader.Offset) + (ulong)(unchecked((long)i)))];
                    }
                    array = array2;
                }
                return array;
            }
        }

        // Token: 0x0600019A RID: 410 RVA: 0x0003299C File Offset: 0x00030B9C
        public virtual Bitmap GetImageResource(string resourceId)
        {
            F4ResourceBundleReader.F4ImageResourceHeader f4ImageResourceHeader = this.GetResourceHeader(resourceId) as F4ResourceBundleReader.F4ImageResourceHeader;
            return this.GetImageResource(f4ImageResourceHeader);
        }

        // Token: 0x0600019B RID: 411 RVA: 0x000329C0 File Offset: 0x00030BC0
        public virtual Bitmap GetImageResource(int resourceNum)
        {
            Bitmap bitmap;
            if (this._resourceIndex == null || this._resourceIndex.ResourceHeaders == null || resourceNum >= this._resourceIndex.ResourceHeaders.Length)
            {
                bitmap = null;
            }
            else
            {
                F4ResourceBundleReader.F4ImageResourceHeader f4ImageResourceHeader = this._resourceIndex.ResourceHeaders[resourceNum] as F4ResourceBundleReader.F4ImageResourceHeader;
                bitmap = this.GetImageResource(f4ImageResourceHeader);
            }
            return bitmap;
        }

        // Token: 0x0600019C RID: 412 RVA: 0x00032A14 File Offset: 0x00030C14
        public virtual int GetImageWidth(int resourceNum)
        {
            int num;
            if (this._resourceIndex == null || this._resourceIndex.ResourceHeaders == null || resourceNum >= this._resourceIndex.ResourceHeaders.Length)
            {
                num = 0;
            }
            else
            {
                num = (int)(this._resourceIndex.ResourceHeaders[resourceNum] as F4ResourceBundleReader.F4ImageResourceHeader).Width;
            }
            return num;
        }

        // Token: 0x0600019D RID: 413 RVA: 0x00032A64 File Offset: 0x00030C64
        protected virtual Bitmap GetImageResource(F4ResourceBundleReader.F4ImageResourceHeader imageHeader)
        {
            checked
            {
                Bitmap bitmap;
                if (imageHeader == null)
                {
                    bitmap = null;
                }
                else
                {
                    Bitmap bitmap2 = new Bitmap((int)imageHeader.Width, (int)imageHeader.Height);
                    ushort[] array = new ushort[(int)(unchecked((ulong)imageHeader.PaletteSize) - 1UL) + 1];
                    if ((imageHeader.Flags & 1U) == 1U)
                    {
                        int num = array.Length - 1;
                        for (int i = 0; i <= num; i++)
                        {
                            array[i] = BitConverter.ToUInt16(this._resourceIndex.ResourceData.Data, (int)imageHeader.PaletteOffset + i * 2);
                        }
                    }
                    int num2 = 0;
                    int num3 = (int)(imageHeader.Height - 1);
                    for (int j = 0; j <= num3; j++)
                    {
                        int num4 = (int)(imageHeader.Width - 1);
                        for (int k = 0; k <= num4; k++)
                        {
                            int num5 = 0;
                            int num6 = 0;
                            int num7 = 0;
                            int num8 = 0;
                            if ((imageHeader.Flags & 1U) == 1U)
                            {
                                byte b = this._resourceIndex.ResourceData.Data[(int)(unchecked((ulong)imageHeader.ImageOffset) + (ulong)(unchecked((long)num2)))];
                                ushort num9 = array[(int)b];
                                num5 = 255;
                                num6 = (num9 & 31744) >> 10 << 3;
                                num7 = (num9 & 992) >> 5 << 3;
                                num8 = (int)(num9 & 31) << 3;
                                num2++;
                            }
                            else if ((imageHeader.Flags & 2U) == 2U)
                            {
                                ushort num10 = BitConverter.ToUInt16(this._resourceIndex.ResourceData.Data, (int)(unchecked((ulong)imageHeader.ImageOffset) + (ulong)(unchecked((long)num2))));
                                num5 = 255;
                                num6 = (num10 & 31744) >> 10 << 3;
                                num7 = (num10 & 992) >> 5 << 3;
                                num8 = (int)(num10 & 31) << 3;
                                num2 += 2;
                            }
                            bitmap2.SetPixel(k, j, Color.FromArgb(num5, num6, num7, num8));
                        }
                    }
                    bitmap = bitmap2;
                }
                return bitmap;
            }
        }

        // Token: 0x0600019E RID: 414 RVA: 0x00032C08 File Offset: 0x00030E08
        protected virtual F4ResourceBundleReader.F4ResourceHeader GetResourceHeader(string resourceId)
        {
            checked
            {
                F4ResourceBundleReader.F4ResourceHeader f4ResourceHeader;
                if (this._resourceIndex == null || this._resourceIndex.ResourceHeaders == null || resourceId == null)
                {
                    f4ResourceHeader = null;
                }
                else
                {
                    int num = this._resourceIndex.ResourceHeaders.Length - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        if (Operators.CompareString(this._resourceIndex.ResourceHeaders[i].ID, resourceId, false) == 0)
                        {
                            return this._resourceIndex.ResourceHeaders[i];
                        }
                    }
                    f4ResourceHeader = null;
                }
                return f4ResourceHeader;
            }
        }

        // Token: 0x0400018A RID: 394
        private const string RESOURCE_FILE_EXTENSION = ".rsc";

        // Token: 0x0400018B RID: 395
        private F4ResourceBundleReader.F4ResourceBundleIndex _resourceIndex;

        // Token: 0x020000D5 RID: 213
        protected internal class F4FlatResourceHeader : F4ResourceBundleReader.F4ResourceHeader
        {
            // Token: 0x0400176D RID: 5997
            public uint Offset;

            // Token: 0x0400176E RID: 5998
            public uint Size;
        }

        // Token: 0x020000D6 RID: 214
        protected internal class F4ImageResourceHeader : F4ResourceBundleReader.F4ResourceHeader
        {
            // Token: 0x0400176F RID: 5999
            public ushort CenterX;

            // Token: 0x04001770 RID: 6000
            public ushort CenterY;

            // Token: 0x04001771 RID: 6001
            public uint Flags;

            // Token: 0x04001772 RID: 6002
            public ushort Height;

            // Token: 0x04001773 RID: 6003
            public uint ImageOffset;

            // Token: 0x04001774 RID: 6004
            public uint PaletteOffset;

            // Token: 0x04001775 RID: 6005
            public uint PaletteSize;

            // Token: 0x04001776 RID: 6006
            public ushort Width;
        }

        // Token: 0x020000D7 RID: 215
        protected internal class F4ResourceBundleIndex
        {
            // Token: 0x04001777 RID: 6007
            public uint NumResources;

            // Token: 0x04001778 RID: 6008
            public F4ResourceBundleReader.F4ResourceRawDataPackage ResourceData;

            // Token: 0x04001779 RID: 6009
            public F4ResourceBundleReader.F4ResourceHeader[] ResourceHeaders;

            // Token: 0x0400177A RID: 6010
            public uint ResourceIndexVersion;

            // Token: 0x0400177B RID: 6011
            public uint Size;
        }

        // Token: 0x020000D8 RID: 216
        [Flags]
        protected internal enum F4ResourceFlags : uint
        {
            // Token: 0x0400177D RID: 6013
            EightBit = 1U,
            // Token: 0x0400177E RID: 6014
            SixteenBit = 2U,
            // Token: 0x0400177F RID: 6015
            UseColorKey = 1073741824U
        }

        // Token: 0x020000D9 RID: 217
        protected internal class F4ResourceHeader
        {
            // Token: 0x04001780 RID: 6016
            public string ID;

            // Token: 0x04001781 RID: 6017
            public uint Type;
        }

        // Token: 0x020000DA RID: 218
        protected internal class F4ResourceRawDataPackage
        {
            // Token: 0x04001782 RID: 6018
            public byte[] Data;

            // Token: 0x04001783 RID: 6019
            public uint Size;

            // Token: 0x04001784 RID: 6020
            public uint Version;
        }

        // Token: 0x020000DB RID: 219
        protected internal class F4SoundResourceHeader : F4ResourceBundleReader.F4ResourceHeader
        {
            // Token: 0x04001785 RID: 6021
            public ushort Channels;

            // Token: 0x04001786 RID: 6022
            public uint Flags;

            // Token: 0x04001787 RID: 6023
            public uint HeaderSize;

            // Token: 0x04001788 RID: 6024
            public uint Offset;

            // Token: 0x04001789 RID: 6025
            public ushort SoundType;
        }
    }
}
