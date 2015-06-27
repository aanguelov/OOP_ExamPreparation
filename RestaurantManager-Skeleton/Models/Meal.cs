using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public abstract class Meal : Recipe, IMeal
    {
        protected Meal(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan) 
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsVegan = isVegan;
            this.Unit = MetricUnit.Grams;
        }

        public bool IsVegan { get; private set; }

        public void ToggleVegan()
        {
            this.IsVegan = !this.IsVegan;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            string vegan = this.IsVegan ? "[VEGAN] " : string.Empty;
            output.Append(vegan)
                .Append(base.ToString());
            return output.ToString();
        }
    }
}
