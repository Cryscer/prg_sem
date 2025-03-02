using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    internal abstract class Item
    {
        public int price, weight;
        public Item(int price, int weight) 
        { 
            this.price = price;
            this.weight = weight;
        }
        public void BuyMany(Character player)
        {
            bool loop = false;
            int answerAmount = 1;
            do
            {
                Console.WriteLine("How many would you like to buy?");
                try
                {
                    answerAmount = int.Parse(Console.ReadLine());
                }
                catch (Exception) { loop = true; }
            } while (loop);
            if ((player.gold > answerAmount * price) && ((player.weightLoad += answerAmount * weight) <= player.weightCap)) for (int i = 0; i < answerAmount; i++)
                {
                    GiveToPlayer(player);
                    player.gold -= price;
                    player.weightLoad += weight;
                }
            else if ((player.gold < answerAmount * price) && ((player.weightLoad += answerAmount * weight) <= player.weightCap)) Console.WriteLine("Not enough gold!");
            else if ((player.gold > answerAmount * price) && ((player.weightLoad += answerAmount * weight) > player.weightCap)) Console.WriteLine("Not enough weight capacity!");
            else Console.WriteLine("Not enough weight capcacity and gold!");            
        }
        public void BuyOne(Character player)
        {
            if ((player.gold > price) && ((player.weightLoad += weight) <= player.weightCap))
            {
                GiveToPlayer(player);
                player.gold -= price;
                player.weightLoad += weight;
            }
            else if ((player.gold < price) && ((player.weightLoad += weight) <= player.weightCap)) Console.WriteLine("Not enough gold!");
            else if ((player.gold > price) && ((player.weightLoad += weight) > player.weightCap)) Console.WriteLine("Not enough weight capacity!");
            else Console.WriteLine("Not enough weight capcacity and gold!");            
        }
        public abstract void GiveToPlayer(Character player);
    }
    
}
