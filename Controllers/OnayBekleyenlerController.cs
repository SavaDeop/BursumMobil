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
    public class OnayBekleyenlerController : Controller
    {
        private BursumMobilContext db = new BursumMobilContext();

        // GET: OnayBekleyenler
        public ActionResult Index(int? id)
        {
            ViewBag.Mesaj = "Başarılı";
         
            ////  TODO:  BURS ALANLARIN BURS ID'Sİ İLE KURUMU EŞLEŞTİRİP LİSTE ŞEKLİNDE GÖNDER
            BursVeren bursVeren = db.BursVerenler.Find(id);
            ViewBag.BursVeren = bursVeren;
            //List<Burslar> burslar = db.Burslar.Where(x => x.BursVerenId == bursVeren.Id).ToList();

            var OnayBekleyenler = db.OnayBekleyenler.Where(x => x.BursVerenId == bursVeren.Id).ToList();
            if (id == null)
            {
                return View(OnayBekleyenler);
            }
            if (OnayBekleyenler == null)
            {
                return HttpNotFound();
            }

            return View(OnayBekleyenler);
        }

        // GET: OnayBekleyenler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnayBekleyenler onayBekleyenler = db.OnayBekleyenler.Find(id);
            if (onayBekleyenler == null)
            {
                return HttpNotFound();
            }
            return View(onayBekleyenler);
        }

        // GET: OnayBekleyenler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OnayBekleyenler/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BursiyerId,BursVerenId")] OnayBekleyenler onayBekleyenler)
        {
            if (ModelState.IsValid)
            {
                db.OnayBekleyenler.Add(onayBekleyenler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(onayBekleyenler);
        }

        // GET: OnayBekleyenler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnayBekleyenler onayBekleyenler = db.OnayBekleyenler.Find(id);
            if (onayBekleyenler == null)
            {
                return HttpNotFound();
            }
            return View(onayBekleyenler);
        }

        // POST: OnayBekleyenler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BursiyerId,BursVerenId")] OnayBekleyenler onayBekleyenler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onayBekleyenler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(onayBekleyenler);
        }

        // GET: OnayBekleyenler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnayBekleyenler onayBekleyenler = db.OnayBekleyenler.Find(id);
            if (onayBekleyenler == null)
            {
                return HttpNotFound();
            }
            return View(onayBekleyenler);
        }

        // POST: OnayBekleyenler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OnayBekleyenler onayBekleyenler = db.OnayBekleyenler.Find(id);
            db.OnayBekleyenler.Remove(onayBekleyenler);
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
