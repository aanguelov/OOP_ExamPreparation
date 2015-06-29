using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public class RentOffer : Offer, IRentOffer
    {
        public RentOffer() 
            : base(OfferType.Rent)
        {
        }

        public decimal PricePerMonth { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(string.Format("Rent: {0}Price = {1}", base.ToString(), this.PricePerMonth));
            return output.ToString();
        }
    }
}
