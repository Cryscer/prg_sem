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
            List<string> columns = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o" };
            Console.Write("  ");
            for (int k = 0;k < arrayToPrint.GetLength(1);k++) Console.Write(" " + columns[k]);
            Console.WriteLine();
            for (int i = 0; i < arrayToPrint.GetLength(0); i++)
            {
                if (i > 8) Console.Write(i + 1 + " "); else Console.Write(i + 1 + "  ");
                for (int j = 0; j < arrayToPrint.GetLength(1); j++) Console.Write(arrayToPrint[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void PlayerPlacement(string[,] playerPlacementArray)
        {
            List<string> columns = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o" };
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
                        Console.WriteLine("Napište řádek od 1 do " + playerPlacementArray.GetLength(0).ToString());
                        int xCoordinate = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("Napište sloupec od a do " + columns[playerPlacementArray.GetLength(1) - 1]);
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
                        int xCoordinate = rng.Next(0, computerPlacementArray.GetLength(1));
                        int yCoordinate = rng.Next(0, computerPlacementArray.GetLength(0));
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
            List<string> columns = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o" };
            List<string> shipTypesLetters = new List<string> { "T", "P", "K", "B", "L" };
            bool fireAgain = false;
            bool errorRepeat;
            int xCoordinate, yCoordinate;
            Console.WriteLine("   Pole nepřítele");
            PrintArray(computerFieldVisual);
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


                        if (shipTypesLetters.Contains(computerField[xCoordinate, yCoordinate]))
                        {
                            computerFieldVisual[xCoordinate, yCoordinate] = "X";
                            fireAgain = true;
                        }
                        else
                        {
                            computerFieldVisual[xCoordinate, yCoordinate] = "V";
                            fireAgain = false;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("error");
                        errorRepeat = true;
                    }
                } while (errorRepeat);
                Console.WriteLine("X = trefa, V = vedle ");
                Console.WriteLine("   Pole nepřítele");
                PrintArray(computerFieldVisual);
            } while (fireAgain);
        }
        static void Main(string[] args)
        {
            List<string> columns = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o" };
            List<string> shipTypesLetters = new List<string> { "T", "P", "K", "B", "L" };
            bool fieldMeasurementRepeat; // implementace custom polí
            int horizontalLength = 0;
            int verticalLength = 0;
            do {
                try
                {
                    fieldMeasurementRepeat = false;
                    Console.WriteLine("Zadejte horizontální délku pole (6-15)");
                    horizontalLength = int.Parse(Console.ReadLine());
                    if ((horizontalLength < 6) || (horizontalLength > 15)) { Console.WriteLine("Zadejte validní hodnotu"); fieldMeasurementRepeat = true; }
                    else
                    {
                        Console.WriteLine("Zadejte vertikální výšku pole (6-15)");
                        verticalLength = int.Parse(Console.ReadLine());
                        if ((verticalLength < 6) || (verticalLength > 15)) { Console.WriteLine("Zadejte validní hodnotu"); fieldMeasurementRepeat = true; }
                    }
                } catch (Exception)
                {
                    Console.WriteLine("error");
                    fieldMeasurementRepeat = true;
                }
            } while (fieldMeasurementRepeat);
            string[,] playerField = new string[ horizontalLength, verticalLength ];
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
            bool sonar = true;
            int sonarXCoordinate, sonarYCoordinate;
            bool sonarRepeat;

            bool fireAgain = false;
            string hitSave = "unasigned";
            bool hitSaveRemains = false;
            int xCoordinate = 0, yCoordinate = 0;
            int savedXCoordinate = 0, savedYCoordinate = 0;
            Random rng = new Random();
            int randomDirection = rng.Next(1, 5);
            List<int> usedDirections = new List<int>(4);
            usedDirections.Add(randomDirection);
            int directionAmount = 0;
            bool errorRepeat;

            while (end == false)
            {                   
                if (sonar) //implementace sonaru
                {
                    do
                    {
                        try
                        {
                            sonarRepeat = false;
                            Console.WriteLine("Chtěli byste použít sonar? (odhalí pole 3*3 na soupeřově poli) ano/ne");
                            string sonarAnswer = Console.ReadLine();
                            if (sonarAnswer == "ano")
                            {
                                Console.WriteLine("Vyberte řádek středu čtverce 3*3");
                                sonarXCoordinate = int.Parse(Console.ReadLine()) - 1;
                                Console.WriteLine("Vyberte sloupec středu čtverce 3*3");
                                sonarYCoordinate = columns.IndexOf(Console.ReadLine());
                                for (int i = -1; i < 2; i++)
                                {
                                    for (int j = -1; j < 2; j++)
                                    {
                                        computerFieldVisual[sonarXCoordinate + i, sonarYCoordinate + j] = computerField[sonarXCoordinate + i, sonarYCoordinate + j];
                                    }
                                }
                                Console.WriteLine("   Pole nepřítele");
                                PrintArray(computerFieldVisual);
                                sonar = false;
                            }
                            else if (sonarAnswer == "ne") { }
                            else sonarRepeat = true;
                        } catch (Exception) { Console.WriteLine("error"); sonarRepeat = true; }
                    } while (sonarRepeat);
                }               
                ShootingPlayer(computerField, computerFieldVisual);
                playerWin = true;
                end = true;
                foreach (string i in computerField) 
                    if (shipTypesLetters.Contains(i))
                    {
                        end = false;
                        playerWin = false;
                    }
                if ((end == true) && (playerWin = true)) Console.WriteLine("Vyhráli jste!");
                else
                {
                    do //pro implementaci strategie palby pc jsem tento kód musel vyndat z funkce, aby si to mohle pamatovat předchozí údaje
                    {
                        do
                        {
                            try
                            {
                                hitSaveRemains = false;
                                for (int i = 0; i < playerField.GetLength(0); i++) for (int j = 0; j < playerField.GetLength(1); j++) if (playerField[i, j] == hitSave) hitSaveRemains = true;
                                directionAmount = 0;
                                foreach (int i in usedDirections) directionAmount++;
                                if (directionAmount == 4) hitSaveRemains = false;
                                if (hitSaveRemains == false)
                                {
                                    usedDirections.Clear();
                                    hitSave = "unasigned";
                                }
                                if ((shipTypesLetters.Contains(hitSave)) && (hitSaveRemains = true))
                                {
                                    if (randomDirection == 1)
                                    {
                                        xCoordinate += 1;
                                    }
                                    else if (randomDirection == 2)
                                    {
                                        xCoordinate -= 1;
                                    }
                                    else if (randomDirection == 3)
                                    {
                                        yCoordinate += 1;
                                    }
                                    else if (randomDirection == 4)
                                    {
                                        yCoordinate -= 1;
                                    }
                                }
                                else
                                {
                                    xCoordinate = rng.Next(0, playerField.GetLength(1));
                                    yCoordinate = rng.Next(0, playerField.GetLength(0));
                                }
                                if (shipTypesLetters.Contains(playerField[xCoordinate, yCoordinate]))
                                {
                                    if (hitSaveRemains == false)
                                    {
                                        savedXCoordinate = xCoordinate;
                                        savedYCoordinate = yCoordinate;
                                        hitSave = playerField[xCoordinate, yCoordinate];
                                    }
                                    playerField[xCoordinate, yCoordinate] = "X";
                                    fireAgain = true;
                                    errorRepeat = false;
                                }
                                else if ((playerField[xCoordinate, yCoordinate] == "X") || (playerField[xCoordinate, yCoordinate] == "V"))
                                {
                                    if (hitSaveRemains)
                                    {
                                        xCoordinate = savedXCoordinate;
                                        yCoordinate = savedYCoordinate;
                                        while (usedDirections.Contains(randomDirection)) randomDirection = rng.Next(1, 5);
                                        usedDirections.Add(randomDirection);
                                        errorRepeat = true;
                                    }
                                    else
                                    {
                                        errorRepeat = true;
                                    }
                                }
                                else
                                {
                                    playerField[xCoordinate, yCoordinate] = "V";
                                    if (hitSaveRemains == true)
                                    {
                                        while (usedDirections.Contains(randomDirection)) randomDirection = rng.Next(1, 5);
                                        usedDirections.Add(randomDirection);                                     
                                        xCoordinate = savedXCoordinate;
                                        yCoordinate = savedYCoordinate;
                                    }                                    
                                    fireAgain = false;
                                    errorRepeat = false;
                                }
                            }
                            catch (Exception)
                            {
                                if (hitSaveRemains == true)
                                {
                                    directionAmount = 0;
                                    foreach (int i in usedDirections) directionAmount++;
                                    if (directionAmount != 4)
                                    {
                                        while (usedDirections.Contains(randomDirection)) randomDirection = rng.Next(1, 5);
                                        usedDirections.Add(randomDirection);
                                        xCoordinate = savedXCoordinate;
                                        yCoordinate = savedYCoordinate;
                                    }
                                }
                                errorRepeat = true;
                            }
                        } while (errorRepeat);
                        Console.WriteLine("X = trefa, V = vedle ");
                        Console.WriteLine("      Vaše pole");
                        PrintArray(playerField);
                    } while (fireAgain);
                    end = true;                    
                    foreach (string i in playerField) if (shipTypesLetters.Contains(i)) end = false;
                    if ((end == true)&&(playerWin == false)) Console.WriteLine("Konec hry");
                }
            }
            Console.ReadLine();
        }
    }
}
