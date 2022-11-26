using System;

namespace TextRPG.equipment

{
    public partial class Equipment
    {
        public class Leggings
        {
            public string name;
            public float health;
            public float damage;
            public float defense;
            public int price;
            public bool equiped;
            /*dodge chance-NYI*/
            public float dexterity;
            /*crit hit chance-NYI*/
            public float luck;

            public Leggings(string name, int price, bool equiped, float health, float damage, float defense, float dexterity, float luck)
            {
                this.health = health;
                this.damage = damage;
                this.defense = defense;
                this.dexterity = dexterity;
                this.luck = luck;
                this.name = name;
                this.price = price;
                this.equiped = equiped;
            }

            public void PrintOutInfo()
            {
                Console.WriteLine($"Name:{name}\nPrice:{price}\n\nHealth+{health}\nDamage+{damage}\nDefense+{defense}\n");
            }

            public void PrintOutPrice()
            {
                Console.WriteLine($"{name}\nPrice:{price} Kricoins, adds +{damage} to all stats\n//////////////////////////////////////");
            }
        }

    }

} //namespace