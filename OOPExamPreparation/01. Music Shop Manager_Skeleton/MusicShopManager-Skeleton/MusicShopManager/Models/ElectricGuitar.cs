using System;
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class ElectricGuitar : Guitar, IElectricGuitar
    {
        private int numberOfAdapters;
        private int numberOfFrets;

        public ElectricGuitar(string make, string model, decimal price, string color, 
                                string bodyWood, string fingerboardWood, int numberOfAdapters, int numberOfFrets) 
            : base(make, model, price, color, true, bodyWood, fingerboardWood)
        {
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;
            this.NumberOfStrings = 6;
        }

        public int NumberOfAdapters
        {
            get { return this.numberOfAdapters; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of adapters must be non-negative.");
                }
                this.numberOfAdapters = value;
            }
        }

        public int NumberOfFrets
        {
            get { return this.numberOfFrets; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of frets must be positive.");
                }
                this.numberOfFrets = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            //output.AppendLine("----- Electric guitars -----");
            output.AppendLine(base.ToString());
            var electronic = IsElectronic ? "yes" : "no";
            output.AppendLine(string.Format("Electronic: {0}", electronic));
            output.AppendLine(string.Format("Strings: {0}", this.NumberOfStrings))
                .AppendLine(string.Format("Body wood: {0}", this.BodyWood))
                .AppendLine(string.Format("Fingerboard wood: {0}", this.FingerboardWood))
                .AppendLine(string.Format("Adapters: {0}", this.NumberOfAdapters))
                .Append(string.Format("Frets: {0}", this.NumberOfFrets));
            return output.ToString();
        }
    }
}
