using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Core.Models
{
   public class Elevator
    {
        public int ID { get; set; }

        public int CountCars { get; set; }

        public string CarKey { get; set; }

        public DateTime BroughtHere { get; set; }

        public DateTime TimeSpent { get; set; }

        public bool PaymentVerification { get; set; }

        public bool Available { get; set; }

        public int ElevatorNumber { get; set; }
    }
}
