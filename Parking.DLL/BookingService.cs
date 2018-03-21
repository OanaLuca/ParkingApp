using Parking.DLL.Ports;
using Parking.Repository;
using System;
using Parking.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Repository.Entity;

namespace Parking.DLL
{
    public class BookingService : BookingAndFloor,IBookingService
    {

        private readonly BookingRepository _bookingRepository;

        public BookingService(BookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public object GetBookId(int id)
        {
            return _bookingRepository.GetBookingById(id);
        }

        public Booking GetBookingEntityById(int id)
        {
            var bookingEntity = _bookingRepository.GetBookingById(id);
            return ConvertToBooking(bookingEntity);

        }

       

        public void SaveBooking(BookingEntity booking)
        {
            FloorEntity floor = new FloorEntity();
            CarEntity car = new CarEntity();
            if ((ParkingPlaceAvailabe(floor, booking) == true) && booking.ID == 0 && floor.BookedPlace == "empty")
            {

                _bookingRepository.Insert(booking);
            }
            else
            if (CheckBookingNo(booking, car) == true)
            {

                _bookingRepository.Update(booking);
            }
        }


        public Booking ConvertToBooking(BookingEntity bookingEntity)
        {
            var booking = new Booking();

            booking.ID = bookingEntity.ID;
            booking.ArrivalTime = bookingEntity.ArrivalTime;
            booking.CarKey = bookingEntity.CarKey;
            booking.ParkingTime = bookingEntity.ParkingTime;
            booking.UserId = bookingEntity.UserId;

            return booking;
        }

        public void CheckDetails(BookingEntity booking)
        {
            var bDetails = new Booking();
            if (bDetails.ParkingTime != null && bDetails.ArrivalTime != null)
            {
                SaveBooking(booking);
            }
            else
                Console.WriteLine("Please proivde all details");

        }

        public void DeletBooking(BookingEntity booking)
        {
            if (booking.ID != 0)
            {
                _bookingRepository.Detele(booking.ID);
            }
            else
            {
                throw new Exception("Nothing to delete!");
            }

        }
       


    }
}
