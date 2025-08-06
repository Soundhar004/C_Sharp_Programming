using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railway_Reservation_System.Data_Infrastructure;

namespace Railway_Reservation_System.Templates
{
    class user_dashboard
    {

        static Train_Data traindata = new Train_Data();
        public static void UserMenu()
        {

            Console.WriteLine("\n1. To View All the Trains");
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
                    Console.WriteLine("****************All Available Trains*************");
                    var trains = traindata.ViewAllTrains();
                    foreach (var t in trains)
                    {
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine($"Train No : {t.TrainNumber}, " +
                            $"Train Name: {t.TrainName}," +
                            $" Source Station  : {t.SourceStation}, " +
                            $"Destination Station : {t.DestinationStation}, " +
                            $"Departure Time : {t.DepartureTime}, " +
                            $"Arrival Time : {t.ArrivalTime}, " +
                            $"Travel Date : {t.TravelDate}, " +
                            $"Duration : {t.Duration}, " +
                            $"Total Seats : {t.TotalSeats}, " +
                            $"Fare : {t.Fare}, " +
                            $"Coach Type : {t.TrainType}, " +
                            $"Status : {t.Status}");
                    }
                    break;

                

                case 2:

                    break;
            }

        }

    }
}
