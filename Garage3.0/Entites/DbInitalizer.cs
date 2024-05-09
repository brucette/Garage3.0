using Garage3._0.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Garage3._0.Entites
{
    public class DbInitalizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            Garage3_0Context _context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<Garage3_0Context>();

            if (!_context.Members.Any())
            {
                _context.AddRange
                (
                    new Member { Id = "199901011111", FirstName = "Kalle", LastName = "Anka", Membership = false },
                    new Member { Id = "199701022222", FirstName = "Anton", LastName = "Smith", Membership = true },
                    new Member { Id = "199501033333", FirstName = "Felicia", LastName = "Kjell", Membership = true },
                    new Member { Id = "200010444444", FirstName = "Joakim", LastName = "Von Anka", Membership = true },
                    new Member { Id = "199101015555", FirstName = "Tom", LastName = "Hendersson", Membership = false },
                    new Member { Id = "200901016666", FirstName = "Joe", LastName = "Black", Membership = false }
                );
                _context.SaveChanges();
            }

            if (!_context.VehicleTypes.Any())
            {
                _context.AddRange
                (
                    new VehicleType { Type = "Car", NumWheels = 4 },
                    new VehicleType { Type = "Airplane", NumWheels = 0 },
                    new VehicleType { Type = "Bus", NumWheels = 8 },
                    new VehicleType { Type = "Motorbike", NumWheels = 2 }
                );
                _context.SaveChanges();
            }

            if (!_context.Vehicle.Any())
            {
                _context.AddRange
                (
                    new Vehicle { Id = "abc123", Brand = "trx123", ModelType = "Volvo", Color = "Black", VehicleTypeId = 1 },
                    new Vehicle { Id = "abc456", Brand = "qwe789", ModelType = "Scania", Color = "Red", VehicleTypeId = 3 },
                    new Vehicle { Id = "abc789", Brand = "tyu789", ModelType = "Toyota", Color = "Blue", VehicleTypeId = 1 },
                    new Vehicle { Id = "qwe123", Brand = "qwe852", ModelType = "Boeing", Color = "Green", VehicleTypeId = 2 },
                    new Vehicle { Id = "asd123", Brand = "ert132", ModelType = "Volvo", Color = "Red", VehicleTypeId = 1 },
                    new Vehicle { Id = "zxc123", Brand = "ert963", ModelType = "Volvo", Color = "Black", VehicleTypeId = 3 }
                );

                _context.AddRange
                (
                    new Ownership { MemberId = "199901011111", VehicleId = "abc123" },
                    new Ownership { MemberId = "199701022222", VehicleId = "abc456" },
                    new Ownership { MemberId = "199501033333", VehicleId = "abc789" },
                    new Ownership { MemberId = "200010444444", VehicleId = "qwe123" },
                    new Ownership { MemberId = "199101015555", VehicleId = "asd123" },
                    new Ownership { MemberId = "200901016666", VehicleId = "zxc123" }
                );
                _context.SaveChanges();
            }

            //This causes the garage site to have a error, find the error later if the time permits. For now park the vehicles manually
            /*if (!_context.Parkings.Any())
            {
                _context.AddRange
                (
                    new Parking { ParkingLotNumber = 0, VehicleId = "abc123", ArrivalTime = DateTime.Now },
                    new Parking { ParkingLotNumber = 1, VehicleId = "abc456", ArrivalTime = DateTime.Now.AddDays(-1) },
                    new Parking { ParkingLotNumber = 2, VehicleId = "abc789", ArrivalTime = DateTime.Now.AddDays(-2) },
                    new Parking { ParkingLotNumber = 3, VehicleId = "qwe123", ArrivalTime = DateTime.Now.AddDays(-3) },
                    new Parking { ParkingLotNumber = 4, VehicleId = "asd123", ArrivalTime = DateTime.Now.AddDays(-4) },
                    new Parking { ParkingLotNumber = 5, VehicleId = "zxc123", ArrivalTime = DateTime.Now.AddMinutes(60) }
                );
                _context.SaveChanges();
            }*/
        }


    }
}
