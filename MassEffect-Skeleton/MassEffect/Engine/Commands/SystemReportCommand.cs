using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassEffect.Interfaces;

namespace MassEffect.Engine.Commands
{
    class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string locationFromCommand = commandArgs[1];
            IEnumerable<IStarship> intactShips = null;
            intactShips = this.GameEngine.Starships
                .Where(s => s.Location.Name == locationFromCommand)
                .Where(s => s.Health > 0)
                .OrderByDescending(s => s.Health)
                .ThenByDescending(s => s.Shields);

            StringBuilder output = new StringBuilder();
            output.AppendLine("Intact ships:");
            output.AppendLine(intactShips.Any() ? String.Join("\n", intactShips) : "N/A");

            IEnumerable<IStarship> destroyedShips = null;
            destroyedShips = this.GameEngine.Starships
                .Where(s => s.Location.Name == locationFromCommand)
                .Where(s => s.Health == 0)
                .OrderBy(s => s.Name);

            output.AppendLine("Destroyed ships:");
            output.AppendLine(destroyedShips.Any() ? String.Join("\n", destroyedShips) : "N/A");

            Console.WriteLine(output.ToString().TrimEnd());
        }
    }
}
