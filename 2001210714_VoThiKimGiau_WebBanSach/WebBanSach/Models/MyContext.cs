using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebBanSach.Models
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyConnection") { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<TypeB> Types { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}