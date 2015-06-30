namespace FarmersCreed.Units
{
    public class Swine : Animal
    {
        public Swine(string id) 
            : base(id, 20, 1)
        {
        }

        //public override string ToString()
        //{
        //    return base.ToString() + string.Format(", Health: {0}", this.Health);
        //}
    }
}
