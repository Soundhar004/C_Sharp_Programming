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



namespace Railway_Reservation_System.Templates
{
    class users_login
    {
        public static SqlConnection conn;
        public static SqlCommand command;
        public static SqlDataReader rd;

        public static string Userid, user;
        public static string userphone, useremail;
        public static bool Login_Status = false; 
        private static string pass;
        static void Main()
        {
            

        }

        /*UserSignup function*/
        public void UserSignup()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter User type (Passenger / Admin): ");
            string usertype = Console.ReadLine();

            InsertData(username, phone, email, password, usertype,"users");
           
        }

        public void LoginValidate()
        {

            Console.WriteLine("Enter the Username :  ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter the Password :  ");
            string password = Console.ReadLine();

            SelectData(username, password);
         
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

                    try
                    {
                        bool result = VerifyPassword(password, pass);
                        if (result)
                        {
                            Console.WriteLine("Login Successfully...");
                            Console.WriteLine(Userid);
                            Console.WriteLine(user);
                            Console.WriteLine(pass);
                            Login_Status = true;
                        }
                        else
                        {
                            Console.WriteLine("Login Failed.");
                            Console.WriteLine("Invalid Password or Username");
                            Login_Status = false;
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"Something went wrong while Logging in : {e.Message}");
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

        public static void InsertData(string username, string phone, string email, string password, string usertype, string table)
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
                    Console.WriteLine("Inserted Successfully......");
                }
                else
                {
                    Console.WriteLine("Something went wrong, It Can't able to insert.....");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }




    }
}
