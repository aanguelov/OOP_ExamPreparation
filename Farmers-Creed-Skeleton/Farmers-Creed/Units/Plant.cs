using System.Text;

namespace FarmersCreed.Units
{
    using System;

    public class Plant : FarmUnit
    {
        public Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            this.GrowTime = growTime;
        }

        public bool HasGrown { get; set; }

        public int GrowTime { get; set; }

        public virtual void Water()
        {
            this.Health += 2;
        }

        public virtual void Wither()
        {
            this.Health -= 1;
            this.CheckIfAlive();
        }

        public virtual void Grow()
        {
            this.GrowTime -= 1;
            if (this.GrowTime == 0)
            {
                this.HasGrown = true;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(base.ToString() + ", ");
            if (IsAlive)
            {
                string grown = this.HasGrown ? "Yes" : "No";
                output.Append(string.Format("Health: {0}, Grown: {1}", this.Health, grown));
            }
            else
            {
                output.Append("DEAD");
            }
            return output.ToString();
        }
    }
}
