//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Utilities_Log;

//namespace Market.Dal
//{
//    public class SqlDB : BaseDAL
//    {
//        public SqlDB(LogManager log) : base(log)
//        {

//        }

//        public static string ConnectionString = @"Integrated Security=SSPI;   Persist Security Info=False;    Initial Catalog=Market;  Data Source=localhost\sqlexpress";

//        public static DataTable ReadFormDB(string Sql_Query)
//        {
//            try
//            {
//                Log.LogEvent(@"Dal \ SqlDB \ ReadFormDB ran Successfully - ");
//                SqlDataAdapter adapter = new SqlDataAdapter(Sql_Query, ConnectionString);
//                //יצירת טבלה בזיכרון
//                DataTable table = new DataTable();
//                //מילוי הנתונים בתוך הטבלה הזמנית בזיכרון
//                adapter.Fill(table);

//                return table;
//            }
//            catch (Exception ex)
//            {
//                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
//            }
//            return new DataTable();
//        }

//        public static void WriteToDB(string Sql_Query)
//        {
//            try
//            {
//                Log.LogEvent(@"Dal \ SqlDB \ WriteToDB ran Successfully - ");
//                //הפעלת הצינור לפי ההגדרות שמופיעות בקונקטשן סטרינג
//                using (SqlConnection connection = new SqlConnection(ConnectionString))
//                {
//                    using (SqlCommand command = new SqlCommand(Sql_Query, connection))
//                    {
//                        connection.Open();

//                        command.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
//            }
//        }

//        public static object GetScalarFromDB(string Sql_Query)
//        {
//            try
//            {
//                Log.LogEvent(@"Dal \ SqlDB \ GetScalarFromDB ran Successfully - ");
//                object result;
//                //הפעלת הצינור לפי ההגדרות שמופיעות בקונקטשן סטרינג
//                using (SqlConnection connection = new SqlConnection(ConnectionString))
//                {
//                    using (SqlCommand command = new SqlCommand(Sql_Query, connection))
//                    {
//                        connection.Open();

//                        result = command.ExecuteScalar();
//                    }
//                }
//                return result;
//            }
//            catch (Exception ex)
//            {
//                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
//            }
//            return new DataTable();
//        }
//    }
//}
