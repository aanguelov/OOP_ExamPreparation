using System;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public abstract class Spell : ISpell
    {
        private int damage;
        private int energyCost;

        protected Spell(int damage, int energyCost)
        {
            this.Damage = damage;
            this.EnergyCost = energyCost;
        }

        public int Damage
        {
            get { return this.damage; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Damage must be positive");
                }
                this.damage = value;
            }
        }

        public int EnergyCost
        {
            get { return this.energyCost; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Energy cost must be posititve");
                }
                this.energyCost = value;
            }
        }
    }
}
