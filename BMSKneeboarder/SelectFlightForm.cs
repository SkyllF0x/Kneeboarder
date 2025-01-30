using BMSKneeboarder.Bms;
using BMSKneeboarder.Bms.Model;
using BMSKneeboarder.Bms.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMSKneeboarder
{
    public partial class SelectFlightForm : Form
    {


        public FlightListItem SelectedFlight
        {
            get
            {
                return lbFlights.SelectedItem as FlightListItem;
            }
        }

        private List<FlightListItem> flightItems = new List<FlightListItem>();
        private void search()
        {
            lbFlights.Items.Clear();

            string s = tbSearch.Text.ToLower();

            foreach (FlightListItem flightItem in flightItems)
            {
                if (string.IsNullOrEmpty(s) || flightItem.DisplayName.ToLower().Contains(s))
                    lbFlights.Items.Add(flightItem);
            }
        }



        public SelectFlightForm(MissionData missionData)
        {
            InitializeComponent();

            lbFlights.Items.Clear();

            for (int i = 0; i < missionData.PackageList.Count; i++)
            {
                for (int j = 0; j < missionData.FlightList.Count; j++)
                {
                    if (missionData.FlightList[j].package == missionData.PackageList[i].id)
                    {
                        flightItems.Add(new FlightListItem(missionData.PackageList[i].name_id, missionData.FlightList[j], missionData.CallsignList[missionData.FlightList[j].callsign_id].Name + missionData.FlightList[j].callsign_num, missionData.GetFlightMission(missionData.FlightList[j])));
                    }
                }
            }

            search();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lbFlights.SelectedItem != null)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void SelectFlightForm_Load(object sender, EventArgs e)
        {

        }

        private void SelectFlightForm_Shown(object sender, EventArgs e)
        {
            tbSearch.Focus();
        }
    }
}
