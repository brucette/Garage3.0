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

        public DbSet<Garage3._0.Entites.Ownership> Ownership { get; set; } = default!;
        public DbSet<Garage3._0.Entites.Member> Member { get; set; } = default!;
    }
}
