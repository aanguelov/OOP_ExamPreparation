using System;
using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public class House : Estate, IHouse
    {
        private int floors;

        public House() 
            : base(EstateType.House)
        {
            //this.Floors = floors;
        }

        public int Floors
        {
            get { return this.floors; }
            set
            {
                if (value <= 0 || value > 10)
                {
                    throw new IndexOutOfRangeException("House floors should be in range [0…10].");
                }
                this.floors = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            string furnished = this.IsFurnished ? "Yes" : "No";
            output.Append(string.Format("House: Name = {0}, Area = {1}, Location = {2}, Furnitured = {3}, Floors: {4}",
                this.Name, this.Area, this.Location, furnished, this.Floors));
            return output.ToString();
        }
    }
}
