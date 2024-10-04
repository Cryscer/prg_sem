using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamenNuzkyPapir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("napis kamen, nuzky, papir nebo zruseni");
            Random rnd = new Random();

            int playerPoints = 0;
            int pcPoints = 0;
            int opakovani = 0;
            int konec = 0;
            do
            {
                while (playerPoints < 3 && pcPoints < 3 && konec == 0)
                {
                    int x = rnd.Next(4);
                    string odpoved = Console.ReadLine();
                    if (x == 1)
                    {
                        Console.WriteLine("kamen");
                        if (odpoved == "kamen")
                        {
                            Console.WriteLine("remiza " + "\nHrac: " + playerPoints + "\nPocitac:" + pcPoints);
                        }
                        else if (odpoved == "nuzky")
                        {
                            pcPoints++;
                            Console.WriteLine("dostal jsem te " + "\nHrac: " + playerPoints + "\nPocitac:" + pcPoints);
                        }
                        else if (odpoved == "papir")
                        {
                            playerPoints++;
                            Console.WriteLine("dostal jsi mne " + "\nHrac: " + playerPoints + "\nPocitac:" + pcPoints);
                        }
                        else if (odpoved == "zruseni")
                        {
                            konec = 1;
                        }
                        else
                        {
                            Console.WriteLine("to nebyla platna odpoved");
                        }
                    }
                    else if (x == 2)
                    {
                        Console.WriteLine("nuzky");
                        if (odpoved == "kamen")
                        {
                            playerPoints++;
                            Console.WriteLine("dostal jsi mne "+"\nHrac: " + playerPoints + "\nPocitac:" + pcPoints);
                        }
                        else if (odpoved == "nuzky")
                        {
                            Console.WriteLine("remiza " + "\nHrac: " + playerPoints + "\nPocitac:" + pcPoints);
                        }
                        else if (odpoved == "papir")
                        {
                            pcPoints++;
                            Console.WriteLine("dostal jsem te " + "\nHrac: " + playerPoints + "\nPocitac:" + pcPoints);
                        }
                        else if (odpoved == "zruseni")
                        {
                            konec = 1;
                        }
                        else
                        {
                            Console.WriteLine("to nebyla platna odpoved");
                        }
                    }
                    else if (x == 3)
                    {
                        Console.WriteLine("papir");
                        if (odpoved == "kamen")
                        {
                            pcPoints++;
                            Console.WriteLine("dostal jsem te " + "\nHrac: " + playerPoints + "\nPocitac:" + pcPoints);
                        }
                        else if (odpoved == "nuzky")
                        {
                            playerPoints++;
                            Console.WriteLine("dostal jsi mne " + "\nHrac: " + playerPoints + "\nPocitac:" + pcPoints);
                        }
                        else if (odpoved == "papir")
                        {
                            Console.WriteLine("remiza " + "\nHrac: " + playerPoints + "\nPocitac:" + pcPoints);
                        }
                        else if (odpoved == "zruseni")
                        {
                            konec = 1;
                        }
                        else
                        {
                            Console.WriteLine("to nebyla platna odpoved");
                        }
                    }

                }
                if (pcPoints == 3)
                {
                    Console.WriteLine("vyhral jsem :)");
                }
                else if (playerPoints == 3)
                {
                    Console.WriteLine("vyhrali jste");
                }
                if (konec == 0)
                {
                    Console.WriteLine("chcete jit znovu?(ano/ne)");
                    string odpovedOpakovani = Console.ReadLine();
                    if (odpovedOpakovani == "ano") opakovani = 1;                    
                }
                
            } while (opakovani != 0);
            
        }
    }
}
