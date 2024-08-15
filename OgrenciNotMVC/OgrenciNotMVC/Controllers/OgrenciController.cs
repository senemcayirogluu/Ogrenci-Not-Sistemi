using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class OgrenciController : Controller
    {
        MvcOkulDBEntities db= new MvcOkulDBEntities();  
        public ActionResult Index()
        {
            var ogrenci = db.TBLOGRENCILER.ToList();
            return View(ogrenci);
        }
        [HttpGet]

        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                            select new SelectListItem
                                            {
                                                Text=i.KULUPAD,
                                                Value=i.KULUPID.ToString()
                                            }).ToList();
            ViewBag.dgr = degerler;   
            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER p3)
        {
            var klp= db.TBLKULUPLER.Where(m=>m.KULUPID==p3.TBLKULUPLER.KULUPID).FirstOrDefault();
            p3.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(p3);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenciler = db.TBLOGRENCILER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("OgrenciGetir", ogrenciler);
        }
        public ActionResult Guncelle(TBLOGRENCILER p1)
        {
            var ogr = db.TBLOGRENCILER.Find(p1.OGRENCIID);
            ogr.OGRAD = p1.OGRAD;
            ogr.OGRSOYAD = p1.OGRSOYAD;
            ogr.OGRFOTO = p1.OGRFOTO;
            ogr.OGRCINSIYET = p1.OGRCINSIYET;
            ogr.OGRKULUP = p1.TBLKULUPLER.KULUPID;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }

    }
}


//List<SelectListItem> items = new List<SelectListItem>();

//items.Add(new SelectListItem { Text = "Matematik", Value = "0" });

//items.Add(new SelectListItem { Text = "Fen Bilgisi", Value = "1" });

//items.Add(new SelectListItem { Text = "Atatürk İlke ve İnkılapları", Value = "2" });

//items.Add(new SelectListItem { Text = "Coğrafya", Value = "3" });

//items.Add(new SelectListItem { Text = "Edebiyat", Value = "4" });

//ViewBag.DersAd = items;

