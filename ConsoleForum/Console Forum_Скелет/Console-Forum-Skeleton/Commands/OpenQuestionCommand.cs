using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            int id = Convert.ToInt32(this.Data[1]);

            List<int> idList = this.Forum.Questions.Select(q => q.Id).ToList();
            if (!idList.Contains(id))
            {
                throw new CommandException(Messages.NoQuestion);
            }
            else
            {
                IQuestion currentQuestion = this.Forum.Questions.FirstOrDefault(q => q.Id == id);
                this.Forum.Output.AppendLine(string.Format("[ Question ID: {0} ]", currentQuestion.Id));
                this.Forum.Output.AppendLine(string.Format("Posted by: {0}", currentQuestion.Author.Username));
                this.Forum.Output.AppendLine(string.Format("Question Title: {0}", currentQuestion.Title));
                this.Forum.Output.AppendLine(string.Format("Question Body: {0}", currentQuestion.Body));
                this.Forum.Output.AppendLine(new string('=', 20));
                if (currentQuestion.Answers.Count == 0)
                {
                    this.Forum.Output.AppendLine("No answers");
                }
                else
                {
                    this.Forum.Output.AppendLine("Answers:");
                    if (currentQuestion.Answers.Any(a => a.GetType() == typeof(BestAnswer)))
                    {
                        IAnswer bestAnswer =
                            currentQuestion.Answers.FirstOrDefault(a => a.GetType() == typeof (BestAnswer));
                        this.Forum.Output.AppendLine(new string('*', 20));
                        this.Forum.Output.AppendLine(string.Format("[ Answer ID: {0} ]", bestAnswer.Id));
                        this.Forum.Output.AppendLine(string.Format("Posted by: {0}", bestAnswer.Author.Username));
                        this.Forum.Output.AppendLine(string.Format("Answer Body: {0}", bestAnswer.Body));
                        this.Forum.Output.AppendLine(new string('-', 20));
                        this.Forum.Output.AppendLine(new string('*', 20));
                    }

                    var plainAnswers = currentQuestion.Answers
                        .Where(a => a is Answer)
                        .OrderBy(a => a.Id);
                    foreach (var answer in plainAnswers)
                    {
                        this.Forum.Output.AppendLine(string.Format("[ Answer ID: {0} ]", answer.Id));
                        this.Forum.Output.AppendLine(string.Format("Posted by: {0}", answer.Author.Username));
                        this.Forum.Output.AppendLine(string.Format("Answer Body: {0}", answer.Body));
                        this.Forum.Output.AppendLine(new string('-', 20));
                    }
                }
                this.Forum.CurrentQuestion = currentQuestion;
            }
            
        }
    }
}
