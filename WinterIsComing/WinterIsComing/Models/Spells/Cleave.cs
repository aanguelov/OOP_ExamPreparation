namespace WinterIsComing.Models.Spells
{
    public class Cleave : Spell
    {
        private const int DefaultCleaveEnergyCost = 15;

        public Cleave(int damage) 
            : base(damage, DefaultCleaveEnergyCost)
        {
        }
    }
}
