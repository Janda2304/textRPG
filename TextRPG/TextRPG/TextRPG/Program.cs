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
            int menuChoices = 0;
            int difficulty = 0;
            bool end = false;
            //definition of player
            player Player1 = new player(50, 5, 2.5f);


            Console.WriteLine("Hello Welcome to textRPG\nWhat do you want to do?");

            while (end == false)
            {
               
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
                        Console.Clear();
                        Console.WriteLine($"1:Easy\n2:Medium\n3:Hard\n");
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
                                Console.Clear();
                                Console.WriteLine($"Difficulty = easy\nHealth = {Player1.health}\nDamage = {Player1.damage}\nDefense = {Player1.defense}");
                                break;
                            case 2:
                                Player1.health = 30;
                                Player1.damage = 3.5f;
                                Player1.defense = 1.25f;
                                Console.Clear();
                                Console.WriteLine($"Difficulty = medium\nHealth = {Player1.health}\nDamage = {Player1.damage}\nDefense = {Player1.defense}");
                                break;
                            case 3:
                                Player1.health = 15;
                                Player1.damage = 2.5f;
                                Player1.defense = 0.5f;
                                Console.Clear();
                                Console.WriteLine($"Difficulty = hard\nHealth = {Player1.health}\nDamage = {Player1.damage}\nDefense = {Player1.defense}");
                                break;
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
         
           










            //rat definitions
            rat ratLevel1 = new rat("rat level 1", 15, 2, 0);
            rat ratLevel2 = new rat("rat level 2", 25, 3, 1);
            rat eliteRat = new rat("elite rat", 50, 5, 2);
            rat bossRat = new rat("rat king", 100, 10, 5);

        }
    }
    class rat
    {
        public string name;
        public int health;
        public int damage;
        public int defense;

        public rat(string name, int health, int damage, int defense)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.defense = defense;

        }
        public void printOutInfo()
        {
            Console.WriteLine($"name={name}\nHealth={health}\nDamage={damage}\nDefense={defense}\n ");
        }
        


    }

    class player
    {
        public float health;
        public float damage;
        public float defense;
        /*dodge chance-NYI*/public float dexterity;
        /*crit hit chance-NYI*/public float luck;


        public player(float health, float damage, float defense)
        {
            this.health = health;
            this.damage = damage;
            this.defense = defense;
        }

        public void printOutInfo()
        {
            Console.WriteLine($"Health={health}\nDamage={damage}\nDefense={defense}\n");
        }



    }


}
