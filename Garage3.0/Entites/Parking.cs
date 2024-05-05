﻿namespace Garage3._0.Entites
{
    public class Parking
    {
        public int Id { get; set; }
        public int ParkingLotNumber { get; set; }
        public DateTime ArrivalTime { get; set; }

        public string VehicleId { get; set; } // Foreign key

        // Navigation property 
        public Ownership Ownership { get; set; }
    }
}
