using System;
using System.Collections.Generic;
using System.Text;
namespace VUV_PCSHOP
{
    internal class Meni
    {
        private int selectedIndex;
        private string[] Opcije;
        private string Prompt;

        public Meni(string[] opcije, string prompt)
        {
            Opcije = opcije;
            Prompt = prompt;
            selectedIndex = 0;
        }
        private void DisplayOptions()
        {
            Console.WriteLine(Prompt);
            for (int i = 0; i < Opcije.Length; i++)
            {
                string currentOption = Opcije[i];
                string prefix;
                if (i == selectedIndex)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor= ConsoleColor.White;
                }
                else
                {
                    prefix = "";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                }

                Console.WriteLine($"<<{currentOption}>>");

            }
            {

            }
            Console.ResetColor();
        }
        public int Run()
        {
            ConsoleKey Keypressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Keypressed = keyInfo.Key;

                if (Keypressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex == -1)
                    {
                        selectedIndex = Opcije.Length - 1;
                    }
                }
                else if (Keypressed==ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == Opcije.Length)
                    {
                        selectedIndex = 0;
                    }
                }

            } while (Keypressed != ConsoleKey.Enter);

            return selectedIndex;
        }
    }
}
