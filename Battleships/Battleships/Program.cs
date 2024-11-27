using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    internal class Program
    {
        static void PrintArray(string[,] arrayToPrint)
        {
            for (int i = 0; i < arrayToPrint.GetLength(0); i++)
            {
                for (int j = 0; j < arrayToPrint.GetLength(1); j++) Console.Write(arrayToPrint[i, j] + " ");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            string[,] playerField = new string[10,10];
            for (int i = 0; i < playerField.GetLength(0); i++) for (int j = 0; j < playerField.GetLength(1); j++) playerField[i,j] = "O";
            
            PrintArray(playerField);
            Console.ReadLine();
        }
    }
}
