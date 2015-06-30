using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            if (height <= 0)
            {
                throw new ArgumentException("Price cannot be less or equal to 0.00 m.");
            }
            this.Height = height;
        }
    }
}
