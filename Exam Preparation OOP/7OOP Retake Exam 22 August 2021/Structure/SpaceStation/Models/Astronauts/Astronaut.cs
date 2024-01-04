using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private IBag bag;
        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            this.bag = new Backpack();
        }
        public string Name
        {
            get { return name; }
             private set
             
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                
                
                name = value; 
            }
        }

        private double  oxygen;

        public double  Oxygen
        {
            get { return oxygen; }
           protected   set 
            
            { 
              if(value<0)
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidOxygen);
                }
                
                oxygen = value; 
            }
        }



        public IBag Bag => this.bag;

        public bool CanBreath => true;

        public  virtual void Breath()
        {
            Oxygen -= 10;
        }
    }
}
