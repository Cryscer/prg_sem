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
            Character player = new Character();
            player.name = "player";
            player.vitality = 2;
            player.endurance = 2;
            player.strength = 2;
            player.dexterity = 2;
            player.RenewStats();
            
            /*Character enemy = new Character();

            while ((player.hp > 0) && (enemy.hp > 0)) 
            {
                player.Attack(enemy);
                enemy.Attack(player);
            }*/
            

            Slime slime1 = new Slime();
            while ((player.hp > 0) && (slime1.hp > 0))
            {
                slime1.Attack(player);
                player.Attack(slime1);
            }
            Console.ReadLine();
        }
    }
}
