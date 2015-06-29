using System;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private int rooms;

        protected BuildingEstate(EstateType type) 
            : base(type)
        {
            //this.Rooms = rooms;
        }

        public int Rooms
        {
            get { return this.rooms; }
            set
            {
                if (value <= 0 || value > 20)
                {
                    throw new IndexOutOfRangeException("Office / apartment rooms should be in range [0…20].");
                }
                this.rooms = value;
            }
        }

        public bool HasElevator { get; set; }
    }
}
