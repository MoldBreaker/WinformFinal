using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TableDAL : AbstractDAL
    {
        public List<Table> GetAllTables()
        {
            return context.Tables.ToList();
        }

        public void AddTable(Table table)
        {
            context.Tables.Add(table);
            context.SaveChanges();
        }

        public void UpdateTable(Table table)
        {
            Table updateTable = context.Tables.FirstOrDefault(t => t.TableId == table.TableId);
            if(updateTable != null)
            {
                updateTable.TableName = table.TableName;
                updateTable.Status = table.Status;
            }
        }

        public void DeleteTable(Table table) { 
            context.Tables.Remove(table);
            context.SaveChanges();
        }

        public Table GetTableById(int tableId)
        {
            return context.Tables.FirstOrDefault(t => t.TableId == tableId);
        }
        public void UpdateTableStatus(int id, int status)
        {
            Table updateTable = context.Tables.FirstOrDefault(t => t.TableId == id);
            if (updateTable != null)
            {
                updateTable.Status = status;
            }
            context.SaveChanges();
        }
    }
}
