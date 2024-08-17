using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Identity
{
    public class User : IdentityUser
    {
        public string Address { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime? BirthDay { get; set; }
    }
}