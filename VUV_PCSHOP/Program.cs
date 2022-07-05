// 
//
//
//       Autor: Đurica Dakić
//       Projekt: Trgovina informaticke opreme
//       Predmet:Objektno-orijentirano programiranje
//       Ustanova:VUV
//       Godina:2022
//
//




using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
namespace VUV_PCSHOP
{
    class Program
    {
        //Nakon logina kao zaposlenik se postavlja taj zaposlenik u globalnu staticku varijablu zbog lakse upotrebe u ostatku programa
      public static class PrijaveljniZaposlenik
        {
          public  static Zaposlenik prijavljeni;
        }
        static class FileLocation
        {
            public static string lokacija;
        }
        //Funkcija koja povlaci lokaciju fileo-va dinamicno
        static void LokacijaDatoteke()
        {
            string lokacija =Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            lokacija = Path.GetDirectoryName(lokacija);
            FileLocation.lokacija = lokacija;
        }

 
        static void SaveListZaposlenici(ref List<Zaposlenik> zaposlenici)
        {
            string lok = FileLocation.lokacija + "\\XML\\zaposlenici.xml";
            string xml = "";
            StreamReader sr = new StreamReader(lok);
            using(sr)
            {
                xml=sr.ReadToEnd();
            }
            sr.Close();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            XmlNodeList zaposlenik = xmlObject.SelectNodes("//vuv_pcshop/osoba/zaposlenici/zaposlenik");
        foreach(XmlNode zap in zaposlenik)
            {
                if(zap.Attributes["otkaz"] != null && zap.Attributes["otkaz"].Value != null)
                {     
                zaposlenici.Add(new Zaposlenik(
                    zap.Attributes["oib"].Value,
                    zap.Attributes["ime"].Value,
                    zap.Attributes["prezime"].Value,
                    zap.Attributes["sifrazaposlenika"].Value,
                    zap.Attributes["otkaz"].Value
                    ));
                }
                else
                {
                    zaposlenici.Add(new Zaposlenik(
                zap.Attributes["oib"].Value,
                zap.Attributes["ime"].Value,
                zap.Attributes["prezime"].Value,
                zap.Attributes["sifrazaposlenika"].Value
                ));
                }
            }
        }      
        static void SaveListAdmini(ref List<Admin> admins)
        {
            string lok = FileLocation.lokacija + "\\XML\\admin.xml";
            string xml = "";
            StreamReader sr = new StreamReader(lok);
            using(sr)
            {
                xml=sr.ReadToEnd();
            }
            sr.Close();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            XmlNodeList admini = xmlObject.SelectNodes("//vuv_pcshop/admins/admin");
        foreach(XmlNode admin in admini)
            {
                admins.Add(new Admin(
                    admin.Attributes["username"].Value,
                    admin.Attributes["password"].Value
                    ));
            }
        }
         static void SaveListArtikli(ref List<Artikl>sviartikli)
        {
            string lok = FileLocation.lokacija + "\\XML\\artikli.xml";
            string xml = "";
            StreamReader sr = new StreamReader(lok);
            using(sr)
            {
                xml=sr.ReadToEnd();
            }
            sr.Close();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            XmlNodeList artikl = xmlObject.SelectNodes("//vuv_pcshop/artikli/artikl");
            foreach (XmlNode art in artikl)
            {

                if (art.Attributes["dostupnost"]!=null && art.Attributes["dostupnost"].Value != null && art.Attributes["obrisano"]!=null && art.Attributes["obrisano"].Value!=null)
                {
                    sviartikli.Add(new Artikl(
                    art.Attributes["kategorija"].Value,
                    art.Attributes["naziv"].Value,
                    art.Attributes["opis"].Value,
                    art.Attributes["jedinicamjere"].Value,
                  Convert.ToDouble(art.Attributes["cijena"].Value),
                  art.Attributes["dostupnost"].Value,
                  art.Attributes["obrisano"].Value
                    )); ; ;
                }
                else { 
                sviartikli.Add(new Artikl(
                    art.Attributes["kategorija"].Value,
                    art.Attributes["naziv"].Value,
                    art.Attributes["opis"].Value,
                    art.Attributes["jedinicamjere"].Value,
                  Convert.ToDouble(art.Attributes["cijena"].Value)
                    ));;
                }
            }
        }
        static void SaveListRacuni(ref List<Racun> sviracuni)
        {
            List<Stavka> s1 = new List<Stavka>();
            List<Racun> r1 = new List<Racun>();
            string lok = FileLocation.lokacija + "\\XML\\racuni.xml";
            string xml = "";
            StreamReader sr = new StreamReader(lok);
            using (sr)
            {
                xml = sr.ReadToEnd();
            }
            sr.Close();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            XmlNodeList racuni = xmlObject.SelectNodes("//vuv_pcshop/racuni/racun");
            XmlNodeList stavke = xmlObject.SelectNodes("//vuv_pcshop/racuni/racun/stavka");

            foreach (XmlNode rac in racuni)
            {



                for(XmlNode stavka=rac.FirstChild;stavka!=null;stavka=stavka.NextSibling)
                {
                    s1.Add(new Stavka(

                new Artikl(stavka.Attributes["kategorijaartikla"].Value,
                    stavka.Attributes["nazivartikla"].Value,
                    stavka.Attributes["opisartikla"].Value,
                    stavka.Attributes["jedinicamjereartikla"].Value,
                   Convert.ToDouble(stavka.Attributes["cijenaartikla"].Value)
                   ),

                Convert.ToInt32(stavka.Attributes["kolicina"].Value)));
                }
                if (rac.Attributes["stonirano"] != null && rac.Attributes["stonirano"].Value != null)
                {
                    r1.Add(new Racun(
                         rac.Attributes["sifraracuna"].Value,
                                  rac.Attributes["sifrazaposlenika"].Value,
                      Convert.ToDouble(rac.Attributes["ukupaniznos"].Value),
                      Convert.ToDateTime(rac.Attributes["datum"].Value),
                      s1,
                      rac.Attributes["stonirano"].Value
                      ));
                }
                else
                {

                
                r1.Add(new Racun(
                       rac.Attributes["sifraracuna"].Value,
                                rac.Attributes["sifrazaposlenika"].Value,
                    Convert.ToDouble(rac.Attributes["ukupaniznos"].Value),
                    Convert.ToDateTime(rac.Attributes["datum"].Value),
                    s1
                    )) ;
               
                }
                s1 = new List<Stavka>();
            }
            sviracuni = r1;
        }
        static void SaveDictKategorije(ref Dictionary<string,string>kategorija)
        {
            string lok = FileLocation.lokacija + "\\XML\\kategorije.xml";
            string xml = "";
            StreamReader sr = new StreamReader(lok);
            using(sr)
            {
                xml=sr.ReadToEnd();
            }
            sr.Close();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            XmlNodeList kate = xmlObject.SelectNodes("//vuv_pcshop/kategorije/kategorija");
        foreach(XmlNode kat in kate)
            {
                kategorija.Add(
                    kat.Attributes["kljuc"].Value,
                    kat.Attributes["vrijednost"].Value

                    );
            }
        }
        static void SpremanjeUXMLzaposlenike(ref List<Zaposlenik> zaposlenici)
        {
            string xml = "";
            StreamReader sr = new StreamReader(FileLocation.lokacija+"\\XML\\zaposlenici.xml");
            using (sr)
            {
                xml = sr.ReadToEnd();
            }
            sr.Close();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            string lokacijaxmla = FileLocation.lokacija+"\\XML\\zaposlenici.xml";
            XmlNode zaposleniciNode = xmlObject.SelectSingleNode("//vuv_pcshop/osoba/zaposlenici");
            zaposleniciNode.RemoveAll();
            foreach(Zaposlenik zaposlenik in zaposlenici)
            {
                XmlNode noviNode = xmlObject.CreateNode(XmlNodeType.Element, "zaposlenik", null);
                XmlAttribute oibAttr = xmlObject.CreateAttribute("oib");
                oibAttr.Value = zaposlenik.Oib.ToString();
                noviNode.Attributes.Append(oibAttr);
                XmlAttribute imeAttr = xmlObject.CreateAttribute("ime");
                imeAttr.Value = zaposlenik.Ime.ToString();
                noviNode.Attributes.Append(imeAttr);
                XmlAttribute prezimeAttr = xmlObject.CreateAttribute("prezime");
                prezimeAttr.Value = zaposlenik.Prezime.ToString();
                noviNode.Attributes.Append(prezimeAttr);
                XmlAttribute sifraAttr = xmlObject.CreateAttribute("sifrazaposlenika");
                sifraAttr.Value = zaposlenik.Sifrazaposlenika.ToString();
                noviNode.Attributes.Append(sifraAttr);
                XmlAttribute otkazAttr = xmlObject.CreateAttribute("otkaz");
                otkazAttr.Value = zaposlenik.VOtkaz.ToString();
                noviNode.Attributes.Append(otkazAttr);
                zaposleniciNode.AppendChild(noviNode);
                    }
            xmlObject.Save(lokacijaxmla);
        }
        static void SpremanjeUXMLartikle(ref List<Artikl> artikli)
        {
            string xml = "";
            StreamReader sr = new StreamReader(FileLocation.lokacija+"\\XML\\artikli.xml");
            using (sr)
            {
                xml = sr.ReadToEnd();
            }
            sr.Close();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            string lokacijaxmla = FileLocation.lokacija+"\\XML\\artikli.xml";
            XmlNode artikliNode = xmlObject.SelectSingleNode("//vuv_pcshop/artikli");
            artikliNode.RemoveAll();
            foreach(Artikl artikl in artikli)
            {
                XmlNode noviNode = xmlObject.CreateNode(XmlNodeType.Element, "artikl", null);
                XmlAttribute katAttr = xmlObject.CreateAttribute("kategorija");
                katAttr.Value = artikl.Kategorija.ToString();
                noviNode.Attributes.Append(katAttr);
                XmlAttribute nazivAttr = xmlObject.CreateAttribute("naziv");
                nazivAttr.Value = artikl.Naziv.ToString();
                noviNode.Attributes.Append(nazivAttr);
                XmlAttribute opisAttr = xmlObject.CreateAttribute("opis");
                opisAttr.Value = artikl.Opis.ToString();
                noviNode.Attributes.Append(opisAttr);
                XmlAttribute jedmjerAttr = xmlObject.CreateAttribute("jedinicamjere");
                jedmjerAttr.Value = artikl.JedinicaMjere.ToString();
                noviNode.Attributes.Append(jedmjerAttr);
                XmlAttribute cijAttr = xmlObject.CreateAttribute("cijena");
                cijAttr.Value = artikl.Cijena.ToString();
                noviNode.Attributes.Append(cijAttr);
                XmlAttribute dostupnostAttr = xmlObject.CreateAttribute("dostupnost");
                dostupnostAttr.Value = artikl.Dostupnost.ToString();
                noviNode.Attributes.Append(dostupnostAttr);
                XmlAttribute obrisanoAttr = xmlObject.CreateAttribute("obrisano");
                obrisanoAttr.Value = artikl.Obrisano.ToString();
                noviNode.Attributes.Append(obrisanoAttr);

                artikliNode.AppendChild(noviNode);
                    }
            xmlObject.Save(lokacijaxmla);
        }
        static void SpremanjeUXMLracuni(ref List<Racun> racuni)
        {
            string xml = "";
            StreamReader sr = new StreamReader(FileLocation.lokacija+"\\XML\\racuni.xml");
            using (sr)
            {
                xml = sr.ReadToEnd();
            }
            sr.Close();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            List<Stavka> s1 = new List<Stavka>();
            string lokacijaxmla = FileLocation.lokacija+"\\XML\\racuni.xml";
            XmlNode racuniNode = xmlObject.SelectSingleNode("//vuv_pcshop/racuni");

            XmlNode artiklNode = xmlObject.SelectSingleNode("//vuv_pcshop/racuni/racun/stavka");
            racuniNode.RemoveAll();
            foreach(Racun rac in racuni)
            {
               
              

                XmlNode noviNode = xmlObject.CreateNode(XmlNodeType.Element, "racun", null);
                XmlAttribute sifrazaposlenikaAttr = xmlObject.CreateAttribute("sifrazaposlenika");
                sifrazaposlenikaAttr.Value = rac.Sifrazaposlenika.ToString();
                noviNode.Attributes.Append(sifrazaposlenikaAttr);
                XmlAttribute sifraracunaAttr = xmlObject.CreateAttribute("sifraracuna");
                if(rac.Sifraracuna!=string.Empty)
                sifraracunaAttr.Value = rac.Sifraracuna;
                noviNode.Attributes.Append(sifraracunaAttr);
                XmlAttribute ukupaniznosAttr = xmlObject.CreateAttribute("ukupaniznos");
                ukupaniznosAttr.Value = rac.Ukupaniznos.ToString();
                noviNode.Attributes.Append(ukupaniznosAttr);
                XmlAttribute datumAttr = xmlObject.CreateAttribute("datum");
                datumAttr.Value = rac.Datum.ToString();
                noviNode.Attributes.Append(datumAttr);
                XmlAttribute stoniranoAttr = xmlObject.CreateAttribute("stonirano");
                stoniranoAttr.Value = rac.Stonirano.ToString();
                noviNode.Attributes.Append(stoniranoAttr);


                racuniNode.AppendChild(noviNode);


           
            }
            XmlNode stavkeNode = racuniNode.FirstChild;


            foreach (Racun rac in racuni)
            {
                s1.Clear();
                s1 = rac.Stavke;

                foreach (Stavka sta in s1)
                {

                    XmlNode novi2Node = xmlObject.CreateNode(XmlNodeType.Element, "stavka", null);

                    XmlAttribute katartAttr = xmlObject.CreateAttribute("kategorijaartikla");
                    katartAttr.Value = sta.Kategorija.ToString();
                    novi2Node.Attributes.Append(katartAttr);
                    XmlAttribute nazartAttr = xmlObject.CreateAttribute("nazivartikla");
                    nazartAttr.Value = sta.Naziv.ToString();
                    novi2Node.Attributes.Append(nazartAttr);
                    XmlAttribute opartAttr = xmlObject.CreateAttribute("opisartikla");
                    opartAttr.Value = sta.Opis.ToString();
                    novi2Node.Attributes.Append(opartAttr);
                    XmlAttribute jedmjerartAttr = xmlObject.CreateAttribute("jedinicamjereartikla");
                    jedmjerartAttr.Value = sta.JedinicaMjere.ToString();
                    novi2Node.Attributes.Append(jedmjerartAttr);
                    XmlAttribute cijenaartAttr = xmlObject.CreateAttribute("cijenaartikla");
                    cijenaartAttr.Value = sta.Cijena.ToString();
                    novi2Node.Attributes.Append(cijenaartAttr);
                    XmlAttribute kolAttr = xmlObject.CreateAttribute("kolicina");
                    kolAttr.Value = sta.Kolicina.ToString();
                    novi2Node.Attributes.Append(kolAttr);
                    XmlAttribute ukupnacAttr = xmlObject.CreateAttribute("ukupnacijena");
                    ukupnacAttr.Value = sta.Ukupnacijena.ToString();
                    novi2Node.Attributes.Append(ukupnacAttr);          



                    stavkeNode.AppendChild(novi2Node);

                }
                stavkeNode = stavkeNode.NextSibling;


            }
            xmlObject.Save(lokacijaxmla);

        }
        static void SpremanjeUXMLkategorije(ref Dictionary<string,string> kategorije)
        {
            string xml = "";
            StreamReader sr = new StreamReader(FileLocation.lokacija+"\\XML\\kategorije.xml");
            using (sr)
            {
                xml = sr.ReadToEnd();
            }
            sr.Close();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            string lokacijaxmla = FileLocation.lokacija+"\\XML\\kategorije.xml";
            XmlNode kategorijeNode = xmlObject.SelectSingleNode("//vuv_pcshop/kategorije");
            kategorijeNode.RemoveAll();
            foreach(KeyValuePair<string,string> kategorija in kategorije)
            {
                XmlNode noviNode = xmlObject.CreateNode(XmlNodeType.Element, "kategorija", null);
                XmlAttribute kljucAttr = xmlObject.CreateAttribute("kljuc");
                kljucAttr.Value = kategorija.Key.ToString();
                noviNode.Attributes.Append(kljucAttr);
                XmlAttribute vrjAttr = xmlObject.CreateAttribute("vrijednost");
                vrjAttr.Value = kategorija.Value.ToString();
                noviNode.Attributes.Append(vrjAttr);
                kategorijeNode.AppendChild(noviNode);
                    }
            xmlObject.Save(lokacijaxmla);
        }
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            
            LokacijaDatoteke();
            List<Admin> admins = new List<Admin>();
            List<Zaposlenik> zaposlenici = new List<Zaposlenik>();
            List<Artikl> sviartikli = new List<Artikl>();
            List<Racun> racuni = new List<Racun>();
            Dictionary<string, string> kategorija = new Dictionary<string, string>();
            //PopisKategorija(ref kategorija);
            SaveListAdmini(ref admins);
            SaveDictKategorije(ref kategorija);
            SaveListZaposlenici(ref zaposlenici);
            SaveListArtikli(ref sviartikli);
            SaveListRacuni(ref racuni);
            menu.Start(ref zaposlenici,ref sviartikli,ref kategorija,ref racuni,ref admins);
            //Startup(ref zaposlenici,ref sviartikli,ref kategorija,ref racuni);
            SpremanjeUXMLzaposlenike(ref zaposlenici);
            SpremanjeUXMLartikle(ref sviartikli);
            SpremanjeUXMLkategorije(ref kategorija);
            SpremanjeUXMLracuni(ref racuni);
        }
    }
}