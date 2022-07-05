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
        private string _stonirano;
        private Random rand = new Random();
        public Racun(string sracun,string szaposlenik,double uiznos,DateTime datum,List<Stavka>stavka)
        {
            _sifraracuna = sracun;
            _sifrazaposlenika = szaposlenik;
            _ukupniznos = uiznos;
            _datum = datum;
            stavke = stavka;
            if (_sifraracuna == string.Empty)
                _sifraracuna = Convert.ToString(rand.Next(1, 9000));

            if (_stonirano == null)
            {
                _stonirano = "ne";
            }
        }
        public Racun()
        {
            Random rand = new Random();
            
            stavke = new List<Stavka>();
            if (_sifraracuna == string.Empty)
                _sifraracuna = Convert.ToString(rand.Next(1, 9000));

            if (_stonirano == null)
            {
                _stonirano = "ne";
            }
        }
        public Racun(string sracun, string szaposlenik, double uiznos, DateTime datum, List<Stavka> stavka,string stonirano)
        {
            _sifraracuna = sracun;
            _sifrazaposlenika = szaposlenik;
            _ukupniznos = uiznos;
            _datum = datum;
            stavke = stavka;
            if (_sifraracuna == string.Empty)
                _sifraracuna = Convert.ToString(rand.Next(1, 9000));

            _stonirano = stonirano;
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
            get { return _sifrazaposlenika; }
            set { _sifrazaposlenika = value; }
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
        public string Stonirano
        {
            get { return _stonirano; }
            set { _stonirano = value; }
        }
        public void Stoniraj(bool ispit)
        {
            if (ispit == false)
            {
                _stonirano = "ne";
            }
            else
            {
                _stonirano = "da";
            }

        }
    }
}
