using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class StationsILSData
    {
        // Token: 0x04001A5D RID: 6749
        public short CampId;

        // Token: 0x04001A5E RID: 6750
        public short TCN_Channel;

        // Token: 0x04001A5F RID: 6751
        public string TCN_Band;

        // Token: 0x04001A60 RID: 6752
        public short TCN_Callsign;

        // Token: 0x04001A61 RID: 6753
        public short TCN_Range;

        // Token: 0x04001A62 RID: 6754
        public short TCN_Type;

        // Token: 0x04001A63 RID: 6755
        public int UHF;

        // Token: 0x04001A64 RID: 6756
        public int VHF;

        // Token: 0x04001A65 RID: 6757
        public int ILS_1;

        // Token: 0x04001A66 RID: 6758
        public int ILS_2;

        // Token: 0x04001A67 RID: 6759
        public int ILS_3;

        // Token: 0x04001A68 RID: 6760
        public int ILS_4;

        // Token: 0x04001A69 RID: 6761
        public string Comment1;

        // Token: 0x04001A6A RID: 6762
        public string Comment2;

        // Token: 0x04001A6B RID: 6763
        public int OpsUHF;

        // Token: 0x04001A6C RID: 6764
        public int GroundUHF;

        // Token: 0x04001A6D RID: 6765
        public int ApproachUHF;

        // Token: 0x04001A6E RID: 6766
        public int LsoUHF;

        // Token: 0x04001A6F RID: 6767
        public int ATIS_freq_VHF;

        public static string FormatILS(int ils)
        {
            string s = ils.ToString();
            if (s.Length > 2)
                return s.Substring(0, s.Length - 2) + "." + s.Substring(s.Length - 2);
            return s;
        }
        public String GetILSString()
        {
            List<string> parts = new List<string>();
            if (ILS_1 > 0)
                parts.Add(FormatILS(ILS_1));
            if (ILS_2 > 0)
                parts.Add(FormatILS(ILS_2));
            if (ILS_3 > 0)
                parts.Add(FormatILS(ILS_3));
            if (ILS_4 > 0)
                parts.Add(FormatILS(ILS_4));

            return string.Join(", ", parts);

        }
    }
}
