using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [Required]
        public int ProId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public virtual Book Book { get; set; }
    }
}