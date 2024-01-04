using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission

 
    {
        private List<IAstronaut> astronauts;
        public Mission()
        {
            this.astronauts = new List<IAstronaut>();
            
        }
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while(true)
            {
                IAstronaut astronaut = astronauts.FirstOrDefault(a => a.CanBreath);
                if(astronaut==null)
                {
                    break;
                }

                while(planet.Items.Count > 0) 
                { 
                    
                    string item = planet.Items.FirstOrDefault();
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                    if(astronaut.Oxygen<0)
                    {
                        break;
                    }
                  
                }
                if(planet.Items.Count==0)
                {
                    break;
                }
            }
            





        }
    }
}
