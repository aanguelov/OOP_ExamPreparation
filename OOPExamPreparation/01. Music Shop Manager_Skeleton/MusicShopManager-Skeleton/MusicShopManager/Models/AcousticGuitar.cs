using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class AcousticGuitar : Guitar, IAcousticGuitar
    {
        public AcousticGuitar(string make, string model, decimal price, string color, 
                                string bodyWood, string fingerboardWood, bool caseIncluded, StringMaterial stringMaterial) 
            : base(make, model, price, color, false, bodyWood, fingerboardWood)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = stringMaterial;
            this.NumberOfStrings = 6;
        }

        public bool CaseIncluded { get; private set; }
        public StringMaterial StringMaterial { get; private set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            //output.AppendLine("----- Acoustic guitars -----");
            output.AppendLine(base.ToString());
            var electronic = IsElectronic ? "yes" : "no";
            output.AppendLine(string.Format("Electronic: {0}", electronic));
            output.AppendLine(string.Format("Strings: {0}", this.NumberOfStrings))
                .AppendLine(string.Format("Body wood: {0}", this.BodyWood))
                .AppendLine(string.Format("Fingerboard wood: {0}", this.FingerboardWood));
            var included = CaseIncluded ? "yes" : "no";
            output.AppendLine(string.Format("Case included: {0}", included))
                .Append(string.Format("String material: {0}", this.StringMaterial));
            return output.ToString();
        }
    }
}
