namespace BMSKneeboarder
{
    partial class BriefingSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BriefingSettingsForm));
            udBingo = new NumericUpDown();
            udJoker = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            btnOk = new Button();
            btnCancel = new Button();
            tbBriefing = new TextBox();
            ((System.ComponentModel.ISupportInitialize)udBingo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udJoker).BeginInit();
            SuspendLayout();
            // 
            // udBingo
            // 
            udBingo.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            udBingo.Location = new Point(73, 12);
            udBingo.Maximum = new decimal(new int[] { 20000, 0, 0, 0 });
            udBingo.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            udBingo.Name = "udBingo";
            udBingo.Size = new Size(72, 23);
            udBingo.TabIndex = 0;
            udBingo.ThousandsSeparator = true;
            udBingo.Value = new decimal(new int[] { 3000, 0, 0, 0 });
            udBingo.ValueChanged += udBingo_ValueChanged;
            // 
            // udJoker
            // 
            udJoker.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            udJoker.Location = new Point(271, 12);
            udJoker.Maximum = new decimal(new int[] { 20000, 0, 0, 0 });
            udJoker.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            udJoker.Name = "udJoker";
            udJoker.Size = new Size(73, 23);
            udJoker.TabIndex = 1;
            udJoker.ThousandsSeparator = true;
            udJoker.Value = new decimal(new int[] { 3000, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 2;
            label1.Text = "Bingo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(216, 14);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 3;
            label2.Text = "Joker:";
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOk.Location = new Point(12, 415);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 4;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(713, 415);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tbBriefing
            // 
            tbBriefing.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbBriefing.Location = new Point(12, 61);
            tbBriefing.Multiline = true;
            tbBriefing.Name = "tbBriefing";
            tbBriefing.Size = new Size(776, 348);
            tbBriefing.TabIndex = 6;
            // 
            // BriefingSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbBriefing);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(udJoker);
            Controls.Add(udBingo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BriefingSettingsForm";
            Text = "Briefing";
            Load += BriefingSettingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)udBingo).EndInit();
            ((System.ComponentModel.ISupportInitialize)udJoker).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown udBingo;
        private NumericUpDown udJoker;
        private Label label1;
        private Label label2;
        private Button btnOk;
        private Button btnCancel;
        private TextBox tbBriefing;
    }
}