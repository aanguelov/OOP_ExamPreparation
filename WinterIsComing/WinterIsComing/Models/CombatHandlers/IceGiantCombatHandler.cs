using System.Collections.Generic;
using System.Linq;
using WinterIsComing.Contracts;
using WinterIsComing.Core;
using WinterIsComing.Core.Exceptions;
using WinterIsComing.Models.Spells;

namespace WinterIsComing.Models.CombatHandlers
{
    public class IceGiantCombatHandler : DefaultCombatHandler
    {
        private const int DefaultHealthForNumberOfTargets = 150;

        public IceGiantCombatHandler(IUnit unit) 
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var targets = new List<IUnit>();
            if (this.Unit.HealthPoints <= DefaultHealthForNumberOfTargets)
            {
                targets.Add(candidateTargets.FirstOrDefault());
            }
            else
            {
                targets = candidateTargets.ToList();
            }

            return targets;
        }

        public override ISpell GenerateAttack()
        {
            var spell = new Stomp(this.Unit.AttackPoints);
            if (spell.EnergyCost > this.Unit.EnergyPoints)
            {
                throw new NotEnoughEnergyException(string.Format(
                    GlobalMessages.NotEnoughEnergy, this.Unit.Name, spell.GetType().Name));
            }

            this.Unit.EnergyPoints -= spell.EnergyCost;
            this.Unit.AttackPoints += 5;

            return spell;
        }
    }
}
