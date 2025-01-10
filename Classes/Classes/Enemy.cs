using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Classes
{
    internal class Enemy
    {
        int health;
        int healthBase;
        int damage;
        int damageBase;
        int level;
        private Random rng;

        public Enemy (int healthBase, int damageBase, int level)
        {
            this.healthBase = healthBase;
            health = this.healthBase * level;
            this.damageBase = damageBase;
            damage = this.damageBase * level;
            this.level = level;
            rng = new Random();
        }

        public int GetHealth()
        {
            return health;
        }

        public int GetDamage()
        {
            return damage;
        }

        public int GetRandomizedDamage()
        {
            return rng.Next(damage / 2, damage + 1);
        }

        public void Hurt(int value)
        {
            health -= value;
            Console.WriteLine("enemy got hit for " + value + " damage");
            if (health <= 0) Console.WriteLine("Enemy is dead");
        }

        public bool IsDead()
        {
            return health <= 0;
        }
    }
}
