using RestaurantManager.Models;

namespace RestaurantManager.Engine.Factories
{
    using System;
    using RestaurantManager.Interfaces;
    using RestaurantManager.Interfaces.Engine;

    public class RecipeFactory : IRecipeFactory
    {
        public IDrink CreateDrink(string name, decimal price, int calories, int quantityPerServing, 
                                    int timeToPrepare, bool isCarbonated)
        {
            IDrink drink = new Drink(name, price, calories, quantityPerServing, timeToPrepare, isCarbonated);

            return drink;
        }

        public ISalad CreateSalad(string name, decimal price, int calories, int quantityPerServing, 
                                    int timeToPrepare, bool containsPasta)
        {
            ISalad salad = new Salad(name, price, calories, quantityPerServing, timeToPrepare, containsPasta);

            return salad;
        }
        
        public IMainCourse CreateMainCourse(string name, decimal price, int calories, int quantityPerServing, 
                                            int timeToPrepare, bool isVegan, string type)
        {
            IMainCourse mainCourse = new MainCourse(name, price, calories, quantityPerServing, timeToPrepare, isVegan, type);

            return mainCourse;
        }

        public IDessert CreateDessert(string name, decimal price, int calories, int quantityPerServing, 
                                        int timeToPrepare, bool isVegan)
        {
            IDessert dessert = new Dessert(name, price, calories, quantityPerServing, timeToPrepare, isVegan);

            return dessert;
        }
    }
}
