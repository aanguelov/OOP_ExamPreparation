namespace FarmersCreed.Units
{
    public class MilkProduct : Food
    {
        public MilkProduct(string id) 
            : base(id, ProductType.Milk, FoodType.Organic, 6, 4)
        {
        }
    }
}
