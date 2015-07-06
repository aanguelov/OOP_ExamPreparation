using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class Mage : Unit
    {
        private const int DefaultMageAttackPoints = 80;
        private const int DefaultMageHealthPoints = 80;
        private const int DefaultMageDefensePoints = 40;
        private const int DefaultMageEnergyPoints = 120;
        private const int DefaultMageRange = 2;

        public Mage(UnitType unitType, string name, int x, int y) 
            : base(unitType, name, x, y, DefaultMageRange, DefaultMageAttackPoints, 
                    DefaultMageHealthPoints, DefaultMageDefensePoints, DefaultMageEnergyPoints)
        {
            this.CombatHandler = new MageCombatHandler(this);
        }
    }
}
