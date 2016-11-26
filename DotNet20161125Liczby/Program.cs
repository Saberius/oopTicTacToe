using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet20161125Liczby
{
    class Program
    {
        static void Main(string[] args)
        {
            Random needleGen = new Random();
            int search;
            int needle = needleGen.Next(0,21);
            int newMin = 0, newMax = 20;
            Console.WriteLine("Witaj!");
            search = GetSearch(newMin, newMax);

            while (search != needle)
            {
                if (search < needle)
                {
                    Console.WriteLine("Twoja liczba jest za mała! podaj liczbę większą od {0}!", search);
                    newMin = search+1;
                    search = GetSearch(search+1, newMax);
                }
                else if (search > needle)
                {
                    Console.WriteLine("Twoja liczba jest za duża! podaj liczbę mniejszą od {0}!", search);
                    newMax = search-1;
                    search = GetSearch(newMin, search-1);
                }

            }

            if (search == needle)
            {
                Console.WriteLine("Gratulacje! Szukana liczba to właśnie {0}!", search);
            }

            Console.ReadLine();
        }

        public static int GetSearch(int min, int max)
        {
            int search;
            do
            {
                Console.WriteLine("Podaj liczbe z zakresu {0}-{1}", min, max);
                search = int.Parse(Console.ReadLine());

            } while (search < min || search > max);

            return search;
        }

    }
}
