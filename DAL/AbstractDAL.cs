using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AbstractDAL
    {
        protected DBContext context = new DBContext();
    }
}
