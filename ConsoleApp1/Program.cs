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
            Console.WriteLine("Hello\nWorld");
            float a = 5f;
            //int / intem je vždy jen int, jedna z proměn musí být jiná, píše se f konci u floatu
            int b = 4;
            float result = a / b;
            Console.WriteLine(result);
            Random rnd = new Random();


            for (int i = 10; i > 0; i--)
            {
                int x = rnd.Next(100);
                if (x > 50)
                {
                    Console.WriteLine(x);
                }
                    else if (x > 25)
                    {
                        Console.WriteLine("vetsi nez 25 ale mensi nez 50 :|");
                    }
                else
                {
                    Console.WriteLine("mensi nez 25 :(");
                }
            }
            bool canContinue = true;
            

                while (canContinue)
                {
                    Console.WriteLine("Je to truee");
                    string userInput = Console.ReadLine();
                    if (userInput.Equals("n") || userInput.Equals("N")) //funguje i == ale u stringu je tohle generally lepsi
                    {
                        Console.WriteLine("je to false :P");

                        canContinue = false;
                    }

                }
                
            

            /*
            string text; 
            int yesOrNo = rnd.Next(100);
            if (yesOrNo > 50)
            {
                text = "yes";
            }
            else
            {
                text = "no";
            }
            */

            string text = rnd.Next(100) > 50 ? "yes" : "no";

            Console.WriteLine(text);
            
            Console.ReadKey();
        }
    }
}
