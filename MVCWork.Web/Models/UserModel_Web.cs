using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWork.Web.Models
{
    public class UserModel_Web
    {
        public int UserId { get; set; }


        //[DisplayName("Identity Number")]
        //[Required(ErrorMessage = "UserIDCard is required")]
        [DisplayName("IDcard Number")]
        public int UserIDCard { get; set; }

        [DisplayName("IDcard Type")]
        public int IDCardTypeID { get; set; }

        [DisplayName("Full Name")]
        [RegularExpression("^[a-zA-Z0-9].{0,49}$", ErrorMessage = "No blank at first, length should suitable")]
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        public string Password_FirstInput { get; set; }

        [DisplayName("Input twice to Confirm Password")]
        [Compare("Password_FirstInput", ErrorMessage ="two input should be the same")]
        public string Password_ConfirmInput { get; set; }
        public DateTime CreateTime { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("PhoneNumber")]
        [RegularExpression("\\d{11}", ErrorMessage = "Please input 11 numbers")]
        public string PhoneNumber { get; set; }

    }
}