using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Chair : Furniture, IChair
    {
        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString() + string.Format("Legs: {0}", this.NumberOfLegs));
            return result.ToString();
        }
    }
}
