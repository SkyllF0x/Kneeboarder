namespace BMSKneeboarder
{
    partial class SelectFlightForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectFlightForm));
            lbFlights = new ListBox();
            btnOk = new Button();
            btnCancel = new Button();
            tbSearch = new TextBox();
            SuspendLayout();
            // 
            // lbFlights
            // 
            lbFlights.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbFlights.FormattingEnabled = true;
            lbFlights.ItemHeight = 15;
            lbFlights.Location = new Point(12, 42);
            lbFlights.Name = "lbFlights";
            lbFlights.Size = new Size(396, 484);
            lbFlights.TabIndex = 0;
            lbFlights.DoubleClick += btnOk_Click;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOk.Location = new Point(12, 548);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "Select";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(333, 548);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tbSearch
            // 
            tbSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSearch.Location = new Point(12, 12);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Search...";
            tbSearch.Size = new Size(396, 23);
            tbSearch.TabIndex = 3;
            tbSearch.TextChanged += tbSearch_TextChanged;
            // 
            // SelectFlightForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 583);
            Controls.Add(tbSearch);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(lbFlights);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SelectFlightForm";
            Text = "Select Flight";
            Load += SelectFlightForm_Load;
            Shown += SelectFlightForm_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbFlights;
        private Button btnOk;
        private Button btnCancel;
        private TextBox tbSearch;
    }
}