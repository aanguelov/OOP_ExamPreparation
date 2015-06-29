using Estates.Engine;
using Estates.Interfaces;
using System;

namespace Estates.Data
{
    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new ModifiedEstateEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            switch (type)
            {
                case EstateType.Apartment :
                    return new Appartment();
                case EstateType.Garage:
                    return new Garage();
                case EstateType.House:
                    return new House();
                case EstateType.Office:
                    return new Office();
                default:
                    throw new NotImplementedException("Unknown object to create");
            }
        }

        public static IOffer CreateOffer(OfferType type)
        {
            switch (type)
            {
                case OfferType.Rent:
                    return new RentOffer();
                case OfferType.Sale:
                    return new SaleOffer();
                default:
                    throw new NotImplementedException("Unknown object to create");
            }
        }
    }
}
