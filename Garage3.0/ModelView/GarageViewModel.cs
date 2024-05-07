using Microsoft.DotNet.Scaffolding.Shared.Project;

namespace Garage3._0.ModelView
{
    public class GarageViewModel
    {
        //Member information
        public string OwnerName { get; set; }
        public string PersonalNumber { get; set; }
        public bool Membership { get; set; }

        //parking information
        public int ParkingLot { get; set; }
        public DateTime ArrivalTime { get; set; }

        //Vehicle information
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public string ModelType { get; set; }
        public string Brand { get; set; }

        //VehicleType information
        public string Type { get; set; }
        public int NumWheels { get; set; }
    }
}
