using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    internal class Character
    {
        public int vitality, strength, endurance = 2, dexterity, attackBonus, damageBonus, evasion, hp, damageDice, weightLoad, xp, level, gold, xpCap, weightCap, armorBonus = 0, weaponBonus, damageDiceAmount;
        public string name;
        public bool isAlive = true, isInTown = true;
        public Armor currentArmor = new Armor(0,0,0);   
        public int minorHealAmount = 0;
        public int mediumHealAmount = 0;
        public int strongHealAmount = 0;
        public int elixirHealAmount = 0;

        public Character(string name, int strength, int dexterity, int vitality, int damageDice, int xp, int gold, int weaponBonus, int damageDiceAmount)
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.vitality = vitality;
            this.damageDiceAmount = damageDiceAmount;
            attackBonus = strength + dexterity;
            this.weaponBonus = weaponBonus;
            damageBonus = strength + this.weaponBonus;
            evasion = 5 + dexterity + armorBonus;
            hp = 5 * vitality;
            this.damageDice = damageDice;
            this.name = name;
            weightCap = 3 * endurance;
            weightLoad = 0;
            level = 1;
            this.gold = gold;
            this.xp = xp;
            xpCap = level * 3;
        }

        public void Attack(Character defender, int d20, int dDamage)
        {
            if (isAlive) { 
                Random rng = new Random();
                Console.WriteLine( name + " attacked " + defender.name);
                int chance = d20 + attackBonus;
                Console.WriteLine(d20 + " + " + attackBonus + " against " + defender.name + "'s " + defender.evasion + " evasion.");
                if (chance < defender.evasion) Console.WriteLine("Miss");
                else
                {
                    int damage = dDamage * damageDiceAmount + damageBonus;
                    Console.WriteLine(damageDiceAmount + " * " + dDamage + " + " + damageBonus);
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
            armorBonus = currentArmor.armorBonus;
            attackBonus = strength + dexterity;
            damageBonus = strength + weaponBonus;
            evasion = 10 + dexterity + armorBonus;            
            xpCap = level * 3;
            
        }
        public void RenewHP()
        {
            hp = vitality * 5;
        }
        public bool DrinkHeal(int potionType, bool used)
        {
            used = false;
            switch (potionType)
            {
                case 1:
                    if (minorHealAmount > 0)
                    {
                        if ((hp + 5) <= (5 * vitality)) hp += 5;
                        else RenewHP();
                        minorHealAmount--;
                        used = true;
                    }
                    else Console.WriteLine("Invalid answer!");
                    break;
                case 2:
                    if (mediumHealAmount > 0)
                    {
                        if ((hp + 10) <= (5 * vitality)) hp += 10;
                        else RenewHP();
                        mediumHealAmount--;
                        used = true;
                    }
                    else Console.WriteLine("Invalid answer!");
                    break;
                case 3:
                    if (strongHealAmount > 0)
                    {
                        if ((hp + 15) <= (5 * vitality)) hp += 15;
                        else RenewHP();
                        strongHealAmount--;
                        used = true;
                    }
                    else Console.WriteLine("Invalid answer!");
                    break;
                case 4:
                    if (elixirHealAmount > 0)
                    {
                        RenewHP();
                        elixirHealAmount--;
                        used = true;
                    }
                    else Console.WriteLine("Invalid answer!");
                    break;
                default:
                    Console.WriteLine("Invalid answer!");
                    break;
            }
            return used;
        }
    }
}
