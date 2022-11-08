using System;

namespace textRPG.enemies
{
    public class Wolf
    {
        public string name;
        public float health;
        public int damage;
        public float defense;
        public float maxHealth;

        public Wolf(string name, float health, int damage, float defense, float maxHealth)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.defense = defense;
            this.maxHealth = maxHealth;

        }
        public void PrintOutInfo()
        {
            Console.WriteLine($"name:{name}\nHealth={health}/{maxHealth}\nDamage={damage}\nDefense={defense}\n ");
        }


    }

} //namespace