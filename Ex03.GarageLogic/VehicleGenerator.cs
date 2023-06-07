namespace Ex03.GarageLogic
{
    internal static class VehicleGenerator
    {
        public static Vehicle GenerateNewVehicle(string i_LicensePlate, eVehicleType i_VehicleType)
        {
            Vehicle vehicle;
            Engine engine = generateEngine(i_VehicleType);
            Wheel[] wheels = generateWheels(i_VehicleType);

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    vehicle = new Car(i_LicensePlate, engine as ElectricEngine, wheels);
                    break;

                case eVehicleType.RegularCar:
                    vehicle = new Car(i_LicensePlate, engine as FuelEngine, wheels);
                    break;

                case eVehicleType.ElectricMotorcycle:
                    vehicle = new Motorcycle(i_LicensePlate, engine as ElectricEngine, wheels);
                    break;

                case eVehicleType.RegularMotorcycle:
                    vehicle = new Motorcycle(i_LicensePlate, engine as FuelEngine, wheels);
                    break;

                case eVehicleType.Truck:
                    vehicle = new Truck(i_LicensePlate, engine as FuelEngine, wheels);
                    break;

                default:
                    vehicle = null;
                    break;
            }

            return vehicle;
        }

        private static Wheel[] generateWheels(eVehicleType i_VehicleType)
        {
            Wheel[] wheels = new Wheel[VehicleProperties.sr_NumOfWheelsDict[i_VehicleType]];

            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i] = new Wheel(VehicleProperties.sr_MaxWheelPSIDict[i_VehicleType]);
            }

            return wheels;
        }

        private static Engine generateEngine(eVehicleType i_VehicleType)
        {
            Engine engine = null;

            if (i_VehicleType == eVehicleType.ElectricCar || i_VehicleType == eVehicleType.ElectricMotorcycle)
            {
                engine = new ElectricEngine(VehicleProperties.sr_MaxEngineCapacity[i_VehicleType]);
            }
            else if (i_VehicleType == eVehicleType.RegularCar || i_VehicleType == eVehicleType.RegularMotorcycle || i_VehicleType == eVehicleType.Truck)
            {
                engine = new FuelEngine(VehicleProperties.sr_FuelTypeDict[i_VehicleType], VehicleProperties.sr_MaxEngineCapacity[i_VehicleType]);
            }

            return engine;

        }

    }
}
