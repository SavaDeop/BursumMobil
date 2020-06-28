using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BursumMobil.Models
{
    public class Burslar
    {
        public int Id { get; set; }
        public string Aciklama { get; set; }
        public int Miktar { get; set; }
        public int Sure { get; set; }

        public int BursVerenId { get; set; }
        public BursVeren BursVeren { get; set; }

        public List<Bursiyer> Bursiyer { get; set; }
    }
}