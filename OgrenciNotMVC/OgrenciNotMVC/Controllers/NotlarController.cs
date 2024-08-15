using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;
using OgrenciNotMVC.Models;

namespace OgrenciNotMVC.Controllers
{
    public class NotlarController : Controller
    {
        MvcOkulDBEntities db = new MvcOkulDBEntities();
        public ActionResult Index()
        {
            var notlar = db.TBLNOTLAR.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult YeniNot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniNot(TBLNOTLAR tbn)
        {
            db.TBLNOTLAR.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var not = db.TBLNOTLAR.Find(id);
            return View("NotGetir", not);
        }
        [HttpPost]
        public ActionResult NotGetir(Class1 model, TBLNOTLAR p, int SINAV1 = 0, int SINAV2 = 0, int SINAV3 = 0,
            int PROJE = 0)
        {
            if (model.islem == "Hesapla")
            {
                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ORTALAMA;

                var DURUM = ORTALAMA >= 60 ? "True" : "False";
                ViewBag.durum = DURUM;

            }
            if (model.islem == "NotGuncelle")
            {
                var not2 = db.TBLNOTLAR.Find(p.NOTID);
                not2.SINAV1 = p.SINAV1;
                not2.SINAV2 = p.SINAV2;
                not2.SINAV3 = p.SINAV3;
                not2.PROJE = p.PROJE;
                not2.ORTALAMA = p.ORTALAMA;
                not2.DURUM = p.DURUM;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
            }
            return View();
        }
    }
}
