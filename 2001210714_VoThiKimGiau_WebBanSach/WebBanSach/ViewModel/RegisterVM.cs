using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebBanSach.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="UserName cannot be blank.")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password cannot be blank.")]
        public string Password { get; set; }


        [Required(ErrorMessage = "ConfirmPassword cannot be blank.")]
        [Compare("Password", ErrorMessage ="Password and ConfirmPassword do not match.")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Email cannot be blank.")]
        [EmailAddress(ErrorMessage ="Invaild Email.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "PhoneNumber cannot be blank.")]
        public string PhoneNumber { get; set; }

        [DisplayFormat(DataFormatString ="{0: dd/MM/yyyy}")]
        public DateTime? DateOfBirth { get; set; }


        [Required(ErrorMessage = "Address cannot be blank.")]
        public string Address { get; set; }
    }
}