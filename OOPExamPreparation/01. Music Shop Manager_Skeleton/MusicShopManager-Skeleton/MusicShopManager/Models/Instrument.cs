using System;
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public abstract class Instrument : Article, IInstrument
    {
        private string color;

        protected Instrument(string make, string model, decimal price, string color, bool isElectronic) 
            : base(make, model, price)
        {
            this.Color = color;
            this.IsElectronic = isElectronic;
        }

        public string Color
        {
            get { return this.color; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The color is required.");
                }
                this.color = value;
            }
        }
        public bool IsElectronic { get; private set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.Append(string.Format("Color: {0}", this.Color));
            
            return output.ToString();
        }
    }
}
