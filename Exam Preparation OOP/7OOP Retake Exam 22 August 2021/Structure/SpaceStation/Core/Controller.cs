using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {

        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private IMission mission;
        private int exploredPlanetsCount;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.mission = new Mission();
        }
        public string AddAstronaut(string type, string astronautName)
        {
          
            if(type!=nameof(Biologist)&& 
                type!=nameof(Meteorologist) && 
                type!=nameof(Geodesist))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            IAstronaut astronaut;
            if(type==nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if(type==nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                astronaut = new Geodesist(astronautName);
            }
            this.astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);

        }

        public string AddPlanet(string planetName, params string[] items)
        {
           
            IPlanet planet = new Planet(planetName);
            planets.Add(planet);
            if (items.Length != 0)
            {
                foreach (var item in items)
                {
                    planet.Items.Add(item);

                }

               
            }
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            List<IAstronaut> suitableAstronauts = this.astronauts
               .Models
               .Where(a => a.Oxygen > 60)
               .ToList();

            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            this.mission.Explore(planet,suitableAstronauts);


            this.exploredPlanetsCount++;

            int deadAstronauts = 0;

            foreach (var astronaut in suitableAstronauts)
            {
                if (astronaut.CanBreath == false)
                {
                    deadAstronauts++;
                }
            }

            return string.Format(OutputMessages.PlanetExplored, planet.Name, deadAstronauts);
        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Any())
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
                else
                {
                    sb.AppendLine("Bag items: none");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);
            if(astronaut==null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            astronauts.Remove(astronaut);
            return String.Format(OutputMessages.AstronautRetired, astronautName);



        }
    }
}
