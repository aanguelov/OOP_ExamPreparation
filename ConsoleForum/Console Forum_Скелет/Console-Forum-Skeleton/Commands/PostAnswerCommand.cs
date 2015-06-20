﻿using System;
using System.Linq;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            var answers = this.Forum.CurrentQuestion.Answers;
            string body = this.Data[1];

            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            Answer answer = new Answer(answers.Count + 1, body, this.Forum.CurrentUser);
            answers.Add(answer);
            //this.Forum.CurrentQuestion = null;
            this.Forum.Output.AppendLine(String.Format(Messages.PostAnswerSuccess, answers.Last().Id));
        }
    }
}
