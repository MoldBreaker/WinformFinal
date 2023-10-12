using BLL;
using DAL.Models;
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
    public partial class frmQuanLyBan : Form
    {
        private TableService tableService = new TableService();
        public frmQuanLyBan()
        {
            InitializeComponent();
        }

        private void frmQuanLyBan_Load(object sender, EventArgs e)
        {
            List<Table> tables = tableService.GetAllTables();

            BindToFLPBan(tables);
        }

        private void BindToFLPBan(List<Table> tables)
        {
            flpBan.Controls.Clear();
            foreach (Table table in tables)
            {
                Button button = new System.Windows.Forms.Button();
                button.Location = new System.Drawing.Point(3, 3);
                button.Name = table.TableId.ToString();
                button.Size = new System.Drawing.Size(91, 73);
                button.TabIndex = 0;
                button.Text = table.TableName;
                button.UseVisualStyleBackColor = true;
                button.Click += new System.EventHandler(this.OnClick);
                button.Tag = table;

                flpBan.Controls.Add(button);
            }
        }

        private void OnClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Table table = (Table)button.Tag;
            txtMaBan.Text = table.TableId.ToString();
            txtTenBan.Text = table.TableName;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string TableName = txtTenBan.Text;
                Table table = new Table();
                table.TableName = TableName;
                table.Status = 0;
                tableService.AddTable(table);
                frmQuanLyBan_Load(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string TableIdStr = txtMaBan.Text;
                string TableName = txtTenBan.Text;
                int TableId;
                if(!int.TryParse(TableIdStr, out TableId))
                {
                    throw new Exception("Mã không hợp lệ");
                }

                Table table = new Table();
                table.TableName = TableName;
                table.Status = 0;
                table.TableId = TableId;
                tableService.UpdateTable(table);
                frmQuanLyBan_Load(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                } else
                {
                    string TableIdStr = txtMaBan.Text;
                    int TableId;
                    if (!int.TryParse(TableIdStr, out TableId))
                    {
                        throw new Exception("Mã không hợp lệ");
                    }
                    tableService.DeleteTable(TableId);
                    frmQuanLyBan_Load(sender, e);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
