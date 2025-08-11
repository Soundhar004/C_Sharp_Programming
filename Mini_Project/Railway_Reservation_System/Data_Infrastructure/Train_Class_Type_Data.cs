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
    class Train_Class_Type_Data
    {

        private bool IsValidClassType(string classType)
        {
            var validTypes = new List<string> { "Sleeper", "2nd AC", "3rd AC" };
            return validTypes.Contains(classType);
        }
        public bool AddClassAvailability(Train_Class_Type_Access availability)
        {
            if (!IsValidClassType(availability.ClassType))
                throw new ArgumentException("Invalid class type.");

            using (SqlConnection conn = db_connection.CreateConnection())
            {
                string query = @"INSERT INTO TrainClasses
                                 (TrainId, ClassType, MaxSeats, AvailableSeats, CostPerSeat, IsActive)
                                 VALUES (@TrainId, @ClassType, @MaxSeats, @AvailableSeats, @CostPerSeat, 1)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrainId", availability.TrainId);
                    cmd.Parameters.AddWithValue("@ClassType", availability.ClassType);
                    cmd.Parameters.AddWithValue("@MaxSeats", availability.MaxSeats);
                    cmd.Parameters.AddWithValue("@AvailableSeats", availability.AvailableSeats);
                    cmd.Parameters.AddWithValue("@CostPerSeat", availability.CostPerSeat);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SQL Error (AddClassAvailability): " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public Train_Class_Type_Access GetAvailability(int trainId, string classType)
        {
            if (!IsValidClassType(classType))
                throw new ArgumentException("Invalid class type.");

            using (SqlConnection conn = db_connection.CreateConnection())
            {
                string query = @"SELECT * FROM TrainClasses 
                                 WHERE TrainId = @TrainId AND ClassType = @ClassType AND IsActive = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.Parameters.AddWithValue("@ClassType", classType);

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Train_Class_Type_Access
                                {
                                    /*AvailabilityId = Convert.ToInt32(reader["AvailabilityId"]),*/
                                    TrainId = Convert.ToInt32(reader["TrainId"]),
                                    ClassType = reader["ClassType"].ToString(),
                                    MaxSeats = Convert.ToInt32(reader["MaxSeats"]),
                                    AvailableSeats = Convert.ToInt32(reader["AvailableSeats"]),
                                    CostPerSeat = Convert.ToDecimal(reader["CostPerSeat"])
                                };
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SQL Error (GetAvailability): " + ex.Message);
                    }
                }
                return null;
            }
        }

        public bool UpdateAvailableSeats(int trainId, string classType, int seatsToBook)
        {
            if (!IsValidClassType(classType))
                throw new ArgumentException("Invalid class type.");

            using (SqlConnection conn = db_connection.CreateConnection())
            {
                string query = @"UPDATE TrainClasses 
                                 SET AvailableSeats = AvailableSeats - @SeatsToBook 
                                 WHERE TrainId = @TrainId AND ClassType = @ClassType AND AvailableSeats >= @SeatsToBook AND IsActive = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.Parameters.AddWithValue("@ClassType", classType);
                    cmd.Parameters.AddWithValue("@SeatsToBook", seatsToBook);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SQL Error (UpdateAvailableSeats): " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool RestoreSeats(int trainId, string classType, int seatsToRestore)
        {
            if (!IsValidClassType(classType))
                throw new ArgumentException("Invalid class type.");

            using (SqlConnection conn = db_connection.CreateConnection())
            {
                string query = @"UPDATE TrainClasses 
                                 SET AvailableSeats = AvailableSeats + @SeatsToRestore 
                                 WHERE TrainId = @TrainId AND ClassType = @ClassType AND IsActive = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.Parameters.AddWithValue("@ClassType", classType);
                    cmd.Parameters.AddWithValue("@SeatsToRestore", seatsToRestore);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SQL Error (RestoreSeats): " + ex.Message);
                        return false;
                    }
                }
            }
        }

    }
}
