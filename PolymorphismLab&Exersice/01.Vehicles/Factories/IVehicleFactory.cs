using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Factories.Interfaces;

public interface IVehicleFactory
{
    IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
}