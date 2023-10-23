using BLL;
using DAL.Models;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class frmTable : Form
    {
        private TableService tableService = new TableService();
        public Table selectedTable;
        public frmTable()
        {
            InitializeComponent();
        }

        private void frmTable_Load(object sender, EventArgs e)
        {
            List<Table> tables = tableService.GetAllTables();
            FillFLPTables(tables);
        }

        private void FillFLPTables(List<Table> tables)
        {
            flpBan.Controls.Clear();
            for(int i = 0; i < tables.Count; i++)
            {
                Panel panel = new System.Windows.Forms.Panel();
                PictureBox pictureBox = new System.Windows.Forms.PictureBox();
                panel.Controls.Add(pictureBox);
                panel.Location = new System.Drawing.Point(3, 3);
                panel.Name = "panel" + tables[i].TableId.ToString();
                panel.Size = new System.Drawing.Size(82, 80);
                panel.Click += new System.EventHandler(this.table_Click);
                if (tables[i].Status == 0)
                {
                    pictureBox.Image = global::Forms.Properties.Resources.coffee_cup_available;
                }
                else if (tables[i].Status == 1)
                {
                    pictureBox.Image = global::Forms.Properties.Resources.coffee_cup_taken;
                }
                else if (tables[i].Status == 2)
                {
                    pictureBox.Image = global::Forms.Properties.Resources.coffee_cup_using;
                }
                pictureBox.Location = new System.Drawing.Point(4, 4);
                pictureBox.Name = "PictureBox" + tables[i].TableId.ToString();
                pictureBox.Size = new System.Drawing.Size(70, 50);
                pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox.TabIndex = 0;
                pictureBox.TabStop = false;
                pictureBox.Click += new System.EventHandler(this.table_Click);
                pictureBox.Tag = tables[i];
                panel.Tag = tables[i];
                flpBan.Controls.Add(panel);
            }
        }
        private void table_Click(object sender, EventArgs e)
        {
            try
            {
                Panel panel = (Panel)sender;
                selectedTable = (Table)panel.Tag;
                txtTableID.Text = selectedTable.TableId.ToString();
            }
            catch 
            {
                PictureBox pictureBox = (PictureBox)sender;
                selectedTable = (Table)pictureBox.Tag;
                txtTableID.Text = selectedTable.TableId.ToString();
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            Table table = tableService.GetTableById(selectedTable.TableId);
            if(table.Status == 0)
            {
                tableService.UpdateTableStatus(selectedTable.TableId, 2);
                foreach(Panel panel in flpBan.Controls)
                {
                    Table panelTable = (Table)panel.Tag;
                    if (panelTable.TableId == table.TableId)
                    {
                        PictureBox pictureBox = (PictureBox)panel.Controls[0];
                        pictureBox.Image = global::Forms.Properties.Resources.coffee_cup_using;
                    }
                }
            }
            else if(table.Status == 1)
            {
                MessageBox.Show("Bàn này đã được đặt");
            }
            else if(table.Status == 2)
            {
                MessageBox.Show("Bàn này đang được sử dụng");
            }
        }

        private void btnFinishedUsing_Click(object sender, EventArgs e)
        {
            Table table = tableService.GetTableById(selectedTable.TableId);
            if (table.Status == 2)
            {
                tableService.UpdateTableStatus(selectedTable.TableId, 0);
                foreach (Panel panel in flpBan.Controls)
                {
                    Table panelTable = (Table)panel.Tag;
                    if (panelTable.TableId == table.TableId)
                    {
                        PictureBox pictureBox = (PictureBox)panel.Controls[0];
                        pictureBox.Image = global::Forms.Properties.Resources.coffee_cup_available;
                    }
                }
            }
            else if (table.Status == 1 || table.Status == 0)
            {
                MessageBox.Show("Bàn này chưa được sử dụng");
            }
            txtTableID.Text = "";
        }

        public string GetTextBoxValue()
        {
            return txtTableID.Text;
        }

        
    }
}
