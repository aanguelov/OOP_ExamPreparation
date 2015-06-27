using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Category : ICategory
    {
        private const int MinNameSymbols = 2;
        private const int MaxNameSymbols = 15;

        private string name;
        //private readonly IList<IProduct> categoryProducts;

        public Category(string name)
        {
            this.Name = name;
            this.CategoryProducts = new List<IProduct>();
        }

        public IList<IProduct> CategoryProducts { get; set; }

        public string Name
        {
            get { return this.name; }
            set
            {
                //if (value.Length < MinNameSymbols || value.Length > MaxNameSymbols)
                //{
                //    throw new IndexOutOfRangeException(string.Format(GlobalErrorMessages.InvalidStringLength, 
                //        "Category name", MinNameSymbols, MaxNameSymbols));
                //}
                Validator.CheckIfStringLengthIsValid(value, MaxNameSymbols, MinNameSymbols,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", MinNameSymbols, MaxNameSymbols));
                this.name = value;
            }
        }
        public void AddCosmetics(IProduct cosmetics)
        {
            this.CategoryProducts.Add(cosmetics);
            //this.categoryProducts
            //    .OrderBy(p => p.Brand)
            //    .ThenByDescending(p => p.Price);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.CategoryProducts.Contains(cosmetics))
            {
                throw new ArgumentException(string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }
            else
            {
                this.CategoryProducts.Remove(cosmetics);
            }
        }

        public string Print()
        {
            var output = new StringBuilder();

            var products = this.CategoryProducts
                .OrderBy(p => p.Brand)
                .ThenByDescending(p => p.Price)
                .ToArray();
            if (products.Count() > 1)
            {
                output.AppendLine(string.Format("{0} category - {1} products in total", this.Name, products.Count()));

                for (int i = 0; i < products.Count(); i++)
                {
                    var currentProduct = products[i];
                    if (i != products.Count() - 1)
                    {
                        output.AppendLine(currentProduct.Print());
                    }
                    else
                    {
                        output.Append(currentProduct.Print());
                    }
                }
            }
            else if (!products.Any())
            {
                output.Append(string.Format("{0} category - {1} products in total", this.Name, products.Count()));
            }
            else
            {
                output.AppendLine(string.Format("{0} category - 1 product in total", this.Name));
                var product = products.FirstOrDefault();
                output.Append(product.Print());
            }

            return output.ToString();
        }
    }
}
