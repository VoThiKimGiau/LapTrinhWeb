using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;

namespace WebBanSach.Areas.Admin.Controllers
{
    public class AuthorController : Controller
    {
        MyContext db = new MyContext();
        // GET: Admin/Author
        public ActionResult Index()
        {
            List<Author> authors = db.Authors.ToList();

            return View(authors);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Author au)
        {
            db.Authors.Add(au);
            db.SaveChanges();
            return RedirectToAction("/Index");
        }

        public ActionResult Edit(int id)
        {
            Author au = db.Authors.Where(row => row.AuthorID == id).FirstOrDefault();

            return View(au);
        }
        [HttpPost]
        public ActionResult Edit(Author au)
        {
            Author a = db.Authors.Where(row => row.AuthorID == au.AuthorID).FirstOrDefault();
            a.AuthorName = au.AuthorName;
            db.SaveChanges();
            return RedirectToAction("/Index");
        }

        public ActionResult Delete(int id)
        {
            Author au = db.Authors.Where(row => row.AuthorID == id).FirstOrDefault();

            return View(au);
        }
        [HttpPost]
        public ActionResult Delete(int id, Author au)
        {
           au = db.Authors.Where(row => row.AuthorID == id).FirstOrDefault();
            db.Authors.Remove(au);
            db.SaveChanges();

            return RedirectToAction("/Index");
        }
    }
}