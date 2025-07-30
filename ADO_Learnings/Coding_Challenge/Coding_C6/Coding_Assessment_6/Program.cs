using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Coding_Assessment_6
{
    class Program
    {
        public static SqlConnection conn;
        public static SqlCommand command;
        public static SqlDataReader reader;
        public static SqlParameter empIdParam;
        public static SqlParameter salaryParam;

        static SqlConnection GetConnection()
        {
            conn = new SqlConnection("Data Source=ICS-LT-7X4X9K3\\SQLEXPRESS;Initial Catalog=SQL_Assessment;" +
                "Integrated Security = true;");
            conn.Open();
            return conn;
        }
        static void Main()
        {
            try
            {
                conn = GetConnection();
                command = new SqlCommand("Insert_Employee_Details", conn);
                command.CommandType = CommandType.StoredProcedure;

                // Get user input
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Given Salary: ");
                double givenSalary = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Gender: ");
                string gender = Console.ReadLine();

                // Input parameters
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@GivenSalary", givenSalary);
                command.Parameters.AddWithValue("@Gender", gender);

                // Output parameters
                empIdParam = new SqlParameter("@GeneratedEmpId", SqlDbType.Int);
                empIdParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(empIdParam);

                salaryParam = new SqlParameter("@CalculatedSalary", SqlDbType.Float);
                salaryParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(salaryParam);

                command.ExecuteNonQuery();

                //Display results
                Console.WriteLine("\nEmployee inserted successfully!");
                Console.WriteLine("Generated EmpId: " + empIdParam.Value);
                Console.WriteLine("Calculated Salary: " + salaryParam.Value);

            }
            catch(Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");

            }
            finally
            {
                conn.Close();
            }
            DisplayData();
            Console.ReadLine();
        }

        static void DisplayData()
        {
            try
            {
                conn = GetConnection();
                command = new SqlCommand("select * from Employee_Details", conn);
                reader = command.ExecuteReader();
                bool status = reader.HasRows;
                if (status)
                {
                    Console.WriteLine("\n*******************Displaying All Data in the Table***************");
                    while (reader.Read())
                    {
                        Console.WriteLine("Employee ID : " + reader["Empid"]);
                        Console.WriteLine("Employee name: " + reader["Name"]);
                        Console.WriteLine("Employee Salary : " + reader["salary"]);

                    }
                }
                else
                {
                    Console.WriteLine("No Data is there...");
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine($"Some Error.... : {e.Message}");
            }
        }
    }
}
