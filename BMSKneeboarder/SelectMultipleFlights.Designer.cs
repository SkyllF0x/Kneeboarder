namespace BMSKneeboarder
{
    partial class SelectMultipleFlights
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectMultipleFlights));
            label1 = new Label();
            lbSelectedFlights = new ListBox();
            lbFlights = new ListBox();
            btnAdd = new Button();
            btnRemove = new Button();
            btnOk = new Button();
            btnCancel = new Button();
            tbSearch = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Selected:";
            // 
            // lbSelectedFlights
            // 
            lbSelectedFlights.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbSelectedFlights.FormattingEnabled = true;
            lbSelectedFlights.ItemHeight = 15;
            lbSelectedFlights.Location = new Point(12, 27);
            lbSelectedFlights.Name = "lbSelectedFlights";
            lbSelectedFlights.SelectionMode = SelectionMode.MultiExtended;
            lbSelectedFlights.Size = new Size(239, 424);
            lbSelectedFlights.TabIndex = 1;
            // 
            // lbFlights
            // 
            lbFlights.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbFlights.FormattingEnabled = true;
            lbFlights.ItemHeight = 15;
            lbFlights.Location = new Point(338, 57);
            lbFlights.Name = "lbFlights";
            lbFlights.SelectionMode = SelectionMode.MultiExtended;
            lbFlights.Size = new Size(234, 394);
            lbFlights.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(257, 187);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "<";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(257, 216);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 4;
            btnRemove.Text = ">";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOk.Location = new Point(12, 473);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 5;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(497, 473);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tbSearch
            // 
            tbSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSearch.Location = new Point(338, 27);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Search...";
            tbSearch.Size = new Size(234, 23);
            tbSearch.TabIndex = 7;
            tbSearch.TextChanged += tbSearch_TextChanged;
            // 
            // SelectMultipleFlights
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 508);
            Controls.Add(tbSearch);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(lbFlights);
            Controls.Add(lbSelectedFlights);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SelectMultipleFlights";
            Text = "Select Flights";
            Load += SelectMultipleFlights_Load;
            Shown += SelectMultipleFlights_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox lbSelectedFlights;
        private ListBox lbFlights;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnOk;
        private Button btnCancel;
        private TextBox tbSearch;
    }
}