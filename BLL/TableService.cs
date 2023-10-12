using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TableService : AbstractService
    {
        public List<Table> GetAllTables()
        {
            return TableDAL.GetAllTables();
        }

        public void AddTable(Table table)
        {
            if(table.TableName.Trim().Length == 0)
            {
                throw new Exception("Tên bàn không được để trống");
            }
            TableDAL.AddTable(table);
        }

        public void UpdateTable(Table table)
        {
            if (table.TableName.Trim().Length == 0)
            {
                throw new Exception("Tên bàn không được để trống");
            }

            Table updateTable = TableDAL.GetTableById(table.TableId);
            if(updateTable == null)
            {
                throw new Exception("Không tìm thấy bàn này");
            }
            TableDAL.UpdateTable(table);
        }

        public void DeleteTable(int id)
        {
            Table deleteTable = TableDAL.GetTableById(id);
            if(deleteTable == null)
            {
                throw new Exception("Không tìm thấy bàn này");
            }
            TableDAL.DeleteTable(deleteTable);
        }
    }
}
