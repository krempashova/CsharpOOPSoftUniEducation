using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private Vessel()
        {
            this.Targets = new List<string>();
        }
        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
            :this()
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
        }
        private string name;

        public string Name
        {
           get { return name; }
           private  set 
            
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name),ExceptionMessages.InvalidVesselName);
                }
                 name = value; }
        }
        private ICaptain captain;

        public ICaptain Captain
        {
            get { return captain; }
            set {
                
                if(value==null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainName);
                }
                
                captain = value; }
        }

        public double ArmorThickness { get; set; }
      
        public double MainWeaponCaliber { get; protected set; }
      
        public double Speed { get; protected set; }
       
        public ICollection<string> Targets { get; private set; }

        public void Attack(IVessel target)
        {
            if(target==null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;
            if(target.ArmorThickness<0)
            {
                target.ArmorThickness = 0;
            }
            this.Targets.Add(target.Name);
            this.Captain.IncreaseCombatExperience();
            target.Captain.IncreaseCombatExperience();
        }

        public abstract void RepairVessel();
        public override string ToString()
        {

            string targetOutput = this.Targets.Any() ?
                String.Join(", ", this.Targets) : "None";
            StringBuilder sb = new StringBuilder();
            sb
             .AppendLine($"- {this.Name}")
            .AppendLine($" *Type: {this.GetType().Name}")
            .AppendLine($" *Armor thickness: {this.ArmorThickness}")
            .AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}")
            .AppendLine($" *Speed: {this.Speed} knots")
            .AppendLine($" *Targets: {targetOutput} ");
            return sb.ToString().TrimEnd();
        }

       
    }
}
