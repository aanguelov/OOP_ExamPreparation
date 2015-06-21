using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class BassGuitar : Guitar, IBassGuitar
    {
        public BassGuitar(string make, string model, decimal price, string color, 
                            string bodyWood, string fingerboardWood) 
            : base(make, model, price, color, true, bodyWood, fingerboardWood)
        {
            this.NumberOfStrings = 4;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            //output.AppendLine("----- Bass guitars -----");
            output.AppendLine(base.ToString());
            var electronic = IsElectronic ? "yes" : "no";
            output.AppendLine(string.Format("Electronic: {0}", electronic));
            output.AppendLine(string.Format("Strings: {0}", this.NumberOfStrings))
                .AppendLine(string.Format("Body wood: {0}", this.BodyWood))
                .AppendLine(string.Format("Fingerboard wood: {0}", this.FingerboardWood));
            return output.ToString();
        }
    }
}
