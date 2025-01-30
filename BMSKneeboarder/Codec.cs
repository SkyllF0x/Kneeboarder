using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder
{
    public static class Codec
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public static byte[] Compress(byte[] toCompress)
        {
            byte[] array = new byte[(toCompress.Length > 10485760) ? (toCompress.Length + 1024) : 10485760];
            int num = Codec.Compress(toCompress, 0, toCompress.Length, array, 0);
            num += 6;
            byte[] array2 = new byte[num];
            Array.Copy(array, array2, num);
            return array2;
        }

        // Token: 0x06000002 RID: 2 RVA: 0x000020A0 File Offset: 0x000002A0
        public static byte[] Decompress(byte[] toDecompress, int uncompressedDataSize)
        {
            byte[] array = new byte[uncompressedDataSize];
            Codec.Decompress(toDecompress, 0, array, 0, uncompressedDataSize);
            return array;
        }

        // Token: 0x06000003 RID: 3 RVA: 0x000020C0 File Offset: 0x000002C0
        public static int Compress(Stream nonCompressedDataStream, int nonCompressedDataLength, Stream outputStream)
        {
            byte[] array = new byte[nonCompressedDataLength];
            nonCompressedDataStream.Read(array, 0, nonCompressedDataLength);
            byte[] array2 = Codec.Compress(array);
            outputStream.Write(array2, 0, array2.Length);
            outputStream.Flush();
            return array2.Length;
        }

        // Token: 0x06000004 RID: 4 RVA: 0x000020FC File Offset: 0x000002FC
        public static void Decompress(Stream compressedDataStream, int compressedDataLength, Stream outputStream, int uncompressedDataLength)
        {
            byte[] array = new byte[compressedDataLength];
            compressedDataStream.Read(array, 0, compressedDataLength);
            byte[] array2 = Codec.Decompress(array, uncompressedDataLength);
            outputStream.Write(array2, 0, array2.Length);
            outputStream.Flush();
        }

        // Token: 0x06000005 RID: 5 RVA: 0x00002134 File Offset: 0x00000334
        public static int Compress(byte[] nonCompressedDataBuffer, int nonCompressedDataStartingOffset, int nonCompressedDataLength, byte[] compressedDataBuffer, int compressedDataBufferStartingOffset)
        {
            GCHandle gchandle = GCHandle.Alloc(nonCompressedDataBuffer);
            GCHandle gchandle2 = GCHandle.Alloc(compressedDataBuffer);
            IntPtr intPtr = Marshal.UnsafeAddrOfPinnedArrayElement(nonCompressedDataBuffer, nonCompressedDataStartingOffset);
            IntPtr intPtr2 = Marshal.UnsafeAddrOfPinnedArrayElement(compressedDataBuffer, compressedDataBufferStartingOffset);
            int num = NativeMethods.LZSS_Compress(intPtr, intPtr2, nonCompressedDataLength);
            gchandle.Free();
            gchandle2.Free();
            return num;
        }

        // Token: 0x06000006 RID: 6 RVA: 0x00002174 File Offset: 0x00000374
        public static int Decompress(byte[] compressedDataBuffer, int compressedDataBufferStartingOffset, byte[] decompressedDataBuffer, int decompressedDataStartingOffset, int decompressedDataLength)
        {
            GCHandle gchandle = GCHandle.Alloc(decompressedDataBuffer);
            GCHandle gchandle2 = GCHandle.Alloc(compressedDataBuffer);
            IntPtr intPtr = Marshal.UnsafeAddrOfPinnedArrayElement(decompressedDataBuffer, decompressedDataStartingOffset);
            int num = NativeMethods.LZSS_Expand(Marshal.UnsafeAddrOfPinnedArrayElement(compressedDataBuffer, compressedDataBufferStartingOffset), intPtr, decompressedDataLength);
            gchandle.Free();
            gchandle2.Free();
            return num;
        }

        // Token: 0x04000001 RID: 1
        private const int DEFAULT_OUTPUT_BUFFER_SIZE = 10485760;
    }
}
