using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;

namespace PlanetWars.Models.MilitaryUnits
{
    public class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel; 
        //eduramceleve may not be set here ?
        public MilitaryUnit(double cost)
        {
            Cost = cost;
       
        }
        public double Cost { get; private set; }

        public int EnduranceLevel { get; private set; }
      


        public void IncreaseEndurance()
        {
            this.EnduranceLevel += 1;
            if(EnduranceLevel>20)
            {
                this.EnduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
