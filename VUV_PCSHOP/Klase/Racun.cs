using System;
using System.Collections.Generic;
using System.Text;

namespace VUV_PCSHOP
{
    class Racun
    {
        private string _sifraracuna;
        private string _sifrazaposlenika;
        private double _ukupaniznos;
        private DateTime _datum;
        private List<Stavka> stavke;
    
        public Racun()
        {
            stavke = new List<Stavka>();
        }
    public void DodavanjeStavke(Stavka stavka) 
        {
            stavke.Add(stavka);
        }
    }
}
