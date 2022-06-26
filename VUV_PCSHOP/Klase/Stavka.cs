using System;
using System.Collections.Generic;
using System.Text;

namespace VUV_PCSHOP
{
    class Stavka:Artikl
    {
        
        private int _kolicina;
        private double _ukupnacijena;
        public Stavka(Artikl artikl,int kolicina)
        {
            _kolicina = kolicina;
            Cijena = artikl.Cijena;
            Naziv = artikl.Naziv;
            Opis = artikl.Opis;
            JedinicaMjere = artikl.JedinicaMjere;
            Kategorija = artikl.Kategorija;
            _ukupnacijena = Cijena * _kolicina;
        }
        //public Stavka(int kolicina)
        //{

        //    _kolicina = kolicina;
        //    _ukupnacijena = (double)artikl.Cijena * kolicina;
        //}
        //public Artikl Artiklstavka {
        //    set { _artiklstavka = value; }
        //}
        public int Kolicina
        {
            get { return _kolicina; }
            set { _kolicina = value; }
        }
        public double Ukupnacijena
        {
            get { return _ukupnacijena; }
            set { _ukupnacijena = value; }
        }
    }
}
