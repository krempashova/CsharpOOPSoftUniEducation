using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        int coloredEggs = 0;
        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if(bunnyType!="HappyBunny" && bunnyType!="SleepyBunny")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            IBunny bunny;
            if(bunnyType== "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else
            {
                bunny = new SleepyBunny(bunnyName);
            }
            this.bunnies.Add(bunny);
            return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);


        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyName);
            if(bunny==null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);
            bunny.AddDye(dye);

            return String.Format(OutputMessages.DyeAdded, power, bunnyName);

        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            this.eggs.Add(egg);
            return String.Format(OutputMessages.EggAdded, eggName);


        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> suitablebunnies = this.bunnies.Models.Where(c => c.Energy >= 50).ToList();
            IWorkshop workshop = new Workshop();
            IEgg egg = this.eggs.FindByName(eggName);

            if (suitablebunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            while (suitablebunnies.Any())
            {
                IBunny currentbunny = suitablebunnies.First();

                while (true)

                {

                    if (currentbunny.Energy == 0 || currentbunny.Dyes.All(x => x.IsFinished()))
                    {

                        suitablebunnies.Remove(currentbunny);
                        break;
                    }
                    workshop.Color(egg, currentbunny);

                    if (egg.IsDone())
                    {
                        coloredEggs++;
                        break;
                    }
                }

                if (egg.IsDone())
                {
                    break;
                }
            }

            return $"Egg {eggName} is {(egg.IsDone() ? "done" : "not done")}.";

        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{coloredEggs} eggs are done!");
            sb.AppendLine($"Bunnies info:");
            foreach (var  bunny in  bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count(x => !x.IsFinished())} not finished");

            }
            return sb.ToString().TrimEnd();


        }
    }
}
