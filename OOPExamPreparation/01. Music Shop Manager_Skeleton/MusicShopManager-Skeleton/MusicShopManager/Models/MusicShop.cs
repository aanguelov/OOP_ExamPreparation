using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicShopManager.Engine;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class MusicShop : IMusicShop
    {
        private string name;

        public MusicShop(string name)
        {
            this.Name = name;
            this.Articles = new List<IArticle>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("name", "The name is required.");
                }
                this.name = value;
            }
        }
        public IList<IArticle> Articles { get; private set; }

        public void AddArticle(IArticle article)
        {
            this.Articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            this.Articles.Remove(article);
        }

        public string ListArticles()
        {
            var list = new StringBuilder();
            list.AppendLine(string.Format("===== {0} =====", this.Name));
            if (this.Articles.Count > 0)
            {
                //var articles = this.Articles.OrderBy(a => a.GetType() == typeof (Microphone))
                //    .ThenBy(a => a.GetType() == typeof (Drum))
                //    .ThenBy(a => a.GetType() == typeof (ElectricGuitar))
                //    .ThenBy(a => a.GetType() == typeof (AcousticGuitar))
                //    .ThenBy(a => a.GetType() == typeof (BassGuitar));
                var microphones = this.Articles
                    .Where(a => a.GetType() == typeof (Microphone))
                    .OrderBy(a => a.Make)
                    .ThenBy(a => a.Model);
                if (microphones.Any())
                {
                    list.AppendLine("----- Microphones -----");
                    foreach (var microphone in microphones)
                    {
                        list.AppendLine(microphone.ToString());
                    }
                }
                var drums = this.Articles
                    .Where(a => a.GetType() == typeof(Drum))
                    .OrderBy(a => a.Make)
                    .ThenBy(a => a.Model);
                if (drums.Any())
                {
                    list.AppendLine("----- Drums -----");
                    foreach (var drum in drums)
                    {
                        list.AppendLine(drum.ToString());
                    }
                }

                var electric = this.Articles
                    .Where(a => a.GetType() == typeof(ElectricGuitar))
                    .OrderBy(a => a.Make)
                    .ThenBy(a => a.Model);
                if (electric.Any())
                {
                    list.AppendLine("----- Electric guitars -----");
                    foreach (var guitar in electric)
                    {
                        list.AppendLine(guitar.ToString());
                    }
                }

                var acoustic = this.Articles
                    .Where(a => a.GetType() == typeof(AcousticGuitar))
                    .OrderBy(a => a.Make)
                    .ThenBy(a => a.Model);
                if (acoustic.Any())
                {
                    list.AppendLine("----- Acoustic guitars -----");
                    foreach (var guitar in acoustic)
                    {
                        list.AppendLine(guitar.ToString());
                    }
                }

                var bass = this.Articles
                    .Where(a => a.GetType() == typeof(BassGuitar))
                    .OrderBy(a => a.Make)
                    .ThenBy(a => a.Model);
                if (bass.Any())
                {
                    list.AppendLine("----- Bass guitars -----");
                    foreach (var guitar in bass)
                    {
                        list.AppendLine(guitar.ToString());
                    }
                }
            }
            else
            {
                list.AppendLine("The shop is empty. Come back soon.");
            }
            return list.ToString();
        }
    }
}
