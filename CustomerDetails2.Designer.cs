namespace ZBCashRegistation
{
    partial class CustomerDetails2
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
            this.crystalCustomerDetails2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalCustomerDetails2
            // 
            this.crystalCustomerDetails2.ActiveViewIndex = -1;
            this.crystalCustomerDetails2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalCustomerDetails2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalCustomerDetails2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalCustomerDetails2.Location = new System.Drawing.Point(0, 0);
            this.crystalCustomerDetails2.Name = "crystalCustomerDetails2";
            this.crystalCustomerDetails2.Size = new System.Drawing.Size(1008, 450);
            this.crystalCustomerDetails2.TabIndex = 0;
            // 
            // CustomerDetails2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 450);
            this.Controls.Add(this.crystalCustomerDetails2);
            this.Name = "CustomerDetails2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerDetails2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CustomerDetails2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalCustomerDetails2;
    }
}