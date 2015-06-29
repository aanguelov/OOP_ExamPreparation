using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public class SaleOffer : Offer, ISaleOffer
    {
        public SaleOffer() 
            : base(OfferType.Sale)
        {
        }

        public decimal Price { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(string.Format("Sale: {0}Price = {1}", base.ToString(), this.Price));
            return output.ToString();
        }
    }
}
