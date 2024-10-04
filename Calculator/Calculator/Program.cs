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
                        Console.WriteLine("zadejte co s nima (moznosti jsou soucet, rozdil, nasobeni a deleni)"); //pridal jsem nasobeni a deleni
                        string operaceA = Console.ReadLine();
                        
                        x = 0;
                        if (operaceA == "soucet")
                        {
                            result = a + b;
                            Console.WriteLine("vysledek je " + result);
                        }
                        else if (operaceA == "rozdil")
                        {
                            result = a - b;
                            Console.WriteLine("vysledek je " + result);
                        }
                        else if (operaceA == "nasobeni")
                        {
                            result = a * b;
                            Console.WriteLine("vysledek je " + result);
                        }
                        else if (operaceA == "deleni")
                        {
                            result = a / b;
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
                        Console.WriteLine("zadejte co s tim cislem (moznosti jsou mocneni, odmocnovani, faktorial a prevod, coz znamena prevod na dvojkovou soustavu)"); //krome mocneni a odmocnovani jsem taky pridal operaci faktorial
                        string operaceB = Console.ReadLine();
                        if (operaceB == "mocneni")
                        {
                            Console.WriteLine("na kolikatou chcete mocnit?");
                            string mocnina = Console.ReadLine();
                            float mocninaCislo = float.Parse(mocnina);
                            result = 1;
                            for (int i = 0; i < mocninaCislo; i++)
                            {
                                result = result * a;
                            }
                            Console.WriteLine("vysledek je " + result);
                        }
                        else if (operaceB == "odmocnovani")
                        {
                            Console.WriteLine("na kolikatou chcete odmocnovat?");
                            string odmocnina = Console.ReadLine();
                            float odmocninaCislo = float.Parse(odmocnina);
                            result = Math.Pow(a, (1 / odmocninaCislo)); //Math.Pow jsem si nasel na internetu ve stack overflow
                            Console.WriteLine("vysledek je " + result);
                        }
                        else if (operaceB == "faktorial")
                        {
                            result = 1;
                            for (int i = 1; i < a+1; i++)
                            {
                                result = result * i;
                            }                            
                            Console.WriteLine("vysledek je " + result);
                        }
                        else if (operaceB == "prevod") //tady jsem pridal prevod na dvojkovou soustavu
                        {
                            while (a>1)
                            {
                                float y = 1;
                                float i;
                                for (i = 0; a > Math.Pow(2, (i + 1)); i++)
                                {
                                    y = y * 2;
                                }
                                result = result + Math.Pow(10,(i));
                                a = a - y;
                            }
                            result = result + a;
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
