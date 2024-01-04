using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        {
            get { return fullName; }
             private set 
            
            
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }

                fullName = value; 
            
            
            }
        }
        public IFormulaOneCar Car
        {
            get { return  car; }
          private   set 
            { 
                if(value== null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                
                
                IFormulaOneCar car = value; 
            }
        }


       
        public int NumberOfWins { get; private set; }

        public bool CanRace { get; private set; }

        public void AddCar(IFormulaOneCar car)
        {

            this.car=car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Pilot {FullName} has {NumberOfWins} wins.");
            return sb.ToString().TrimEnd();
        }
    }
}
