using System;
using System.Text;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Units
{
    public abstract class Unit : IUnit
    {
        private string name;
        private int range;

        protected Unit(UnitType unitType, string name, int x, int y, int range, int attackPoints, int healthPoints, 
                        int defensePoints, int energyPoints)
        {
            this.UnitType = unitType;
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Range = range;
            this.AttackPoints = attackPoints;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
            this.EnergyPoints = energyPoints;
        }

        public UnitType UnitType { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null, empty or whitespace");
                }
                this.name = value;
            }
        }

        public int Range
        {
            get { return this.range; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Range must be positive");
                }
                this.range = value;
            }
        }

        public int AttackPoints { get; set; }

        public int HealthPoints { get; set; }

        public int DefensePoints { get; set; }

        public int EnergyPoints { get; set; }

        public ICombatHandler CombatHandler { get; protected set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format(">{0} - {1} at ({2},{3})", this.Name, this.UnitType, this.X, this.Y));

            if (this.HealthPoints > 0)
            {
                output.AppendLine(string.Format("-Health points = {0}", this.HealthPoints))
                    .AppendLine(string.Format("-Attack points = {0}", this.AttackPoints))
                    .AppendLine(string.Format("-Defense points = {0}", this.DefensePoints))
                    .AppendLine(string.Format("-Energy points = {0}", this.EnergyPoints))
                    .Append(string.Format("-Range = {0}", this.Range));
            }
            else
            {
                output.Append("(Dead)");
            }

            return output.ToString();
        }
    }
}
