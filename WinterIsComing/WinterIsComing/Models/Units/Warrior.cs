using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class Warrior : Unit
    {
        private const int DefaultWarriorAttackPoints = 120;
        private const int DefaultWarriorHealthPoints = 180;
        private const int DefaultWarriorDefensePoints = 70;
        private const int DefaultWarriorEnergyPoints = 60;
        private const int DefaultWarriorRange = 1;

        public Warrior(UnitType unitType, string name, int x, int y) 
            : base(unitType, name, x, y, DefaultWarriorRange, DefaultWarriorAttackPoints,
                    DefaultWarriorHealthPoints, DefaultWarriorDefensePoints, DefaultWarriorEnergyPoints)
        {
            this.CombatHandler = new WarriorCombatHandler(this);
        }

    }
}
