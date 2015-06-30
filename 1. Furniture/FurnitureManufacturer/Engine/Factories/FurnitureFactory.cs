namespace FurnitureManufacturer.Engine.Factories
{
    using System;

    using Interfaces;
    using Interfaces.Engine;
    using Models;

    public class FurnitureFactory : IFurnitureFactory
    {
        private const string Wooden = "wooden";
        private const string Leather = "leather";
        private const string Plastic = "plastic";
        private const string InvalidMaterialName = "Invalid material name: {0}";

        public ITable CreateTable(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
        {
            materialType = GetMaterialType(materialType).ToString();

            ITable table = new Table(model, materialType, price, height, length, width);

            return table;
        }

        public IChair CreateChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            materialType = GetMaterialType(materialType).ToString();

            IChair chair = new Chair(model, materialType, price, height, numberOfLegs);

            return chair;
        }

        public IAdjustableChair CreateAdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            materialType = GetMaterialType(materialType).ToString();

            IAdjustableChair adjustableChair = new AdjustableChair(model, materialType, price, height, numberOfLegs);

            return adjustableChair;
        }

        public IConvertibleChair CreateConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            materialType = GetMaterialType(materialType).ToString();

            IConvertibleChair convertibleChair = new ConvertibleChair(model, materialType, price, height, numberOfLegs);

            return convertibleChair;
        }

        private MaterialType GetMaterialType(string material)
        {
            switch (material)
            {
                case Wooden:
                    return MaterialType.Wooden;
                case Leather:
                    return MaterialType.Leather;
                case Plastic:
                    return MaterialType.Plastic;
                default:
                    throw new ArgumentException(string.Format(InvalidMaterialName, material));
            }
        }
    }
}
