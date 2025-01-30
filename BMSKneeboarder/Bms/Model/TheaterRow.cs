using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class TheaterRow : IDisposable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Bitmap TheaterMap { get; set; }
        public Bitmap TheaterMap2 { get; set; }

        public void Dispose()
        {
            if (TheaterMap != null)
                TheaterMap.Dispose();
            if (TheaterMap2 != null)
                TheaterMap2.Dispose();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
