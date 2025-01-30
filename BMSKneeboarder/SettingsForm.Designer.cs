namespace BMSKneeboarder
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            label1 = new Label();
            cbPilot = new ComboBox();
            btnOk = new Button();
            btnCancel = new Button();
            tbBmsDir = new TextBox();
            label2 = new Label();
            tcSettings = new TabControl();
            tabGeneral = new TabPage();
            tabTheaters = new TabPage();
            pTheaterEdit = new Panel();
            btnSelectMap2 = new Button();
            pbTheaterMap2 = new PictureBox();
            label4 = new Label();
            btnSelectMap = new Button();
            pbTheaterMap = new PictureBox();
            label3 = new Label();
            lbTheaters = new ListBox();
            dlgSelectMapFile = new OpenFileDialog();
            btnApply = new Button();
            dlgSelectDir = new FolderBrowserDialog();
            btnBrowseDir = new Button();
            tcSettings.SuspendLayout();
            tabGeneral.SuspendLayout();
            tabTheaters.SuspendLayout();
            pTheaterEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbTheaterMap2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbTheaterMap).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 38);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 0;
            label1.Text = "Pilot:";
            // 
            // cbPilot
            // 
            cbPilot.FormattingEnabled = true;
            cbPilot.Location = new Point(134, 35);
            cbPilot.Name = "cbPilot";
            cbPilot.Size = new Size(159, 23);
            cbPilot.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOk.Location = new Point(12, 423);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 2;
            btnOk.Text = "Save";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(490, 423);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tbBmsDir
            // 
            tbBmsDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbBmsDir.Location = new Point(134, 6);
            tbBmsDir.Name = "tbBmsDir";
            tbBmsDir.Size = new Size(324, 23);
            tbBmsDir.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 9);
            label2.Name = "label2";
            label2.Size = new Size(122, 15);
            label2.TabIndex = 5;
            label2.Text = "Falcon BMS directory:";
            // 
            // tcSettings
            // 
            tcSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tcSettings.Controls.Add(tabGeneral);
            tcSettings.Controls.Add(tabTheaters);
            tcSettings.Location = new Point(12, 12);
            tcSettings.Name = "tcSettings";
            tcSettings.SelectedIndex = 0;
            tcSettings.Size = new Size(553, 405);
            tcSettings.TabIndex = 6;
            // 
            // tabGeneral
            // 
            tabGeneral.Controls.Add(btnBrowseDir);
            tabGeneral.Controls.Add(tbBmsDir);
            tabGeneral.Controls.Add(label2);
            tabGeneral.Controls.Add(cbPilot);
            tabGeneral.Controls.Add(label1);
            tabGeneral.Location = new Point(4, 24);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.Padding = new Padding(3);
            tabGeneral.Size = new Size(545, 377);
            tabGeneral.TabIndex = 0;
            tabGeneral.Text = "General";
            tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tabTheaters
            // 
            tabTheaters.Controls.Add(pTheaterEdit);
            tabTheaters.Controls.Add(lbTheaters);
            tabTheaters.Location = new Point(4, 24);
            tabTheaters.Name = "tabTheaters";
            tabTheaters.Padding = new Padding(3);
            tabTheaters.Size = new Size(867, 473);
            tabTheaters.TabIndex = 1;
            tabTheaters.Text = "Theaters";
            tabTheaters.UseVisualStyleBackColor = true;
            // 
            // pTheaterEdit
            // 
            pTheaterEdit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pTheaterEdit.Controls.Add(btnSelectMap2);
            pTheaterEdit.Controls.Add(pbTheaterMap2);
            pTheaterEdit.Controls.Add(label4);
            pTheaterEdit.Controls.Add(btnSelectMap);
            pTheaterEdit.Controls.Add(pbTheaterMap);
            pTheaterEdit.Controls.Add(label3);
            pTheaterEdit.Location = new Point(185, 6);
            pTheaterEdit.Name = "pTheaterEdit";
            pTheaterEdit.Size = new Size(676, 461);
            pTheaterEdit.TabIndex = 1;
            pTheaterEdit.Visible = false;
            // 
            // btnSelectMap2
            // 
            btnSelectMap2.Location = new Point(208, 172);
            btnSelectMap2.Name = "btnSelectMap2";
            btnSelectMap2.Size = new Size(117, 23);
            btnSelectMap2.TabIndex = 5;
            btnSelectMap2.Text = "Select Map File";
            btnSelectMap2.UseVisualStyleBackColor = true;
            btnSelectMap2.Click += btnSelectMap2_Click;
            // 
            // pbTheaterMap2
            // 
            pbTheaterMap2.Location = new Point(52, 172);
            pbTheaterMap2.Name = "pbTheaterMap2";
            pbTheaterMap2.Size = new Size(150, 150);
            pbTheaterMap2.TabIndex = 4;
            pbTheaterMap2.TabStop = false;
            pbTheaterMap2.Paint += pbTheaterMap2_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 172);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 3;
            label4.Text = "Map 2:";
            // 
            // btnSelectMap
            // 
            btnSelectMap.Location = new Point(208, 3);
            btnSelectMap.Name = "btnSelectMap";
            btnSelectMap.Size = new Size(117, 23);
            btnSelectMap.TabIndex = 2;
            btnSelectMap.Text = "Select Map File";
            btnSelectMap.UseVisualStyleBackColor = true;
            btnSelectMap.Click += btnSelectMap_Click;
            // 
            // pbTheaterMap
            // 
            pbTheaterMap.Location = new Point(52, 3);
            pbTheaterMap.Name = "pbTheaterMap";
            pbTheaterMap.Size = new Size(150, 150);
            pbTheaterMap.TabIndex = 1;
            pbTheaterMap.TabStop = false;
            pbTheaterMap.Paint += pbTheaterMap_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 3);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 0;
            label3.Text = "Map:";
            // 
            // lbTheaters
            // 
            lbTheaters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbTheaters.FormattingEnabled = true;
            lbTheaters.ItemHeight = 15;
            lbTheaters.Location = new Point(6, 6);
            lbTheaters.Name = "lbTheaters";
            lbTheaters.Size = new Size(173, 454);
            lbTheaters.TabIndex = 0;
            lbTheaters.SelectedIndexChanged += lbTheaters_SelectedIndexChanged;
            // 
            // dlgSelectMapFile
            // 
            dlgSelectMapFile.Filter = "Image files (*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg";
            dlgSelectMapFile.Title = "Select Map File";
            // 
            // btnApply
            // 
            btnApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnApply.Location = new Point(93, 423);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(75, 23);
            btnApply.TabIndex = 7;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // dlgSelectDir
            // 
            dlgSelectDir.ShowNewFolderButton = false;
            // 
            // btnBrowseDir
            // 
            btnBrowseDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseDir.Location = new Point(464, 6);
            btnBrowseDir.Name = "btnBrowseDir";
            btnBrowseDir.Size = new Size(75, 23);
            btnBrowseDir.TabIndex = 6;
            btnBrowseDir.Text = "Browse";
            btnBrowseDir.UseVisualStyleBackColor = true;
            btnBrowseDir.Click += btnBrowseDir_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 458);
            Controls.Add(btnApply);
            Controls.Add(tcSettings);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            Text = "Settings";
            FormClosed += SettingsForm_FormClosed;
            Load += SettingsForm_Load;
            tcSettings.ResumeLayout(false);
            tabGeneral.ResumeLayout(false);
            tabGeneral.PerformLayout();
            tabTheaters.ResumeLayout(false);
            pTheaterEdit.ResumeLayout(false);
            pTheaterEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbTheaterMap2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbTheaterMap).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox cbPilot;
        private Button btnOk;
        private Button btnCancel;
        private TextBox tbBmsDir;
        private Label label2;
        private TabControl tcSettings;
        private TabPage tabGeneral;
        private TabPage tabTheaters;
        private Panel pTheaterEdit;
        private ListBox lbTheaters;
        private PictureBox pbTheaterMap;
        private Label label3;
        private Button btnSelectMap;
        private OpenFileDialog dlgSelectMapFile;
        private Button btnSelectMap2;
        private PictureBox pbTheaterMap2;
        private Label label4;
        private Button btnApply;
        private Button btnBrowseDir;
        private FolderBrowserDialog dlgSelectDir;
    }
}