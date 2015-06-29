using System.Collections.Generic;
using System.Linq;
using Estates.Engine;
using Estates.Interfaces;

namespace Estates.Data
{
    class ModifiedEstateEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location" :
                    return this.ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                case "find-rents-by-price" :
                    return this.ExecuteFindRentsByPriceCommand(int.Parse(cmdArgs[0]), int.Parse(cmdArgs[1]));
                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);
            }
        }

        private string ExecuteFindRentsByPriceCommand(int minPrice, int maxPrice)
        {
            var rentOffers = this.Offers
                .Where(o => o.Type == OfferType.Rent)
                .Cast<IRentOffer>();
            var offers = rentOffers
                .Where(o => o.PricePerMonth >= minPrice && o.PricePerMonth <= maxPrice)
                .OrderBy(o => o.PricePerMonth)
                .ThenBy(o => o.Estate.Name);
            return this.FormatQueryResults(offers);
        }

        private string ExecuteFindRentsByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                .OrderBy(o => o.Estate.Name);
            return this.FormatQueryResults(offers);
        }
    }
}
