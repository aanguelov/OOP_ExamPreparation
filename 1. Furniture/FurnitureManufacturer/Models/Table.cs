using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Table : Furniture, ITable
    {
        public Table(string model, string material, decimal price, decimal height, decimal length, decimal width) 
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
            this.Area = length*width;
        }

        public decimal Length { get; private set; }

        public decimal Width { get; private set; }

        public decimal Area { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString() + string.Format("Length: {0}, Width: {1}, Area: {2}",
                this.Length, this.Width, this.Area));
            return result.ToString();
        }
    }
}
