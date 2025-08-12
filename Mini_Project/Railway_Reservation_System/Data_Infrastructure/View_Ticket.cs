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
                        BookingId = reader["BookingId"] != DBNull.Value ? Convert.ToInt32(reader["BookingId"]) : 0,
                        PassengerName = reader["PassengerName"] != DBNull.Value ? reader["PassengerName"].ToString() : string.Empty,
                        FromStation = reader["FromStation"] != DBNull.Value ? reader["FromStation"].ToString() : string.Empty,
                        ToStation = reader["ToStation"] != DBNull.Value ? reader["ToStation"].ToString() : string.Empty,
                        TravelDate = reader["TravelDate"] != DBNull.Value ? Convert.ToDateTime(reader["TravelDate"]) : DateTime.MinValue,
                        SeatNo = reader["SeatNo"] != DBNull.Value ? Convert.ToInt32(reader["SeatNo"]) : 0,
                        SeatType = reader["SeatType"] != DBNull.Value ? reader["SeatType"].ToString() : string.Empty,
                        TotalCost = reader["TotalCost"] != DBNull.Value ? Convert.ToDecimal(reader["TotalCost"]) : 0m,
                        BookingDate = reader["BookingDate"] != DBNull.Value ? Convert.ToDateTime(reader["BookingDate"]) : DateTime.MinValue,
                        IsCancelled = reader["IsCancelled"] != DBNull.Value ? Convert.ToBoolean(reader["IsCancelled"]) : false,
                        TrainId = reader["TrainId"] != DBNull.Value ? Convert.ToInt32(reader["TrainId"]) : 0,
                        IsDeleted = reader["IsDeleted"] != DBNull.Value ? Convert.ToBoolean(reader["IsDeleted"]) : false
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Reservation_Access> ViewAllBookings()
        {
            try
            {
                List<Reservation_Access> raccess = new List<Reservation_Access>();
                using (SqlConnection conn = db_connection.CreateConnection())
                {
                    var cmd = new SqlCommand("SELECT * FROM Reservation WHERE IsDeleted = 0", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var reservation = new Reservation_Access
                        {
                            BookingId = reader["BookingId"] != DBNull.Value ? Convert.ToInt32(reader["BookingId"]) : 0,
                            PassengerName = reader["PassengerName"] != DBNull.Value ? reader["PassengerName"].ToString() : string.Empty,
                            FromStation = reader["FromStation"] != DBNull.Value ? reader["FromStation"].ToString() : string.Empty,
                            ToStation = reader["ToStation"] != DBNull.Value ? reader["ToStation"].ToString() : string.Empty,
                            TravelDate = reader["TravelDate"] != DBNull.Value ? Convert.ToDateTime(reader["TravelDate"]) : DateTime.MinValue,
                            SeatNo = reader["SeatNo"] != DBNull.Value ? Convert.ToInt32(reader["SeatNo"]) : 0,
                            SeatType = reader["SeatType"] != DBNull.Value ? reader["SeatType"].ToString() : string.Empty,
                            TotalCost = reader["TotalCost"] != DBNull.Value ? Convert.ToDecimal(reader["TotalCost"]) : 0,
                            BookingDate = reader["BookingDate"] != DBNull.Value ? Convert.ToDateTime(reader["BookingDate"]) : DateTime.MinValue,
                            IsCancelled = reader["IsCancelled"] != DBNull.Value ? Convert.ToBoolean(reader["IsCancelled"]) : false,
                            TrainId = reader["TrainId"] != DBNull.Value ? Convert.ToInt32(reader["TrainId"]) : 0,
                            IsDeleted = reader["IsDeleted"] != DBNull.Value ? Convert.ToBoolean(reader["IsDeleted"]) : false
                        };

                        raccess.Add(reservation);
                    }
                    return raccess;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Some Error : {e.Message}");
                return null;
            }
        }


        
       /* public bool ShowTicket()
        {
 
            var Ticket = viewticket.ViewAllBookings();
            foreach(var t in Ticket)
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
            return true;



        }*/



    }

    
}
