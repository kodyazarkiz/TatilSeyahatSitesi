using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSitesi.Controllers;
using TatilSeyahatSitesi.Models.Sınıflar;
using Context = TatilSeyahatSitesi.Models.Sınıflar.Context;

namespace TatilSeyahatSitesi.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context db = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            //var bloglar = db.Blogs.ToList();
            by.Deger1 = db.Blogs.ToList();
            by.Deger3 = db.Blogs.Take(8).ToList();
            return View(by);
        }
        public ActionResult BlogDetay(int ID)
        {
            //var blogbul = db.Blogs.Where(x => x.ID == id).ToList();
            by.Deger1 = db.Blogs.Where(x => x.ID == ID).ToList();
            by.Deger2 = db.Yorumlars.Where(x => x.Blogid == ID).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int ID)
        {
            ViewBag.deger = ID;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            db.Yorumlars.Add(y);
            db.SaveChanges();
            return PartialView("Index");
        }
    }
}