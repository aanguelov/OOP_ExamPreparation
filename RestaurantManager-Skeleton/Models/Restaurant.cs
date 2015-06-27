using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Restaurant : IRestaurant
    {
        private string name;

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.Recipes = new List<IRecipe>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Restaurant name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public string Location { get; private set; }

        public IList<IRecipe> Recipes { get; private set; }

        public void AddRecipe(IRecipe recipe)
        {
            this.Recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.Recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("***** {0} - {1} *****", this.Name, this.Location));
            var recipes = this.Recipes;
            if (recipes.Count == 0)
            {
                output.Append("No recipes... yet");
            }
            else
            {
                var drinks = recipes.Where(r => r is IDrink).OrderBy(r => r.Name).ToArray();

                if (drinks.Any())
                {
                    output.AppendLine("~~~~~ DRINKS ~~~~~");
                    for (int i = 0; i < drinks.Count(); i++)
                    {
                        var currentDrink = drinks[i];
                        if (i != drinks.Count() - 1)
                        {
                            output.AppendLine(currentDrink.ToString());
                        }
                        else
                        {
                            output.Append(currentDrink);
                        }
                    }
                }

                var salads = recipes.Where(r => r is ISalad).OrderBy(r => r.Name).ToArray();

                if (salads.Any())
                {
                    output.AppendLine("~~~~~ SALADS ~~~~~");
                    for (int i = 0; i < salads.Count(); i++)
                    {
                        var currentSalad = salads[i];
                        if (i != salads.Count() - 1)
                        {
                            output.AppendLine(currentSalad.ToString());
                        }
                        else
                        {
                            output.Append(currentSalad);
                        }
                    }
                }

                var mainCourses = recipes.Where(r => r is IMainCourse).OrderBy(r => r.Name).ToArray();

                var desserts = recipes.Where(r => r is IDessert).OrderBy(r => r.Name).ToArray();

                if (mainCourses.Any())
                {
                    output.AppendLine("~~~~~ MAIN COURSES ~~~~~");
                    for (int i = 0; i < mainCourses.Count(); i++)
                    {
                        var currentMainCourse = mainCourses[i];
                        if (i != mainCourses.Count() - 1)
                        {
                            output.AppendLine(currentMainCourse.ToString());
                        }
                        else
                        {
                            output.Append(currentMainCourse);
                        }
                    }
                    if (desserts.Any())
                    {
                        output.AppendLine();
                    }
                }

                //var desserts = recipes.Where(r => r is IDessert).OrderBy(r => r.Name).ToArray();

                if (desserts.Any())
                {
                    output.AppendLine("~~~~~ DESSERTS ~~~~~");
                    for (int i = 0; i < desserts.Count(); i++)
                    {
                        var currentDessert = desserts[i];
                        if (i != desserts.Count() - 1)
                        {
                            output.AppendLine(currentDessert.ToString());
                        }
                        else
                        {
                            output.Append(currentDessert);
                        }
                    }
                }
            }

            return output.ToString();
        }
    }
}
