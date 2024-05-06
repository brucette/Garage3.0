using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage3._0.Entites;

namespace Garage3._0.Data
{
    public class Garage3_0Context : DbContext
    {
        public Garage3_0Context (DbContextOptions<Garage3_0Context> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; } = default!;
        //public DbSet<Vehicle> Vehicles { get; set; } = default!;
        public DbSet<Ownership> Ownerships { get; set; } = default!;
        public DbSet<Parking> Parkings { get; set; } = default!;
        public DbSet<Receipt> Receipts { get; set; } = default!;
        
        //public DbSet<VehicleType> VehicleTypes { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ownership>().HasKey(o => new { o.MemberId, o.VehicleId });

            //needs to create a connection between Vehicle and VehicleType
            modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.VehicleType)
            .WithOne(t => t.Vehicle)
            .HasForeignKey<VehicleType>(t => t.VehicleId)
            .IsRequired();

            //Configure foregin keys?
            // This section can be removed
            /*
            modelBuilder.Entity<Ownership>()
                .HasOne(o => o.Member)
                .WithMany(m => m.Ownerships)
                .HasForeignKey(o => o.MemberId);

            modelBuilder.Entity<Ownership>()
                .HasOne(o => o.Vehicle)
                .WithMany(v => v.Ownerships)
                .HasForeignKey(o => o.VehicleId);
            */
        }
        public DbSet<Garage3._0.Entites.Vehicle> Vehicle { get; set; } = default!;
        public IEnumerable<object> VehicleType { get; internal set; }

        // något här vetefan vad bara
    }
}
