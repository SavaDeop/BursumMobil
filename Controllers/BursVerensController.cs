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
    public class BursVerensController : Controller
    {
        private BursumMobilContext db = new BursumMobilContext();

        // GET: BursVerens
        public ActionResult Index()
        {
            return View(db.BursVerenler.ToList());
        }

        // GET: BursVerens/Details/5
        public ActionResult Details(int? id)
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

        // GET: BursVerens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BursVerens/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KurumAdi,Aciklama")] BursVeren bursVeren)
        {
            if (ModelState.IsValid)
            {
                db.BursVerenler.Add(bursVeren);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bursVeren);
        }

        // GET: BursVerens/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: BursVerens/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KurumAdi,Aciklama")] BursVeren bursVeren)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bursVeren).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bursVeren);
        }

        // GET: BursVerens/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: BursVerens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BursVeren bursVeren = db.BursVerenler.Find(id);
            db.BursVerenler.Remove(bursVeren);
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

        public ActionResult Admin(int? id)
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

        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(BursVeren kullanıcı)
        {
            var kullanıcıInDb = db.BursVerenler.FirstOrDefault(x => x.KurumAdi == kullanıcı.KurumAdi && x.KurumAdi == kullanıcı.KurumAdi);
            if (kullanıcıInDb != null)
            {
                return RedirectToAction("Admin", "BursVerens", new { id = kullanıcıInDb.Id });
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı veya Şifre";
                return View();

            }
        }


    }
}
