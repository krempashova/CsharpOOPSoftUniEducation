using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel,ISubmarine
    {

        private const double submarineArmorThickness = 200;
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, submarineArmorThickness)
        {
            this.SubmergeMode = false;
        }
       
        public bool SubmergeMode { get; private set; }

        public override void RepairVessel()
        {
            this.ArmorThickness = submarineArmorThickness;
        }

        public void ToggleSubmergeMode()
        {
            if(!this.SubmergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
            this.SubmergeMode =! this.SubmergeMode;
        }
        
            public override string ToString()
            {
            StringBuilder sb = new StringBuilder();
            string submergeModeOnOff = this.SubmergeMode ? "ON" : "OFF";

            sb
                .AppendLine(base.ToString())
                .AppendLine($" *Submerge mode: {submergeModeOnOff}");
            return sb.ToString().TrimEnd();
            }
    }
    }

