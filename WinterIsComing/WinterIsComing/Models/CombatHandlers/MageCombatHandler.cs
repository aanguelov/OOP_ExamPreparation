using System.Collections.Generic;
using System.Linq;
using WinterIsComing.Contracts;
using WinterIsComing.Core;
using WinterIsComing.Core.Exceptions;
using WinterIsComing.Models.Spells;

namespace WinterIsComing.Models.CombatHandlers
{
    public class MageCombatHandler : DefaultCombatHandler
    {
        private static int defaultSpellCounter = 0;

        public MageCombatHandler(IUnit unit) 
            : base(unit)
        {
            this.Counter = defaultSpellCounter;
            this.HasCast = true;
        }

        public int Counter { get; set; }

        public bool HasCast { get; set; }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var targets = new List<IUnit>();
            var orderedEnemies = candidateTargets
                .OrderByDescending(t => t.HealthPoints)
                .ThenBy(t => t.Name).ToArray();
            for (int i = 0; i < orderedEnemies.Count(); i++)
            {
                var currentTarget = orderedEnemies[i];
                targets.Add(currentTarget);
                if (i == 2)
                {
                    break;
                }
            }
            return targets;
        }

        public override ISpell GenerateAttack()
        {
            //bool hasCast;
            ISpell spell;
            if (this.Counter % 2 == 0)
            {
                spell = new FireBreath(this.Unit.AttackPoints);
            }
            else
            {
                spell = new Blizzard(this.Unit.AttackPoints*2);
            }
            int neededEnergy = spell.EnergyCost;
            if (neededEnergy > this.Unit.EnergyPoints)
            {
                this.HasCast = false;
                throw new NotEnoughEnergyException(string.Format(
                    GlobalMessages.NotEnoughEnergy, this.Unit.Name, spell.GetType().Name));
            }

            if (this.HasCast)
            {
                this.Counter++;
                this.Unit.EnergyPoints -= spell.EnergyCost;
                defaultSpellCounter += this.Counter;
            }

            return spell;
        }
    }
}
