using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eCarDoors m_CarDoors;
        protected static readonly Dictionary<string, string[]> sr_CarProperties = new Dictionary<string, string[]>()
        {
            {"Car Color", new string[4] {"White", "Black", "Yellow", "Red" } },
            {"Number of doors", new string[4] {"Two Door", "Three Door", "Four Door", "Five Door"} },
        };

        public Car(string i_LicensePlate, Engine i_Engine, Wheel[] i_Wheels) : base (i_LicensePlate, i_Engine, i_Wheels)
        {
        }

        public override Dictionary<string, string[]> GetProperties()
        {
            Dictionary<string, string[]> propertiesDictToReturn = new Dictionary<string, string[]>();

            if (base.Engine is FuelEngine)
            {
                propertiesDictToReturn = VehicleProperties.MergeDictionaries(sr_CarProperties, sr_VehicleProperties);
                propertiesDictToReturn.Add("Current fuel amount", null);
            }
            else
            {
                propertiesDictToReturn = VehicleProperties.MergeDictionaries(sr_CarProperties, sr_VehicleProperties);
                propertiesDictToReturn.Add("Current battery life", null);
            }
            return propertiesDictToReturn;
        }

        public override void SetProperties(Dictionary<string, string> i_Properties)
        {
            string carDoorsString = i_Properties["Number of doors"];
            string carColorString = i_Properties["Car Color"];

            r_Engine.SetProperties(i_Properties);
            base.SetProperties(i_Properties);
            setNumberOfDoors(carDoorsString);
            setCarColor(carColorString);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine(string.Format("Car color : {0}   |   Car doors : {1}", this.m_CarColor.ToString(), this.m_CarDoors.ToString()));
            return stringBuilder.ToString();
        }

        public enum eCarDoors
        {
            TwoDoors = 1,
            ThreeDoors = 2,
            FourDoors = 3,
            FiveDoors = 4,
        }

        public enum eCarColor
        {
            White = 1,
            Black = 2,
            Yellow = 3,
            Red = 4,
        }

        private void setNumberOfDoors(string i_CarDoorsString)
        {
            eCarDoors carDoorsEnum;

            if (!int.TryParse(i_CarDoorsString, out _))
            {
                throw new FormatException("Invalid option for car doors");
            }
            else
            {
                if (!Enum.TryParse<eCarDoors>(i_CarDoorsString, out carDoorsEnum))
                {
                    throw new ArgumentException("Undefined option for car doors");
                }
            }
            this.m_CarDoors = carDoorsEnum;
        }

        private void setCarColor(string i_CarColorString)
        {
            eCarColor carColorEnum;

            if (!int.TryParse(i_CarColorString, out _))
            {
                throw new FormatException("Invalid type for car color");
            }
            else
            {
                if (!Enum.TryParse<eCarColor>(i_CarColorString, out carColorEnum))
                {
                    throw new ArgumentException("Undefined option for car color");
                }
            }
            this.m_CarColor = carColorEnum;
        }
    }
}
