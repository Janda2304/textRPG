using System;
namespace textRPG.enemies
{


    public class Rat
    {
        public string name;
        public float health;
        public float maxHealth;
        public float defense;
        public float minDmg;
        public float maxDmg;
        public int coinGain;
        public int xpGain;
        

        public Rat(string name, float health, float maxHealth, float minDmg, float maxDmg, float defense, int coinGain, int xpGain)
        {
            this.name = name;
            this.health = health;
            this.minDmg = minDmg;
            this.maxDmg = maxDmg;
            this.defense = defense;
            this.maxHealth = maxHealth;
            this.coinGain = coinGain;
            this.xpGain = xpGain;

        }
        public void PrintOutInfo()
        {
            Console.WriteLine($"type:{name}\nHealth:{maxHealth}\nDamage:{minDmg}-{maxDmg}\nDefense:{defense}\n");
        }



    }

}



