namespace Forms
{
    partial class frmThongTinThe
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.txtNguoiSoHuu = new System.Windows.Forms.TextBox();
            this.txtDiem = new System.Windows.Forms.TextBox();
            this.txtXepHang = new System.Windows.Forms.TextBox();
            this.btnHuyThe = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Thẻ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Người sở hữu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Điểm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rank";
            // 
            // txtMaThe
            // 
            this.txtMaThe.Location = new System.Drawing.Point(143, 39);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.ReadOnly = true;
            this.txtMaThe.Size = new System.Drawing.Size(147, 22);
            this.txtMaThe.TabIndex = 4;
            // 
            // txtNguoiSoHuu
            // 
            this.txtNguoiSoHuu.Location = new System.Drawing.Point(143, 76);
            this.txtNguoiSoHuu.Name = "txtNguoiSoHuu";
            this.txtNguoiSoHuu.ReadOnly = true;
            this.txtNguoiSoHuu.Size = new System.Drawing.Size(147, 22);
            this.txtNguoiSoHuu.TabIndex = 5;
            // 
            // txtDiem
            // 
            this.txtDiem.Location = new System.Drawing.Point(143, 116);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.ReadOnly = true;
            this.txtDiem.Size = new System.Drawing.Size(147, 22);
            this.txtDiem.TabIndex = 6;
            // 
            // txtXepHang
            // 
            this.txtXepHang.Location = new System.Drawing.Point(143, 150);
            this.txtXepHang.Name = "txtXepHang";
            this.txtXepHang.ReadOnly = true;
            this.txtXepHang.Size = new System.Drawing.Size(147, 22);
            this.txtXepHang.TabIndex = 7;
            // 
            // btnHuyThe
            // 
            this.btnHuyThe.Location = new System.Drawing.Point(178, 196);
            this.btnHuyThe.Name = "btnHuyThe";
            this.btnHuyThe.Size = new System.Drawing.Size(112, 44);
            this.btnHuyThe.TabIndex = 8;
            this.btnHuyThe.Text = "Huỷ Thẻ";
            this.btnHuyThe.UseVisualStyleBackColor = true;
            this.btnHuyThe.Click += new System.EventHandler(this.btnHuyThe_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(33, 196);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(112, 44);
            this.btnDong.TabIndex = 9;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmThongTinThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(337, 269);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnHuyThe);
            this.Controls.Add(this.txtXepHang);
            this.Controls.Add(this.txtDiem);
            this.Controls.Add(this.txtNguoiSoHuu);
            this.Controls.Add(this.txtMaThe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmThongTinThe";
            this.Text = "Thông Tin Thẻ";
            this.Load += new System.EventHandler(this.frmThongTinThe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.TextBox txtNguoiSoHuu;
        private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.TextBox txtXepHang;
        private System.Windows.Forms.Button btnHuyThe;
        private System.Windows.Forms.Button btnDong;
    }
}