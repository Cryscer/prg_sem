﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPrices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> prices = new Dictionary<string, double>();
            prices["banany"] = 6.48;
            prices["mleko"] = 20.90;
            prices["okurka"] = 10.90;
            Console.WriteLine("co chcete udelat?");
            string command = Console.ReadLine();
            switch (command)
            {
                case "ukazat list" :
                    Console.WriteLine("list zbozi:");
                    foreach(KeyValuePair<string, double> kvp in prices) Console.WriteLine(kvp.Key);
                    break;
                
            }
                
            
            
                
                        
            string name1 = Console.ReadLine();
            prices[name1] = float.Parse(Console.ReadLine());
            Console.WriteLine(prices[name1]);
            Console.ReadLine();            
            

        }
    }
}
