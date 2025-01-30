using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.UI
{
    public class TheaterListItem
    {
        public TheaterListItem() { }
        public TheaterListItem(string theaterFile, string name, string dir) {
            TheaterFile = theaterFile;
            TheaterDir = dir;
            Name = name;
        }

        public string TheaterDir { get; set; }
        public string TheaterFile { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
