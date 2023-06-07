using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle : IPropertyHolder
    {
        protected string m_ModelName;
        protected float m_EnergyPercentage;
        protected readonly string r_LicensePlate;
        protected readonly Engine r_Engine;
        protected readonly Wheel[] r_Wheels;

        protected static readonly Dictionary<string, string[]> sr_VehicleProperties = new Dictionary<string, string[]>()
        {
            {"Model name", null},
            {"Wheels Manufacturer" , null},
            {"Wheels current PSI", null}
        };

        public Vehicle(string i_LicensePlate, Engine i_Engine, Wheel[] i_Wheels)
        {
            if (string.IsNullOrEmpty(i_LicensePlate))
            {
                throw new ArgumentException("Empty license plate");
            }

            this.r_LicensePlate = i_LicensePlate;
            this.r_Engine = i_Engine;
            this.r_Wheels = i_Wheels;
        }

        public void SyncEnergyPercentage()
        {
            if (this.r_Engine is FuelEngine fuelEngine)
            {
                this.m_EnergyPercentage = (fuelEngine.CurrentFuel / fuelEngine.EngineMaxCapacity) * 100;
            }
            else if (this.r_Engine is ElectricEngine electricEngine)
            {
                this.m_EnergyPercentage = (electricEngine.CurrentBatteryLife / electricEngine.EngineMaxCapacity) * 100;
            }
        }

        public string ModelName
        {
            get { return this.m_ModelName; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException("Model type cannot be empty");
                }

                this.m_ModelName = value;
            }
        }

        public string LicensePlate
        {
            get { return this.r_LicensePlate; }
        }

        public Engine Engine 
        { 
            get { return this.r_Engine;} 
        }

        public Wheel[] Wheels
        {
            get { return this.r_Wheels; }
        }

        public abstract Dictionary<string, string[]> GetProperties();

        public virtual void SetProperties(Dictionary<string, string> i_Properties)
        {
            string modelTypeString = i_Properties["Model name"];
            string wheelManufacturerString = i_Properties["Wheels Manufacturer"];
            string wheelCurrentPSIString = i_Properties["Wheels current PSI"];

            ModelName = modelTypeString;
            setWheelsProperties(wheelManufacturerString, wheelCurrentPSIString);
            SyncEnergyPercentage();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(this.r_Engine.ToString());
            stringBuilder.AppendLine(this.r_Wheels[0].ToString());
            stringBuilder.AppendLine("Vehicle Properties");
            stringBuilder.AppendLine("======================================");
            stringBuilder.AppendLine(string.Format("Model name : {0}   |   License Plate : {1}", this.m_ModelName, this.r_LicensePlate));
            stringBuilder.Append(string.Format("Current energy percentages : {0}%", this.m_EnergyPercentage));

            return stringBuilder.ToString();
        }

        private void setWheelsProperties(string i_WheelManufacturer, string i_WheelCurrentPSI)
        {
            float wheelCurrentPSI;

            if (!float.TryParse(i_WheelCurrentPSI, out wheelCurrentPSI))
            {
                throw new FormatException("Invalid type of current wheel PSI we're given");
            } 

            foreach (Wheel wheel in r_Wheels)
            {
                wheel.CurrentPSI = wheelCurrentPSI;
                wheel.ManufacturerName = i_WheelManufacturer;
            }
        }

    }
    public enum eVehicleType
    {
        Truck = 1,
        ElectricMotorcycle = 2,
        RegularMotorcycle = 3,
        ElectricCar = 4,
        RegularCar = 5,
    }
}
