using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL : AbstractDAL
    {
        public void Insert(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        throw new Exception($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
            }
        }

        public User GetUserByEmail(string email)
        {
            User user = context.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }
        public User GetUserByPhone(string phone)
        {
            User user = context.Users.FirstOrDefault(u => u.SDT == phone);
            return user;
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            User UpdateUser = context.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if(UpdateUser != null)
            {
                UpdateUser.Username = user.Username;
                UpdateUser.Password = user.Password;
                UpdateUser.SDT = user.SDT;
                UpdateUser.Email = user.Email;
                UpdateUser.RoleId = user.RoleId;
                context.SaveChanges();
            }
        }

        public User GetUserByID(int ID)
        {
            return context.Users.FirstOrDefault(u => u.UserId==ID);
        }

        public List<User> GetTopUsers()
        {
            return context.Users.OrderByDescending(u => u.Invoices.Sum(i => i.AfterDiscount)).ToList();
        }
    }
}
