using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.UI
{
    public class KneeboardPageLayout : IDisposable
    {
        public PageType PageType { get; set; }
        public Bitmap Image { get; set; } = null;
        public int Saturation { get; set; }

        public MapSettings MapSettings { get; set; }

        public KneeboardPageLayout() 
        {
            PageType = PageType.Blank;
            Image = null;
            Saturation = 100;
            MapSettings = new MapSettings();
        }

        public void Dispose()
        {
            if (Image != null)
            {
                Image.Dispose();
            }
            MapSettings.Dispose();
        }
    }
}
