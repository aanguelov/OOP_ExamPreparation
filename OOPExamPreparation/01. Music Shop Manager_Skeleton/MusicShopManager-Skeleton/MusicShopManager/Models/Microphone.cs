using System.Runtime.CompilerServices;
using System.Text;
using MusicShopManager.Interfaces;
using MusicShopManager.Models;

namespace MusicShopManager.Models
{
    public class Microphone : Article, IMicrophone
    {
        public Microphone(string make, string model, decimal price, bool hasCable) 
            : base(make, model, price)
        {
            this.HasCable = hasCable;
        }

        public bool HasCable { get; private set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            //output.AppendLine("----- Microphones -----");
            output.AppendLine(base.ToString());
            var cable = HasCable ? "yes" : "no";
            output.Append(string.Format("Cable: {0}", cable));
            return output.ToString();
        }

        //public Microphone(string make, string model, decimal price) : base(make, model, price)
        //{
        //}
    }
}
