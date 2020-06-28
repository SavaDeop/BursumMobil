using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BursumMobil.Models
{
    public class OnayBekleyenler
    {
        public int Id { get; set; }

        public int BursiyerId { get; set; }
        public int BursVerenId { get; set; }

        public List<BursVeren> bursVerenler { get; set; }
        public List<Bursiyer> bursiyerler { get; set; }

    }
}