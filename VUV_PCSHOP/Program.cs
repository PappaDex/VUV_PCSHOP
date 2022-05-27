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
        static void Startup(ref List<Zaposlenik>zaposlenici)
        {
            try
            {
                do
                {
                    odabir:
                    int i = 1;
                    Console.WriteLine("Odaberite zaposlenika:");
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
                        Izbornik();
                        break;
                    
                    }
                    else
                    {

                    }
                    
                } while (true);

            }
            catch (Exception)
            {

                throw;
            }
        }
        static void SpremanjeUliste(ref List<Zaposlenik> zaposlenici)
        {
            string xml = "";
            StreamReader sr = new StreamReader("C:\\Users\\dakic\\source\\repos\\VUV_PCSHOP\\VUV_PCSHOP\\XML\\zaposlenici.xml");
            using(sr)
            {
                xml=sr.ReadToEnd();
            }
            sr.Close();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            XmlNodeList zaposlenik = xmlObject.SelectNodes("//vuv_pcshop/osoba/zaposlenici/zaposlenik");
        }
        static void SpremanjeUXML(ref List<Zaposlenik> zaposlenici)
        {
            string xml = "";
            StreamReader sr = new StreamReader("C:\\Users\\dakic\\source\\repos\\VUV_PCSHOP\\VUV_PCSHOP\\XML\\zaposlenici.xml");
            using (sr)
            {
                xml = sr.ReadToEnd();
            }
            sr.Close();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            string lokacijaxmla = "C:\\Users\\dakic\\source\\repos\\VUV_PCSHOP\\VUV_PCSHOP\\XML\\zaposlenici.xml";
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
        static void Izbornik()
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
            List<Zaposlenik> zaposlenici = new List<Zaposlenik>();
            List<Artikl> sviartikli = new List<Artikl>();
            Startup(ref zaposlenici);
            SpremanjeUXML(ref zaposlenici);
        }
    }
}
