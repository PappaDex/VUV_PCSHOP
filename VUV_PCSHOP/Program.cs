using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
namespace VUV_PCSHOP
{
    class Program
    {
        static class PrijaveljniZaposlenik
        {
          public  static Zaposlenik prijavljeni;
        }
        static class FileLocation
        {
            public static string lokacija;
        }
        static void LokacijaDatoteke()
        {
            string lokacija =Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            lokacija = Path.GetDirectoryName(lokacija);
            FileLocation.lokacija = lokacija;
        }
        //static void PopisKategorija(ref Dictionary<string,string>kategorije)
        //{
        //    kategorije.Add("LAP","Laptopi,Racunala");
        //    kategorije.Add("KOM","Komponente");
        //    kategorije.Add("KON","Konzole");
        //    kategorije.Add("MON","Monitori,Periferija");
        //    kategorije.Add("SOF", "Software,Kablovi");

        //}
        static void KreiranjeRacuna(ref List<Racun> racuni,ref Dictionary<string,string>kategorije,ref List<Artikl>artikli) 
        {
            try
            {

                Racun r1 = new Racun();
                do
                {
                    Console.WriteLine("Odabir:" +
                        "\n1.Dodavanje Stavki" +
                        "\n2.Zavrsi Racun");
                  
                   
                    string izbor = Console.ReadLine();
                    int izb;
                    if (int.TryParse(izbor, out izb) == true)                    {
                        
                        switch(izb)
                        {
                            case 1:
                               r1=DodavanjeStavki(ref kategorije, ref artikli,ref racuni);
                                break;
                            case 2:
                                if (r1 != null)
                                {
                                    r1.Sifrazaposlenika = PrijaveljniZaposlenik.prijavljeni.Sifrazaposlenika;
                                    r1.Datum = DateTime.Now;
                                    racuni.Add(r1);
                                }
                                else
                                {
                                    Console.WriteLine("prazan racun!");
                                }
                                    break;

                        }
                     
                       
                    }
                    else
                    {

                    }

                } while (Console.ReadKey().Key != ConsoleKey.Escape);
                Console.Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }
        static Racun DodavanjeStavki(ref Dictionary<string,string>kategorije,ref List<Artikl>artikli,ref List<Racun>racuni)
        {
            try
            {
                List<Artikl> artikliukat = new List<Artikl>();
                List<Stavka> stavke = new List<Stavka>();
                List<string> kljuckat = new List<string>();
                Racun r1 = new Racun();
                int i = 1;
                Console.WriteLine("Odaberite Kategoriju:");
                foreach (KeyValuePair<string, string> kategorija in kategorije)
                {

                    Console.WriteLine(i + "." + kategorija.Value);
                    kljuckat.Add(kategorija.Key);
                 
                    i++;
                }

                string izbor = Console.ReadLine();
                int izb;
                if (int.TryParse(izbor, out izb) == true)
                {
                    do
                    {
                        izb = Convert.ToInt32(izbor);
                        int j = 1;
                        Console.WriteLine("Odaberi Artikl:");
                        foreach (Artikl art in artikli)
                        {
                            if (art.Kategorija == kljuckat[izb - 1])
                            {
                                Console.WriteLine(j + "." + art.Naziv +
                                    "\nOpis:" + art.Opis);
                                artikliukat.Add(art);
                                Console.WriteLine("kat:"+kljuckat[izb-1]);
                                j++;
                            
                            }

                        }
                         izbor = Console.ReadLine();
                        if (int.TryParse(izbor, out  izb) == true)
                        {
                            izb = Convert.ToInt32(izbor);
                            
                            Console.Write("Kolicina:");
                            int kol = Convert.ToInt32(Console.ReadLine());

                            Stavka s1 = new Stavka(artikliukat[izb-1],kol);
                          
                              
                            Console.WriteLine("test:");
                            Console.WriteLine(s1.Kategorija);
                            r1.DodavanjeStavke(s1);
                        }    
                            Console.WriteLine("ESC-izlaz");
                        artikliukat.Clear();
                    } while (Console.ReadKey().Key != ConsoleKey.Escape);
                  

                }
                return (r1);


            }



            catch (Exception)
            {

                throw;
            }
        }
        static void DodavanjeArtikla(ref List<Artikl> sviartikli,ref Dictionary<string,string>kategorije)
        {
            try
            {
               
                do
                {
                    List<string> kljuckat = new List<string>();
                    int i = 1;
                    Console.WriteLine("Odaberite Kategoriju:");
                    foreach(KeyValuePair<string,string> kategorija in kategorije)
                    {

                        Console.WriteLine(i+"."+kategorija.Value);
                        kljuckat.Add(kategorija.Key);
                        i++;
                    }
                    string izbor = Console.ReadLine();
                    int izb;
                    if (int.TryParse(izbor, out izb) == true)
                    {   Console.WriteLine("Naziv:");
                            string naziv = Console.ReadLine();
                            Console.WriteLine("Opis:");
                            string opis = Console.ReadLine();
                            Console.WriteLine("Jedinica Mjere:");
                            string mjera = Console.ReadLine();
                            Console.WriteLine("Jedinicna cijena:");
                            double kolicina=Convert.ToDouble(Console.ReadLine());
                            Artikl noviartikl = new Artikl(naziv,opis,mjera,kolicina);
                        izb = Convert.ToInt32(izbor);
                        noviartikl.DodavanjeKategorije(kljuckat[izb - 1]);
                        sviartikli.Add(noviartikl);
                        Console.WriteLine("Dodavanje Uspjesno!");
                        Console.ReadKey();
                        Console.Clear();
                        
                        break;

                    }
                    else
                    {

                    }

                } while (Console.ReadKey().Key != ConsoleKey.Escape);
                Console.Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }
        static void AzuriranjeArtikla(ref List<Artikl> artikli, ref Dictionary<string, string> kategorije)
        {
            try
            {
                do
                {
                    List<string> listakljuceva = new List<string>();
                    int i = 1;
                    Console.WriteLine("Odaberite Artikl Koji zelite azurirat:");
                    foreach(Artikl art in artikli)
                    {
                        Console.WriteLine(i+"."+art.Naziv);
                        i++;

                    }

                    string izbor1 = Console.ReadLine();
                    if(int.TryParse(izbor1,out int izb1))
                    {
                        izb1 = Convert.ToInt32(izbor1);
                    }
                    do
                    {
                        Console.WriteLine("Odaberite sta zelite azurirat" +
                            "\n1.Kategoriju" +
                            "\n2.Naziv" +
                            "\n3.Opis" +
                            "\n4.Jedinicnu Mjeru" +
                            "\n5.Cijenu" +
                            "\nESC-Exit");

                        string izbor = Console.ReadLine();
                        if (int.TryParse(izbor, out int izb))
                        {
                            izb = Convert.ToInt32(izbor);
                            if(izb==1)
                            {
                                Console.WriteLine("Odaberite novu kategoriju:");
                                int j = 1;
                                foreach(KeyValuePair<string,string> kljuc in kategorije)
                                {
                                    Console.WriteLine(j+"."+kljuc.Value);
                                    listakljuceva.Add(kljuc.Value);
                                    j++;
                                }
                                string izbor3= Console.ReadLine();
                                if(int.TryParse(izbor3,out int izb3))
                                {
                                    artikli[izb1 - 1].Kategorija = listakljuceva[izb3];
                                }
                                
                            }
                            if(izb==2)
                            {
                                Console.WriteLine("Unesite novi naziv:");
                                string naziv = Console.ReadLine();
                                artikli[izb - 1].Naziv = naziv;
                            }
                            if(izb==3)
                            {
                                Console.WriteLine("Unesite novi opis:");
                                string opis = Console.ReadLine();
                                artikli[izb - 1].Opis = opis;
                            }
                            if(izb==4)
                            {
                                Console.WriteLine("Unesite novu jedinicnu mjeru:");
                                string jedmjer = Console.ReadLine();
                                artikli[izb - 1].JedinicaMjere = jedmjer;
                            }
                            if(izb==5)
                            {
                                Console.WriteLine("Unesite novu cijenu:");
                                string cijena = Console.ReadLine();
                                if(int.TryParse(cijena,out int cij))
                                artikli[izb - 1].Cijena = cij;
                            }
                        }

                    } while (Console.ReadKey().Key != ConsoleKey.Escape);


                } while (Console.ReadKey().Key != ConsoleKey.Escape);
                }
            catch (Exception)
            {

                throw;
            }
        }
        static void BrisanjeArtikla(ref List<Artikl> artikli)
        {
            try
            {

                int i = 0;
            Console.WriteLine("Odaberite Artikl koji zelite obrisat");
            foreach(Artikl art in artikli)
                {
                    Console.WriteLine(i+"."+art.Naziv);
                    i++;
                }
                string odabir = Console.ReadLine();
                if(int.TryParse(odabir,out int odb))
                {
                    artikli.RemoveAt(i-1);
                }

             }
            catch (Exception)
            {

                throw;
            }
        }
        static void Startup(ref List<Zaposlenik>zaposlenici,ref List<Artikl>sviartikli,ref Dictionary<string,string>kategorije,ref List<Racun>racuni)
        {
            try
            {
                do
                {
                    odabir:
                    int i = 1;
                    Console.WriteLine("Odaberite zaposlenika:" +
                        "\nESC.Logout");
                    foreach(Zaposlenik z in zaposlenici)
                    {
                        Console.WriteLine(i+"."+z.IspisPunogImena());
                        i++;
                    }
                    string izbor = Console.ReadLine();
                    int izb;
                    if (int.TryParse(izbor, out izb) == true)
                    {
                        if(izb==-1)
                        {
                            Console.WriteLine("OIB:");
                            string oibz=Console.ReadLine();
                            Console.WriteLine("Ime:");
                            string imez=Console.ReadLine();
                            Console.WriteLine("Prezime:");
                            string prezimez=Console.ReadLine();
                            Console.WriteLine("Sifra Zaposlenika:");
                            string sifraz=Console.ReadLine();
                            Zaposlenik novizaposlenik = new Zaposlenik(oibz, imez, prezimez, sifraz);
                            zaposlenici.Add(novizaposlenik);
                            goto odabir;
                        }
                        izb = Convert.ToInt32(izbor);
                       PrijaveljniZaposlenik.prijavljeni=zaposlenici[izb-1];
                        Console.WriteLine("Odabir uspjesan!"+PrijaveljniZaposlenik.prijavljeni.IspisPunogImena());
                        Console.ReadKey();
                        Console.Clear();



                        Izbornik(ref sviartikli,ref kategorije,ref racuni);
                        break;
                    
                    }
                    else
                    {

                    }
                    
                } while (Console.ReadKey().Key != ConsoleKey.Escape);

            }
            catch (Exception)
            {

                throw;
            }
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
                zaposlenici.Add(new Zaposlenik(
                    zap.Attributes["oib"].Value,
                    zap.Attributes["ime"].Value,
                    zap.Attributes["prezime"].Value,
                    zap.Attributes["sifrazaposlenika"].Value
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
        foreach(XmlNode art in artikl)
            {
                sviartikli.Add(new Artikl(
                    art.Attributes["kategorija"].Value,
                    art.Attributes["naziv"].Value,
                    art.Attributes["opis"].Value,
                    art.Attributes["jedinicamjere"].Value,
                  Convert.ToInt32(art.Attributes["cijena"].Value)
                    ));;
            }
        }  
        //static void SaveListRacuni(ref List<Racun>sviracuni)
        //{
        //    List<Stavka> s1 = new List<Stavka>();
        //    string lok = FileLocation.lokacija + "\\XML\\racuni.xml";
        //    string xml = "";
        //    StreamReader sr = new StreamReader(lok);
        //    using(sr)
        //    {
        //        xml=sr.ReadToEnd();
        //    }
        //    sr.Close();
        //    XmlDocument xmlObject = new XmlDocument();
        //    xmlObject.LoadXml(xml);
        //    XmlNodeList racuni = xmlObject.SelectNodes("//vuv_pcshop/racuni/racun");
        //    XmlNodeList stavke = xmlObject.SelectNodes("//vuv_pcshop/racuni/racun/stavka");
        //foreach(XmlNode stavka in stavke)
        //    {
        //        s1.Add(new Stavka(
                    
        //    new Artikl(stavka.Attributes["kategorijaartikla"].Value,
        //        stavka.Attributes["nazivartikla"].Value,
        //        stavka.Attributes["opisartikla"].Value,
        //        stavka.Attributes["jedinicamjereartikla"].Value,
        //       Convert.ToDouble(stavka.Attributes["cijenaartikla"].Value)
        //       )



        //        )); ; ; ;
        //    }
        //        foreach (XmlNode rac in racuni)
        //    {

        //        sviracuni.Add(new Racun(
        //            new(Stavka(

        //            rac.Attributes["sifrazaposlenik"].Value,
        //            rac.Attributes["sifraracun"].Value,
        //           Convert.ToDouble(rac.Attributes["ukupniznos"].Value),
        //           Convert.ToDateTime(rac.Attributes["datum"].Value)

        //            )) ; ;
        //    }
        //} 
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
            
        static void ArtikliMeni(ref List<Artikl>artikli,ref Dictionary<string,string>kategorije)
        {

            do
            {
                Console.WriteLine("Izbornik" +
                    "\n1.Dodavanje" +
                    "\n2.Azuriranje" +
                    "\n3.Brisanje");

                string izbor = Console.ReadLine();
                if (int.TryParse(izbor, out int izb))
                {
                    izb = Convert.ToInt32(izbor);
                    switch (izb)
                    {
                        case 1:
                            {
                                DodavanjeArtikla(ref artikli, ref kategorije);
                                break;
                            }
                        case 2:
                            {
                                AzuriranjeArtikla(ref artikli, ref kategorije);
                                break;
                            }
                        case 3:
                            BrisanjeArtikla(ref artikli);
                            break;
                    }
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
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
            string lokacijaxmla = FileLocation.lokacija+"\\XML\\racuni.xml";
            XmlNode racuniNode = xmlObject.SelectSingleNode("//vuv_pcshop/racuni");
            int i = 0;
            XmlNode artiklNode = xmlObject.SelectSingleNode("//vuv_pcshop/racuni/racun/stavka");
            racuniNode.RemoveAll();
            foreach(Racun rac in racuni)
            {
                List<Stavka> s1 = new List<Stavka>();
                s1 = rac.Stavke;
                XmlNode noviNode = xmlObject.CreateNode(XmlNodeType.Element, "racun", null);
                XmlAttribute sifrazaposlenikaAttr = xmlObject.CreateAttribute("sifrazaposlenika");
                sifrazaposlenikaAttr.Value = rac.Sifrazaposlenika.ToString();
                noviNode.Attributes.Append(sifrazaposlenikaAttr);
                XmlAttribute sifraracunaAttr = xmlObject.CreateAttribute("sifraracuna");
                sifraracunaAttr.Value = rac.Sifraracuna.ToString();
                noviNode.Attributes.Append(sifraracunaAttr);
                XmlAttribute ukupaniznosAttr = xmlObject.CreateAttribute("ukupaniznos");
                ukupaniznosAttr.Value = rac.Ukupaniznos.ToString();
                noviNode.Attributes.Append(ukupaniznosAttr);
                XmlAttribute datumAttr = xmlObject.CreateAttribute("datum");
                datumAttr.Value = rac.Datum.ToString();
                noviNode.Attributes.Append(datumAttr);
              
                
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
                    if (i == 0)
                    {
                        racuniNode.AppendChild(noviNode);
                        i++;
                    }
                    XmlNode stavkeNode = xmlObject.SelectSingleNode("//vuv_pcshop/racuni/racun");
                    stavkeNode.AppendChild(novi2Node);

                }

                racuniNode.AppendChild(noviNode);

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
        static void Izbornik(ref List<Artikl>artikli,ref Dictionary<string,string>kategorije,ref List<Racun>racuni)
        {
            try
            {
             
             
                do
                {
                    Console.WriteLine("" +
                    "1.Dodavanje/Azuriranje/Brisanje Artikla" +
                    "\n2.Pregled artikala" + 
                    "\n3.Kreiraj Racun" +
                    "\n4.Pregled racuna po zaposleniku" +
                    "\nESC.izlaz");

                    string switch1 = Console.ReadLine();
                    int sw1int;
                    if (int.TryParse(switch1, out sw1int) == true)
                    {
                        
                        switch (sw1int)
                        {
                            case 1:
                                Console.Clear();
                                ArtikliMeni(ref artikli,ref kategorije);
                                break;
                            case 3:
                                Console.Clear();
                                KreiranjeRacuna(ref racuni,ref kategorije,ref artikli);
                                    break;
                            default:
                                break;
                        }
                    }

                    Console.Clear();
                
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
                
            }


            catch (Exception)
            {

                throw;
            }
        }
        static void Main(string[] args)
        {
            LokacijaDatoteke();
            List<Zaposlenik> zaposlenici = new List<Zaposlenik>();
            List<Artikl> sviartikli = new List<Artikl>();
            List<Racun> racuni = new List<Racun>();
            Dictionary<string, string> kategorija = new Dictionary<string, string>();
            //PopisKategorija(ref kategorija);
            SaveDictKategorije(ref kategorija);
            SaveListZaposlenici(ref zaposlenici);
            SaveListArtikli(ref sviartikli);    
            Startup(ref zaposlenici,ref sviartikli,ref kategorija,ref racuni);
            SpremanjeUXMLzaposlenike(ref zaposlenici);
            SpremanjeUXMLartikle(ref sviartikli);
            SpremanjeUXMLkategorije(ref kategorija);
            SpremanjeUXMLracuni(ref racuni);
        }
    }
}