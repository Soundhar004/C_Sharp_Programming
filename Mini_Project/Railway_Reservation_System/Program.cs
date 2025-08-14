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
            bool run = true;
            while (run)
            { 
                string headerText = "TRAIN BOOKING SYSTEM";
                string headerBorder = new string('=', 50);


                Console.WriteLine($"\n{headerBorder}");
                Console.WriteLine($"{headerText.PadLeft((headerBorder.Length - headerText.Length) / 2 + headerText.Length)}");
                Console.WriteLine($"{headerBorder}\n");
                /*Console.WriteLine("==========================================================");*/
                Console.WriteLine("*******Please select to get inside*********\n\n" +
                    "1. Login as a Passenger.\n\n" +
                    "2. Login as a Admin.\n\n" +
                    "3. Register as a User.\n\n" +
                    "4. To Exit.\n\n" +
                    "(Note : Only after the registration you can able to Login.)\n");

                Console.WriteLine("Enter the option : ");
                int Getuser = Convert.ToInt32(Console.ReadLine());

                users_login userlogin = new users_login();
                admin_login adminlogin = new admin_login();
                admin_dashboard admindashboard = new admin_dashboard();

                switch (Getuser)
                {
                    case 1:
                        
                        if (userlogin.LoginValidate())
                        {
                            Console.WriteLine($"Welcome {users_login.user}, Book Your Ticket and Enjoy Your Journey");
                            user_dashboard.UserMenu();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Username Or Password");
                        }

                        break;

                    case 2:
                        
                        if (adminlogin.AdminLogin())
                        {
                            Console.WriteLine($"Welcome Admin {admin_login.adminname}, Now You Can Able To Modify....");
                            admindashboard.AdminMenu();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Admin Username Or Password");
                            
                        }
                        break;

                    case 3:

                        if (userlogin.UserSignup())
                        {
                            Console.WriteLine("\nRegistered Successfully.....");
                            Console.WriteLine("Login to Use Your Application......");
                        }
                        else
                        {
                            Console.WriteLine("\nSomething went wrong while Registering!");
                        }
                        break;

                    /*case 4:

                        if (adminlogin.AdminSignup())
                        {
                            Console.WriteLine("Admin Registered Successfully.....");
                            Console.WriteLine("Login to Use Your Application......");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong while Registering!");
                        }
                        break;*/
                    case 4:
                        Console.WriteLine("Exiting...");
                        run = false;
                        break;


                }
            }

            
        }
    }
}
