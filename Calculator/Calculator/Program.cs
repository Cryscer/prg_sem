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
                            if (inputB == 0)
                            {
                                Console.WriteLine("nulou nelze delit");
                                x = 1;
                            }
                            else
                            {
                                result = inputA / inputB;
                                Console.WriteLine("vysledek je " + result);
                            }
                            
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
                            if (inputA < 0)
                            {
                                Console.WriteLine("prosim zadejte kladne cislo");
                                x = 1;
                            }
                            else
                            {
                                Console.WriteLine("na kolikatou chcete odmocnovat?");
                                string root = Console.ReadLine();
                                float rootExponent = float.Parse(root);
                                result = Math.Pow(inputA, (1 / rootExponent)); //tohle jsem si nasel na internetu ve stack overflow
                                Console.WriteLine("vysledek je " + result);   
                            }
                            
                        }
                        else if (operationB == "faktorial")
                        {
                            if (inputA < 0)
                            {
                                Console.WriteLine("prosim zadejte kladne cislo");
                                x = 1;
                            }
                            else
                            {
                                int aButInt = (int)inputA;
                                Console.WriteLine(inputA + " prevedeno na " + aButInt);
                                result = 1;
                                for (int i = 1; i < aButInt + 1; i++)
                                {
                                    result = result * i;
                                }
                                Console.WriteLine("vysledek je " + result);
                            }
                        }
                        else if (operationB == "prevod") //tady jsem pridal prevod na dvojkovou soustavu
                        {
                            int aButInt = (int)inputA;                           
                            if (aButInt < 0)
                            {
                                Console.WriteLine("prosim zadejte kladne cislo");
                                x = 1;
                            }
                            else
                            {   
                                Console.WriteLine(inputA + " prevedeno na " + aButInt);
                                while (aButInt>1)
                                {
                                    int y = 1;
                                    int i;
                                    for (i = 0; aButInt >= Math.Pow(2, (i+1)); i++)
                                    {
                                        y = y * 2;
                                    }
                                    result = result + Math.Pow(10,(i));
                                    aButInt = aButInt - y;
                                }
                                result = result + aButInt;
                                Console.WriteLine("vysledek je " + result);
                            }
                            
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
