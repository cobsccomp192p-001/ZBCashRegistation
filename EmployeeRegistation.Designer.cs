namespace ZBCashRegistation
{
    partial class EmployeeRegistation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeRegistation));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnupdate = new System.Windows.Forms.Button();
            this.txtdesignation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtempphone2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txthidempno = new System.Windows.Forms.TextBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.txtempphone1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtempname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employeename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Designation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnupdate);
            this.panel1.Controls.Add(this.txtdesignation);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtaddress);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtempphone2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txthidempno);
            this.panel1.Controls.Add(this.btncancel);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Controls.Add(this.txtempphone1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtempname);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 247);
            this.panel1.TabIndex = 0;
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnupdate.Location = new System.Drawing.Point(628, 198);
            this.btnupdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(100, 32);
            this.btnupdate.TabIndex = 15;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // txtdesignation
            // 
            this.txtdesignation.Location = new System.Drawing.Point(199, 199);
            this.txtdesignation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtdesignation.Name = "txtdesignation";
            this.txtdesignation.Size = new System.Drawing.Size(224, 22);
            this.txtdesignation.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 199);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Designation";
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(199, 156);
            this.txtaddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(224, 22);
            this.txtaddress.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 156);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Address";
            // 
            // txtempphone2
            // 
            this.txtempphone2.Location = new System.Drawing.Point(199, 113);
            this.txtempphone2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtempphone2.Name = "txtempphone2";
            this.txtempphone2.Size = new System.Drawing.Size(224, 22);
            this.txtempphone2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Phone Number2";
            // 
            // txthidempno
            // 
            this.txthidempno.Location = new System.Drawing.Point(721, 4);
            this.txthidempno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txthidempno.Multiline = true;
            this.txthidempno.Name = "txthidempno";
            this.txthidempno.Size = new System.Drawing.Size(117, 24);
            this.txthidempno.TabIndex = 8;
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btncancel.Location = new System.Drawing.Point(744, 197);
            this.btncancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(100, 32);
            this.btncancel.TabIndex = 7;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnsave.Location = new System.Drawing.Point(628, 197);
            this.btnsave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(100, 32);
            this.btnsave.TabIndex = 6;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtempphone1
            // 
            this.txtempphone1.Location = new System.Drawing.Point(199, 70);
            this.txtempphone1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtempphone1.Name = "txtempphone1";
            this.txtempphone1.Size = new System.Drawing.Size(224, 22);
            this.txtempphone1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phone Number1";
            // 
            // txtempname
            // 
            this.txtempname.Location = new System.Drawing.Point(199, 27);
            this.txtempname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtempname.Name = "txtempname";
            this.txtempname.Size = new System.Drawing.Size(224, 22);
            this.txtempname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Employeename,
            this.Phone,
            this.phone2,
            this.Address,
            this.Designation});
            this.dataGridView1.Location = new System.Drawing.Point(15, 270);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(864, 170);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // Employeename
            // 
            this.Employeename.HeaderText = "EmployeeName";
            this.Employeename.MinimumWidth = 6;
            this.Employeename.Name = "Employeename";
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Phone 1";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            // 
            // phone2
            // 
            this.phone2.HeaderText = "Phone2";
            this.phone2.MinimumWidth = 6;
            this.phone2.Name = "phone2";
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            // 
            // Designation
            // 
            this.Designation.HeaderText = "Designation";
            this.Designation.MinimumWidth = 6;
            this.Designation.Name = "Designation";
            // 
            // EmployeeRegistation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 444);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(910, 491);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(910, 491);
            this.Name = "EmployeeRegistation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Registation";
            this.Load += new System.EventHandler(this.EmployeeRegistation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtempphone1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtempname;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtdesignation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtempphone2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txthidempno;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employeename;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Designation;
    }
}