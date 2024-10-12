using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneBilgiSistemi
{
    public class Bolumler
    {
        public int Bolumİd { get; set; }
        public string BolumAd { get; set; }
        public Bolumler(int bolumid,string bolumad)
        {
            Bolumİd = bolumid;
            BolumAd = bolumad;
        }
       
    }
}
