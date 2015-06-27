using ArmyOfCreatures.Extended.Specialties;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class WolfRaider : Creature
    {
        private const int DefaultWolfRaiderAttack = 8;
        private const int DefaultWolfRaiderDefense = 5;
        private const int DefaultWolfRaiderHealthPoints = 10;
        private const decimal DefaultWolfRaiderDamage = 3.5m;
        private const int WolfRaiderDoubleDamageWhenAttackingRounds = 7;

        public WolfRaider() 
            : base(DefaultWolfRaiderAttack, DefaultWolfRaiderDefense, DefaultWolfRaiderHealthPoints, DefaultWolfRaiderDamage)
        {
            this.AddSpecialty(new DoubleDamage(WolfRaiderDoubleDamageWhenAttackingRounds));
        }
    }
}
