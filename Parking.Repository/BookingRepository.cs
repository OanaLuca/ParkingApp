using Parking.Repository.Entity;
using Parking.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository
{
    public class BookingRepository: Repository<BookingEntity>
    {
        public BookingEntity GetBookingById(int id)
        {
            return GetById(id);
        }

        public List<BookingEntity> GetAllBookings()
        {
            return GetAll();
        }

        public int InsertBookingEntity(BookingEntity bookingEntity)
        {
            return Insert(bookingEntity);
        }

        public void UpdateBookingEntity(BookingEntity bookingEntity)
        {
            Update(bookingEntity);
        }

        public bool DeleteBookingEntity(int id)
        {
            return Detele(id);
        }
    }
}
