using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railway_Reservation_System.Accessors;
using Railway_Reservation_System.Templates;
using Railway_Reservation_System.Data_Infrastructure;

namespace Railway_Reservation_System.Templates
{
    class admin_dashboard
    {
        
        public void AdminMenu()
        {
            Console.WriteLine("\n1. To Add Train.");
            Console.WriteLine("2. Search the Train by Number");
            Console.WriteLine("3. Book your Tickets");
            Console.WriteLine("4. My Bookings");
            Console.WriteLine("5. Cancel Ticket");
            Console.WriteLine("6. Logout");
            Console.Write("Enter choice: ");
            int getuser = Convert.ToInt32(Console.ReadLine());

            Train_Data traindata = new Train_Data();
            switch (getuser)
            {
                case 1:
                    traindata.GetDataForAddTrain();
                    break;
            }
        }
    }
}
