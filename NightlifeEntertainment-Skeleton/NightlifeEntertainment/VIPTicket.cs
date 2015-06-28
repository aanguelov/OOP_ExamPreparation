using System;

namespace NightlifeEntertainment
{
    public class VIPTicket : Ticket
    {
        public VIPTicket(IPerformance performance) 
            : base(performance, TicketType.VIP)
        {
        }

        protected override decimal CalculatePrice()
        {
            if (this.Performance == null)
            {
                throw new ArgumentException("The price cannot be calculated because there is no performance for this ticket.");
            }

            return base.CalculatePrice()*1.5m;
        }
    }
}
