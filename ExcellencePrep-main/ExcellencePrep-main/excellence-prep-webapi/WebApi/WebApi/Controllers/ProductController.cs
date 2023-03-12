using Market.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Xml.Linq;


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
        public JsonResult addProductToDB([FromBody] Product product)
        {
            ProductList.Add(new Product() { Id = 5, Name = product.Name, Price = product.Price, UnitsInStock = product.UnitsInStock, DepartmentName = product.DepartmentName });
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


        
        [HttpPost("UpdateProduct")]
        public JsonResult UpdateProduct([FromBody] Product product)
        {
        
            Product Product = ProductList?.FirstOrDefault(p => p.Id == product.Id);

            if (Product != null)
            {
                Product.Name = product.Name;
                Product.Price = product.Price;
                Product.UnitsInStock = product.UnitsInStock;
                Product.DepartmentName = product.DepartmentName;
                return new JsonResult("OK");
            }
            else
            {
                return new JsonResult("Department not found");
            }
        }
    }
}
