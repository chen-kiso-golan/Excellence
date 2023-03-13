using Market.Dal;
using Market.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                string SQLquery = "select * from Products";
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




        
        public void addProductToDB(Product product)
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ ProductDS \ addProductToDB ran Successfully - ");
                string SQLquery = "insert into Products values ('" + product.Name + "','" + product.Price + "' ,'" + product.UnitsInStock + "' ,'" + product.DepartmentId + "')";
                SqlDB.WriteToDB(SQLquery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }





        
        public void deleteProductFromDB(int id)
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ ProductDS \ deleteProductFromDB ran Successfully - ");
                string SQLquery = "delete from Products where id = " + id;
                SqlDB.WriteToDB(SQLquery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }




        
        public void updateProduct(Product product)
        {
            try
            {
                Log.LogEvent(@"Data.Sql \ ProductDS \ updateProduct ran Successfully - ");
                string SQLquery = "update Products set name = '" + product.Name + "', price = '" + product.Price + "', unitsInStock = '" + product.UnitsInStock + "', departmentId = '" + product.DepartmentId + "' where id = " + product.Id.ToString();
                SqlDB.WriteToDB(SQLquery);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
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
                Product.Price = (int)row["price"];
                Product.UnitsInStock = (int)row["unitsInStock"];
                Product.DepartmentId = (int)row["departmentId"];
                list.Add(Product);
            }
            return list;
        }
    }
}
