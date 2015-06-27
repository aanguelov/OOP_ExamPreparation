using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    class Dreadnought : Starship
    {
        private const int DefaultHealth = 200;
        private const int DefaultShields = 300;
        private const int DefaultDamage = 150;
        private const double DefaultFuel = 700;

        public Dreadnought(string name, StarSystem location) 
            : base(name, DefaultHealth, DefaultShields, DefaultDamage, DefaultFuel, location)
        {

        }

        public override IProjectile ProduceAttack()
        {
            return new Laser(this.Damage + this.Shields/2);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;
            base.RespondToAttack(attack);
            this.Shields -= 50;
        }
    }
}
