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
        static void DodavanjeArtikla(ref List<Artikl> sviartikli)
        {
            try
            {
                do
                {
                    Console.WriteLine("Odaberite Kategoriju:" +
                        "\n1.Laptopi,Racunala" +
                        "\n2.Komponente" +
                        "\n3.Konzole" +
                        "\n4.Monitori,Periferija" +
                       
                        "\nESC.Exit");
                   
                   
                    string izbor = Console.ReadLine();
                    int izb;
                    if (int.TryParse(izbor, out izb) == true)
                    {   Console.WriteLine("Naziv:");
                            string naziv = Console.ReadLine();
                            Console.WriteLine("Opis:");
                            string opis = Console.ReadLine();
                            Console.WriteLine("Jedinica Mjere:");
                            string mjera = Console.ReadLine();
                            Console.WriteLine("Kolicina:");
                            int kolicina=Convert.ToInt32(Console.ReadLine());
                            Artikl noviartikl = new Artikl(naziv,opis,mjera,kolicina);
                        izb = Convert.ToInt32(izbor);
                        noviartikl.AddKategorija(izb, noviartikl);
                        sviartikli.Add(noviartikl);
                        
                         
                       
                        
                 
                      
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
        static void Startup(ref List<Zaposlenik>zaposlenici,ref List<Artikl>sviartikli)
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
                            Console.WriteLine("Sigra Zaposlenika:");
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



                        Izbornik(ref sviartikli);
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
        static void SpremanjeUliste(ref List<Zaposlenik> zaposlenici,ref List<Artikl>sviartikli)
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
        
        static void SpremanjeUXML(ref List<Zaposlenik> zaposlenici)
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
        static void Izbornik(ref List<Artikl>artikli)
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
                        sw1int = Convert.ToInt32(switch1);
                        switch (sw1int)
                        {
                            case 1:
                                DodavanjeArtikla(ref artikli);
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
          
            SpremanjeUliste(ref zaposlenici,ref sviartikli);
            Startup(ref zaposlenici,ref sviartikli);
            SpremanjeUXML(ref zaposlenici);
        }
    }
}
