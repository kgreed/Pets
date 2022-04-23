using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Pets.Module.BusinessObjects
{
    //This factory creates DbContext for design-time services. For example, it is required for database migration.
    public class PetsDesignTimeDbContextFactory : IDesignTimeDbContextFactory<PetsEFCoreDbContext>
    {
        public PetsEFCoreDbContext CreateDbContext(string[] args)
        {
            throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
            //var optionsBuilder = new DbContextOptionsBuilder<PetsEFCoreDbContext>();
            //optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Pooling=false;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Pets");
            //return new PetsEFCoreDbContext(optionsBuilder.Options);
        }
    }
}
