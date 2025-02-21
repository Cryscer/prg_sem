using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    internal class Character
    {
        int vitality, strength, endurance, dexterity, attackBonus, damageBonus, evasion, hp, damageDice;

        public Character(int vitality, int strength, int endurance, int dexterity)
        {
            attackBonus = strength + dexterity;
            damageBonus = strength;
            evasion = 10 + dexterity;
            hp = 5 * vitality;
            damageDice = 6;
        }

        static void Attack(Character attacker, Character defender)
        {
            Random rng = new Random();
            int chance = rng.Next(1, 21) + attacker.attackBonus;
            if (chance < defender.evasion) Console.WriteLine("Miss");
            else
            {
                int damage = rng.Next(1, attacker.damageDice + 1) + attacker.damageBonus;
                defender.hp -= damage;
                Console.WriteLine("Attack dealt " + damage + " damage");
            }

        }

    }
}
