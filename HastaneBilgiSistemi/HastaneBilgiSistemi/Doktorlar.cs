using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneBilgiSistemi
{
    public class Doktorlar:Bolumler,IDoktorlar
    {

        public bool Sabahcimi { get; set; }
        public int Doktorİd { get; set; }
        public string DoktorAd { get; set; }
        public string DoktorSoyad { get; set; }
        public Bolumler Bolum { get; set; }

        public List<string> Saatler {  get; set; }

        public Doktorlar(int doktorid,string doktorad,string Doktorsoyad,Bolumler bolum,List<string>saatler,bool sabahcimi):base(bolum.Bolumİd,bolum.BolumAd)
        {
            DoktorAd = doktorad;
            Doktorİd=doktorid;
            DoktorSoyad = Doktorsoyad;
            Bolum = bolum;
            Saatler = saatler;
            this.Sabahcimi = sabahcimi;
            
        }

    }
}
