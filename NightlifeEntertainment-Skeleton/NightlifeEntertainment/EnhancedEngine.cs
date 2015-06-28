using System;
using System.Linq;

namespace NightlifeEntertainment
{
    public class EnhancedEngine : CinemaEngine
    {
        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "opera":
                    var opera = new OperaHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(opera);
                    break;
                case "sports_hall":
                    var sportsHall = new SportsHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sportsHall);
                    break;
                case "concert_hall":
                    var concertHall = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concertHall);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[5]);

            if (venue == null)
            {
                throw new ArgumentException("Venue doesn`t exist.");
            }

            switch (commandWords[2])
            {
                case "theatre":
                    //var theatreVenue = this.GetVenue(commandWords[5]);
                    if (!venue.AllowedTypes.Contains(PerformanceType.Theatre))
                    {
                        throw new ArgumentException("Invalid venue.");
                    }
                    var theatre = new Theatre(commandWords[3], decimal.Parse(commandWords[4]), venue, 
                                                DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
                    break;
                case "concert":
                    //var concertVenue = this.GetVenue(commandWords[5]);
                    if (!venue.AllowedTypes.Contains(PerformanceType.Concert))
                    {
                        throw new ArgumentException("Invalid venue.");
                    }
                    var concert = new Concert(commandWords[3], decimal.Parse(commandWords[4]), venue, 
                                                DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(concert);
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[2]);
            var performance = this.GetPerformance(commandWords[3]);

            if (venue == null || performance == null || !venue.AllowedTypes.Contains(performance.Type))
            {
                throw new ArgumentException("Invalid venue or performance.");
            }

            if (performance.Tickets.Count == venue.Seats)
            {
                throw new InvalidOperationException("There are no seats left for this performance.");
            }

            switch (commandWords[1])
            {
                case "student":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }
                    break;
                case "vip":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new VIPTicket(performance));
                    }
                    break;
                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            var performanceName = commandWords[1];
            var performance = this.Performances.FirstOrDefault(p => p.Name == performanceName);
            if (performance == null)
            {
                throw new ArgumentNullException("There is no such performance.");
            }
            var venue = performance.Venue;
            var startTime = performance.StartTime;
            var soldTickets = performance.Tickets.Where(t => t.Status == TicketStatus.Sold).ToArray();
            var prices = soldTickets.Select(t => t.Price);

            this.Output.AppendLine(string.Format("{0}: {1} ticket(s), total: ${2:F2}", 
                                                    performanceName, soldTickets.Count(), prices.Sum()))
                       .AppendLine(string.Format("Venue: {0} ({1})", venue.Name, venue.Location))
                       .AppendLine(string.Format("Start time: {0}", startTime));
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            var searchPhrase = commandWords[1].ToLower();
            var time = DateTime.Parse(commandWords[2] + " " + commandWords[3]);

            var performances = this.Performances
                .Where(p => p.Name.ToLower().Contains(searchPhrase) && p.StartTime >= time)
                .OrderBy(p => p.StartTime)
                .ThenByDescending(p => p.BasePrice)
                .ThenBy(p => p.Name);

            var venues = this.Venues
                .Where(v => v.Name.ToLower().Contains(searchPhrase))
                .OrderBy(v => v.Name);

            this.Output.AppendLine(string.Format("Search for \"{0}\"", commandWords[1]));
            this.Output.AppendLine("Performances:");
            if (performances.Any())
            {
                foreach (var performance in performances)
                {
                    this.Output.AppendLine("-" + performance.Name);
                }
            }
            else
            {
                this.Output.AppendLine("no results");
            }

            this.Output.AppendLine("Venues:");
            if (venues.Any())
            {
                foreach (var venue in venues)
                {
                    this.Output.AppendLine("-" + venue.Name);
                    var currentVenue = venue;
                    var venueEvents = this.Performances
                        .Where(p => p.Venue == currentVenue && p.StartTime >= time)
                        .OrderBy(p => p.StartTime)
                        .ThenByDescending(p => p.BasePrice)
                        .ThenBy(p => p.Name);
                    if (venueEvents.Any())
                    {
                        foreach (var performance in venueEvents)
                        {
                            this.Output.AppendLine("--" + performance.Name);
                        }
                    }
                }
            }
            else
            {
                this.Output.AppendLine("no results");
            }
        }
    }
}
