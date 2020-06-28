using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BursumMobil.Models;

namespace BursumMobil.Controllers
{
    public class BursiyerController : Controller
    {
        private BursumMobilContext db = new BursumMobilContext();

        // GET: Bursiyer
        public ActionResult Index()
        {
            return View(db.BursAlanlar.ToList());
        }

        // GET: Bursiyer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Id = id;
            Bursiyer bursiyer = db.BursAlanlar.Find(id);
            if (bursiyer == null)
            {
                return HttpNotFound();
            }
            return View("Details", "_LayoutPage1",bursiyer);
        }

        // GET: Bursiyer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bursiyer/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Soyad,TcKimlikNo,ePosta,Sifre")] Bursiyer bursiyer)
        {
            if (ModelState.IsValid)
            {
                db.BursAlanlar.Add(bursiyer);
                db.SaveChanges();
                return RedirectToAction("Details",new {id=bursiyer.Id });
                
            }

            return View(bursiyer);
        }

        // GET: Bursiyer/Edit/5
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

        // POST: Bursiyer/Edit/5
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

        // GET: Bursiyer/Delete/5
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

        // POST: Bursiyer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bursiyer bursiyer = db.BursAlanlar.Find(id);
            db.BursAlanlar.Remove(bursiyer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Basvurularım(int? id)
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
            return View("Basvurularım", "_LayoutPage1", bursiyer);
        }

        public ActionResult Burslarım(int? id)
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
            return View("Burslarım", "_LayoutPage1", bursiyer);
           
        }

        public ActionResult Belgelerim(int? id)
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
            return View("Belgelerim", "_LayoutPage1", bursiyer);
        }

        public ActionResult Mulakatlarım(int? id)
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
            return View("Mulakatlarım", "_LayoutPage1", bursiyer);
        }

        public ActionResult Ayarlar(int? id)
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
            return View("Ayarlar", "_LayoutPage1", bursiyer);
        }
        public ActionResult EpostaDegis(int? id)
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
            return View("EpostaDegis", "_LayoutPage1", bursiyer);
        }

        public ActionResult ParolaDegis(int? id)
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
            return View("ParolaDegis", "_LayoutPage1", bursiyer);
        }
        public ActionResult UyelikSilme(int? id)
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
            return View("UyelikSilme", "_LayoutPage1", bursiyer);
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
