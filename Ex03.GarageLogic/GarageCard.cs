using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageCard : IPropertyHolder
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;

        protected static readonly Dictionary<string, string[]> sr_GarageCardProperties = new Dictionary<string, string[]>()
        {
            {"Owner name" , null},
            {"Owner Phone Number", null},
        };

        public GarageCard()
        {
            this.m_VehicleStatus = eVehicleStatus.Inrepair;
        }

        public string OwnerName
        {
            get { return this.m_OwnerName; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new FormatException("Empty owner name");
                }

                this.m_OwnerName = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get { return this.m_OwnerPhoneNumber; }
            set
            {
                if (!int.TryParse(value, out _))
                {
                    throw new FormatException("Invalid phone number");
                }

                this.m_OwnerPhoneNumber = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return this.m_VehicleStatus; }
            set { this.m_VehicleStatus = value; }
        }

        public Dictionary<string, string[]> GetProperties()
        {
            return sr_GarageCardProperties;
        }

        public void SetProperties(Dictionary<string, string> i_Properties)
        {
            string ownerNameString = i_Properties["Owner name"];
            string ownerPhoneNumberString = i_Properties["Owner Phone Number"];

            OwnerName = ownerNameString;
            OwnerPhoneNumber = ownerPhoneNumberString;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Owner's credentials");
            stringBuilder.AppendLine("======================================");
            stringBuilder.AppendLine(string.Format("Vehicle status : {0}", this.m_VehicleStatus.ToString()));
            stringBuilder.AppendLine(string.Format("Owner's name : {0}", this.m_OwnerName));
            stringBuilder.AppendLine(string.Format("Owner's phone number : {0}", this.m_OwnerPhoneNumber));

            return stringBuilder.ToString();    
        }

        public enum eVehicleStatus
        {
            Inrepair = 1,
            Repaired = 2,
            Paid = 3,
        }
    }
}
