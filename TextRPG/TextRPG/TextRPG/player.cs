using System;

namespace textRPG
{


    public class Player
    {
        public float health;
        public float minDmg;
        public float maxDmg;
        public float defense;
        public float maxHealth;
        public int exp;
        public int coins;
        public int level;

        /*dodge chance-NYI*/
       
        public float dex;
        public string gameDifficulty;

        /*critical hit chance-NYI*/
        public float lck;
        public float minLck;



        public Player(string gameDifficulty, float health, float minDmg, float maxDmg, float defense, float maxHealth, float dex, float lck, int exp, int coins, int level)
        {
            this.health = health;
            this.minDmg = minDmg;
            this.maxDmg = maxDmg;
            this.defense = defense;
            this.maxHealth = maxHealth;
            this.exp = exp;
            this.coins = coins;
            this.level = level;
            this.dex = dex;
            this.lck = lck;



        }




        public void DifficultyFunction()
        {
            #region difficulties

            switch (gameDifficulty)
            {
                case "easy":
                    maxHealth = 50;
                    minDmg = 2;
                    maxDmg = 5;
                    defense = 2.5f;
                    break;
                case "medium":

                    maxHealth = 30;
                    if (health > 30)
                    {
                        health = 30;
                    }
                    minDmg = 1;
                    maxDmg = 3;
                    defense = 1.5f;
                    break;

                case "hard":

                    maxHealth = 15;
                    if (health > 15)
                    {
                        health = 15;
                    }
                    minDmg = 0;
                    maxDmg = 2;
                    defense = 0.5f;
                    break;

            }

            Console.Clear();
            Console.WriteLine($"Difficulty = {gameDifficulty}\nHealth = {maxHealth}\nDamage = {minDmg}-{maxDmg}\nDefense = {defense}");
            #endregion difficulties
        }

    }
}






