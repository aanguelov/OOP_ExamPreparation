using System;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Drink : Recipe, IDrink
    {
        private const int MaxCaloriesPerDrink = 100;
        private const int MaxTimeForDrinkPreparation = 20;

        private int calories;
        private int timeToPrepare;

        public Drink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated) 
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.Calories = calories;
            this.TimeToPrepare = timeToPrepare;
            this.IsCarbonated = isCarbonated;
            this.Unit = MetricUnit.Milliliters;
        }

        public new int Calories
        {
            get { return this.calories; }
            set
            {
                if (value > MaxCaloriesPerDrink)
                {
                    throw new ArgumentException(string.Format(
                        "The calories in a drink must not be greater than {0}.", MaxCaloriesPerDrink));
                }
                this.calories = value;
            }
        }

        public new int TimeToPrepare
        {
            get { return this.timeToPrepare; }
            set
            {
                if (value > MaxTimeForDrinkPreparation)
                {
                    throw new ArgumentException(string.Format(
                        "The time to prepare a drink must not be greater than {0} minutes.", MaxTimeForDrinkPreparation));
                }
                this.timeToPrepare = value;
            }
        }

        public bool IsCarbonated { get; private set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(base.ToString());
            string carbonated = this.IsCarbonated ? "yes" : "no";
            output.AppendLine(string.Format("Carbonated: {0}", carbonated));
            return output.ToString();
        }
    }
}
