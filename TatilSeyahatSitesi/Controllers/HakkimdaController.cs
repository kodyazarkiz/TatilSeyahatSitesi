using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSitesi.Models.Sınıflar;

namespace TatilSeyahatSitesi.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Hakkimizdas.ToList();
            return View(degerler);
        }

        public ActionResult HakkimdaSil(int id)
        {
            var hakkimda = c.Hakkimizdas.Find(id);
            c.Hakkimizdas.Remove(hakkimda);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult HakkimdaGetir(int id)
        {
            var hakkimda = c.Hakkimizdas.Find(id);
            return View("HakkimdaGetir", hakkimda);
        }
        [HttpPost]
        public ActionResult HakkimdaGetir(Hakkimizda p)
        {
            var hakkimda = c.Hakkimizdas.Find(p.ID);
            hakkimda.FotoURL = p.FotoURL;
            hakkimda.Aciklama = p.Aciklama;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}