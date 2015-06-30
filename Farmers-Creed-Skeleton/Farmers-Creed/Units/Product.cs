using System.Text;

namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;

    public class Product : GameObject, IProduct
    {
        private int quantity;
        private ProductType productType;

        public Product(string id, ProductType productType, int quantity)
            : base(id)
        {
            this.Quantity = quantity;
            this.ProductType = productType;
        }

        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Product quantity cannot be negative!");
                }
                this.quantity = value;
            }
        }

        public ProductType ProductType
        {
            get { return this.productType; }
            set { this.productType = value; }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(base.ToString() + ", ")
                .Append(string.Format("Quantity: {0}, ", this.Quantity))
                .Append(string.Format("Product Type: {0}", this.ProductType));
            return output.ToString();
        }
    }
}
