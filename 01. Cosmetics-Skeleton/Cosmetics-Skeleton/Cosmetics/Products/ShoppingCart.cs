using System.Collections.Generic;
using System.Linq;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class ShoppingCart : IShoppingCart
    {
        public ShoppingCart()
        {
            this.ProductsInCart = new List<IProduct>();
        }

        public IList<IProduct> ProductsInCart { get; set; }

        public void AddProduct(IProduct product)
        {
            this.ProductsInCart.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.ProductsInCart.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            bool doesContain = true;

            if (!this.ProductsInCart.Contains(product))
            {
                doesContain = false;
            }

            return doesContain;
        }

        public decimal TotalPrice()
        {
            var shampooPrices = this.ProductsInCart
                .Where(p => p is IShampoo)
                .Select(p => p.Price);

            var toothPastePrices = this.ProductsInCart
                .Where(p => p is IToothpaste)
                .Select(p => p.Price);
            decimal totalPrice = shampooPrices.Sum() + toothPastePrices.Sum();
            return totalPrice;
        }
    }
}
