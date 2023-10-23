
namespace Forms
{
    partial class frmTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTable));
            this.flpBan = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFinishedUsing = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTableID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpBan
            // 
            this.flpBan.AutoScroll = true;
            this.flpBan.Location = new System.Drawing.Point(12, 12);
            this.flpBan.Name = "flpBan";
            this.flpBan.Size = new System.Drawing.Size(516, 333);
            this.flpBan.TabIndex = 0;
            this.flpBan.Paint += new System.Windows.Forms.PaintEventHandler(this.flpBan_Paint);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.btnFinishedUsing);
            this.panel1.Controls.Add(this.btnChoose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTableID);
            this.panel1.Location = new System.Drawing.Point(12, 351);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 82);
            this.panel1.TabIndex = 1;
            // 
            // btnFinishedUsing
            // 
            this.btnFinishedUsing.Location = new System.Drawing.Point(363, 31);
            this.btnFinishedUsing.Name = "btnFinishedUsing";
            this.btnFinishedUsing.Size = new System.Drawing.Size(75, 23);
            this.btnFinishedUsing.TabIndex = 9;
            this.btnFinishedUsing.Text = "Bỏ chọn";
            this.btnFinishedUsing.UseVisualStyleBackColor = true;
            this.btnFinishedUsing.Click += new System.EventHandler(this.btnFinishedUsing_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChoose.Location = new System.Drawing.Point(260, 32);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 8;
            this.btnChoose.Text = "Chọn";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã bàn";
            // 
            // txtTableID
            // 
            this.txtTableID.Location = new System.Drawing.Point(134, 32);
            this.txtTableID.Name = "txtTableID";
            this.txtTableID.ReadOnly = true;
            this.txtTableID.Size = new System.Drawing.Size(100, 22);
            this.txtTableID.TabIndex = 0;
            // 
            // frmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(539, 440);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpBan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bàn";
            this.Load += new System.EventHandler(this.frmTable_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTableID;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button btnFinishedUsing;
    }
}