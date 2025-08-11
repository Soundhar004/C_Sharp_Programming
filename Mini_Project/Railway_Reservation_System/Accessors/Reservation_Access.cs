using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_System.Accessors
{
    public class Reservation_Access
    {

        public int BookingId { get; set; }               // Auto-generated in DB
        public string PassengerName { get; set; }        // Passenger's full name
        public string FromStation { get; set; }          // Departure station
        public string ToStation { get; set; }            // Arrival station
        public DateTime TravelDate { get; set; }         // Date of travel
        public int SeatNo { get; set; }               // Seat number
        public string SeatType { get; set; }             // Seat type (AC, Sleeper, etc.)
        public DateTime BookingDate { get; set; }
        public Decimal TotalCost { get; set; }
        public bool IsCancelled { get; set; }
        public int TrainId { get; set; }
        public bool IsDeleted { get; set; }



    }
}
