using System.Text;

namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public class Animal : FarmUnit
    {
        public Animal(string id, int health, int productionQuantity)
            : base(id, health, productionQuantity)
        {
        }

        public void Eat(IEdible food, int quantity)
        {
            food.Quantity -= quantity;
            if (this.GetType() == typeof(Swine))
            {
                this.Health += food.HealthEffect * quantity * 2;
            }

            if (this.GetType() == typeof(Cow))
            {
                if (food.FoodType == FoodType.Organic)
                {
                    this.Health += food.HealthEffect*quantity;
                }
                else
                {
                    this.Health -= food.HealthEffect*quantity;
                    this.CheckIfAlive();
                }
            }
        }

        public void Starve()
        {
            this.Health -= 1;
            if (this.GetType() == typeof(Swine))
            {
                this.Health -= 2;
            }
            this.CheckIfAlive();
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(base.ToString() + ", ");
            if (IsAlive)
            {
                output.Append(string.Format("Health: {0}", this.Health));
            }
            else
            {
                output.Append("DEAD");
            }
            return output.ToString();
        }
    }
}
