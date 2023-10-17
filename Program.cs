using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdliczanieOdleglosciMiedzyPkt
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        public class randomPkt
        {
            double k;
            double n = 10;
            double szerokoscGeo;
            double dlugoscGeo;
            List<double> listaWygenerowanychPkt = new List<double>();

            public RandomGeneration(double n,double k) 
            {
                Random randomk = new Random();
                k = randomk.NextDouble();
                Console.WriteLine($"Liczba przejść przez punkty jest równa: {k}");

                Random randomn = new Random();
                for (double i = 0; i<=n; i++)
                {
                    double randomValue = randomk.NextDouble();
                    listaWygenerowanychPkt.Add(randomValue);
                    Console.WriteLine($"Współrzędne na mapce: ");
                    for (double j=0;j<randomValue;j++)
                    {
                        Console.WriteLine(randomValue);
                    }
                }
            }
            

            
            
        }

    }

    
}
