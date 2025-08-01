using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Reservation_System.Templates
{
    public class db_connection
    {
        private static string server;
        public static SqlConnection CreateConnection()
        {
            try
            {
                server = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
                SqlConnection conn = new SqlConnection(server);
                conn.Open();
                Console.WriteLine("Connection Established Successfully!!.......");
                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine($"There is an Error while connecting Database : {e.Message}");
                return null;
            }
           

        }


    }
}
