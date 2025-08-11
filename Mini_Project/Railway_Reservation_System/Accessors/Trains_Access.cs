using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_System.Accessors
{
    public class Trains_Access
    {
        public int TrainID { get; set; }
        public string TrainNumber { get; set; }
        public string TrainName { get; set; }
        public string SourceStation { get; set; }
        public string DestinationStation { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public DateTime TravelDate { get; set; }
        public string Duration { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal Fare { get; set; }
        public string TrainType { get; set; }
        public string Status { get; set; }
        public string IsDeleted { get; set; }

    }
}
