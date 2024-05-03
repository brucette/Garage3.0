namespace Garage3._0.Entites
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int NumWheels { get; set; }
        public string VehicleId { get; set; }//foreign key
        public Vehicle Vehicle { get; set; }

    }
}
