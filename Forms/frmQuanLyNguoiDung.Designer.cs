namespace Forms
{
    partial class frmQuanLyNguoiDung
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenNguoiDung = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbVaiTro = new System.Windows.Forms.ComboBox();
            this.dgvNguoiDung = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaNguoiDung = new System.Windows.Forms.TextBox();
            this.btnXemHoaDon = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.rdHienThiToanBo = new System.Windows.Forms.RadioButton();
            this.rdChiHienNV = new System.Windows.Forms.RadioButton();
            this.rdChiHienKH = new System.Windows.Forms.RadioButton();
            this.rdChiHienQL = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTongQL = new System.Windows.Forms.TextBox();
            this.txtTongNV = new System.Windows.Forms.TextBox();
            this.txtTongKH = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên người dùng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "SDT";
            // 
            // txtTenNguoiDung
            // 
            this.txtTenNguoiDung.Location = new System.Drawing.Point(152, 38);
            this.txtTenNguoiDung.Name = "txtTenNguoiDung";
            this.txtTenNguoiDung.ReadOnly = true;
            this.txtTenNguoiDung.Size = new System.Drawing.Size(185, 22);
            this.txtTenNguoiDung.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(152, 69);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(185, 22);
            this.txtEmail.TabIndex = 4;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(152, 100);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.ReadOnly = true;
            this.txtSDT.Size = new System.Drawing.Size(185, 22);
            this.txtSDT.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Vai trò";
            // 
            // cbbVaiTro
            // 
            this.cbbVaiTro.FormattingEnabled = true;
            this.cbbVaiTro.Location = new System.Drawing.Point(152, 133);
            this.cbbVaiTro.Name = "cbbVaiTro";
            this.cbbVaiTro.Size = new System.Drawing.Size(185, 24);
            this.cbbVaiTro.TabIndex = 7;
            // 
            // dgvNguoiDung
            // 
            this.dgvNguoiDung.AllowUserToAddRows = false;
            this.dgvNguoiDung.AllowUserToDeleteRows = false;
            this.dgvNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguoiDung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvNguoiDung.Location = new System.Drawing.Point(16, 168);
            this.dgvNguoiDung.Name = "dgvNguoiDung";
            this.dgvNguoiDung.ReadOnly = true;
            this.dgvNguoiDung.RowHeadersWidth = 51;
            this.dgvNguoiDung.RowTemplate.Height = 24;
            this.dgvNguoiDung.Size = new System.Drawing.Size(720, 341);
            this.dgvNguoiDung.TabIndex = 8;
            this.dgvNguoiDung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNguoiDung_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mã người dùng";
            // 
            // txtMaNguoiDung
            // 
            this.txtMaNguoiDung.Location = new System.Drawing.Point(152, 7);
            this.txtMaNguoiDung.Name = "txtMaNguoiDung";
            this.txtMaNguoiDung.ReadOnly = true;
            this.txtMaNguoiDung.Size = new System.Drawing.Size(185, 22);
            this.txtMaNguoiDung.TabIndex = 10;
            // 
            // btnXemHoaDon
            // 
            this.btnXemHoaDon.Location = new System.Drawing.Point(460, 7);
            this.btnXemHoaDon.Name = "btnXemHoaDon";
            this.btnXemHoaDon.Size = new System.Drawing.Size(102, 50);
            this.btnXemHoaDon.TabIndex = 12;
            this.btnXemHoaDon.Text = "Xem hoá đơn đã mua";
            this.btnXemHoaDon.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã Người Dùng";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Username";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Email";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "SDT";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Vai trò";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            this.Column6.Width = 125;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(352, 7);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(102, 50);
            this.btnCapNhat.TabIndex = 13;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // rdHienThiToanBo
            // 
            this.rdHienThiToanBo.AutoSize = true;
            this.rdHienThiToanBo.Location = new System.Drawing.Point(571, 132);
            this.rdHienThiToanBo.Name = "rdHienThiToanBo";
            this.rdHienThiToanBo.Size = new System.Drawing.Size(120, 20);
            this.rdHienThiToanBo.TabIndex = 14;
            this.rdHienThiToanBo.TabStop = true;
            this.rdHienThiToanBo.Tag = "All";
            this.rdHienThiToanBo.Text = "Hiển thị toàn bộ";
            this.rdHienThiToanBo.UseVisualStyleBackColor = true;
            this.rdHienThiToanBo.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // rdChiHienNV
            // 
            this.rdChiHienNV.AutoSize = true;
            this.rdChiHienNV.Location = new System.Drawing.Point(571, 100);
            this.rdChiHienNV.Name = "rdChiHienNV";
            this.rdChiHienNV.Size = new System.Drawing.Size(140, 20);
            this.rdChiHienNV.TabIndex = 15;
            this.rdChiHienNV.TabStop = true;
            this.rdChiHienNV.Tag = "NV";
            this.rdChiHienNV.Text = "Chỉ hiện Nhân Viên";
            this.rdChiHienNV.UseVisualStyleBackColor = true;
            this.rdChiHienNV.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // rdChiHienKH
            // 
            this.rdChiHienKH.AutoSize = true;
            this.rdChiHienKH.Location = new System.Drawing.Point(571, 65);
            this.rdChiHienKH.Name = "rdChiHienKH";
            this.rdChiHienKH.Size = new System.Drawing.Size(151, 20);
            this.rdChiHienKH.TabIndex = 16;
            this.rdChiHienKH.TabStop = true;
            this.rdChiHienKH.Tag = "KH";
            this.rdChiHienKH.Text = "Chỉ hiện Khách Hàng";
            this.rdChiHienKH.UseVisualStyleBackColor = true;
            this.rdChiHienKH.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // rdChiHienQL
            // 
            this.rdChiHienQL.AutoSize = true;
            this.rdChiHienQL.Location = new System.Drawing.Point(571, 34);
            this.rdChiHienQL.Name = "rdChiHienQL";
            this.rdChiHienQL.Size = new System.Drawing.Size(127, 20);
            this.rdChiHienQL.TabIndex = 17;
            this.rdChiHienQL.TabStop = true;
            this.rdChiHienQL.Tag = "QL";
            this.rdChiHienQL.Text = "Chỉ hiện Quan Lý";
            this.rdChiHienQL.UseVisualStyleBackColor = true;
            this.rdChiHienQL.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 522);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Tổng số Quản Lý";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 522);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Tỏng số Nhân Viên";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(504, 522);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Tổng số Khách Hàng";
            // 
            // txtTongQL
            // 
            this.txtTongQL.Location = new System.Drawing.Point(128, 519);
            this.txtTongQL.Name = "txtTongQL";
            this.txtTongQL.ReadOnly = true;
            this.txtTongQL.Size = new System.Drawing.Size(69, 22);
            this.txtTongQL.TabIndex = 21;
            // 
            // txtTongNV
            // 
            this.txtTongNV.Location = new System.Drawing.Point(389, 519);
            this.txtTongNV.Name = "txtTongNV";
            this.txtTongNV.ReadOnly = true;
            this.txtTongNV.Size = new System.Drawing.Size(69, 22);
            this.txtTongNV.TabIndex = 22;
            // 
            // txtTongKH
            // 
            this.txtTongKH.Location = new System.Drawing.Point(642, 519);
            this.txtTongKH.Name = "txtTongKH";
            this.txtTongKH.ReadOnly = true;
            this.txtTongKH.Size = new System.Drawing.Size(69, 22);
            this.txtTongKH.TabIndex = 23;
            // 
            // frmQuanLyNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 557);
            this.Controls.Add(this.txtTongKH);
            this.Controls.Add(this.txtTongNV);
            this.Controls.Add(this.txtTongQL);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rdChiHienQL);
            this.Controls.Add(this.rdChiHienKH);
            this.Controls.Add(this.rdChiHienNV);
            this.Controls.Add(this.rdHienThiToanBo);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnXemHoaDon);
            this.Controls.Add(this.txtMaNguoiDung);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvNguoiDung);
            this.Controls.Add(this.cbbVaiTro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTenNguoiDung);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmQuanLyNguoiDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý người dùng";
            this.Load += new System.EventHandler(this.frmQuanLyNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenNguoiDung;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbVaiTro;
        private System.Windows.Forms.DataGridView dgvNguoiDung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaNguoiDung;
        private System.Windows.Forms.Button btnXemHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.RadioButton rdHienThiToanBo;
        private System.Windows.Forms.RadioButton rdChiHienNV;
        private System.Windows.Forms.RadioButton rdChiHienKH;
        private System.Windows.Forms.RadioButton rdChiHienQL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTongQL;
        private System.Windows.Forms.TextBox txtTongNV;
        private System.Windows.Forms.TextBox txtTongKH;
    }
}