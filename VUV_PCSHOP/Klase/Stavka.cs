using System;
using System.Collections.Generic;
using System.Text;

namespace VUV_PCSHOP
{
    class Stavka:Artikl
    {
        private Artikl _artikl;
        private int _kolicina;
        private double _ukupnacijena;

        public Stavka(Artikl artikl,int kolicina)
        {
            _artikl = artikl;
            _kolicina = kolicina;
            _ukupnacijena = (double)artikl.Cijena * kolicina;
        }
    }
}
