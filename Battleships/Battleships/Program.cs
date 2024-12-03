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
            List<string> shipTypesLetters = new List<string> { "T", "P", "K", "B", "L"};
            List<string> shipTypes = new List<string> { "Torpédoborec", "Ponorka", "Křižník", "Bitevní loď", "Letadlová loď" };
            Console.WriteLine("      Vaše pole");
            PrintArray(playerField);
            string[,] computerField = (string[,])playerField.Clone();
            Console.WriteLine("    Pole nepřítele");
            PrintArray(computerField);
            bool repeat;

            for (int i = 0; i < shipTypes.Count; i++)
            {
                do
                {
                    repeat = false;
                    try
                    {
                        Console.WriteLine("Umístěte " + shipTypes[i]);
                        int shipIndex = i;
                        Console.WriteLine("Napište řádek od 1 do 10");
                        int xCoordinate = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("Napište sloupec od a do j");
                        int yCoordinate = columns.IndexOf(Console.ReadLine());
                        Console.WriteLine("Napište směr orientace lodě (nahoru, doprava, dolů, doleva)");
                        string direction = Console.ReadLine();
                        switch (direction)
                        {
                            case "nahoru":
                                {
                                    for (int j = 0; j < shipIndex + 1; j++) playerField[xCoordinate - 1 - j, yCoordinate] = shipTypesLetters[shipIndex];
                                    break;
                                }
                            case "doprava":
                                {
                                    for (int j = 0; j < shipIndex + 1; j++) playerField[xCoordinate, yCoordinate + 1 + j] = shipTypesLetters[shipIndex];
                                    break;
                                }
                            case "dolů":
                                {
                                    for (int j = 0; j < shipIndex + 1; j++) playerField[xCoordinate + 1 + j, yCoordinate] = shipTypesLetters[shipIndex];
                                    break;
                                }
                            case "doleva":
                                {
                                    for (int j = 0; j < shipIndex + 1; j++) playerField[xCoordinate, yCoordinate - 1 - j] = shipTypesLetters[shipIndex];
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("error");
                                    repeat = true;
                                    break;
                                };
                        }
                        playerField[xCoordinate, yCoordinate] = shipTypesLetters[shipIndex];
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("error");
                        repeat = true;
                    }
                } while (repeat);
                PrintArray(playerField);
            }                                           

            Console.ReadLine();
        }
    }
}
