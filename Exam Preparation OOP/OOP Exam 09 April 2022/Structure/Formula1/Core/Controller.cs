using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Formula1.Core
{
    public class Controller : IController
    {
        PilotRepository pilotRepository;
        RaceRepository raceRepository;
        FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository=new RaceRepository();
            carRepository=new FormulaOneCarRepository();

        }

        public string CreatePilot(string fullName)
        {
           IPilot pilot= pilotRepository.FindByName(fullName);
            if(pilot!=null)
            {
                //exist
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.Models.Any(m=>m.Model==model))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            FormulaOneCar car;
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);

            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            carRepository.Add(car);
            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }
        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = raceRepository.FindByName(raceName);
            if(race!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);
            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);

        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = carRepository.FindByName(carModel);
            if (pilot==null || pilot.Car!=null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
           
            if(car==null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

              pilot.AddCar(car);
            carRepository.Remove(car);
            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName,car.GetType().Name,carModel);

        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.FindByName(raceName);
            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if(pilot==null|| pilot.CanRace==false || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);




        }
        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);
            if(race==null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if(race.Pilots.Count<3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if(race.TookPlace==true)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }
           race.TookPlace=true;
           List<IPilot>orderedPilots=race.Pilots.OrderByDescending(p=>p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();

            orderedPilots[0].WinRace();
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Pilot {orderedPilots[0].FullName} wins the {raceName} race.")
                .AppendLine($"Pilot {orderedPilots[1].FullName} is second in the {raceName} race.")
                .AppendLine($"Pilot {orderedPilots[3].FullName} is third in the {raceName} race.");
            return sb.ToString().TrimEnd();
                
        }
        public string RaceReport()
        {
            List<IRace> executedraces = raceRepository.Models.Where(p => p.TookPlace).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var race in executedraces)
            {
                sb.AppendLine(race.RaceInfo());
            }


            return sb.ToString().TrimEnd();

        }

        public string PilotReport()
        {
            
             List<IPilot>orderedpilots=pilotRepository.Models.OrderByDescending(P=>P.NumberOfWins).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var pilot in orderedpilots)
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();

        }

        
       
    }
}
