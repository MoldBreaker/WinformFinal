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
                Button btn = new System.Windows.Forms.Button();
                btn.Location = new System.Drawing.Point(3, 3);
                btn.Name = tables[i].TableId.ToString();
                btn.Size = new System.Drawing.Size(80, 50);
                btn.TabIndex = 0;
                if (tables[i].Status == 0)
                {
                    btn.Text = tables[i].TableName;
                }
                else if (tables[i].Status == 1)
                {
                    btn.Text = tables[i].TableName + "(đã đặt)";
                }
                else if (tables[i].Status == 2)
                {
                    btn.Text = tables[i].TableName + "(đang sử dụng)";
                }
                btn.UseVisualStyleBackColor = true;
                btn.Click += new System.EventHandler(this.table_Click);
                btn.Tag = tables[i];
                btn.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
                flpBan.Controls.Add(btn);
            }
        }
        private void table_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            selectedTable = (Table)btn.Tag;
            txtTableID.Text = selectedTable.TableId.ToString();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            Table table = tableService.GetTableById(selectedTable.TableId);
            if(table.Status == 0)
            {
                tableService.UpdateTableStatus(selectedTable.TableId, 2);
                foreach(Button btn in flpBan.Controls)
                {
                    Table btnTable = (Table)btn.Tag;
                    if (btnTable.TableId == table.TableId)
                    {
                        btn.Text = btnTable.TableName + "(đang sử dụng)";
                    }
                }
                MessageBox.Show("Chọn bàn thành công");
                this.Close();
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
                foreach (Button btn in flpBan.Controls)
                {
                    Table btnTable = (Table)btn.Tag;
                    if (btnTable.TableId == table.TableId)
                    {
                        btn.Text = btnTable.TableName;
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

        private void flpBan_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
