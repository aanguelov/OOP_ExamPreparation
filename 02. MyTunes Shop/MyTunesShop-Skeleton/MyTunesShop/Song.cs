namespace MyTunesShop
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Song : Media, ISong
    {
        //private IPerformer performer;
        //private string genre;
        //private int year;
        private string duration;
        //private bool rateable = true;

        public Song(string title, decimal price, IPerformer performer, string genre, int year, string duration) 
            : base(title, price, performer, genre, year)
        {
            //this.Performer = performer;
            //this.Genre = genre;
            //this.Year = year;
            this.Duration = duration;
            //this.Ratings = new List<int>();
            //this.Rateable = rateable;
        }

        public string Duration
        {
            get
            {
                return this.duration;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The duration of a song is required.");
                }

                this.duration = value;
            }
        }

        //public bool Rateable { get; private set; }

        //public bool Rateable
        //{
        //    get { return this.rateable; }
        //    private set
        //    {
        //        if (!value)
        //        {
        //            throw new ArgumentException("The song must be rateable.");
        //        }
        //        this.rateable = true;
        //    }
        //}

        //public IList<int> Ratings { get; private set; }

        //public void PlaceRating(int rating)
        //{
        //    this.Ratings.Add(rating);
        //}

    }
}
