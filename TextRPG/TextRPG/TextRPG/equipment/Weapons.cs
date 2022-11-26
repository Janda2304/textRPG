namespace TextRPG.equipment

{
    public partial class Equipment
    {
        public class Weapons
        {
            public string name;
            public float minDmg;
            public float maxDmg;
            /*crit hit chance-NYI*/
            public float luck;

            public int price;
            public bool equiped;

            public Weapons(string name, float minDmg, float maxDmg, float luck, int price, bool equiped)
            {
                this.name = name;
                this.minDmg = minDmg;
                this.maxDmg = maxDmg;
                this.luck = luck;
                this.price = price;
                this.equiped = equiped;

            }
        }
    }
} //namespace