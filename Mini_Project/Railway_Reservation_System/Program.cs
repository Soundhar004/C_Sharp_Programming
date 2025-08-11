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
                Console.WriteLine("*******Please select to get inside*********\n\n" +
                    "1. Login as a Passenger.\n\n" +
                    "2. Login as a Admin.\n\n" +
                    "3. Register as a User.\n\n" +
                    "4. Register as a Admin.\n\n" +
                    "5. To Exit.\n\n"+
                    "(Note : After the registration youcan able to Login.)\n");

                Console.WriteLine("Enter the option : ");
                int Getuser = Convert.ToInt32(Console.ReadLine());
               
                users_login userlogin = new users_login();
                admin_login adminlogin = new admin_login();
                admin_dashboard admindashboard = new admin_dashboard();

                switch (Getuser)
                {
                    case 1:
                        userlogin.LoginValidate();
                        if (users_login.Login_Status)
                        {
                            Console.WriteLine($"Welcome {users_login.user}, Book Your Ticket and Enjoy Your Journey");
                            user_dashboard.UserMenu();
                        }
                        else
                        {
                            users_login.Login_Status = false;
                        }

                        break;

                    case 2:
                        adminlogin.AdminLogin();
                        if (admin_login.Admin_Login_Status)
                        {
                            Console.WriteLine($"Welcome Admin {admin_login.adminname}, Now You Can Able To Modify....");
                            admindashboard.AdminMenu();
                        }
                        else
                        {
                            users_login.Login_Status = false;
                        }
                        break;

                    case 3:
                        userlogin.UserSignup();
                        break;

                    case 4:
                        adminlogin.AdminSignup();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid Option. ");
                        break;

                }

            
        }
    }
}
