using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
      
        private  Captain()
        {
            this.CombatExperience = 0;
            this.Vessels = new HashSet<IVessel>();
        }
        public Captain(string fullName)
            :this()
        {
            FullName = fullName;
           
        }

        private string fullName;

        public string FullName
        {
            get { return fullName; }
           private  set 
            { 
                if(string.IsNullOrWhiteSpace(value))

                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName,nameof(value));
                }
                
                fullName = value; }
        }

       

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels { get; private set; }

        public void AddVessel(IVessel vessel)
        {
            if(vessel==null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            this.Vessels.Add(vessel);


        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");

            foreach (var vessel in Vessels)
            {
                sb.AppendLine(vessel.ToString());
            }

            return sb.ToString().TrimEnd();
            
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
