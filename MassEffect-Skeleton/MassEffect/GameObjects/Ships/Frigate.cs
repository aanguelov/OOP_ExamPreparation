using System.Text;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    class Frigate : Starship
    {
        //private new const int Health = 60;
        //private new const int Shields = 50;
        //private new const int Damage = 30;
        //private new const double Fuel = 220;
        //private int projectilesFired;

        public Frigate(string name, StarSystem location) 
            : base(name, 60, 50, 30, 220, location)
        {
        }

        public int ProjectilesFired { get; set; }

        //public new int Health { get; set; }

        public override IProjectile ProduceAttack()
        {
            ProjectilesFired++;
            return new ShieldReaver(this.Damage);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (this.Health > 0)
            {
                sb.AppendLine(string.Format("-Projectiles fired: {0}", this.ProjectilesFired));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
