namespace TextRPG.equipment
{
    public partial class Equipment
    {

        public class WeaponEquipment
        {
            public float minDmg;
            public float maxDmg;

            public WeaponEquipment(float minDmg, float maxDmg)
            {
                this.minDmg = minDmg;
                this.maxDmg = maxDmg;
            }
        }

    }
}