using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        public static List<Product> ProductList = new List<Product>();
        //public static int? Counter = ProductList?.Max(p => p.Id);


        public ProductController()
        {
            ProductList.Clear();
            ProductList.Add(new Product() { Id = 1, Name = "Doll", Price = 10, UnitsInStock = 5, DepartmentName = "?" });
            ProductList.Add(new Product() { Id = 2, Name = "Meat", Price = 20, UnitsInStock = 10, DepartmentName = "?" });
            ProductList.Add(new Product() { Id = 3, Name = "Milk", Price = 6, UnitsInStock = 9, DepartmentName = "?" });
            ProductList.Add(new Product() { Id = 4, Name = "Cookies", Price = 4, UnitsInStock = 10, DepartmentName = "?" });

        }

        


        [HttpGet("getAllProductsFromDB")]
        public JsonResult getAllProductsFromDB()
        {
            return new JsonResult(ProductList);
        }




        [HttpPost("addProductToDB")]
        public JsonResult addProductToDB(string name, int price, int unitsInStock, string DepartmentName)
        {
            ProductList.Add(new Product() { Id = 5, Name = name, Price = price, UnitsInStock = unitsInStock, DepartmentName = DepartmentName });
            return new JsonResult("OK");
        }

        
        [HttpDelete("deleteProduct/{id}")]
        public JsonResult deleteProduct(int id)
        {
            Product Product = ProductList?.Find(d => d.Id == id);

            if (Product != null)
            {
                ProductList.Remove(Product);
                return new JsonResult("OK");
            }
            else
            {
                return new JsonResult("Product not found");
            }
        }


        
        [HttpPut("UpdateProduct/{id}")]
        public JsonResult UpdateProduct(int id, string name, int price, int unitsInStock, string DepartmentName)
        {
            Product Product = ProductList?.FirstOrDefault(d => d.Id == id);

            if (Product != null)
            {
                Product.Name = name;
                Product.Price = price;
                Product.UnitsInStock = unitsInStock;
                Product.DepartmentName = DepartmentName;
                return new JsonResult("OK");
            }
            else
            {
                return new JsonResult("Department not found");
            }
        }
    }
}
