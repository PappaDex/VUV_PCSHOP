using System;
using System.Collections.Generic;
using System.Text;

namespace VUV_PCSHOP
{
    class Racun
    {
        private string _sifraracuna;
        private string _sifrazaposlenika;
        private double _ukupniznos;
        private DateTime _datum;
        private List<Stavka> stavke;

        public Racun(string sracun,string szaposlenik,double uiznos,DateTime datum,List<Stavka>stavka)
        {
            _sifraracuna = sracun;
            _sifrazaposlenika = szaposlenik;
            _ukupniznos = uiznos;
            _datum = datum;
            stavke = stavka;
        }
        public Racun()
        {
            
            stavke = new List<Stavka>();
        }
        public void DodavanjeStavke(Stavka stavka)
        {
            stavke.Add(stavka);
            _ukupniznos = (double)_ukupniznos + stavka.Cijena * stavka.Kolicina;
        }
        public string Sifraracuna
        {
            get { return _sifraracuna; }
        }
        public string Sifrazaposlenika
        {
            get { return _sifraracuna; }
            set { _sifraracuna=value; }
        }
        public double Ukupaniznos
        {
            get { return _ukupniznos; }
        }
        public DateTime Datum
        {
            get { return _datum; }
            set { _datum = value; }
        }
        public List<Stavka> Stavke
        {
            get { return stavke; }
        }
    }
}
