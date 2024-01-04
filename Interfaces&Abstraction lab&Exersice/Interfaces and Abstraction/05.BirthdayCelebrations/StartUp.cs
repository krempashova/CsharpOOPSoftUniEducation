namespace BirthdayCelebrations;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

public class StartUp
    {
        static void Main(string[] args)
        {

            List<IBirthtable> society = new();
            string comand;
            while ((comand=Console.ReadLine())!="End")
            {

                string[] tokens = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0]=="Citizen")
                {
                    IBirthtable citizen = new Citizien(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                    society.Add(citizen);


                }                
                else if (tokens[0]=="Pet")
                {
                IBirthtable pet = new Pet(tokens[1], tokens[2]);
                society.Add(pet);
                }
               
            }


            string  year = Console.ReadLine();

            foreach (var element in society)
            {
                if(element.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(element.Birthdate);
                }
            }


        }
    }


