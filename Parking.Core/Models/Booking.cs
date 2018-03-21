using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Core.Models
{
   public class Booking
    {
        public int ID { get; set; }

        public int UserId { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public DateTime? ParkingTime { get; set; }

        public string CarKey { get; set; }
    }
}
