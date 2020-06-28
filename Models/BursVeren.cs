using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BursumMobil.Models
{
    public class BursVeren
    {
        public int Id { get; set; }   // TODO: RESİM EKLENECEK VE İLİŞKİLER AYARLANACAK
        public string KurumAdi { get; set; }
        public string Aciklama { get; set; }

        public List<Burslar> VerilenBurslar { get; set; }

    }
}