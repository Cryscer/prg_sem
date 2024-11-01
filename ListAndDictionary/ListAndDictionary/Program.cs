using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListAndDictionary
{
    internal class Program
    {
        static void PrintList(List<string> list)
        {
            foreach (string name in list)
            {
                Console.Write(name + ",");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("spagety");
            list.Add("palacinky");
            list.Add("buchty");
            list.Add("pizza");
            list.Add("dort");

            PrintList(list);

            list.RemoveAt(3);
            PrintList(list);

            


            Dictionary<string, string> favoriteFoods = new Dictionary<string, string>();
            favoriteFoods["Karel"] = "buchticky se sodo";
            favoriteFoods["Lojza"] = "sisky s makem";
            favoriteFoods["Xaver"] = "vypecky se zelim";
            favoriteFoods["Andromeda"] = "Kabanos";
            favoriteFoods["Cecilie"] = "durum kebab se syrem, cesnekem a bylinkami";

            foreach(KeyValuePair<string, string> studentAndFood in favoriteFoods)
            {
                string name = studentAndFood.Key;
                string food = studentAndFood.Value;
                Console.WriteLine("Oblibene jidlo studenta " + name + " je " + food);
            }
            if (favoriteFoods.ContainsKey("Martin")) Console.WriteLine("Martin je v seznamu a ma oblibene jidlo");
            else Console.WriteLine("Martin neni v seznamu a zivi se energii vesmiru");
            
        
            

            Console.ReadKey();
        }
    }
}
