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
            int xpCap = player.level * 3;
            bool loop;
            /*Character enemy = new Character();

            while ((player.hp > 0) && (enemy.hp > 0)) 
            {
                player.Attack(enemy);
                enemy.Attack(player);
            }*/

            List<Room> dungeon = new List<Room>(10);
            Room room1 = new Room();
            dungeon.Add(room1);
            Room room2 = new Room();
            dungeon.Add(room2);
            Room room3 = new Room();
            dungeon.Add(room3);
            Room room4 = new Room();
            dungeon.Add(room4);
            Room room5 = new Room();
            dungeon.Add(room5);
            
            while (!player.isInTown)  
            {
                Room currentRoom = dungeon[0];
                if (dungeon.Count > 1)
                {
                    currentRoom.isPlayerInside = true;
                    dungeon[0].GenerateRoom(player);
                    dungeon.RemoveAt(0);
                    Console.WriteLine("Would you like to continue exploring[1] or return to town[2]?");
                    loop = false;
                    do
                    {
                        if (Console.ReadLine() == "2") Travel(player.isInTown);
                        else if (Console.ReadLine() != "1")
                        {
                            Console.WriteLine("invalid answer");
                            loop = true;
                        }
                    } while (loop);
                }
                else
                {
                    Console.WriteLine("You beat all the challenges that this dungeon offered and arrive at the final room of the dungeon, the treasure room. " +
                        "Inside you find a chest filled to the brim with 100 gold in total. With nothing left to do you leave the dungeon");
                    player.gold += 100;
                    Travel(player.isInTown);
                }
            }
                                              
            Console.ReadLine();
        }
        public static void InitiateCombat2(Character enemy, Character player, bool isInTown)
        {
            while ((player.hp > 0) && (enemy.hp > 0))
            {
                player.Attack(enemy);
                enemy.Attack(player);
            }
            if (player.hp > 0) PlayerDeath(player, isInTown);
            else player.xp += enemy.xp;

        }
        public static void InitiateCombat3(Character enemy1, Character enemy2, Character player, bool isInTown)
        {
            while ((player.hp > 0) && ((enemy1.hp > 0) || (enemy2.hp > 0)))
            {
                if (enemy1.hp > 0) player.Attack(enemy1);
                else player.Attack(enemy2);
                enemy1.Attack(player);
                enemy2.Attack(player);
            }
            if (player.hp > 0) PlayerDeath(player, isInTown);
            else player.xp += enemy1.xp + enemy2.xp;

        }
        static void PlayerDeath(Character player, bool isInTown)
        {
        player.xp = 0;
        player.gold /= 2;
        player.RenewHP();
        Travel(isInTown);
            Console.WriteLine("You feel your consciousness fading as a result of your injuries. " +
                "Then you find yourself waking up back in the town in a bed in the church, your wounds all healed. " +
                "Seems like some other hunters retrieved your body." +
                "xp = 0," +
                "gold halved," +
                "hp restored");
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
                Console.WriteLine("You arrive at the town. Here your most important services are the church[1], which offers fully restoring your hp for 2 gold pieces, " +
                    "the Monument[2], which allows adventurers to empower themselves using the hard-earned vitality of their enemies," +
                    "and the shop[3], where you can buy equipment and sell things obtained from the dungeon");
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
