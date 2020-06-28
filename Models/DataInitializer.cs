using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BursumMobil.Models // Seeding Data Kısmı
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<BursumMobilContext>
    {
        protected override void Seed(BursumMobilContext context)
        {
           base.Seed(context);                     // TODO:   TEST VERİLERİ EKLEMEK İÇİN DOLDUR
        }
    }
}