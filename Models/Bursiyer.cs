using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BursumMobil.Models
{
    public class Bursiyer
    {
        public int Id { get; set; }    // TODO : RESİM EKLENECEK VE İLİŞKİLER AYARLANACAK.
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int TcKimlikNo { get; set; }
        public string ePosta { get; set; }
        public string Sifre { get; set; }
                     
        public int BursVerenId { get; set; }
    }
}