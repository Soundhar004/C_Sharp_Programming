using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Electricity_Billing_System
{
     public class DB_Handling
    {
            public SqlConnection GetConnection()
            {
                string connStr = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;
                return new SqlConnection(connStr);
            }

    }
}
