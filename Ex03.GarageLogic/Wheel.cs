using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private readonly float r_MaxWheelPSI;
        private float m_CurrentPSI;

        public Wheel(float i_MaxWheelPSI)
        {
            this.r_MaxWheelPSI = i_MaxWheelPSI;
        }

        public string ManufacturerName
        {
            get { return this.m_ManufacturerName; }
            set
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Empty Manufacturer name");
                }

                this.m_ManufacturerName = value;
            }
        }

        public float MaxWheelPSI
        {
            get { return this.r_MaxWheelPSI; }
        }

        public float CurrentPSI
        {
            get { return this.m_CurrentPSI; }
            set
            {
                if (value >= 0 && value <= r_MaxWheelPSI)
                {
                    this.m_CurrentPSI = value;
                }
                else
                {
                    throw new ValueOutOfRangeException("wheel PSI", 0 , r_MaxWheelPSI);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Wheel");
            stringBuilder.AppendLine("======================================");
            stringBuilder.AppendLine(string.Format("Wheel Manufacturer : {0}   |   Current Air Pressure : {1}   |   Max Air Pressure : {2}", this.m_ManufacturerName,this.m_CurrentPSI, this.r_MaxWheelPSI));

            return stringBuilder.ToString();
        }

        public enum eMaxWheelPSI
        {
            MotorCycleMaxWheelPSI = 31,
            CarMaxWheelPSI = 33,
            TruckMaxWheelPSI = 26,
        }
    }
}
