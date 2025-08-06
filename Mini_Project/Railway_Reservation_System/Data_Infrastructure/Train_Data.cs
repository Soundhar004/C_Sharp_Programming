using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Railway_Reservation_System.Accessors;
using Railway_Reservation_System.Templates;
using Railway_Reservation_System.Data_Infrastructure;

namespace Railway_Reservation_System.Data_Infrastructure
{
    public class Train_Data
    {



        public List<Trains_Access> ViewAllTrains()
        {
            try
            {
                List<Trains_Access> trains = new List<Trains_Access>();
                using (SqlConnection conn = db_connection.CreateConnection())
                {
                    var cmd = new SqlCommand("SELECT * FROM Trains WHERE IsDeleted = 0", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        trains.Add(new Trains_Access
                        {
                            TrainID = (int)reader["TrainID"],
                            TrainNumber = reader["TrainNumber"].ToString(),
                            TrainName = reader["TrainName"].ToString(),
                            SourceStation = reader["SourceStation"].ToString(),
                            DestinationStation = reader["DestinationStation"].ToString(),
                            DepartureTime = (TimeSpan)reader["DepartureTime"],
                            ArrivalTime = (TimeSpan)reader["ArrivalTime"],
                            TravelDate = (DateTime)reader["TravelDate"],
                            Duration = reader["Duration"].ToString(),
                            TotalSeats = (int)reader["TotalSeats"],
                            AvailableSeats = (int)reader["AvailableSeats"],
                            Fare = (decimal)reader["Fare"],
                            TrainType = reader["TrainType"].ToString(),
                            Status = reader["Status"].ToString()
                        });
                    }

                    return trains;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Some Error : {e.Message}");
                return null;
            }
        }

       
        public void GetDataForAddTrain()
        {
            Trains_Access train = new Trains_Access();
            Console.WriteLine("Enter Train ID:");
            train.TrainID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Train Number:");
            train.TrainNumber = Console.ReadLine();
            Console.WriteLine("Enter Train Name:");
            train.TrainName = Console.ReadLine();
            Console.WriteLine("Enter Source Station:");
            train.SourceStation = Console.ReadLine();
            Console.WriteLine("Enter Destination Station:");
            train.DestinationStation = Console.ReadLine();
            Console.WriteLine("Enter Departure Time (HH:mm):");
            train.DepartureTime = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine("Enter Arrival Time (HH:mm):");
            train.ArrivalTime = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine("Enter Travel Date (yyyy-MM-dd):");
            train.TravelDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Duration:");
            train.Duration = Console.ReadLine();
            Console.WriteLine("Enter Total Seats:");
            train.TotalSeats = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Available Seats:");
            train.AvailableSeats = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Fare:");
            train.Fare = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Train Type:");
            train.TrainType = Console.ReadLine();
            Console.WriteLine("Enter Status:");
            train.Status = Console.ReadLine();
            Train_Data.AddTrain(train);

        }

        public static void AddTrain(Trains_Access train)
        {
            using (SqlConnection conn = db_connection.CreateConnection())
            {
                string query = @"INSERT INTO Trains 
                                (TrainNumber, TrainName, SourceStation, DestinationStation,
                                DepartureTime, ArrivalTime, TravelDate, Duration, TotalSeats,
                                AvailableSeats, Fare, TrainType, Status, IsDeleted)
                                VALUES 
                                (@TrainNumber, @TrainName, @SourceStation, @DestinationStation,
                                @DepartureTime, @ArrivalTime, @TravelDate, @Duration, @TotalSeats,
                                @AvailableSeats, @Fare, @TrainType, @Status, @IsDeleted)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrainNumber", train.TrainNumber);
                    cmd.Parameters.AddWithValue("@TrainName", train.TrainName);
                    cmd.Parameters.AddWithValue("@SourceStation", train.SourceStation);
                    cmd.Parameters.AddWithValue("@DestinationStation", train.DestinationStation);
                    cmd.Parameters.AddWithValue("@DepartureTime", train.DepartureTime);
                    cmd.Parameters.AddWithValue("@ArrivalTime", train.ArrivalTime);
                    cmd.Parameters.AddWithValue("@TravelDate", train.TravelDate);
                    cmd.Parameters.AddWithValue("@Duration", train.Duration);
                    cmd.Parameters.AddWithValue("@TotalSeats", train.TotalSeats);
                    cmd.Parameters.AddWithValue("@AvailableSeats", train.AvailableSeats);
                    cmd.Parameters.AddWithValue("@Fare", train.Fare);
                    cmd.Parameters.AddWithValue("@TrainType", train.TrainType);
                    cmd.Parameters.AddWithValue("@Status", train.Status);
                    cmd.Parameters.AddWithValue("@IsDeleted", 0); // default not deleted
                    cmd.ExecuteNonQuery();
                }
            }










        }
    }
}
