using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BursumMobil.Models
{
    public class Bursiyerlerim
    {
        public BursVeren BursVeren { get; set; } 
        public List<Bursiyer> Bursiyerleri { get; set; }        
    }
}