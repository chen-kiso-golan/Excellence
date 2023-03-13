using Market.Dal_2;
using Market.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Utilities_Log;

namespace Market.Data.Sql_2
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



        public void addDepartmentToDB(Department department)
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ DepartmentDS \ addDepartmentToDB ran Successfully - ");
                string SQLquery = "insert into Departments values ('" + department.Name + "','" + department.Description + "')";
                SqlDB.WriteToDB(SQLquery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }



        
        public void deleteDepartmentFromDB(int id)
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ DepartmentDS \ deleteDepartmentFromDB ran Successfully - ");
                string SQLquery = "delete from Departments where id = " + id;
                SqlDB.WriteToDB(SQLquery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }




        public void updateDepartment(Department department)
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ DepartmentDS \ updateDepartment ran Successfully - ");
                string SQLquery = "update Departments set name = '" + department.Name + "', description = '" + department.Description + "' where id = " + department.Id.ToString();
                SqlDB.WriteToDB(SQLquery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
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
