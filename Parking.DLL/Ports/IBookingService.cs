using Parking.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.DLL.Ports
{
    public interface IBookingService
    {
        void CheckDetails(BookingEntity booking);
        void SaveBooking(BookingEntity booking);
        void DeletBooking(BookingEntity booking);


    }
}
