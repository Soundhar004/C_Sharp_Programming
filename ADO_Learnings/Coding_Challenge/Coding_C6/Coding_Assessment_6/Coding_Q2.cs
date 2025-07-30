using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Coding_Assessment_6
{
    class Coding_Q2
    {
        public static SqlConnection conn;
        public static SqlCommand command;
        public static SqlDataReader reader;
        public static SqlParameter updatedSalaryParam;

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
                command = new SqlCommand("UpdateEmployeeSalary", conn);
                command.CommandType = CommandType.StoredProcedure;

                //Get EmpId from user
                Console.Write("Enter Employee ID to update salary: ");
                int empId = Convert.ToInt32(Console.ReadLine());
                command.Parameters.AddWithValue("@EmpId", empId);

                //Output parameter
                updatedSalaryParam = new SqlParameter("@UpdatedSalary", SqlDbType.Float);
                updatedSalaryParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(updatedSalaryParam);

                command.ExecuteNonQuery();

                double updatedSalary = Convert.ToDouble(updatedSalaryParam.Value);
                Console.WriteLine("\nSalary updated successfully!");
                Console.WriteLine("Updated Salary: " + updatedSalary);

                //Display the data
                command = new SqlCommand("select * from Employee_Details where EmpId = @EmpId", conn);
                command.Parameters.AddWithValue("@EmpId", empId);
                reader = command.ExecuteReader();

                bool status = reader.HasRows;
                if (status)
                {
                    Console.WriteLine("\n*******************Displaying Employee Data in the Table***************");
                    while (reader.Read())
                    {
                        Console.WriteLine("Employee ID : " + reader["Empid"]);
                        Console.WriteLine("Employee name: " + reader["Name"]);
                        Console.WriteLine("Employee Salary : " + reader["salary"]);
                        Console.WriteLine("Employee Gender : " + reader["Gender"]);

                    }
                    reader.Close();
                }
                else
                {
                    Console.WriteLine("No Data is there...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
            finally
            {
                conn.Close();
            }
            Console.ReadLine();
        }

       /* static void DisplayData()
        {
            try
            {
                conn = GetConnection();
                command = new SqlCommand("select * from Employee_Details where EmpId = @EmpId", conn);
                command.Parameters.AddWithValue("@EmpId", empId);
                reader = command.ExecuteReader();
                
                bool status = reader.HasRows;
                if (status)
                {
                    Console.WriteLine("\n*******************Displaying Employee Data in the Table***************");
                    while (reader.Read())
                    {
                        Console.WriteLine("Employee ID : " + reader["Empid"]);
                        Console.WriteLine("Employee name: " + reader["Name"]);
                        Console.WriteLine("Employee Salary : " + reader["salary"]);
                        Console.WriteLine("Employee Gender : " + reader["Gender"]);

                    }
                    reader.Close();
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
        }*/

    }
}
