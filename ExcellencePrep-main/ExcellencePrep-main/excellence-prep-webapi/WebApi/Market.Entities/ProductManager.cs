//using Market.Data.Sql;
//using Market.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Utilities_Log;

//namespace Market.Entities
//{
//    public class ProductManager : BaseEntity
//    {
//        BaseDataSql BaseDataSql;
//        public ProductManager(LogManager log) : base(log)
//        {
//            BaseDataSql = new BaseDataSql(Log);
//        }


        
//        public List<Product> ProductTable = new List<Product>();
//        public List<Product> getAllProductsFromDB()
//        {
//            try
//            {
//                Log.LogEvent(@"Entities \ ProductManager \ getAllProductsFromDB ran Successfully - ");
//                ProductTable.Clear();
//                ProductDS productDS = new ProductDS(Log);
//                return ProductTable = productDS.getAllProductsFromDB();
//            }
//            catch (Exception ex)
//            {
//                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
//            }
//            return ProductTable;
//        }





        
//        public void addProductToDB(Product product)
//        {
//            try
//            {
//                Log.LogEvent(@"Entities \ ProductManager \ addProductToDB ran Successfully - ");
//                ProductDS productDS = new ProductDS(Log);
//                productDS.addProductToDB(product);
//            }
//            catch (Exception ex)
//            {
//                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
//            }
//        }




        
//        public void deleteProductFromDB(int id)
//        {
//            try
//            {
//                Log.LogEvent(@"Entities \ ProductManager \ deleteProductFromDB ran Successfully - ");
//                ProductDS productDS = new ProductDS(Log);
//                productDS.deleteProductFromDB(id);
//            }
//            catch (Exception ex)
//            {
//                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
//            }
//        }


        
//        public void updateProduct(Product product)
//        {
//            try
//            {
//                Log.LogEvent(@"Entities \ ProductManager \ updateProduct ran Successfully - ");
//                ProductDS productDS = new ProductDS(Log);
//                productDS.updateProduct(product);
//            }
//            catch (Exception ex)
//            {
//                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
//            }
//        }
//    }
//}
