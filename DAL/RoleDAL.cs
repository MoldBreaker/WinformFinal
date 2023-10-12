using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoleDAL : AbstractDAL
    {
        public List<Role> GetRoles()
        {
            return context.Roles.ToList();
        }

        public Role GetRoleByID(string ID)
        {
            return context.Roles.FirstOrDefault(r => r.RoleId == ID);
        }
    }
}
