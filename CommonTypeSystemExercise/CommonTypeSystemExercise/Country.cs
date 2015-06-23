using System;
using System.CodeDom;
using System.Collections.Generic;

namespace CommonTypeSystemExercise
{
    public class Country : IComparable<Country>
    {
        private string name;
        private long population;
        private int area;

        public Country(string name, long population, int area)
        {
            this.Name = name;
            this.Population = population;
            this.Area = area;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be empty string.");
                }
                this.name = value;
            }
        }

        public long Population
        {
            get { return this.population; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Population must be positive.");
                }
                this.population = value;
            }
        }

        public int Area
        {
            get { return this.area; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Area must be positive.");
                }
                this.area = value;
            }
        }

        public HashSet<string> Cities { get; set; }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Population.GetHashCode();
        }

        public int CompareTo(Country other)
        {
            if (this.Area != other.Area)
            {
                return this.Area - other.Area;
            }

            if (this.Population != other.Population)
            {
                return (int) (this.Population - other.Population);
            }

            if (this.Name != other.Name)
            {
                
            }
        }

        public override bool Equals(object obj)
        {
            Country country = obj as Country;
            if (obj == null)
            {
                return false;
            }

            if (!Object.Equals(this.Name, country.Name))
            {
                return false;
            }
            return true;
        }

        public static bool operator ==(Country a, Country b)
        {
            if (!a.Equals(b))
            {
                return false;
            }
            return true;
        }

        public static bool operator !=(Country a, Country b)
        {
            if (!a.Equals(b))
            {
                return true;
            }
            return false;
        }
    }
}
