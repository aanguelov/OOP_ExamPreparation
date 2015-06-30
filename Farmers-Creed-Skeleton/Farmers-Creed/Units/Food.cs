using System.Text;

namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public class Food : Product, IEdible
    {
        private FoodType foodType;
        private int healthEffect;

        public Food(string id, ProductType productType, FoodType foodType, int quantity, int healthEffect)
            : base(id, productType, quantity)
        {
            this.HealthEffect = healthEffect;
            this.FoodType = foodType;
        }

        public FoodType FoodType
        {
            get { return this.foodType; }
            set { this.foodType = value;  }
        }

        public int HealthEffect
        {
            get { return this.healthEffect; }
            set { this.healthEffect = value; }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(base.ToString())
                .Append(string.Format(", Food Type: {0}, ", this.FoodType))
                .Append(string.Format("Health Effect: {0}", this.HealthEffect));
            return output.ToString();
        }
    }
}
