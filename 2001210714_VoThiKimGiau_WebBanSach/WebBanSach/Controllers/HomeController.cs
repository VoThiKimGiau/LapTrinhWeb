using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    public class HomeController : Controller
    {
        MyContext db = new MyContext();
        // GET: Home
        public ActionResult Index(string sort = "", int page = 1, string search = "")
        {
            List<Book> books = db.Books.Where(t => t.Name.Contains(search)).ToList();
            ViewBag.Search = search;
            //Sort
            ViewBag.sort = sort;
            switch (sort)
            {
                case "BookID":
                    {
                        books = books.OrderBy(t => t.BookID).ToList();
                        break;
                    }
                case "Name":
                    {
                        books = books.OrderBy(t => t.Name).ToList();
                        break;
                    }
                case "Price":
                    {
                        books = books.OrderBy(t => t.Price).ToList();
                        break;
                    }
                default:
                    break;
            }

            //Paging
            int NoRecordPerPage = 8;
            int NoPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(books.Count) / Convert.ToDouble(NoRecordPerPage)));
            int NoRecordToSkip = (page - 1) * NoRecordPerPage;

            ViewBag.Page = page;
            ViewBag.NoPages = NoPage;
            books = books.Skip(NoRecordToSkip).Take(NoRecordPerPage).ToList();

            return View(books);
        }

        public ActionResult Detail(int id)
        {
            Book book = db.Books.Where(t => t.BookID == id).FirstOrDefault();

            if (book == null)
                return RedirectToAction("/Index");

            return View(book);
        }
    }
}