using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private float m_CurrentBatteryLife;

        public ElectricEngine(float i_MaxBatteryLife) : base(i_MaxBatteryLife)
        {
        }

        public float CurrentBatteryLife
        {
            get { return this.m_CurrentBatteryLife; }
            set
            {
                if (value + this.m_CurrentBatteryLife <= base.EngineMaxCapacity && value >= 0)
                {
                    this.m_CurrentBatteryLife += value;
                }
                else
                {
                    throw new ValueOutOfRangeException("current battery life", 0 , base.EngineMaxCapacity - this.m_CurrentBatteryLife);
                }
            }
        }

        public override void SetProperties(Dictionary<string, string> i_Properties)
        {
            string currentBatteryLifeString = i_Properties["Current battery life"];
            float currentBatteryLife;

            if (!float.TryParse(currentBatteryLifeString, out currentBatteryLife))
            {
                throw new FormatException("Please provide a decimal number for the current battery life");
            }
            else
            {
                CurrentBatteryLife = currentBatteryLife;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine(string.Format("Current battery life : {0}", this.m_CurrentBatteryLife));

            return stringBuilder.ToString();
        }
    }
}
