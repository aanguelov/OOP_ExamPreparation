namespace FarmersCreed.Units
{
    public class TobaccoPlant : Plant
    {
        private const int DefaultTobaccoPlantHealth = 12;
        private const int DefaultTobaccoPlantGrowTime = 4;
        private const int DefaultTobaccoProductionQuantity = 10;

        public TobaccoPlant(string id) 
            : base(id, DefaultTobaccoPlantHealth, DefaultTobaccoProductionQuantity, DefaultTobaccoPlantGrowTime)
        {
        }

        public override void Grow()
        {
            this.GrowTime -= 1;
            base.Grow();
        }
    }
}
