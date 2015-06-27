using MassEffect.Engine.Commands;

namespace MassEffect.Engine
{
    class ExtendCommandManager : CommandManager
    {
        public override void SeedCommands()
        {
            base.SeedCommands();
            //this.commandsByName["system-report"] = new SystemReportCommand(this.Engine);
            this.commandsByName.Add("system-report", new SystemReportCommand(this.Engine));
        }
    }
}
