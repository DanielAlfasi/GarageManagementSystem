# Garage Management System 

This project is a garage management system implemented in C#. It allows for the registration, management, and servicing of vehicles in a garage.

## Features

Register a new vehicle in the garage.
Display a list of license numbers of all the vehicles in the garage.
Display a list of license numbers of all the vehicles in the garage, filtered by their status.
Change the status of a specific vehicle.
Inflate the wheels of a vehicle to their maximum.
Refuel a gasoline-powered vehicle.
Charge an electric vehicle.
Display full details of a specific vehicle.
Classes

## The project consists of several classes:

Vehicle: An abstract class that represents a vehicle in the garage.
Car, Motorcycle, Truck: Classes that inherit from Vehicle and represent specific types of vehicles.
Engine: An abstract class that represents an engine in a vehicle.
ElectricEngine, FuelEngine: Classes that inherit from Engine and represent specific types of engines.
GarageManager: A class that manages the operations in the garage.
GarageCard: A class that holds the owner's details and the vehicle's status.
RegisteredVehicle: A class that represents a vehicle registered in the garage.
IPropertyHolder: An interface that is implemented by Vehicle and GarageCard.
Installation

Clone the repository: git clone https://github.com/yourusername/GarageManagementSystem.git
Navigate to the project directory: cd GarageManagementSystem
Open the solution file in your preferred C# IDE (like Visual Studio).
Build and run the project.
Usage

Follow the prompts in the console application to manage the vehicles in the garage.

### Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

MIT
