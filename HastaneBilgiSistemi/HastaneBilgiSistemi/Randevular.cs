using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneBilgiSistemi
{
    public class Randevular
    {
        public string RandevuSaati { get; set; }
        public string Doktor { get; set; }
        public Randevular(string randevusaati,string doktor)
        {
                RandevuSaati = randevusaati;
            Doktor = doktor;
     
        }
        
    }
}
