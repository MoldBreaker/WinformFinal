using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL
{   

    public class InvoiceDetailService : AbstractService
    {
        public List<InvoiceDetail> GetInvoiceDetailsByInvoiceID(int invoiceID)
        {
            return InvoiceDetailDAL.GetInvoiceDetailsByInvoiceId(invoiceID);
        }

    }

}
