using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railway_Reservation_System.Accessors;
using System.Data.SqlClient;
using Railway_Reservation_System.Templates;

namespace Railway_Reservation_System.Data_Infrastructure
{
    class View_Ticket
    {
        static Trains_Access trainaccess = new Trains_Access();
        public Reservation_Access GetTicketById(int bookingid)
        {
            using (SqlConnection conn = db_connection.CreateConnection())
            {
                string query = "SELECT * FROM Reservation WHERE BookingId = @BookingId AND IsDeleted = 0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingId", bookingid);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Reservation_Access
                    {
                        BookingId = Convert.ToInt32(reader["BookingId"]),
                        PassengerName = reader["PassengerName"].ToString(),
                        FromStation = reader["FromStation"].ToString(),
                        ToStation = reader["ToStation"].ToString(),
                        TravelDate = Convert.ToDateTime(reader["TravelDate"]),
                        SeatNo = Convert.ToInt32(reader["SeatNo"]),
                        SeatType = reader["SeatType"].ToString(),
                        TotalCost = Convert.ToDecimal(reader["TotalCost"]),
                        BookingDate = Convert.ToDateTime(reader["BookingDate"]),
                        IsCancelled = Convert.ToBoolean(reader["IsCancelled"]),
                        TrainId = Convert.ToInt32(reader["TrainId"]),
                        IsDeleted = Convert.ToBoolean(reader["IsDeleted"])
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public bool ShowTicket()
        {
            Console.WriteLine("Enter Ticket Id");
            int bookingid = Convert.ToInt32(Console.ReadLine());
            var Ticket = GetTicketById(bookingid);
            if (Ticket != null)
            {
                Console.WriteLine("\n*********Your Booking*********");
                Console.WriteLine($"Booking ID      : {Ticket.BookingId}");
                Console.WriteLine($"Train Id        : {Ticket.TrainId}");
                Console.WriteLine($"Passenger Name  : {Ticket.PassengerName}");
                Console.WriteLine($"From Station    : {Ticket.FromStation}");
                Console.WriteLine($"Arrival Station : {Ticket.ToStation}");
                Console.WriteLine($"Travel Date     : {Ticket.TravelDate}");
                Console.WriteLine($"Seat Number     : {Ticket.SeatNo}");
                Console.WriteLine($"Seat Type       : {Ticket.SeatType}");
                Console.WriteLine($"Booking Date    : {Ticket.BookingDate}");
                Console.WriteLine($"Total Cost      : {Ticket.TotalCost}");
                Console.WriteLine($"Cancelled      : {(Ticket.IsCancelled ? "Yes" : "No")}");
                return true;
            }
            else
            {
                Console.WriteLine("Booking Not Found");
                return false;
            }

        }



    }

    
}
