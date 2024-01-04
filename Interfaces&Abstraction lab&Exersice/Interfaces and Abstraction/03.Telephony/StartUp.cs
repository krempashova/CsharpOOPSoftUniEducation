using System.Numerics;
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] phoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var phoneNumber in phoneNumbers)
            {
                IStatiunaryPhone pnohe;
                if(phoneNumber.Length==7)
                {
                    pnohe = new  StationaryPhone();
                    try
                    {
                        Console.WriteLine(pnohe.Call(phoneNumber));
                    }
                    catch (ArgumentException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    ISmartPhone phone;
                    phone = new Smartphone();
                    try
                    {
                        Console.WriteLine(phone.Call(phoneNumber));
                    }
                    catch (ArgumentException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                }
            }
            foreach (var url in websites)
            {
                ISmartPhone website;
                website = new Smartphone();
                try
                {
                    Console.WriteLine(website.BrowseUrl(url));
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
