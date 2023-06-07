using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException (string i_Message, float i_MinValue, float i_MaxValue) : base(string.Format("The value for {2} is out of range, needs to be between {0} - {1}", i_MinValue, i_MaxValue, i_Message))
        {
            this.r_MaxValue = i_MaxValue;
            this.r_MinValue = i_MinValue;
        }

        public float MaxValue
        {
            get { return r_MaxValue; }
        }

        public float MinValue
        {
            get { return r_MinValue; }
        }

    }
}