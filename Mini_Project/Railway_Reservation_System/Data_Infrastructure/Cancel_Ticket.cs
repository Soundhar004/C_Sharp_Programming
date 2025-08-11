using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Railway_Reservation_System.Templates;
using Railway_Reservation_System.Accessors;

namespace Railway_Reservation_System.Data_Infrastructure
{
    class Cancel_Ticket
    {
        public bool  CancelTheTicket(int bookingid, decimal totalcost)
        {
            decimal refundAmount = totalcost * 0.5m;

            try
            {
                using (SqlConnection conn = db_connection.CreateConnection())
                {
                    // Insert cancellation record
                    string query = @"INSERT INTO Cancellations 
                        (BookingId, RefundAmount, CancellationDate, TicketCancelled) 
                        VALUES (@BookingId, @RefundAmount, @CancellationDate, 1)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@BookingId", bookingid);
                        command.Parameters.AddWithValue("@RefundAmount", refundAmount);
                        command.Parameters.AddWithValue("@CancellationDate", DateTime.Now);

                        int rowsAffected = command.ExecuteNonQuery();

                        // Update reservation status
                        string updateQuery = @"UPDATE Reservation SET IsCancelled = 1 WHERE BookingId = @BookingId";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@BookingId", bookingid);
                            updateCmd.ExecuteNonQuery();
                        }

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error While Cancelling the Ticket : " + ex.Message);
                return false;
            }
        }

       

        public List<Cancel_Access> GetCancelledTickets()
        {

            List<Cancel_Access> cancelaccess = new List<Cancel_Access>();
            try
            {
                using (SqlConnection conn = db_connection.CreateConnection())
                {
                    string query = "SELECT * FROM Cancellations";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                cancelaccess.Add(new Cancel_Access
                                {
                                    CancellationId = Convert.ToInt32(reader["CancellationId"]),
                                    BookingId = Convert.ToInt32(reader["BookingId"]),
                                    RefundAmount = Convert.ToDecimal(reader["RefundAmount"]),
                                    CancellationDate = Convert.ToDateTime(reader["CancellationDate"]),
                                    TicketCancelled = Convert.ToBoolean(reader["TicketCancelled"])
                                });
                               /* return new Cancel_Access
                                {
                                    CancellationId = Convert.ToInt32(reader["CancellationId"]),
                                    BookingId = Convert.ToInt32(reader["BookingId"]),
                                    RefundAmount = Convert.ToDecimal(reader["RefundAmount"]),
                                    CancellationDate = Convert.ToDateTime(reader["CancellationDate"]),
                                    TicketCancelled = Convert.ToBoolean(reader["TicketCancelled"])
                                };*/
                            }
                            return cancelaccess;
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while fetching cancellation details: " + ex.Message);
                return null;
            }
        }


        public bool DeleteTheTicket(int bookingId)
        {
            try
            {
                using (SqlConnection conn = db_connection.CreateConnection())
                {
                    string query = "UPDATE Reservation SET IsDeleted = 1 WHERE BookingId = @BookingId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookingId", bookingId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while deleting the Ticket: " + ex.Message);
                return false;
            }
        }









    }
}
