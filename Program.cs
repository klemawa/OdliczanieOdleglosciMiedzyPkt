using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OdliczanieOdleglosciMiedzyPkt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            randomPkt randomPkt = new randomPkt();
            double n = 10;
            randomPkt.RandomGeneration(n);
            randomPkt.PktPoczatekIKoniec(0 ,0);
        }

        public class randomPkt
        {
            double k;
            List<double> listaWygenerowanychPkt = new List<double>();

            public double RandomGeneration(double n) 
            {
                Random randomk = new Random(); //losowanie liczby przejść k
                k = randomk.NextDouble()*(n-2)+1;
                int liczbaPrzejsc = (int)k;
                Console.WriteLine($"Liczba przejść przez punkty jest równa: {liczbaPrzejsc}");
                
                Random randomn = new Random();
                Console.WriteLine($"Współrzędne na mapce: ");
                for (double i = 0; i<=n-1; i++)
                {
                    double randomSzerokosc = Math.Round(randomn.NextDouble() * 50, 2); // losowanie szerokości geograficznej
                    double randomDlugosc = Math.Round(randomn.NextDouble() * 50, 2); // losowanie długości geograficznej
                    listaWygenerowanychPkt.Add(randomSzerokosc);
                    listaWygenerowanychPkt.Add(randomDlugosc);
                }

                for (int j = 0; j < listaWygenerowanychPkt.Count; j += 2) //wyświetlanie listy
                {
                    Console.WriteLine($"Punkt {j / 2 + 1}: Szerokość: {listaWygenerowanychPkt[j]}, Długość: {listaWygenerowanychPkt[j + 1]}");
                }
                return 0; ;
            }

            public double PktPoczatekIKoniec(double poczatek, double koniec)
            {
                Random random = new Random();

                int losowyIndeksPoczatek = random.Next(listaWygenerowanychPkt.Count / 2) * 2; // uwzględnienie skoku o 2
                double poczatekSzerokosc = listaWygenerowanychPkt[losowyIndeksPoczatek];
                double poczatekDlugosc = listaWygenerowanychPkt[losowyIndeksPoczatek + 1];

                int losowyIndeksKoniec = random.Next(listaWygenerowanychPkt.Count / 2) * 2; // uwzględnienie skoku o 2
                double koniecSzerokosc = listaWygenerowanychPkt[losowyIndeksKoniec];
                double koniecDlugosc = listaWygenerowanychPkt[losowyIndeksKoniec + 1];

                Console.WriteLine($"Wylosowany punkt początkowy: Szerokość: {poczatekSzerokosc}, Długość: {poczatekDlugosc}");
                Console.WriteLine($"Wylosowany punkt końcowy: Szerokość: {koniecSzerokosc}, Długość: {koniecDlugosc}");
                
                return 0;
            }
        }
    }  
}
