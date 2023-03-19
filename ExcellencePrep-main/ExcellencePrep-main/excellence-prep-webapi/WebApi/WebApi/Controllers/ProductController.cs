using Market.Data.Sql;
using Market.Entities;
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
 

        public ProductController()
        {
            
        }



        public List<Product> ProductList;

        [HttpGet("getAllProductsFromDB")]
        public List<Product> getAllProductsFromDB()
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ ProductController \ getAllProductsFromDB ran Successfully - ");
                ProductList = new List<Product>();
                ProductList = MainManager.Instance.ProductManager.getAllProductsFromDB();
                return ProductList;
            }

            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

            return ProductList;
        }





        [HttpPost("addProductToDB")]
        public JsonResult addProductToDB([FromBody] Product product)
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ ProductController \ addProductToDB ran Successfully - ");
                MainManager.Instance.ProductManager.addProductToDB(product);
                return new JsonResult("OK");
            }

            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return new JsonResult("Problem");
        }






        
        [HttpDelete("deleteProduct/{id}")]
        public JsonResult deleteProduct(int id)
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ ProductController \ deleteProduct ran Successfully - ");
                MainManager.Instance.ProductManager.deleteProductFromDB(id);
                return new JsonResult("OK");
            }

            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return new JsonResult("Problem");
        }




        
        [HttpPost("UpdateProduct")]
        public JsonResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ ProductController \ updateProduct ran Successfully - ");
                MainManager.Instance.ProductManager.updateProduct(product);
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
