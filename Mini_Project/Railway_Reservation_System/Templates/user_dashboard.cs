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
        static Booking_Data bookingtrain = new Booking_Data();
        static View_Ticket viewticket = new View_Ticket();
        static Cancel_Ticket cancelticket = new Cancel_Ticket();
        static Train_Class_Type_Data trainclass = new Train_Class_Type_Data();
        public static void UserMenu()
        {
            bool run = true;
            while (run)
            {
                string headerText = "USER DASHBOARD";
                string headerBorder = new string('=', 50);

                Console.WriteLine($"\n{headerBorder}");

                Console.WriteLine($"{headerText.PadLeft((headerBorder.Length - headerText.Length) / 2 + headerText.Length)}");

                Console.WriteLine($"{headerBorder}\n");

                /*Console.WriteLine("\n==========================================================");*/
                Console.WriteLine("\n1. To View All the Trains.");
                Console.WriteLine("\n2. To Book Your Tickets.");
                Console.WriteLine("\n3. To View All My Bookings.");
                Console.WriteLine("\n4. To Cancel the Ticket.");
                Console.WriteLine("\n5. To view my cancelled Tickets.");
                Console.WriteLine("\n6. To Delete the Ticket.");
                Console.WriteLine("\n7. To Exit.");
                Console.Write("\nEnter your choice : ");
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
                            Console.WriteLine($"Tarin Id : {t.TrainID}\n" +
                                $"Train No : {t.TrainNumber}, \n" +
                                $"Train Name: {t.TrainName},\n" +
                                $"Source Station  : {t.SourceStation}, \n" +
                                $"Destination Station : {t.DestinationStation}, \n" +
                                $"Departure Time : {t.DepartureTime}, \n" +
                                $"Arrival Time : {t.ArrivalTime}, \n" +
                                $"Duration : {t.Duration}, \n" +
                                $"Total Seats : {t.TotalSeats}, \n" +
                                $"Fare : {t.Fare}, \n" +
                                $"Coach Type : {t.TrainType}, \n" +
                                $"Status : {t.Status}\n");
                        }
                        break;

                    case 2:
                        try
                        {
                            if (bookingtrain.GetBookingUser())
                            {
                                Console.WriteLine("Ticket Booked Successfully.......");
                            }
                            else
                            {
                                Console.WriteLine("Failed! to book your Ticket");
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Something went wrong : {e.Message}");
                        }
                        break;
                    case 3:
                        var Ticket = viewticket.ViewAllBookings();
                        foreach (var t in Ticket)
                        {
                            Console.WriteLine("\n*********Your Booking*********");
                            Console.WriteLine($"Booking ID      : {t.BookingId}");
                            Console.WriteLine($"Train Id        : {t.TrainId}");
                            Console.WriteLine($"Passenger Name  : {t.PassengerName}");
                            Console.WriteLine($"From Station    : {t.FromStation}");
                            Console.WriteLine($"Arrival Station : {t.ToStation}");
                            Console.WriteLine($"Travel Date     : {t.TravelDate}");
                            Console.WriteLine($"Seat Number     : {t.SeatNo}");
                            Console.WriteLine($"Seat Type       : {t.SeatType}");
                            Console.WriteLine($"Booking Date    : {t.BookingDate}");
                            Console.WriteLine($"Total Cost      : {t.TotalCost}");
                            Console.WriteLine($"Cancelled      : {(t.IsCancelled ? "Yes" : "No")}");
                        }
                       /* try
                        {
                            if (viewticket.ShowTicket())
                            {
                                Console.WriteLine("-----You Can See Your Ticket Now-------");
                            }
                            else
                            {
                                Console.WriteLine("Tickets Not Found");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Something went wrong : {e.Message}");
                        }*/
                        break;

                    case 4:
                        Console.WriteLine("Enter Booking Id : ");
                        int bookingid = Convert.ToInt32(Console.ReadLine());
                        var result = viewticket.GetTicketById(bookingid);


                        if (result == null || result.IsCancelled)
                        {
                            Console.WriteLine("Invalid or already cancelled booking.");
                            return;
                        }
                        bool cancel = cancelticket.CancelTheTicket(bookingid, result.TotalCost);
                        if (cancel)
                        {
                            Console.WriteLine("You Cancelled Your Ticket Sucessfully....");
                            trainclass.RestoreSeats(result.TrainId, result.SeatType, result.SeatNo);
                        }


                        break;

                    case 5:

                        var canceltickets = cancelticket.GetCancelledTickets();
                        if (canceltickets != null)
                        {
                            foreach (var ct in canceltickets)
                            {
                                Console.WriteLine("-----------------------------------------");
                                Console.WriteLine(
                                   $"Cancellation Id : {ct.CancellationId}, \n" +
                                   $"Booking Id      : {ct.BookingId},\n" +
                                   $"Refund Amount   : {ct.RefundAmount}, \n" +
                                   $"Cancelled Date  : {ct.CancellationDate},\n" +
                                   $"Departure Time : {(ct.TicketCancelled ? "Yes" : "No")}\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cancelled Ticket Not Found");
                        }

                        break;
                    case 6:
                        Console.Write("Enter Booking Id to Delete Your Ticket : ");
                        int bookid = Convert.ToInt32(Console.ReadLine());
                        if (cancelticket.DeleteTheTicket(bookid))
                        {
                            Console.WriteLine("Your Ticket has Deleted");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Exiting.....");
                        run = false;
                        break;



                }
            }

        }

    }
}
