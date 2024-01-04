using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        public Egg(string name,  int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public string Name
        {
            get { return name; }
           private set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }
                
                
                name = value; 
            }
        }

        private int energyRequired;

        public int EnergyRequired
        {
            get { return energyRequired; }
           private  set 
            { 
                if(value<0)
                {
                    value = 0;
                }
                
                energyRequired = value;
            
            }
        }

        public void GetColored()
        {
            this.EnergyRequired -= 10;
            if(EnergyRequired<0)
            {
                this.EnergyRequired = 0;
            }
        }

        public bool IsDone()
        {
           if(this.EnergyRequired==0)
            {
                return true;

            }
            return false;
        }
    }
}
