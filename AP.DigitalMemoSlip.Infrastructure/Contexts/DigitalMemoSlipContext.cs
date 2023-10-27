using AP.DigitalMemoSlip.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AP.DigitalMemoSlip.Infrastructure.Contexts
{
    public class DigitalMemoSlipContext : DbContext
    {
        public DigitalMemoSlipContext(DbContextOptions<DigitalMemoSlipContext> options) : base(options) { }

        public DbSet<Consigner> Consigners { get; set; }
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // model configuration
            //modelBuilder.ApplyConfiguration(new PersonConfiguration()); // manual
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // auto

            // seeding
            //modelBuilder.Entity<Store>().Seed();
            //modelBuilder.Entity<Person>().Seed();

        }
    }
}
