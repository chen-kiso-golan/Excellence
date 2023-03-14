using Market.Data.Sql;
using Market.Entities;
using Market.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using Utilities_Log;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Department")]
    public class DepartmentController : Controller 
    {


        public DepartmentController()
        {
        }





        public List<Department> DepartmentList;


        [HttpGet("getAllDepartmentFromDB")]
        public List<Department> getAllDepartmentFromDB()
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ DepartmentController \ getAllDepartmentFromDB ran Successfully - ");
                DepartmentList = new List<Department>();
                DepartmentList = MainManager.Instance.DepartmentManager.ShowAllDepartmentFromDB();
                return DepartmentList;
            }
    
            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

            return DepartmentList;
        }




        
        [HttpPost("addDepartmentToDB")]
        public void addDepartmentToDB([FromBody] Department department)
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ DepartmentController \ addDepartmentToDB ran Successfully - ");
                MainManager.Instance.DepartmentManager.addDepartmentToDB(department);
                //return new JsonResult("OK");
            }

            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

            //return new JsonResult("Problem");
        }

        



        [HttpDelete("deleteDepartment/{id}")]
        public void deleteDepartmentFromDB(int id)
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ DepartmentController \ deleteDepartmentFromDB ran Successfully - ");
                MainManager.Instance.DepartmentManager.deleteDepartmentFromDB(id);
            }

            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }







        [HttpPost("UpdateDepartment")]
        public void updateDepartment([FromBody] Department department)
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ DepartmentController \ updateDepartment ran Successfully - ");
                MainManager.Instance.DepartmentManager.updateDepartment(department);
            }

            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }


    }
}
