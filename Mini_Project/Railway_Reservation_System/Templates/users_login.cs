using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Railway_Reservation_System.Templates;
using BCrypt.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;



namespace Railway_Reservation_System.Templates
{
    class users_login
    {
        public static SqlConnection conn;
        public static SqlCommand command;
        public static SqlDataReader rd;

        public static string Userid, user;
        public static string userphone, useremail;
        private static string pass;
        static void Main()
        {
            

        }

        /*UserSignup function*/
        public bool UserSignup()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Phone: ");
            string phone = GetValidMobileNumber();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter User type (Passenger / Admin): ");
            string usertype = Console.ReadLine();

            bool status = InsertData(username, phone, email, password, usertype,"users");
            if (status)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LoginValidate()
        {

            Console.WriteLine("Enter the Username :  ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter the Password :  ");
            string password = Console.ReadLine();

            SelectData(username, password);
            try
            {
                bool result = VerifyPassword(password, pass);
                if (result)
                {
                    Console.WriteLine("\nYou Logged in Successfully...");
                    return true;
                }
                else
                {
                    Console.WriteLine("\nLogin Failed.");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong while Logging in : {e.Message}");
                return false;
            }

        }

        
         public static bool VerifyPassword(string userpass, string dbpass)
         {
            bool result = BCrypt.Net.BCrypt.Verify(userpass, dbpass);
            return result;
         }

        public void SelectData(string username, string password)
        {

            try
            {
                conn = db_connection.CreateConnection();
                string query = "select * from users where Username=@username";
                command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@username",username);
                rd = command.ExecuteReader();
                bool status = rd.HasRows;
                if (status)
                {

                    while (rd.Read())
                    {
                        Userid = rd["UserId"].ToString();
                        user= rd["Username"].ToString();
                        pass = rd["PasswordHash"].ToString();
                        userphone = rd["PhoneNumber"].ToString();
                        useremail = rd["Email"].ToString();
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

        /*Password Hashing Function*/
        public static string HashPassword(string password)
        {
            string hashedpassword = BCrypt.Net.BCrypt.HashPassword(password, workFactor:12);
            return hashedpassword;
            
        }

        public static bool InsertData(string username, string phone, string email, string password, string usertype, string table)
        {
            try
            {
                string passwordhashed = HashPassword(password);
                DateTime registrationDate = DateTime.Now;
                SqlConnection conn = db_connection.CreateConnection();
                string query = ($"INSERT INTO {table}(Username, PhoneNumber, Email, PasswordHash, UserType, RegistrationDate, IsDeleted) VALUES(@Username, @Phonenumber, @Email, @PasswordHash, @Usertype, @Regiterdate, 0)");
                command = new SqlCommand(query,conn);
                /*command.Connection = conn;*/
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("Phonenumber", phone);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PasswordHash", passwordhashed);
                command.Parameters.AddWithValue("@Usertype",usertype);
                command.Parameters.AddWithValue("@Regiterdate", registrationDate);

                int rows_affected = command.ExecuteNonQuery();
                if (rows_affected > 0)
                {

                    /*Console.WriteLine("Inserted Successfully......");*/
                    /*Console.WriteLine("Registered Successfully.....");
                    Console.WriteLine("Login to Use Your Application......");*/
                    return true;
                }
                else
                {
                    /*Console.WriteLine("Something went wrong, It Can't able to insert.....");*/
                    /*Console.WriteLine("Something went wrong while Registering!");*/
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
                return false;
            }
        }


        static string GetValidMobileNumber()
        {
            string pattern = @"^[6-9]\d{9}$";

            while (true)
            {
                string input = Console.ReadLine();

                if (Regex.IsMatch(input, pattern))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid mobile number. Please enter a 10-digit number starting with 6, 7, 8, or 9.");
                }
            }
        }


    }
}
