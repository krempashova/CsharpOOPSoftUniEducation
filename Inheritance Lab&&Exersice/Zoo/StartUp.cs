using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var name=Console.ReadLine();    
            Gorilla gorilla = new Gorilla(name);
            Console.WriteLine(gorilla);
        }
    }
}