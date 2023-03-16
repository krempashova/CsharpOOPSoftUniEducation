using VehiclesExtension.IO.Interfaces;

namespace Vehicles.IO
{

    public class ConsoleWriter : IWriter
    {
        public ConsoleWriter()
        {
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        => Console.WriteLine(text);
    }
}
