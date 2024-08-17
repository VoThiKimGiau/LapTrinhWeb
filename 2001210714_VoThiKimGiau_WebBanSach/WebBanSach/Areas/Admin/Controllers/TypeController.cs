using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;

namespace WebBanSach.Areas.Admin.Controllers
{
    public class TypeController : Controller
    {
        MyContext db = new MyContext();
        // GET: Admin/Type
        public ActionResult Index()
        {
            List<TypeB> types = db.Types.ToList();

            return View(types);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TypeB type)
        {
            db.Types.Add(type);
            db.SaveChanges();
            return RedirectToAction("/Index");
        }
        public ActionResult Edit(int id)
        {
            TypeB type = db.Types.Where(row => row.TypeID == id).FirstOrDefault();

            return View(type);
        }
        [HttpPost]
        public ActionResult Edit(TypeB type)
        {
            TypeB t = db.Types.Where(row => row.TypeID == type.TypeID).FirstOrDefault();
            t.TypeName = type.TypeName;
            db.SaveChanges();
            return RedirectToAction("/Index");
        }
        public ActionResult Delete(int id)
        {
            TypeB type = db.Types.Where(row => row.TypeID == id).FirstOrDefault();

            return View(type);
        }
        [HttpPost]
        public ActionResult Delete(int id, TypeB type)
        {
            type = db.Types.Where(row => row.TypeID == id).FirstOrDefault();
            db.Types.Remove(type);
            db.SaveChanges();

            return RedirectToAction("/Index");
        }
    }
}