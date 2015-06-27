using System;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        private const int MinProductNameLength = 3;
        private const int MaxProductNameLength = 10;

        private const int MinProductBrandLength = 2;
        private const int MaxProductBrandLength = 10;

        private string name;
        private string brand;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                //if (value.Length < MinProductNameLength || value.Length > MaxProductNameLength)
                //{
                //    throw new IndexOutOfRangeException(string.Format(GlobalErrorMessages.InvalidStringLength,
                //        "Product name", MinProductNameLength, MaxProductNameLength));
                //}
                Validator.CheckIfStringLengthIsValid(value, MinProductNameLength, MaxProductNameLength,
                                                        string.Format(GlobalErrorMessages.InvalidStringLength,
                                                        "Product name", MinProductNameLength, MaxProductNameLength));
                this.name = value;
            }
        }

        public string Brand
        {
            get { return this.brand; }
            private set
            {
                //if (value.Length < MinProductBrandLength || value.Length > MaxProductBrandLength)
                //{
                //    throw new IndexOutOfRangeException(string.Format(GlobalErrorMessages.InvalidStringLength,
                //        "Product brand", MinProductBrandLength, MaxProductBrandLength));
                //}

                Validator.CheckIfStringLengthIsValid(value, MinProductBrandLength, MaxProductBrandLength,
                                                        string.Format(GlobalErrorMessages.InvalidStringLength,
                                                        "Product brand", MinProductBrandLength, MaxProductBrandLength));
                this.brand = value;
            }
        }

        public decimal Price { get; set; }

        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            output.AppendLine(string.Format("  * Price: ${0}", this.Price));
            output.Append(string.Format("  * For gender: {0}", this.Gender));

            return output.ToString();
        }
    }
}
