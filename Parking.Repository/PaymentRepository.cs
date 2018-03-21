using Parking.Repository.Entity;
using Parking.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository
{
    public class PaymentRepository: Repository <PaymentEntity>
    {
        public PaymentEntity GetPaymentById(int id)
        {
            return GetById(id);
        }

        public List<PaymentEntity> GetAllPayments()
        {
            return GetAll();
        }

        public int InsertPaymentEntity(PaymentEntity paymentEntity)
        {
            return Insert(paymentEntity);
        }

        public void UpdatePaymentEntity(PaymentEntity paymentEntity)
        {
            Update(paymentEntity);
        }

        public bool DeletePaymentEntity(int id)
        {
            return Detele(id);
        }
    }
}

