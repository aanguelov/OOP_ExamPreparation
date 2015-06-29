using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public class Appartment : BuildingEstate, IApartment
    {
        public Appartment() 
            : base(EstateType.Apartment)
        {
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            string furnished = this.IsFurnished ? "Yes" : "No";
            string elevator = this.HasElevator ? "Yes" : "No";
            output.Append(string.Format("Apartment: Name = {0}, Area = {1}, Location = {2}, Furnitured = {3}, Rooms: {4}, Elevator: {5}",
                this.Name, this.Area, this.Location, furnished, this.Rooms, elevator));
            return output.ToString();
        }
    }
}
