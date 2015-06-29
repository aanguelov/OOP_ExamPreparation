using System;
using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public class Garage : Estate, IGarage
    {
        private int width;
        private int height;

        public Garage() 
            : base(EstateType.Garage)
        {
            //this.Width = width;
            //this.Height = height;
        }

        public int Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0 || value > 500)
                {
                    throw new IndexOutOfRangeException("Garage width should be in range [0…500].");
                }
                this.width = value;
            }
        }

        public int Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0 || value > 500)
                {
                    throw new IndexOutOfRangeException("Garage height should be in range [0…500].");
                }
                this.height = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            string furnished = this.IsFurnished ? "Yes" : "No";
            output.Append(string.Format("Garage: Name = {0}, Area = {1}, Location = {2}, Furnitured = {3}, Width: {4}, Height: {5}",
                this.Name, this.Area, this.Location, furnished, this.Width, this.Height));
            return output.ToString();
        }
    }
}
