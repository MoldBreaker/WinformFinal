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
    public partial class frmQuanLyNguoiDung : Form
    {
        private RoleService roleService = new RoleService();
        private UserService userService = new UserService();
        public frmQuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            try
            {
                List<Role> roles = roleService.GetRoles();
                List<User> users = userService.GetAllUsers();

                FillComboBoxVaiTro(roles);
                BindDGVNguoiDung(users);
                rdHienThiToanBo.Checked = true;

                FIllAllCount(users);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AllCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            try
            {
                if (((RadioButton)sender).Checked)
                {
                    RadioButton rb = (RadioButton)sender;
                    List<User> users = new List<User>();
                    switch (rb.Tag.ToString())
                    {
                        case "KH":
                        case "NV":
                        case "QL":
                            users = userService.GetUsersByRoleID(rb.Tag.ToString());
                            break;
                        default:
                            users = userService.GetAllUsers();
                            break;
                    }
                    BindDGVNguoiDung(users);
                    FIllAllCount(users);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillComboBoxVaiTro(List<Role> roles)
        {
            cbbVaiTro.DataSource = roles;
            cbbVaiTro.DisplayMember = "RoleName";
            cbbVaiTro.ValueMember = "RoleId";
        }

        private void BindDGVNguoiDung(List<User> users)
        {
            dgvNguoiDung.Rows.Clear();
            for(int i=0;i<users.Count; i++)
            {
                int index = dgvNguoiDung.Rows.Add();
                dgvNguoiDung.Rows[index].Cells[0].Value = users[i].UserId;
                dgvNguoiDung.Rows[index].Cells[1].Value = users[i].Username;
                dgvNguoiDung.Rows[index].Cells[2].Value = users[i].Email;
                dgvNguoiDung.Rows[index].Cells[3].Value = users[i].SDT;
                dgvNguoiDung.Rows[index].Cells[4].Value = users[i].Role.RoleName;
                dgvNguoiDung.Rows[index].Cells[5].Value = users[i].RoleId;
            }
        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txtMaNguoiDung.Text = dgvNguoiDung.Rows[index].Cells[0].Value.ToString();
            txtTenNguoiDung.Text = dgvNguoiDung.Rows[index].Cells[1].Value.ToString();
            txtEmail.Text = dgvNguoiDung.Rows[index].Cells[2].Value.ToString();
            txtSDT.Text = dgvNguoiDung.Rows[index].Cells[3].Value.ToString();
            cbbVaiTro.SelectedValue = dgvNguoiDung.Rows[index].Cells[5].Value;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string userIDStr = txtMaNguoiDung.Text;
                if(userIDStr.Trim().Length == 0)
                {
                    throw new Exception("Bạn chưa chọn người dùng nào");
                }
                int UserID = int.Parse(userIDStr);
                string RoleID = cbbVaiTro.SelectedValue.ToString();
                userService.UpdateUserRole(UserID, RoleID);
                frmQuanLyNguoiDung_Load(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FIllAllCount(List<User> users)
        {
            int countQL = 0;
            int countNV = 0;
            int countKH = 0;
            for(int i=0;i<users.Count; i++)
            {
                if (users[i].RoleId == "KH")
                {
                    countKH++;
                } else if (users[i].RoleId == "NV")
                {
                    countNV++;
                } else
                {
                    countQL++;
                }
            }
            txtTongKH.Text = countKH.ToString();
            txtTongNV.Text = countNV.ToString();
            txtTongQL.Text = countQL.ToString();
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = int.Parse(txtMaNguoiDung.Text);
                User user = userService.GetUserById(userId);
                if (user == null)
                {
                    throw new Exception("Không tồn tại người dùng này");
                }
                FrmLichSuDonHang frmLichSuDonHang = new FrmLichSuDonHang();
                frmLichSuDonHang.user = user;
                frmLichSuDonHang.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
