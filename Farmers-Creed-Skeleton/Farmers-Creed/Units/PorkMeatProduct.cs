namespace FarmersCreed.Units
{
    public class PorkMeatProduct : Food
    {
        public PorkMeatProduct(string id) 
            : base(id, ProductType.PorkMeat, FoodType.Meat, 1, 5)
        {
        }
    }
}
