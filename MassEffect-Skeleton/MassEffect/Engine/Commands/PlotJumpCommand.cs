using System;
using System.Linq;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Locations;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipFromCommand = commandArgs[1];
            string destinationFromCommand = commandArgs[2];

            IStarship ship = null;
            ship = this.GameEngine.Starships.FirstOrDefault(s => s.Name == shipFromCommand);
            base.ValidateAlive(ship);

            var previousLocation = ship.Location;
            StarSystem destination = this.GameEngine.Galaxy.GetStarSystemByName(destinationFromCommand);

            if (previousLocation.Name == destinationFromCommand)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, destinationFromCommand));
            }

            this.GameEngine.Galaxy.TravelTo(ship, destination);
            Console.WriteLine(Messages.ShipTraveled, shipFromCommand, previousLocation.Name, destinationFromCommand);
        }
    }
}
