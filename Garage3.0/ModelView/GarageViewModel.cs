using Microsoft.DotNet.Scaffolding.Shared.Project;
using System.ComponentModel.DataAnnotations;

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
        public TimeSpan TotalParkingTime { get; set; }

        public string DisplayTime => $"{TotalParkingTime.Days} days, {TotalParkingTime.Hours} h {TotalParkingTime.Minutes} min";

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
