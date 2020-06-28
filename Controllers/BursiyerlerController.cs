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
    public class BursiyerlerController : Controller
    {
        private BursumMobilContext db = new BursumMobilContext();

        // GET: Bursiyerler
        public ActionResult Index()
        {
            return View(db.BursAlanlar.ToList());
        }

        // GET: Bursiyerler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bursiyer bursiyer = db.BursAlanlar.Find(id);
            if (bursiyer == null)
            {
                return HttpNotFound();
            }
            return View(bursiyer);
        }

        // GET: Bursiyerler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bursiyerler/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Soyad,TcKimlikNo,ePosta")] Bursiyer bursiyer)
        {
            if (ModelState.IsValid)
            {
                db.BursAlanlar.Add(bursiyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bursiyer);
        }

        // GET: Bursiyerler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bursiyer bursiyer = db.BursAlanlar.Find(id);
            if (bursiyer == null)
            {
                return HttpNotFound();
            }
            return View(bursiyer);
        }

        // POST: Bursiyerler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Soyad,TcKimlikNo,ePosta")] Bursiyer bursiyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bursiyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bursiyer);
        }

        // GET: Bursiyerler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bursiyer bursiyer = db.BursAlanlar.Find(id);
            if (bursiyer == null)
            {
                return HttpNotFound();
            }
            return View(bursiyer);
        }

        // POST: Bursiyerler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bursiyer bursiyer = db.BursAlanlar.Find(id);
            db.BursAlanlar.Remove(bursiyer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Bursiyerlerim(int? id)
        {
            ////  TODO:  BURS ALANLARIN BURS ID'Sİ İLE KURUMU EŞLEŞTİRİP LİSTE ŞEKLİNDE GÖNDER
            BursVeren bursVeren = db.BursVerenler.Find(id);
            ViewBag.BursVeren = bursVeren;
            //List<Burslar> burslar = db.Burslar.Where(x => x.BursVerenId == bursVeren.Id).ToList();

            var bursAlanlar = db.BursAlanlar.Where(x => x.BursVerenId == bursVeren.Id);


            return View(bursAlanlar);
        }


        public ActionResult Onayla(int? id)
        {
            

            return View();
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
