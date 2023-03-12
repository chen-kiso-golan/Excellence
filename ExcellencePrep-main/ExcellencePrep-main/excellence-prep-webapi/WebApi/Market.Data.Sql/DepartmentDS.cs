using Market.Dal;
using Market.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Utilities_Log;

namespace Market.Data.Sql
{
    public class DepartmentDS : BaseDataSql
    {
        BaseDAL BaseDAL;
        public DepartmentDS(LogManager log) : base(log)
        {
            BaseDAL = new BaseDAL(Log);
        }

        public List<Department> ReadAllDepartmentFromDB()
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ DepartmentDS \ ReadAllDepartmentFromDB ran Successfully - ");
                string SQLquery = "select * from Departments";
                DataTable dataTable = new DataTable();
                dataTable = SqlDB.ReadFormDB(SQLquery);
                return ConvertDataTableToList(dataTable);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return new List<Department>();
        }




        //-------------- Convert DataTable To List
        public List<Department> ConvertDataTableToList(DataTable dataTable)
        {
            List<Department> list = new List<Department>();
            foreach (DataRow row in dataTable.Rows)
            {
                Department Department = new Department();
                Department.Id = (int)row["id"];
                Department.Name = (string)row["name"];
                Department.Description = (string)row["description"];
                list.Add(Department);
            }
            return list;
        }
    }
}
