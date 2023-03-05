using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Department")]
    public class DepartmentController : Controller
    {
        // GET: DepartmentController
        [HttpGet("getAllDepartmentFromDB")]
        public JsonResult getAllDepartmentFromDB()
        {
            List<Department> DepartmentList = new List<Department>();
            DepartmentList.Add(new Department() { Id = 1, Name = "Toys" });
            DepartmentList.Add(new Department() { Id = 2, Name = "Food" });
            DepartmentList.Add(new Department() { Id = 3, Name = "Drinks" });
            DepartmentList.Add(new Department() { Id = 4, Name = "Snacks" });
            return new JsonResult(DepartmentList);
        }

        //// GET: DepartmentController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: DepartmentController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: DepartmentController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DepartmentController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: DepartmentController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DepartmentController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: DepartmentController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
