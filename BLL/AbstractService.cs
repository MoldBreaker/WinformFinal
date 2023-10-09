using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AbstractService
    {
        protected RoleDAL RoleDAL = new RoleDAL();
        protected UserDAL UserDAL = new UserDAL();
    }
}
