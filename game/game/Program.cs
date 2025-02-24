using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    internal class Program
    {        
        
      
        static void Main(string[] args)
        {                       
            Console.WriteLine("this is the player ");
            
            int vitality = 1;
            int endurance = 1;
            int strength = 1;
            int dexterity = 1;
            
            int attackBonus = strength + dexterity;
            int damageBonus = strength;
            int evasiveness = 10 + dexterity;
            int hp = 5 * vitality;

            Character player = new Character();
            /*Character enemy = new Character();

            while ((player.hp > 0) && (enemy.hp > 0)) 
            {
                player.Attack(enemy);
                enemy.Attack(player);
            }*/
            

            Slime slime1 = new Slime();
            slime1.Attack(player);
            Console.ReadLine();
        }
    }
}
