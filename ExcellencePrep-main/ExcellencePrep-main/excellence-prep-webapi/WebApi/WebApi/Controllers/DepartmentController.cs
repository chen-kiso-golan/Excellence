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

            //DepartmentList.Clear();
            //DepartmentList.Add(new Department() { Id = 1, Name = "Toys" });
            //DepartmentList.Add(new Department() { Id = 2, Name = "Food" });
            //DepartmentList.Add(new Department() { Id = 3, Name = "Drinks" });
            //DepartmentList.Add(new Department() { Id = 4, Name = "Snacks" });
        }

        public List<Department> DepartmentList;


        [HttpGet("getAllDepartmentFromDB")]
        public List<Department> getAllDepartmentFromDB()
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ DepartmentController ran Successfully - ");
                DepartmentList = new List<Department>();
                DepartmentList = MainManager.Instance.DepartmentManager.ShowAllDepartmentFromDB();
                return DepartmentList;
            }
    
            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

            return DepartmentList;
            //return new JsonResult(DepartmentList);
        }

        
        [HttpPost("addDepartmentToDB")]
        public JsonResult addDepartmentToDB([FromBody] Department department)
        {
            DepartmentList.Add(new Department() { Id = 5 , Name = department.Name, Description = department.Description });
            return new JsonResult("OK");
        }

        
        [HttpDelete("deleteDepartment/{id}")]
        public JsonResult deleteDepartmentFromDB(int id)
        {
            Department department = DepartmentList?.Find(d => d.Id == id);

            if (department != null)
            {
                DepartmentList.Remove(department);
                return new JsonResult("OK");
            }
            else
            {
                return new JsonResult("Department not found");
            }
        }

        [HttpPost("UpdateDepartment")]
        public JsonResult updateDepartment([FromBody] Department department)
        {
            Department Department = DepartmentList?.FirstOrDefault(d => d.Id == department.Id);

            if (department != null)
            {
                Department.Name = department.Name;
                Department.Description = department.Description;
                return new JsonResult("OK");
            }
            else
            {
                return new JsonResult("Department not found");
            }
        }


    }
}
