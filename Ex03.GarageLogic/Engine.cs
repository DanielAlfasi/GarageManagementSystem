using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private readonly float r_EngineMaxCapacity;
        
        public Engine(float i_EngineMaxCapacity)
        {
            this.r_EngineMaxCapacity = i_EngineMaxCapacity;
        }

        public float EngineMaxCapacity
        {
            get { return this.r_EngineMaxCapacity; }
        }

        public abstract void SetProperties(Dictionary<string, string> i_Properties);

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Engine");
            stringBuilder.AppendLine("======================================");
            stringBuilder.Append(string.Format("Engine max capacity : {0}", this.r_EngineMaxCapacity));

            return stringBuilder.ToString();
        }

    }
}
