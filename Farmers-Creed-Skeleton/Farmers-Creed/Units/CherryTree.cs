using System.Text;

namespace FarmersCreed.Units
{
    class CherryTree : FoodPlant
    {
        private const int DefaultCherryTreeHealth = 14;
        private const int DefaultCherryTreeGrowTime = 3;
        private const int DefaultCherryTreeProductionQuantity = 4;

        public CherryTree(string id) 
            : base(id, DefaultCherryTreeHealth, DefaultCherryTreeProductionQuantity, DefaultCherryTreeGrowTime)
        {
        }

        //public override string ToString()
        //{
        //    var output = new StringBuilder();
        //    output.Append(base.ToString() + ", ");
        //    if (IsAlive)
        //    {
        //        string grown = this.HasGrown ? "yes" : "no";
        //        output.Append(string.Format("Health: {0}, Grown: {1}", this.Health, grown));
        //    }
        //    else
        //    {
        //        output.Append("DEAD");
        //    }
        //    return output.ToString();
        //}
    }
}
