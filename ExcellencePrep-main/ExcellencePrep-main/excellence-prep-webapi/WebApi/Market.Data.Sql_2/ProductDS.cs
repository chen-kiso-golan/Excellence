using Market.Dal;
using Market.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Utilities_Log;

namespace Market.Data.Sql
{
    public class ProductDS : BaseDataSql
    {
        BaseDAL BaseDAL;
        public ProductDS(LogManager log) : base(log)
        {
            BaseDAL = new BaseDAL(Log);
        }


        
        public List<Product> getAllProductsFromDB()
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ ProductDS \ getAllProductsFromDB ran Successfully - ");
                string SQLquery = "EXEC getAllProductsFromDB";
                DataTable dataTable = new DataTable();
                dataTable = SqlDB.ReadFormDB(SQLquery);
                return ConvertDataTableToList(dataTable);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return new List<Product>();
        }





        public JsonResult addProductToDB(Product product)
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ ProductDS \ addProductToDB ran Successfully - ");
                string SQLquery = "EXEC addProductToDB @name='" + product.Name + "', @price='" + product.Price + "' ,@unitsInStock='" + product.UnitsInStock + "' ,@departmentId='" + product.DepartmentId + "'";
                SqlDB.WriteToDB(SQLquery);
                return new JsonResult();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return new JsonResult();
        }






        public JsonResult deleteProductFromDB(int id)
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ ProductDS \ deleteProductFromDB ran Successfully - ");
                string SQLquery = "EXEC deleteProductFromDB @id= " + id;
                SqlDB.WriteToDB(SQLquery);
                return new JsonResult();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return new JsonResult();
        }





        public JsonResult updateProduct(Product product)
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ ProductDS \ updateProduct ran Successfully - ");
                string SQLquery = "EXEC updateProduct @id = '" + product.Id+"' ,@name = '" + product.Name + "', @price = '" + product.Price + "', @unitsInStock = '" + product.UnitsInStock + "', @departmentId = '" + product.DepartmentId;
                SqlDB.WriteToDB(SQLquery);
                return new JsonResult();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return new JsonResult();
        }


        //-------------- Convert DataTable To List
        public List<Product> ConvertDataTableToList(DataTable dataTable)
        {
            List<Product> list = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                Product Product = new Product();
                Product.Id = (int)row["id"];
                Product.Name = (string)row["name"];
                Product.Price = (decimal)row["price"];
                Product.UnitsInStock = (int)row["unitsInStock"];
                Product.DepartmentId = (int)row["departmentId"];
                list.Add(Product);
            }
            return list;
        }
    }
}
