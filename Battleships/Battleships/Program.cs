using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
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
        static void PlayerPlacement(string[,] playerPlacementArray)
        {
            List<string> columns = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            List<string> shipTypesLetters = new List<string> { "T", "P", "K", "B", "L" };
            List<string> shipTypes = new List<string> { "Torpédoborec", "Ponorka", "Křižník", "Bitevní loď", "Letadlová loď" };
            bool repeat;
            for (int i = 0; i < shipTypes.Count; i++)
            {
                do
                {
                    repeat = false;
                    try
                    {
                        Console.WriteLine(shipTypes[i]);
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
                                    for (int k = 0; k < shipIndex + 1; k++)
                                    {
                                        if (shipTypesLetters.Contains(playerPlacementArray[xCoordinate - 1 - k, yCoordinate]))
                                        {
                                            Console.WriteLine("Lodě nemohou ležet přes sebe!");
                                            repeat = true;
                                        }
                                    }
                                    if (repeat == false)
                                    {
                                        for (int j = 0; j < shipIndex + 1; j++) playerPlacementArray[xCoordinate - 1 - j, yCoordinate] = shipTypesLetters[shipIndex];
                                    }
                                    break;
                                }
                            case "doprava":
                                {
                                    for (int k = 0; k < shipIndex + 1; k++)
                                    {
                                        if (shipTypesLetters.Contains(playerPlacementArray[xCoordinate, yCoordinate + 1 + k]))
                                        {
                                            Console.WriteLine("Lodě nemohou ležet přes sebe!");
                                            repeat = true;
                                        }
                                    }
                                    if (repeat == false)
                                    {
                                        for (int j = 0; j < shipIndex + 1; j++) playerPlacementArray[xCoordinate, yCoordinate + 1 + j] = shipTypesLetters[shipIndex];
                                    }
                                    break;
                                }
                            case "dolů":
                                {
                                    for (int k = 0; k < shipIndex + 1; k++)
                                    {
                                        if (shipTypesLetters.Contains(playerPlacementArray[xCoordinate + 1 + k, yCoordinate]))
                                        {
                                            Console.WriteLine("Lodě nemohou ležet přes sebe!");
                                            repeat = true;
                                        }
                                    }
                                    if (repeat == false)
                                    {
                                        for (int j = 0; j < shipIndex + 1; j++) playerPlacementArray[xCoordinate + 1 + j, yCoordinate] = shipTypesLetters[shipIndex];
                                    }
                                    break;
                                }
                            case "doleva":
                                {
                                    for (int k = 0; k < shipIndex + 1; k++)
                                    {
                                        if (shipTypesLetters.Contains(playerPlacementArray[xCoordinate, yCoordinate - 1 - k]))
                                        {
                                            Console.WriteLine("Lodě nemohou ležet přes sebe!");
                                            repeat = true;
                                        }
                                    }
                                    if (repeat == false)
                                    {
                                        for (int j = 0; j < shipIndex + 1; j++) playerPlacementArray[xCoordinate, yCoordinate - 1 - j] = shipTypesLetters[shipIndex];
                                    }
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("error");
                                    repeat = true;
                                    break;
                                };
                        }
                        if (shipTypesLetters.Contains(playerPlacementArray[xCoordinate, yCoordinate]))
                        {
                            Console.WriteLine("Lodě nemohou ležet přes sebe!");
                            repeat = true;
                        }
                        else if (repeat == false) playerPlacementArray[xCoordinate, yCoordinate] = shipTypesLetters[shipIndex];
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("error");
                        repeat = true;
                    }
                } while (repeat);
                Console.WriteLine("      Vaše pole");
                PrintArray(playerPlacementArray);
            }
        }
        static void ComputerPlacement(string[,] computerPlacementArray)
        {
            List<string> shipTypesLetters = new List<string> { "T", "P", "K", "B", "L" };
            bool repeat;
            Random rng = new Random();
            for (int i = 0; i < shipTypesLetters.Count; i++)
            {
                do
                {
                    repeat = false;
                    try
                    {                        
                        int shipIndex = i;
                        int xCoordinate = rng.Next(0, 10);
                        int yCoordinate = rng.Next(0, 10);
                        int direction = rng.Next(1, 5);
                        switch (direction)
                        {
                            case 1:
                                {
                                    for (int k = 0; k < shipIndex + 1; k++) if (shipTypesLetters.Contains(computerPlacementArray[xCoordinate - 1 - k, yCoordinate])) repeat = true;
                                    if (repeat == false) for (int j = 0; j < shipIndex + 1; j++) computerPlacementArray[xCoordinate - 1 - j, yCoordinate] = shipTypesLetters[shipIndex];
                                    break;
                                }
                            case 2:
                                {
                                    for (int k = 0; k < shipIndex + 1; k++) if (shipTypesLetters.Contains(computerPlacementArray[xCoordinate, yCoordinate + 1 + k])) repeat = true;
                                    if (repeat == false) for (int j = 0; j < shipIndex + 1; j++) computerPlacementArray[xCoordinate, yCoordinate + 1 + j] = shipTypesLetters[shipIndex];
                                    break;
                                }
                            case 3:
                                {
                                    for (int k = 0; k < shipIndex + 1; k++) if (shipTypesLetters.Contains(computerPlacementArray[xCoordinate + 1 + k, yCoordinate])) repeat = true;
                                    if (repeat == false) for (int j = 0; j < shipIndex + 1; j++) computerPlacementArray[xCoordinate + 1 + j, yCoordinate] = shipTypesLetters[shipIndex];
                                    break;
                                }
                            case 4:
                                {
                                    for (int k = 0; k < shipIndex + 1; k++) if (shipTypesLetters.Contains(computerPlacementArray[xCoordinate, yCoordinate - 1 - k])) repeat = true;
                                    if (repeat == false) for (int j = 0; j < shipIndex + 1; j++) computerPlacementArray[xCoordinate, yCoordinate - 1 - j] = shipTypesLetters[shipIndex];
                                    break;
                                }
                            default:
                                {
                                    repeat = true;
                                    break;
                                };
                        }
                        if (shipTypesLetters.Contains(computerPlacementArray[xCoordinate, yCoordinate])) repeat = true;
                        else if (repeat == false) computerPlacementArray[xCoordinate, yCoordinate] = shipTypesLetters[shipIndex];
                    }
                    catch (Exception)
                    {
                        repeat = true;
                    }   
                } while (repeat);               
            }
        }
        static void ShootingPlayer(string[,] computerField, string[,] computerFieldVisual) // ve funkcích střílení jsem ponechal stejná jména array jako v mainu, jelikož mi případalo, že jejich jména sedí a měnit je by byla jen extra práce
        {
            List<string> columns = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            List<string> shipTypesLetters = new List<string> { "T", "P", "K", "B", "L" };
            bool fireAgain;
            bool errorRepeat = false;
            int xCoordinate = 0, yCoordinate = 0;
            do
            {
                do
                {
                    try
                    {
                        errorRepeat = false;
                        Console.WriteLine("Napište do jakého řádku chcete pálit");
                        xCoordinate = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("Napište do jakého sloupce chcete pálit");
                        yCoordinate = columns.IndexOf(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("error");
                        errorRepeat = true;
                    }
                } while (errorRepeat);
                Console.WriteLine("T = trefa, V = vedle ");
                if (shipTypesLetters.Contains(computerField[xCoordinate, yCoordinate]))
                {
                    computerFieldVisual[xCoordinate, yCoordinate] = "T";
                    fireAgain = true;                    
                }
                else
                {
                    computerFieldVisual[xCoordinate, yCoordinate] = "V";
                    fireAgain = false;
                }
                Console.WriteLine("   Pole nepřítele");
                PrintArray(computerFieldVisual);
            } while (fireAgain);
        }
        static void ShootingComputer(string[,] playerField)
        {
            List<string> shipTypesLetters = new List<string> { "T", "P", "K", "B", "L" };
            bool fireAgain;
            Random rng = new Random();
            do
            {
                int xCoordinate = rng.Next(0, 10);
                int yCoordinate = rng.Next(0, 10);
                Console.WriteLine("T = trefa, V = vedle ");
                if (shipTypesLetters.Contains(playerField[xCoordinate, yCoordinate]))
                {
                    playerField[xCoordinate, yCoordinate] = "T";
                    fireAgain = true;
                }
                else
                {
                    playerField[xCoordinate, yCoordinate] = "V";
                    fireAgain = false;
                }
                Console.WriteLine("      Vaše pole");
                PrintArray(playerField);
            } while (fireAgain);
        }
        static void Main(string[] args)
        {
            List<string> shipTypesLetters = new List<string> { "T", "P", "K", "B", "L" };
            string[,] playerField = new string[10, 10];
            for (int i = 0; i < playerField.GetLength(0); i++) for (int j = 0; j < playerField.GetLength(1); j++) playerField[i, j] = "O";
            string[,] computerField = (string[,])playerField.Clone();
            string[,] computerFieldVisual = (string[,])playerField.Clone();
            Console.WriteLine("      Vaše pole");
            PrintArray(playerField);
            PlayerPlacement(playerField); //umístění lodí pro počítač a hráče jsem rozdělil do dvou funkcí kvůli writeline instrukcím/nápovědám            
            ComputerPlacement(computerField);
            Console.WriteLine("   Pole nepřítele");
            PrintArray(computerFieldVisual);
            bool playerWin;
            bool end = false;
            while (end == false)
            {    
                playerWin = true;
                end = true;
                ShootingPlayer(computerField, computerFieldVisual); 
                foreach (string i in computerField) if (shipTypesLetters.Contains(i))
                    {
                        end = false;
                        playerWin = false;
                    }
                if ((end == true) && (playerWin = true)) Console.WriteLine("Vyhráli jste!");
                else
                {
                    end = true;
                    ShootingComputer(playerField);
                    foreach (string i in playerField) if (shipTypesLetters.Contains(i)) end = false;
                    if ((end == true)&&(playerWin == false)) Console.WriteLine("Konec hry");
                }
            }
            Console.ReadLine();
        }
    }
}
