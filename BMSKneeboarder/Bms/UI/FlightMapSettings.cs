using BMSKneeboarder.Bms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.UI
{
    public class FlightMapSettings
    {
        public Flight Flight { get; set; }

        public Pen FlightPlanPen { get; set; }

        public bool ShowOnMap { get; set; } = false;

        public String DisplayName { get; set; }

        public String Mission { get; set; }

        public FlightMapSettings(Flight flight, string callsign, string mission)
        {
            Flight = flight;
            DisplayName = callsign + " - " + mission;
            Mission = mission;

            switch (mission)
            {
                case "BARCAP": case "TARCAP": case "SWEEP": case "HAVCAP": case "DCA": FlightPlanPen = new Pen(Color.Yellow, 4); FlightPlanPen.DashPattern = [4, 2]; break;
                case "STRIKE": case "DEAD": FlightPlanPen = new Pen(Color.Red, 4); FlightPlanPen.DashPattern = [4, 2]; break;
                default: FlightPlanPen = new Pen(Color.Black, 4); FlightPlanPen.DashPattern = [4, 2]; break;
            }
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
