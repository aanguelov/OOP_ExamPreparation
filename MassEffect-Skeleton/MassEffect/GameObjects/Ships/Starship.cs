using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public abstract class Starship : IStarship
    {
        private IList<Enhancement> enhancements; 

        protected Starship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();
        }

        public virtual IEnumerable<Enhancement> Enhancements
        {
            get { return this.enhancements; }
        }

        public void AddEnhancement(Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("Enhancement cannot be null!");
            }
            this.enhancements.Add(enhancement);

            this.Damage += enhancement.DamageBonus;
            this.Shields += enhancement.ShieldBonus;
            this.Fuel += enhancement.FuelBonus;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Shields { get; set; }
        public int Damage { get; set; }
        public double Fuel { get; set; }
        public StarSystem Location { get; set; }

        public abstract IProjectile ProduceAttack();

        public virtual void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));

            if (this.Health <= 0)
            {
                sb.Append("(Destroyed)");
            }
            else
            {
                sb.AppendLine(string.Format("-Location: {0}", this.Location.Name));
                sb.AppendLine(string.Format("-Health: {0}", this.Health));
                sb.AppendLine(string.Format("-Shields: {0}", this.Shields));
                sb.AppendLine(string.Format("-Damage: {0}", this.Damage));
                sb.AppendLine(string.Format("-Fuel: {0:F1}", this.Fuel));
                sb.Append(string.Format("-Enhancements: {0}", 
                    this.Enhancements.Any() ? string.Join(", ", this.Enhancements) : "N/A"));
            }
            return sb.ToString();
        }
    }
}
