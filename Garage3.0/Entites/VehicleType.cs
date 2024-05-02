namespace Garage3._0.Entites
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int NumWheels { get; set; }
        public int VehicleId { get; set; }

        public Vehicle Vehicles { get; set; }

    }
}
