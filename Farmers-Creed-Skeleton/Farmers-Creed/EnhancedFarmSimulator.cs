using System.Linq;
using FarmersCreed.Interfaces;
using FarmersCreed.Simulator;
using FarmersCreed.Units;

namespace FarmersCreed
{
    public class EnhancedFarmSimulator : FarmSimulator
    {
        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "CherryTree":
                    var cherryTree = new CherryTree(id);
                    this.farm.Plants.Add(cherryTree);
                    break;
                case "TobaccoPlant":
                    var tobaccoPlant = new TobaccoPlant(id);
                    this.farm.Plants.Add(tobaccoPlant);
                    break;
                case "Cow":
                    var cow = new Cow(id);
                    this.farm.Animals.Add(cow);
                    break;
                case "Swine":
                    var pig = new Swine(id);
                    this.farm.Animals.Add(pig);
                    break;
                default:
                    base.AddObjectToFarm(inputCommands);
                    break;
            }
        }

        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');

            string action = inputCommands[0];

            switch (action)
            {
                case "feed":
                    var animal = this.farm.Animals.FirstOrDefault(a => a.Id == inputCommands[1]);
                    var food = this.farm.Products.FirstOrDefault(p => p.Id == inputCommands[2]) as Food;
                    int quantity = int.Parse(inputCommands[3]);
                    this.farm.Feed(animal, food, quantity);
                    break;
                case "water":
                    var plant = this.farm.Plants.FirstOrDefault(p => p.Id == inputCommands[1]);
                    this.farm.Water(plant);
                    break;
                case "exploit":
                    if (inputCommands[1] == "animal")
                    {
                        var animalToExploit = this.farm.Animals.FirstOrDefault(a => a.Id == inputCommands[2]) as IProductProduceable;
                        this.farm.Exploit(animalToExploit);
                    }
                    else
                    {
                        var plantToExploit = this.farm.Plants.FirstOrDefault(p => p.Id == inputCommands[2]) as IProductProduceable;
                        this.farm.Exploit(plantToExploit);
                    }
                    break;
                default:
                    base.ProcessInput(input);
                    break;
            }
        }
    }
}
