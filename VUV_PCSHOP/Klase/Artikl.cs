using System;
using System.Collections.Generic;
using System.Text;

namespace VUV_PCSHOP
{
    class Artikl
    {

        private string _kategorija;
        private string _dostupnost;
        private string _naziv;
        private string _opis;
        private string _jedinicamjere;
        private double _cijena;

        //private Dictionary<string, Artikl> kategorije { get; set; }
        public Artikl(string naziv, string opis, string jedinicamjere, double cijena)
        {
            _naziv = naziv;
            _opis = opis;
            _jedinicamjere = jedinicamjere;
            _cijena = cijena;
            if (_dostupnost == null)
            {
                _dostupnost = "da";
            }
        }
        public Artikl(string kategorija, string naziv, string opis, string jedinicamjere, double cijena)
        {
            _kategorija = kategorija;
            _naziv = naziv;
            _opis = opis;
            _jedinicamjere = jedinicamjere;
            _cijena = cijena;
            if (_dostupnost == null)
            {
                _dostupnost = "da";
            }
        }      
        public Artikl(string kategorija, string naziv, string opis, string jedinicamjere, double cijena,string dostupnost)
        {
            _kategorija = kategorija;
            _naziv = naziv;
            _opis = opis;
            _jedinicamjere = jedinicamjere;
            _cijena = cijena;
            _dostupnost = dostupnost;
        }
        public Artikl() { }
        public string Kategorija
        {
            get { return _kategorija; }
            set { _kategorija = value; }
        }
        public string Naziv
        {
            get { return _naziv; }
            set { _naziv = value; }
        }
        public string Opis
        {
            get { return _opis; }
            set { _opis = value; }
        }
        public string JedinicaMjere
        {
            get { return _jedinicamjere; }
            set { _jedinicamjere = value; }
        } 
        public string Dostupnost
        {
            get { return _dostupnost; }
            set { _dostupnost = value; }
        }
        public double Cijena
        {
            get { return _cijena; }
            set { _cijena = value; }
        }
        public void DodavanjeKategorije(string kljuckat)
        {
            _kategorija = kljuckat;

        }
        public void PromjenaDostupnosti(bool ispit)
        {
            if(ispit==false)
            {
                _dostupnost = "ne";
            }
            else
            {
                _dostupnost = "da";
            }

        }
      
    }
}
