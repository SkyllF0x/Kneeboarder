using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.UI
{
    public class KneeboardLayout : IDisposable
    {
        /*public List<PageType> LeftPageTypes { get; set; }
        public List<PageType> RightPageTypes { get; set; }

        public List<Dictionary<string, string>> LeftPageSettings { get; set; }
        public List<Dictionary<string, string>> RightPageSettings { get; set; }*/

        public List<KneeboardPageLayout> Pages { get; set; }

        public List<KneeboardPageLayout> LeftPages 
        {
            get
            {
                return Pages.SkipLast(16).ToList();
            }
        }

        public List<KneeboardPageLayout> RightPages
        {
            get
            {
                return Pages.Skip(16).ToList();
            }
        }

        

        public KneeboardLayout() {
            Pages = new List<KneeboardPageLayout>();

            for (int i = 0; i < 32; i++)
                Pages.Add(new KneeboardPageLayout());
        }

        public void Dispose()
        {
            foreach (KneeboardPageLayout kpl in Pages)
                kpl.Dispose();
        }
    }
}
