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
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDboStokEntities db = new MvcDboStokEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //var urun = db.TBLURUN.ToList();
            var urun = db.TBLURUN.ToList().ToPagedList(sayfa, 5);
            return View(urun);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLURUN p)
        {
            var ktgr = db.TBLKATEGORİLER.Where(m => m.KATEGORIID == p.TBLKATEGORİLER.KATEGORIID).FirstOrDefault();
            p.TBLKATEGORİLER = ktgr;

            db.TBLURUN.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Urun");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.TBLURUN.Find(id);
            db.TBLURUN.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index", "Urun");
        }
        public ActionResult Guncelle(int id)
        {
            var urun = db.TBLURUN.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("Guncelle", urun);
        }
        public ActionResult UrunGuncelle(TBLURUN p)
        {
            var urun = db.TBLURUN.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            var ktgr = db.TBLKATEGORİLER.Where(m => m.KATEGORIID == p.TBLKATEGORİLER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktgr.KATEGORIID;
            urun.MARKA = p.MARKA;
            urun.URUNFIYAT = p.URUNFIYAT;
            urun.STOK = p.STOK;


            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
