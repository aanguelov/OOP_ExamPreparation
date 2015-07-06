namespace Infestation
{
    public class Tank : Unit
    {
        private const int BaseTankHealth = 20;
        private const int BaseTankPower = 25;
        private const int BaseTankAggression = 25;

        public Tank(string id) 
            : base(id, UnitClassification.Mechanical, BaseTankHealth, BaseTankPower, BaseTankAggression)
        {
        }

        
    }
}
