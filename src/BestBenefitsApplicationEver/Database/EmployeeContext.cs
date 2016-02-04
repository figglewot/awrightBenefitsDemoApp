using System;
using BestBenefitsApplicationEver.Models;
using Microsoft.Data.Entity;

namespace BestBenefitsApplicationEver.Database
{
    public sealed class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Startup.Configuration["Data:EmployeeContextConnection"];

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
