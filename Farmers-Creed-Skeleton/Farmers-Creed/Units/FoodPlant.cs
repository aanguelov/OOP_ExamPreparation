namespace FarmersCreed.Units
{
    public class FoodPlant : Plant
    {
        public FoodPlant(string id, int health, int productionQuantity, int growTime) 
            : base(id, health, productionQuantity, growTime)
        {
        }

        public override void Water()
        {
            this.Health += 1;
        }

        public override void Wither()
        {
            this.Health -= 1;
            base.Wither();
        }
    }
}
