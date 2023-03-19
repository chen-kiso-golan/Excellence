using Market.Data.Sql;
using Market.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Utilities_Log;

namespace Market.Entities
{
    public class DepartmentManager : BaseEntity
    {
        BaseDataSql BaseDataSql;
        public DepartmentManager(LogManager log) : base(log)
        {
            BaseDataSql = new BaseDataSql(Log);
        }



        public List<Department> DepartmentTable = new List<Department>();
        public List<Department> getAllDepartmentFromDB()
        {
            try
            {
                Log.LogEvent(@"Entities \ DepartmentManager \ getAllDepartmentFromDB ran Successfully - ");
                DepartmentTable.Clear();
                DepartmentDS departmentDS = new DepartmentDS(Log);
                return DepartmentTable = departmentDS.getAllDepartmentFromDB();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return DepartmentTable;
        }



        public JsonResult addDepartmentToDB(Department department)
        {
            try
            {
                Log.LogEvent(@"Entities \ DepartmentManager \ addDepartmentToDB ran Successfully - ");
                DepartmentDS departmentDS = new DepartmentDS(Log);
                departmentDS.addDepartmentToDB(department);
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
                Log.LogEvent(@"Entities \ DepartmentManager \ deleteDepartmentFromDB ran Successfully - ");
                DepartmentDS departmentDS = new DepartmentDS(Log);
                departmentDS.deleteDepartmentFromDB(id);
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
                Log.LogEvent(@"Entities \ DepartmentManager \ updateDepartment ran Successfully - ");
                DepartmentDS departmentDS = new DepartmentDS(Log);
                departmentDS.updateDepartment(department);
                return new JsonResult();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return new JsonResult();
        }
    }
}
