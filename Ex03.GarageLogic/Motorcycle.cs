using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eMotorcycleLicense m_MotorcycleLicense;
        private int m_EngineVolume;
        protected static readonly Dictionary<string, string[]> sr_MotorcycleProperties = new Dictionary<string, string[]>()
        {
            {"Motorcycle license", new string[4] {"B1", "AA", "A1", "A2" } },
            {"Engine volume", null },
        };

        public Motorcycle(string i_LicensePlate, Engine i_Engine, Wheel[] i_Wheels) : base(i_LicensePlate, i_Engine, i_Wheels)
        {
        }

        public eMotorcycleLicense MotorcycleLicense
        {
            get { return this.m_MotorcycleLicense; }
            set { this.m_MotorcycleLicense = value; }
        }

        public int EngineVolume
        {
            get {  return this.m_EngineVolume; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentException("Engine volume cannot be zero and below");
                }

                this.m_EngineVolume = value; 
            }
        }

        public override Dictionary<string, string[]> GetProperties()
        {
            Dictionary<string, string[]> propertiesDictToReturn = new Dictionary<string, string[]>();

            if (base.Engine is FuelEngine)
            {
                propertiesDictToReturn = VehicleProperties.MergeDictionaries(sr_MotorcycleProperties, sr_VehicleProperties);
                propertiesDictToReturn.Add("Current fuel amount", null);
            }
            else
            {
                propertiesDictToReturn = VehicleProperties.MergeDictionaries(sr_MotorcycleProperties, sr_VehicleProperties);
                propertiesDictToReturn.Add("Current battery life", null);
            }

            return propertiesDictToReturn;
        }

        public override void SetProperties(Dictionary<string, string> i_Properties)
        {
            string motorcycleLicenseString = i_Properties["Motorcycle license"];
            string motorcycleEngineVolumeString = i_Properties["Engine volume"];

            r_Engine.SetProperties(i_Properties);
            base.SetProperties(i_Properties);
            setMotorcycleLicense(motorcycleLicenseString);
            setMotorcycleEngineVolume(motorcycleEngineVolumeString);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine(string.Format("Motorcycle license type : {0}   |   Engine Volume : {1}", this.m_MotorcycleLicense.ToString(), this.m_EngineVolume));

            return stringBuilder.ToString();
        }

        public enum eMotorcycleLicense
        {
            B1 = 1,
            AA = 2,
            A1 = 3,
            A2 = 4,
        }

        private void setMotorcycleEngineVolume(string i_MotorcycleEngineVolumeString)
        {
            int motorcycleEngineVolume;

            if (!int.TryParse(i_MotorcycleEngineVolumeString, out motorcycleEngineVolume))
            {
                throw new FormatException("The motorcycle engine volume is invalid");
            }

            this.EngineVolume = motorcycleEngineVolume;
        }

        private void setMotorcycleLicense(string i_MotorcycleLicenseString)
        {
            eMotorcycleLicense motorcycleLicenseEnum;

            if (!int.TryParse(i_MotorcycleLicenseString, out _))
            {
                throw new FormatException("The option you selected for motorcycle license type is invalid");
            }
            else
            {
                if (!Enum.TryParse<eMotorcycleLicense>(i_MotorcycleLicenseString, out motorcycleLicenseEnum))
                {
                    throw new ArgumentException("This motorcycle license is not defined");
                }
            }

            this.m_MotorcycleLicense = motorcycleLicenseEnum;
        }
    }
}
