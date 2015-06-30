using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private decimal defaultConvertibleChairHeight = 0;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
            this.IsConverted = false;
            defaultConvertibleChairHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            this.IsConverted = !this.IsConverted;
            if (IsConverted)
            {
                this.Height = 0.10m;
            }
            else
            {
                this.Height = defaultConvertibleChairHeight;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            string state = this.IsConverted ? "Converted" : "Normal";
            result.Append(base.ToString() + string.Format(", State: {0}", state));
            return result.ToString();
        }
    }
}
