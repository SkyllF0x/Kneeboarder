using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class L16File
    {
        public string VoiceAChannel { get; set; } = "000";
        public string VoiceBChannel { get; set; } = "000";
        public string MsnChannel { get; set; } = "000";
        public string FighterChannel { get; set; } = "000";
        public string SpecialChannel { get; set; } = "000";

        public string Callsign { get; set; } = "  ";
        public string CallsignNumber { get; set; } = "11";
        public bool FlightLead { get; set; } = false;
        public bool ETR { get; set; } = false;
        public int TcnChannel { get; set; } = 75;
        public string TcnBand { get; set; } = "X";
        public string[] FlightSTNs { get; set; } = new string[] { "", "", "", "" };
        public string[] TeamSTNs { get; set; } = new string[] { "", "", "", "" };
        public string[] DonorSTNs { get; set; } = new string[] { "", "", "", "", "", "", "", "" };

    }
}
