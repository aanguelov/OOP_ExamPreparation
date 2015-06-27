using System;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class MainCourse : Meal, IMainCourse
    {
        public MainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, 
                            bool isVegan, string type) 
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.Type = (MainCourseType) Enum.Parse(typeof (MainCourseType), type);
        }

        public MainCourseType Type { get; private set; }

        //public string CourseType { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(base.ToString())
                  .Append(string.Format("Type: {0}", this.Type));
            return output.ToString();
        }
    }
}
