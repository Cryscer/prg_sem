using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    internal class Room
    {
        Random rng = new Random();
        int amountOfEnemies;
        int roomType;
        public bool isPlayerInside;
        
        public Room(int roomType)
        {
            this.roomType = roomType; 
            amountOfEnemies = rng.Next(1, 3);          
        }
        
        public void GenerateRoom(Character player)
        {
            Character currentEnemy1 = new Slime("slime1");
            Character currentEnemy2 = new Slime("slime2");
            if ((3 <= player.level) && (player.level < 6))
            {
                currentEnemy1 = new Character("goblin", 2, 5, 3, 6, 4, 3, 0, 1);
                currentEnemy2 = new Slime("slime");
            }
            else if ((6 <= player.level) && (player.level < 9))
            {
                currentEnemy1 = new Character("goblin1", 2, 5, 3, 6, 4, 3, 0, 1);
                currentEnemy2 = new Character("goblin2", 2, 5, 3, 6, 4, 3, 0, 1);
            }
            else if ((9 <= player.level) && (player.level < 12))
            {
                currentEnemy1 = new Character("skeleton", 5, 5, 5, 4, 7, 4, 1, 2);
                currentEnemy2 = new Character("goblin", 2, 5, 3, 6, 4, 3, 0, 1);
            }
            else if ((12 <= player.level) && (player.level < 15))
            {
                currentEnemy1 = new Character("skeleton1", 5, 5, 5, 4, 7, 4, 1, 2);
                currentEnemy2 = new Character("skeleton2", 5, 5, 5, 4, 7, 4, 1, 2);
            }
            else if ((15 <= player.level) && (player.level < 18))
            {
                currentEnemy1 = new Character("orc", 7, 4, 7, 6, 10, 7, 2, 2);
                currentEnemy2 = new Character("skeleton", 5, 5, 5, 4, 7, 4, 1, 2);
            }
            else if ((18 <= player.level) && (player.level < 21))
            {
                currentEnemy1 = new Character("orc1", 7, 4, 7, 6, 10, 7, 2, 2);
                currentEnemy2 = new Character("orc2", 7, 4, 7, 6, 10, 7, 2, 2);
            }
            else if ((21 <= player.level) && (player.level < 24))
            {
                currentEnemy1 = new Character("troll", 10, 7, 10, 10, 20, 12, 3, 3);
                currentEnemy2 = new Character("orc", 7, 4, 7, 6, 10, 7, 2, 2);
            }
            else if (24 <= player.level)
            {
                currentEnemy1 = new Character("troll1", 10, 7, 10, 10, 20, 12, 3, 3);
                currentEnemy2 = new Character("troll2", 10, 7, 10, 10, 20, 12, 3, 3);
            }

            if (roomType > 2)
            {
                switch (amountOfEnemies)
                {
                    case 1:
                        Console.WriteLine("You find a room with an enemy in it. Naturally, you start fighting.");
                        Console.WriteLine(currentEnemy1.name + " blocks the way!");
                        Program.InitiateCombat2(currentEnemy1, player);
                        break;
                    case 2:
                        Console.WriteLine("You find a room with 2 enemies in it. Naturally, you start fighting.");
                        Console.WriteLine(currentEnemy1.name + " and " + currentEnemy2.name + " block the way!");
                        Program.InitiateCombat3(currentEnemy1, currentEnemy2, player);
                        break;
                }
            }
            else if (roomType == 2)
            {
                Console.WriteLine("You find a room with an altar containing a small pool of glowing liquid. Drinking it fully restores your hp.");
                player.RenewHP();
            }
            else
            {
                Console.WriteLine("The room you find is empty save for some coins. You grab them and move on." +
                    "+ " + player.level * 2 + " gold");
                player.gold += player.level * 2;                
            }
        }
    }
}
