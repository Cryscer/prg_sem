using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    internal class Character
    {
        public int vitality, strength, endurance, dexterity, attackBonus, damageBonus, evasion, hp, damageDice;
        string name = " character";

        public Character()
        {
            name = "character";
            strength = 1;
            endurance = 1;
            dexterity = 1;
            attackBonus = 1;
            attackBonus = strength + dexterity;
            damageBonus = strength;
            evasion = 10 + dexterity;
            hp = 5 * vitality;
            damageDice = 6;
        }

        public void Attack(Character defender)
        {
            Random rng = new Random();
            Console.WriteLine( name + " attacked " + defender.name);
            int chance = rng.Next(1, 21) + attackBonus;
            if (chance < defender.evasion) Console.WriteLine("Miss");
            else
            {
                int damage = rng.Next(1, damageDice + 1) + damageBonus;
                defender.hp -= damage;
                Console.WriteLine("Attack dealt " + damage + " damage");
                Console.WriteLine(defender.hp);
            }

        }

    }
}
