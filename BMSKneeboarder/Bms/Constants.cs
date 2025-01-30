using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms
{
    public enum IconColor
    {
        Blue = 2, Brown = 3, Gray = 7, Green = 1, Orange = 4, Red = 6, White = 0, Yellow = 5
    }
    public static class Constants
    {
        
        public const float KM_TO_FT = 3279.98f;
        public const float KM_TO_NM = 0.5398847f;
        public const int VEHICLES_PER_UNIT = 16;
        public const int MAXIMUM_ROLES = 16;
        public const float METERS_TO_FT = 3.28084f;
        public const int HARDPOINTS_MAX = 16;
        public const int MAX_FEAT_DEPEND_LEGACY = 5;
        public const int MAX_FEAT_DEPEND = 10;
        public static Dictionary<IconColor, string> IconColors = new Dictionary<IconColor, string>(new KeyValuePair<IconColor, string>[] { 
            new KeyValuePair<IconColor, string>(IconColor.Blue, "bludark.idx"),
            new KeyValuePair<IconColor, string>(IconColor.Brown, "brndark.idx"),
            new KeyValuePair<IconColor, string>(IconColor.Gray, "grydark.idx"),
            new KeyValuePair<IconColor, string>(IconColor.Green, "grndark.idx"),
            new KeyValuePair<IconColor, string>(IconColor.Orange, "orndark.idx"),
            new KeyValuePair<IconColor, string>(IconColor.Red, "reddark.idx"),
            new KeyValuePair<IconColor, string>(IconColor.White, "whtdark.idx"),
            new KeyValuePair<IconColor, string>(IconColor.Yellow, "ylwdark.idx"),
        });
    }
}
