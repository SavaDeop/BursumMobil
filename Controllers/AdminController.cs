using BursumMobil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BursumMobil.Controllers
{
   
    public class AdminController : Controller
    {
        
        BursumMobilContext db = new BursumMobilContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Bursiyer kullanıcı)
        {
            var kullanıcıInDb = db.BursAlanlar.FirstOrDefault(x => x.Ad == kullanıcı.Ad && x.Soyad == kullanıcı.Soyad);
            if (kullanıcıInDb != null)
            {                
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı veya Şifre";
                return View();

            }
        }

        public ActionResult BVeren()
        {

            return View(db);
        }

    }
}