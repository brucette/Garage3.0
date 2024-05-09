namespace Garage3._0.ModelView
{
    public class ReceiptViewModel
    {
        public int Id { get; private set; }
        public string PersonNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string VehicleType { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public TimeSpan TotalParkingTimeInMinutes { get; set; }
        public double Price { get; set; }
    }
}
