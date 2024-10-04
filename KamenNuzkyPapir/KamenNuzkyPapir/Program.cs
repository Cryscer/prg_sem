using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamenNuzkyPapir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("napis k pro kamen, n pro nuzky, p pro papir a z pro zruseni");
            Random rnd = new Random();
            int x = rnd.Next(4);
            string odpoved = Console.ReadLine();
            if (x == 1) 
            {
                Console.WriteLine("kamen");
            }
            else if (x == 2)
            {
                Console.WriteLine("nuzky");
            }
            else if (x == 3)
            {
                Console.WriteLine("papir");
            }
        }
    }
}
