using System.Collections.Generic;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.CombatHandlers
{
    public abstract class DefaultCombatHandler : ICombatHandler
    {
        protected DefaultCombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit { get; set; }

        public abstract IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);

        public abstract ISpell GenerateAttack();
    }
}
