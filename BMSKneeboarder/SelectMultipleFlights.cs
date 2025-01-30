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
    public partial class SelectMultipleFlights : Form
    {
        private MissionData missionData;

        public Flight[] SelectedFlights
        {
            get
            {
                return lbSelectedFlights.Items.Cast<FlightListItem>().Select(x => x.Flight).ToArray();
            }
            set
            {
                lbSelectedFlights.Items.Clear();
                foreach (Flight flight in value)
                {
                    Package package = missionData.PackageList.FirstOrDefault(x => x.id == flight.package);
                    lbSelectedFlights.Items.Add(new FlightListItem(package == null ? (short)0 : package.name_id, flight, missionData.GetFlightCallsign(flight), missionData.GetFlightMission(flight)));
                    Search();
                }
            }
        }

        private void Search()
        {
            lbFlights.Items.Clear();

            foreach (Flight flight in missionData.FlightList)
            {
                if (lbSelectedFlights.Items.Cast<FlightListItem>().Where(x => x.FlightId == flight.id).Count() == 0)
                {
                    Package package = missionData.PackageList.FirstOrDefault(x => x.id == flight.package);
                    FlightListItem item = new FlightListItem(package == null ? (short)0 : package.name_id, flight, missionData.GetFlightCallsign(flight), missionData.GetFlightMission(flight));
                    if (string.IsNullOrEmpty(tbSearch.Text) || item.DisplayName.ToLower().Contains(tbSearch.Text.ToLower()))
                        lbFlights.Items.Add(item);
                }
            }
        }

        public SelectMultipleFlights(MissionData missionData)
        {
            this.missionData = missionData;

            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SelectMultipleFlights_Load(object sender, EventArgs e)
        {
            Search();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (FlightListItem item in lbFlights.SelectedItems.Cast<FlightListItem>())
            {
                lbSelectedFlights.Items.Add(item);

            }
            Search();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (FlightListItem item in lbSelectedFlights.SelectedItems.Cast<FlightListItem>())
            {
                lbFlights.Items.Add(item);
            }
            for (int i = lbSelectedFlights.SelectedItems.Count - 1; i >= 0; i--)
            {
                lbSelectedFlights.Items.Remove(lbSelectedFlights.SelectedItems[i]);
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SelectMultipleFlights_Shown(object sender, EventArgs e)
        {
            tbSearch.Focus();
        }
    }
}
