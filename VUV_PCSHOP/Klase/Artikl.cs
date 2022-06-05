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
        private double _cijena;

        //private Dictionary<string, Artikl> kategorije { get; set; }
        public Artikl(string naziv,string opis,string jedinicamjere,double cijena)
        {
            _naziv = naziv;
            _opis = opis;
            _jedinicamjere = jedinicamjere;
            _cijena = cijena;
        }
        public Artikl(string kategorija,string naziv,string opis,string jedinicamjere,double cijena)
        {
            _kategorija = kategorija;
            _naziv = naziv;
            _opis = opis;
            _jedinicamjere = jedinicamjere;
            _cijena = cijena;
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
        public double Cijena
        {
            get { return _cijena; }
        }
        public void DodavanjeKategorije(string kljuckat) 
        {
            _kategorija = kljuckat;
        
        }
     
      
    }
}
