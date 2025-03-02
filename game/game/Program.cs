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
            Character player = new Character("player", 2, 2, 2, 3, 0, 0, 0, 1);
            Travel(player);
            Console.ReadLine();
        }
        public static void InitiateCombat2(Character enemy, Character player)
        {
            Random rng = new Random();
            bool loop1;
            bool loop2;
            bool itemUsed;
            bool attacked;
            while ((player.hp > 0) && (enemy.hp > 0) && (!player.isInTown))
            {
                itemUsed = false;
                Console.WriteLine("Would you like to attack[1], use a healing potion[2], check your character info[3] or flee[4]?");
                do
                {
                    attacked = false;
                    loop1 = true;
                    string answerA = Console.ReadLine();
                    switch (answerA) 
                    {
                        case "1":
                            player.Attack(enemy, rng.Next(1, 21), rng.Next(1, player.damageDice + 1));
                            attacked = true;
                            loop1 = false;
                            break;
                        case "2":
                            if (itemUsed) Console.WriteLine("One item already used this round!");
                            else
                            {
                                Console.WriteLine("Which healing potion would you like to use?" +
                                    "\nMinor[1] - restores 5hp - " + player.minorHealAmount +
                                    "\nMedium[2] - restores 10hp - " + player.mediumHealAmount +
                                    "\nStrong[3] - restores 15hp - " + player.strongHealAmount +
                                    "\nElixir of life[4] - fully restores hp - " + player.elixirHealAmount
                                    + "\nExit[5]");
                                do
                                {
                                    loop2 = true;
                                    string answerB = Console.ReadLine();
                                    switch (answerB)
                                    {
                                        case "1":
                                            player.hp += 5;
                                            player.minorHealAmount--;
                                            itemUsed = true;
                                            loop2 = false;
                                            break;
                                        case "2":
                                            player.hp += 10;
                                            player.mediumHealAmount--;
                                            itemUsed = true;
                                            loop2 = false;
                                            break;
                                        case "3":
                                            player.hp += 15;
                                            player.strongHealAmount--;
                                            itemUsed = true;
                                            loop2 = false;
                                            break;
                                        case "4":
                                            player.RenewHP();
                                            player.elixirHealAmount--;
                                            itemUsed = true;
                                            loop2 = false;
                                            break;
                                        case "5":
                                            loop2 = false;
                                            break;
                                        default:
                                            Console.WriteLine("Invalid answer!");
                                            loop2 = true;
                                            break;
                                    }
                                } while (loop2);
                            }
                            break;
                        case "3":
                            GenerateSheet(player);
                            break;
                        case "4":
                            Console.WriteLine("Are you sure you want to flee back to the town?y/n");
                            if (Console.ReadLine() == "y")
                            {
                                Travel(player);
                                loop1 = false;
                            }
                            else if (Console.ReadLine() == "n") loop1 = true;
                            else
                            {
                                Console.WriteLine("Invalid answer!");
                                loop1 = true;
                            }
                            break;
                        default :
                            Console.WriteLine("Invalid answer!");
                            loop1 = true;
                            break;
                    }
                    if (itemUsed && (player.hp > 0) && (enemy.hp > 0) && (!player.isInTown) && (!attacked)) Console.WriteLine("What would you like to do now? Attack[1], check character info[3] or flee[4]?");
                    else if ((player.hp > 0) && (enemy.hp > 0) && (!player.isInTown) && (!attacked)) Console.WriteLine("What would you like to do now? Attack[1], use a healing potion[2], check character info[3] or flee[4]?");
                } while (loop1);
                if (!player.isInTown) enemy.Attack(player, rng.Next(1, 21), rng.Next(1, enemy.damageDice + 1));
            }
            if ((player.hp <= 0) && (!player.isInTown)) PlayerDeath(player);
            else if (!player.isInTown)
            {
                player.xp += enemy.xp;
                player.gold += enemy.gold;
                Console.WriteLine("+ " + enemy.xp + " xp" +
                    "\n+ " + enemy.gold + " gold");
            }

        }
        public static void InitiateCombat3(Character enemy1, Character enemy2, Character player)
        {
            Random rng = new Random();
            bool loop1;
            bool loop2;
            bool loop3;
            bool itemUsed;
            bool attacked;
            while ((player.hp > 0) && ((enemy1.hp > 0) || (enemy2.hp > 0)))
            {
                itemUsed = false;
                Console.WriteLine("Would you like to attack[1], use a healing potion[2], check your character info[3] or flee[4]?");
                do
                {
                    loop1 = true;
                    attacked = false;
                    string answerA = Console.ReadLine();
                    switch (answerA)
                    {
                        case "1":
                            if ((enemy1.hp > 0) && (enemy2.hp > 0))
                            {
                                Console.WriteLine("Whci enemy would you like to attack, " + enemy1.name + "[1] or " + enemy2.name + "[2]?" +
                                    "\nExit[3]");
                                loop3 = true;
                                do
                                {
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            player.Attack(enemy1, rng.Next(1, 21), rng.Next(1, player.damageDice + 1));
                                            loop3 = false;
                                            loop1 = false;
                                            attacked = true;
                                            break;
                                        case "2":
                                            player.Attack(enemy2, rng.Next(1, 21), rng.Next(1, player.damageDice + 1));
                                            loop3 = false;
                                            loop1 = false;
                                            attacked = true;
                                            break;
                                        case "3":
                                            loop3 = false;
                                            break;
                                        default:
                                            Console.WriteLine("Invalid answer!");
                                            break;
                                    }
                                } while (loop3);
                            }
                            else if (enemy1.hp > 0)
                            {
                                player.Attack(enemy1, rng.Next(1, 21), rng.Next(1, player.damageDice + 1));
                                loop3 = false;
                                loop1 = false;
                                attacked = true;
                            }
                            else if (enemy2.hp > 0)
                            {
                                player.Attack(enemy2, rng.Next(1, 21), rng.Next(1, player.damageDice + 1));
                                loop3 = false;
                                loop1 = false;
                                attacked = true;
                            }
                                break;
                        case "2":
                            if (itemUsed) Console.WriteLine("One item already used this round!");
                            else
                            {
                                Console.WriteLine("Which healing potion would you like to use?" +
                                    "\nMinor[1] - restores 5hp - " + player.minorHealAmount +
                                    "\nMedium[2] - restores 10hp - " + player.mediumHealAmount +
                                    "\nStrong[3] - restores 15hp - " + player.strongHealAmount +
                                    "\nElixir of life[4] - fully restores hp - " + player.elixirHealAmount
                                    + "\nExit[5]");
                                do
                                {
                                    loop2 = true;
                                    string answerB = Console.ReadLine();
                                    switch (answerB)
                                    {
                                        case "1":
                                            itemUsed = player.DrinkHeal(1, itemUsed);
                                            if (itemUsed) loop2 = false;
                                            break;
                                        case "2":
                                            itemUsed = player.DrinkHeal(2, itemUsed);
                                            if (itemUsed) loop2 = false;
                                            break;
                                        case "3":
                                            itemUsed = player.DrinkHeal(3, itemUsed);
                                            if (itemUsed) loop2 = false;
                                            break;
                                        case "4":
                                            itemUsed = player.DrinkHeal(4, itemUsed);
                                            if (itemUsed) loop2 = false;
                                            break;
                                        case "5":
                                            loop2 = false;
                                            break;
                                        default:
                                            Console.WriteLine("Invalid answer!");
                                            loop2 = true;
                                            break;
                                    }
                                } while (loop2);
                            }
                            break;
                        case "3":
                            GenerateSheet(player);
                            break;
                        case "4":
                            Console.WriteLine("Are you sure you want to flee back to the town?y/n");
                            if (Console.ReadLine() == "y")
                            {
                                Travel(player);
                                loop1 = false;
                            }
                            else if (Console.ReadLine() == "n") loop1 = true;
                            else
                            {
                                Console.WriteLine("Invalid answer!");
                                loop1 = true;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid answer!");
                            loop1 = true;
                            break;
                    }
                    if ((itemUsed) && ((player.hp > 0) && ((enemy1.hp > 0) || (enemy2.hp > 0))) && (!attacked)) Console.WriteLine("What would you like to do now? Attack[1], check character info[3] or flee[4]?");
                    else if ((!itemUsed) && (player.hp > 0) && ((enemy1.hp > 0) || (enemy2.hp > 0)) && (!attacked)) Console.WriteLine("What would you like to do now? Attack[1], use a healing potion[2], check character info[3] or flee[4]?");                   
                } while (loop1);
                if (!player.isInTown)
                {
                    enemy1.Attack(player, rng.Next(1, 21), rng.Next(1, enemy1.damageDice + 1));
                    enemy2.Attack(player, rng.Next(1, 21), rng.Next(1, enemy2.damageDice + 1));
                }
            }
            if ((player.hp <= 0) && (!player.isInTown)) PlayerDeath(player);
            else if (!player.isInTown)
            {
                player.xp += enemy1.xp + enemy2.xp;
                player.gold += enemy1.gold + enemy2.gold;
                Console.WriteLine("+ " + (enemy1.xp + enemy2.xp) + " xp" +
                    "\n+ " + (enemy1.gold + enemy2.gold) + " gold");
            }
        }
        static void PlayerDeath(Character player)
        {
            player.xp = 0;
            player.gold /= 2;
        
            player.RenewHP();
            Console.WriteLine("You feel your consciousness fading as a result of your injuries. " +
                "\nThen you find yourself waking up back in the town in a bed in the church, your wounds all healed. " +
                "\nSeems like some other hunters retrieved your body." +
                "\nxp = 0," +
                "\ngold halved," +
                "\nhp restored");
            Travel(player);
        }
        static void Travel(Character player)
        {
            bool loop, loop2;
            if (player.isInTown)
            {
                Random rng = new Random();
                Console.WriteLine("Traveling to dungeon\n");
                player.isInTown = false;
                List<Room> dungeon = new List<Room>(5);
                Room room1 = new Room(rng.Next(1, 11));
                dungeon.Add(room1);
                Room room2 = new Room(rng.Next(1, 11));
                dungeon.Add(room2);
                Room room3 = new Room(rng.Next(1, 11));
                dungeon.Add(room3);
                Room room4 = new Room(rng.Next(1, 11));
                dungeon.Add(room4);
                Room room5 = new Room(rng.Next(1, 11));
                dungeon.Add(room5);
                Room room6 = new Room(rng.Next(1, 11));
                dungeon.Add(room6);
                Room room7 = new Room(rng.Next(1, 11));
                dungeon.Add(room7);
                Room room8 = new Room(rng.Next(1, 11));
                dungeon.Add(room8);
                Room room9 = new Room(rng.Next(1, 11));
                dungeon.Add(room9);
                Room room10 = new Room(rng.Next(1, 11));
                dungeon.Add(room10);
                while (!player.isInTown)
                {
                    if (dungeon.Count > 1)
                    {
                        dungeon[0].GenerateRoom(player);
                        dungeon.RemoveAt(0); 
                        do
                        {
                            Console.WriteLine("Would you like to continue exploring[1], return to town[2], use a healing potion[3] or check your character sheet[4]?");
                            loop = true;
                            string answerA = Console.ReadLine();
                            switch (answerA)
                            {
                                case "1":
                                    loop = false;
                                    break;
                                case "2":
                                    dungeon.Clear();
                                    Travel(player);
                                    loop = false;
                                    break;
                                case "3":
                                    Console.WriteLine("Which healing potion would you like to use?" +
                                        "\nMinor[1] - restores 5hp - " + player.minorHealAmount +
                                        "\nMedium[2] - restores 10hp - " + player.mediumHealAmount +
                                        "\nStrong[3] - restores 15hp - " + player.strongHealAmount +
                                        "\nElixir of life[4] - fully restores hp - " + player.elixirHealAmount
                                        + "\nExit[5]");
                                    do
                                    {
                                        string answerB = Console.ReadLine();
                                        bool useless = false;
                                        loop2 = true;
                                        switch (answerB)
                                        {
                                            case "1":
                                                useless = player.DrinkHeal(1, useless);
                                                loop2 = false;
                                                break;
                                            case "2":
                                                useless = player.DrinkHeal(2, useless);
                                                loop2 = false;
                                                break;
                                            case "3":
                                                useless = player.DrinkHeal(3, useless);
                                                loop2 = false;
                                                break;
                                            case "4":
                                                useless = player.DrinkHeal(4, useless);
                                                loop2 = false;
                                                break;
                                            case "5":
                                                loop2 = false;
                                                break;
                                            default:
                                                Console.WriteLine("Invalid answer!");
                                                break;
                                        }
                                    } while (loop2);
                                    break;
                                case "4":
                                    GenerateSheet(player);
                                    break;
                            }
                        } while (loop);
                    }
                    else
                    {
                        Console.WriteLine("You beat all the challenges that this dungeon offered and arrive at the final room of the dungeon, the treasure room. " +
                            "\nInside you find a chest filled with " + 10 * player.level + " gold in total. With nothing left to do you leave the dungeon");
                        player.gold += 10 * player.level;
                        Travel(player);
                    }
                }
            }
            else if (player.hp > 0)
            {
                loop = true;
                Console.WriteLine("Traveling to town\n");                
                player.isInTown = true;
                Console.WriteLine("You arrive at the town. Here your most important services are the church[1], which offers fully restoring your hp for 2 gold pieces, " +
                    "\nthe Monument[2], which allows adventurers to empower themselves using the hard-earned life force of their enemies," +
                    "\nand the market[3], where you can buy equipment to aid you in your next dungeon exploration." +
                    "\nAlternatively, you could return to the dungeon[4]." +
                    "\n" +
                    "\nCheck character profile[5]");
                while (loop)
                {
                    string answerA = Console.ReadLine();
                    switch (answerA)
                    {
                        case "1":
                            ChurchHeal(player, player.isInTown);
                            break;
                        case "2":
                            LevelUp(player);
                            break;
                        case "3":
                            Market(player);
                            break;
                        case "4":
                            Travel(player);
                            loop = false;
                            break;
                        case "5":
                            GenerateSheet(player);
                            break;
                        default:
                            Console.WriteLine("Invalid answer");
                            break;
                    }
                    if (loop) Console.WriteLine("Where would you like to go next? The church[1], the Monument[2], the market[3] or the dungeon[4]?" +
                        "\nCheck character profile[5]");
                }

            }
            else player.isInTown = true;
        }
        static void LevelUp(Character player)
        {
            bool loop1 = true;
            bool loop2;
            bool loop3;
            do
            {
                if (player.xp >= player.xpCap)
                {
                    Console.WriteLine("Which stat would you like to raise? Strenght[1] for accuracy and damage, Vitality[2] for hp, Dexterity[3] for evasion and accuracy, Endurance[4] for carry capacity.");
                    do
                    {
                        loop3 = false;
                        string answerStat = Console.ReadLine();
                        switch (answerStat)
                        {
                            case "1":
                                player.xp -= player.xpCap;
                                player.strength += 1;
                                player.RenewStats();
                                Console.WriteLine("Strength raised, accuracy and damage improved. Remaining xp:" + player.xp + ", " + player.xpCap + " needed to level up forther");
                                break;
                            case "2":
                                player.xp -= player.xpCap;
                                player.vitality += 1;
                                player.hp += 5;
                                Console.WriteLine("Vitality raised, hp improved. Remaining xp:" + player.xp + ", " + player.xpCap + " needed to level up forther");
                                break;
                            case "3":
                                player.xp -= player.xpCap;
                                player.dexterity += 1;
                                player.RenewStats();
                                Console.WriteLine("Dexterity raised, accuracy and evasion improved. Remaining xp:" + player.xp + ", " + player.xpCap + " needed to level up forther");
                                break;
                            case "4":
                                player.xp -= player.xpCap;
                                player.endurance += 1;
                                player.RenewStats();
                                Console.WriteLine("Endurance raised, carry capacity improved. Remaining xp:" + player.xp + ", " + player.xpCap + " needed to level up forther");
                                break;
                            default:
                                Console.WriteLine("invalid answer");
                                loop3 = true;
                                break;
                        }
                    } while (loop3);
                    player.level += 1;
                    do
                    {
                        Console.WriteLine("Would you like to level up again?y/n");
                        string answerA = Console.ReadLine();
                        if (answerA == "n")
                        {
                            loop1 = false;
                            loop2 = false;
                        }
                        else if (answerA == "y") loop2 = false;
                        else
                        {
                            Console.WriteLine("invalid answer");
                            loop2 = true;
                        }
                    } while (loop2);
                }
                else
                {
                    Console.WriteLine("Not enough xp");
                    loop1 = false;
                }
            } while (loop1);
        }
        static void ChurchHeal(Character player, bool isInTown)
        {
            if (player.gold < 2) Console.WriteLine("Not enough gold!");
            else
            {
                player.gold -= 2;
                player.RenewHP();
                Console.WriteLine("Hp succesfully restored! -2 gold");
            }

        }
        static void Market(Character player)
        {
            Console.WriteLine("Here's the selection of items, their weights and prices" +
                "\nHealth potions - 1W" +
                "\nMinor[1] - restores 5hp - 1G" +
                "\nMedium[2] - restores 10hp - 3G" +
                "\nStrong[3] - restores 15hp - 5G" +
                "\nElixir of life[4] - fully restores hp - 10G" +
                "\n" +
                "\nWeapons" +
                "\nDagger[5] - 3G, 1W - increases your damage to d6" +
                "\nShortsword[6] - 6G, 2W - increases damage to 2d4 + 1 bonus damage" +
                "\nLongsword[7] - 12G, 3W - increases damage to 2d6 + 2 bonus damage " +
                "\nGreatsword[8] - 25G, 4W - increases damage to 3d6 + 3 bonus damage" +
                "\n" +
                "\nArmor" +
                "\nLeather[9] - 5G, 1W - increases evasion by 1 " +
                "\nChain[10] - 10G. 3W - increases evasion by 2" +
                "\nScale[11] - 15G. 4W - increases evasion by 3" +
                "\nPlate[12] - 25G. 6W - increases evasion by 4" +
                "\n" +
                "\nExit[13]" +
                "\n" +
                "\nWhich option would you like to select?");
            bool loop = true;
            do {
                string answerA = Console.ReadLine();
                switch (answerA)
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
                        if (player.weaponBonus > dagger.damageBonus) Console.WriteLine("You already have this or a better weapon");
                        else dagger.BuyOne(player);
                        break;
                    case "6":
                        Weapon shortsword = new Weapon(4, 1, 2, 6, 2);
                        if (player.weaponBonus >= shortsword.damageBonus) Console.WriteLine("You already have this or a better weapon");
                        else shortsword.BuyOne(player);
                        break;
                    case "7":
                        Weapon longsword = new Weapon(6, 2, 2, 12, 3);
                        if (player.weaponBonus >= longsword.damageBonus) Console.WriteLine("You already have this or a better weapon");
                        else longsword.BuyOne(player);
                        break;
                    case "8":
                        Weapon greatsword = new Weapon(6, 3, 3, 25, 4);
                        if (player.weaponBonus >= greatsword.damageBonus) Console.WriteLine("You already have this or a better weapon");
                        else greatsword.BuyOne(player);
                        break;
                    case "9":
                        Armor leather = new Armor(1, 5, 1);
                        if (player.armorBonus >= leather.armorBonus) Console.WriteLine("You already have this or better armor");
                        else leather.BuyOne(player);
                        break;
                    case "10":
                        Armor chain = new Armor(2, 10, 3);
                        if (player.armorBonus >= chain.armorBonus) Console.WriteLine("You already have this or better armor");
                        else chain.BuyOne(player);
                        break;
                    case "11":
                        Armor scale = new Armor(3, 15, 4);
                        if (player.armorBonus >= scale.armorBonus) Console.WriteLine("You already have this or better armor");
                        else scale.BuyOne(player);
                        break;
                    case "12":
                        Armor plate = new Armor(4, 25, 6);
                        if (player.armorBonus >= plate.armorBonus) Console.WriteLine("You already have this or better armor");
                        else plate.BuyOne(player);
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
        static void GenerateSheet(Character player)
        {
            Console.WriteLine("level " + player.level +
                "\nhp " + player.hp + "/" + player.vitality * 5 +
                "\nevasion " + player.evasion +
                "\nweight load " + player.weightLoad + "/" + player.weightCap +
                "\nxp " + player.xp + "/" + player.xpCap +
                "\ngold " + player.gold +
                "\nattack bonus " + player.attackBonus +
                "\ndamage bonus " + player.damageBonus +
                "\narmor bonus " + player.armorBonus +
                "\nweapon dice " + player.damageDiceAmount + "d" + player.damageDice + " + " + player.weaponBonus);
        }
    }
}
