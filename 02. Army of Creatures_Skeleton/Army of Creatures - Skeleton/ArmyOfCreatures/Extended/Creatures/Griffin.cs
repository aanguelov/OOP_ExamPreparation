using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Griffin : Creature
    {
        private const int DefaultGriffinAttack = 8;
        private const int DefaultGriffinDefense = 8;
        private const int DefaultGriffinHealthPoints = 25;
        private const decimal DefaultGriffinDamage = 4.5m;
        private const int GriffinDoubleDefenseWhenDefendingRounds = 5;
        private const int GriffinAddDefenceWhenSkipPoints = 3;

        public Griffin() 
            : base(DefaultGriffinAttack, DefaultGriffinDefense, DefaultGriffinHealthPoints, DefaultGriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(GriffinDoubleDefenseWhenDefendingRounds));
            this.AddSpecialty(new AddDefenseWhenSkip(GriffinAddDefenceWhenSkipPoints));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
