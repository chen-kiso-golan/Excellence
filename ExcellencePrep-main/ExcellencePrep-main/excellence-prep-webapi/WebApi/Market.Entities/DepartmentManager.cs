using Market.Data.Sql;
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


    }
}
