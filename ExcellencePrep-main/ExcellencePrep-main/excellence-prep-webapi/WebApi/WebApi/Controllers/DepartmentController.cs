using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Department")]
    public class DepartmentController : Controller
    {

        public static List<Department> DepartmentList = new List<Department>();
        //public static int? Counter = DepartmentList?.Max(d => d.Id);

        public DepartmentController()
        {
            DepartmentList.Clear();
            DepartmentList.Add(new Department() { Id = 1, Name = "Toys" });
            DepartmentList.Add(new Department() { Id = 2, Name = "Food" });
            DepartmentList.Add(new Department() { Id = 3, Name = "Drinks" });
            DepartmentList.Add(new Department() { Id = 4, Name = "Snacks" });
        }


        [HttpGet("getAllDepartmentFromDB")]
        public JsonResult getAllDepartmentFromDB()
        {
            return new JsonResult(DepartmentList);
        }

        
        [HttpPost("addDepartmentToDB")]
        public JsonResult addDepartmentToDB(string name, string description)
        {
            DepartmentList.Add(new Department() { Id = 5 , Name = name, Description = description });
            return new JsonResult("OK");
        }

        
        [HttpDelete("deleteDepartmentFromDB/{id}")]
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

        [HttpPut("updateDepartment/{id}")]
        public JsonResult updateDepartment(int id, string name, string description)
        {
            Department department = DepartmentList?.FirstOrDefault(d => d.Id == id);

            if (department != null)
            {
                department.Name = name;
                department.Description = description;
                return new JsonResult("OK");
            }
            else
            {
                return new JsonResult("Department not found");
            }
        }


    }
}
