using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Salad : Meal, ISalad
    {
        private const bool IsSaladVegan = true;

        public Salad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta) 
            : base(name, price, calories, quantityPerServing, timeToPrepare, IsSaladVegan)
        {
            this.ContainsPasta = containsPasta;
        }

        public bool ContainsPasta { get; private set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            string pasta = this.ContainsPasta ? "yes" : "no";
            output.AppendLine(base.ToString())
                .AppendLine(string.Format("Contains pasta: {0}", pasta));
            return output.ToString();
        }
    }
}
