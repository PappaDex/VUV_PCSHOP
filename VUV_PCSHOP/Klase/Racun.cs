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
        public string Sifraracuna
        {
            get { return _sifraracuna; }
        }
        public string Sifrazaposlenika
        {
            get { return _sifraracuna; }
        }
        public double Ukupaniznos
        {
            get { return _ukupaniznos; }
        }
        public DateTime Datum
        {
            get { return _datum; }
        }
        public List<Stavka> Stavke
        {
            get { return stavke; }
        }
    }
}
