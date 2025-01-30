using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.UI
{
    public class DashPatternListItem
    {
        public float[] DashPattern { get; set; }
        public string Name { get; set; }

        public DashPatternListItem(float[] pattern, string name)
        {
            DashPattern = pattern;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
