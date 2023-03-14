using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOK.Models.Entity;

namespace MVCSTOK.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDboStokEntities db = new MvcDboStokEntities();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> degerler = (from i in db.TBLURUN.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.URUNAD,
                                                 Value = i.URUNID.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATIS p)
        {
            var urun = db.TBLURUN.Where(m => m.URUNID == p.TBLURUN.URUNID).FirstOrDefault();
            p.TBLURUN = urun;

            db.TBLSATIS.Add(p);
            db.SaveChanges();
            return View();
        }

    }
}