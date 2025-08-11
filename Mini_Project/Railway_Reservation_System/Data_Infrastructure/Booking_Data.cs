using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railway_Reservation_System.Accessors;
using System.Data.SqlClient;
using Railway_Reservation_System.Templates;
using Railway_Reservation_System.Data_Infrastructure;

namespace Railway_Reservation_System.Data_Infrastructure
{
    class Booking_Data
    {

        /*public static Reservation_Access reservation = new Reservation_Access();*/
        public static Train_Class_Type_Data trainclass = new Train_Class_Type_Data();
        public bool GetBookingUser()
        {
            
            Console.WriteLine("Enter Train Id : ");
            int trainId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Passenger name : ");
            string passengerName = Console.ReadLine();
            Console.WriteLine("Enter From station : ");
            string fromStation = Console.ReadLine();
            Console.WriteLine("Enter Arrival station : ");
            string toStation = Console.ReadLine();
            Console.WriteLine("Enter Travel Date (yyyy-MM-dd):");
            DateTime travelDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter No of Seats : ");
            int seatNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Seat Type : ");
            string seatType = Console.ReadLine();


            var available_seats = trainclass.GetAvailability(trainId, seatType);
            if (available_seats == null )
            {
                Console.WriteLine("No seats are there");
                return false;
            }
            else if (available_seats.AvailableSeats < seatNo)
            {
                Console.WriteLine("not enough seats available");
            }
            
            decimal totalCost = seatNo * available_seats.CostPerSeat;
            Reservation_Access reservation = new Reservation_Access
            {
                TrainId = trainId,
                PassengerName = passengerName,
                FromStation= fromStation,
                ToStation= toStation,
                TravelDate = travelDate,
                SeatNo= seatNo,
                SeatType = seatType,
                TotalCost = totalCost,
                BookingDate = DateTime.Now
            };
            bool booking_status = Booking_Data.MakingRservation(reservation);

            if (booking_status)
            {
                trainclass.UpdateAvailableSeats(trainId, seatType, seatNo);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool MakingRservation(Reservation_Access reserve)
        {
            try
            {
                using (SqlConnection conn = db_connection.CreateConnection())
                {
                    string query = @"INSERT INTO Reservation (PassengerName, FromStation, ToStation, TravelDate, SeatNo, SeatType, BookingDate, TotalCost, IsDeleted, IsCancelled, TrainID )
                                    VALUES (@passengername, @fromstation, @arrivalstation, @traveldate, @seatno ,@seattype, @bookingdate, @totalcost, @Isdeleted, @Iscancelled, @trainid);";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@passengername", reserve.PassengerName);
                        cmd.Parameters.AddWithValue("@fromstation", reserve.FromStation);
                        cmd.Parameters.AddWithValue("@arrivalstation", reserve.ToStation);
                        cmd.Parameters.AddWithValue("@traveldate", reserve.TravelDate);
                        cmd.Parameters.AddWithValue("@seatno", reserve.SeatNo);
                        cmd.Parameters.AddWithValue("@seattype", reserve.SeatType);
                        cmd.Parameters.AddWithValue("@bookingdate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@totalcost", reserve.TotalCost);
                        cmd.Parameters.AddWithValue("@Isdeleted", 0);
                        cmd.Parameters.AddWithValue("@trainid", reserve.TrainId);
                        cmd.Parameters.AddWithValue("@Iscancelled", 0);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error While Booking Train {e.Message}");
                return false;
            }
        }

        /*public Reservation_Access ShowAllReservations(int bookingid)
        {

            try
            {
                using (SqlConnection conn = db_connection.CreateConnection())
                {
                    string query = "SELECT * FROM Reservations WHERE BookingId = @BookingId AND IsDeleted = 0";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookingId", bookingid);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Reservation_Access
                                {
                                    BookingId = Convert.ToInt32(reader["BookingId"]),
                                    PassengerName = Convert.ToInt32(reader["CustId"]),
                                    TrainId = Convert.ToInt32(reader["TrainId"]),
                                    TravelDate = Convert.ToDateTime(reader["TravelDate"]),
                                    ClassType = reader["ClassType"].ToString(),
                                    SeatsBooked = Convert.ToInt32(reader["SeatsBooked"]),
                                    BerthAllotment = reader["BerthAllotment"].ToString(),
                                    TotalCost = Convert.ToDecimal(reader["TotalCost"]),
                                    BookingDate = Convert.ToDateTime(reader["BookingDate"]),
                                    IsCancelled = Convert.ToBoolean(reader["IsCancelled"]),
                                    IsDeleted = Convert.ToBoolean(reader["IsDeleted"])
                                };
                            }
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching reservation: " + ex.Message);
                return null;
            }

        }
*/
        public static void SeatAvailability()
        {

        }

        public static void AvailableTrains()
        {

        }

        


    }
}
