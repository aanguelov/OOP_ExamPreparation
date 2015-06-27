using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    class Laser : Projectile
    {
        public Laser(int damage) 
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            if (this.Damage > ship.Shields)
            {
                int healthToBeRemoved = this.Damage - ship.Shields;
                ship.Shields = 0;
                ship.Health -= healthToBeRemoved;
            }
            else
            {
                ship.Shields -= this.Damage;
            }
        }
    }
}
