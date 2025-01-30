using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder
{
    public static class NativeMethods
    {
        // Token: 0x06000007 RID: 7
        [DllImport("LzssNative.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int LZSS_Compress(IntPtr nonCompressedDataBuffer, IntPtr compressedDataBuffer, int nonCompressedDataSize);

        // Token: 0x06000008 RID: 8
        [DllImport("LzssNative.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int LZSS_Expand(IntPtr compressedDataBuffer, IntPtr decompressedDataBuffer, int decompressedDataSize);
    }
}
