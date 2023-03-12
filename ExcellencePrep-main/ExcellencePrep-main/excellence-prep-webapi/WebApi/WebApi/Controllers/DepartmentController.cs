using Market.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


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
