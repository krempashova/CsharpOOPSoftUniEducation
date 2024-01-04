using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Race : IRace
    {

        private string raceName;
        private int numberOfLaps;
        private ICollection<IPilot> pilots;
        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get { return raceName; }
           private  set {



                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }



                raceName = value; 
            }
        }
       

        public int NumberOfLaps
        {
            get { return numberOfLaps; }
           private  set 
            { 
                if(value<1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                
                numberOfLaps = value; 
            
            }
        }

        public bool TookPlace { get;   set ; }

       
       

        public ICollection<IPilot> Pilots
        {
            get { return pilots; }
          
        }


        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);

        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"The {RaceName} race has:")
                .AppendLine($"Participants: {pilots.Count}")
                .AppendLine($"Number of laps: {NumberOfLaps}")
                .AppendLine($"Took place: {(TookPlace ? "YES" : "NO")}");
            return sb.ToString().TrimEnd();



        }
    }
}
