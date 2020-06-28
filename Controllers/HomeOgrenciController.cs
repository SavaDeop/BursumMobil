using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BursumMobil.Models;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace BursumMobil.Controllers
{
    public class HomeOgrenciController : Controller
    {
        BursumMobilContext db = new BursumMobilContext();
        // GET: HomeOgrenci
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult BursVerenler()
        {
           


            return View(db.BursVerenler.ToList());
        }

        public ActionResult BursArama(int? id)
        {

            var burslar = db.Burslar.Include(a => a.BursVeren);

            return View(burslar.ToList());
        }

        public ActionResult BursVerenDetay(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BursVeren bursVeren = db.BursVerenler.Find(id);
            if (bursVeren == null)
            {
                return HttpNotFound();
            }
            return View(bursVeren);
        }

        public ActionResult BursDetay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Burslar burslar = db.Burslar.Find(id);
            BursVeren bursVeren = burslar.BursVeren;

            ViewBag.BursVeren = bursVeren;
            
            if (burslar == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mesaj = " Başvurunuz Başarıyla Alınmıştır.";
            return View(burslar);
        }

         public ActionResult BursDetay1(int? id, int? id2)
        {
            id2 = ViewBag.Id;
            Burslar burs  = db.Burslar.Find(id);

            var BursVerdi = burs.BursVerenId;

            List<Bursiyer> bursiyerOnay = db.BursAlanlar.ToList();

            ViewBag.BursVerdi = BursVerdi;
            

            ViewBag.Mesaj = " Başvurunuz Başarıyla Alınmıştır.";
            return View();
        }

    }
}