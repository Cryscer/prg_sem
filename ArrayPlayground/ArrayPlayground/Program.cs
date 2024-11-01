using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        /*static int[] Hundred(int[] myArray)
        {
            Random rnd = new Random();
            if (myArray.Length < 100)
            {
                int[] x = { rnd.Next(0, 101) };
                myArray = {Hundred(myArray), x} ;
            }
            return myArray;
        }
        (spatna rekurze)
         */
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové pole a naplň ho pěti libovolnými čísly.
            int[] myArray = { 5, 8, 6, 1 };

            //TODO 2: Vypiš do konzole všechny prvky pole, zkus jak klasický for, kde i využiješ jako index v poli, tak foreach.
            for (int i = 0; i < myArray.Length; i++) Console.WriteLine(myArray[i]);
            
            foreach (int i in myArray) Console.WriteLine(i);
            
            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            int sum = 0;
            foreach (int i in myArray) sum += i;
            Console.WriteLine("suma je " + sum);
            /*
            average = myArray.Sum();
            */

            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            double average = 0;
            foreach (int i in myArray) average += i;
            average /= myArray.Length;
            Console.WriteLine("prumer je " + average);
            /*
             average = myArray.Average();
             */

            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            int max = int.MinValue;
            foreach (int i in myArray)
                if (i > max) 
                {
                    max = i;
                }
            /*
            average = myArray.Max();
            */
            Console.WriteLine("maximum je " + max);
            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            int min = int.MaxValue;
            foreach (int i in myArray)
                if (i < min)
                {
                    min = i;
                }
            /*
            average = myArray.Min();
            */
            Console.WriteLine("minimum je " + min);

            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.
            Console.WriteLine("zadejte cislo jehoz index chcete nalezt");
            int inputA = int.Parse(Console.ReadLine());
            bool x = true;
            for (int i = 0; i < myArray.Length; i++)           
                if (myArray[i] == inputA)
                {
                    Console.WriteLine("vase cislo ma index " + (i + 1));
                    x = false;
                }          
            if (x) Console.WriteLine("vase cislo se nenachazi v poli");

            //TODO 8: Přepiš pole na úplně nové tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9.
            Random rng = new Random();
            myArray = new int[100];
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = rng.Next(0,10);
                Console.Write(myArray[i] + ",");
            }
            Console.WriteLine();

            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];
            foreach (int number in myArray)
            {
                counts[number]++;
            }
            for (int i = 0;i < counts.Length;i++) Console.WriteLine("Cetnost cislice " + i + " je " + counts[i]);

            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.
            int[] reversedArray = new int[100];
            for(int i = 0 ; i < myArray.Length ; i++)
            {
                reversedArray[i] = myArray[myArray.Length - 1 - i];
                Console.Write(reversedArray[i] + ",");
            }

            //Zkus is dál hrát s polem dle své libosti. Můžeš třeba prohodit dva prvky, ukládat do pole prvky nějaké posloupnosti (a pak si je vyhledávat) nebo cokoliv dalšího tě napadne

            Console.ReadKey();
        }
    }
}
