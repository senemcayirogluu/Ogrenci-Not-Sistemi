using OgrenciNotMVC.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMVC.Controllers
{
    public class GaleriController : Controller
    {
        MvcOkulDBEntities db = new MvcOkulDBEntities();
        public ActionResult Foto()
        {
            var fotoList = db.TBLOGRENCILER
               .Where(x => !string.IsNullOrEmpty(x.OGRFOTO))
               .Select(x => x.OGRFOTO)
               .ToList();

            return View(fotoList);
        }
    }
}