namespace WinterIsComing.Models.Spells
{
    public class Blizzard : Spell
    {
        private const int DefaultBlizzardEnergyCost = 40;

        public Blizzard(int damage) 
            : base(damage, DefaultBlizzardEnergyCost)
        {
        }
    }
}
