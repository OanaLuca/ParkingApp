using Parking.Core.Models;
using Parking.DLL;
using Parking.UI.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parking.Repository.Entity;
using Parking.Repository;

namespace Parking.UI.Controllers
{
    public class BookingController : Controller
    {

        private readonly BookingService bookingServiceModel;


        public BookingController(BookingService booking)
        {
            bookingServiceModel = booking;
        }

        [HttpGet]
        public ActionResult AddOrEditBooking(int id = 0)
        {
            BookingModel bookingModel = new BookingModel();
            return View(bookingModel);
        }


        [HttpPost]
        public ActionResult AddOrEditBooking(BookingModel bookingModel)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {

                var bllBooking = ConvertToBLL(bookingModel);
                var entityBooking = ConvertFromBLLToRepo(bllBooking);

                bookingServiceModel.SaveBooking(entityBooking);
                
                //  return RedirectToAction("BookingInfo");

                ViewBag.SuccessMessage = "Booking Completed";
                return View("AddOrEditBooking", new BookingModel());
            }
            else
            {
                ViewBag.ErrorMessage = "Unable to complete booking";
                return View("AddOrEditBooking", new BookingModel());
            }


        }


        [HttpGet]
        public ActionResult DetailsBooking()
        {

         
            return View();
        }


#region Private Methods


        private BookingEntity ConvertFromBLLToRepo(Booking bookingBll)
        {
            var repoBooking = new BookingEntity();

            {
                repoBooking.ArrivalTime = bookingBll.ArrivalTime;
                repoBooking.CarKey = bookingBll.CarKey;
                repoBooking.ID = bookingBll.ID;
                repoBooking.ParkingTime = bookingBll.ParkingTime;
                repoBooking.UserId = bookingBll.UserId;

            }

            return repoBooking;
        }



        private Booking ConvertToBLL(BookingModel model)
        {
            var bllModel = new Booking();

            bllModel.ArrivalTime = model.ArrivalTime;
            bllModel.CarKey = model.CarKey;
            bllModel.ID = model.ID;
            bllModel.ParkingTime = model.ParkingTime;
            bllModel.UserId = model.UserId;

            return bllModel;

        }
    }

#endregion
}