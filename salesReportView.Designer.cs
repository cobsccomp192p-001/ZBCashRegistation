namespace ZBCashRegistation
{
    partial class salesReportView
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
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnsupdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cashInhand1 = new ZBCashRegistation.DataSet.cashInhand();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashInhand1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpfrom
            // 
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrom.Location = new System.Drawing.Point(88, 23);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.Size = new System.Drawing.Size(145, 20);
            this.dtpfrom.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnsupdate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpfrom);
            this.panel1.Location = new System.Drawing.Point(78, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 60);
            this.panel1.TabIndex = 1;
            // 
            // btnsupdate
            // 
            this.btnsupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnsupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsupdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnsupdate.Location = new System.Drawing.Point(546, 18);
            this.btnsupdate.Name = "btnsupdate";
            this.btnsupdate.Size = new System.Drawing.Size(75, 26);
            this.btnsupdate.TabIndex = 9;
            this.btnsupdate.Text = "Report";
            this.btnsupdate.UseVisualStyleBackColor = false;
            this.btnsupdate.Click += new System.EventHandler(this.btnsupdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(298, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // dtpto
            // 
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(343, 23);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(145, 20);
            this.dtpto.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(78, 68);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(803, 393);
            this.crystalReportViewer1.TabIndex = 2;
            // 
            // cashInhand1
            // 
            this.cashInhand1.DataSetName = "cashInhand";
            this.cashInhand1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // salesReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 526);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "salesReportView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "salesReportView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.salesReportView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashInhand1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpfrom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btnsupdate;
        private DataSet.cashInhand cashInhand1;
    }
}