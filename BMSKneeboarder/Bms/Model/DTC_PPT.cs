using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class DTC_PPT
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double R { get; set; }
        public string Text { get; set; }
        public int PptNum { get; set; }

        public DTC_PPT() {
            X = 0;
            Y = 0;
            R = 0;
            Text = string.Empty;
        }

        public DTC_PPT(int pptNum)
        {
            this.PptNum = pptNum;
        }

        public DTC_PPT(double X, double Y, double R, string text)
        {
            this.X = X;
            this.Y = Y;
            this.R = R;
            this.Text = text;
        }

        public bool IsZero
        {
            get { return Math.Abs(X) + Math.Abs(Y) < 1e-6; }
        }

        public override string ToString()
        {
            return Text + " / " + PptNum;
        }
    }
}
