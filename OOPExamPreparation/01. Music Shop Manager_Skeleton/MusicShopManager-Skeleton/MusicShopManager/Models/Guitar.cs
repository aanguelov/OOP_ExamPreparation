using System;
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public abstract class Guitar : Instrument, IGuitar
    {
        private string bodyWood;
        private string fingerboardWood;

        protected Guitar(string make, string model, decimal price, string color, bool isElectronic, 
                            string bodyWood, string fingerboardWood) 
            : base(make, model, price, color, isElectronic)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerboardWood;
            //this.NumberOfStrings = 6;
        }

        public string BodyWood
        {
            get { return this.bodyWood; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The bodywood is required.");
                }
                this.bodyWood = value;
            }
        }

        public string FingerboardWood
        {
            get { return this.fingerboardWood; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The fingerboardwood is required.");
                }
                this.fingerboardWood = value;
            }
        }
        public int NumberOfStrings { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(base.ToString());
            return output.ToString();
        }
    }
}
