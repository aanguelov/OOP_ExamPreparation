using System.Collections.Generic;
using System.Linq;
using WinterIsComing.Contracts;
using WinterIsComing.Core;
using WinterIsComing.Core.Exceptions;
using WinterIsComing.Models.Spells;

namespace WinterIsComing.Models.CombatHandlers
{
    public class WarriorCombatHandler : DefaultCombatHandler
    {
        private const int DefaultWarriorHealthForAddingToDamage = 80;
        private const int DefaultWarriorHealthForFreeEnergy = 50;

        public WarriorCombatHandler(IUnit unit) : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var targets = new List<IUnit>();
            var pickedTarget = candidateTargets
                .OrderBy(t => t.HealthPoints)
                .ThenBy(t => t.Name)
                .FirstOrDefault();

            if (pickedTarget != null)
            {
                targets.Add(pickedTarget);
            }
            return targets;
        }

        public override ISpell GenerateAttack()
        {
            int spellDamage = this.Unit.AttackPoints;
            if (this.Unit.HealthPoints <= DefaultWarriorHealthForAddingToDamage)
            {
                spellDamage += this.Unit.HealthPoints*2;
            }
            ISpell spell = new Cleave(spellDamage);

            if (spell.EnergyCost > this.Unit.EnergyPoints)
            {
                throw new NotEnoughEnergyException(string.Format(
                GlobalMessages.NotEnoughEnergy, this.Unit.Name, spell.GetType().Name));
            }

            if (this.Unit.HealthPoints > DefaultWarriorHealthForFreeEnergy)
            {
                this.Unit.EnergyPoints -= spell.EnergyCost;
            }

            return spell;
        }
    }
}
