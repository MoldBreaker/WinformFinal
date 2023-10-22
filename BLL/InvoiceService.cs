using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
            }
            InvoiceDetailDAL.AddInvoiceDetailToInvoice(details);

            //Cập nhật points cho card nếu có
            Card card = CardDAL.GetCardByUserId(invoice.UserId);
            if(card != null)
            {
                card.Point += (int)invoice.AfterDiscount / 1000;
                CardService cardService = new CardService();
                cardService.UpdatePoints(card);
            }
        }
        public List<Invoice> GetInvoicesByUserID(int userID)
        {
            return InvoiceDAL.GetInvoiceByUserId(userID).OrderByDescending(i => i.CreatedAt).ToList();
        }
        public Invoice GetInvoiceById(int id)
        {
            return InvoiceDAL.GetInvoiceById(id);
        }

        public List<Invoice> GetAllInvoices()
        {
            return InvoiceDAL.GetAllInvoices().OrderByDescending(i => i.CreatedAt).ToList();
        }

        public List<Invoice> GetInvoicesByDate(DateTime today)
        {
            return InvoiceDAL.GetInvoicesByDate(today).OrderByDescending(i => i.CreatedAt).ToList();
        }

        public double GetInvoicesByDayOfWeek(DateTime time)
        {
            DateTime monday = time;
            DateTime sunday = time;
            while (monday.DayOfWeek != DayOfWeek.Monday)
            {
                monday = monday.AddDays(-1);
            }
            while (sunday.DayOfWeek != DayOfWeek.Sunday)
            {
                sunday = sunday.AddDays(1);
            }
            List<Invoice> invoices = InvoiceDAL.GetAllInvoices()
                .Where(i => i.CreatedAt >= monday && i.CreatedAt <= sunday)
                .OrderByDescending(i => i.CreatedAt)
                .ToList();

            return invoices.Sum(i => i.AfterDiscount);
        }

        public double GetTotalRevenueByMonth(DateTime time)
        {
            DateTime firstDayOfMonth = new DateTime(time.Year, time.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            List<Invoice> invoices = InvoiceDAL.GetAllInvoices()
                .Where(i => i.CreatedAt >= firstDayOfMonth && i.CreatedAt <= lastDayOfMonth)
                .OrderByDescending(i => i.CreatedAt)
                .ToList();

            double totalRevenue = invoices.Sum(i => i.AfterDiscount);
            return totalRevenue;
        }
    }
}
