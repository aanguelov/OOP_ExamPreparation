using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTunesShop
{
    public class ExtendedEngine : MyTunesEngine
    {
        protected override void ExecuteRateCommand(string[] commandWords)
        {
            string songName = commandWords[2];
            var song = this.media.FirstOrDefault(s => s is Song && s.Title == songName) as Song;
            if (song == null)
            {
                this.Printer.PrintLine("The song does not exist in the database.");
                return;
            }

            int rate = Convert.ToInt32(commandWords[3]);
            song.PlaceRating(rate);
            this.Printer.PrintLine("The rating has been placed successfully.");
        }

        protected override string GetSongReport(ISong song)
        {
            var songSalesInfo = this.mediaSupplies[song];
            StringBuilder songInfo = new StringBuilder();
            songInfo.AppendFormat("{0} ({1}) by {2}", song.Title, song.Year, song.Performer.Name).AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", song.Genre, song.Price).AppendLine();

            if (song.Ratings.Any())
            {
                songInfo.AppendFormat("Rating: {0}", Math.Round(song.Ratings.Average())).AppendLine();
            }
            else
            {
                songInfo.AppendLine("Rating: 0");
            }
            songInfo.AppendFormat("Supplies: {0}, Sold: {1}", songSalesInfo.Supplies, songSalesInfo.QuantitySold);
            return songInfo.ToString();
        }

        protected override void ExecuteInsertMediaCommand(string[] commandWords)
        {
            //base.ExecuteInsertMediaCommand(commandWords);
            switch (commandWords[2])
            {
                case "album":
                    var performer = this.performers.FirstOrDefault(p => p.Name == commandWords[5]);
                    if (performer == null)
                    {
                        this.Printer.PrintLine("The performer does not exist in the database.");
                        return;
                    }

                    var album = new Album(commandWords[3], decimal.Parse(commandWords[4]), performer, commandWords[6], 
                                            int.Parse(commandWords[7]));
                    this.InsertAlbum(album);
                    break;
                default:
                    base.ExecuteInsertMediaCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song_to_album":
                    var albumName = this.media.FirstOrDefault(a => a.Title == commandWords[2]) as Album;
                    if (albumName == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }
                    var song = this.media.FirstOrDefault(s => s.Title == commandWords[3]) as Song;
                    if (song == null)
                    {
                        this.Printer.PrintLine("The song does not exist in the database.");
                        return;
                    }
                    albumName.Songs.Add(song);
                    this.Printer.PrintLine(string.Format("The song {0} has been added to the album {1}.", 
                                                            song.Title, albumName.Title));
                    break;
                case "member_to_band":
                    var band = this.performers.FirstOrDefault(b => b.Name == commandWords[2]) as Band;
                    if (band == null)
                    {
                        this.Printer.PrintLine("The band does not exist in the database.");
                        return;
                    }
                    string member = commandWords[3];
                    band.AddMember(member);
                    this.Printer.PrintLine(string.Format("The member {0} has been added to the band {1}.", member, band.Name));
                    break;
                default:
                    base.ExecuteInsertCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSupplyCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Supply(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully supplied.", quantity, album.Title);
                    break;
                default:
                    base.ExecuteSupplyCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSellCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[2]) as IAlbum;
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Sell(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully sold.", quantity, album.Title);
                    break;
                default:
                    base.ExecuteSellCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    var band = new Band(commandWords[3]);
                    this.InsertPerformer(band);
                    break;
                default:
                    base.ExecuteInsertPerformerCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album" :
                    var album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[3]) as IAlbum;
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(GetAlbumReport(album));
                    break;
                default:
                    base.ExecuteReportMediaCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    var band = this.performers.FirstOrDefault(b => b is IBand && b.Name == commandWords[3]) as IBand;
                    if (band == null)
                    {
                        this.Printer.PrintLine("The band does not exist in the database.");
                        return;
                    }
                    this.Printer.PrintLine(GetBandReport(band));
                    break;
                default:
                    base.ExecuteReportPerformerCommand(commandWords);
                    break;
            }
        }

        public void InsertAlbum(IAlbum album)
        {
            this.media.Add(album);
            this.mediaSupplies.Add(album, new SalesInfo());
            this.Printer.PrintLine(string.Format("Album {0} by {1} added successfully", album.Title, album.Performer.Name));
        }

        public string GetAlbumReport(IAlbum album)
        {
            var albumInfo = new StringBuilder();
            var albumSalesInfo = this.mediaSupplies[album];
            albumInfo.AppendLine(string.Format("{0} ({1}) by {2}", album.Title, album.Year, album.Performer.Name))
                .AppendLine(string.Format("Genre: {0}, Price: ${1:F2}", album.Genre, album.Price))
                .AppendLine(string.Format("Supplies: {0}, Sold: {1}", albumSalesInfo.Supplies, albumSalesInfo.QuantitySold));
            var songs = album.Songs;
            if (songs.Count > 0)
            {
                albumInfo.AppendLine("Songs:");
                for (int i = 0; i < songs.Count; i++)
                {
                    var currentSong = songs[i];
                    if (i != songs.Count - 1)
                    {
                        albumInfo.AppendLine(string.Format("{0} ({1})", currentSong.Title, currentSong.Duration));
                    }
                    else
                    {
                        albumInfo.Append(string.Format("{0} ({1})", currentSong.Title, currentSong.Duration));
                    }
                }
            }
            else
            {
                albumInfo.Append("No songs");
            }
            return albumInfo.ToString();
        }

        public string GetBandReport(IBand band)
        {
            var bandInfo = new StringBuilder();

            bandInfo.Append(band.Name + ": ");

            List<string> members = band.Members.ToList();

            if (members.Count > 0)
            {
                bandInfo.AppendLine(string.Join(", ", members));
            }
            else
            {
                bandInfo.AppendLine();
            }

            var songs = band.Songs.OrderBy(s => s.Title);
            if (songs.Any())
            {
                List<string> songNames = songs.Select(s => s.Title).ToList();
                bandInfo.Append(string.Join("; ", songNames));
            }
            else
            {
                bandInfo.Append("no songs");
            }

            return bandInfo.ToString();
        }
    }
}
