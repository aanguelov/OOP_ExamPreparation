namespace WinterIsComing.Models.Spells
{
    public class Stomp : Spell
    {
        private const int DefaultStompEnergyCost = 10;

        public Stomp(int damage) 
            : base(damage, DefaultStompEnergyCost)
        {
        }
    }
}
