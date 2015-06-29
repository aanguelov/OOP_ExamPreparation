using System;
using Estates.Interfaces;

namespace Estates.Data
{
    public class Estate : IEstate
    {
        private const double MinArea = 0;
        private const double MaxArea = 10000;

        private double area;

        public Estate(EstateType type)
        {
            this.Type = type;
            //this.Area = area;
        }

        public string Name { get; set; }

        public EstateType Type { get; set; }

        public double Area
        {
            get { return this.area; }
            set
            {
                if (value <= MinArea || value > MaxArea)
                {
                    throw new IndexOutOfRangeException("Estate area should be in range [0…10000].");
                }
                this.area = value;
            }
        }

        public string Location { get; set; }

        public bool IsFurnished { get; set; }
    }
}
