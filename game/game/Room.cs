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
        bool special;
        bool unentered;
        bool isPlayerInside;
        
        public Room()
        {
            Random rng = new Random();
            special = false;
            amountOfEnemies = rng.Next(1, 3);
            unentered = true;
            isPlayerInside = false;
            
        }
        
        public void GenerateRoom()
        {
            /*Random rng = new Random();
            int enemySelection = rng.Next(1,4);
            if (enemySelection == 1) {*/
            Slime slime1 = new Slime("slime1");
            Slime slime2 = new Slime("slime2");
            if (unentered && isPlayerInside) 
            {
                switch (amountOfEnemies) 
                {
                    case 1:
                        Program.InitiateCombat2(slime1, player);
                        break;
                    case 2:
                        Program.InitiateCombat3(slime1, slime2, player);
                        break ;                    
                }
            }                     
        } 
    }
}
