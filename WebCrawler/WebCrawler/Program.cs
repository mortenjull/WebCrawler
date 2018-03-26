using System;
using System.Runtime.CompilerServices;
using WebAgent;

namespace WebCrawler
{
    class Program
    {
        private static readonly Opperations _opperations;

        static Program()
        {
            _opperations = new Opperations();
        }

        static void Main(string[] args)
        {           
            Console.WriteLine("Hello dipshit!");
            Console.WriteLine("");
            PrintConsoleMenu();

            string command = "";
            while (command.ToLower().Trim() != "quit")
            {
                command = Console.ReadLine();
                Menu(command.Trim().ToLower());
            }
        }

        static void Menu(string option)
        {
            if (string.IsNullOrWhiteSpace(option))
            {
                Console.WriteLine("Bad option.");
                Console.WriteLine("");
            }

            switch (option)
            {
                case "crawl":
                    _opperations.Crawl();
                    break;

                case "clear":
                    ClearConsole();
                    break;
            }
        }

        private static void ClearConsole()
        {
            Console.Clear();
            PrintConsoleMenu();
        }

        private static void PrintConsoleMenu()
        {
            Console.WriteLine("Console menu:");
            Console.WriteLine("");
            Console.WriteLine("Crawl a site: crawl");
            Console.WriteLine("");
            Console.WriteLine("Clear console: clear");
            Console.WriteLine("");
        }
    }
}
