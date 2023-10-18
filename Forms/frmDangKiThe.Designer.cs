namespace Forms
{
    partial class frmDangKiThe
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
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.txtNguoiSoHuu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDangKyThe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMaThe
            // 
            this.txtMaThe.Location = new System.Drawing.Point(146, 31);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(172, 22);
            this.txtMaThe.TabIndex = 0;
            // 
            // txtNguoiSoHuu
            // 
            this.txtNguoiSoHuu.Location = new System.Drawing.Point(146, 79);
            this.txtNguoiSoHuu.Name = "txtNguoiSoHuu";
            this.txtNguoiSoHuu.ReadOnly = true;
            this.txtNguoiSoHuu.Size = new System.Drawing.Size(172, 22);
            this.txtNguoiSoHuu.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Số Thẻ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Người sở hữu";
            // 
            // btnDangKyThe
            // 
            this.btnDangKyThe.Location = new System.Drawing.Point(128, 136);
            this.btnDangKyThe.Name = "btnDangKyThe";
            this.btnDangKyThe.Size = new System.Drawing.Size(124, 46);
            this.btnDangKyThe.TabIndex = 4;
            this.btnDangKyThe.Text = "Đăng Ký Ngay";
            this.btnDangKyThe.UseVisualStyleBackColor = true;
            this.btnDangKyThe.Click += new System.EventHandler(this.btnDangKyThe_Click);
            // 
            // frmDangKiThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(374, 212);
            this.Controls.Add(this.btnDangKyThe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNguoiSoHuu);
            this.Controls.Add(this.txtMaThe);
            this.Name = "frmDangKiThe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Ký Thẻ";
            this.Load += new System.EventHandler(this.frmDangKiThe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.TextBox txtNguoiSoHuu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDangKyThe;
    }
}