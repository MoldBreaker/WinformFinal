using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InvoiceDetailDAL : AbstractDAL
    {
        public void AddInvoiceDetail(InvoiceDetail detail)
        {
            context.InvoiceDetails.Add(detail);
            context.SaveChanges();
        }

        public List<InvoiceDetail> GetInvoiceDetailsByInvoiceId(int invoiceId)
        {
            return context.InvoiceDetails.Where(p => p.InvoiceId == invoiceId).ToList();
        }

        public List<InvoiceDetail> GetAllInvoicesDetail()
        {
            return context.InvoiceDetails.ToList();
        }

        public void AddInvoiceDetailToInvoice(List<InvoiceDetail> invoiceDetails)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    for(int i=0;i<invoiceDetails.Count;i++)
                    {
                        context.InvoiceDetails.Add(invoiceDetails[i]);
                    }
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
