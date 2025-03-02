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

        int amountOfEnemies;
        int roomType;
        bool unexplored;
        public bool isPlayerInside;
        
        public Room()
        {
            Random rng = new Random();
            roomType = rng.Next(1, 11);
            amountOfEnemies = rng.Next(1, 3);          
        }
        
        public void GenerateRoom(Character player)
        {
            /*Random rng = new Random();
            int enemySelection = rng.Next(1,4);
            if (enemySelection == 1) {*/
            Slime slime1 = new Slime("slime1");
            Slime slime2 = new Slime("slime2");
            Character currentEnemy1 = slime1;
            Character currentEnemy2 = slime2;
            if (roomType > 2)
            {
                switch (amountOfEnemies)
                {
                    case 1:
                        Program.InitiateCombat2(currentEnemy1, player, player.isInTown);
                        break;
                    case 2:
                        Program.InitiateCombat3(currentEnemy1, currentEnemy2, player, player.isInTown);
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
