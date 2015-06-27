using System;
using System.Globalization;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class DoubleDamage : Specialty
    {
        private int effectiveRounds;

        public DoubleDamage(int effectiveRounds)
        {
            this.EffectiveRounds = effectiveRounds;
        }

        public int EffectiveRounds
        {
            get { return this.effectiveRounds; }
            set
            {
                if (value <= 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("Rounds must be between 0 and 10");
                }
                this.effectiveRounds = value;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            //if (attackerWithSpecialty == null)
            //{
            //    throw new ArgumentNullException("defenderWithSpecialty");
            //}

            //if (defender == null)
            //{
            //    throw new ArgumentNullException("attacker");
            //}

            //if (this.EffectiveRounds <= 0 || this.EffectiveRounds > 10)
            //{
            //    return;
            //}
            //attackerWithSpecialty.CurrentAttack *= 2;
            //this.effectiveRounds--;
        }

        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {
            
        }

        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
            
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            
        }

        public override decimal ChangeDamageWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty, 
            ICreaturesInBattle defender,
            decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.EffectiveRounds <= 0)
            {
                return currentDamage;
            }
            this.effectiveRounds--;
            return currentDamage*2;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.EffectiveRounds);
        }
    }
}
