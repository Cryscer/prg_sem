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

            List<Room> dungeon = new List<Room>(10);           
            Console.ReadLine();
        }
        public static void InitiateCombat2(Character enemy, Character player)
        {
            while ((player.hp > 0) && (enemy.hp > 0))
            {
                player.Attack(enemy);
                enemy.Attack(player);
            }
            
        }
        public static void InitiateCombat3(Character enemy1, Character enemy2, Character player)
        {
            while ((player.hp > 0) && ((enemy1.hp > 0) || (enemy2.hp > 0)))
            {
                if (enemy1.hp > 0) player.Attack(enemy1);
                else player.Attack(enemy2);
                enemy1.Attack(player);
                enemy2.Attack(player);
            }

        }
    }
}
