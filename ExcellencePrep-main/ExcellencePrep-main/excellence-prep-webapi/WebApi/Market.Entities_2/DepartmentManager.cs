using Market.Data.Sql_2;
using Market.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<Department> ShowAllDepartmentFromDB()
        {
            try
            {
                Log.LogEvent(@"Entities \ DepartmentManager \ ShowAllDepartmentFromDB ran Successfully - ");
                DepartmentTable.Clear();
                DepartmentDS departmentDS = new DepartmentDS(Log);
                return DepartmentTable = departmentDS.ReadAllDepartmentFromDB();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return DepartmentTable;
        }



        public void addDepartmentToDB(Department department)
        {
            try
            {
                Log.LogEvent(@"Entities \ DepartmentManager \ addDepartmentToDB ran Successfully - ");
                DepartmentDS departmentDS = new DepartmentDS(Log);
                departmentDS.addDepartmentToDB(department);
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
                Log.LogEvent(@"Entities \ DepartmentManager \ deleteDepartmentFromDB ran Successfully - ");
                DepartmentDS departmentDS = new DepartmentDS(Log);
                departmentDS.deleteDepartmentFromDB(id);
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
                Log.LogEvent(@"Entities \ DepartmentManager \ updateDepartment ran Successfully - ");
                DepartmentDS departmentDS = new DepartmentDS(Log);
                departmentDS.updateDepartment(department);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }
    }
}
