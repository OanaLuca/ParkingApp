using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Core.Models
{
    public class User
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Punctuality { get; set; }

        public bool? Loyalty { get; set; }

        public string CarKey { get; set; }

        public bool BookingOk { get; set; }

        public int Age { get; set; }
    }
}
