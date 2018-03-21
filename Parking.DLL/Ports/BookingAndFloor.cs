using Parking.Repository.Entity;
using Parking.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.DLL.Ports
{
    public abstract class BookingAndFloor
    {

    
        public virtual bool ParkingPlaceAvailabe(FloorEntity floor, BookingEntity booking)
        {
            if (floor.CountEmptyPlaces >= 1 || booking.ArrivalTime < floor.NextEmptyPlace)
            {
                return false;
            }
            return false;
        }

        public virtual bool CheckBookingNo(BookingEntity booking, CarEntity car)
        {
            if (booking.CarKey == car.CarKey)
                return true;
            return false;
        }

    }
}

