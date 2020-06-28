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
    public class BurslarController : Controller
    {
        private BursumMobilContext db = new BursumMobilContext();

        // GET: Burslar
        public ActionResult Index()
        {
            var burslar = db.Burslar.Include(b => b.BursVeren);
            return View(burslar.ToList());
        }
        [Authorize]
        // GET: Burslar/Details/5
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

        // GET: Burslar/Create
        public ActionResult Create()
        {
            ViewBag.BursVerenId = new SelectList(db.BursVerenler, "Id", "KurumAdi");
            return View();
        }

        // POST: Burslar/Create
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

        // GET: Burslar/Edit/5
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

        // POST: Burslar/Edit/5
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

        // GET: Burslar/Delete/5
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

        // POST: Burslar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Burslar burslar = db.Burslar.Find(id);
            db.Burslar.Remove(burslar);
            db.SaveChanges();
            return RedirectToAction("Index");
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
