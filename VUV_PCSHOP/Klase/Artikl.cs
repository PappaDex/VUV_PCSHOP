using System;
using System.Collections.Generic;
using System.Text;

namespace VUV_PCSHOP
{
    class Artikl
    {

        private string _kategorija;
      
        private string _naziv;
        private string _opis;
        private string _jedinicamjere;
        private double _kolicina;

        //private Dictionary<string, Artikl> kategorije { get; set; }
        public Artikl(string naziv,string opis,string jedinicamjere,double kolicina)
        {
            _naziv = naziv;
            _opis = opis;
            _jedinicamjere = jedinicamjere;
            _kolicina = kolicina;
        }
        public Artikl(string kategorija,string naziv,string opis,string jedinicamjere,double kolicina)
        {
            _kategorija = kategorija;
            _naziv = naziv;
            _opis = opis;
            _jedinicamjere = jedinicamjere;
            _kolicina = kolicina;
        }
        public Artikl() { }
        public string Kategorija
        {
            get { return _kategorija; }
        }
        public string Naziv
        {
            get { return _naziv; }
        }
        public string Opis
        {
            get { return _opis; }
        }
        public string JedinicaMjere
        {
            get { return _jedinicamjere; }
        }
        public double Kolicina
        {
            get { return _kolicina; }
        }
        public void DodavanjeKategorije(string kljuckat) 
        {
            _kategorija = kljuckat;
        
        }
     
      
    }
}
