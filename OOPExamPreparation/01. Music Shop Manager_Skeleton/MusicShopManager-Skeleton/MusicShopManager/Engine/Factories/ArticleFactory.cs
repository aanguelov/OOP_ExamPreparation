namespace MusicShopManager.Engine.Factories
{
    using System;
    using MusicShopManager.Interfaces;
    using MusicShopManager.Interfaces.Engine;
    using MusicShopManager.Models;

    public class ArticleFactory : IArticleFactory
    {
        public IMicrophone CreateMirophone(string make, string model, decimal price, bool hasCable)
        {
            Microphone microphone = new Microphone(make, model, price, hasCable);
            return microphone;
        }

        public IDrums CreateDrums(string make, string model, decimal price, string color, int width, int height)
        {
            Drum drum = new Drum(make, model, price, color, width, height);
            return drum;
        }

        public IElectricGuitar CreateElectricGuitar(string make, string model, decimal price, string color,
            string bodyWood, string fingerboardWood, int numberOfAdapters, int numberOfFrets)
        {
            ElectricGuitar electricGuitar = new ElectricGuitar(make, model, price, color, bodyWood, fingerboardWood,    
                                                                numberOfAdapters, numberOfFrets);
            return electricGuitar;
        }

        public IAcousticGuitar CreateAcousticGuitar(string make, string model, decimal price, string color,
            string bodyWood, string fingerboardWood, bool caseIncluded, StringMaterial stringMaterial)
        {
            AcousticGuitar acousticGuitar = new AcousticGuitar(make, model, price, color, bodyWood, fingerboardWood,
                                                                caseIncluded, stringMaterial);
            return acousticGuitar;
        }

        public IBassGuitar CreateBassGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood)
        {
            BassGuitar bassGuitar = new BassGuitar(make, model, price, color, bodyWood, fingerboardWood);
            return bassGuitar;
        }
    }
}
