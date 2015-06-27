using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended
{
    public class AncientBehemoth : Creature
    {
        private const int DefaultAncientBehemothAttack = 19;
        private const int DefaultAncientBehemothDefense = 19;
        private const int DefaultAncientBehemothHealthPoints = 300;
        private const decimal DefaultAncientBehemothDamage = 40;
        private const int AncientBehemothEnemyDefenseReductionPercentage = 80;
        private const int ABehemotDoubleDefenseWhenDefendingRounds = 5;

        public AncientBehemoth() 
            : base(DefaultAncientBehemothAttack, DefaultAncientBehemothDefense, 
                    DefaultAncientBehemothHealthPoints, DefaultAncientBehemothDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(AncientBehemothEnemyDefenseReductionPercentage));
            this.AddSpecialty(new DoubleDefenseWhenDefending(ABehemotDoubleDefenseWhenDefendingRounds));

        }
    }
}
