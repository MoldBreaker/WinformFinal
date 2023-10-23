using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService : AbstractService
    {
        public List<User> GetAllUsers()
        {
            return UserDAL.GetAllUsers();
        }

        public List<User> GetUsersByRoleID(string RoleID)
        {
            return UserDAL.GetAllUsers().Where(u => u.RoleId == RoleID).ToList();
        }

        public void UpdateUserRole(int UserID, string RoleID)
        {
            Role role = RoleDAL.GetRoleByID(RoleID);
            if(role == null)
            {
                throw new Exception("Không tồn tại role này");
            }

            User user = UserDAL.GetUserByID(UserID);
            if(user == null)
            {
                throw new Exception("Không tồn tại người dùng này");
            }

            user.RoleId = RoleID;
            UserDAL.UpdateUser(user);
        }

        public void Register(User user)
        {
             if(user.Username.Trim().Length == 0)
            {
                throw new Exception("Username không được để trống");
            }

            if(user.Password.Trim().Length == 0)
            {
                throw new Exception("Mật khẩu không được để trống");
            }else if (!Validator.IsValidPassword(user.Password))
            {
                throw new Exception("Không đúng định dạng mật khẩu!");
            }

            if(user.Email.Trim().Length == 0)
            {
                throw new Exception("Email không được để trống");
            }

            if(user.SDT.Trim().Length == 0)
            {
                throw new Exception("SDT không được để trống");
            }

            if(!Validator.IsValidEmail(user.Email))
            {
                throw new Exception("Email không hợp lệ");
            }

            if(!Validator.IsValidPhone(user.SDT))
            {
                throw new Exception("SDT không hợp lệ");
            }

            User getUserByEmail = UserDAL.GetUserByEmail(user.Email);
            if(getUserByEmail != null)
            {
                throw new Exception("Email đã được đăng kí");
            }
            User getUserByPhone = UserDAL.GetUserByPhone(user.SDT);
            if(getUserByPhone != null)
            {
                throw new Exception("SDT đã được đăng kí");
            }

            user.RoleId = "KH";
            UserDAL.Insert(user);
        }

        public User Login(User user)
        {
            if (user.Email.Trim().Length == 0)
            {
                throw new Exception("Email không được để trống");
            }

            if(user.Password.Trim().Length == 0)
            {
                throw new Exception("Mật khảu không được để trống");
            }

            if (!Validator.IsValidEmail(user.Email))
            {
                throw new Exception("Email không hợp lệ");
            }

            User getUserByEmail = UserDAL.GetUserByEmail(user.Email);

            if(getUserByEmail == null) {
                throw new Exception("Email này chưa được đăng kí");
            }

            if(user.Password != getUserByEmail.Password)
            {
                throw new Exception("Mật khẩu không khớp");
            }

            return getUserByEmail;
        }

        public void ChangePassword(int UserID, string OldPassword, string NewPassword, string CNewPassword)
        {
            if(NewPassword != CNewPassword)
            {
                throw new Exception("Mật khẩu mới không trùng nhau");
            }
            if(!Validator.IsValidPassword(OldPassword))
            {
                throw new Exception("Mật khẩu cũ không đúng định dạng");
            }
            if (!Validator.IsValidPassword(NewPassword))
            {
                throw new Exception("Mật khẩu mới không đúng định dạng");
            }
            User user = UserDAL.GetUserByID(UserID);
            if (user == null)
            {
                throw new Exception("Không tìm thấy user này");
            }
            if(OldPassword != user.Password)
            {
                throw new Exception("Mật khẩu cũ không khớp");
            }
            user.Password = NewPassword;
            UserDAL.UpdateUser(user);
        }

        public User GetUserById(int userId)
        {
            return UserDAL.GetUserByID(userId);
        }

        public List<User> GetTopUsers()
        {
            return UserDAL.GetTopUsers().Where(u => u.RoleId == "KH").ToList();
        }

        public User GetUserByPhone(string phoneNumber)
        {
           
            return UserDAL.GetUserByPhone(phoneNumber);
        }
    }
}
