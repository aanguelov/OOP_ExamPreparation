using System;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public abstract class Recipe : IRecipe
    {
        private string name;
        private decimal price;
        private int calories;
        private int quantityPerServing;
        private int timeToPrepare;

        protected Recipe(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.TimeToPrepare = timeToPrepare;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Recipe name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The price must be positive.");
                }
                this.price = value;
            }
        }

        public int Calories
        {
            get { return this.calories; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The calories must be positive.");
                }
                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get { return this.quantityPerServing; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The quantity per serving must be positive.");
                }
                this.quantityPerServing = value;
            }
        }

        public MetricUnit Unit { get; set; }

        public int TimeToPrepare
        {
            get { return this.timeToPrepare; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The time for preparation must be positive.");
                }
                this.timeToPrepare = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            string unit = "g";
            if (this.Unit == MetricUnit.Milliliters)
            {
                unit = "ml";
            }
            output.AppendLine(string.Format("==  {0} == ${1:F2}", this.Name, this.Price))
                  .AppendLine(string.Format("Per serving: {0} {1}, {2} kcal", this.QuantityPerServing, unit, this.Calories))
                  .Append(string.Format("Ready in {0} minutes", this.TimeToPrepare));
            return output.ToString();
        }
    }
}
