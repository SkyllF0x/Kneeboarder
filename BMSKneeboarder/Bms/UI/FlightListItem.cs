using BMSKneeboarder.Bms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.UI
{
    public class FlightListItem
    {
        public BmsStructs.BmsId PackageId { get { return Flight.package; } }
        public short PackageNo { get; set; }
        public BmsStructs.BmsId FlightId { get { return Flight.id; } }
        public string FlightCallsign { get; set; }
        public string Mission { get; set; }
        public string DisplayName { get { return PackageNo + " - " + FlightCallsign + " - " + Mission; } }

        public Flight Flight {  get; set; }

        public FlightListItem(short packageNo, Flight flight, string flightCallsign, string mission)
        {
            PackageNo = packageNo;
            Flight = flight;
            FlightCallsign = flightCallsign;
            Mission = mission;
        }

        public override string ToString()
        {
            return DisplayName;
        }

    }
}
