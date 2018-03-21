using Parking.DLL.Ports;
using Parking.Repository;
using Parking.Repository.Entity;
using System;
using Parking.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.DLL
{
    public class PaymentService : IPaymentServices
    {

        private readonly PaymentRepository _paymentRepository;

        public PaymentService(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }


        public void Save(PaymentEntity paymentEntity)
        {
            if (paymentEntity.ID == 0)
            {
                _paymentRepository.Insert(paymentEntity);
            }
            else
            {
                _paymentRepository.Update(paymentEntity);
            }
        }

       
        public bool CheckPaymentOK(Payment paymentInstance)
        {
            if (paymentInstance.CardCVC.Length == 3 && paymentInstance.CardNumber.Length == 16 && paymentInstance.CardExpirationYear.ToString().Length == 2 && paymentInstance.CardExpirationMonth.ToString().Length == 22)
                return true;
            else
                return false;
        }


        public Payment ConvertPayment(PaymentEntity paymentEntity)
        {
            var payment = new Payment();

            payment.Amount = paymentEntity.Amount;
            payment.CardCVC = paymentEntity.CardCVC;
            payment.CardExpirationMonth = payment.CardExpirationMonth;
            payment.CardExpirationYear = paymentEntity.CardExpirationYear;
            payment.CardNumber = payment.CardNumber;
            payment.ID = paymentEntity.ID;
            payment.PaymentTime = paymentEntity.PaymentTime;
            payment.UserId = paymentEntity.UserId ?? 0;
            payment.Currency = payment.Currency;
            return payment;

        }

        public void Delete(PaymentEntity payment)
        {
            if (payment.ID != 0)
            {
                _paymentRepository.Detele(payment.ID);
            }
            else
            {
                throw new Exception("Nothing to delete!");
            }
        }
    }
}
