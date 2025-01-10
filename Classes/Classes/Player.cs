using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Player
    {
        int health;
        public int damage;
        public string name;
        private Random rng;

        public Player(int health, int damage, string name)
        {
            SetHealth(health);
            this.damage = damage;
            this.name = name;
            rng = new Random();
        }

        public void SetHealth(int value)
        {
            health = value;
            if (health < 0) health = 0;
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
            return rng.Next(damage / 2, damage + damage / 2 + 1);
        }

        public void Hurt(int value)
        {
            health -= value;
            Console.WriteLine("player got hit for " + value + " damage");
            if (health <= 0) Console.WriteLine("Player is dead");
        }

        public bool IsDead()
        {
            return health <= 0;
        }
    }
}
