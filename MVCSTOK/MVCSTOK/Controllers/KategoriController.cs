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
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDboStokEntities db = new MvcDboStokEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var kategori = db.TBLKATEGORİLER.ToList().ToPagedList(sayfa, 5);
            return View(kategori);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORİLER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORİLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index", "Kategori");
        }
        public ActionResult Sil(int id)
        {
            var ktgr = db.TBLKATEGORİLER.Find(id);
            db.TBLKATEGORİLER.Remove(ktgr);
            db.SaveChanges();
            return RedirectToAction("Index", "Kategori");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORİLER.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(TBLKATEGORİLER p)
        {
            var ktgr = db.TBLKATEGORİLER.Find(p.KATEGORIID);
            ktgr.KATEGORIAD = p.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Kategori");
        }
    }
}