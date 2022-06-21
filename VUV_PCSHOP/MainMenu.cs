using System;
using System.Collections.Generic;
using System.Text;

namespace VUV_PCSHOP
{
    class MainMenu:Program
    {
        public void Start(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
           Console.Title= ("IT trgovina");
            RunMainMenu(ref zaposlenici,ref sviartikli,ref kategorije,ref racuni);
        }
        private void RunMainMenu(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
           
            string prompt = "Odaberite Zaposlenika";
            string[] options = new string[zaposlenici.Count];
            int i = 0;
            foreach (Zaposlenik z in zaposlenici)
            {
                options[i] = z.IspisPunogImena();
                i++;

            }
          
            Meni mainMeni = new Meni(options, prompt);
            int selectedIndex = mainMeni.Run();
            PrijaveljniZaposlenik.prijavljeni = zaposlenici[selectedIndex];
            Console.WriteLine("Odabir uspjesan!" + PrijaveljniZaposlenik.prijavljeni.IspisPunogImena());
            Izbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);

            }

    
        private void Izbornik(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            string prompt = "VUV PC SHOP";
            Racun r1=new Racun();
            string[] options = { "Dodavanje/Azuriranje/Brisanje Artikla", "Pregled artikala", "Kreiraj Racun", "Pregled racuna po zaposleniku", "izlaz" };
            Meni mainMeni = new Meni(options, prompt);
            int selectedIndex = mainMeni.Run();
            switch(selectedIndex)
            {
                case 0:
                    DABArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 1:
                    PregledArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 2:
                    KreirajRacun(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni,ref r1);
                    break;
                case 3:
                    PregledRacuna(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 4:
                    Izlaz();
                    break;

               
            }
            
        }
        private void DABArtikli(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            string prompt = "VUV PC SHOP";
            string[] options = { "Dodavanje", "Azuriranje", "Brisanje", "Nazad"};
            Meni mainMeni = new Meni(options, prompt);
            int selectedIndex = mainMeni.Run();
            switch (selectedIndex)
            {
                case 0:
                    DodavanjeArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 1:
                    AzuriranjeArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 2:
                    BrisanjeArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 3:
                    Izbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;

            }
        }
        private void DodavanjeArtikli(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
         while (true)
            {
                string prompt = "Odaberi kategoriju";
                string[] options = {""};

                List<string> kljuckat = new List<string>();
                int i = 0;
                foreach (KeyValuePair<string, string> kategorija in kategorije)
                {
                   
                    i++;
                    kljuckat.Add(kategorija.Key);
                   
                }
                options = new string[i + 1];
                int j = 0;
                foreach(KeyValuePair<string,string> kategorija in kategorije)
                {
                    options[j] = kategorija.Value;
                    j++;
                }
                options[i] = "Izlaz";
                Meni mainMeni = new Meni(options, prompt);
                int selectedIndex = mainMeni.Run();
                if (selectedIndex == i)
                {
                    DABArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                }
                else
                {


                    Console.WriteLine("Naziv:");
                    string naziv = Console.ReadLine();
                    Console.WriteLine("Opis:");
                    string opis = Console.ReadLine();
                    Console.WriteLine("Jedinica Mjere:");
                    string mjera = Console.ReadLine();
                    Console.WriteLine("Jedinicna cijena:");
                    double kolicina = Convert.ToDouble(Console.ReadLine());
                    Artikl noviartikl = new Artikl(naziv, opis, mjera, kolicina);
                    noviartikl.DodavanjeKategorije(kljuckat[selectedIndex]);
                    sviartikli.Add(noviartikl);
                    Console.WriteLine("Dodavanje Uspjesno!");
                    Console.ReadKey();
                    Console.Clear();
                 }
           }



        }
        private void AzuriranjeArtikli(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            while (true)
            {
                string prompt = "Odaberite Artikl koji zelite azurirati";
                string[] options = { "" };

                List<string> kljuckat = new List<string>();
                int i = 0;
                options = new string[sviartikli.Count+1];
                options[sviartikli.Count] = "Izlaz";
               
                foreach (Artikl artikl in sviartikli)
                {
                    options[i] = artikl.Naziv;
                    i++;
                }
                options[i] = "Izlaz";
                Meni mainMeni = new Meni(options, prompt);
                int selectedIndex = mainMeni.Run();
                if (selectedIndex == i)
                {
                    DABArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                }
                else
                {
                   bool ispit = true;
                    while(ispit==true)
                    {
                        List<string> listakljuceva = new List<string>();
                        string prompt2 = "Odaberite sta zelite azurirati:";
                    string[] options2 = {"Kategoriju","Naziv","Opis","Jedinicnu Mjeru","Cijenu","Izlaz"};
                        Meni mainMeni2 = new Meni(options2, prompt2);
                        int selectedIndex2 = mainMeni2.Run();
                        switch(selectedIndex2)
                        {
                            case 0:
  
                                string prompt3=("Odaberite novu kategoriju:");
                                string[] options3=new string[kategorije.Count+1];
                                options3[kategorije.Count]="Nazad";
                                int x = 0;
                                foreach (KeyValuePair<string, string> kljuc in kategorije)
                                {
                                    listakljuceva.Add(kljuc.Value);
                                    options3[x] = kljuc.Value;
                                    x++;
                                }
                                Meni mainMeni3 = new Meni(options3, prompt3);
                                int selectedIndex3 = mainMeni3.Run();

                                if(selectedIndex3==kategorije.Count)
                                {
                                    AzuriranjeArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                                }
                                else
                                {

                                    sviartikli[selectedIndex].Kategorija = listakljuceva[selectedIndex3];
                                }
                                break;
                            case 1:
                                Console.WriteLine("Unesite novi naziv:");
                                string naziv = Console.ReadLine();
                                sviartikli[selectedIndex].Naziv = naziv;
                                break;
                            case 2:
                                Console.WriteLine("Unesite novi opis:");
                                string opis = Console.ReadLine();
                                sviartikli[selectedIndex].Opis = opis;
                                break;
                            case 3:
                                Console.WriteLine("Unesite novu jedinicnu mjeru:");
                                string jedmjer = Console.ReadLine();
                                sviartikli[selectedIndex].JedinicaMjere = jedmjer;
                                break;
                            case 4:
                                Console.WriteLine("Unesite novu cijenu:");
                                string cijena = Console.ReadLine();
                                if (int.TryParse(cijena, out int cij))
                                    sviartikli[selectedIndex].Cijena = cij;
                                break;
                            case 5:
                               ispit=false;
                                break;
                        }
                    }
                }
            }
        }
        private void BrisanjeArtikli(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            while (true)
            {
                string prompt = "Odaberite Artikl koji zelite azurirati";
                string[] options = { "" };

                int i = 0;
                options = new string[sviartikli.Count + 1];
                options[sviartikli.Count] = "Izlaz";

                foreach (Artikl artikl in sviartikli)
                {
                    options[i] = artikl.Naziv;
                    i++;
                }
                options[i] = "Izlaz";
                Meni mainMeni = new Meni(options, prompt);
                int selectedIndex = mainMeni.Run();
                if (selectedIndex == i)
                {
                    DABArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                }
                else
                {
                    sviartikli.RemoveAt(selectedIndex);
                }
            }
        }
        private void PregledArtikli(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            List<Artikl> artikliukat = new List<Artikl>();
            List<string> kljuckat = new List<string>();
            string prompt3 = ("Odaberite kategoriju:");
            string[] options3 = new string[kategorije.Count + 1];
            options3[kategorije.Count] = "Nazad";
            int x = 0;
            foreach (KeyValuePair<string, string> kljuc in kategorije)
            {
                kljuckat.Add(kljuc.Key);
                options3[x] = kljuc.Value;
                x++;
            }
            Meni mainMeni3 = new Meni(options3, prompt3);
            int selectedIndex3 = mainMeni3.Run();
            if (selectedIndex3==x)
            {
                Izbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
            }
            else
            {
                string prompt1 = ("Odaberite artikl:          Dostupnost:");

                int x1 = 0;

                foreach (Artikl art in sviartikli)
                {
                    if (art.Kategorija == kljuckat[selectedIndex3])
                    {
                        artikliukat.Add(art);
                        x1++;

                    }

                }
                string[] options1 = new string[x1+1];
                int j = 0;
                foreach (Artikl art in sviartikli)
                {
                    if (art.Kategorija == kljuckat[selectedIndex3])
                    {
                        options1[j] = art.Naziv+"   "+art.Dostupnost;
                        j++;

                    }

                }
                options1[j] = "Izlaz";
                izbor2:
                Meni mainMeni1 = new Meni(options1, prompt1);
                int selectedIndex1 = mainMeni1.Run();
                if (selectedIndex1 == j)
                {
                    PregledArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                }
                else
                {
                    string prompt2 = "Odaberite Dostupnost:";
                    string[] options2 = { "da", "ne", "nazad" };
                    Meni mainMeni2= new Meni(options2, prompt2);
                    int selectedIndex2 = mainMeni2.Run();
                    if(selectedIndex2!=2)
                    artikliukat[selectedIndex1].Dostupnost = options2[selectedIndex2];
                    else
                    {
                        goto izbor2;
                    }
                }
                Console.ReadKey();
                Console.Clear();
                PregledArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
            }

        }
        private void KreirajRacun(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni,ref Racun r1)
        {
            try
            {

                
                

                
                    string prompt = "VUV PC shop";
                    string[] options = { "Dodavanje stavki","Zavrsi Racun","Izlaz" };
                    Meni mainMeni = new Meni(options, prompt);
                    int selectedIndex = mainMeni.Run();
                    


                   

                        switch (selectedIndex)
                        {
                            case 0:
                                r1 = DodavanjeStavki(ref kategorije, ref sviartikli, ref racuni,ref zaposlenici,ref r1);
                        KreirajRacun(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni,ref r1);
                                break;
                            case 1:
                                if (r1 != null)
                                {
                                    r1.Sifrazaposlenika = PrijaveljniZaposlenik.prijavljeni.Sifrazaposlenika;
                                    r1.Datum = DateTime.Now;
                                    
                                    racuni.Add(r1);
                            //for (int i = 0; i < r1.Stavke.Count; i++)
                            //{
                            //    Console.WriteLine("Stavka " + i + "." + r1.Stavke[i].Naziv);

                            //}
                            //Console.ReadKey();
                            //        foreach (Racun rac in racuni)
                            //        {

                            //            for (int j = 0; j < rac.Stavke.Count; j++)
                            //            {
                            //                Console.WriteLine("Naziv:"+rac.Stavke[j].Naziv);
                            //                Console.WriteLine("Kolicina:"+rac.Stavke[j].Kolicina);
                                       
                            //            }


                            //        }
                            //Console.ReadKey();
                                    r1 = null;

                                }
                                else
                                {
                                    Console.WriteLine("prazan racun!");
                                }
                        Izbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                                break;
                        case 2:
                            Izbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                            break;

                        }


                


            }
            catch (Exception)
            {

                throw;
            }
        }
        private static Racun DodavanjeStavki(ref Dictionary<string, string> kategorije, ref List<Artikl> sviartikli, ref List<Racun> racuni, ref List<Zaposlenik> zaposlenici,ref Racun r1)
        {

            List<Artikl> artikliukat = new List<Artikl>();
            List<Stavka> stavke = new List<Stavka>();
            List<string> kljuckat = new List<string>();
          


            string prompt = ("Odaberite kategoriju:");
            string[] options = new string[kategorije.Count + 1];
            int x = 0;
            foreach (KeyValuePair<string, string> kljuc in kategorije)
            {
                kljuckat.Add(kljuc.Key);
                options[x] = kljuc.Value;
                x++;
            }
            options[kategorije.Count] = "Nazad";
                Meni mainMeni = new Meni(options, prompt);
                int selectedIndex = mainMeni.Run();


                if(selectedIndex==kategorije.Count)
            {
                return r1;
            }
            else { 
                   
                    string prompt1 = ("Odaberite artikl:");
                 
 

                    foreach (Artikl art in sviartikli)
                    {
                        if (art.Kategorija == kljuckat[selectedIndex])
                        {
                        if (art.Dostupnost == "da")
                            artikliukat.Add(art);
        

                        }

                    }

               
                int j = 0;
                    foreach (Artikl art in sviartikli)
                    {
                    if (art.Kategorija == kljuckat[selectedIndex])
                    {
                        if (art.Dostupnost == "da")
                        { 
                      
                            j++;
                        }
                    }

                    }
                string[] options1 = new string[j+1];
                int k = 0;
                foreach (Artikl art in sviartikli)
                    {
                    if (art.Kategorija == kljuckat[selectedIndex])
                    {
                        if (art.Dostupnost == "da")
                        {
                            options1[k] = art.Naziv;
                            k++;
                        }
                    }

                    }
              
                options1[j] = "Izlaz2";
                Meni mainMeni1 = new Meni(options1, prompt1);
                    int selectedIndex1 = mainMeni1.Run();
                if (selectedIndex1 != j) 
                { 
                    Console.Write("Kolicina:");
                        int kol = Convert.ToInt32(Console.ReadLine());

                        Stavka s1 = new Stavka(artikliukat[selectedIndex1], kol);


                        r1.DodavanjeStavke(s1);
                    Console.ReadKey();
                }
                artikliukat.Clear();

                            DodavanjeStavki(ref kategorije, ref sviartikli, ref racuni, ref zaposlenici,ref r1);

            
                        
 
                    return (r1);

            }
        } 
        private void PregledRacuna(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
             {
            try
            {

           
            string prompt = "Odaberite Zaposlenika";
            string[] options=new string [zaposlenici.Count+1];
            int i = 0;
            foreach (Zaposlenik z in zaposlenici)
            {
                options[i] = z.IspisPunogImena();
                i++;

            }
            options[zaposlenici.Count] = "Izlaz";
            Meni mainMeni = new Meni(options, prompt);
            int selectedIndex = mainMeni.Run();
            if(selectedIndex==zaposlenici.Count)
            {
                Izbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
            }
            else
            {
                foreach(Racun rac in racuni)
                {
                    if (rac.Sifrazaposlenika == zaposlenici[selectedIndex].Sifrazaposlenika)
                    { 
                    Console.WriteLine("Sifra Racuna:"+rac.Sifraracuna);
                    Console.WriteLine("Datum:"+rac.Datum);
                    Console.WriteLine("Iznos:"+rac.Ukupaniznos);
                    }
                }
                    Console.ReadKey();
                    PregledRacuna(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    
            }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
     
        private void Izlaz()
        {
            Console.WriteLine("Pritisnite bilo koju tipku za izlaz...");
            Console.ReadKey(true);
        
        }
    }
}
