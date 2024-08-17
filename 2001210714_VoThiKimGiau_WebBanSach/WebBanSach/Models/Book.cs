using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }


        [Required]
        public string Name { get; set; }


        [Required]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Price { get; set; }

        public string Detail { get; set; }


        [Required]
        public int NO_Goods { get; set; }


        [Required]
        public int TypeID { get; set; }


        [Required]
        public int AuthorID { get; set; }


        public string Image { get; set; }

        public virtual Author Author { get; set; }
        public virtual TypeB Type { get; set; }

    }
}