using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character player = new Character("player", 2, 2, 2, 3);                        
            Travel(player.isInTown, player);
            Console.ReadLine();
        }
        public static void InitiateCombat2(Character enemy, Character player, bool isInTown)
        {
            while ((player.hp > 0) && (enemy.hp > 0))
            {
                player.Attack(enemy);
                enemy.Attack(player);
            }
            if (player.hp > 0) PlayerDeath(player, isInTown);
            else player.xp += enemy.xp;

        }
        public static void InitiateCombat3(Character enemy1, Character enemy2, Character player, bool isInTown)
        {
            while ((player.hp > 0) && ((enemy1.hp > 0) || (enemy2.hp > 0)))
            {
                if (enemy1.hp > 0) player.Attack(enemy1);
                else player.Attack(enemy2);
                enemy1.Attack(player);
                enemy2.Attack(player);
            }
            if (player.hp > 0) PlayerDeath(player, isInTown);
            else player.xp += enemy1.xp + enemy2.xp;

        }
        static void PlayerDeath(Character player, bool isInTown)
        {
        player.xp = 0;
        player.gold /= 2;
        Travel(isInTown, player);
        player.RenewHP();
        Console.WriteLine("You feel your consciousness fading as a result of your injuries. " +
                "Then you find yourself waking up back in the town in a bed in the church, your wounds all healed. " +
                "Seems like some other hunters retrieved your body." +
                "xp = 0," +
                "gold halved," +
                "hp restored");
        }
        static bool Travel(bool isInTown, Character player)
        {
            bool loop;
            if (isInTown)
            {
                Console.WriteLine("Traveling to dungeon");
                isInTown = false;
                List<Room> dungeon = new List<Room>(5);
                Room room1 = new Room();
                dungeon.Add(room1);
                Room room2 = new Room();
                dungeon.Add(room2);
                Room room3 = new Room();
                dungeon.Add(room3);
                Room room4 = new Room();
                dungeon.Add(room4);
                Room room5 = new Room();
                dungeon.Add(room5);
                while (!player.isInTown)
                {
                    Room currentRoom = dungeon[0];
                    if (dungeon.Count > 1)
                    {
                        currentRoom.isPlayerInside = true;
                        dungeon[0].GenerateRoom(player);
                        dungeon.RemoveAt(0);
                        Console.WriteLine("Would you like to continue exploring[1] or return to town[2]?");
                        loop = false;
                        do
                        {
                            if (Console.ReadLine() == "2")
                            {
                                dungeon.Clear();
                                Travel(player.isInTown, player);
                                loop = false;
                            }
                            else if (Console.ReadLine() != "1")
                            {
                                Console.WriteLine("invalid answer");
                                loop = true;
                            }
                            else loop = false;
                        } while (loop);
                    }
                    else
                    {
                        Console.WriteLine("You beat all the challenges that this dungeon offered and arrive at the final room of the dungeon, the treasure room. " +
                            "Inside you find a chest filled with " + 10 * player.level + " gold in total. With nothing left to do you leave the dungeon");
                        player.gold += 10 * player.level;
                        Travel(player.isInTown, player);
                    }
                }
            }
            else if (player.hp > 0)
            {
                loop = true;
                Console.WriteLine("Traveling to town");
                isInTown = true;
                Console.WriteLine("You arrive at the town. Here your most important services are the church[1], which offers fully restoring your hp for 2 gold pieces, " +
                    "the Monument[2], which allows adventurers to empower themselves using the hard-earned life force of their enemies," +
                    "and the market[3], where you can buy equipment to aid you in your next dungeon exploration." +
                    "Alternatively, you could return to the dungeon[4].");
                while (loop)
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            ChurchHeal(player, isInTown);
                            break;
                        case "2":
                            LevelUp(player, isInTown, player.xpCap);
                            break;
                        case "3":
                            Market(player);
                            break;
                        case "4":
                            Travel(player.isInTown, player);
                            loop = false;
                            break;
                        default:
                            Console.WriteLine("Invalid answer");
                            break;
                    }
                    if (loop) Console.WriteLine("Where would you like to go next? The church[1], the Monument[2], the market[3] or the dungeon[4]?");
                }

            }
            else isInTown = true;
            return isInTown;
        }
        static void LevelUp(Character player, bool isInTown, int xpCap)
        {
            if (isInTown)
            {
                bool loop1 = true;
                bool loop2 = false;
                do
                {
                    
                    string answerStat = Console.ReadLine();
                    /*switch v s d e*/
                    if (player.xp >= xpCap)
                    {
                        Console.WriteLine("Which stat would you like to raise?");
                        switch (answerStat)
                        {
                            case "s":
                                xpCap = -xpCap;
                                player.strength += 1;
                                player.RenewStats();
                                Console.WriteLine("Strength raised, accuracy and damage improved. Remaining xp:" + player.xp + ", " + player.xpCap + " needed to level up forther");
                                break;
                            case "v":
                                xpCap = -xpCap;
                                player.vitality += 1;
                                player.hp += 5;
                                Console.WriteLine("Vitality raised, hp improved. Remaining xp:" + player.xp + ", " + player.xpCap + " needed to level up forther");
                                break;
                            case "d":
                                xpCap = -xpCap;
                                player.dexterity += 1;
                                player.RenewStats();
                                Console.WriteLine("Dexterity raised, accuracy and evasion improved. Remaining xp:" + player.xp + ", " + player.xpCap + " needed to level up forther");
                                break;
                            case "e":
                                xpCap = -xpCap;
                                player.endurance += 1;
                                player.RenewStats();
                                Console.WriteLine("Endurance raised, carry capacity improved. Remaining xp:" + player.xp + ", " + player.xpCap + " needed to level up forther");
                                break;
                        }
                        player.level += 1;
                        do
                        {
                            Console.WriteLine("Would you like to level up again?y/n");
                            if (Console.ReadLine() == "n")
                            {
                                loop1 = false;
                                loop2 = false;
                            }
                            else if (Console.ReadLine() != "y")
                            {
                                Console.WriteLine("invalid answer");
                                loop2 = true;
                            }
                            else loop2 = false;
                        } while (loop2);

                    }
                    else
                    {
                        Console.WriteLine("Not enough xp");
                        loop1 = false;
                    }
                } while (loop1);
            }
            else Console.WriteLine("Must be in Town!");
        }
        static void ChurchHeal(Character player, bool isInTown)
        {
            if (isInTown)
            {
                if (player.gold < 2) Console.WriteLine("Not enough gold!");
                else
                {
                    player.gold -= 2;
                    player.RenewHP();
                    Console.WriteLine("Hp succesfully restored! -2 gold");
                }
            }
            else Console.WriteLine("Must be in Town!");
        }
        static void Market(Character player)
        {
            Console.WriteLine("Here's the selection of items, their weights and prices" +
                "Health potions - 1W" +
                "Minor[1] - restores 5hp - 1G" +
                "Medium[2] - restores 10hp - 3G" +
                "Strong[3] - restores 15hp - 5G" +
                "Elixir of life[4] - fully restores hp - 10G" +
                "" +
                "Weapons" +
                "Dagger[5] - 3G, 1W - increases your damage to d6" +
                "Shortsword[6] - 6G, 2W - increases damage to 2d4 + 1 bonus damage" +
                "Longsword[7] - 12G, 3W - increases damage to 2d6 + 2 bonus damage " +
                "Greatsword[8] - 25G, 4W - increases damage to 3d6 + 3 bonus damage" +
                "" +
                "Armour" +
                "Leather[9] - 5G, 1W - increases evasion by 1 " +
                "Chain[10] - 10G. 3W - increases evasion by 2" +
                "Scale[11] - 15G. 4W - increases evasion by 3" +
                "Plate[12] - 25G. 6W - increases evasion by 4" +
                "" +
                "Exit[13]" +
                "" +
                "Which option would you like to select?");
            bool loop = true;
            do {
                switch (Console.ReadLine())
                {
                    case "1":
                        Healpot minorPotion = new Healpot(1, 1, 1);
                        minorPotion.BuyMany(player);
                        break;
                    case "2":
                        Healpot mediumPotion = new Healpot(2, 3, 1);
                        mediumPotion.BuyMany(player);
                        break;
                    case "3":
                        Healpot strongPotion = new Healpot(3, 5, 1);
                        strongPotion.BuyMany(player);
                        break;
                    case "4":
                        Healpot elixirPotion = new Healpot(4, 10, 1);
                        elixirPotion.BuyMany(player);
                        break;
                    case "5":
                        Weapon dagger = new Weapon(6, 0, 1, 3, 1);
                        dagger.BuyOne(player);
                        break;
                    case "6":
                        Weapon shortsword = new Weapon(4, 1, 2, 6, 2);
                        shortsword.BuyOne(player);
                        break;
                    case "7":
                        Weapon longsword = new Weapon(6, 2, 2, 12, 3);
                        longsword.BuyOne(player);
                        break;
                    case "8":
                        Weapon greatsword = new Weapon(6, 3, 3, 25, 4);
                        greatsword.BuyOne(player);
                        break;
                    case "9":
                        Armor leather = new Armor(1, 5, 1);
                        leather.BuyOne(player);
                        break;
                    case "10":
                        Armor chain = new Armor(2, 10, 3);
                        chain.BuyOne(player);
                        break;
                    case "11":
                        Armor scale = new Armor(3, 15, 4);
                        scale.BuyOne(player);
                        break;
                    case "12":
                        Armor plate = new Armor(4, 25, 6);
                        plate.BuyOne(player);
                        break;
                    case "13":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid answer!");
                        break;                            
                }
                Console.WriteLine("Anything else?");
            } while (loop);
        }
    }
}
