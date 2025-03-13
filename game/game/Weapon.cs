using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    internal class Weapon : Item
    {
        public int damageDice, damageBonus, damageDieAmount;

        public Weapon(int damageDice, int damageBonus, int damageDieAmount, int price, int weight) : base(price, weight)
        {
            this.damageDice = damageDice;
            this.damageBonus = damageBonus;
            this.damageDieAmount = damageDieAmount;
        }
        public override void GiveToPlayer(Character player)
        {
            player.weightLoad -= player.currentWeapon.weight;
            player.currentWeapon = this;
            player.RenewStats();
        }
    }
}
