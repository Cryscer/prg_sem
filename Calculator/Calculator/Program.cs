using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int x = 0;
            //integer x pozijeme k opakovani kodu pokud uzivatel zada spatne cislo nebo ciselnou operaci
            do
            {
                try //try a catch jsem si nasel na internetu takze mozna to ma byt jinak?
                {   
                    double result = 0; // result musim mit na double aby mi fungovaly odmocniny
                    Console.WriteLine("zadejte prvni cislo");
                    string firstNum = Console.ReadLine();
                    float a = float.Parse(firstNum);
                    Console.WriteLine("Chcete zadat dalsi cislo? (zadejte ano nebo ne)");
                    string odpovedA = Console.ReadLine();
                    if (odpovedA == "ano")
                    {
                        Console.WriteLine("zadejte druhe cislo");
                        string scndNum = Console.ReadLine();
                        float b = float.Parse(scndNum);
                        Console.WriteLine("zadejte co s nima (moznosti jsou soucet, rozdil a mocneni)");
                        string operace = Console.ReadLine();
                        
                        x = 0;
                        if (operace == "soucet")
                        {
                            result = a + b;
                            Console.WriteLine("vysledek je " + result);
                        }
                        else if (operace == "rozdil")
                        {
                            result = a - b;
                            Console.WriteLine("vysledek je " + result);
                        }
                        else
                        {
                            Console.WriteLine("priste zadejte platnou ciselnou operaci");
                            x = 1;
                        }
                    }
                    else if (odpovedA == "ne")
                    { 
                        x = 0;
                        Console.WriteLine("zadejte co s tim cislem (moznosti jsou mocneni a odmocnovani)");
                        string odpovedB = Console.ReadLine();
                        if (odpovedB == "mocneni")
                        {
                            Console.WriteLine("na kolikatou chcete mocnit?");
                            string mocnina = Console.ReadLine();
                            float mocninaCislo = float.Parse(mocnina);
                            result = Math.Pow(a, (mocninaCislo));
                            Console.WriteLine("vysledek je " + result);
                        }
                        else if (odpovedB == "odmocnovani")
                        {
                            Console.WriteLine("na kolikatou chcete odmocnovat?");
                            string odmocnina = Console.ReadLine();
                            float odmocninaCislo = float.Parse(odmocnina);
                            result = Math.Pow(a, (1 / odmocninaCislo)); //tohle jsem si nasel na internetu na stack overflow
                            Console.WriteLine("vysledek je " + result);
                        }
                        else
                        {
                            Console.WriteLine("priste zadejte platnou odpoved");
                            x = 1;
                        }

                    }
                    else
                    {
                        Console.WriteLine("priste zadejte platnou odpoved");
                        x = 1;
                    }
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("priste zadejte cislo");
                    x = 1;

                }
            } while (x==1);
            
            Console.ReadKey();            
        }
    }
}
