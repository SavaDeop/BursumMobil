using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BursumMobil.Models;

namespace BursumMobil.Controllers
{
    public class BurslarsController : Controller
    {
        private BursumMobilContext db = new BursumMobilContext();

        // GET: Burslars
        public ActionResult Index()
        {
            var burslar = db.Burslar.Include(b => b.BursVeren);
            return View(burslar.ToList());
        }

        // GET: Burslars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Burslar burslar = db.Burslar.Find(id);
            if (burslar == null)
            {
                return HttpNotFound();
            }
            return View(burslar);
        }

        // GET: Burslars/Create
        public ActionResult Create()
        {
            ViewBag.BursVerenId = new SelectList(db.BursVerenler, "Id", "KurumAdi");
            return View();
        }

        // POST: Burslars/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Aciklama,Miktar,Sure,BursVerenId")] Burslar burslar)
        {
            if (ModelState.IsValid)
            {
                db.Burslar.Add(burslar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BursVerenId = new SelectList(db.BursVerenler, "Id", "KurumAdi", burslar.BursVerenId);
            return View(burslar);
        }

        // GET: Burslars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Burslar burslar = db.Burslar.Find(id);
            if (burslar == null)
            {
                return HttpNotFound();
            }
            ViewBag.BursVerenId = new SelectList(db.BursVerenler, "Id", "KurumAdi", burslar.BursVerenId);
            return View(burslar);
        }

        // POST: Burslars/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Aciklama,Miktar,Sure,BursVerenId")] Burslar burslar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(burslar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BursVerenId = new SelectList(db.BursVerenler, "Id", "KurumAdi", burslar.BursVerenId);
            return View(burslar);
        }

        // GET: Burslars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Burslar burslar = db.Burslar.Find(id);
            if (burslar == null)
            {
                return HttpNotFound();
            }
            return View(burslar);
        }

        // POST: Burslars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Burslar burslar = db.Burslar.Find(id);
            db.Burslar.Remove(burslar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Burslarım(int? id)
        {
            // TODO : KURUMUN AÇMIŞ OLDUĞU BURSLAR GÖRÜNTÜLENECEK
            BursVeren bursVeren = db.BursVerenler.Find(id);

            //var bursiyer = db.Burslar
            //    .Select(x => new Bursiyerlerim()
            //    {
            //        BursVeren = x.BursVeren,
            //        Bursiyerleri = x.Bursiyer .Where(x => x.BursVerenId == bursVeren.Id)
            //    });

            //ViewBag.Bursiyer = bursiyer;

            List<Burslar> burslar = db.Burslar.Where(x => x.BursVerenId == bursVeren.Id).ToList();
            //List<Bursiyer> bursiyer = db.BursAlanlar.Select(x => x.Id == burslar.Where(a => a.Bursiyer );
            var idler = db.BursAlanlar.ToList();

            //List<Bursiyerlerim> bursiyerler = db.BursAlanlar.Where(x => x.Id = idle);
            
            


            return View(burslar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
