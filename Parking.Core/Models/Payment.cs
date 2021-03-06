﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Core.Models
{
   public class Payment
    {
        public int ID { get; set; }

        public int UserId { get; set; }

        public DateTime PaymentTime { get; set; }

        public decimal Amount { get; set; }

        public string CardNumber { get; set; }

        public string CardCVC { get; set; }

        public DateTime CardExpirationMonth { get; set; }

        public string Currency { get; set; }

        public DateTime CardExpirationYear { get; set; }
    }
}
