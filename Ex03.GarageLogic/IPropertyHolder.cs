using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public interface IPropertyHolder
    {
        Dictionary<string, string[]> GetProperties();
        void SetProperties(Dictionary<string, string> i_Properties);
    }

}
