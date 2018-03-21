using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parking.UI.Models.Payment
{
    public class PaymentModel
    {

        public int ID { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Full name")]
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        public DateTime PaymentTime { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Display(Name = "Card Number")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.CreditCard)]
        public string CardNumber { get; set; }

        [Display(Name = "Carc CVC")]
        [Required(ErrorMessage = "This field is required")]
        [Range(100, 999, ErrorMessage = "CVC format : aaa ")]
        public string CardCVC { get; set; }

        [Display(Name = "Expiration month")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]
        public DateTime CardExpiratioMonth { get; set; }

        [Display(Name = "Expiration date")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]
        public DateTime CardExpirationYear { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Currency)]
        public string Currency { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //public DateTime CardExpirationYear { get; set; }

    }
}