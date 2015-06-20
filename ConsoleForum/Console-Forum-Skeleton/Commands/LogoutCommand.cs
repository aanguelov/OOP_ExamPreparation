using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    public class LogoutCommand : AbstractCommand
    {
        public LogoutCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            //this.Forum.CurrentQuestion = null;
            if (this.Forum.IsLogged)
            {
                this.Forum.Output.AppendLine(Messages.LogoutSuccess);
                this.Forum.CurrentUser = null;
            }
            else
            {
                this.Forum.Output.AppendLine(Messages.NotLogged);
            }
            this.Forum.CurrentQuestion = null;
        }
    }
}
