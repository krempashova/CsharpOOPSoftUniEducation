﻿using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        private UnitRepository units;
        private WeaponRepository weapons;
        private string name;
        private double budget;

        public string Name
        {
            get { return name; }
            private  set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                
                name = value;
            }
        }
        public double  Budget
        {
            get { return budget; }
             private set 
            { 
               if(value<0)
                {
                    throw new ArgumentException(ExceptionMessages.UnsufficientBudget);
                }
                
                
                budget = value; 
            }
        }

        private double militaryPower;

        public double MilitaryPower => Math.Round(this.CalculateMilitaryPower(), 3);



        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }
        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }
        public void Spend(double amount)
        {
           if(this.Budget<amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
             this.Budget -= amount;
        }
        public void Profit(double amount)
        {
            this.Budget += amount;
        }


        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

           
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.Append($"--Forces: ");
            if (this.Army.Count == 0)
            {
                sb.AppendLine("No units");
            }
            else
            {
                var units = new Queue<string>();

                foreach (var item in this.Army)
                {
                    units.Enqueue(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", units));
            }

            sb.Append($"--Combat equipment: ");

            if (this.Weapons.Count == 0)
            {
                sb.AppendLine("No weapons");
            }
            else
            {
                var equipment = new Queue<string>();

                foreach (var item in this.Weapons)
                {
                    equipment.Enqueue(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", equipment));
            }
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().Trim();
        }
   
        private double CalculateMilitaryPower()
        {
            double result = this.units.Models.Sum(x => x.EnduranceLevel) + this.weapons.Models.Sum(x => x.DestructionLevel);
            if (this.units.Models.Any(s=>s.GetType().Name==nameof(AnonymousImpactUnit)))
            {
                result *= 1.3;
            }
            if(this.units.Models.Any(s=>s.GetType().Name==nameof(NuclearWeapon)))
            {
                result *= 1.45;
            }
            return result;
        }
    }
}
