using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("Name cannot be empty, null or with less than 5 symbols.");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            private set
            {
                if (value.Length != 10 || !this.CheckIfRegNumberContainsOnlyDigits(value))
                {
                    throw new ArgumentException("Registration number must be exactly 10 symbols and must contain only digits.");
                }
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures { get; private set; }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            var furniture = this.Furnitures.FirstOrDefault(f => f.Model == model);
            return furniture;
        }

        public string Catalog()
        {
            var result = new StringBuilder();

            string count = this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no";
            string furnitures = this.Furnitures.Count != 1 ? "furnitures" : "furniture";
            var companyFurniture = this.Furnitures
                .OrderBy(f => f.Price)
                .ThenBy(f => f.Model).ToArray();

            if (companyFurniture.Any())
            {
                result.AppendLine(string.Format("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber, count, furnitures));

                for (int i = 0; i < companyFurniture.Count(); i++)
                {
                    var current = companyFurniture[i];
                    if (i != companyFurniture.Count() - 1)
                    {
                        result.AppendLine(companyFurniture[i].ToString());
                    }
                    else
                    {
                        result.Append(companyFurniture[i]);
                    }
                }
            }
            else
            {
                result.Append(string.Format("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber, count, furnitures));
            }

            return result.ToString();
        }

        public bool CheckIfRegNumberContainsOnlyDigits(string value)
        {
            bool contains = true;
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsDigit(value[i]))
                {
                    contains = false;
                }
            }
            return contains;
        }
    }
}
