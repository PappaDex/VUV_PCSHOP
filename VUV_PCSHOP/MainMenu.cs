using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace VUV_PCSHOP
{
    class MainMenu : Program
    {
        public void Start(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni, ref List<Admin> admins)
        {
            Console.Title = ("VUV PC SHOP");
            LoginMeni(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni, ref admins);
        }
        private void LoginMeni(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni, ref List<Admin> admins)
        {
            string prompt1 = "Prijava:";
            string[] options1 = { "Admin", "Zaposlenik" };
            Meni prijavaMeni = new Meni(options1, prompt1);
            int selectedIndex1 = prijavaMeni.Run();
            if (selectedIndex1 == 0)
            {
                AdminLogin(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni, ref admins);
            }
            else
            {
                RunMainMenu(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
            }
        }
        private void AdminLogin(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni, ref List<Admin> admins)
        {
            string username="";
            string password="";

            bool ex = false;
            while (ex == false)
            {
                Console.Write("Username:");
                 username = Console.ReadLine();
                Console.Write("Password:");
                
                 password = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    Exceptions e1 = new Exceptions("Username/Password ne smije bit prazan!");
                    Console.WriteLine(e1);
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    ex = true;
                }
            }
            bool ispit = false;
            foreach (Admin admin in admins)
            {
                if (admin.Username == username && admin.Password == password)
                {
                    ispit = true;


                }

            }
            if (ispit == true)
            {

                Console.WriteLine("Login uspjesan!");
                Console.ReadKey();
                AdminIzbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);

            }
            else
            {
                Console.WriteLine("Krivi unos!");
                Console.ReadKey();
                LoginMeni(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni, ref admins);
             
            }
       

        }
        private void AdminIzbornik(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            string prompt = "VUV PC SHOP";
            Racun r1 = new Racun();
            string[] options = { "Dodavanje/Azuriranje/Brisanje Zaposlenika", "Statistika", "Stoniraj Racun", "Dodavanje/Brisanje Kategorije", "izlaz" };
            Meni mainMeni = new Meni(options, prompt);
            int selectedIndex = mainMeni.Run();
            switch (selectedIndex)
            {
                case 0:
                    DABZaposlenici(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 1:
                    Statistika(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 2:
                    StonirajRacun(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 3:
                    DBKategorije(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;



            }
        }
        private void DABZaposlenici(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            string prompt = "VUV PC SHOP";
            string[] options = { "Dodavanje", "Azuriranje", "Brisanje", "Nazad" };
            Meni mainMeni = new Meni(options, prompt);
            int selectedIndex = mainMeni.Run();
            switch (selectedIndex)
            {
                case 0:
                    DodavanjeZaposlenik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 1:
                    AzuriranjeZaposlenik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 2:
                    BrisanjeZaposlenik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 3:
                    AdminIzbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;

            }
        }
        private void DodavanjeZaposlenik(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {

            bool ex = false;
            while (ex == false)
            {

                Console.WriteLine("OIB:");
                string oibz = Console.ReadLine();
                if (oibz.Length != 11 || string.IsNullOrEmpty(oibz) || double.TryParse(oibz, out double provjera) == false || oibz.Contains(" "))
                {
                    Exceptions ex1 = new Exceptions("Oib moze sadrzit samo brojeve i mora biti duzine 11!");
                    Console.WriteLine(ex1);
                    Console.ReadKey();

                }
                else
                {
                    Console.WriteLine("Ime:");
                    string imez = Console.ReadLine();
                    if (string.IsNullOrEmpty(imez)==true)
                    {
                        Exceptions ex1 = new Exceptions("Ime ne smije bit prazno!");
                        Console.WriteLine(ex1);
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("Prezime:");
                        string prezimez = Console.ReadLine();
                        if (string.IsNullOrEmpty(prezimez)==true)
                        {
                            Exceptions ex1 = new Exceptions("Prezime ne smije bit prazno!");
                            Console.WriteLine(ex1);
                            Console.ReadKey();

                        }
                        else
                        {
                            
                            Console.WriteLine("Sifra Zaposlenika:");
                            string sifraz = Console.ReadLine();
                            if (double.TryParse(sifraz, out double provjera2) == false || string.IsNullOrEmpty(sifraz) == true)
                            {
                                Exceptions ex1 = new Exceptions("Sifra zaposlenika moze bit samo broj i ne smije bit prazna!");
                                Console.WriteLine(ex1);
                                Console.ReadKey();
                            }
                            else
                            {
                                bool postoji = false;
                                  foreach(Zaposlenik zap in zaposlenici)
                                {
                                    if(zap.Sifrazaposlenika==sifraz)
                                    {
                                        Console.WriteLine("Sifra vec u koriscenju!");
                                        postoji = true;
                                        Console.ReadKey();
                                    }
                                }
                                  if(postoji==false)
                                {
                                    Zaposlenik novizaposlenik = new Zaposlenik(oibz, imez, prezimez, sifraz);
                                    zaposlenici.Add(novizaposlenik);
                                    Console.WriteLine("Uspjesno dodavanje!");
                                    Console.ReadKey();
                                    ex = true;
                                }
                            }
                        }
                    }
                }
                Console.Clear();
           
         
            }
            DABZaposlenici(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
        }
        private void AzuriranjeZaposlenik(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            string prompt = "Odaberite Zaposlenika";
            string[] options = new string[zaposlenici.Count + 1];
            int i = 0;
            foreach (Zaposlenik z in zaposlenici)
            {
                options[i] = z.IspisPunogImena();
                i++;

            }
            options[i] = "Izlaz";

            Meni mainMeni = new Meni(options, prompt);
            int selectedIndex = mainMeni.Run();


            if (selectedIndex == i)
            {
                DABZaposlenici(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
            }
            else
            {

                string prompt2 = "Odaberite sta zelite azurirati:";
                string[] options2 = { "OIB", "Ime", "Prezime", "Izlaz" };
                Meni mainMeni2 = new Meni(options2, prompt2);
                int selectedIndex2 = mainMeni2.Run();
                switch (selectedIndex2)
                {
                    case 0:
                        bool isp1 = false;
                        while(isp1==false)
                        { 
                        Console.WriteLine("Unesite novi OIB:");
                        string oib = Console.ReadLine();

                        if (oib.Length != 11 || string.IsNullOrEmpty(oib) || double.TryParse(oib, out double provjera) == false || oib.Contains(" "))
                        {
                            Exceptions ex1 = new Exceptions("Oib moze sadrzit samo brojeve i mora biti duzine 11!");
                                Console.WriteLine(ex1);
                                Console.ReadKey();

                        }
                        else
                        {
                            zaposlenici[selectedIndex].Oib = oib;
                                isp1 = true;
                                AzuriranjeZaposlenik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                            }

                        }
                        break;
                    case 1:
                        bool isp2 = false;
                        while(isp2==false)
                        {     
                        Console.WriteLine("Unesite novo Ime:");
                        string imez = Console.ReadLine();

                        if (string.IsNullOrEmpty(imez) == false)
                        {
                            Exceptions ex1 = new Exceptions("Ime ne smije bit prazno!");
                                Console.WriteLine(ex1);
                                Console.ReadKey();

                        }
                        else
                        {
                            zaposlenici[selectedIndex].Ime = imez;
                                isp2 = true;
                                AzuriranjeZaposlenik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                            }
                        }
                        break;
                    case 2:
                      bool isp3 = false;
                        while(isp3==false)
                        { 
                        Console.WriteLine("Unesite novo prezime:");
                        string prezime = Console.ReadLine();
                        if (string.IsNullOrEmpty(prezime) == false)
                        {
                            Exceptions ex1 = new Exceptions("Prezime ne smije bit prazno!");
                                Console.WriteLine(ex1);

                                Console.ReadKey();

                        }
                        else
                        {
                            zaposlenici[selectedIndex].Prezime = prezime;
                                isp3 = true;
                                AzuriranjeZaposlenik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                        }
                        }

                        break;
                    case 3:
                        AzuriranjeZaposlenik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                        break;

                }

            }
            Console.Clear();
        }
        private void BrisanjeZaposlenik(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            string prompt = "Odaberite Zaposlenika koji zelite obrisat";
            string[] options = { "" };

            int i = 0;
            options = new string[zaposlenici.Count + 1];
            options[zaposlenici.Count] = "Izlaz";

            foreach (Zaposlenik zaposlenik in zaposlenici)
            {
                options[i] = zaposlenik.IspisPunogImena();
                i++;
            }
            options[i] = "Izlaz";
            Meni mainMeni = new Meni(options, prompt);
            int selectedIndex = mainMeni.Run();
            if (selectedIndex == i)
            {
                DABZaposlenici(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
            }
            else
            {
                zaposlenici[selectedIndex].Otkaz(true);
                DABZaposlenici(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
            }
        }
        private void Statistika(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            string prompt = "VUV PC SHOP";
            Racun r1 = new Racun();
            string[] options = { "Najprodavaniji artikli", "Najbolji radnici", "Prodaja u kategorijama", "izlaz" };
            Meni mainMeni = new Meni(options, prompt);
            int selectedIndex = mainMeni.Run();
            switch (selectedIndex)
            {
                case 0:
                    NajprodavanijiArt(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 1:
                    NajRadnici(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 2:
                    NajKat(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
                case 3:
                    AdminIzbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                    break;
            }
        }
        private void NajprodavanijiArt(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            Dictionary<string, double> topart = new Dictionary<string, double>();
            List<Stavka> stavka = new List<Stavka>();
            List<Stavka> topstavke = new List<Stavka>();
         
            foreach   (Racun rac in racuni)
            {
               for(int i=0; i<rac.Stavke.Count;i++)
                {
                    if (topart.ContainsKey(rac.Stavke[i].Naziv))
                    {
                        topart[rac.Stavke[i].Naziv] = topart[rac.Stavke[i].Naziv] + rac.Stavke[i].Kolicina;
                    }    
                        else
                            {
                                topart.Add(rac.Stavke[i].Naziv, rac.Stavke[i].Kolicina);
                            }
                   
                }

            }
            Dictionary<double, string> sorttopart = new Dictionary<double, string>();

            //foreach (KeyValuePair<string, double> item in topart)
            //{
            //    sorttopart.Add(item.Value, item.Key);
            //} 
            Console.WriteLine("5 Najprodavanijih artikala je:");
            int k = 0;
            foreach (KeyValuePair<string, double> par in topart.OrderByDescending(pair => pair.Value))
            {
                if (k < 5)
                {
                    Console.WriteLine("Ime:{0}" + "  Kol:{1}", par.Key, par.Value);
                    k++;
                }
                else
                {
                    break;
                }
            }
          
            // foreach(KeyValuePair<string,double> par in topart)
            //{
      
            //}
          
            Console.ReadKey();
            AdminIzbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);

        }
        private void NajRadnici(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            Dictionary<string,double> zapnarac = new Dictionary<string,double>();
            Dictionary<Zaposlenik, double> topzap = new Dictionary<Zaposlenik, double>();
            List<Stavka> stavka = new List<Stavka>();
            List<Stavka> topstavke = new List<Stavka>();

            foreach (Racun rac in racuni)
            {
                
                    if (zapnarac.ContainsKey(rac.Sifrazaposlenika))
                    {
                    zapnarac[rac.Sifrazaposlenika] = zapnarac[rac.Sifrazaposlenika] + rac.Ukupaniznos;
                    }
                    else
                    {
                    zapnarac.Add(rac.Sifrazaposlenika, rac.Ukupaniznos);
                    }

                

            }

            Console.WriteLine("Najbolji radinici:");
            foreach (KeyValuePair<string, double> par in zapnarac.OrderByDescending(pair => pair.Value))
            {
                for(int a=0;a<zaposlenici.Count;a++)   
                if (par.Key == zaposlenici[a].Sifrazaposlenika)
                {
                        Console.WriteLine("Ime:{0}    Prodano:{1}kn", zaposlenici[a].Ime +"  "+ zaposlenici[a].Prezime,par.Value); 


                }
                
            }


            Console.ReadKey();
            AdminIzbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);

        }
        private void NajKat(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            Dictionary<string, int> topkat = new Dictionary<string, int>();
            List<Stavka> stavka = new List<Stavka>();
            List<Stavka> topstavke = new List<Stavka>();

            foreach (Racun rac in racuni)
            {
                for (int i = 0; i < rac.Stavke.Count; i++)
                {
                    if (topkat.ContainsKey(rac.Stavke[i].Kategorija))
                    {
                        topkat[rac.Stavke[i].Kategorija] = topkat[rac.Stavke[i].Kategorija] + 1;
                    }
                    else
                    {
                        topkat.Add(rac.Stavke[i].Kategorija, 1);
                    }

                }

            }

            Console.WriteLine("Kolicina prodanog iz svake kategorije:");
            foreach (KeyValuePair<string, string> svekat in kategorije)
            {
                foreach(KeyValuePair<string,int>prodanekat in topkat)
                if (svekat.Key==prodanekat.Key)
                {
                    Console.WriteLine("{0}:" + "  Prodano:{1}", svekat.Value, prodanekat.Value);
                 
                }
             
            }

            Console.ReadKey();
            AdminIzbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
        }

        private void StonirajRacun(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            string prompt = "Odaberite racun: koji zelite obrisat";
            string[] options=new string[racuni.Count+1];
            int j = 0;
            Console.Clear();
            Console.WriteLine("Racuni:");
            foreach (Racun r1 in racuni)
            {
                options[j] = "Sifra racuna:" + r1.Sifraracuna + " Zaposlenik:" + Zaposlenik.PovratZaposlenika(r1.Sifrazaposlenika, zaposlenici);
                Console.WriteLine("\nSifra Racuna:"+r1.Sifraracuna+"\nArtikli:");
                for(int i=0;i<r1.Stavke.Count;i++)
                {
                    Console.WriteLine("Ime Artikla:"+r1.Stavke[i].Naziv+"     Kolicina:"+r1.Stavke[i].Kolicina);
                }
                j++;
            }
            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
            options[racuni.Count] = "izlaz";
            Meni stoniraj = new Meni(options, prompt);
            int index=stoniraj.Run();
            if (index == racuni.Count)
            {
                AdminIzbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
            }
            else
            {
                racuni[index].Stoniraj(true);
                AdminIzbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
            }    
        }
        
        private void DBKategorije(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            {
                string prompt = "VUV PC SHOP";
                string[] options = { "Dodavanje","Brisanje", "Nazad" };
                Meni mainMeni = new Meni(options, prompt);
                int selectedIndex = mainMeni.Run();
                switch (selectedIndex)
                {
                    case 0:
                        DodavanjeKat(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                        break;
                    case 1:
                        BrisanjeKat(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                        break;
                    case 2:
                        AdminIzbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                        break;
  

                }
            }
        }
        private void DodavanjeKat(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            bool ex = false;
            while(ex==false)
            {
                Console.WriteLine("Unesite skracenicu za kategoriju");
                string skrat = Console.ReadLine();
                if(string.IsNullOrEmpty(skrat)==true)
                {
                    Exceptions ex1 = new Exceptions("Skracenica za kategoriju ne smije bit prazna!");
                    Console.WriteLine(ex1);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Unesite ime za kategoriju");
                    string kat = Console.ReadLine();
                    if(string.IsNullOrEmpty(kat)==true||skrat==kat)
                    {
                        Exceptions ex2 = new Exceptions("Ime kategorije ne smije bit prazno i ne moze bit jednako!");
                        Console.WriteLine(ex2);
                        Console.ReadKey();


                    }
                    else
                    {
                        Console.WriteLine("Dodavanje uspjesno!");
                        kategorije.Add(skrat, kat);
                        ex = true;
                        Console.ReadKey();
                    }
                }
                Console.Clear();
            }
            Console.Clear();
            DBKategorije(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
        }
        private void BrisanjeKat(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {

            string prompt = "Odaberi kategoriju koju zelite obrisati";
            string[] options = { "" };

            List<string> kljuckat = new List<string>();
            int i = 0;
            foreach (KeyValuePair<string, string> kategorija in kategorije)
            {

                i++;
                kljuckat.Add(kategorija.Key);

            }
            options = new string[i + 1];
            int j = 0;
            foreach (KeyValuePair<string, string> kategorija in kategorije)
            {
                options[j] = kategorija.Value;
                j++;
            }
            options[i] = "Izlaz";
            Meni mainMeni = new Meni(options, prompt);
            int selectedIndex = mainMeni.Run();
            if (selectedIndex == i)
            {
                DBKategorije(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
            }
            else
            {
                kategorije.Remove(kljuckat[selectedIndex]);
                Console.WriteLine("Obrisano:" + kljuckat[selectedIndex] +"   "+ options[selectedIndex]);
                Console.ReadKey();
                
            }
            BrisanjeArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);


        }
        private void RunMainMenu(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
            string prompt = "Odaberite Zaposlenika";
          
            int i = 0;
            foreach (Zaposlenik z in zaposlenici)
            {
                if(z.VOtkaz=="ne")
                {     
              
                i++;
                }

            }
            string[] options = new string[i];
            i = 0;
            foreach (Zaposlenik z in zaposlenici)
            {
                if (z.VOtkaz == "ne")
                {

                    options[i] = z.IspisPunogImena();
                    i++;
                }

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

                bool ex = false;
                while (ex == false)
                {
                    Console.WriteLine("Naziv:");
                    string naziv = Console.ReadLine();
                    if (string.IsNullOrEmpty(naziv))
                    {
                        Exceptions ex1 = new Exceptions("Naziv ne smije biti prazan!");
                        Console.WriteLine(ex1);
                        Console.ReadKey();
                    }
                    else
                    {

                        Console.WriteLine("Opis:");
                        string opis = Console.ReadLine();
                        if (string.IsNullOrEmpty(opis))
                        {
                            Exceptions ex1 = new Exceptions("Opis ne smije biti prazan!");
                            Console.WriteLine(ex1);
                            Console.ReadKey();
                        }
                        else
                        {

                            Console.WriteLine("Jedinica Mjere:");
                            string mjera = Console.ReadLine();


                            Console.WriteLine("Jedinicna cijena:");
                            string skolicina =Console.ReadLine();
                            if (double.TryParse(skolicina, out double kolicina) == false || string.IsNullOrEmpty(skolicina))
                            {
                                Exceptions ex1 = new Exceptions("Cijena ne smije bit prazna i mora bit brojcana!");
                                Console.WriteLine(ex1);
                                Console.ReadKey();
                            }
                            else
                            {
                                Artikl noviartikl = new Artikl(naziv, opis, mjera, kolicina);
                                noviartikl.DodavanjeKategorije(kljuckat[selectedIndex]);
                                sviartikli.Add(noviartikl);
                                Console.WriteLine("Dodavanje Uspjesno!");
                                Console.ReadKey();
                                ex = true;
                            }
                        }

                    }
                 
                  
                    Console.Clear();
                }
                DABArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
            }
           



        }
        private void AzuriranjeArtikli(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
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
                    switch (selectedIndex2)
                    {
                        case 0:

                            string prompt3 = ("Odaberite novu kategoriju:");
                            string[] options3 = new string[kategorije.Count + 1];
                            options3[kategorije.Count] = "Nazad";
                            int x = 0;
                            foreach (KeyValuePair<string, string> kljuc in kategorije)
                            {
                                listakljuceva.Add(kljuc.Value);
                                options3[x] = kljuc.Value;
                                x++;
                            }
                            Meni mainMeni3 = new Meni(options3, prompt3);
                            int selectedIndex3 = mainMeni3.Run();

                            if (selectedIndex3 == kategorije.Count)
                            {
                                AzuriranjeArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                            }
                            else
                            {

                                sviartikli[selectedIndex].Kategorija = listakljuceva[selectedIndex3];
                            }
                            break;
                        case 1:
                            bool isp1 = false;
                            while (isp1 == false)
                            {


                                Console.WriteLine("Unesite novi naziv:");
                                string naziv = Console.ReadLine();
                                if (string.IsNullOrEmpty(naziv) == true)
                                {

                                    Exceptions ex1 = new Exceptions("Naziv ne smije bit prazan!");
                                    Console.WriteLine(ex1);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {

                                    isp1 = true;
                                    sviartikli[selectedIndex].Naziv = naziv;
                                }
                            }
                            break;
                        case 2:
                            bool isp2 = false;
                            while (isp2 == false)
                            {


                                Console.WriteLine("Unesite novi opis:");
                                string opis = Console.ReadLine();
                                if (string.IsNullOrEmpty(opis) == true)
                                {

                                    Exceptions ex1 = new Exceptions("Opis ne smije bit prazan!");
                                    Console.WriteLine(ex1);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {

                                    isp2 = true;
                                    sviartikli[selectedIndex].Opis = opis;
                                }
                            }
                            break;
                        case 3:
                            Console.WriteLine("Unesite novu jedinicnu mjeru:");
                            string jedmjer = Console.ReadLine();
                            sviartikli[selectedIndex].JedinicaMjere = jedmjer;
                            break;
                        case 4:
                            bool isp4 = false;
                            while (isp4 == false)
                            {
                       
                                Console.WriteLine("Unesite novu cijenu:");
                                string cijena = Console.ReadLine();
                                if (double.TryParse(cijena, out double cij) == false || string.IsNullOrEmpty(cijena))
                                {
                                    Exceptions ex1 = new Exceptions("Cijena ne smije bit prazna i mora bit brojcana!");
                                    Console.WriteLine(ex1);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    sviartikli[selectedIndex].Cijena = cij;
                                    isp4 = true;
                                }
                                
                            }
                                break;
                            case 5:
                               ispit=false;
                                break;
                        }
                    }
                }
            
        }
        private void BrisanjeArtikli(ref List<Zaposlenik> zaposlenici, ref List<Artikl> sviartikli, ref Dictionary<string, string> kategorije, ref List<Racun> racuni)
        {
           
                string prompt = "Odaberite Artikl koji zelite obrisat";
                string[] options = { "" };
            List<Artikl> neobirsaniart = new List<Artikl>();
                int i = 0;
               


            foreach (Artikl artikl in sviartikli)
            {
                if (artikl.Obrisano == "ne")
                {
                    neobirsaniart.Add(artikl);

                }
            }
            options = new string[neobirsaniart.Count + 1];
            options[neobirsaniart.Count] = "Izlaz";
            foreach (Artikl artikl in sviartikli)
                {
                    if (artikl.Obrisano == "ne")
                    {
                        options[i] = artikl.Naziv;
                        i++;
                    }
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
                    int ind=sviartikli.IndexOf(neobirsaniart[selectedIndex]);
                sviartikli[ind].Obrisati(true);
                DABArtikli(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
            }
            neobirsaniart.Clear();
           
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
                    if (art.Kategorija == kljuckat[selectedIndex3] && art.Obrisano=="ne")
                    {
                        artikliukat.Add(art);
                        x1++;

                    }

                }
                string[] options1 = new string[x1+1];
                int j = 0;
                foreach (Artikl art in artikliukat)
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
                    { 
                    artikliukat[selectedIndex1].Dostupnost = options2[selectedIndex2];
                    }
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
                            Console.WriteLine("Racun br:"+r1.Sifraracuna);
                            Console.WriteLine("Zaposlenik:"+PrijaveljniZaposlenik.prijavljeni.IspisPunogImena());
                            Console.WriteLine("Kupljeni artikli:");
                            Console.WriteLine("");
                            for (int i = 0; i < r1.Stavke.Count; i++)
                            {
                                Console.WriteLine(r1.Stavke[i].Kolicina+ "x   " + r1.Stavke[i].Naziv);

                            }
                            Console.WriteLine("\nUkupna cijena:"+r1.Ukupaniznos+"kn");
                            Console.ReadKey();
                    
    
                            r1 = null;

                                }
                                else
                                {
                                    Console.WriteLine("prazan racun!");
                            Console.ReadKey();
                                }
                        Izbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                                break;
                        case 2:
                            Izbornik(ref zaposlenici, ref sviartikli, ref kategorije, ref racuni);
                            break;

                        }


                


            }
            catch (Exceptions)
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
                        if (art.Kategorija == kljuckat[selectedIndex] && art.Obrisano=="ne")
                        {
                        if (art.Dostupnost == "da"&&art.Obrisano=="ne")
                            artikliukat.Add(art);
        

                        }

                    }

               
                int j = 0;
                    foreach (Artikl art in artikliukat)
                    {
                    if (art.Kategorija == kljuckat[selectedIndex]&&art.Obrisano=="ne")
                    {
                        if (art.Dostupnost == "da"&&art.Obrisano=="ne")
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
                        if (art.Dostupnost == "da"&&art.Obrisano=="ne")
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
                    if (rac.Sifrazaposlenika == zaposlenici[selectedIndex].Sifrazaposlenika && rac.Stonirano=="ne")
                    { 
                    Console.WriteLine("\nSifra Racuna:"+rac.Sifraracuna);
                    Console.WriteLine("Datum:"+rac.Datum);
                    Console.WriteLine("Iznos:"+rac.Ukupaniznos+"kn");
                            Console.WriteLine();
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
