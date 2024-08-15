using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Views.Shared
{
    public class DefaultController : Controller
    {
        MvcOkulDBEntities db = new MvcOkulDBEntities();
        public ActionResult Index()
        {
            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {  
            return View(); 
        }

        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER p)
        {
            db.TBLDERSLER.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var dersler = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(dersler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var ders = db.TBLDERSLER.Find(id); 
            return View("DersGetir", ders);
        }
        public ActionResult Guncelle(TBLDERSLER p2)
        {
            var drs = db.TBLDERSLER.Find(p2.DERSID);
            drs.DERSADI = p2.DERSADI;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}