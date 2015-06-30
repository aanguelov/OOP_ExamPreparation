using System;
using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture : IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;

        protected Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Model cannot be empty, null or with less than 3 symbols.");
                }
                this.model = value;
            }
        }

        public string Material { get; private set; }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to $0.00.");
                }
                this.price = value;
            }
        }

        public decimal Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to 0.00 m.");
                }
                this.height = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, ",
                 this.GetType().Name, this.Model, this.Material, this.Price, this.Height));
            return result.ToString();
        }
    }
}
