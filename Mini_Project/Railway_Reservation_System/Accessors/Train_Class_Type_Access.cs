using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_System.Accessors
{
    class Train_Class_Type_Access
    {
        public int AvailabilityId { get; set; }
        public int TrainId { get; set; }
        public string ClassType { get; set; }
        public int MaxSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal CostPerSeat { get; set; }

    }
}
