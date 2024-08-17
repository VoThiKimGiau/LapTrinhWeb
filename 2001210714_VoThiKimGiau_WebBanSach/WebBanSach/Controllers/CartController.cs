using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    public class CartController : Controller
    {
        MyContext db = new MyContext();
        // GET: Carts
        public ActionResult Index()
        {
            List<Cart> Carts = db.Carts.ToList();

            return View(Carts);
        }
        public ActionResult Add(int id = 0)
        {
            if (id > 0)
            {              
                Cart CartsItem = db.Carts.Where(Carts => Carts.ProId == id).FirstOrDefault();
                if (CartsItem != null)
                {
                    CartsItem.Quantity += 1;
                }
                else
                {
                    Cart Carts = new Cart();
                    Carts.ProId = id;
                    Carts.Quantity = 1;
                    Carts.Book = db.Books.Where(t => t.BookID == id).FirstOrDefault();
                    db.Carts.Add(Carts);
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult UpdateQuantity(int quan = 0, int proid = 0)
        {
            if (quan > 0)
            {
                Cart CartsItem = db.Carts.Where(Carts => Carts.ProId == proid).FirstOrDefault();
                if (CartsItem != null)
                {
                    CartsItem.Quantity = quan;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Cart cart = db.Carts.Where(row => row.Book.BookID == id).FirstOrDefault();

            return View(cart);
        }
        [HttpPost]
        public ActionResult Delete(int id, Cart cart)
        {
            cart = db.Carts.Where(row => row.Book.BookID == id).FirstOrDefault();
            db.Carts.Remove(cart);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}