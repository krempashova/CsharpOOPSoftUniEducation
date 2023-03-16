﻿using Vehicles.IO;
using VehiclesExtension.Core;
using VehiclesExtension.Core.Interfaces;
using VehiclesExtension.Factories.Interfaces;
using VehiclesExtension.IO.Interfaces;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IVehicleFactory vehicleFactory = new VehicleFactory();

IEngine engine = new Engine(reader, writer, vehicleFactory);

engine.Run();