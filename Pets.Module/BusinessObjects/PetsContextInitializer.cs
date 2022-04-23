using DevExpress.ExpressApp.EFCore.DesignTime;
using Microsoft.EntityFrameworkCore;
using System;

namespace Pets.Module.BusinessObjects
{
    public class PetsContextInitializer : DbContextTypesInfoInitializerBase
    {
        protected override DbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PetsEFCoreDbContext>()
                .UseSqlServer(@";");
            return new PetsEFCoreDbContext(optionsBuilder.Options);
        }
    }
}
