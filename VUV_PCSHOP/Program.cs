using System;
using System.Collections.Generic;
namespace VUV_PCSHOP
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Zaposlenik> zaposlenici = new List<Zaposlenik>();
                List<Artikl> sviartikli = new List<Artikl>();
                Console.WriteLine();
                do
                {
                    Console.WriteLine("" +
                    "1.Dodavanje/Azuriranje/Brisanje Artikla" +
                    "\n2.Pregled artikala" +
                    "\n3.Kreiraj Racun" +
                    "\n4.Pregled racuna po zaposleniku" +
                    "\n5.izlaz");

                    string switch1 = Console.ReadLine();
                    int sw1int;
                    if(int.TryParse(switch1,out sw1int)==true)
                    {
                        sw1int=Convert.ToInt32(switch1);
                    }




                } while (Console.ReadKey().Key!=ConsoleKey.Escape);
            }
       
          
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
