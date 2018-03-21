using Parking.Core.Models;
using Parking.DLL;
using Parking.Repository.Entity;
using Parking.UI.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parking.UI.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        private readonly PaymentService paymentServiceModel;


        public PaymentController(PaymentService payment)
        {
            paymentServiceModel = payment;
        }

        [HttpGet]
        public ActionResult Payment(int id=0)
        {
            PaymentModel paymentModel = new PaymentModel();
            return View(paymentModel);
            
        }

        [HttpPost]
        public ActionResult Payment(PaymentModel paymentModel)
        {
            PaymentModel model = new PaymentModel();
            if (ModelState.IsValid)
            {
                var bllPayment = ConvertToBLLPayment(paymentModel);
                var entityPayment = ConvertFromBLLToRepo(bllPayment);

                entityPayment.CardExpirationMonth = DateTime.Now;
                entityPayment.CardExpirationYear = DateTime.Now;
                entityPayment.PaymentTime = DateTime.Now;
                entityPayment.UserId = entityPayment.UserId == 0 ? (int?)null : entityPayment.UserId;

                paymentServiceModel.Save(entityPayment);


                ViewBag.SuccessMessage = "Payment completed";
                return View("Payment", new PaymentModel());
            }

            else
                ViewBag.ErrorMessage = "Failed";
            return View("Payment", new PaymentModel());
        }


#region Private Methods
        private Payment ConvertToBLLPayment(PaymentModel paymentEntity)
        {
            var payment = new Payment();

            payment.Amount = paymentEntity.Amount;
            payment.CardCVC = paymentEntity.CardCVC;
            payment.CardExpirationMonth = payment.CardExpirationMonth;
            payment.CardExpirationYear = paymentEntity.CardExpirationYear;
            payment.CardNumber = payment.CardNumber;
            payment.ID = paymentEntity.ID;
            payment.PaymentTime = paymentEntity.PaymentTime;
            payment.UserId = paymentEntity.UserId;
            payment.Currency = payment.Currency;
            return payment;

        }

        private PaymentEntity ConvertFromBLLToRepo(Payment paymentModel)
        {
            var pay = new PaymentEntity();


            pay.Amount = paymentModel.Amount;
            pay.CardCVC = paymentModel.CardCVC;
            pay.CardExpirationMonth = paymentModel.CardExpirationMonth;
            pay.CardExpirationYear = paymentModel.CardExpirationYear;
            pay.CardNumber = paymentModel.CardNumber;
            pay.Currency = paymentModel.Currency;
            pay.ID = paymentModel.ID;
            pay.PaymentTime = paymentModel.PaymentTime;
            pay.UserId = paymentModel.UserId;

            return pay;
        }
    }

#endregion
}