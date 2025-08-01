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

        public static int Userid;
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

            InsertData(username, phone, email, password, usertype);
           
        }

        public void LoginValidate()
        {

            Console.WriteLine("Enter the Username :  ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter the Password :  ");
            string password = Console.ReadLine();
            
        }




        public static void SelectData(string username, string password)
        {

            /*user and pass from database*/
            string user,pass;

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
              
                    Userid = rd.GetInt32(rd.GetOrdinal("UserId"));
                    user = rd.GetString(rd.GetOrdinal("Username"));
                    pass = rd.GetString(rd.GetOrdinal("PasswordHash"));

                    bool result = BCrypt.Net.BCrypt.Verify(password, pass);
                    Console.WriteLine(Userid);
                    Console.WriteLine(user);
                    Console.WriteLine(pass);
                    Console.WriteLine(result);

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
            string hashedpassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedpassword;
            
        }

        static void InsertData(string username, string phone, string email, string password, string usertype)
        {
            try
            {
                string passwordhashed = HashPassword(password);
                DateTime registrationDate = DateTime.Now;
                SqlConnection conn = db_connection.CreateConnection();
                string query = "INSERT INTO Users(Username, PhoneNumber, Email, PasswordHash, UserType, RegistrationDate, IsDeleted) VALUES(@Username, @Phonenumber, @Email, @PasswordHash, @Usertype, @Regiterdate, 1)";
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
