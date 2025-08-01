using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Railway_Reservation_System.Templates;

namespace Railway_Reservation_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("*******Please select to get inside*********\n" +
                "1. Login as a Passenger.\n" +
                "2. Login as a Admin.\n" +
                "3. Register as a User.\n" +
                "(Note : After the registration youcan able to Login.)");
            int Getuser =  Convert.ToInt32(Console.ReadLine().ToLower());
            users_login userlogin = new users_login();
            switch (Getuser)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    userlogin.UserSignup();
                    break;
            }
            

            Console.Read();
        }
    }
}
