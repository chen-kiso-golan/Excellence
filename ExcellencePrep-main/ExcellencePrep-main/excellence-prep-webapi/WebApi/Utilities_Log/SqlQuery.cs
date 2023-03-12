using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Utilities_Log
{
    public class SqlQuery
    {
        public static string connectionString;
        public static void ConnectionStringInit(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        public delegate object SetDataReader_delegate(SqlDataReader reader);
        public static object ReadFromDB(string SqlQuery, SetDataReader_delegate Ptrfunc)
        {
            object retHash = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            retHash = Ptrfunc(reader);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //Handle the exception here, such as logging it or displaying an error message
            }


            return retHash;
        }
        public static int WriteToDB(string SqlQuery)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                    {
                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                //Handle the exception here, such as logging it or displaying an error message
            }

            return rowsAffected;
        }
        public static void WriteWithValuesToDB(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach (KeyValuePair<string, object> param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                //Handle the exception here, such as logging it or displaying an error message
            }
        }
        public static object ReadScalarFromDB(string SqlQuery)
        {
            object answer = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                    {
                        connection.Open();

                        answer = command.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                //Handle the exception here, such as logging it or displaying an error message
            }
            return answer;
        }
        public static DataTable ReadTableFromDB(string sqlQuery)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connectionString);

                DataTable table = new DataTable();

                adapter.Fill(table);

                return table;
            }
            catch (SqlException ex)
            {
                // Handle the exception, for example by logging it or displaying an error message
            }
            return null;
        }

    }
}
