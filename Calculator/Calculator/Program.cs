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
                    float inputA = float.Parse(firstNum);
                    Console.WriteLine("Chcete zadat dalsi cislo? (zadejte ano nebo ne)");
                    string answerA = Console.ReadLine();
                    if (answerA == "ano")
                    {
                        Console.WriteLine("zadejte druhe cislo");
                        string scndNum = Console.ReadLine();
                        float inputB = float.Parse(scndNum);
                        Console.WriteLine("zadejte co s nima (moznosti jsou soucet, rozdil, nasobeni a deleni)"); //pridal jsem nasobeni a deleni
                        string operationA = Console.ReadLine();
                        
                        x = 0;
                        if (operationA == "soucet")
                        {
                            result = inputA + inputB;
                            Console.WriteLine("vysledek je " + result);
                        }
                        else if (operationA == "rozdil")
                        {
                            result = inputA - inputB;
                            Console.WriteLine("vysledek je " + result);
                        }
                        else if (operationA == "nasobeni")
                        {
                            result = inputA * inputB;
                            Console.WriteLine("vysledek je " + result);
                        }
                        else if (operationA == "deleni")
                        {
                            result = inputA / inputB;
                            Console.WriteLine("vysledek je " + result);
                        }
                        else
                        {
                            Console.WriteLine("priste zadejte platnou ciselnou operaci");
                            x = 1;
                        }
                    }
                    else if (answerA == "ne")
                    { 
                        x = 0;
                        Console.WriteLine("zadejte co s tim cislem (moznosti jsou mocneni, odmocnovani, faktorial a prevod, coz znamena prevod na dvojkovou soustavu)"); //krome mocneni a odmocnovani jsem taky pridal operaci faktorial
                        string operationB = Console.ReadLine();
                        if (operationB == "mocneni")
                        {
                            Console.WriteLine("na kolikatou chcete mocnit?");
                            string power = Console.ReadLine();
                            float powerExponent = float.Parse(power);
                            result = 1;
                            for (int i = 0; i < powerExponent; i++)
                            {
                                result = result * inputA;
                            }
                            Console.WriteLine("vysledek je " + result);
                        }
                        else if (operationB == "odmocnovani")
                        {
                            Console.WriteLine("na kolikatou chcete odmocnovat?");
                            string root = Console.ReadLine();
                            float rootExponent = float.Parse(root);
                            result = Math.Pow(inputA, (1 / rootExponent)); //tohle jsem si nasel na internetu ve stack overflow
                            Console.WriteLine("vysledek je " + result);
                        }
                        else if (operationB == "faktorial")
                        {
                            result = 1;
                            for (int i = 1; i < inputA+1; i++)
                            {
                                result = result * i;
                            }                            
                            Console.WriteLine("vysledek je " + result);
                        }
                        else if (operationB == "prevod") //tady jsem pridal prevod na dvojkovou soustavu
                        {
                            while (inputA>1)
                            {
                                float y = 1;
                                float i = 0;
                                for (i = 0; inputA > Math.Pow(2, (i + 1)); i++)
                                {
                                    y = y * 2;
                                }
                                result = result + Math.Pow(10,(i));
                                inputA = inputA - y;
                            }
                            result = result + inputA;
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
