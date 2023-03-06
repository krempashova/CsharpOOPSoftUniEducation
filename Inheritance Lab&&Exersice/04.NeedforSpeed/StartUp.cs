using NeedforSpeed;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new(200, 100);
            SportCar sportCar = new SportCar(100, 100);
            RaceMotorcycle raceMotorcycle = new(100, 100);
            sportCar.Drive(10);
            Console.WriteLine(sportCar.Fuel);
        }
    }
}
