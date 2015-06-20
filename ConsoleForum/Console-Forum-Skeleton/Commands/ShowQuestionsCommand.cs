using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            //this.Forum.CurrentQuestion = null;
            if (this.Forum.Questions.Count == 0)
            {
                this.Forum.Output.AppendLine(Messages.NoQuestions);
            }
            else
            {
                foreach (var question in this.Forum.Questions.OrderBy(q => q.Id))
                {
                    this.Forum.Output.AppendLine(string.Format("[ Question ID: {0} ]", question.Id));
                    this.Forum.Output.AppendLine(string.Format("Posted by: {0}", question.Author.Username));
                    this.Forum.Output.AppendLine(string.Format("Question Title: {0}", question.Title));
                    this.Forum.Output.AppendLine(string.Format("Question Body: {0}", question.Body));
                    this.Forum.Output.AppendLine(new string('=', 20));
                    if (question.Answers.Count == 0)
                    {
                        this.Forum.Output.AppendLine("No answers");
                    }
                    else
                    {
                        this.Forum.Output.AppendLine("Answers:");
                        if (question.Answers.Any(a => a is BestAnswer))
                        {
                            IAnswer bestAnswer = question.Answers.FirstOrDefault(q => q.GetType() == typeof (BestAnswer));
                            this.Forum.Output.AppendLine(new string('*', 20));
                            this.Forum.Output.AppendLine(string.Format("[ Answer ID: {0} ]", bestAnswer.Id));
                            this.Forum.Output.AppendLine(string.Format("Posted by: {0}", bestAnswer.Author.Username));
                            this.Forum.Output.AppendLine(string.Format("Answer Body: {0}", bestAnswer.Body));
                            this.Forum.Output.AppendLine(new string('-', 20));
                            this.Forum.Output.AppendLine(new string('*', 20));
                        }

                        var plainAnswers = question.Answers
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
                }
            }
            this.Forum.CurrentQuestion = null;
        }
    }
}
