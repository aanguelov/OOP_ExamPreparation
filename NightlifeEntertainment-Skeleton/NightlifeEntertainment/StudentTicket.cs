using System;

namespace NightlifeEntertainment
{
    public class StudentTicket : Ticket
    {
        public StudentTicket(IPerformance performance) 
            : base(performance, TicketType.Student)
        {
        }

        protected override decimal CalculatePrice()
        {
            if (this.Performance == null)
            {
                throw new ArgumentException("The price cannot be calculated because there is no performance for this ticket.");
            }

            return (base.CalculatePrice()*80)/100;
        }
    }
}
