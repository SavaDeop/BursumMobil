using BursumMobil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BursumMobil.Controllers
{
    public class HomeController : Controller
    {
        BursumMobilContext db = new BursumMobilContext();
        public ActionResult Index()
        {
            //Bursiyer K = new Bursiyer();
            //K.Ad = "sAVA";

            //BursumMobilContext db = new BursumMobilContext();

            //db.BursAlanlar.Add(K);
            //db.SaveChanges();
            
            return View();
        }

        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Kayit( entity)
        //{
        //   // Database.ElemanEkle(entity);

        //    return View("UyeListesi", Database.Liste);
        //}

       
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(Bursiyer kullanıcı)
        {
            var kullanıcıInDb = db.BursAlanlar.FirstOrDefault(x => x.ePosta == kullanıcı.ePosta && x.Sifre == kullanıcı.Sifre);
            if (kullanıcıInDb!=null)
            {
                return RedirectToAction("Details", "Bursiyer", new { id = kullanıcıInDb.Id});
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı veya Şifre";
                return View();
                     
            }
        }

        public ActionResult Logout()
        {
            return View("Index");
        }

        //[HttpPost]
        //public ActionResult Giris( entity)
        //{
        //   // Database.ElemanEkle(entity);

        //    return View("UyeListesi", Database.Liste);
        //}




    }
}