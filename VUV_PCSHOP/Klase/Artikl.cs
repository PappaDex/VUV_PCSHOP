using System;
using System.Collections.Generic;
using System.Text;

namespace VUV_PCSHOP
{
    class Artikl
    {
        
        public static Dictionary<string,List<Artikl>> _kategorija { get; set; }
      
        private string _naziv { get; set; }
        private string _opis { get; set; }
        private string _jedinicamjere { get; set; }
        private int _kolicina { get; set; }
 
        //private Dictionary<string, Artikl> kategorije { get; set; }
        public Artikl(string naziv,string opis,string jedinicamjere,int kolicina)
        {
            _naziv = naziv;
            _opis = opis;
            _jedinicamjere = jedinicamjere;
            _kolicina = kolicina;
        }
        public Artikl() { }
        public void Sortiranje() 
        {
        
        
        }
        public void AddKategorija(int izb, Artikl noviartikl)
        {
            _kategorija.Add("Laptopi,Racunala", null);
            _kategorija.Add("Komponente", null);
            _kategorija.Add("Konzole", null);
            _kategorija.Add("Monitori,Periferija", null);
            if(izb==1)
            {
                _kategorija["Laptopi,Racunala"].Add(noviartikl);
            }
            if(izb==2)
            {
                _kategorija["Komponente"].Add(noviartikl);
            }
            if(izb==3)
            {
                _kategorija["Konzole"].Add(noviartikl);
            }
            if(izb==4)
            {
                _kategorija["Monitori,Periferija"].Add(noviartikl);
            }

        }
        public void IspisKategorija()
        {
            foreach (KeyValuePair<string, List<Artikl>> elem in _kategorija)
            {
                Console.WriteLine("KLJUC:{0}\n Vrijednost:{1}", elem.Key, elem.Value);
            }
        }
    }
}
