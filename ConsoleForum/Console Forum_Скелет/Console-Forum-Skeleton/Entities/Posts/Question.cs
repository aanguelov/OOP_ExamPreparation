using System.Collections.Generic;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public class Question : IQuestion
    {
        public Question(int id, string body, IUser author, string title)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public int Id { get; set; }
        public string Body { get; set; }
        public IUser Author { get; set; }
        public string Title { get; set; }
        public IList<IAnswer> Answers { get; private set; }
    }
}
