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
            this.trởVềToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chThongKeTheoThang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTopSanPham = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chDoanhThuTheoTuan)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chThongKeTheoThang)).BeginInit();
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trởVềToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1153, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trởVềToolStripMenuItem
            // 
            this.trởVềToolStripMenuItem.Name = "trởVềToolStripMenuItem";
            this.trởVềToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.trởVềToolStripMenuItem.Text = "Trở Về";
            this.trởVềToolStripMenuItem.Click += new System.EventHandler(this.trởVềToolStripMenuItem_Click);
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
            this.label1.Size = new System.Drawing.Size(421, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Top Sản Phẩm Bán Chạy Nhất";
            // 
            // lbTopSanPham
            // 
            this.lbTopSanPham.AutoSize = true;
            this.lbTopSanPham.Location = new System.Drawing.Point(81, 527);
            this.lbTopSanPham.Name = "lbTopSanPham";
            this.lbTopSanPham.Size = new System.Drawing.Size(146, 16);
            this.lbTopSanPham.TabIndex = 5;
            this.lbTopSanPham.Text = "Thông tin top sản phẩm";
            // 
            // frmQuanLyThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1153, 776);
            this.Controls.Add(this.lbTopSanPham);
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
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.frmQuanLyThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chDoanhThuTheoTuan)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chThongKeTheoThang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chDoanhThuTheoTuan;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem trởVềToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chThongKeTheoThang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTopSanPham;
    }
}