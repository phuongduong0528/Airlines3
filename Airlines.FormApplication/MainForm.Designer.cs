namespace Airlines.FormApplication
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.applyBtn = new System.Windows.Forms.Button();
            this.returnDtp = new System.Windows.Forms.DateTimePicker();
            this.outboundDtp = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.returnRbt = new System.Windows.Forms.RadioButton();
            this.onewayRbt = new System.Windows.Forms.RadioButton();
            this.cabintypeCbx = new System.Windows.Forms.ComboBox();
            this.toCbx = new System.Windows.Forms.ComboBox();
            this.fromCbx = new System.Windows.Forms.ComboBox();
            this.outboundflightDgv = new System.Windows.Forms.DataGridView();
            this.returnflightDgv = new System.Windows.Forms.DataGridView();
            this.outboundChk = new System.Windows.Forms.CheckBox();
            this.returnChk = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outboundflightDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnflightDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.applyBtn);
            this.groupBox1.Controls.Add(this.returnDtp);
            this.groupBox1.Controls.Add(this.outboundDtp);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.returnRbt);
            this.groupBox1.Controls.Add(this.onewayRbt);
            this.groupBox1.Controls.Add(this.cabintypeCbx);
            this.groupBox1.Controls.Add(this.toCbx);
            this.groupBox1.Controls.Add(this.fromCbx);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(814, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Parameters";
            // 
            // applyBtn
            // 
            this.applyBtn.Enabled = false;
            this.applyBtn.Location = new System.Drawing.Point(696, 72);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(111, 33);
            this.applyBtn.TabIndex = 5;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // returnDtp
            // 
            this.returnDtp.CustomFormat = "dd/MM/yyyy";
            this.returnDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.returnDtp.Location = new System.Drawing.Point(533, 74);
            this.returnDtp.Name = "returnDtp";
            this.returnDtp.Size = new System.Drawing.Size(145, 26);
            this.returnDtp.TabIndex = 4;
            // 
            // outboundDtp
            // 
            this.outboundDtp.CustomFormat = "dd/MM/yyyy";
            this.outboundDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.outboundDtp.Location = new System.Drawing.Point(317, 74);
            this.outboundDtp.Name = "outboundDtp";
            this.outboundDtp.Size = new System.Drawing.Size(145, 26);
            this.outboundDtp.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(475, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Return";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Outbound";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(572, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cabin Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // returnRbt
            // 
            this.returnRbt.AutoSize = true;
            this.returnRbt.Location = new System.Drawing.Point(139, 76);
            this.returnRbt.Name = "returnRbt";
            this.returnRbt.Size = new System.Drawing.Size(70, 24);
            this.returnRbt.TabIndex = 2;
            this.returnRbt.TabStop = true;
            this.returnRbt.Text = "Return";
            this.returnRbt.UseVisualStyleBackColor = true;
            // 
            // onewayRbt
            // 
            this.onewayRbt.AutoSize = true;
            this.onewayRbt.Location = new System.Drawing.Point(8, 76);
            this.onewayRbt.Name = "onewayRbt";
            this.onewayRbt.Size = new System.Drawing.Size(90, 24);
            this.onewayRbt.TabIndex = 2;
            this.onewayRbt.TabStop = true;
            this.onewayRbt.Text = "One way";
            this.onewayRbt.UseVisualStyleBackColor = true;
            // 
            // cabintypeCbx
            // 
            this.cabintypeCbx.FormattingEnabled = true;
            this.cabintypeCbx.Items.AddRange(new object[] {
            "Economy",
            "Business",
            "First class"});
            this.cabintypeCbx.Location = new System.Drawing.Point(664, 26);
            this.cabintypeCbx.Name = "cabintypeCbx";
            this.cabintypeCbx.Size = new System.Drawing.Size(143, 28);
            this.cabintypeCbx.TabIndex = 0;
            // 
            // toCbx
            // 
            this.toCbx.FormattingEnabled = true;
            this.toCbx.Location = new System.Drawing.Point(365, 26);
            this.toCbx.Name = "toCbx";
            this.toCbx.Size = new System.Drawing.Size(143, 28);
            this.toCbx.TabIndex = 0;
            // 
            // fromCbx
            // 
            this.fromCbx.FormattingEnabled = true;
            this.fromCbx.Location = new System.Drawing.Point(87, 26);
            this.fromCbx.Name = "fromCbx";
            this.fromCbx.Size = new System.Drawing.Size(143, 28);
            this.fromCbx.TabIndex = 0;
            // 
            // outboundflightDgv
            // 
            this.outboundflightDgv.AllowUserToAddRows = false;
            this.outboundflightDgv.AllowUserToDeleteRows = false;
            this.outboundflightDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outboundflightDgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.outboundflightDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outboundflightDgv.Location = new System.Drawing.Point(9, 164);
            this.outboundflightDgv.Name = "outboundflightDgv";
            this.outboundflightDgv.ReadOnly = true;
            this.outboundflightDgv.Size = new System.Drawing.Size(814, 139);
            this.outboundflightDgv.TabIndex = 1;
            // 
            // returnflightDgv
            // 
            this.returnflightDgv.AllowUserToAddRows = false;
            this.returnflightDgv.AllowUserToDeleteRows = false;
            this.returnflightDgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.returnflightDgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.returnflightDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.returnflightDgv.Location = new System.Drawing.Point(12, 340);
            this.returnflightDgv.Name = "returnflightDgv";
            this.returnflightDgv.ReadOnly = true;
            this.returnflightDgv.Size = new System.Drawing.Size(814, 139);
            this.returnflightDgv.TabIndex = 1;
            // 
            // outboundChk
            // 
            this.outboundChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outboundChk.AutoSize = true;
            this.outboundChk.Location = new System.Drawing.Point(549, 131);
            this.outboundChk.Name = "outboundChk";
            this.outboundChk.Size = new System.Drawing.Size(279, 24);
            this.outboundChk.TabIndex = 2;
            this.outboundChk.Text = "Display three days before and after";
            this.outboundChk.UseVisualStyleBackColor = true;
            // 
            // returnChk
            // 
            this.returnChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.returnChk.AutoSize = true;
            this.returnChk.Location = new System.Drawing.Point(546, 306);
            this.returnChk.Name = "returnChk";
            this.returnChk.Size = new System.Drawing.Size(279, 24);
            this.returnChk.TabIndex = 2;
            this.returnChk.Text = "Display three days before and after";
            this.returnChk.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Outbound flight details";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Return flight details";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 500);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.returnChk);
            this.Controls.Add(this.outboundChk);
            this.Controls.Add(this.returnflightDgv);
            this.Controls.Add(this.outboundflightDgv);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tw Cen MT", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outboundflightDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnflightDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton returnRbt;
        private System.Windows.Forms.RadioButton onewayRbt;
        private System.Windows.Forms.ComboBox cabintypeCbx;
        private System.Windows.Forms.ComboBox toCbx;
        private System.Windows.Forms.ComboBox fromCbx;
        private System.Windows.Forms.DateTimePicker returnDtp;
        private System.Windows.Forms.DateTimePicker outboundDtp;
        private System.Windows.Forms.DataGridView outboundflightDgv;
        private System.Windows.Forms.DataGridView returnflightDgv;
        private System.Windows.Forms.CheckBox outboundChk;
        private System.Windows.Forms.CheckBox returnChk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button applyBtn;
    }
}

