using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Accessing_Data
    {

        public static SqlConnection conn;
        public static SqlCommand command;
        public static SqlDataReader reader;

        static void Main()
        {
            try
            {
                conn = GetConnection();
                Console.Write($"Connection Successfully Established... : {conn}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"some error : {e.Message}");
            }
            SelectData();
         /*   InsertData();*/
            Console.Read();
        }
        static SqlConnection GetConnection()
        {

            //conn = new SqlConnection("Data source = ICS-LT-7X4X9K3\\SQLEXPRESS; Initial catalog = Sql_Learnings; Integrated security = True");
            conn = new SqlConnection("Server=ICS-LT-7X4X9K3\\SQLEXPRESS ;Database=Sql_Learnings; Trusted_Connection=True;");
            conn.Open();
            return conn;
        }

        static void SelectData()
        {
            try
            {
                conn = GetConnection();
               /* Console.WriteLine("Enter Department No : ");
                int deptno = Convert.ToInt32(Console.ReadLine());*/
                /*command = new SqlCommand($"select * from EMP where Deptno={deptno}", conn);*/
                command = new SqlCommand("select * from Dept where Deptno=23", conn);
              /*  command.Parameters.AddWithValue("@deptno", deptno);*/
                reader = command.ExecuteReader();
                bool status = reader.HasRows;
                if (status)
                {
                    Console.WriteLine("Starting to Display");
                    while (reader.Read())
                    {
                     /*   Console.WriteLine("Employee ID : " + reader["Empno"]);*/
                        Console.WriteLine("Employee name: " + reader["Dname"]);
                     /*   Console.WriteLine("Employee Salary : " + reader["sal"]);
                        Console.WriteLine("Department Nunmber : " + reader["Deptno"]);*/
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

        static void InsertData()
        {
            try
            {
                conn = GetConnection();
                Console.WriteLine("Enter Student ID : ");
                int stud_id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student Name : ");
                string stud_name = Console.ReadLine();
                Console.WriteLine("Enter Student Department : ");
                string stud_dept = Console.ReadLine();
                string query = "insert into DEPT values(@DEPTNO,@DNAME,@LOC)";

                command = new SqlCommand(query);
                command.Connection = conn;
                command.Parameters.AddWithValue("@DEPTNO", stud_id);
                command.Parameters.AddWithValue("@DNAME", stud_name);
                command.Parameters.AddWithValue("@LOC", stud_dept);

                int rows_affected = command.ExecuteNonQuery();
                if(rows_affected > 0)
                {
                    Console.WriteLine("Inserted Successfully......");
                }
                else
                {
                    Console.WriteLine("Something went wrong, It Can't able to insert.....");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : ", e.Message);
            }
        }


    }
}
