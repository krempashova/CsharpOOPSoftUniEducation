using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IVessel> vessels;
        private readonly ICollection<ICaptain> captains;
        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new HashSet<ICaptain>();
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {

            ICaptain captaintoAssing = this.captains.FirstOrDefault(S => S.FullName == selectedCaptainName);
            if (captaintoAssing==null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            IVessel vesseltoassing = this.vessels.FindByName(selectedVesselName);
            if(vesseltoassing==null)
            {


               return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            
            if(vesseltoassing.Captain!=null)
            {
               return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            vesseltoassing.Captain = captaintoAssing;
            captaintoAssing.AddVessel(vesseltoassing);

             return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName,selectedVesselName);

        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel vesselAttacked = this.vessels.FindByName(attackingVesselName);
           
            if(vesselAttacked==null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            IVessel vesselDefend = this.vessels.FindByName(defendingVesselName);
            if (vesselDefend==null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if(vesselAttacked.ArmorThickness==0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, vesselAttacked);
            }

            if(vesselDefend.ArmorThickness==0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, vesselDefend.Name);
            }


                vesselAttacked.Attack(vesselDefend);
                return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, vesselDefend.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = this.captains.First(c => c.FullName == captainFullName);
            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);
            if(captains.Any(s=>s.FullName==fullName))
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            captains.Add(captain);
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);

        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = vessels.FindByName(name);
           if(vessel!=null)
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, this.vessels.GetType().Name, name);
            }


            IVessel producevessel;
            if(vesselType== "Battleship")
            {
                producevessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if(vesselType=="Submarine")
            {
                producevessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }

          
            this.vessels.Add(producevessel);
            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);

        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vesseltorepair = this.vessels.FindByName(vesselName);
            if(vesseltorepair==null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
            else
            {
                vesseltorepair.RepairVessel();
                return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
            }



        }

        public string ToggleSpecialMode(string vesselName)
        {

            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel.GetType().Name == "Battleship")
            {
                Battleship vesselBattleship = (Battleship)vessel;
                vesselBattleship.ToggleSonarMode();
                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {

                Submarine vesseltosubmarine = (Submarine)vessel;
                vesseltosubmarine.ToggleSubmergeMode();
                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);

            }
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);
           
                return vessel?.ToString();
                     
        }
    }
}
