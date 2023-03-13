using Market.Data.Sql_2;
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
        public void addProductToDB([FromBody] Product product)
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ ProductController \ addProductToDB ran Successfully - ");
                MainManager.Instance.ProductManager.addProductToDB(product);
            }

            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }






        
        [HttpDelete("deleteProduct/{id}")]
        public void deleteProduct(int id)
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ ProductController \ deleteProduct ran Successfully - ");
                MainManager.Instance.ProductManager.deleteProductFromDB(id);
            }

            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }




        
        [HttpPost("UpdateProduct")]
        public void UpdateProduct([FromBody] Product product)
        {
            try
            {
                MainManager.Instance.log.LogEvent(@"WebApi \ ProductController \ updateProduct ran Successfully - ");
                MainManager.Instance.ProductManager.updateProduct(product);
            }

            catch (Exception ex)
            {
                MainManager.Instance.log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }
    }
}
