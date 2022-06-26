using System;
using System.Collections.Generic;
using System.Text;

namespace VUV_PCSHOP
{
    class Zaposlenik:Osoba
    {
        private string _oib;
        private string _ime;
        private string _prezime;
        private string _sifrazaposlenika;
        //private string OIB
        //{
        //    get { return _oib; }
        //    set { _oib = value; }
        //}
        //private string Ime
        //{
        //    get { return _ime; }
        //    set { _ime = value; }
        //}
        //private string Prezime
        //{
        //    get { return _prezime; }
        //    set { _prezime = value; }
        //}
        public Zaposlenik(string oib, string ime, string prezime, string sifra)
        {
            _oib = oib;
            _ime = ime;
            _prezime = prezime;
            _sifrazaposlenika = sifra;
        }
      
        public string Oib
        {
            get { return _oib; }
            set { _oib = value; }
           
        }

        public string Ime
        {
            get { return _ime; }
            set { _ime = value; }
          
        }

        public string Prezime
        {
            get { return _prezime; }
            set { _prezime = value; }
         
        }

        public string Sifrazaposlenika
        {
            get { return _sifrazaposlenika; }
            
        }
        public string IspisPunogImena()
        {
            string punoime = _ime + " " + _prezime;
            return punoime; 
        }
      

    }
}
