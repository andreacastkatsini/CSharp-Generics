using Microsoft.EntityFrameworkCore;
using WiredBrianCoffee.StorageApp.Entities;

namespace WiredBrianCoffee.StorageApp.Data
{
    class StorageAppDbContext: DbContext
    {
        public DbSet<Employee>? Employees => Set<Employee>();
        public DbSet<Organization>? Organizations => Set<Organization>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
