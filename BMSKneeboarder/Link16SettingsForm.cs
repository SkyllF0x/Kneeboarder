using BMSKneeboarder.Bms;
using BMSKneeboarder.Bms.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMSKneeboarder
{

    public partial class Link16SettingsForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger("default");

        private MissionData missionData;

        private Regex re2Digits = new Regex("^\\d{2,2}$");
        private Regex re3Digits = new Regex("^\\d{3,3}$");
        private Regex reSTN = new Regex("^(\\d{4,4}[1-4])|(00000)$");
        private Regex reSTN4 = new Regex("^\\d{4,4}$");
        private Regex re2Letters = new Regex("^[A-Z, ]{2,2}$");
        private List<L16Flight> flightItems = new List<L16Flight>();

        public Link16SettingsForm(MissionData missionData)
        {
            this.missionData = missionData;

            InitializeComponent();
        }

        private void UpdateUI()
        {
            tbFA_VoiceAChnl.Text = missionData.L16Files["A"].VoiceAChannel.PadLeft(3, '0');
            tbFA_VoiceBChnl.Text = missionData.L16Files["A"].VoiceBChannel.PadLeft(3, '0');
            tbFA_MsnChnl.Text = missionData.L16Files["A"].MsnChannel.PadLeft(3, '0');
            tbFA_FighterChnl.Text = missionData.L16Files["A"].FighterChannel.PadLeft(3, '0');
            tbFA_SpecChnl.Text = missionData.L16Files["A"].SpecialChannel.PadLeft(3, '0');
            tbFA_Callsign.Text = missionData.L16Files["A"].Callsign.PadLeft(2, ' ');
            tbFA_CallsignNum.Text = missionData.L16Files["A"].CallsignNumber.PadLeft(2, '0');
            cbFA_FlightLead.Checked = missionData.L16Files["A"].FlightLead;
            cbFA_ETR.Checked = missionData.L16Files["A"].ETR;
            udFA_TcnChnl.Value = missionData.L16Files["A"].TcnChannel;
            cbFA_TcnBand.SelectedIndex = cbFA_TcnBand.Items.IndexOf(missionData.L16Files["A"].TcnBand);
            tbFA_Flight1.Text = missionData.L16Files["A"].FlightSTNs[0].PadLeft(5, '0');
            tbFA_Flight2.Text = missionData.L16Files["A"].FlightSTNs[1].PadLeft(5, '0'); 
            tbFA_Flight3.Text = missionData.L16Files["A"].FlightSTNs[2].PadLeft(5, '0');
            tbFA_Flight4.Text = missionData.L16Files["A"].FlightSTNs[3].PadLeft(5, '0'); 
            tbFA_Team1.Text = missionData.L16Files["A"].TeamSTNs[0].PadLeft(5, '0');
            tbFA_Team2.Text = missionData.L16Files["A"].TeamSTNs[1].PadLeft(5, '0');
            tbFA_Team3.Text = missionData.L16Files["A"].TeamSTNs[2].PadLeft(5, '0');
            tbFA_Team4.Text = missionData.L16Files["A"].TeamSTNs[3].PadLeft(5, '0');
            tbFA_Donor1.Text = missionData.L16Files["A"].DonorSTNs[0].PadLeft(5, '0');
            tbFA_Donor2.Text = missionData.L16Files["A"].DonorSTNs[1].PadLeft(5, '0');
            tbFA_Donor3.Text = missionData.L16Files["A"].DonorSTNs[2].PadLeft(5, '0');
            tbFA_Donor4.Text = missionData.L16Files["A"].DonorSTNs[3].PadLeft(5, '0');
            tbFA_Donor5.Text = missionData.L16Files["A"].DonorSTNs[4].PadLeft(5, '0');
            tbFA_Donor6.Text = missionData.L16Files["A"].DonorSTNs[5].PadLeft(5, '0');
            tbFA_Donor7.Text = missionData.L16Files["A"].DonorSTNs[6].PadLeft(5, '0');
            tbFA_Donor8.Text = missionData.L16Files["A"].DonorSTNs[7].PadLeft(5, '0');

            tbFB_VoiceAChnl.Text = missionData.L16Files["B"].VoiceAChannel.PadLeft(3, '0');
            tbFB_VoiceBChnl.Text = missionData.L16Files["B"].VoiceBChannel.PadLeft(3, '0');
            tbFB_MsnChnl.Text = missionData.L16Files["B"].MsnChannel.PadLeft(3, '0');
            tbFB_FighterChnl.Text = missionData.L16Files["B"].FighterChannel.PadLeft(3, '0');
            tbFB_SpecChnl.Text = missionData.L16Files["B"].SpecialChannel.PadLeft(3, '0');
            tbFB_Callsign.Text = missionData.L16Files["B"].Callsign.PadLeft(2, ' ');
            tbFB_CallsignNum.Text = missionData.L16Files["B"].CallsignNumber.PadLeft(2, '0');
            cbFB_FlightLead.Checked = missionData.L16Files["B"].FlightLead;
            cbFB_ETR.Checked = missionData.L16Files["B"].ETR;
            udFB_TcnChnl.Value = missionData.L16Files["B"].TcnChannel;
            cbFB_TcnBand.SelectedIndex = cbFB_TcnBand.Items.IndexOf(missionData.L16Files["B"].TcnBand);
            tbFB_Flight1.Text = missionData.L16Files["B"].FlightSTNs[0].PadLeft(5, '0');
            tbFB_Flight2.Text = missionData.L16Files["B"].FlightSTNs[1].PadLeft(5, '0');
            tbFB_Flight3.Text = missionData.L16Files["B"].FlightSTNs[2].PadLeft(5, '0');
            tbFB_Flight4.Text = missionData.L16Files["B"].FlightSTNs[3].PadLeft(5, '0');
            tbFB_Team1.Text = missionData.L16Files["B"].TeamSTNs[0].PadLeft(5, '0');
            tbFB_Team2.Text = missionData.L16Files["B"].TeamSTNs[1].PadLeft(5, '0');
            tbFB_Team3.Text = missionData.L16Files["B"].TeamSTNs[2].PadLeft(5, '0');
            tbFB_Team4.Text = missionData.L16Files["B"].TeamSTNs[3].PadLeft(5, '0');
            tbFB_Donor1.Text = missionData.L16Files["B"].DonorSTNs[0].PadLeft(5, '0');
            tbFB_Donor2.Text = missionData.L16Files["B"].DonorSTNs[1].PadLeft(5, '0');
            tbFB_Donor3.Text = missionData.L16Files["B"].DonorSTNs[2].PadLeft(5, '0');
            tbFB_Donor4.Text = missionData.L16Files["B"].DonorSTNs[3].PadLeft(5, '0');
            tbFB_Donor5.Text = missionData.L16Files["B"].DonorSTNs[4].PadLeft(5, '0');
            tbFB_Donor6.Text = missionData.L16Files["B"].DonorSTNs[5].PadLeft(5, '0');
            tbFB_Donor7.Text = missionData.L16Files["B"].DonorSTNs[6].PadLeft(5, '0');
            tbFB_Donor8.Text = missionData.L16Files["B"].DonorSTNs[7].PadLeft(5, '0');

            ValidateAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            log.Debug(">> Link16 SaveToDTC");
            if (ValidateAll())
            {
                missionData.L16Files["A"].VoiceAChannel = tbFA_VoiceAChnl.Text;
                missionData.L16Files["A"].VoiceBChannel = tbFA_VoiceBChnl.Text;
                missionData.L16Files["A"].MsnChannel = tbFA_MsnChnl.Text;
                missionData.L16Files["A"].FighterChannel = tbFA_FighterChnl.Text;
                missionData.L16Files["A"].SpecialChannel = tbFA_SpecChnl.Text;
                missionData.L16Files["A"].Callsign = tbFA_Callsign.Text;
                missionData.L16Files["A"].CallsignNumber = tbFA_CallsignNum.Text;
                missionData.L16Files["A"].FlightLead = cbFA_FlightLead.Checked;
                missionData.L16Files["A"].ETR = cbFA_ETR.Checked;
                missionData.L16Files["A"].TcnChannel = Convert.ToInt32(udFA_TcnChnl.Value);
                missionData.L16Files["A"].TcnBand = cbFA_TcnBand.Items[cbFA_TcnBand.SelectedIndex].ToString();
                missionData.L16Files["A"].FlightSTNs[0] = tbFA_Flight1.Text;
                missionData.L16Files["A"].FlightSTNs[1] = tbFA_Flight2.Text;
                missionData.L16Files["A"].FlightSTNs[2] = tbFA_Flight3.Text;
                missionData.L16Files["A"].FlightSTNs[3] = tbFA_Flight4.Text;
                missionData.L16Files["A"].TeamSTNs[0] = tbFA_Team1.Text;
                missionData.L16Files["A"].TeamSTNs[1] = tbFA_Team2.Text;
                missionData.L16Files["A"].TeamSTNs[2] = tbFA_Team3.Text;
                missionData.L16Files["A"].TeamSTNs[3] = tbFA_Team4.Text;
                missionData.L16Files["A"].DonorSTNs[0] = tbFA_Donor1.Text;
                missionData.L16Files["A"].DonorSTNs[1] = tbFA_Donor2.Text;
                missionData.L16Files["A"].DonorSTNs[2] = tbFA_Donor3.Text;
                missionData.L16Files["A"].DonorSTNs[3] = tbFA_Donor4.Text;
                missionData.L16Files["A"].DonorSTNs[4] = tbFA_Donor5.Text;
                missionData.L16Files["A"].DonorSTNs[5] = tbFA_Donor6.Text;
                missionData.L16Files["A"].DonorSTNs[6] = tbFA_Donor7.Text;
                missionData.L16Files["A"].DonorSTNs[7] = tbFA_Donor8.Text;

                missionData.L16Files["B"].VoiceAChannel = tbFB_VoiceAChnl.Text;
                missionData.L16Files["B"].VoiceBChannel = tbFB_VoiceBChnl.Text;
                missionData.L16Files["B"].MsnChannel = tbFB_MsnChnl.Text;
                missionData.L16Files["B"].FighterChannel = tbFB_FighterChnl.Text;
                missionData.L16Files["B"].SpecialChannel = tbFB_SpecChnl.Text;
                missionData.L16Files["B"].Callsign = tbFB_Callsign.Text;
                missionData.L16Files["B"].CallsignNumber = tbFB_CallsignNum.Text;
                missionData.L16Files["B"].FlightLead = cbFB_FlightLead.Checked;
                missionData.L16Files["B"].ETR = cbFB_ETR.Checked;
                missionData.L16Files["B"].TcnChannel = Convert.ToInt32(udFB_TcnChnl.Value);
                missionData.L16Files["B"].TcnBand = cbFB_TcnBand.Items[cbFB_TcnBand.SelectedIndex].ToString();
                missionData.L16Files["B"].FlightSTNs[0] = tbFB_Flight1.Text;
                missionData.L16Files["B"].FlightSTNs[1] = tbFB_Flight2.Text;
                missionData.L16Files["B"].FlightSTNs[2] = tbFB_Flight3.Text;
                missionData.L16Files["B"].FlightSTNs[3] = tbFB_Flight4.Text;
                missionData.L16Files["B"].TeamSTNs[0] = tbFB_Team1.Text;
                missionData.L16Files["B"].TeamSTNs[1] = tbFB_Team2.Text;
                missionData.L16Files["B"].TeamSTNs[2] = tbFB_Team3.Text;
                missionData.L16Files["B"].TeamSTNs[3] = tbFB_Team4.Text;
                missionData.L16Files["B"].DonorSTNs[0] = tbFB_Donor1.Text;
                missionData.L16Files["B"].DonorSTNs[1] = tbFB_Donor2.Text;
                missionData.L16Files["B"].DonorSTNs[2] = tbFB_Donor3.Text;
                missionData.L16Files["B"].DonorSTNs[3] = tbFB_Donor4.Text;
                missionData.L16Files["B"].DonorSTNs[4] = tbFB_Donor5.Text;
                missionData.L16Files["B"].DonorSTNs[5] = tbFB_Donor6.Text;
                missionData.L16Files["B"].DonorSTNs[6] = tbFB_Donor7.Text;
                missionData.L16Files["B"].DonorSTNs[7] = tbFB_Donor8.Text;

                missionData.SaveLink16DTC();

                DialogResult = DialogResult.OK;
                Close();
            }
            log.Debug("<< Link16 SaveToDTC");
        }

        private void Link16SettingsForm_Load(object sender, EventArgs e)
        {
            flightItems.Clear();
            foreach (Flight f in missionData.FlightList)
            {
                if (f.STN != null && f.STN != string.Empty)
                {
                    Package p = missionData.PackageList.FirstOrDefault(x => x.id == f.package);
                    if (p == null) {
                        continue;
                    }
                    L16Flight item = new L16Flight(
                        missionData.GetFlightCallsign(f), f.STN, missionData.GetFlightMission(f), f.PlanesNum,
                        p == null ? 0 : p.name_id);
                    flightItems.Add(item);
                }
            }

            tbSearchFlight.Text = missionData.CurrPackageNo.ToString();

            SearchFlights();

            //load flight STN from mission on load
            Populate();

            UpdateUI();
        }

        private void btnReloadDTC_Click(object sender, EventArgs e)
        {
            log.Debug(">> Link16 ReloadDTC");
            missionData.LoadPilotDTC();
            UpdateUI();
            log.Debug("<< Link16 ReloadDTC");
        }

        private bool ValidateControl(Control c, Regex re)
        {
            bool r = false;
            if (c is TextBox)
            {
                Match m = re.Match(c.Text);
                r = m.Success;

                if (r)
                {
                    c.BackColor = Color.White;
                    c.ForeColor = Color.Black;
                }
                else
                {
                    c.BackColor = Color.Red;
                    c.ForeColor = Color.White;
                }
            }
            return r;
        }

        private bool ValidateAll()
        {
            bool r = true;



            r = r && ValidateControl(tbFA_VoiceAChnl, re3Digits);
            r = r && ValidateControl(tbFA_VoiceBChnl, re3Digits);
            r = r && ValidateControl(tbFA_MsnChnl, re3Digits);
            r = r && ValidateControl(tbFA_FighterChnl, re3Digits);
            r = r && ValidateControl(tbFA_SpecChnl, re3Digits);
            r = r && ValidateControl(tbFA_Callsign, re2Letters);
            r = r && ValidateControl(tbFA_CallsignNum, re2Digits);
            r = r && ValidateControl(tbFA_Flight1, reSTN);
            r = r && ValidateControl(tbFA_Flight2, reSTN);
            r = r && ValidateControl(tbFA_Flight3, reSTN);
            r = r && ValidateControl(tbFA_Flight4, reSTN);
            r = r && ValidateControl(tbFA_Team1, reSTN);
            r = r && ValidateControl(tbFA_Team2, reSTN);
            r = r && ValidateControl(tbFA_Team3, reSTN);
            r = r && ValidateControl(tbFA_Team4, reSTN);
            r = r && ValidateControl(tbFA_Donor1, reSTN);
            r = r && ValidateControl(tbFA_Donor2, reSTN);
            r = r && ValidateControl(tbFA_Donor3, reSTN);
            r = r && ValidateControl(tbFA_Donor4, reSTN);
            r = r && ValidateControl(tbFA_Donor5, reSTN);
            r = r && ValidateControl(tbFA_Donor6, reSTN);
            r = r && ValidateControl(tbFA_Donor7, reSTN);
            r = r && ValidateControl(tbFA_Donor8, reSTN);

            return r;
        }

        private void tbFA_VoiceAChnl_TextChanged(object sender, EventArgs e)
        {

            ValidateControl(sender as Control, re3Digits);
        }

        private void tbFA_VoiceBChnl_TextChanged(object sender, EventArgs e)
        {
            ValidateControl(sender as Control, re3Digits);
        }

        private void tbFA_MsnChnl_TextChanged(object sender, EventArgs e)
        {
            ValidateControl(sender as Control, re3Digits);
        }

        private void tbFA_FighterChnl_TextChanged(object sender, EventArgs e)
        {
            ValidateControl(sender as Control, re3Digits);
        }

        private void tbFA_SpecChnl_TextChanged(object sender, EventArgs e)
        {
            ValidateControl(sender as Control, re3Digits);
        }

        private void tbFA_Callsign_TextChanged(object sender, EventArgs e)
        {
            ValidateControl(sender as Control, re2Letters);
        }

        private void tbFA_CallsignNum_TextChanged(object sender, EventArgs e)
        {
            ValidateControl(sender as Control, re2Digits);
        }

        private void tbSTN_TextChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Control lbl = control.Parent.GetNextControl(control, true);
            if (lbl != null)
            {
                if (ValidateControl(control, reSTN))
                {
                    if (control.Text == "00000")
                    {
                        lbl.Text = string.Empty;
                    }
                    else
                    {
                        Flight f = missionData.FlightList.FirstOrDefault(x => x.STN == control.Text.Substring(0, 4));
                        if (f != null)
                        {
                            lbl.Text = missionData.GetFlightCallsign(f) + "-" + control.Text.Substring(4, 1);
                            lbl.ForeColor = Color.Black;
                        }
                        else
                        {
                            lbl.Text = "STN not found!";
                            lbl.ForeColor = Color.Orange;
                        }
                    }
                }
            }

        }

        private void tbFB_VoiceAChnl_TextChanged(object sender, EventArgs e)
        {
            ValidateControl(sender as Control, re3Digits);
        }

        private void tbFB_VoiceBChnl_TextChanged(object sender, EventArgs e)
        {
            ValidateControl(sender as Control, re3Digits);
        }

        private void tbFB_MsnChnl_TextChanged(object sender, EventArgs e)
        {
            ValidateControl(sender as Control, re3Digits);
        }

        private void tbFB_FighterChnl_TextChanged(object sender, EventArgs e)
        {
            ValidateControl(sender as Control, re3Digits);
        }

        private void tbFB_SpecChnl_TextChanged(object sender, EventArgs e)
        {
            ValidateControl(sender as Control, re3Digits);
        }

        private void tbFB_Callsign_TextChanged(object sender, EventArgs e)
        {
            ValidateControl(sender as Control, re2Letters);
        }

        private void tbFB_CallsignNum_TextChanged(object sender, EventArgs e)
        {
            ValidateControl(sender as Control, re2Digits);
        }

        private void btnCopyA2B_Click(object sender, EventArgs e)
        {
            log.Debug(">> Link16 CopyAtoB");
            tbFB_VoiceAChnl.Text = tbFA_VoiceAChnl.Text;
            tbFB_VoiceBChnl.Text = tbFA_VoiceBChnl.Text;
            tbFB_MsnChnl.Text = tbFA_MsnChnl.Text;
            tbFB_FighterChnl.Text = tbFA_FighterChnl.Text;
            tbFB_SpecChnl.Text = tbFA_SpecChnl.Text;
            tbFB_Callsign.Text = tbFA_Callsign.Text;
            tbFB_CallsignNum.Text = tbFA_CallsignNum.Text;
            cbFB_FlightLead.Checked = cbFA_FlightLead.Checked;
            cbFB_ETR.Checked = cbFA_ETR.Checked;
            udFB_TcnChnl.Value = udFA_TcnChnl.Value;
            cbFB_TcnBand.SelectedIndex = cbFA_TcnBand.SelectedIndex;
            tbFB_Flight1.Text = tbFA_Flight1.Text;
            tbFB_Flight2.Text = tbFA_Flight2.Text;
            tbFB_Flight3.Text = tbFA_Flight3.Text;
            tbFB_Flight4.Text = tbFA_Flight4.Text;
            tbFB_Team1.Text = tbFA_Team1.Text;
            tbFB_Team2.Text = tbFA_Team2.Text;
            tbFB_Team3.Text = tbFA_Team3.Text;
            tbFB_Team4.Text = tbFA_Team4.Text;
            tbFB_Donor1.Text = tbFA_Donor1.Text;
            tbFB_Donor2.Text = tbFA_Donor2.Text;
            tbFB_Donor3.Text = tbFA_Donor3.Text;
            tbFB_Donor4.Text = tbFA_Donor4.Text;
            tbFB_Donor5.Text = tbFA_Donor5.Text;
            tbFB_Donor6.Text = tbFA_Donor6.Text;
            tbFB_Donor7.Text = tbFA_Donor7.Text;
            tbFB_Donor8.Text = tbFA_Donor8.Text;
            log.Debug("<< Link16 CopyAtoB");
        }

        private void tbSTN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            TextBox c = sender as TextBox;

            if (c.SelectionStart < c.Text.Length)
            {
                if (e.KeyData == Keys.D1 || e.KeyData == Keys.D2 || e.KeyData == Keys.D3 || e.KeyData == Keys.D4 || e.KeyData == Keys.D5 || e.KeyData == Keys.D6 || e.KeyData == Keys.D7 || e.KeyData == Keys.D8 || e.KeyData == Keys.D9 || e.KeyData == Keys.D0)
                {
                    int s = c.SelectionStart;
                    c.Text = c.Text.Substring(0, c.SelectionStart) + c.Text.Substring(c.SelectionStart + 1);
                    c.SelectionStart = s;
                }
            }
        }

        private void tbSTN_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox c = sender as TextBox;

            if (e.KeyData == Keys.Delete)
                c.Text = "00000";
        }

        private class FlightItem
        {

            public string STN;
            public string DisplayName;
            public string Callsign;

            public FlightItem(string callsign, string stn)
            {
                Callsign = callsign;
                STN = stn;
                DisplayName = "    " + callsign;
            }

            public override string ToString()
            {
                return DisplayName;
            }
        }
       
        private class L16Flight : FlightItem
        {
            public int Size;
            public string Mission;
            public List<FlightItem> Members;

            public L16Flight() : this("", "0000", "", 0, 0)
            { 
            
            }

            public L16Flight(string callsign, string stn, string msn, int size, int name_id) : base(callsign, stn)
            {
                Mission = msn;
                DisplayName = (name_id + " - ") + Callsign + " - " + Mission;
                Size = size;
                Members = new List<FlightItem>();

                for (int i = 0; i < Size; ++i)
                {
                    FlightItem member = new FlightItem(Callsign + "-" + (i + 1).ToString(), stn + (i + 1).ToString());
                    Members.Add(member);
                }
            }

            public void AddMembers(ListBox listToAdd) 
            {
                foreach (FlightItem member in Members) {
                    listToAdd.Items.Add(member);
                }
            }
        }

        private void SearchFlights()
        {
            lbFlights.Items.Clear();
            string s = tbSearchFlight.Text;

            foreach (L16Flight item in flightItems)
            {
                if (s == string.Empty || item.DisplayName.ToLower().Contains(s.ToLower()))
                {
                    lbFlights.Items.Add(item);
                    item.AddMembers(lbFlights);
                }
            }
        }

        private void Populate()
        {
            //Populate with our flight data

            Flight f = missionData.GetCurrentFlight();
            missionData.L16Files["A"].MsnChannel = f.MSN_ch.PadLeft(3, '0');
            missionData.L16Files["A"].FighterChannel = f.F2F_ch.PadLeft(3, '0');
            missionData.L16Files["A"].SpecialChannel = f.EW_ch.PadLeft(3, '0');
            if (f.STN != string.Empty)
            {
                for (int i = 0; i < f.PlanesNum; ++i)
                {
                    missionData.L16Files["A"].FlightSTNs[i] = f.STN + (i + 1).ToString();
                }
            }
            string cs = missionData.GetFlightCallsign(f);
            missionData.L16Files["A"].Callsign = cs[0] + cs.Substring(cs.Length - 2, 1);
            missionData.L16Files["A"].CallsignNumber = cs.Substring(cs.Length - 1) + "1";
            missionData.L16Files["A"].FlightLead = true;
        }

        private void tbSearchFlight_TextChanged(object sender, EventArgs e)
        {
            SearchFlights();
        }

        private void lbFlights_MouseDown(object sender, MouseEventArgs e)
        {

            int index = lbFlights.IndexFromPoint(e.X, e.Y);
            FlightItem item = lbFlights.Items[index] as FlightItem;
            lbFlights.DoDragDrop(item.STN, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void tbSTN_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tbSTN_DragDrop(object sender, DragEventArgs e)
        {
            TextBox control = sender as TextBox;
            string stn = e.Data.GetData(DataFormats.Text).ToString();
            if (reSTN.IsMatch(stn))
            {
                control.Text = stn;
            }
            if (reSTN4.IsMatch(stn))
            {
                int sz = flightItems.First(x => x.STN == stn).Size;
                control.Text = stn + "1";
                Control c = control;
                for (int k = 2; k < sz + 1; k++)
                {
                    Control c2 = control.Parent.GetNextControl(c, true);
                    if (c2 == null)
                        break;
                    Control c3 = control.Parent.GetNextControl(c2, true);
                    if (c3 == null)
                        break;
                    c3.Text = stn + k.ToString();
                    c = c3;
                }
            }
        }
    }
}
