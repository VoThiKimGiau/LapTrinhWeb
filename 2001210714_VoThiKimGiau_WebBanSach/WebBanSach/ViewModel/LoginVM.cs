using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebBanSach.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "UserName cannot be blank.")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password cannot be blank.")]
        public string Password { get; set; }
    }
}