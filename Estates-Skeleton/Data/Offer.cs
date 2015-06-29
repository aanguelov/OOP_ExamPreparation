using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public class Offer : IOffer
    {
        public Offer(OfferType type)
        {
            this.Type = type;
        }

        public OfferType Type { get; set; }

        public IEstate Estate { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(string.Format("Estate = {0}, Location = {1}, ", this.Estate.Name, this.Estate.Location));
            return output.ToString();
        }
    }
}
