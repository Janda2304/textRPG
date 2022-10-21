using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace textRPG
{
    class Program
    {



        static void Main(string[] args)
        {
            //rat declaration
            rat ratLevel1 = new rat("rat level 1", 15, 2, 0, 0);
            rat ratLevel2 = new rat("rat level 2", 25, 3, 1, 0);
            rat eliteRat = new rat("elite rat", 50, 5, 2, 0);
            rat bossRat = new rat("rat king", 100, 10, 5, 0);
            ratLevel1.maxHealth = ratLevel1.health;
            ratLevel2.maxHealth = ratLevel2.health;
            eliteRat.maxHealth = eliteRat.health;
            bossRat.maxHealth = bossRat.health;
            //
           

            int menuChoices = 0;
            int difficulty = 0;
            int battle = 0;
            bool end = false;
            bool difficultyChoice = false;
            bool battleChoice = false;
            int battleActionChoice = 0;
            bool isBattleActive = true;
            int ratBattle = 0;
            float defenseFormula = 0;
            Random defenseFormulaRandomizer = new Random();
            Random dmgRnd = new Random();
            //player declaration
            player Player1 = new player(50, 5, 2.5f, 0, 0);
            Player1.maxHealth = Player1.health;
            //
            //string declarations
            string blockingMessage = $"blocking temporarily increased your defense by 10\nyour defense:{Player1.defense+10}";

            Console.WriteLine("Hello Welcome to textRPG\nWhat do you want to do?");

            while (end == false)
            {

                if (Player1.health == 0)
                {
                    Console.Clear();
                    Console.WriteLine("you died, better luck next time\npress escape to exit the game");
                    Console.ReadKey();
                    Thread.Sleep(500);
                    Environment.Exit(0);
                }

                Console.WriteLine("\n\n1:choose game difficulty\n2:battle\n3:show player info\n4:enter shop\n5:sleep(regenerate hp)\n6:exit textRPG");
                try
                {
                    menuChoices = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("error please try again");

                }
                //menu choices switch
                switch (menuChoices)
                {
                    case 1:
                        //difficulty choice
                        difficultyChoice = false;
                        while (difficultyChoice == false)
                        {
                            Console.Clear();
                            Console.WriteLine($"1:Easy\n2:Medium\n3:Hard\n4:back to main menu");
                            try
                            {
                                difficulty = int.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                //error print out
                                Console.Clear();
                                Console.WriteLine("error please try again");

                            }
                            //difficulty switch
                            switch (difficulty)
                            {
                                case 1:
                                    Player1.health = 50;
                                    Player1.damage = 5;
                                    Player1.defense = 2.5f;
                                    Player1.maxHealth = Player1.health;
                                    Console.Clear();
                                    Console.WriteLine($"Difficulty = easy\nHealth = {Player1.health}\nDamage = {Player1.damage}\nDefense = {Player1.defense}");
                                    difficultyChoice = true;
                                    break;
                                case 2:
                                    Player1.health = 30;
                                    Player1.damage = 3;
                                    Player1.defense = 1.5f;
                                    Player1.maxHealth = Player1.health;
                                    Console.Clear();
                                    Console.WriteLine($"Difficulty = medium\nHealth = {Player1.health}\nDamage = {Player1.damage}\nDefense = {Player1.defense}");
                                    difficultyChoice = true;
                                    break;
                                case 3:
                                    Player1.health = 15;
                                    Player1.damage = 2;
                                    Player1.defense = 0.5f;
                                    Player1.maxHealth = Player1.health;
                                    Console.Clear();
                                    Console.WriteLine($"Difficulty = hard\nHealth = {Player1.health}\nDamage = {Player1.damage}\nDefense = {Player1.defense}");
                                    difficultyChoice = true;
                                    break;
                                case 4:
                                    Console.Clear();
                                    difficultyChoice = true;
                                    break;
                                default:
                                    Console.WriteLine("error difficulty not found");
                                    Thread.Sleep(2000);
                                    break;
                            }
                        }

                        break;
                    case 2:
                        battleChoice = false;
                        while (battleChoice == false)
                        {
                            Console.Clear();
                            Console.WriteLine("1:rats\n2:wolfs\n3:bears\n4:back to main menu");
                            battle = int.Parse(Console.ReadLine());
                            switch (battle)
                            {
                                case 1:
                                    Console.Clear();
                                    ratLevel1.printOutInfo();
                                    ratLevel2.printOutInfo();
                                    eliteRat.printOutInfo();
                                    bossRat.printOutInfo();
                                    Console.WriteLine("1:rat level 1\n2:rat level 2\n3:elite rat\n4:Rat King\n5: exit to main menu");
                                    ratBattle = int.Parse(Console.ReadLine());
                                    switch (ratBattle)
                                    {
                                        case 1:
                                            while (isBattleActive == true)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("what do you want to do:\n1:attack\n2:block");
                                                battleActionChoice = int.Parse(Console.ReadLine());
                                                switch (battleActionChoice)
                                                {
                                                    case 1:
                                                        //player hit calculation
                                                        Console.Clear();
                                                        Player1.damage = dmgRnd.Next(1, Player1.damage);
                                                        defenseFormula = defenseFormulaRandomizer.Next(0, Convert.ToInt32(ratLevel1.defense));
                                                        ratLevel1.health -= Player1.damage - defenseFormula;
                                                        Console.WriteLine($"You dealt {Player1.damage - defenseFormula} damage");
                                                        Console.WriteLine($"Rat have {ratLevel1.health}/{ratLevel1.maxHealth} health left\npress enter to continue");
                                                        Console.ReadLine();
                                                        //
                                                        //enemy hit calculation
                                                        ratLevel1.damage = dmgRnd.Next(1, ratLevel1.damage);
                                                        defenseFormula = defenseFormulaRandomizer.Next(0, Convert.ToInt32(Player1.defense));
                                                        if (ratLevel1.damage - defenseFormula < 0)
                                                        {
                                                            ratLevel1.damage = 0;
                                                            defenseFormula = 0;
                                                        }
                                                        Player1.health -= ratLevel1.damage - defenseFormula;
                                                        Console.WriteLine($"Rat level 1 dealt {ratLevel1.damage - defenseFormula} damage");
                                                        Console.WriteLine($"you have {Player1.health}/{Player1.maxHealth} health left\npress enter to continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 2:
                                                        Console.Clear();
                                                        Player1.defense += 10;
                                                        Console.WriteLine(blockingMessage);
                                                        Console.ReadLine();
                                                        //enemy hit calculation
                                                        
                                                        ratLevel1.damage = dmgRnd.Next(1, ratLevel1.damage);
                                                        defenseFormula = defenseFormulaRandomizer.Next(0, Convert.ToInt32(Player1.defense));
                                                        if (ratLevel1.damage - defenseFormula < 0)
                                                        {
                                                            ratLevel1.damage = 0;
                                                            defenseFormula = 0;
                                                        }
                                                        Player1.health -= ratLevel1.damage - defenseFormula;
                                                        Console.WriteLine($"Rat level 1 dealt {ratLevel1.damage - defenseFormula} damage");
                                                        Console.WriteLine($"you have {Player1.health}/{Player1.maxHealth} health left\npress enter to continue");
                                                        Console.ReadLine();                                                      
                                                        break;
                                                    default:
                                                        Console.WriteLine("error, action not found");
                                                        Thread.Sleep(500);
                                                        Console.Clear();
                                                        battleChoice = true;

                                                        break;
                                                }
                                                if (ratLevel1.health == 0)
                                                {
                                                    Player1.exp += 10;
                                                    Console.Clear();
                                                    Console.WriteLine("Rat level 1 died, Congratulations!");
                                                    Console.WriteLine($"You've gained 10 exp and 5 Kricoins\nYou now have {Player1.exp} exp and Player1.coins Kricoins\npress enter to continue");
                                                    Console.ReadLine();
                                                    isBattleActive = false;
                                                }

                                            }

                                            break;
                                        case 2:
                                            break;
                                        case 3:
                                            break;
                                        case 4:
                                            break;
                                        case 5:
                                            Console.Clear();
                                            battleChoice = true;
                                            break;
                                        default:
                                            Console.Clear();
                                            Console.WriteLine("error enemy type not found");
                                            battleChoice = true;
                                            break;


                                    }


                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Error enemy not found");
                                    Thread.Sleep(1500);
                                    break;
                                case 4:
                                    battleChoice = true;
                                    Console.Clear();
                                    break;
                            }
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Player1.printOutInfo();
                        break;

                    case 6:
                        Thread.Sleep(1000);
                        end = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("error please try again");
                        break;

                }
            }

        }

    }
}
    class rat
    {
        public string name;
        public float health;
        public int damage;
        public float defense;
        public float maxHealth;

        public rat(string name, float health, int damage, float defense, float maxHealth)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.defense = defense;
            this.maxHealth = maxHealth;

        }
        public void printOutInfo()
        {
            Console.WriteLine($"name:{name}\nHealth={health}/{maxHealth}\nDamage={damage}\nDefense={defense}\n ");
        }
        


    }

    class player
    {
        public float health;
        public int damage;
        public float defense;
        public float maxHealth;
        public int exp;
        /*dodge chance-NYI*/
        public float dexterity;
        /*crit hit chance-NYI*/public float luck;


        public player(float health, int damage, float defense, float maxHealth, int exp)
        {
            this.health = health;
            this.damage = damage;
            this.defense = defense;
            this.maxHealth = maxHealth;
            this.exp = exp;
        }

        public void printOutInfo()
        {
            Console.WriteLine($"Health={health}/{maxHealth}\nDamage={damage}\nDefense={defense}\n");
        }



    }

   



