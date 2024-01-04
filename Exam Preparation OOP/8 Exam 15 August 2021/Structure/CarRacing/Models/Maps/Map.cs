using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            IRacer racer;
            if (racerOne.IsAvailable()==false  && racerTwo.IsAvailable()==false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if(racerOne.IsAvailable()==true && racerTwo.IsAvailable()==false) 
            { 
            
            //racerOne wins
            return string.Format(OutputMessages.OneRacerIsNotAvailable,racerOne.Username,racerTwo.Username);  
            
            }
            else if(racerOne.IsAvailable() == false && racerTwo.IsAvailable() == true)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else

            {
                racerOne.Race();

                double chanceOfWiningOne = 1;
                if (racerOne.RacingBehavior == "strict")
                {
                    chanceOfWiningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.2;
                }
                else if (racerOne.RacingBehavior == "aggressive")
                {
                    chanceOfWiningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.1;
                }
                racerTwo.Race();
                double chanceOfWiningTwo = 1;
                if (racerTwo.RacingBehavior == "strict")
                {
                    chanceOfWiningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.2;
                }
                else if (racerTwo.RacingBehavior == "aggressive")
                {
                     chanceOfWiningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.1;
                }
                string result = string.Empty;
               if(chanceOfWiningOne>chanceOfWiningTwo)
                {
                    //one win
                    result = string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
                }
               else

                {
                    //two win
                    result = string.Format(OutputMessages.RacerWinsRace, racerTwo.Username, racerOne.Username, racerTwo.Username);
                }
                return result;
            }



        }
    }
}
