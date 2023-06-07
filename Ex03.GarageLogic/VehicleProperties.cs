using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal static class VehicleProperties
    {
        internal static readonly Dictionary<eVehicleType, int> sr_NumOfWheelsDict = new Dictionary<eVehicleType, int>()
        {
            { eVehicleType.Truck, 14 },
            { eVehicleType.ElectricCar, 5 },
            { eVehicleType.RegularCar, 5 },
            { eVehicleType.ElectricMotorcycle, 2 },
            { eVehicleType.RegularMotorcycle, 2 },
        };

        internal static readonly Dictionary<eVehicleType, FuelEngine.eFuelType> sr_FuelTypeDict = new Dictionary<eVehicleType, FuelEngine.eFuelType>()
        {
            { eVehicleType.Truck, FuelEngine.eFuelType.Soler },
            { eVehicleType.RegularCar, FuelEngine.eFuelType.Octan95 },
            { eVehicleType.RegularMotorcycle, FuelEngine.eFuelType.Octan98 },
        };

        internal static readonly Dictionary<eVehicleType, float> sr_MaxWheelPSIDict = new Dictionary<eVehicleType, float>()
        {
            { eVehicleType.Truck, (float)Wheel.eMaxWheelPSI.TruckMaxWheelPSI },
            { eVehicleType.RegularCar, (float)Wheel.eMaxWheelPSI.CarMaxWheelPSI },
            { eVehicleType.ElectricCar, (float)Wheel.eMaxWheelPSI.CarMaxWheelPSI },
            { eVehicleType.RegularMotorcycle, (float)Wheel.eMaxWheelPSI.MotorCycleMaxWheelPSI },
            { eVehicleType.ElectricMotorcycle, (float)Wheel.eMaxWheelPSI.MotorCycleMaxWheelPSI },
        };

        internal static readonly Dictionary<eVehicleType, float> sr_MaxEngineCapacity = new Dictionary<eVehicleType, float>()
        {
            { eVehicleType.Truck, 135f },
            { eVehicleType.RegularCar, 46 },
            { eVehicleType.ElectricCar, 5.2f },
            { eVehicleType.RegularMotorcycle, 6.4f },
            { eVehicleType.ElectricMotorcycle, 2.6f },
        };

        internal static Dictionary<TKey, TValue> MergeDictionaries<TKey, TValue>(Dictionary<TKey, TValue> i_FirstDict, Dictionary<TKey, TValue> i_SecondDict)
        {
            Dictionary<TKey, TValue> mergedDict = new Dictionary<TKey, TValue>(i_FirstDict);

            foreach (var keyValuePair in i_SecondDict)
            {
                mergedDict[keyValuePair.Key] = keyValuePair.Value;
            }

            return mergedDict;
        }
    }
}
