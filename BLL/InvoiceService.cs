using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InvoiceService : AbstractService
    {
        public void Checkout(Invoice invoice, List<InvoiceDetail> details)
        {
            if(details.Count == 0)
            {
                throw new Exception("Không có sản phẩm trong giỏ");
            }
            if(invoice.TotalPrice <= 0)
            {
                throw new Exception("Không thể thanh toán");
            }
            invoice.CreatedAt = DateTime.Now;
            InvoiceDAL.AddInvoice(invoice);
            Invoice lastestInvoice = InvoiceDAL.GetLastestInvoice();
            for(int i = 0; i < details.Count; i++)
            {
                details[i].InvoiceId = lastestInvoice.InvoiceId;
                lastestInvoice.InvoiceDetails.Add(details[i]);
            }
            InvoiceDetailDAL.AddInvoiceDetailToInvoice(details);
        }

    }
}
