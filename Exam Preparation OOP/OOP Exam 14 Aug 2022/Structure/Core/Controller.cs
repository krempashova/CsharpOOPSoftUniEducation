using PlanetWars.Core.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.MilitaryUnits;
using System.Linq;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Models.Weapons;
using System.Reflection;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {

            if (planets.FindByName(name) != null)
            {

                return string.Format(OutputMessages.ExistingPlanet, name);

            }

            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);


        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                return string.Format(ExceptionMessages.UnexistingPlanet, planetName);
            }
            if (unitTypeName != nameof(AnonymousImpactUnit) &&
                unitTypeName != nameof(SpaceForces) &&
                unitTypeName != nameof(StormTroopers))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit militaryUnit;
            if (unitTypeName == nameof(SpaceForces))
            {
                militaryUnit = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                militaryUnit = new StormTroopers();
            }
            else
            {
                militaryUnit = new AnonymousImpactUnit();
            }

            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);

            return string.Format(OutputMessages.UnitAdded, militaryUnit.GetType().Name, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (planet.Weapons.Any(p => p.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }


            if (weaponTypeName != nameof(BioChemicalWeapon)
                && weaponTypeName != nameof(NuclearWeapon) &&
                weaponTypeName != nameof(SpaceMissiles))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weapon;
            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else
            {
                weapon = new SpaceMissiles(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);

        }
        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }
            double specializeCost = 1.25;
            planet.Spend(specializeCost);
            planet.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);


            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if (firstPlanet.Weapons.Any(c => c.GetType().Name == nameof(NuclearWeapon))
                && secondPlanet.Weapons.Any(c => c.GetType().Name == nameof(NuclearWeapon))
                || firstPlanet.Weapons.Any(c => c.GetType().Name != nameof(NuclearWeapon))
                && secondPlanet.Weapons.Any(c => c.GetType().Name != nameof(NuclearWeapon)))
                {
                    //both loose
                    double halfBudgetFirstplanet = firstPlanet.Budget / 2;
                    double halfBudgetsecondPlanet = secondPlanet.Budget / 2;

                    return OutputMessages.NoWinner;
                }
                if (secondPlanet.Weapons.Any(c => c.GetType().Name == nameof(NuclearWeapon)))
                {
                    //secondPlanet wins
                    double halfBudgetsec = secondPlanet.Budget / 2;
                    double halfBudgetgirst = firstPlanet.Budget / 2;
                    double totbud = halfBudgetsec + halfBudgetgirst;
                    double morefromlooser = firstPlanet.Army.Sum(c => c.Cost) + firstPlanet.Weapons.Sum(y => y.Price);
                    totbud += morefromlooser;

                    planets.RemoveItem(firstPlanet.Name);
                    return string.Format(OutputMessages.WinnigTheWar, secondPlanet, firstPlanet);

                }
               else  if (firstPlanet.Weapons.Any(c => c.GetType().Name == nameof(NuclearWeapon)))
                {
                    //first Win
                  double  halfBudgetsecond = secondPlanet.Budget / 2;
                    double halfBudgetfirst = firstPlanet.Budget / 2;
                    double totalwinner = halfBudgetsecond + halfBudgetfirst;
                    double moretoadd = secondPlanet.Army.Sum(c => c.Cost) + secondPlanet.Weapons.Sum(n => n.Price);
                    totalwinner += moretoadd;
                    planets.RemoveItem(secondPlanet.Name);
                    return string.Format(OutputMessages.WinnigTheWar, firstPlanet, secondPlanet);
                }
            }
            else if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {//first win:

                double halfBudgetse = secondPlanet.Budget / 2;
                double halfBudgetfi = firstPlanet.Budget / 2;
                double totalwinnerbudget = halfBudgetse + halfBudgetfi;
                double moretoaddfromlose = secondPlanet.Army.Sum(c => c.Cost) + secondPlanet.Weapons.Sum(n => n.Price);
                totalwinnerbudget += moretoaddfromlose;
                planets.RemoveItem(secondPlanet.Name);
                return string.Format(OutputMessages.WinnigTheWar, firstPlanet, secondPlanet);

                //second win:

            }
            
                double halfBudget2 = secondPlanet.Budget / 2;
                double halfBudget1 = firstPlanet.Budget / 2;
                double TOTALBUDGET = halfBudget2 + halfBudget1;
                double moretoaddfromlosser = firstPlanet.Army.Sum(c => c.Cost) + firstPlanet.Weapons.Sum(y => y.Price);
                TOTALBUDGET += moretoaddfromlosser;

                planets.RemoveItem(firstPlanet.Name);
                return string.Format(OutputMessages.WinnigTheWar, secondPlanet, firstPlanet);
            
            
        }

        public string ForcesReport()
        {


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in this.planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

      

    }




    }

