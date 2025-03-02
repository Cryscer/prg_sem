using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    internal class Character
    {
        public int vitality = 1, strength = 1, endurance = 1, dexterity = 1, attackBonus, damageBonus, evasion, hp, damageDice, weightLoad, xp, level, gold, xpCap, weightCap, armorBonus = 0;
        public string name;
        public bool isAlive = true, isInTown = false;        

        public Character(string name ,int strength, int dexterity, int vitality, int damageDice)
        {           
            attackBonus = strength + dexterity;
            damageBonus = strength;
            evasion = 5 + dexterity + armorBonus;
            hp = 5 * vitality;
            this.damageDice = damageDice;
            this.name = name;
            weightCap = 3 * endurance;
            weightLoad = 0;
            level = 1;
            gold = 1;
            xpCap = level * 3;
        }

        public void Attack(Character defender)
        {
            if (isAlive == true) { 
            Random rng = new Random();
            Console.WriteLine( name + " attacked " + defender.name);
            int chance = rng.Next(1, 21) + attackBonus;               
                if (chance < defender.evasion) Console.WriteLine("Miss");
                else
                {
                    int damage = rng.Next(1, damageDice + 1) + damageBonus;
                    defender.hp -= damage;
                    Console.WriteLine("Attack dealt " + damage + " damage");
                    Console.WriteLine(defender.name + " has " + defender.hp + " hp left");
                    if (defender.hp <= 0)
                    {
                        Console.WriteLine(defender.name + " died");
                        defender.isAlive = false;
                    }
                    Console.WriteLine();
                }
            }
        }
        public void RenewStats()
        {
            attackBonus = strength + dexterity;
            damageBonus = strength;
            evasion = 10 + dexterity + armorBonus;            
            xpCap = level * 3;
        }
        public void RenewHP()
        {
            hp = vitality * 5;
        }
    }
}
