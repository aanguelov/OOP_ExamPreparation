using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;
using ConsoleForum.Entities.Users;

namespace ConsoleForum.Commands
{
    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            //var answers = this.Forum.CurrentQuestion.Answers;
            int id = Convert.ToInt32(this.Data[1]);

            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            List<int> idList = this.Forum.CurrentQuestion.Answers.Select(a => a.Id).ToList();
            if (!idList.Contains(id))
            {
                throw new CommandException(Messages.NoAnswer);
            }

            if (this.Forum.CurrentQuestion.Author != this.Forum.CurrentUser && 
                    this.Forum.CurrentUser.GetType() != typeof(Administrator))
            {
                throw new CommandException(Messages.NoPermission);
            }

            var answers = this.Forum.CurrentQuestion.Answers;
            Answer answer = answers.FirstOrDefault(a => a.Id == id) as Answer;
            BestAnswer bestAnswer = new BestAnswer(answer.Id, answer.Body, answer.Author);
            answers.Remove(answer);
            answers.Add(bestAnswer);

            this.Forum.Output.AppendLine(string.Format(Messages.BestAnswerSuccess, id));
        }
    }
}
