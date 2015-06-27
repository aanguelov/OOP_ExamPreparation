using System;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo
    {
        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) 
            : base(name, brand, price, gender)
        {
            this.Price = price*milliliters;
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters { get; private set; }

        public UsageType Usage { get; private set; }

        public override string Print()
        {
            var output = new StringBuilder();
            output.AppendLine(base.Print());
            output.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            output.Append(string.Format("  * Usage: {0}", this.Usage));

            return output.ToString();
        }
    }
}
