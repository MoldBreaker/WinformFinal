﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService : AbstractService
    {
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
    }
}
