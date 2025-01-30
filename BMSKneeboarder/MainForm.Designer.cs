namespace BMSKneeboarder
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mnuTop = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuFileOpen = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            dlgOpen = new OpenFileDialog();
            toolStripContainer = new ToolStripContainer();
            splitContainer1 = new SplitContainer();
            panelLeft = new Panel();
            trbLeftSat = new TrackBar();
            btnLeftClipboard = new Button();
            btnLeftFile = new Button();
            cbLeftType = new ComboBox();
            tabControlLeft = new TabControl();
            tabLeft1 = new TabPage();
            tabLeft2 = new TabPage();
            tabLeft3 = new TabPage();
            tabLeft4 = new TabPage();
            tabLeft5 = new TabPage();
            tabLeft6 = new TabPage();
            tabLeft7 = new TabPage();
            tabLeft8 = new TabPage();
            tabLeft9 = new TabPage();
            tabLeft10 = new TabPage();
            tabLeft11 = new TabPage();
            tabLeft12 = new TabPage();
            tabLeft13 = new TabPage();
            tabLeft14 = new TabPage();
            tabLeft15 = new TabPage();
            tabLeft16 = new TabPage();
            panelRight = new Panel();
            trbRightSat = new TrackBar();
            btnRightClipboard = new Button();
            btnRightFile = new Button();
            cbRightType = new ComboBox();
            tabControlRight = new TabControl();
            tabRight1 = new TabPage();
            tabRight2 = new TabPage();
            tabRight3 = new TabPage();
            tabRight4 = new TabPage();
            tabRight5 = new TabPage();
            tabRight6 = new TabPage();
            tabRight7 = new TabPage();
            tabRight8 = new TabPage();
            tabRight9 = new TabPage();
            tabRight10 = new TabPage();
            tabRight11 = new TabPage();
            tabRight12 = new TabPage();
            tabRight13 = new TabPage();
            tabRight14 = new TabPage();
            tabRight15 = new TabPage();
            tabRight16 = new TabPage();
            toolStrip1 = new ToolStrip();
            btnOpenMission = new ToolStripButton();
            cbTheater = new ToolStripComboBox();
            toolStripButton1 = new ToolStripButton();
            btnReloadMission = new ToolStripButton();
            btnDTCDropdown = new ToolStripDropDownButton();
            muLoadMissionDTC = new ToolStripMenuItem();
            mnuLoadPilotDTC = new ToolStripMenuItem();
            btnLink16 = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnSaveKB = new ToolStripButton();
            progressBar = new ToolStripProgressBar();
            imageList1 = new ImageList(components);
            dlgPasteFile = new OpenFileDialog();
            ctxMnuDatacard = new ContextMenuStrip(components);
            mnuItemSelectFlights = new ToolStripMenuItem();
            mnuItemSelectSupportFlights = new ToolStripMenuItem();
            ctxMnuMap = new ContextMenuStrip(components);
            mnuItemMapSettings = new ToolStripMenuItem();
            mnuCopyMapSettings = new ToolStripMenuItem();
            mnuPasteMap = new ToolStripMenuItem();
            mnuPasteMapSettings = new ToolStripMenuItem();
            ctxMnuBriefing = new ContextMenuStrip(components);
            editBriefingToolStripMenuItem = new ToolStripMenuItem();
            mnuTop.SuspendLayout();
            toolStripContainer.ContentPanel.SuspendLayout();
            toolStripContainer.TopToolStripPanel.SuspendLayout();
            toolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLeftSat).BeginInit();
            tabControlLeft.SuspendLayout();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbRightSat).BeginInit();
            tabControlRight.SuspendLayout();
            toolStrip1.SuspendLayout();
            ctxMnuDatacard.SuspendLayout();
            ctxMnuMap.SuspendLayout();
            ctxMnuBriefing.SuspendLayout();
            SuspendLayout();
            // 
            // mnuTop
            // 
            mnuTop.Items.AddRange(new ToolStripItem[] { mnuFile, settingsToolStripMenuItem });
            mnuTop.Location = new Point(0, 0);
            mnuTop.Name = "mnuTop";
            mnuTop.Size = new Size(1520, 24);
            mnuTop.TabIndex = 0;
            mnuTop.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileOpen });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(37, 20);
            mnuFile.Text = "File";
            // 
            // mnuFileOpen
            // 
            mnuFileOpen.Name = "mnuFileOpen";
            mnuFileOpen.Size = new Size(147, 22);
            mnuFileOpen.Text = "Open Mission";
            mnuFileOpen.Click += mnuFileOpen_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // dlgOpen
            // 
            dlgOpen.Filter = "Mission Files (*.cam, *.tac)|*.cam;*.tac";
            dlgOpen.Title = "Open Mission";
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            toolStripContainer.ContentPanel.Controls.Add(splitContainer1);
            toolStripContainer.ContentPanel.Size = new Size(1520, 856);
            toolStripContainer.Dock = DockStyle.Fill;
            toolStripContainer.Location = new Point(0, 24);
            toolStripContainer.Name = "toolStripContainer";
            toolStripContainer.Size = new Size(1520, 881);
            toolStripContainer.TabIndex = 1;
            toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            toolStripContainer.TopToolStripPanel.Controls.Add(toolStrip1);
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelLeft);
            splitContainer1.Panel1.Controls.Add(tabControlLeft);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelRight);
            splitContainer1.Panel2.Controls.Add(tabControlRight);
            splitContainer1.Size = new Size(1520, 856);
            splitContainer1.SplitterDistance = 707;
            splitContainer1.TabIndex = 0;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(trbLeftSat);
            panelLeft.Controls.Add(btnLeftClipboard);
            panelLeft.Controls.Add(btnLeftFile);
            panelLeft.Controls.Add(cbLeftType);
            panelLeft.Dock = DockStyle.Top;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(707, 31);
            panelLeft.TabIndex = 1;
            // 
            // trbLeftSat
            // 
            trbLeftSat.Location = new Point(292, 4);
            trbLeftSat.Maximum = 100;
            trbLeftSat.Name = "trbLeftSat";
            trbLeftSat.Size = new Size(161, 45);
            trbLeftSat.TabIndex = 3;
            trbLeftSat.TickStyle = TickStyle.None;
            trbLeftSat.Value = 100;
            trbLeftSat.ValueChanged += trbLeftSat_ValueChanged;
            // 
            // btnLeftClipboard
            // 
            btnLeftClipboard.Location = new Point(211, 4);
            btnLeftClipboard.Name = "btnLeftClipboard";
            btnLeftClipboard.Size = new Size(75, 23);
            btnLeftClipboard.TabIndex = 2;
            btnLeftClipboard.Text = "Clipboard";
            btnLeftClipboard.UseVisualStyleBackColor = true;
            btnLeftClipboard.Click += btnLeftClipboard_Click;
            // 
            // btnLeftFile
            // 
            btnLeftFile.Location = new Point(130, 4);
            btnLeftFile.Name = "btnLeftFile";
            btnLeftFile.Size = new Size(75, 23);
            btnLeftFile.TabIndex = 1;
            btnLeftFile.Text = "File";
            btnLeftFile.UseVisualStyleBackColor = true;
            btnLeftFile.Click += btnLeftFile_Click;
            // 
            // cbLeftType
            // 
            cbLeftType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLeftType.FormattingEnabled = true;
            cbLeftType.Items.AddRange(new object[] { "Datacard", "Custom", "Blank" });
            cbLeftType.Location = new Point(3, 4);
            cbLeftType.Name = "cbLeftType";
            cbLeftType.Size = new Size(121, 23);
            cbLeftType.TabIndex = 0;
            cbLeftType.SelectedIndexChanged += cbLeftType_SelectedIndexChanged;
            // 
            // tabControlLeft
            // 
            tabControlLeft.Alignment = TabAlignment.Left;
            tabControlLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlLeft.Controls.Add(tabLeft1);
            tabControlLeft.Controls.Add(tabLeft2);
            tabControlLeft.Controls.Add(tabLeft3);
            tabControlLeft.Controls.Add(tabLeft4);
            tabControlLeft.Controls.Add(tabLeft5);
            tabControlLeft.Controls.Add(tabLeft6);
            tabControlLeft.Controls.Add(tabLeft7);
            tabControlLeft.Controls.Add(tabLeft8);
            tabControlLeft.Controls.Add(tabLeft9);
            tabControlLeft.Controls.Add(tabLeft10);
            tabControlLeft.Controls.Add(tabLeft11);
            tabControlLeft.Controls.Add(tabLeft12);
            tabControlLeft.Controls.Add(tabLeft13);
            tabControlLeft.Controls.Add(tabLeft14);
            tabControlLeft.Controls.Add(tabLeft15);
            tabControlLeft.Controls.Add(tabLeft16);
            tabControlLeft.Location = new Point(0, 37);
            tabControlLeft.Multiline = true;
            tabControlLeft.Name = "tabControlLeft";
            tabControlLeft.SelectedIndex = 0;
            tabControlLeft.Size = new Size(707, 819);
            tabControlLeft.TabIndex = 1;
            tabControlLeft.SelectedIndexChanged += tabControlLeft_SelectedIndexChanged;
            tabControlLeft.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft1
            // 
            tabLeft1.BackColor = Color.LightGray;
            tabLeft1.Location = new Point(27, 4);
            tabLeft1.Name = "tabLeft1";
            tabLeft1.Padding = new Padding(3);
            tabLeft1.Size = new Size(676, 811);
            tabLeft1.TabIndex = 0;
            tabLeft1.Text = "1";
            tabLeft1.Paint += tabLeft1_Paint;
            tabLeft1.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft2
            // 
            tabLeft2.BackColor = Color.LightGray;
            tabLeft2.Location = new Point(27, 4);
            tabLeft2.Name = "tabLeft2";
            tabLeft2.Padding = new Padding(3);
            tabLeft2.Size = new Size(676, 811);
            tabLeft2.TabIndex = 1;
            tabLeft2.Text = "2";
            tabLeft2.Paint += tabLeft2_Paint;
            tabLeft2.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft3
            // 
            tabLeft3.BackColor = Color.LightGray;
            tabLeft3.Location = new Point(27, 4);
            tabLeft3.Name = "tabLeft3";
            tabLeft3.Size = new Size(676, 811);
            tabLeft3.TabIndex = 2;
            tabLeft3.Text = "3";
            tabLeft3.Paint += tabLeft3_Paint;
            tabLeft3.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft4
            // 
            tabLeft4.BackColor = Color.LightGray;
            tabLeft4.Location = new Point(27, 4);
            tabLeft4.Name = "tabLeft4";
            tabLeft4.Size = new Size(676, 811);
            tabLeft4.TabIndex = 3;
            tabLeft4.Text = "4";
            tabLeft4.Paint += tabLeft4_Paint;
            tabLeft4.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft5
            // 
            tabLeft5.BackColor = Color.LightGray;
            tabLeft5.Location = new Point(27, 4);
            tabLeft5.Name = "tabLeft5";
            tabLeft5.Size = new Size(676, 811);
            tabLeft5.TabIndex = 4;
            tabLeft5.Text = "5";
            tabLeft5.Paint += tabLeft5_Paint;
            tabLeft5.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft6
            // 
            tabLeft6.BackColor = Color.LightGray;
            tabLeft6.Location = new Point(27, 4);
            tabLeft6.Name = "tabLeft6";
            tabLeft6.Size = new Size(676, 811);
            tabLeft6.TabIndex = 5;
            tabLeft6.Text = "6";
            tabLeft6.Paint += tabLeft6_Paint;
            tabLeft6.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft7
            // 
            tabLeft7.BackColor = Color.LightGray;
            tabLeft7.Location = new Point(27, 4);
            tabLeft7.Name = "tabLeft7";
            tabLeft7.Size = new Size(676, 811);
            tabLeft7.TabIndex = 6;
            tabLeft7.Text = "7";
            tabLeft7.Paint += tabLeft7_Paint;
            tabLeft7.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft8
            // 
            tabLeft8.BackColor = Color.LightGray;
            tabLeft8.Location = new Point(27, 4);
            tabLeft8.Name = "tabLeft8";
            tabLeft8.Size = new Size(676, 811);
            tabLeft8.TabIndex = 7;
            tabLeft8.Text = "8";
            tabLeft8.Paint += tabLeft8_Paint;
            tabLeft8.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft9
            // 
            tabLeft9.BackColor = Color.LightGray;
            tabLeft9.Location = new Point(27, 4);
            tabLeft9.Name = "tabLeft9";
            tabLeft9.Size = new Size(676, 811);
            tabLeft9.TabIndex = 8;
            tabLeft9.Text = "9";
            tabLeft9.Paint += tabLeft9_Paint;
            tabLeft9.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft10
            // 
            tabLeft10.BackColor = Color.LightGray;
            tabLeft10.Location = new Point(27, 4);
            tabLeft10.Name = "tabLeft10";
            tabLeft10.Size = new Size(676, 811);
            tabLeft10.TabIndex = 9;
            tabLeft10.Text = "10";
            tabLeft10.Paint += tabLeft10_Paint;
            tabLeft10.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft11
            // 
            tabLeft11.BackColor = Color.LightGray;
            tabLeft11.Location = new Point(27, 4);
            tabLeft11.Name = "tabLeft11";
            tabLeft11.Size = new Size(676, 811);
            tabLeft11.TabIndex = 10;
            tabLeft11.Text = "11";
            tabLeft11.Paint += tabLeft11_Paint;
            tabLeft11.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft12
            // 
            tabLeft12.BackColor = Color.LightGray;
            tabLeft12.Location = new Point(27, 4);
            tabLeft12.Name = "tabLeft12";
            tabLeft12.Size = new Size(676, 811);
            tabLeft12.TabIndex = 11;
            tabLeft12.Text = "12";
            tabLeft12.Paint += tabLeft12_Paint;
            tabLeft12.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft13
            // 
            tabLeft13.BackColor = Color.LightGray;
            tabLeft13.Location = new Point(27, 4);
            tabLeft13.Name = "tabLeft13";
            tabLeft13.Size = new Size(676, 811);
            tabLeft13.TabIndex = 12;
            tabLeft13.Text = "13";
            tabLeft13.Paint += tabLeft13_Paint;
            tabLeft13.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft14
            // 
            tabLeft14.BackColor = Color.LightGray;
            tabLeft14.Location = new Point(27, 4);
            tabLeft14.Name = "tabLeft14";
            tabLeft14.Size = new Size(676, 811);
            tabLeft14.TabIndex = 13;
            tabLeft14.Text = "14";
            tabLeft14.Paint += tabLeft14_Paint;
            tabLeft14.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft15
            // 
            tabLeft15.BackColor = Color.LightGray;
            tabLeft15.Location = new Point(27, 4);
            tabLeft15.Name = "tabLeft15";
            tabLeft15.Size = new Size(676, 811);
            tabLeft15.TabIndex = 14;
            tabLeft15.Text = "15";
            tabLeft15.Paint += tabLeft15_Paint;
            tabLeft15.DoubleClick += tabLeft_DoubleClick;
            // 
            // tabLeft16
            // 
            tabLeft16.BackColor = Color.LightGray;
            tabLeft16.Location = new Point(27, 4);
            tabLeft16.Name = "tabLeft16";
            tabLeft16.Size = new Size(676, 811);
            tabLeft16.TabIndex = 15;
            tabLeft16.Text = "16";
            tabLeft16.Paint += tabLeft16_Paint;
            tabLeft16.DoubleClick += tabLeft_DoubleClick;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(trbRightSat);
            panelRight.Controls.Add(btnRightClipboard);
            panelRight.Controls.Add(btnRightFile);
            panelRight.Controls.Add(cbRightType);
            panelRight.Dock = DockStyle.Top;
            panelRight.Location = new Point(0, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(809, 31);
            panelRight.TabIndex = 2;
            // 
            // trbRightSat
            // 
            trbRightSat.Location = new Point(292, 3);
            trbRightSat.Maximum = 100;
            trbRightSat.Name = "trbRightSat";
            trbRightSat.Size = new Size(152, 45);
            trbRightSat.TabIndex = 3;
            trbRightSat.TickStyle = TickStyle.None;
            trbRightSat.Value = 100;
            trbRightSat.ValueChanged += trbRightSat_ValueChanged;
            // 
            // btnRightClipboard
            // 
            btnRightClipboard.Location = new Point(211, 3);
            btnRightClipboard.Name = "btnRightClipboard";
            btnRightClipboard.Size = new Size(75, 23);
            btnRightClipboard.TabIndex = 2;
            btnRightClipboard.Text = "Clipboard";
            btnRightClipboard.UseVisualStyleBackColor = true;
            btnRightClipboard.Click += btnRightClipboard_Click;
            // 
            // btnRightFile
            // 
            btnRightFile.Location = new Point(130, 3);
            btnRightFile.Name = "btnRightFile";
            btnRightFile.Size = new Size(75, 23);
            btnRightFile.TabIndex = 1;
            btnRightFile.Text = "File";
            btnRightFile.UseVisualStyleBackColor = true;
            btnRightFile.Click += btnRightFile_Click;
            // 
            // cbRightType
            // 
            cbRightType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRightType.FlatStyle = FlatStyle.System;
            cbRightType.FormattingEnabled = true;
            cbRightType.Items.AddRange(new object[] { "Datacard", "Custom", "Blank" });
            cbRightType.Location = new Point(3, 4);
            cbRightType.Name = "cbRightType";
            cbRightType.Size = new Size(121, 23);
            cbRightType.TabIndex = 0;
            cbRightType.SelectedIndexChanged += cbRightType_SelectedIndexChanged;
            // 
            // tabControlRight
            // 
            tabControlRight.Alignment = TabAlignment.Right;
            tabControlRight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlRight.Controls.Add(tabRight1);
            tabControlRight.Controls.Add(tabRight2);
            tabControlRight.Controls.Add(tabRight3);
            tabControlRight.Controls.Add(tabRight4);
            tabControlRight.Controls.Add(tabRight5);
            tabControlRight.Controls.Add(tabRight6);
            tabControlRight.Controls.Add(tabRight7);
            tabControlRight.Controls.Add(tabRight8);
            tabControlRight.Controls.Add(tabRight9);
            tabControlRight.Controls.Add(tabRight10);
            tabControlRight.Controls.Add(tabRight11);
            tabControlRight.Controls.Add(tabRight12);
            tabControlRight.Controls.Add(tabRight13);
            tabControlRight.Controls.Add(tabRight14);
            tabControlRight.Controls.Add(tabRight15);
            tabControlRight.Controls.Add(tabRight16);
            tabControlRight.Location = new Point(0, 37);
            tabControlRight.Multiline = true;
            tabControlRight.Name = "tabControlRight";
            tabControlRight.SelectedIndex = 0;
            tabControlRight.Size = new Size(789, 819);
            tabControlRight.TabIndex = 0;
            tabControlRight.SelectedIndexChanged += tabControlRight_SelectedIndexChanged;
            // 
            // tabRight1
            // 
            tabRight1.BackColor = Color.LightGray;
            tabRight1.Location = new Point(4, 4);
            tabRight1.Name = "tabRight1";
            tabRight1.Padding = new Padding(3);
            tabRight1.Size = new Size(758, 811);
            tabRight1.TabIndex = 0;
            tabRight1.Text = "1";
            tabRight1.Paint += tabRight1_Paint;
            tabRight1.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight2
            // 
            tabRight2.BackColor = Color.LightGray;
            tabRight2.Location = new Point(4, 4);
            tabRight2.Name = "tabRight2";
            tabRight2.Padding = new Padding(3);
            tabRight2.Size = new Size(758, 811);
            tabRight2.TabIndex = 1;
            tabRight2.Text = "2";
            tabRight2.Paint += tabRight2_Paint;
            tabRight2.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight3
            // 
            tabRight3.BackColor = Color.LightGray;
            tabRight3.Location = new Point(4, 4);
            tabRight3.Name = "tabRight3";
            tabRight3.Size = new Size(758, 811);
            tabRight3.TabIndex = 2;
            tabRight3.Text = "3";
            tabRight3.Paint += tabRight3_Paint;
            tabRight3.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight4
            // 
            tabRight4.BackColor = Color.LightGray;
            tabRight4.Location = new Point(4, 4);
            tabRight4.Name = "tabRight4";
            tabRight4.Size = new Size(758, 811);
            tabRight4.TabIndex = 3;
            tabRight4.Text = "4";
            tabRight4.Paint += tabRight4_Paint;
            tabRight4.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight5
            // 
            tabRight5.BackColor = Color.LightGray;
            tabRight5.Location = new Point(4, 4);
            tabRight5.Name = "tabRight5";
            tabRight5.Size = new Size(758, 811);
            tabRight5.TabIndex = 4;
            tabRight5.Text = "5";
            tabRight5.Paint += tabRight5_Paint;
            tabRight5.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight6
            // 
            tabRight6.BackColor = Color.LightGray;
            tabRight6.Location = new Point(4, 4);
            tabRight6.Name = "tabRight6";
            tabRight6.Size = new Size(758, 811);
            tabRight6.TabIndex = 5;
            tabRight6.Text = "6";
            tabRight6.Paint += tabRight6_Paint;
            tabRight6.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight7
            // 
            tabRight7.BackColor = Color.LightGray;
            tabRight7.Location = new Point(4, 4);
            tabRight7.Name = "tabRight7";
            tabRight7.Size = new Size(758, 811);
            tabRight7.TabIndex = 6;
            tabRight7.Text = "7";
            tabRight7.Paint += tabRight7_Paint;
            tabRight7.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight8
            // 
            tabRight8.BackColor = Color.LightGray;
            tabRight8.Location = new Point(4, 4);
            tabRight8.Name = "tabRight8";
            tabRight8.Size = new Size(758, 811);
            tabRight8.TabIndex = 7;
            tabRight8.Text = "8";
            tabRight8.Paint += tabRight8_Paint;
            tabRight8.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight9
            // 
            tabRight9.BackColor = Color.LightGray;
            tabRight9.Location = new Point(4, 4);
            tabRight9.Name = "tabRight9";
            tabRight9.Size = new Size(758, 811);
            tabRight9.TabIndex = 8;
            tabRight9.Text = "9";
            tabRight9.Paint += tabRight9_Paint;
            tabRight9.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight10
            // 
            tabRight10.BackColor = Color.LightGray;
            tabRight10.Location = new Point(4, 4);
            tabRight10.Name = "tabRight10";
            tabRight10.Size = new Size(758, 811);
            tabRight10.TabIndex = 9;
            tabRight10.Text = "10";
            tabRight10.Paint += tabRight10_Paint;
            tabRight10.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight11
            // 
            tabRight11.BackColor = Color.LightGray;
            tabRight11.Location = new Point(4, 4);
            tabRight11.Name = "tabRight11";
            tabRight11.Size = new Size(758, 811);
            tabRight11.TabIndex = 10;
            tabRight11.Text = "11";
            tabRight11.Paint += tabRight11_Paint;
            tabRight11.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight12
            // 
            tabRight12.BackColor = Color.LightGray;
            tabRight12.Location = new Point(4, 4);
            tabRight12.Name = "tabRight12";
            tabRight12.Size = new Size(758, 811);
            tabRight12.TabIndex = 11;
            tabRight12.Text = "12";
            tabRight12.Paint += tabRight12_Paint;
            tabRight12.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight13
            // 
            tabRight13.BackColor = Color.LightGray;
            tabRight13.Location = new Point(4, 4);
            tabRight13.Name = "tabRight13";
            tabRight13.Size = new Size(758, 811);
            tabRight13.TabIndex = 12;
            tabRight13.Text = "13";
            tabRight13.Paint += tabRight13_Paint;
            tabRight13.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight14
            // 
            tabRight14.BackColor = Color.LightGray;
            tabRight14.Location = new Point(4, 4);
            tabRight14.Name = "tabRight14";
            tabRight14.Size = new Size(758, 811);
            tabRight14.TabIndex = 13;
            tabRight14.Text = "14";
            tabRight14.Paint += tabRight14_Paint;
            tabRight14.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight15
            // 
            tabRight15.BackColor = Color.LightGray;
            tabRight15.Location = new Point(4, 4);
            tabRight15.Name = "tabRight15";
            tabRight15.Size = new Size(758, 811);
            tabRight15.TabIndex = 14;
            tabRight15.Text = "15";
            tabRight15.Paint += tabRight15_Paint;
            tabRight15.DoubleClick += tabRight_DoubleClick;
            // 
            // tabRight16
            // 
            tabRight16.BackColor = Color.LightGray;
            tabRight16.Location = new Point(4, 4);
            tabRight16.Name = "tabRight16";
            tabRight16.Size = new Size(758, 811);
            tabRight16.TabIndex = 15;
            tabRight16.Text = "16";
            tabRight16.Paint += tabRight16_Paint;
            tabRight16.DoubleClick += tabRight_DoubleClick;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnOpenMission, cbTheater, toolStripButton1, btnReloadMission, btnDTCDropdown, btnLink16, toolStripSeparator1, btnSaveKB, progressBar });
            toolStrip1.Location = new Point(3, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(646, 25);
            toolStrip1.TabIndex = 0;
            // 
            // btnOpenMission
            // 
            btnOpenMission.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnOpenMission.Image = (Image)resources.GetObject("btnOpenMission.Image");
            btnOpenMission.ImageTransparentColor = Color.Magenta;
            btnOpenMission.Name = "btnOpenMission";
            btnOpenMission.Size = new Size(40, 22);
            btnOpenMission.Text = "Open";
            btnOpenMission.Click += btnOpenMission_Click;
            // 
            // cbTheater
            // 
            cbTheater.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTheater.Name = "cbTheater";
            cbTheater.Size = new Size(121, 25);
            cbTheater.SelectedIndexChanged += cbTheater_SelectedIndexChanged;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(75, 22);
            toolStripButton1.Text = "Select Flight";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // btnReloadMission
            // 
            btnReloadMission.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnReloadMission.Image = (Image)resources.GetObject("btnReloadMission.Image");
            btnReloadMission.ImageTransparentColor = Color.Magenta;
            btnReloadMission.Name = "btnReloadMission";
            btnReloadMission.Size = new Size(91, 22);
            btnReloadMission.Text = "Reload Mission";
            btnReloadMission.Click += btnReloadMission_Click;
            // 
            // btnDTCDropdown
            // 
            btnDTCDropdown.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnDTCDropdown.DropDownItems.AddRange(new ToolStripItem[] { muLoadMissionDTC, mnuLoadPilotDTC });
            btnDTCDropdown.Image = (Image)resources.GetObject("btnDTCDropdown.Image");
            btnDTCDropdown.ImageTransparentColor = Color.Magenta;
            btnDTCDropdown.Name = "btnDTCDropdown";
            btnDTCDropdown.Size = new Size(69, 22);
            btnDTCDropdown.Text = "Load DTC";
            // 
            // muLoadMissionDTC
            // 
            muLoadMissionDTC.Name = "muLoadMissionDTC";
            muLoadMissionDTC.Size = new Size(146, 22);
            muLoadMissionDTC.Text = "From Mission";
            muLoadMissionDTC.Click += muLoadMissionDTC_Click;
            // 
            // mnuLoadPilotDTC
            // 
            mnuLoadPilotDTC.Name = "mnuLoadPilotDTC";
            mnuLoadPilotDTC.Size = new Size(146, 22);
            mnuLoadPilotDTC.Text = "Pilot's DTC";
            mnuLoadPilotDTC.Click += mnuLoadPilotDTC_Click;
            // 
            // btnLink16
            // 
            btnLink16.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnLink16.Image = (Image)resources.GetObject("btnLink16.Image");
            btnLink16.ImageTransparentColor = Color.Magenta;
            btnLink16.Name = "btnLink16";
            btnLink16.Size = new Size(45, 22);
            btnLink16.Text = "Link16";
            btnLink16.Click += btnLink16_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // btnSaveKB
            // 
            btnSaveKB.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSaveKB.Image = (Image)resources.GetObject("btnSaveKB.Image");
            btnSaveKB.ImageTransparentColor = Color.Magenta;
            btnSaveKB.Name = "btnSaveKB";
            btnSaveKB.Size = new Size(52, 22);
            btnSaveKB.Text = "Save KB";
            btnSaveKB.Click += btnSaveKB_Click;
            // 
            // progressBar
            // 
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(100, 22);
            progressBar.Visible = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // dlgPasteFile
            // 
            dlgPasteFile.Filter = "Image files (*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg";
            dlgPasteFile.Title = "Paste From File";
            // 
            // ctxMnuDatacard
            // 
            ctxMnuDatacard.Items.AddRange(new ToolStripItem[] { mnuItemSelectFlights, mnuItemSelectSupportFlights });
            ctxMnuDatacard.Name = "ctxMnuSelectFlights";
            ctxMnuDatacard.Size = new Size(198, 48);
            // 
            // mnuItemSelectFlights
            // 
            mnuItemSelectFlights.Name = "mnuItemSelectFlights";
            mnuItemSelectFlights.Size = new Size(197, 22);
            mnuItemSelectFlights.Text = "Select Flights...";
            mnuItemSelectFlights.Click += mnuItemSelectFlights_Click;
            // 
            // mnuItemSelectSupportFlights
            // 
            mnuItemSelectSupportFlights.Name = "mnuItemSelectSupportFlights";
            mnuItemSelectSupportFlights.Size = new Size(197, 22);
            mnuItemSelectSupportFlights.Text = "Select Support Flights...";
            mnuItemSelectSupportFlights.Click += mnuItemSelectSupportFlights_Click;
            // 
            // ctxMnuMap
            // 
            ctxMnuMap.Items.AddRange(new ToolStripItem[] { mnuItemMapSettings, mnuCopyMapSettings, mnuPasteMap, mnuPasteMapSettings });
            ctxMnuMap.Name = "ctxMnuMap";
            ctxMnuMap.Size = new Size(212, 92);
            // 
            // mnuItemMapSettings
            // 
            mnuItemMapSettings.Name = "mnuItemMapSettings";
            mnuItemMapSettings.Size = new Size(211, 22);
            mnuItemMapSettings.Text = "Map Settings...";
            mnuItemMapSettings.Click += mnuItemMapSettings_Click;
            // 
            // mnuCopyMapSettings
            // 
            mnuCopyMapSettings.Name = "mnuCopyMapSettings";
            mnuCopyMapSettings.Size = new Size(211, 22);
            mnuCopyMapSettings.Text = "Copy";
            mnuCopyMapSettings.Click += mnuCopyMapSettings_Click;
            // 
            // mnuPasteMap
            // 
            mnuPasteMap.Name = "mnuPasteMap";
            mnuPasteMap.Size = new Size(211, 22);
            mnuPasteMap.Text = "Paste Map";
            mnuPasteMap.Click += mnuPasteMap_Click;
            // 
            // mnuPasteMapSettings
            // 
            mnuPasteMapSettings.Name = "mnuPasteMapSettings";
            mnuPasteMapSettings.Size = new Size(211, 22);
            mnuPasteMapSettings.Text = "Paste Objects Appearance";
            mnuPasteMapSettings.Click += mnuPasteMapSettings_Click;
            // 
            // ctxMnuBriefing
            // 
            ctxMnuBriefing.Items.AddRange(new ToolStripItem[] { editBriefingToolStripMenuItem });
            ctxMnuBriefing.Name = "ctxMnuBriefing";
            ctxMnuBriefing.Size = new Size(139, 26);
            // 
            // editBriefingToolStripMenuItem
            // 
            editBriefingToolStripMenuItem.Name = "editBriefingToolStripMenuItem";
            editBriefingToolStripMenuItem.Size = new Size(138, 22);
            editBriefingToolStripMenuItem.Text = "Edit Briefing";
            editBriefingToolStripMenuItem.Click += editBriefingToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1520, 905);
            Controls.Add(toolStripContainer);
            Controls.Add(mnuTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mnuTop;
            Name = "MainForm";
            Text = "BMSKneeboarder";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            mnuTop.ResumeLayout(false);
            mnuTop.PerformLayout();
            toolStripContainer.ContentPanel.ResumeLayout(false);
            toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer.TopToolStripPanel.PerformLayout();
            toolStripContainer.ResumeLayout(false);
            toolStripContainer.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbLeftSat).EndInit();
            tabControlLeft.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbRightSat).EndInit();
            tabControlRight.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ctxMnuDatacard.ResumeLayout(false);
            ctxMnuMap.ResumeLayout(false);
            ctxMnuBriefing.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuTop;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuFileOpen;
        private OpenFileDialog dlgOpen;
        private ToolStripContainer toolStripContainer;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private SplitContainer splitContainer1;
        private TabControl tabControlLeft;
        private TabPage tabLeft1;
        private TabPage tabLeft2;
        private TabPage tabLeft3;
        private TabPage tabLeft4;
        private TabPage tabLeft5;
        private TabPage tabLeft6;
        private TabPage tabLeft7;
        private TabPage tabLeft8;
        private TabPage tabLeft9;
        private TabPage tabLeft10;
        private TabPage tabLeft11;
        private TabPage tabLeft12;
        private TabPage tabLeft13;
        private TabPage tabLeft14;
        private TabPage tabLeft15;
        private TabPage tabLeft16;
        private ImageList imageList1;
        private ToolStripButton btnSaveKB;
        private TabControl tabControlRight;
        private TabPage tabRight1;
        private TabPage tabRight2;
        private TabPage tabRight3;
        private TabPage tabRight4;
        private TabPage tabRight5;
        private TabPage tabRight6;
        private TabPage tabRight7;
        private TabPage tabRight8;
        private TabPage tabRight9;
        private TabPage tabRight10;
        private TabPage tabRight11;
        private TabPage tabRight12;
        private TabPage tabRight13;
        private TabPage tabRight14;
        private TabPage tabRight15;
        private TabPage tabRight16;
        private Panel panelLeft;
        private ComboBox cbLeftType;
        private Panel panelRight;
        private ComboBox cbRightType;
        private ToolStripComboBox cbTheater;
        private Button btnRightClipboard;
        private Button btnRightFile;
        private OpenFileDialog dlgPasteFile;
        private Button btnLeftFile;
        private Button btnLeftClipboard;
        private ContextMenuStrip ctxMnuDatacard;
        private ToolStripMenuItem mnuItemSelectFlights;
        private ToolStripButton btnOpenMission;
        private ToolStripMenuItem mnuItemSelectSupportFlights;
        private TrackBar trbRightSat;
        private TrackBar trbLeftSat;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ContextMenuStrip ctxMnuMap;
        private ToolStripMenuItem mnuItemMapSettings;
        private ToolStripDropDownButton btnDTCDropdown;
        private ToolStripMenuItem muLoadMissionDTC;
        private ToolStripMenuItem mnuLoadPilotDTC;
        private ToolStripSeparator toolStripSeparator1;
        private ContextMenuStrip ctxMnuBriefing;
        private ToolStripMenuItem editBriefingToolStripMenuItem;
        private ToolStripButton btnLink16;
        private ToolStripProgressBar progressBar;
        private ToolStripMenuItem mnuCopyMapSettings;
        private ToolStripMenuItem mnuPasteMapSettings;
        private ToolStripMenuItem mnuPasteMap;
        private ToolStripButton btnReloadMission;
    }
}
