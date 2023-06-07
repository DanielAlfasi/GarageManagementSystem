using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string,RegisteredVehicle> r_Vehicles;

        public Dictionary<string,RegisteredVehicle> Vehicles
        {
            get { return this.r_Vehicles; }
        }
        
        public GarageManager()
        {
            this.r_Vehicles = new Dictionary<string,RegisteredVehicle>();
        }

        public bool Contains(string i_LicensePlate)
        {
            return r_Vehicles.ContainsKey(i_LicensePlate);
        }

        public RegisteredVehicle GetVehicleByLicensePlate(string i_LicensePlate)
        {
            return r_Vehicles[i_LicensePlate];
        }

        public Vehicle InitVehicle(string i_LicensePlate, eVehicleType i_VehicleType)
        {
            return VehicleGenerator.GenerateNewVehicle(i_LicensePlate, i_VehicleType);
        }

        public void RegisterVehicle(Vehicle i_Vehicle, GarageCard i_GarageCard)
        {
            RegisteredVehicle registeredVehicle = new RegisteredVehicle(i_Vehicle, i_GarageCard);
            r_Vehicles[i_Vehicle.LicensePlate] = registeredVehicle;
        }

        public void ChangeStatus(string i_LicensePlate, GarageCard.eVehicleStatus i_NewStatus)
        {
            r_Vehicles[i_LicensePlate].Card.VehicleStatus = i_NewStatus;
        }

        public void InflateVehicleWheelsToMax(string i_LicensePlate)
        {
            Vehicle vehicleToInflateWheels = this.r_Vehicles[i_LicensePlate].Vehicle;

            foreach (Wheel wheel in vehicleToInflateWheels.Wheels)
            {
                wheel.CurrentPSI = wheel.MaxWheelPSI;
            }
        }

        public Dictionary<string,RegisteredVehicle> GetVehiclesByStatus(GarageCard.eVehicleStatus i_VehicleStatus)
        {
            Dictionary<string, RegisteredVehicle> registeredVehiclesByStatusDict = new Dictionary<string, RegisteredVehicle>();
           
                foreach (string registeredVehicleLicensePlate in r_Vehicles.Keys)
                {
                    if (this.r_Vehicles[registeredVehicleLicensePlate].Card.VehicleStatus == i_VehicleStatus)
                    {
                        registeredVehiclesByStatusDict.Add(registeredVehicleLicensePlate, this.r_Vehicles[registeredVehicleLicensePlate]);
                    }
                }

            return registeredVehiclesByStatusDict;
        }

        public void ChargeBattery(string i_LicensePlate, string i_TimeToChargeString)
        {
            float timeToCharge;

            if (this.r_Vehicles[i_LicensePlate].Vehicle.Engine is ElectricEngine electricEngine)
            {
                if(float.TryParse(i_TimeToChargeString,out timeToCharge))
                {
                    electricEngine.CurrentBatteryLife = float.Parse(i_TimeToChargeString);
                    r_Vehicles[i_LicensePlate].Vehicle.SyncEnergyPercentage();
                }
                else
                {
                    throw new FormatException("Charging parameter is invalid");
                }

            }
            else
            {
                throw new ArgumentException("Cannot charge a gasoline vehicle");
            }
        }

        public void FuelEngine(string i_LicensePlate, string i_LitersToFillString, FuelEngine.eFuelType i_FuelType)
        {
            float litersToFill;

            if (this.r_Vehicles[i_LicensePlate].Vehicle.Engine is FuelEngine fuelEngine)
            {
                if (fuelEngine.FuelType == i_FuelType)
                {
                    if (float.TryParse(i_LitersToFillString, out litersToFill))
                    {
                        fuelEngine.CurrentFuel = float.Parse(i_LitersToFillString);
                        r_Vehicles[i_LicensePlate].Vehicle.SyncEnergyPercentage();
                    }
                    else
                    {
                        throw new FormatException("Fuel parameter is invalid");
                    }
             
                }
                else
                {
                    throw new ArgumentException("Wrong fuel type");
                }
            }
            else
            {
                throw new ArgumentException("Cannot fuel an Electric engine with gasoline");
            }
        }
    }
}
