using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSitesi.Controllers;
using TatilSeyahatSitesi.Models.Sınıflar;

namespace TatilSeyahatSitesi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Hakkimizdas.ToList();
            return View(degerler);
        }
    }
}