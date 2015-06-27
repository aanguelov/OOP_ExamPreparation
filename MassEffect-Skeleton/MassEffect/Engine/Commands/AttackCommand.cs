using System;
using System.Linq;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string attackerName = commandArgs[1];
            string targetName = commandArgs[2];

            IStarship attackingShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == attackerName);
            IStarship targetShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == targetName);

            this.ProcessStarshipBattle(attackingShip, targetShip);
        }

        private void ProcessStarshipBattle(IStarship attacker, IStarship toBeAttacked)
        {
            base.ValidateAlive(attacker);
            base.ValidateAlive(toBeAttacked);

            base.ValidateSameStarsystem(attacker, toBeAttacked);

            IProjectile attack = attacker.ProduceAttack();
            toBeAttacked.RespondToAttack(attack);

            Console.WriteLine(Messages.ShipAttacked, attacker.Name, toBeAttacked.Name);

            if (toBeAttacked.Shields < 0)
            {
                toBeAttacked.Shields = 0;
            }

            if (toBeAttacked.Health <= 0)
            {
                toBeAttacked.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, toBeAttacked.Name);
            }
        }
    }
}
