using BMSKneeboarder.Bms;
using BMSKneeboarder.Bms.Model;
using BMSKneeboarder.Bms.UI;
using Microsoft.Toolkit.HighPerformance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMSKneeboarder
{
    public partial class MapSettingsForm : Form
    {
        public MapSettingsForm(MissionData missionData, MapSettings mapSettings)
        {
            this.missionData = missionData;
            this.mapSettings = mapSettings;
            InitializeComponent();
        }

        private MissionData missionData;
        private MapSettings mapSettings;

        private DashPatternListItem[] dashPatternListItems = new DashPatternListItem[] {
            new DashPatternListItem(null, "Solid"),
            new DashPatternListItem([4, 2], "Dashed"),
            new DashPatternListItem([1, 3], "Dotted")
        };

        private int GetPenPatternIndex(Pen pen)
        {
            int r = -1;



            for (int i = 0; i < dashPatternListItems.Length; i++)
            {
                DashPatternListItem item = dashPatternListItems[i];

                if (item.DashPattern == null && pen.DashStyle == System.Drawing.Drawing2D.DashStyle.Solid)
                {
                    r = i;
                    break;
                }
                if (item.DashPattern != null && pen.DashStyle == System.Drawing.Drawing2D.DashStyle.Custom && item.DashPattern.SequenceEqual(pen.DashPattern))
                {
                    r = i;
                    break;
                }
            }


            return r;
        }

        private void UpdateUI()
        {
            pbMap.Width = pbMap.Height * 1280 / 2024;
            pRight.Width = this.Width - pbMap.Width - 60;
            pRight.Height = pbMap.Height;
            pRight.Top = pbMap.Top;
            pRight.Left = this.Width - pRight.Width - 30;

            btnBgColor.BackColor = mapSettings.BackgroundColor;
            comboBox1.SelectedIndex = mapSettings.MapIndex;
            tbMapSaturation.Value = mapSettings.MapSaturation;
            tbMapBrightness.Value = mapSettings.MapBrightness;

            btnStptColor.BackColor = mapSettings.WptPen.Color;
            tbStptWidth.Value = Convert.ToInt32(mapSettings.WptPen.Width);
            lblStptWidth.Text = tbStptWidth.Value.ToString();
            btnWptLabelColor.BackColor = mapSettings.WptLabelColor;
            tbWptLabelSize.Value = mapSettings.WptLabelSize;
            lblWptLabelSize.Text = tbWptLabelSize.Value.ToString();
            cbShowWptNumbers.Checked = mapSettings.ShowWptLabels;

            cbShowBE.Checked = mapSettings.ShowBE;
            btnBEColor.BackColor = mapSettings.BEColor;
            tbBESize.Value = mapSettings.BESize;
            lblBESize.Text = mapSettings.BESize.ToString();
            cbShowBEGrid.Checked = mapSettings.ShowBEGrid;
            btnBEGridColor.BackColor = mapSettings.BEGridPen.Color;
            tbBEGridWidth.Value = Convert.ToInt32(mapSettings.BEGridPen.Width);
            lblBEGridWidth.Text = mapSettings.BEGridPen.Width.ToString();

            cbShowStptLines.Checked = mapSettings.ShowWptLines;
            btnStptLinesColor.BackColor = mapSettings.WptLinePen.Color;
            tbStptLinesWidth.Value = Convert.ToInt32(mapSettings.WptLinePen.Width);
            lblStptLinesWidth.Text = tbStptLinesWidth.Value.ToString();

            cbShowLine1.Checked = mapSettings.ShowSTPTLine1;
            cbShowLine2.Checked = mapSettings.ShowSTPTLine2;
            cbShowLine3.Checked = mapSettings.ShowSTPTLine3;
            cbShowLine4.Checked = mapSettings.ShowSTPTLine4;
            btnLine1Color.BackColor = mapSettings.STPTLine1Pen.Color;
            btnLine2Color.BackColor = mapSettings.STPTLine2Pen.Color;
            btnLine3Color.BackColor = mapSettings.STPTLine3Pen.Color;
            btnLine4Color.BackColor = mapSettings.STPTLine4Pen.Color;
            udLine1Width.Value = Convert.ToInt32(mapSettings.STPTLine1Pen.Width);
            udLine2Width.Value = Convert.ToInt32(mapSettings.STPTLine2Pen.Width);
            udLine3Width.Value = Convert.ToInt32(mapSettings.STPTLine3Pen.Width);
            udLine4Width.Value = Convert.ToInt32(mapSettings.STPTLine4Pen.Width);
            cbLine1Pattern.SelectedIndex = GetPenPatternIndex(mapSettings.STPTLine1Pen);
            cbLine2Pattern.SelectedIndex = GetPenPatternIndex(mapSettings.STPTLine2Pen);
            cbLine3Pattern.SelectedIndex = GetPenPatternIndex(mapSettings.STPTLine3Pen);
            cbLine4Pattern.SelectedIndex = GetPenPatternIndex(mapSettings.STPTLine4Pen);

            clbPpts.Items.Clear();
            foreach (DTC_PPT ppt in missionData.PilotPpts)
            {
                if (!ppt.IsZero)
                {
                    clbPpts.Items.Add(ppt);
                    if (mapSettings.ShowPptNums.Contains(ppt.PptNum))
                        clbPpts.SetItemChecked(clbPpts.Items.Count - 1, true);
                }
            }

            btnPptColor.BackColor = mapSettings.PPTPen.Color;
            btnPptFillColor.BackColor = ((SolidBrush)mapSettings.PPTBrush).Color;
            tbPptFillOpacity.Value = ((SolidBrush)mapSettings.PPTBrush).Color.A;
            cbShowPptNames.Checked = mapSettings.ShowPptNames;
            btnPptNameColor.BackColor = mapSettings.PPTNamesColor;
            tbPptNameSize.Value = mapSettings.PPTNamesSize;
            lblPptNameSize.Text = mapSettings.PPTNamesSize.ToString();
            cbShowPptNums.Checked = mapSettings.ShowPptNumbers;
            btnPptNumColor.BackColor = mapSettings.PPTNumbersColor;
            tbPptNumSize.Value = mapSettings.PPTNumbersSize;
            lblPptNumSize.Text = mapSettings.PPTNumbersSize.ToString();

            cbShowAirports.Checked = mapSettings.ShowAirports;
            cbShowAirstrips.Checked = mapSettings.ShowAirstrips;
            tbABIconSize.Value = mapSettings.AirportIconSize;

            btnPencilColor.BackColor = mapSettings.PencilPen.Color;
            tbPencilWidth.Value = Convert.ToInt32(mapSettings.PencilPen.Width);
            tbEraserSize.Value = mapSettings.EraserSize;
        }

        private void InitPatternsComboBox(System.Windows.Forms.ComboBox comboBox)
        {
            comboBox.Items.Clear();
            foreach (DashPatternListItem item in dashPatternListItems)
                comboBox.Items.Add(item);
        }

        private void MapSettingsForm_Load(object sender, EventArgs e)
        {
            InitPatternsComboBox(cbLine1Pattern);
            InitPatternsComboBox(cbLine2Pattern);
            InitPatternsComboBox(cbLine3Pattern);
            InitPatternsComboBox(cbLine4Pattern);
            InitPatternsComboBox(cbFlightPattern);

            if (mapSettings.OtherFlights.Count == 0)
            {
                Package p = missionData.PackageList.FirstOrDefault(x => x.id == missionData.CurrPackageId);
                foreach (Flight f in missionData.GetCurrPackageFlights())
                {
                    if (f.id != missionData.CurrFlightId)
                        mapSettings.OtherFlights.Add(new FlightMapSettings(f, missionData.GetFlightCallsign(f), missionData.GetFlightMission(f)));
                }

                if (p != null)
                {
                    Flight awacs = missionData.FlightList.FirstOrDefault(x => x.id == p.awacs);
                    if (awacs != null)
                        mapSettings.OtherFlights.Add(new FlightMapSettings(awacs, missionData.GetFlightCallsign(awacs), missionData.GetFlightMission(awacs)));
                    Flight tanker = missionData.FlightList.FirstOrDefault(x => x.id == p.tanker);
                    if (tanker != null)
                        mapSettings.OtherFlights.Add(new FlightMapSettings(tanker, missionData.GetFlightCallsign(tanker), missionData.GetFlightMission(tanker)));
                }
            }

            clbFlights.Items.Clear();
            foreach (FlightMapSettings f in mapSettings.OtherFlights)
            {
                clbFlights.Items.Add(f);
                if (f.ShowOnMap)
                    clbFlights.SetItemChecked(clbFlights.Items.Count - 1, true);
            }

            UpdateUI();

            RedrawMap(true);

            pbMap.MouseWheel += PbMap_MouseWheel;
        }

        private void PbMap_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (mapSettings.ScaleRatio + e.Delta * 0.000001 > 1e-4)
                mapSettings.ScaleRatio += e.Delta * 0.000001;
            RedrawMap(true);
        }

        private void MapSettingsForm_Resize(object sender, EventArgs e)
        {
            UpdateUI();
            RedrawMap(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void RedrawMap(bool updateMap)
        {
            skipMapRebuild = !updateMap;
            pbMap.Invalidate();
        }

        private bool skipMapRebuild = false;
        private void pbMap_Paint(object sender, PaintEventArgs e)
        {

            if (MapBitmap == null)
                MapBitmap = new Bitmap(1280, 2048);

            if (!skipMapRebuild)
            {
                using (Graphics g = Graphics.FromImage(MapBitmap))
                    BmsUtils.DrawMap(missionData, mapSettings, MapBitmap.Width, MapBitmap.Height, g, isPanning);
            }

            e.Graphics.DrawImage(MapBitmap, new Rectangle(0, 0, pbMap.Width, pbMap.Height), new Rectangle(0, 0, MapBitmap.Width, MapBitmap.Height), GraphicsUnit.Pixel);

            if (mapSettings.DrawingBitmap != null)
                e.Graphics.DrawImage(mapSettings.DrawingBitmap, new Rectangle(0, 0, pbMap.Width, pbMap.Height), new Rectangle(0, 0, mapSettings.DrawingBitmap.Width, mapSettings.DrawingBitmap.Height), GraphicsUnit.Pixel);

            //GC.Collect();
        }

        private void btnFit_Click(object sender, EventArgs e)
        {
            //Flight currentFlight = missionData.GetCurrentFlight();

            mapSettings.Fit(missionData, mapSettings, pbMap.Width, pbMap.Height);

            RedrawMap(true);
        }

        private bool isPanning = false;
        private bool isDrawing = false;
        private Bitmap DrawingBitmapOrig = null;
        private void pbMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (activeDrawTool == "pencil" || activeDrawTool == "eraser")
            {
                isDrawing = true;
                pbMap.Cursor = Cursors.Cross;
            }
            else if (activeDrawTool == "text")
            {
                isDrawing = true;
                pbMap.Cursor = Cursors.Cross;
            }
            else
            {
                isPanning = true;
                pbMap.Cursor = Cursors.SizeAll;
            }
        }

        private void pbMap_MouseLeave(object sender, EventArgs e)
        {
            isDrawing = false;

            pbMap.Cursor = Cursors.Default;
            if (isPanning)
            {
                isPanning = false;
                RedrawMap(true);
            }
            else
                RedrawMap(false);
        }

        private void pbMap_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;

            pbMap.Cursor = Cursors.Default;
            if (isPanning)
            {
                isPanning = false;
                RedrawMap(true);
            }
            else
                RedrawMap(false);
        }

        private Point pbMapMousePos;
        private Bitmap MapBitmap { get; set; } = null;
        private void pbMap_MouseMove(object sender, MouseEventArgs e)
        {

            if (isPanning)
            {

                mapSettings.Center = new PointF(
                    mapSettings.Center.X + (-e.Location.X + pbMapMousePos.X) / (float)mapSettings.GetScale(pbMap.Width),
                    mapSettings.Center.Y + (e.Location.Y - pbMapMousePos.Y) / (float)mapSettings.GetScale(pbMap.Width)
                );
                RedrawMap(true);
            }
            if (isDrawing)
            {
                if (mapSettings.DrawingBitmap == null)
                    mapSettings.DrawingBitmap = new Bitmap(1280, 2048);

                using (Graphics g = Graphics.FromImage(mapSettings.DrawingBitmap))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    if (activeDrawTool == "pencil")
                    {
                        int x1 = pbMapMousePos.X * 1280 / pbMap.Width;
                        int y1 = pbMapMousePos.Y * 2048 / pbMap.Height;
                        int x2 = e.Location.X * 1280 / pbMap.Width;
                        int y2 = e.Location.Y * 2048 / pbMap.Height;

                        g.DrawLine(mapSettings.PencilPen, x1, y1, x2, y2);
                    }

                    if (activeDrawTool == "eraser")
                    {
                        int x1 = pbMapMousePos.X * 1280 / pbMap.Width;
                        int y1 = pbMapMousePos.Y * 2048 / pbMap.Height;
                        int x2 = e.Location.X * 1280 / pbMap.Width;
                        int y2 = e.Location.Y * 2048 / pbMap.Height;

                        g.CompositingMode = CompositingMode.SourceCopy;
                        using (GraphicsPath path = new GraphicsPath())
                        {
                            for (float d = 0f; d <= 1f; d += 0.1f)
                            {
                                int x = Convert.ToInt32(x1 + (float)(x2 - x1) * d);
                                int y = Convert.ToInt32(y1 + (float)(y2 - y1) * d);
                                path.Reset();
                                path.AddEllipse(x - mapSettings.EraserSize / 2, y - mapSettings.EraserSize / 2, mapSettings.EraserSize, mapSettings.EraserSize);
                                g.FillPath(Brushes.Transparent, path);
                            }
                        }
                        g.CompositingMode = CompositingMode.SourceOver;

                    }
                }

                RedrawMap(false);
            }
            pbMapMousePos = e.Location;
        }

        private void btnBgColor_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.BackgroundColor = dlgColor.Color;
                UpdateUI();
                RedrawMap(true);
            }
        }

        private void tbMapSaturation_ValueChanged(object sender, EventArgs e)
        {
            mapSettings.MapSaturation = tbMapSaturation.Value;
            RedrawMap(true);
        }

        private void btnStptColor_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.WptPen.Color = dlgColor.Color;
                mapSettings.WptLabelColor = dlgColor.Color;
                mapSettings.WptLinePen.Color = dlgColor.Color;

                UpdateUI();
                RedrawMap(true);
            }
        }

        private void btnWptLabelColor_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.WptLabelColor = dlgColor.Color;
                UpdateUI();
                RedrawMap(true);
            }
        }

        private void cbShowWptNumbers_CheckedChanged(object sender, EventArgs e)
        {
            mapSettings.ShowWptLabels = cbShowWptNumbers.Checked;
            RedrawMap(true);
        }

        private void cbShowBE_CheckedChanged(object sender, EventArgs e)
        {
            mapSettings.ShowBE = cbShowBE.Checked;
            RedrawMap(true);
        }

        private void btnBEColor_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.BEColor = dlgColor.Color;
                UpdateUI();
                RedrawMap(true);
            }
        }

        private void cbShowStptLines_CheckedChanged(object sender, EventArgs e)
        {
            mapSettings.ShowWptLines = cbShowStptLines.Checked;
            RedrawMap(true);
        }

        private void btnStptLinesColor_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.WptLinePen.Color = dlgColor.Color;
                UpdateUI();
                RedrawMap(true);
            }
        }

        private void cbShowLine1_CheckedChanged(object sender, EventArgs e)
        {
            mapSettings.ShowSTPTLine1 = cbShowLine1.Checked;
            RedrawMap(true);
        }

        private void cbShowLine2_CheckedChanged(object sender, EventArgs e)
        {
            mapSettings.ShowSTPTLine2 = cbShowLine2.Checked;
            RedrawMap(true);
        }

        private void cbShowLine3_CheckedChanged(object sender, EventArgs e)
        {
            mapSettings.ShowSTPTLine3 = cbShowLine3.Checked;
            RedrawMap(true);
        }

        private void cbShowLine4_CheckedChanged(object sender, EventArgs e)
        {
            mapSettings.ShowSTPTLine4 = cbShowLine4.Checked;
            RedrawMap(true);
        }

        private void btnLine1Color_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.STPTLine1Pen.Color = dlgColor.Color;
                UpdateUI();
                RedrawMap(true);
            }
        }

        private void btnLine2Color_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.STPTLine2Pen.Color = dlgColor.Color;
                UpdateUI();
                RedrawMap(true);
            }
        }

        private void btnLine3Color_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.STPTLine3Pen.Color = dlgColor.Color;
                UpdateUI();
                RedrawMap(true);
            }
        }

        private void btnLine4Color_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.STPTLine4Pen.Color = dlgColor.Color;
                UpdateUI();
                RedrawMap(true);
            }
        }

        private void udLine1Width_ValueChanged(object sender, EventArgs e)
        {
            mapSettings.STPTLine1Pen.Width = Convert.ToSingle(udLine1Width.Value);
            RedrawMap(true);
        }

        private void udLine2Width_ValueChanged(object sender, EventArgs e)
        {
            mapSettings.STPTLine2Pen.Width = Convert.ToSingle(udLine2Width.Value);
            RedrawMap(true);
        }

        private void udLine3Width_ValueChanged(object sender, EventArgs e)
        {
            mapSettings.STPTLine3Pen.Width = Convert.ToSingle(udLine3Width.Value);
            RedrawMap(true);
        }

        private void udLine4Width_ValueChanged(object sender, EventArgs e)
        {
            mapSettings.STPTLine4Pen.Width = Convert.ToSingle(udLine4Width.Value);
            RedrawMap(true);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mapSettings.MapIndex = comboBox1.SelectedIndex;
            RedrawMap(true);
        }

        private void cbShowBEGrid_CheckedChanged(object sender, EventArgs e)
        {
            mapSettings.ShowBEGrid = cbShowBEGrid.Checked;
            RedrawMap(true);
        }

        private void btnBEGridColor_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.BEGridPen.Color = dlgColor.Color;
                UpdateUI();
                RedrawMap(true);
            }
        }

        private void btnPptColor_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.PPTPen.Color = dlgColor.Color;
                UpdateUI();
                RedrawMap(true);
            }
        }

        private void btnPptFillColor_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                ((SolidBrush)mapSettings.PPTBrush).Color = Color.FromArgb(tbPptFillOpacity.Value, dlgColor.Color);
                UpdateUI();
                RedrawMap(true);
            }
        }

        private void tbPptFillOpacity_ValueChanged(object sender, EventArgs e)
        {
            ((SolidBrush)mapSettings.PPTBrush).Color = Color.FromArgb(tbPptFillOpacity.Value, ((SolidBrush)mapSettings.PPTBrush).Color);
            RedrawMap(true);
        }

        private void cbShowPptNames_CheckedChanged(object sender, EventArgs e)
        {
            mapSettings.ShowPptNames = cbShowPptNames.Checked;
            RedrawMap(true);
        }

        private void btnPptNameColor_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.PPTNamesColor = dlgColor.Color;
                UpdateUI();
                RedrawMap(true);
            }
        }

        private void clbPpts_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            DTC_PPT ppt = (DTC_PPT)clbPpts.Items[e.Index];
            if (e.NewValue == CheckState.Checked)
            {
                if (!mapSettings.ShowPptNums.Contains(ppt.PptNum))
                    mapSettings.ShowPptNums.Add(ppt.PptNum);
            }
            else
            {
                mapSettings.ShowPptNums.Remove(ppt.PptNum);
            }
            RedrawMap(true);
        }

        private void cbShowPptNums_CheckedChanged(object sender, EventArgs e)
        {
            mapSettings.ShowPptNumbers = cbShowPptNums.Checked;
            RedrawMap(true);
        }

        private void btnPptNumColor_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.PPTNumbersColor = dlgColor.Color;
                UpdateUI();
                RedrawMap(true);
            }
        }

        private void cbLine1Pattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            DashPatternListItem item = (DashPatternListItem)cbLine1Pattern.SelectedItem;
            if (item.DashPattern == null)
                mapSettings.STPTLine1Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            else
                mapSettings.STPTLine1Pen.DashPattern = item.DashPattern;
            RedrawMap(true);
        }

        private void clbFlights_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            FlightMapSettings item = (FlightMapSettings)clbFlights.Items[e.Index];
            item.ShowOnMap = e.NewValue == CheckState.Checked;
            RedrawMap(true);
        }

        private void clbFlights_SelectedIndexChanged(object sender, EventArgs e)
        {
            pFlightSettings.Visible = (clbFlights.SelectedIndex != -1);
            if (pFlightSettings.Visible)
            {
                btnFlightColor.BackColor = mapSettings.OtherFlights[clbFlights.SelectedIndex].FlightPlanPen.Color;
                udFlightWidth.Value = Convert.ToInt32(mapSettings.OtherFlights[clbFlights.SelectedIndex].FlightPlanPen.Width);
                cbFlightPattern.SelectedIndex = GetPenPatternIndex(mapSettings.OtherFlights[clbFlights.SelectedIndex].FlightPlanPen);
            }
        }

        private void btnFlightColor_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.OtherFlights[clbFlights.SelectedIndex].FlightPlanPen.Color = dlgColor.Color;
                btn.BackColor = dlgColor.Color;
                RedrawMap(true);
            }
        }

        private void udFlightWidth_ValueChanged(object sender, EventArgs e)
        {
            mapSettings.OtherFlights[clbFlights.SelectedIndex].FlightPlanPen.Width = Convert.ToSingle(udFlightWidth.Value);
            RedrawMap(true);
        }

        private void cbFlightPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            DashPatternListItem item = (DashPatternListItem)cbFlightPattern.SelectedItem;
            if (item.DashPattern == null)
                mapSettings.OtherFlights[clbFlights.SelectedIndex].FlightPlanPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            else
                mapSettings.OtherFlights[clbFlights.SelectedIndex].FlightPlanPen.DashPattern = item.DashPattern;
            RedrawMap(true);
        }

        private void btnAddOtherFlight_Click(object sender, EventArgs e)
        {
            using (SelectMultipleFlights frm = new SelectMultipleFlights(missionData))
            {
                frm.SelectedFlights = mapSettings.OtherFlights.Select(fms => fms.Flight).ToArray();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    for (int i = mapSettings.OtherFlights.Count - 1; i >= 0; i--)
                    {
                        if (!frm.SelectedFlights.Any(x => x.id == mapSettings.OtherFlights[i].Flight.id))
                        {
                            mapSettings.OtherFlights.RemoveAt(i);
                            clbFlights.Items.RemoveAt(i);
                        }
                    }

                    foreach (Flight f in frm.SelectedFlights)
                    {
                        if (!mapSettings.OtherFlights.Any(x => x.Flight.id == f.id))
                        {
                            Package p = missionData.PackageList.FirstOrDefault(x => x.id == f.package);
                            FlightMapSettings fms = new FlightMapSettings(f, p.name_id + " - " + missionData.GetFlightCallsign(f), missionData.GetFlightMission(f));
                            fms.ShowOnMap = true;
                            mapSettings.OtherFlights.Add(fms);
                            clbFlights.Items.Add(fms);
                            clbFlights.SetItemChecked(clbFlights.Items.Count - 1, true);
                        }
                    }

                    RedrawMap(true);
                }
            }
        }

        private void cbShowAirports_CheckedChanged(object sender, EventArgs e)
        {
            mapSettings.ShowAirports = cbShowAirports.Checked;
            RedrawMap(true);
        }

        private void cbShowAirstrips_CheckStateChanged(object sender, EventArgs e)
        {
            mapSettings.ShowAirstrips = cbShowAirstrips.Checked;
            RedrawMap(true);
        }

        private void cbLine2Pattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            DashPatternListItem item = (DashPatternListItem)cbLine2Pattern.SelectedItem;
            if (item.DashPattern == null)
                mapSettings.STPTLine2Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            else
                mapSettings.STPTLine2Pen.DashPattern = item.DashPattern;
            RedrawMap(true);
        }

        private void cbLine3Pattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            DashPatternListItem item = (DashPatternListItem)cbLine3Pattern.SelectedItem;
            if (item.DashPattern == null)
                mapSettings.STPTLine3Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            else
                mapSettings.STPTLine3Pen.DashPattern = item.DashPattern;
            RedrawMap(true);
        }

        private void cbLine4Pattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            DashPatternListItem item = (DashPatternListItem)cbLine4Pattern.SelectedItem;
            if (item.DashPattern == null)
                mapSettings.STPTLine4Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            else
                mapSettings.STPTLine4Pen.DashPattern = item.DashPattern;
            RedrawMap(true);
        }

        private void tbMapBrightness_ValueChanged(object sender, EventArgs e)
        {
            mapSettings.MapBrightness = tbMapBrightness.Value;
            RedrawMap(true);
        }

        private void tbABIconSize_ValueChanged(object sender, EventArgs e)
        {
            mapSettings.AirportIconSize = tbABIconSize.Value;
            RedrawMap(true);
        }

        private string activeDrawTool = "";

        private void btnPencil_CheckedChanged(object sender, EventArgs e)
        {
            if (btnPencil.Checked)
            {
                btnDrawText.Enabled = false;
                btnEraser.Checked = false;
                activeDrawTool = "pencil";
            }
            else
                activeDrawTool = "";

            pPencilParams.Visible = (activeDrawTool == "pencil");
        }

        private void MapSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MapBitmap != null)
                MapBitmap.Dispose();
        }

        private void btnDrawClear_Click(object sender, EventArgs e)
        {
            if (mapSettings.DrawingBitmap != null)
            {
                mapSettings.DrawingBitmap.Dispose();
                mapSettings.DrawingBitmap = null;
            }
            //using (Graphics g = Graphics.FromImage(mapSettings.DrawingBitmap))
            //  g.Clear(Color.Transparent);
            RedrawMap(false);
        }

        private void btnPencilColor_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            dlgColor.Color = btn.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                mapSettings.PencilPen.Color = dlgColor.Color;
                btn.BackColor = dlgColor.Color;

            }
        }

        private void tbPencilWidth_ValueChanged(object sender, EventArgs e)
        {
            mapSettings.PencilPen.Width = tbPencilWidth.Value;
            lblPencilWidth.Text = tbPencilWidth.Value.ToString();
        }

        private void btnEraser_CheckedChanged(object sender, EventArgs e)
        {
            if (btnEraser.Checked)
            {
                btnPencil.Checked = false;
                btnDrawText.Enabled = false;
                activeDrawTool = "eraser";
            }
            else
            {
                activeDrawTool = "";
            }

            pEraserParams.Visible = (activeDrawTool == "eraser");
        }

        private void tbEraserSize_ValueChanged(object sender, EventArgs e)
        {
            mapSettings.EraserSize = tbEraserSize.Value;
            lblEraserWidth.Text = tbEraserSize.Value.ToString();
        }

        private void tbStptWidth_ValueChanged(object sender, EventArgs e)
        {
            lblStptWidth.Text = tbStptWidth.Value.ToString();
            mapSettings.WptPen.Width = Convert.ToSingle(tbStptWidth.Value);
            RedrawMap(true);
        }

        private void tbStptLinesWidth_ValueChanged(object sender, EventArgs e)
        {
            lblStptLinesWidth.Text = tbStptLinesWidth.Value.ToString();
            mapSettings.WptLinePen.Width = Convert.ToSingle(tbStptLinesWidth.Value);
            RedrawMap(true);
        }

        private void tbWptLabelSize_ValueChanged(object sender, EventArgs e)
        {
            lblWptLabelSize.Text = tbWptLabelSize.Value.ToString();
            mapSettings.WptLabelSize = tbWptLabelSize.Value;
            RedrawMap(true);
        }

        private void tbBESize_ValueChanged(object sender, EventArgs e)
        {
            lblBESize.Text = tbBESize.Value.ToString();
            mapSettings.BESize = tbBESize.Value;
            RedrawMap(true);
        }

        private void tbBEGridWidth_ValueChanged(object sender, EventArgs e)
        {
            lblBEGridWidth.Text = tbBEGridWidth.Value.ToString();
            mapSettings.BEGridPen.Width = tbBEGridWidth.Value;
            RedrawMap(true);
        }

        private void tbPptNameSize_ValueChanged(object sender, EventArgs e)
        {
            mapSettings.PPTNamesSize = tbPptNameSize.Value;
            lblPptNameSize.Text = tbPptNameSize.Value.ToString();
            RedrawMap(true);
        }

        private void tbPptNumSize_ValueChanged(object sender, EventArgs e)
        {
            mapSettings.PPTNumbersSize = tbPptNumSize.Value;
            lblPptNumSize.Text = tbPptNumSize.Value.ToString();
            RedrawMap(true);
        }

        private void btnDrawText_CheckedChanged(object sender, EventArgs e)
        {
            if (btnDrawText.Checked)
            {

                btnEraser.Checked = false;
                btnPencil.Checked = false;
                activeDrawTool = "text";
            }
            else
                activeDrawTool = "";

            pDrawTextParams.Visible = (activeDrawTool == "text");
        }
    }
}
