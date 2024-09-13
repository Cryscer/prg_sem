using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float a = 5f;
            //int / intem je vždy jen int, jedna z proměn musí být jiná, píše se f konci u floatu
            int b = 4;
            float result = a / b;
            Console.WriteLine(result);

            Console.WriteLine("Hello\nWorld");
            Console.ReadKey();
        }
    }
}
