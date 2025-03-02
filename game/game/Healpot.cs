using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    internal class Healpot : Item
    {
        public int healType;
        public Healpot(int healType, int price, int weight) : base(price, weight)
        {
            this.healType = healType;
            this.price = price;
            this.weight = weight;
        }
        public override void GiveToPlayer(Character player)
        {
            switch (healType)
            {
                case 1:
                    player.minorHealAmount++;
                    break;
                case 2:
                    player.mediumHealAmount++; 
                    break;
                case 3:
                    player.strongHealAmount++;
                    break;
                case 4:
                    player.elixirHealAmount++; 
                break;
            }                
        }
    }
}
