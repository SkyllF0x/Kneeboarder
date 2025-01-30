using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class Point2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool IsZero
        {
            get { return Math.Abs(X) + Math.Abs(Y) < 1e-6; }
        }
    }
}
