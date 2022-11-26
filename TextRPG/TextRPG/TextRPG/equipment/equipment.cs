
namespace TextRPG.equipment

{
    public partial class Equipment
    {
        public float hp;
        public float dmg;
        public float def;
        public string name;



        public Equipment(string name, float hp, float dmg, float def)
        {
            this.name = name;
            this.hp = hp;
            this.dmg = dmg;
            this.def = def;


        }
    }
} //namespace