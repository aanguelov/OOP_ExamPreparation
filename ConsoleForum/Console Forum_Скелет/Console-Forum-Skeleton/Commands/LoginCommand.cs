using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleForum.Contracts;
using ConsoleForum.Utility;

namespace ConsoleForum.Commands
{
    public class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            if (this.Forum.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            List<string> usernames = users.Select(u => u.Username).ToList();
            List<string> passList = users.Select(u => u.Password).ToList();
            if (!usernames.Contains(username) || !passList.Contains(password))
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }

            this.Forum.CurrentUser = users.FirstOrDefault(u => u.Username == username);
            this.Forum.Output.AppendLine(String.Format(Messages.LoginSuccess, username));
        }
    }
}
