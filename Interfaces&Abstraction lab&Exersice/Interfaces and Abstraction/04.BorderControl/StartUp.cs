using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

public class StartUp
    {
        static void Main(string[] args)
        {

            List<IIndentifable> society = new();
            string comand;
            while ((comand=Console.ReadLine())!="End")
            {

                string[] tokens = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 3)
                {
                    IIndentifable citizen = new Citizien(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    society.Add(citizen);

                }                
                else if(tokens.Length==2)
                {
                    IIndentifable robot = new Robots(tokens[0], tokens[1]);
                    society.Add(robot);
                }
            }


            string  fakeid = Console.ReadLine();

            foreach (var item in society)
            {
                if(item.Id.EndsWith(fakeid))
                {
                    Console.WriteLine(item.Id);
                }
            }


        }
    }


