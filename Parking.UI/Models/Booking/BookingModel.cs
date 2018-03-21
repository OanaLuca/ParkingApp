using Parking.UI.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parking.UI.Models.Booking
{
    public class BookingModel
    {


        [Required(ErrorMessage ="This field is required")]
        public string Name { get; set; }

        public int ID { get; set; }

        public int UserId { get; set; }

        public string BookedParkingSpot { get; set; } = "123BZZX67";

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "This field is required")]
        public DateTime? ArrivalTime { get; set; }


        [DataType(DataType.Time)]
        [Required(ErrorMessage = "This field is required")]
        public DateTime? ParkingTime { get; set; }

      
        [Required(ErrorMessage = "This field is required")]
        public string CarKey { get; set; }

  

    }
}