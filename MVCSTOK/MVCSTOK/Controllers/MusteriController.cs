using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MVCSTOK.Models.Entity;

namespace MVCSTOK.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDboStokEntities db = new MvcDboStokEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //var deger = db.TBLMUSTERI.ToList();
            var deger = db.TBLMUSTERI.ToList().ToPagedList(sayfa, 5);
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERI p2)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERI.Add(p2);
            db.SaveChanges();
            return RedirectToAction("Index", "Musteri");
        }
        public ActionResult Sil(int id)
        {
            var musteri = db.TBLMUSTERI.Find(id);
            db.TBLMUSTERI.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index", "Musteri");
        }
        public ActionResult Guncelle(int id)
        {
            var musteri = db.TBLMUSTERI.Find(id);
            return View("Guncelle", musteri);
        }
        public ActionResult MusteriGuncelle(TBLMUSTERI p)
        {
            var musteri = db.TBLMUSTERI.Find(p.MUSTERIID);
            musteri.MUSTERIAD = p.MUSTERIAD;
            musteri.MUSTERISOYAD = p.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Musteri");
        }
    }
}