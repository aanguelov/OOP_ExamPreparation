using System.Runtime.CompilerServices;
using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    public class Cow : Animal
    {
        private const int BaseHealth = 15;

        public Cow(string id) 
            : base(id, BaseHealth, 6)
        {
            
        }

        
    }
}
