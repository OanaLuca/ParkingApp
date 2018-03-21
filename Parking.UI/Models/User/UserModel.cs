using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parking.UI.Models.User
{
    public class UserModel
    {
        public int ID { get; set; }


        [Display(Name = "Fisrt Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your first name")]
        [StringLength(50, ErrorMessage = "Length cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your last name")]
        [StringLength(50, ErrorMessage = "Length cannot exceed 50 characters")]
        public string LastName { get; set; }


        [Display(Name = "UserName")]
        [Index(IsUnique = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a username")]
        [StringLength(50, ErrorMessage = "Length cannot exceed 50 characters")]
        
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide password")]
        [StringLength(50, ErrorMessage = "Length cannot exceed 50 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please confirm passowrd")]
        [StringLength(50, ErrorMessage = "Length cannot exceed 50 characters")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Age")]
        [Range(18, 100, ErrorMessage = "You must be older than 18 and younger than 100")]
        public int Age { get; set; }



        public bool Punctuality { get; set; }

        public bool? Loyalty { get; set; }

        public string CarKey { get; set; }

        public bool BookingOk { get; set; }

      

    }
}
