﻿using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public class BestAnswer : IAnswer
    {
        public BestAnswer(int id, string body, IUser author)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;
        }

        public int Id { get; set; }
        public string Body { get; set; }
        public IUser Author { get; set; }
    }
}
