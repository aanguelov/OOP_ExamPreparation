using RestaurantManager.Interfaces;
using RestaurantManager.Models;

namespace RestaurantManager.Engine.Factories
{
    using System;
    using RestaurantManager.Interfaces.Engine;

    public class RestaurantFactory : IRestaurantFactory
    {
        public IRestaurant CreateRestaurant(string name, string location)
        {
            IRestaurant restaurant = new Restaurant(name, location);

            return restaurant;
        }
    }
}
