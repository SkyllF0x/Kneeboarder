using BMSKneeboarder.Bms;
using log4net;
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
    public partial class BriefingSettingsForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger("default");
        private MissionData missionData;
        public BriefingSettingsForm(MissionData missionData)
        {
            this.missionData = missionData;

            InitializeComponent();
        }

        private void UpdateUI()
        {
            udBingo.Value = missionData.PilotBingo;
            udJoker.Value = missionData.PilotJoker;
            tbBriefing.Text = missionData.BriefingText;
        }

        private void BriefingSettingsForm_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            log.Debug(">> BriefingForm Save");
            missionData.PilotBingo = Convert.ToInt32(udBingo.Value);
            missionData.PilotJoker = Convert.ToInt32(udJoker.Value);
            missionData.BriefingText = tbBriefing.Text;

            BMSKneeboarderDB.Instance.SaveSettings("briefing", tbBriefing.Text);
            BMSKneeboarderDB.Instance.SaveSettings("bingo", udBingo.Value.ToString());
            BMSKneeboarderDB.Instance.SaveSettings("joker", udJoker.Value.ToString());

            DialogResult = DialogResult.OK;

            Close();
            log.Debug("<< BriefingForm Save");
        }

        private void udBingo_ValueChanged(object sender, EventArgs e)
        {
            udJoker.Minimum = udBingo.Value + 1000;
        }
    }
}
