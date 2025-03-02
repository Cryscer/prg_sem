using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game 
{
    internal class Armor : Item
    {
        public int armorBonus;
        public Armor(int armorBonus, int price, int weight) :  base (price, weight)
        {
            this.armorBonus = armorBonus;
            this.price = price;
            this.weight = weight;
        }
        override public void GiveToPlayer(Character player)
        {
            player.currentArmor = this;
            player.RenewStats();
        }
    }
}
