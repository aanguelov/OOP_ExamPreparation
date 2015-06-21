using System;
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
     public abstract class Article : IArticle
     {
         private string make;
         private string model;
         private decimal price;

         protected Article(string make, string model, decimal price)
         {
             this.Make = make;
             this.Model = model;
             this.Price = price;
         }

         public string Make
         {
             get { return this.make; }
             private set
             {
                 if (string.IsNullOrWhiteSpace(value))
                 {
                     throw new ArgumentException("The make is required.");
                 }
                 this.make = value;
             }
         }

         public string Model
         {
             get { return this.model; }
             private set
             {
                 if (string.IsNullOrWhiteSpace(value))
                 {
                     throw new ArgumentException("The model is required.");
                 }
                 this.model = value;
             }
         }

         public decimal Price
         {
             get { return this.price; }
             private set
             {
                 if (value <= 0)
                 {
                     throw new ArgumentException("The price must be positive.");
                 }
                 this.price = value;
             }
         }

         public override string ToString()
         {
             var output = new StringBuilder();
             output.AppendLine(string.Format("= {0} {1} =", this.Make, this.Model));
             output.Append(string.Format("Price: ${0:F2}", this.Price));
             return output.ToString();
         }
     }
}
