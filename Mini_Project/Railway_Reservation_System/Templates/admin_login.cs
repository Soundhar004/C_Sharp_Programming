using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Railway_Reservation_System.Templates
{
    class admin_login
    {
        public static SqlConnection conn;
        public static SqlCommand command;
        public static SqlDataReader rd;

        public static string AdminId, adminname;
        public static string adminphone, adminemail;
        public static bool Admin_Login_Status = false;
        private static string adminpass;
        public bool AdminSignup()
        {
            Console.Write("Enter admin Username: ");
            string adminname = Console.ReadLine();
            Console.Write("Enter admin Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter User type (Passenger / Admin): ");
            string usertype = Console.ReadLine();

            bool status = users_login.InsertData(adminname,phone,email,password,usertype,"admins");
            if (status)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AdminLogin()
        {
            Console.WriteLine("Enter the Admin Username :  ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter the Admin Password :  ");
            string password = Console.ReadLine();
            SelectData(username, password);
            try
            {
                bool result = users_login.VerifyPassword(password, adminpass);
                if (result)
                {
                    Console.WriteLine("\nAdmin Logged in Successfully...");
                    /*Console.WriteLine(AdminId);
                    Console.WriteLine(adminname);
                    Console.WriteLine(adminpass);*/
                    Admin_Login_Status = true;
                    return true;

                }
                else
                {
                    Console.WriteLine("\nAdmin Login Failed.");
                    Admin_Login_Status = false;
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong while Logging in : {e.Message}");
                return false;
            }

        }



        public void SelectData(string username, string password)
        {
            try
            {
                conn = db_connection.CreateConnection();
                string query = "select * from admins where Username=@username";
                command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@username", username);
                rd = command.ExecuteReader();
                bool status = rd.HasRows;
                if (status)
                {
                    while (rd.Read())
                    {
                        AdminId = rd["AdminId"].ToString();
                        adminname = rd["Username"].ToString();
                        adminpass = rd["PasswordHash"].ToString();
                        adminphone = rd["PhoneNumber"].ToString();
                        adminemail = rd["Email"].ToString();
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
