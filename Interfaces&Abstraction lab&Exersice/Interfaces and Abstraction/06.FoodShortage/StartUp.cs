using FoodShortage.Models;
using FoodShortage.Models.Interfaces;
using System.Linq;

namespace FoodShortage;



public class StartUp
{
    static void Main(string[] args)
    {

        List<IBuyer> buyers = new();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] info = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (info.Length == 4)
            {
                IBuyer citizen = new Citizien(info[0], int.Parse(info[1]), info[2], info[3]);
                buyers.Add(citizen);
            }
            else if (info.Length == 3)
            {

                IBuyer rebels = new Rebel(info[0], int.Parse(info[1]), info[2]);
                buyers.Add(rebels);

            }
        }
        string comand;
        while ((comand = Console.ReadLine()) != "End")
        {

            
            buyers.FirstOrDefault(buyer => buyer.Name == comand)?.BuyFood();



        }
        Console.WriteLine(buyers.Sum(b => b.Food));
    }
}



