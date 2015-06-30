using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    class CherryProduct : Food
    {
        public CherryProduct(string id) 
            : base(id, ProductType.Cherry, FoodType.Organic, 4, 2)
        {
        }
    }
}
