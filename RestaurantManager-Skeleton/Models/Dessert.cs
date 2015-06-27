using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Dessert : Meal, IDessert
    {
        //private const bool WithShugar = true;

        public Dessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan) 
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.WithSugar = true;
        }

        public bool WithSugar { get; private set; }

        public void ToggleSugar()
        {
            this.WithSugar = !this.WithSugar;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            string sugar = this.WithSugar ? string.Empty : "[NO SUGAR] ";
            output.Append(sugar)
                  .Append(base.ToString());
            return output.ToString();
        }
    }
}
