using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InvoiceDAL : AbstractDAL
    {
        public void AddInvoice(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
        }

        public Invoice GetLastestInvoice()
        {
            var latestInvoice = context.Invoices.OrderByDescending(i => i.CreatedAt).FirstOrDefault();
            return latestInvoice;
        }

        public List<Invoice> GetAllInvoices()
        {
            return context.Invoices.ToList();
        }

        public Invoice GetInvoiceById(int id)
        {
            return context.Invoices.FirstOrDefault(p => p.InvoiceId == id);
        }

        public List<Invoice> GetInvoiceByUserId(int userId)
        {
            return context.Invoices.Where(p => p.UserId == userId).ToList();
        }


    }
}
