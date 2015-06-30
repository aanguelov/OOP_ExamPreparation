using System.Linq;
using System.Text;

namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using FarmersCreed.Interfaces;

    public class Farm : GameObject, IFarm
    {
        public Farm(string id)
            : base(id)
        {
            this.Plants = new List<Plant>();
            this.Animals = new List<Animal>();
            this.Products = new List<Product>();
        }

        public List<Plant> Plants { get; set; }

        public List<Animal> Animals { get; set; }

        public List<Product> Products { get; set; }

        public void AddProduct(Product product)
        {
            var productId = this.Products.FirstOrDefault(p => p.Id == product.Id);

            if (productId != null)
            {
                int defaultProductQuantity = 0;
                switch(product.ProductType)
                {
                    case ProductType.Cherry :
                        defaultProductQuantity = 4;
                        break;
                    case ProductType.Grain:
                        defaultProductQuantity = 10;
                        break;
                    case ProductType.Milk:
                        defaultProductQuantity = 6;
                        break;
                    case ProductType.PorkMeat:
                        defaultProductQuantity = 1;
                        break;
                    case ProductType.Tobacco:
                        defaultProductQuantity = 10;
                        break;
                }
                productId.Quantity += defaultProductQuantity;
            }
            else
            {
                this.Products.Add(product);
            }
        }

        public void Exploit(IProductProduceable productProducer)
        {
            var product = productProducer.GetProduct();
            this.AddProduct(product);
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            animal.Eat(edibleProduct, productQuantity);
        }

        public void Water(Plant plant)
        {
            plant.Water();
        }

        public void UpdateFarmState()
        {
            var liveAnimals = this.Animals.Where(a => a.IsAlive == true);
            var livePlants = this.Plants.Where(p => p.IsAlive == true);

            foreach (var animal in liveAnimals)
            {
                animal.Starve();
            }

            foreach (var plant in livePlants)
            {
                if (plant.HasGrown)
                {
                    plant.Wither();
                }
                else
                {
                    plant.Grow();
                }
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(base.ToString());
            var animals = this.Animals
                .Where(a => a.IsAlive)
                .OrderBy(a => a.Id);
            foreach (var animal in animals)
            {
                output.AppendLine(animal.ToString());
            }

            var plants = this.Plants
                .Where(p => p.IsAlive)
                .OrderBy(p => p.Health)
                .ThenBy(p => p.Id);

            foreach (var plant in plants)
            {
                output.AppendLine(plant.ToString());
            }

            var products = this.Products
                .OrderBy(p => p.ProductType.ToString())
                .ThenByDescending(p => p.Quantity)
                .ThenBy(p => p.Id);

            foreach (var product in products)
            {
                if (product != products.Last())
                {
                    output.AppendLine(product.ToString());
                }
                else
                {
                    output.Append(product);
                }
            }

            return output.ToString();
        }
    }
}
