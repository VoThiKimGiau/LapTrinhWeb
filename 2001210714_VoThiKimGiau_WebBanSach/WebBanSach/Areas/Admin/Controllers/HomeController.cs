using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;

namespace WebBanSach.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        MyContext db = new MyContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            List<Book> books = db.Books.ToList();
            return View(books);
        }
        public ActionResult Create()
        {
            ViewBag.Au = db.Authors.ToList();
            ViewBag.Type = db.Types.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    if (imageFile.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Image", "Kích thước file phải nhỏ hơn 2MB.");
                        return View();
                    }

                    var allowEx = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(imageFile.FileName).ToLower();
                    if (!allowEx.Contains(fileEx))
                    {
                        ModelState.AddModelError("Image", "Chỉ chấp nhận file ảnh jpg hoặc png.");
                        return View();
                    }

                    book.Image = "";
                    db.Books.Add(book);
                    db.SaveChanges();

                    Book book1 = db.Books.ToList().Last();

                    var fileName = book1.BookID.ToString() + fileEx;
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    imageFile.SaveAs(path);

                    book1.Image = fileName;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    book.Image = "/Images/no_image.jpg";
                    db.Books.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            Book book = db.Books.Where(row => row.BookID == id).FirstOrDefault();
            ViewBag.Au = db.Authors.ToList();
            ViewBag.Type = db.Types.ToList();

            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            Book b = db.Books.Where(row => row.BookID == book.BookID).FirstOrDefault();
            b.Name = book.Name;
            b.Price = book.Price;
            b.Detail = book.Detail;
            b.NO_Goods = book.NO_Goods;
            b.AuthorID = book.AuthorID;
            b.TypeID = book.TypeID;

            db.SaveChanges();
            return RedirectToAction("/Index");
        }
        public ActionResult Delete(int id)
        {
            Book book = db.Books.Where(row => row.BookID == id).FirstOrDefault();

            return View(book);
        }
        [HttpPost]
        public ActionResult Delete(int id, Book book)
        {
            book = db.Books.Where(row => row.BookID == id).FirstOrDefault();
            db.Books.Remove(book);
            db.SaveChanges();

            return RedirectToAction("/Index");
        }
    }
}