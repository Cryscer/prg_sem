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
            Character player = new Character("player", 2, 2, 2, 3);
            bool isInTown = false;
            int xpCap = player.level * 3;
            /*Character enemy = new Character();

            while ((player.hp > 0) && (enemy.hp > 0)) 
            {
                player.Attack(enemy);
                enemy.Attack(player);
            }*/

            List<Room> dungeon = new List<Room>(10);
            Room room1 = new Room();
            room1.isPlayerInside = true;
            room1.GenerateRoom(player);
            Travel(isInTown);

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
            if (player.hp > 0) {/*DIE*/ }
            else player.xp += enemy1.xp + enemy2.xp;

        }
        static bool Travel(bool isInTown)
        {
            if (isInTown)
            {
                Console.WriteLine("Traveling to dungeon");
                isInTown = false;
            }
            else
            {
                Console.WriteLine("Traveling to town");
                isInTown = true;
            }
            return isInTown;
        }
        static void LevelUp(Character player, bool isInTown, int xpCap)
        {
            if (isInTown)
            {
                Console.WriteLine("What level would you want to raise?");
                string answerStat = Console.ReadLine();
                /*switch v s d e*/
                if (player.xp >= xpCap)
                {
                    switch (answerStat)
                    {
                        case "s":
                            xpCap = -xpCap;
                            player.strength += 1;
                            player.RenewStats();
                            break;
                        case "v":
                            xpCap = -xpCap;
                            player.vitality += 1;
                            player.hp += 5;
                            break;
                        case "d":
                            xpCap = -xpCap;
                            player.dexterity += 1;
                            player.RenewStats();
                            break;
                        case "e":
                            xpCap = -xpCap;
                            player.endurance += 1;
                            player.RenewStats();
                            break;
                    }

                }
                else Console.WriteLine("Not enough xp");                                                
            }
            else Console.WriteLine("Must be in Town!");
        }
        static void ChurchHeal(Character player, bool isInTown)
        {
            if (isInTown)
            {
                if (player.gold < 2) Console.WriteLine("Not enough gold!");
                else
                {
                    player.gold -= 2;
                    player.RenewHP();
                }
            }
            else Console.WriteLine("Must be in Town!");
        }
    }
}
