using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;
        private float m_CurrentFuel;

        public FuelEngine(eFuelType i_FuelType, float i_MaxFuelCapacity) : base (i_MaxFuelCapacity)
        {
            this.r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get { return this.r_FuelType; }
        }

        public float CurrentFuel
        {
            get { return this.m_CurrentFuel; }
            set
            {
                if (value + this.CurrentFuel <= base.EngineMaxCapacity && value >= 0)
                {
                    this.m_CurrentFuel += value;
                }
                else
                {
                    throw new ValueOutOfRangeException("current fuel amount", 0 , base.EngineMaxCapacity - this.m_CurrentFuel);
                }
            }
        }

        public override void SetProperties(Dictionary<string, string> i_Properties)
        {
            string currentFuelString = i_Properties["Current fuel amount"];
            float currentFuel;

            if (!float.TryParse(currentFuelString, out currentFuel))
            {
                throw new FormatException("Please provide a decimal number for the current fuel amount");
            }
            else
            {
                CurrentFuel = currentFuel;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine(string.Format("Engine current fuel : {0}   |   Fuel type : {1}", this.m_CurrentFuel, this.r_FuelType.ToString()));

            return stringBuilder.ToString();
        }

        public enum eFuelType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4,
        }
    }
}
