using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> listOfIngredients) 
            : base(name, brand, price, gender)
        {
            this.ListOfIngredients = new List<string>(listOfIngredients);
        }

        public string Ingredients { get; private set; }

        public IList<string> ListOfIngredients { get; set; }

        public override string Print()
        {
            var output = new StringBuilder();
            output.AppendLine(base.Print());
            output.Append(string.Format("  * Ingredients: {0}", string.Join(", ", this.ListOfIngredients)));
            return output.ToString();
        }
    }
}
