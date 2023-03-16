namespace Vehicles.IO;
    using System;
    using VehiclesExtension.IO.Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
       => Console.ReadLine();
    }




