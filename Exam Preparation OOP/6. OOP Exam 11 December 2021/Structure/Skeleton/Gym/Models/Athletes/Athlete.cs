using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        
        public Athlete(string fullName,  string motivation, int stamina, int numberOfMedals)
        {
            FullName = fullName;
           
            Motivation = motivation;
           
            Stamina = stamina;
            NumberOfMedals = numberOfMedals;
            
        }

        public string   FullName 
        {
            get { return fullName; }
             private set 
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }
                
                
                this.fullName = value; 
            }
        }
        private string motivation;

        public string Motivation
        {
            get { return motivation; }
           private set 
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }


                motivation = value;
            
            }
        }
        //You may be needded fild?????
        public int Stamina { get; protected set; }
        private int numberOfMedals;

        public int NumberOfMedals
        {
            get { return numberOfMedals; }
             private set 
            { 
                if(value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }
                
                numberOfMedals = value; 
            
            }
        }

        public abstract void Exercise();
       // SHOULD stamina++;
    }
}
