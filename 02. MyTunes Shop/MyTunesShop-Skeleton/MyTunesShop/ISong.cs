namespace MyTunesShop
{
    using System;

    public interface ISong : IRateable, IMedia
    {
        IPerformer Performer { get; }

        string Genre { get; }

        int Year { get; }

        string Duration { get; }

    }
}
