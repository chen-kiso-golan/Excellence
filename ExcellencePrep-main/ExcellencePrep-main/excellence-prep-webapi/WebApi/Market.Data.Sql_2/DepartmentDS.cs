using Market.Dal;
using Market.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;
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

        public List<Department> getAllDepartmentFromDB()
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ DepartmentDS \ getAllDepartmentFromDB ran Successfully - ");
                string SQLquery = "EXEC getAllDepartmentFromDB";
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



        public JsonResult addDepartmentToDB(Department department)
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ DepartmentDS \ addDepartmentToDB ran Successfully - ");
                string SQLquery = "EXEC addDepartmentToDB @name='" + department.Name + "',@description='" + department.Description + "'";
                SqlDB.WriteToDB(SQLquery);
                return new JsonResult();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return new JsonResult();
        }




        public JsonResult deleteDepartmentFromDB(int id)
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ DepartmentDS \ deleteDepartmentFromDB ran Successfully - ");
                string SQLquery = "EXEC deleteDepartmentFromDB @id=" + id;
                SqlDB.WriteToDB(SQLquery);
                return new JsonResult();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return new JsonResult();
        }




        public JsonResult updateDepartment(Department department)
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ DepartmentDS \ updateDepartment ran Successfully - ");
                string SQLquery = "EXEC updateDepartment @name = '" + department.Name + "', @description = '" + department.Description + "', @id = " + department.Id;
                SqlDB.WriteToDB(SQLquery);
                return new JsonResult();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return new JsonResult();
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
