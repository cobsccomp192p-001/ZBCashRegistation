namespace ZBCashRegistation
{
    partial class FoodItemsreg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodItemsreg));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsupdate = new System.Windows.Forms.Button();
            this.txtitemhidId = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbcategory = new System.Windows.Forms.ComboBox();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.txtfoodname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cateid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btncancel);
            this.panel1.Controls.Add(this.btnsupdate);
            this.panel1.Controls.Add(this.txtitemhidId);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.cmbcategory);
            this.panel1.Controls.Add(this.txtdescription);
            this.panel1.Controls.Add(this.txtfoodname);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 460);
            this.panel1.TabIndex = 0;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(27, 171);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(232, 22);
            this.txtPrice.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sale Price";
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btncancel.Location = new System.Drawing.Point(160, 417);
            this.btncancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(100, 32);
            this.btncancel.TabIndex = 9;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsupdate
            // 
            this.btnsupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnsupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsupdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnsupdate.Location = new System.Drawing.Point(160, 378);
            this.btnsupdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsupdate.Name = "btnsupdate";
            this.btnsupdate.Size = new System.Drawing.Size(100, 32);
            this.btnsupdate.TabIndex = 8;
            this.btnsupdate.Text = "Update";
            this.btnsupdate.UseVisualStyleBackColor = false;
            this.btnsupdate.Click += new System.EventHandler(this.btnsupdate_Click);
            // 
            // txtitemhidId
            // 
            this.txtitemhidId.Location = new System.Drawing.Point(137, 4);
            this.txtitemhidId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtitemhidId.Multiline = true;
            this.txtitemhidId.Name = "txtitemhidId";
            this.txtitemhidId.Size = new System.Drawing.Size(153, 25);
            this.txtitemhidId.TabIndex = 7;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdate.Location = new System.Drawing.Point(160, 378);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 32);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbcategory
            // 
            this.cmbcategory.FormattingEnabled = true;
            this.cmbcategory.Location = new System.Drawing.Point(27, 106);
            this.cmbcategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbcategory.Name = "cmbcategory";
            this.cmbcategory.Size = new System.Drawing.Size(232, 24);
            this.cmbcategory.TabIndex = 1;
            // 
            // txtdescription
            // 
            this.txtdescription.Location = new System.Drawing.Point(27, 238);
            this.txtdescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(232, 125);
            this.txtdescription.TabIndex = 5;
            // 
            // txtfoodname
            // 
            this.txtfoodname.Location = new System.Drawing.Point(27, 38);
            this.txtfoodname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtfoodname.Name = "txtfoodname";
            this.txtfoodname.Size = new System.Drawing.Size(232, 22);
            this.txtfoodname.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 215);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Category";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Food Item";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.ItemName,
            this.Category,
            this.price,
            this.Description,
            this.cateid});
            this.dataGridView1.Location = new System.Drawing.Point(307, 15);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(572, 425);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "id";
            this.ItemID.MinimumWidth = 6;
            this.ItemID.Name = "ItemID";
            this.ItemID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item";
            this.ItemName.MinimumWidth = 6;
            this.ItemName.Name = "ItemName";
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            // 
            // price
            // 
            this.price.HeaderText = "Price";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            // 
            // cateid
            // 
            this.cateid.HeaderText = "CategoryId";
            this.cateid.MinimumWidth = 6;
            this.cateid.Name = "cateid";
            this.cateid.Visible = false;
            // 
            // FoodItemsreg
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
            this.Name = "FoodItemsreg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Food Item Registation";
            this.Load += new System.EventHandler(this.FoodItemsreg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbcategory;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.TextBox txtfoodname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtitemhidId;
        private System.Windows.Forms.Button btnsupdate;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn cateid;
    }
}