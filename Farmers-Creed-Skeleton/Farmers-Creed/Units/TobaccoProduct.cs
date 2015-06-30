namespace FarmersCreed.Units
{
    public class TobaccoProduct : Product
    {
        private const int DefaultTobaccoQuantity = 10;

        public TobaccoProduct(string id) 
            : base(id, ProductType.Tobacco, DefaultTobaccoQuantity)
        {
        }
    }
}
