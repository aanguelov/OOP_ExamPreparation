using System;
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class Drum : Instrument, IDrums
    {
        private int width;
        private int height;

        public Drum(string make, string model, decimal price, string color, int width, int height) 
            : base(make, model, price, color, false)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width 
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The width must be positive.");
                }
                this.width = value;
            }
        }

        public int Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The height must be positive.");
                }
                this.height = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            //output.AppendLine("----- Drums -----");
            output.AppendLine(base.ToString());
            var electronic = IsElectronic ? "yes" : "no";
            output.AppendLine(string.Format("Electronic: {0}", electronic));
            output.Append(string.Format("Size: {0}cm x {1}cm", this.Width, this.Height));
            return output.ToString();
        }
    }
}
