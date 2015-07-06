namespace WinterIsComing.Models.Spells
{
    public class FireBreath : Spell
    {
        private const int DefaultFireBreathEnergyCost = 30;

        public FireBreath(int damage) 
            : base(damage, DefaultFireBreathEnergyCost)
        {
        }
    }
}
