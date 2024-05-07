namespace Garage3._0.Entites
{
    public class VehicleType
    {
        public int VehicleTypeId { get; set; }
        public string Type { get; set; }
        public int NumWheels { get; set; }

        // DO WE NEED THESE? :
        // public string VehicleId { get; set; }//foreign key
        // public Vehicle Vehicle { get; set; }
    }
}
