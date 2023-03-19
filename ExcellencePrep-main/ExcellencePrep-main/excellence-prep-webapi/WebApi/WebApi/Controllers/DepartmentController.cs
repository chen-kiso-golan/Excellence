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
                DepartmentList = MainManager.Instance.DepartmentManager.getAllDepartmentFromDB();
                return DepartmentList;
            }
    
            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

            return DepartmentList;
        }




        
        [HttpPost("addDepartmentToDB")]
        public JsonResult addDepartmentToDB([FromBody] Department department)
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ DepartmentController \ addDepartmentToDB ran Successfully - ");
                MainManager.Instance.DepartmentManager.addDepartmentToDB(department);
                return new JsonResult("OK");
            }

            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

            return new JsonResult("Problem");
        }

        



        [HttpDelete("deleteDepartment/{id}")]
        public JsonResult deleteDepartmentFromDB(int id)
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ DepartmentController \ deleteDepartmentFromDB ran Successfully - ");
                MainManager.Instance.DepartmentManager.deleteDepartmentFromDB(id);
                return new JsonResult("OK");
            }

            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return new JsonResult("Problem");
        }







        [HttpPost("UpdateDepartment")]
        public JsonResult updateDepartment([FromBody] Department department)
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ DepartmentController \ updateDepartment ran Successfully - ");
                MainManager.Instance.DepartmentManager.updateDepartment(department);
                return new JsonResult("OK");
            }

            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return new JsonResult("Problem");
        }


    }
}
