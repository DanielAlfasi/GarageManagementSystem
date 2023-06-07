using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsCarryingDangerousGoods;
        private float m_CargoVolume;
        protected static readonly Dictionary<string, string[]> sr_TruckProperties = new Dictionary<string, string[]>()
        {
            {"Needs to support Dangerous Goods", new string[2] {"Supports dangerous goods" , "Doesn't supports dangerous goods"} },
            {"Cargo Volume" , null},
        };

        public Truck(string i_LicensePlate, Engine i_Engine, Wheel[] i_Wheels) : base(i_LicensePlate, i_Engine, i_Wheels)
        {
        }

        public float CargoVolume
        {
            get { return this.m_CargoVolume; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Cargo volume is invalid");
                }

                this.m_CargoVolume = value;
            }
        }

        public override Dictionary<string, string[]> GetProperties()
        {
            Dictionary<string , string[]> propertiesDictToReturn = new Dictionary<string , string[]>();

            if(base.Engine is FuelEngine)
            {
                propertiesDictToReturn = VehicleProperties.MergeDictionaries(sr_TruckProperties, sr_VehicleProperties);
                propertiesDictToReturn.Add("Current fuel amount", null);
            }
            else
            {
                propertiesDictToReturn = VehicleProperties.MergeDictionaries(sr_TruckProperties, sr_VehicleProperties);
                propertiesDictToReturn.Add("Current battery life", null);
            }

            return propertiesDictToReturn;
        }

        public override void SetProperties(Dictionary<string, string> i_Properties)
        {
            string isCarryingDangerousGoodsString = i_Properties["Needs to support Dangerous Goods"];
            string cargoVolumeString = i_Properties["Cargo Volume"];

            r_Engine.SetProperties(i_Properties);
            base.SetProperties(i_Properties);
            setCargoVolume(cargoVolumeString);
            setIsCarryingDangerousGoods(isCarryingDangerousGoodsString);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine(string.Format("Is carrying dangerous goods : {0}   |   Cargo volume : {1}", this.m_IsCarryingDangerousGoods.ToString(), this.m_CargoVolume));

            return stringBuilder.ToString();
        }

        private void setIsCarryingDangerousGoods(string i_IsCarryingDangerousGoodsString)
        {
            if (i_IsCarryingDangerousGoodsString == "1")
            {
                this.m_IsCarryingDangerousGoods = true;
            }
            else if (i_IsCarryingDangerousGoodsString == "2")
            {
                this.m_IsCarryingDangerousGoods = false;
            }
            else
            {
                throw new FormatException("The option you selected for Dangerous Goods is invalid");
            }

        }

        private void setCargoVolume(string i_CargoVolumeString)
        {
            float cargoVolume;

            if (!float.TryParse(i_CargoVolumeString, out cargoVolume))
            {
                throw new FormatException("Need to provide a decimal number for for the cargo volume");
            }

            CargoVolume = cargoVolume;
        }
    }
}
