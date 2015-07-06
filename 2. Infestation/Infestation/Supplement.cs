namespace Infestation
{
    public class Supplement : ISupplement
    {
        public Supplement(int powerEffect, int healthEffect, int aggressionEffect)
        {
            this.PowerEffect = powerEffect;
            this.HealthEffect = healthEffect;
            this.AggressionEffect = aggressionEffect;
        }

        public int PowerEffect { get; private set; }

        public int HealthEffect { get; private set; }

        public int AggressionEffect { get; private set; }

        public void ReactTo(ISupplement otherSupplement)
        {
            throw new System.NotImplementedException();
        }
    }
}
