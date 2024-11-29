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
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            string[,] playerField = new string[10, 10];
            for (int i = 0; i < playerField.GetLength(0); i++) 
            { 
                for (int j = 0; j < playerField.GetLength(1); j++) 
                { 
                    playerField[i, j] = "O"; 
                } 
            }           
            List<string> columns = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j","B","B" };
            Console.WriteLine("Your field");
            PrintArray(playerField);
            string[,] computerField = (string[,])playerField.Clone();
            Console.WriteLine("Opponent's field");
            PrintArray(computerField);
            bool repeat;

            do
            {
                repeat = false;
                try
                {
                    Console.WriteLine("");
                    Console.WriteLine("Write the line number from 1 to 10");
                    int xCoordinate = int.Parse(Console.ReadLine());
                    Console.WriteLine("Write the column number from 1 to 10");
                    int yCoordinate = int.Parse(Console.ReadLine());
                    playerField[xCoordinate - 1, yCoordinate - 1] = "T";
                    string direction = Console.ReadLine();
                    switch (direction)
                    {
                        case "up":
                            {
                                playerField[xCoordinate - 1 - 1, yCoordinate - 1] = "T";
                                break;
                            }
                        case "right":
                            {
                                playerField[xCoordinate - 1, yCoordinate - 1 + 1] = "T";
                                break;
                            }
                        case "down":
                            {
                                playerField[xCoordinate - 1 + 1, yCoordinate - 1] = "T";
                                break;
                            }
                        case "left":
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
