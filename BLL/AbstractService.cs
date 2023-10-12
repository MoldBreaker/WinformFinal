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
        protected ProductCategoryDAL ProductCategoryDAL = new ProductCategoryDAL();
        protected ProductDAL ProductDAL = new ProductDAL();
        protected TableDAL TableDAL = new TableDAL();
    }
}
