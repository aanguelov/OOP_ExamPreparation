using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;

    public abstract class FarmUnit : GameObject, IProductProduceable 
    {
        protected FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
            this.IsAlive = true;
        }

        public int Health { get; set; }

        public bool IsAlive { get; set; }

        public int ProductionQuantity { get; set; }

        public Product GetProduct()
        {
            string id = this.Id + "Product";
            Product product = null;
            if (this.GetType() == typeof(Cow))
            {
                if (this.IsAlive)
                {
                    product = new Food(id, ProductType.Milk, FoodType.Organic, 6, 4);
                    this.Health -= 2;
                }
            }
            else if (this.GetType() == typeof(TobaccoPlant))
            {
                if (this.IsAlive)
                {
                    product = new Product(id, ProductType.Tobacco, 10);
                }
            }else if (this.GetType() == typeof(CherryTree))
            {
                if (this.IsAlive)
                {
                    product = new Food(id, ProductType.Cherry, FoodType.Organic, 4, 2);
                }
            }
            else
            {
                if (this.IsAlive)
                {
                    product = new Food(id, ProductType.PorkMeat, FoodType.Meat, 1, 5);
                    this.IsAlive = false;
                }
            }
            
            return product;
        }

        public void CheckIfAlive()
        {
            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }
    }
}
