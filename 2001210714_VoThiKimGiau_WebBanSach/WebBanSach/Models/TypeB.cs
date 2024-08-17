using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    public class TypeB
    {
        [Key]
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<Book> Book { get; set; }
    }
}