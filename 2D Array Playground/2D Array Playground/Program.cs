using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace _2D_Array_Playground
{
    internal class Program
    {
        static void Print2DArray(int[,] arrayToPrint)
        {
            for (int i = 0; i < arrayToPrint.GetLength(0); i++)
            {
                for (int j = 0; j < arrayToPrint.GetLength(1); j++) Console.Write(arrayToPrint[i, j] + ", ");               
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void ResetArray(int[,] arrayToReset)
        { 
            for (int i = 0; i < arrayToReset.GetLength(0); i++)
            {
                for (int j = 0; j < arrayToReset.GetLength(1); j++)
                {
                    arrayToReset[i, j] = i * 5 + j + 1;
                }
            }
        } 
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové 2D pole velikosti 5 x 5, naplň ho čísly od 1 do 25 a vypiš ho do konzole (5 řádků po 5 číslech).
            int[,] chessBoard = new int[5, 5];
            for (int i = 0;i < chessBoard.GetLength(0); i++)
            {
                for (int j = 0;j < chessBoard.GetLength(1); j++)
                {
                    chessBoard[i, j] = i * 5 + j + 1;
                }               
            }
            Print2DArray(chessBoard);

            //TODO 2: Vypiš do konzole n-tý řádek pole, kde n určuje proměnná nRow.
            int nRow = 2;
            for (int i = 0;i < chessBoard.GetLength(1); i++)
            {
                Console.Write(chessBoard[nRow, i] + " ");
            }
            Console.WriteLine();
            //TODO 3: Vypiš do konzole n-tý sloupec pole, kde n určuje proměnná nColumn.
            int nColumn = 2;
            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                Console.WriteLine(chessBoard[i, nColumn]);
            }

            //TODO 4: Prohoď prvek na souřadnicích [xFirst, yFirst] s prvkem na souřadnicích [xSecond, ySecond] a vypiš celé pole do konzole po prohození.
            //Nápověda: Budeš potřebovat proměnnou navíc, do které si uložíš první z prvků před tím, než ho přepíšeš druhým, abys hodnotou prvního prvku potom mohl přepsat druhý
            int xFirst, yFirst, xSecond, ySecond;
            xFirst = yFirst = 0;
            xSecond = ySecond = 4;
            /*int temporary = chessBoard[xFirst, yFirst];
            chessBoard[xFirst,yFirst] = chessBoard[xSecond, ySecond];
            chessBoard[xSecond, ySecond] = temporary;*/
            (chessBoard[xFirst, yFirst], chessBoard[xSecond, ySecond]) = (chessBoard[xSecond, ySecond], chessBoard[xFirst, yFirst]);
            Print2DArray (chessBoard);
            ResetArray(chessBoard);
            //TODO 5: Prohoď n-tý řádek v poli s m-tým řádkem (n je dáno proměnnou nRowSwap, m mRowSwap) a vypiš celé pole do konzole po prohození.
            int nRowSwap = 0;
            int mRowSwap = 1;
            for (int i = 0; i < chessBoard.GetLength(0); i++) (chessBoard[nRowSwap, i], chessBoard[mRowSwap, i]) = (chessBoard[mRowSwap, i], chessBoard[nRowSwap, i]);
            /*for (int i = 0; i < chessBoard.GetLength(1); i++)
            {
                int temporary = chessBoard[nRowSwap, i];
                chessBoard[nRowSwap, i] = chessBoard[mRowSwap, i];
                chessBoard[mRowSwap, i] = temporary;
            }*/
            Print2DArray(chessBoard);
            ResetArray(chessBoard);
            //TODO 6: Prohoď n-tý sloupec v poli s m-tým sloupcem (n je dáno proměnnou nColSwap, m mColSwap) a vypiš celé pole do konzole po prohození.
            int nColSwap = 0;
            int mColSwap = 1;
            for (int i = 0; i < chessBoard.GetLength(1); i++) (chessBoard[i,nColSwap], chessBoard[i,mColSwap]) = (chessBoard[i, mColSwap], chessBoard[i, nColSwap]);
            Print2DArray(chessBoard);
            ResetArray(chessBoard);
            //TODO 7: Otoč pořadí prvků na hlavní diagonále (z levého horního rohu do pravého dolního rohu) a vypiš celé pole do konzole po otočení.
            for (int i = 0;i < chessBoard.GetLength(0)/2; i++)
            {
                int temporary = chessBoard[i, i];
                chessBoard[i, i] = chessBoard[chessBoard.GetLength(0)-i - 1, chessBoard.GetLength(0) - i - 1];
                chessBoard[chessBoard.GetLength(0) - i - 1, chessBoard.GetLength(0) - i - 1] = temporary;
            }
            Print2DArray(chessBoard);
            ResetArray(chessBoard);
            //TODO 8: Otoč pořadí prvků na vedlejší diagonále (z pravého horního rohu do levého dolního rohu) a vypiš celé pole do konzole po otočení.
            for (int i = 0; i < chessBoard.GetLength(0) / 2; i++)
            {
                int temporary = chessBoard[i, chessBoard.GetLength(0) - i - 1];
                chessBoard[i, chessBoard.GetLength(0) - i - 1] = chessBoard[chessBoard.GetLength(0) - i - 1, i];
                chessBoard[chessBoard.GetLength(0) - i - 1, i] = temporary;
            }
            Print2DArray(chessBoard);
            ResetArray(chessBoard);
            Console.ReadKey();
        }
    }
}
