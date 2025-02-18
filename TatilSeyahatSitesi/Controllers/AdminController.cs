using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSitesi.Models.Sınıflar;
namespace TatilSeyahatSitesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult BlogGetir(int id)
        {
            var blog = c.Blogs.Find(id);
            return View("BlogGetir", blog);
        }
        [HttpPost]
        public ActionResult BlogGuncelle(Blog p)
        {
            var blog = c.Blogs.Find(p.ID);
            blog.Aciklama = p.Aciklama;
            blog.Baslik = p.Baslik;
            blog.BlogImage = p.BlogImage;
            blog.Tarih = p.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var yorum = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(yorum);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var yorum = c.Yorumlars.Find(id);
            return View("YorumGetir", yorum);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yorum = c.Yorumlars.Find(y.ID);
            yorum.KullaniciAdi = y.KullaniciAdi;
            yorum.Mail = y.Mail;
            yorum.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult Adres()
        {
            var Adres = c.Adres.ToList();
            return View(Adres);
        }

        public ActionResult AdresSil(int id)
        {
            var Adres = c.Adres.Find(id);
            c.Adres.Remove(Adres);
            c.SaveChanges();
            return RedirectToAction("Adres");
        }
        [HttpGet]
        public ActionResult AdresGetir(int id)
        {
            var Adres = c.Adres.Find(id);
            return View("AdresGetir", Adres);
        }
        [HttpPost]
        public ActionResult AdresGetir(Adres y)
        {
            var Adres = c.Adres.Find(y.ID);
            Adres.Baslik = y.Baslik;
            Adres.AdresAcik = y.AdresAcik;
            Adres.Mail = y.Mail;
            Adres.Telefon = y.Telefon;
            Adres.Konum= y.Konum;
            c.SaveChanges();
            return RedirectToAction("Adres");
        }

        public ActionResult İletisim()
        {
            var iletisim = c.İletisims.ToList();
            return View(iletisim);
        }

        public ActionResult iletisimSil(int id)
        {
            var iletisim = c.İletisims.Find(id);
            c.İletisims.Remove(iletisim);
            c.SaveChanges();
            return RedirectToAction("iletisim");
        }
        [HttpGet]
        public ActionResult iletisimGetir(int id)
        {
            var iletisim = c.İletisims.Find(id);
            return View("iletisimGetir", iletisim);
        }
        [HttpPost]
        public ActionResult iletisimGetir(İletisim y)
        {
            var iletisim = c.İletisims.Find(y.ID);
            iletisim.AdSoyad = y.AdSoyad;
            iletisim.Mail = y.Mail;
            iletisim.Konu = y.Konu;
            iletisim.Mesaj = y.Mesaj;
            c.SaveChanges();
            return RedirectToAction("İletisim");
        }
    }
}