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
            Console.WriteLine("   a b c d e f g h i j");
            for (int i = 0; i < arrayToPrint.GetLength(0); i++)
            {
                if (i == 9) Console.Write(i + 1 + " "); else Console.Write(i + 1 + "  ");
                for (int j = 0; j < arrayToPrint.GetLength(1); j++) Console.Write(arrayToPrint[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            string[,] playerField = new string[10, 10];
            for (int i = 0; i < playerField.GetLength(0); i++) for (int j = 0; j < playerField.GetLength(1); j++) playerField[i, j] = "O"; 
                 
            List<string> columns = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j"};
            Console.WriteLine("      Vaše pole");
            PrintArray(playerField);
            string[,] computerField = (string[,])playerField.Clone();
            Console.WriteLine("    Pole nepřítele");
            PrintArray(computerField);
            bool repeat;

            do
            {
                repeat = false;
                try
                {
                    Console.WriteLine("");
                    Console.WriteLine("Napište řádek od 1 do 10");
                    int xCoordinate = int.Parse(Console.ReadLine());
                    Console.WriteLine("Napište sloupec od a do j");
                    int yCoordinate = columns.IndexOf(Console.ReadLine()) + 1;
                    Console.WriteLine("Napište směr orientace lodě (nahoru, doprava, dolů, doleva)");
                    string direction = Console.ReadLine();
                    switch (direction)
                    {
                        case "nahoru":
                            {
                                playerField[xCoordinate - 1 - 1, yCoordinate - 1] = "T";
                                break;
                            }
                        case "doprava":
                            {
                                playerField[xCoordinate - 1, yCoordinate - 1 + 1] = "T";
                                break;
                            }
                        case "dolů":
                            {
                                playerField[xCoordinate - 1 + 1, yCoordinate - 1] = "T";
                                break;
                            }
                        case "doleva":
                            {
                                playerField[xCoordinate - 1, yCoordinate - 1 - 1] = "T";
                                break;
                            }
                        default: 
                            {
                                Console.WriteLine("error");
                                repeat = true;
                                break;
                            };
                    }
                    playerField[xCoordinate - 1, yCoordinate - 1] = "T";
                }
                catch (Exception)
                {
                    Console.WriteLine("error");
                    repeat = true;
                }
            } while (repeat);
            PrintArray(playerField);

            Console.ReadLine();
        }
    }
}
