using System.Text;

namespace Ex03.GarageLogic
{
    public class RegisteredVehicle
    {
        private readonly Vehicle r_Vehicle;
        private readonly GarageCard r_Card;

        public RegisteredVehicle(Vehicle i_Vehicle, GarageCard i_Card)
        {
            this.r_Vehicle = i_Vehicle;
            this.r_Card = i_Card;
        }

        public Vehicle Vehicle
        {
            get { return this.r_Vehicle; }
        }

        public GarageCard Card
        {
            get { return this.r_Card; }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(r_Card.ToString());
            stringBuilder.AppendLine(r_Vehicle.ToString());

            return stringBuilder.ToString();
        }

    }
}
