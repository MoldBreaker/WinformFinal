namespace Forms
{
    partial class frmQuanLyThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyThongKe));
            this.chDoanhThuTheoTuan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chThongKeTheoThang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTopSellers = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTopUsers = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chDoanhThuTheoTuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chThongKeTheoThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSellers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // chDoanhThuTheoTuan
            // 
            this.chDoanhThuTheoTuan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            chartArea1.Name = "ChartArea1";
            this.chDoanhThuTheoTuan.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chDoanhThuTheoTuan.Legends.Add(legend1);
            this.chDoanhThuTheoTuan.Location = new System.Drawing.Point(0, 33);
            this.chDoanhThuTheoTuan.Name = "chDoanhThuTheoTuan";
            this.chDoanhThuTheoTuan.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "DoanhThu";
            this.chDoanhThuTheoTuan.Series.Add(series1);
            this.chDoanhThuTheoTuan.Size = new System.Drawing.Size(589, 428);
            this.chDoanhThuTheoTuan.TabIndex = 0;
            this.chDoanhThuTheoTuan.Text = "Thống Kê Danh Thu Theo Tuần";
            title1.Name = "Title1";
            title1.Text = "Doanh Thu Theo Tuần";
            this.chDoanhThuTheoTuan.Titles.Add(title1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1153, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chThongKeTheoThang
            // 
            this.chThongKeTheoThang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            chartArea2.Name = "ChartArea1";
            this.chThongKeTheoThang.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chThongKeTheoThang.Legends.Add(legend2);
            this.chThongKeTheoThang.Location = new System.Drawing.Point(613, 33);
            this.chThongKeTheoThang.Name = "chThongKeTheoThang";
            this.chThongKeTheoThang.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "DoanhThu";
            this.chThongKeTheoThang.Series.Add(series2);
            this.chThongKeTheoThang.Size = new System.Drawing.Size(540, 428);
            this.chThongKeTheoThang.TabIndex = 3;
            this.chThongKeTheoThang.Text = "Thống Kê Danh Thu Theo Tháng";
            title2.Name = "Title1";
            title2.Text = "Doanh Thu Theo Tháng";
            this.chThongKeTheoThang.Titles.Add(title2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Top 5 Sản Phẩm Bán Chạy Nhất";
            // 
            // dgvTopSellers
            // 
            this.dgvTopSellers.AllowUserToAddRows = false;
            this.dgvTopSellers.AllowUserToDeleteRows = false;
            this.dgvTopSellers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopSellers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopSellers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvTopSellers.Location = new System.Drawing.Point(66, 521);
            this.dgvTopSellers.Name = "dgvTopSellers";
            this.dgvTopSellers.ReadOnly = true;
            this.dgvTopSellers.RowHeadersWidth = 51;
            this.dgvTopSellers.RowTemplate.Height = 24;
            this.dgvTopSellers.Size = new System.Drawing.Size(344, 180);
            this.dgvTopSellers.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Hạng";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên Sản Phẩm";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // dgvTopUsers
            // 
            this.dgvTopUsers.AllowUserToAddRows = false;
            this.dgvTopUsers.AllowUserToDeleteRows = false;
            this.dgvTopUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column3,
            this.Column4});
            this.dgvTopUsers.Location = new System.Drawing.Point(582, 521);
            this.dgvTopUsers.Name = "dgvTopUsers";
            this.dgvTopUsers.ReadOnly = true;
            this.dgvTopUsers.RowHeadersWidth = 51;
            this.dgvTopUsers.RowTemplate.Height = 24;
            this.dgvTopUsers.Size = new System.Drawing.Size(542, 180);
            this.dgvTopUsers.TabIndex = 7;
            
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Hạng";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tên Người Dùng";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Số Tiền Đã Mua";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(694, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 36);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bảng Xếp Hạng";
            // 
            // frmQuanLyThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1153, 713);
            this.Controls.Add(this.dgvTopUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTopSellers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chThongKeTheoThang);
            this.Controls.Add(this.chDoanhThuTheoTuan);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmQuanLyThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng Xếp Hạng";
            this.Load += new System.EventHandler(this.frmQuanLyThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chDoanhThuTheoTuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chThongKeTheoThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSellers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chDoanhThuTheoTuan;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chThongKeTheoThang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTopSellers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridView dgvTopUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}