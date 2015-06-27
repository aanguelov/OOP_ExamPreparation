using System;
using System.Linq;
using MassEffect.Engine.Factories;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Ships;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string typeOfShipToBeCreated = commandArgs[1];
            string shipName = commandArgs[2];
            string locationOfShip = commandArgs[3];

            bool shipAlreadyExists = this.GameEngine.Starships
                .Any(s => s.Name == shipName);

            if (shipAlreadyExists)
            {
                throw new ShipException(Messages.DuplicateShipName);
            }

            var location = this.GameEngine.Galaxy.GetStarSystemByName(locationOfShip);
            StarshipType shipType = (StarshipType) Enum.Parse(typeof (StarshipType), typeOfShipToBeCreated);

            IStarship createdShip = this.GameEngine.ShipFactory.CreateShip(shipType, shipName, location);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                var enhancementType = (EnhancementType)Enum.Parse(typeof (EnhancementType), commandArgs[i]);

                Enhancement enhancement = null;
                enhancement = this.GameEngine.EnhancementFactory.Create(enhancementType);
                createdShip.AddEnhancement(enhancement);
            }

            GameEngine.Starships.Add(createdShip);

            Console.WriteLine(Messages.CreatedShip, shipType, shipName);
        }
    }
}
