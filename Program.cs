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
            randomPkt.RandomGeneration(n, out int liczbaPrzejsc);
            randomPkt.PktPoczatekIKoniec(0, 0, liczbaPrzejsc);
        }

        public class randomPkt
        {
            double k;
            List<double> listaWygenerowanychPkt = new List<double>();

            public double RandomGeneration(double n, out int liczbaPrzejsc)
            {
                Random randomk = new Random();
                k = randomk.NextDouble() * (n - 2) + 1;
                liczbaPrzejsc = (int)k;
                Console.WriteLine($"Liczba przejść przez punkty jest równa: {liczbaPrzejsc}");

                Random randomn = new Random();

                for (double i = 0; i <= n - 1; i++)
                {
                    double randomSzerokosc = Math.Round(randomn.NextDouble() * 50, 2);
                    double randomDlugosc = Math.Round(randomn.NextDouble() * 50, 2);
                    listaWygenerowanychPkt.Add(randomSzerokosc);
                    listaWygenerowanychPkt.Add(randomDlugosc);
                }

                for (int j = 0; j < listaWygenerowanychPkt.Count; j += 2)
                {
                    Console.WriteLine($"Punkt {j / 2 + 1}: Szerokość: {listaWygenerowanychPkt[j]}, Długość: {listaWygenerowanychPkt[j + 1]}");
                }
                return 0; ;
            }

            public double PktPoczatekIKoniec(double poczatek, double koniec, int liczbaPrzejsc)
            {
                Random random = new Random();

                int losowyIndeksPoczatek = random.Next(listaWygenerowanychPkt.Count / 2) * 2;
                double poczatekSzerokosc = listaWygenerowanychPkt[losowyIndeksPoczatek];
                double poczatekDlugosc = listaWygenerowanychPkt[losowyIndeksPoczatek + 1];

                int losowyIndeksKoniec = random.Next(listaWygenerowanychPkt.Count / 2) * 2;
                double koniecSzerokosc = listaWygenerowanychPkt[losowyIndeksKoniec];
                double koniecDlugosc = listaWygenerowanychPkt[losowyIndeksKoniec + 1];

                Console.WriteLine($"\nWylosowany punkt początkowy: Szerokość: {poczatekSzerokosc}, Długość: {poczatekDlugosc}");
                Console.WriteLine($"Wylosowany punkt końcowy: Szerokość: {koniecSzerokosc}, Długość: {koniecDlugosc}");

                List<double> trasa = new List<double>();
                List<double> dostepnePunkty = new List<double>(listaWygenerowanychPkt);

                trasa.Add(poczatekSzerokosc); trasa.Add(poczatekDlugosc);
                dostepnePunkty.Remove(poczatekSzerokosc); dostepnePunkty.Remove(poczatekDlugosc);

                while (dostepnePunkty.Count > 0 && trasa.Count / 2 < liczbaPrzejsc)
                {
                    double ostatniSzerokosc = trasa[trasa.Count - 2];
                    double ostatniDlugosc = trasa[trasa.Count - 1];
                    double najmniejszaOdleglosc = double.MaxValue;
                    int indeksNajblizszego = 0;

                    for (int i = 0; i < dostepnePunkty.Count; i += 2)
                    {
                        double odleglosc = Math.Sqrt(Math.Pow(ostatniSzerokosc - dostepnePunkty[i], 2) + Math.Pow(ostatniDlugosc - dostepnePunkty[i + 1], 2));
                        if (odleglosc < najmniejszaOdleglosc)
                        {
                            najmniejszaOdleglosc = odleglosc;
                            indeksNajblizszego = i;
                        }
                    }

                    trasa.Add(dostepnePunkty[indeksNajblizszego]);
                    trasa.Add(dostepnePunkty[indeksNajblizszego + 1]);
                    dostepnePunkty.RemoveAt(indeksNajblizszego);
                    dostepnePunkty.RemoveAt(indeksNajblizszego);
                }

                trasa.Add(koniecSzerokosc);
                trasa.Add(koniecDlugosc);

                Console.WriteLine("\nNajkrótsza trasa:");
                for (int i = 0; i < trasa.Count; i += 2)
                {
                    Console.WriteLine($"Punkt {i / 2 + 1}: Szerokość: {trasa[i]}, Długość: {trasa[i + 1]}");
                }

                return 0;
            }
        }
    }  
}
