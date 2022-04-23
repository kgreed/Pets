using System;
using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
using DevExpress.Persistent.BaseImpl.EFCore.AuditTrail;

namespace Pets.Module.BusinessObjects {
    // This code allows our Model Editor to get relevant EF Core metadata at design time.
    // For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
	public class PetsContextInitializer : DbContextTypesInfoInitializerBase {
		protected override DbContext CreateDbContext() {
			var optionsBuilder = new DbContextOptionsBuilder<PetsEFCoreDbContext>()
                .UseSqlServer(@";");
            return new PetsEFCoreDbContext(optionsBuilder.Options);
		}
	}
	//This factory creates DbContext for design-time services. For example, it is required for database migration.
	public class PetsDesignTimeDbContextFactory : IDesignTimeDbContextFactory<PetsEFCoreDbContext> {
		public PetsEFCoreDbContext CreateDbContext(string[] args) {
			throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
			//var optionsBuilder = new DbContextOptionsBuilder<PetsEFCoreDbContext>();
			//optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Pooling=false;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Pets");
			//return new PetsEFCoreDbContext(optionsBuilder.Options);
		}
	}
	[TypesInfoInitializer(typeof(PetsContextInitializer))]
	public class PetsEFCoreDbContext : DbContext {
		public PetsEFCoreDbContext(DbContextOptions<PetsEFCoreDbContext> options) : base(options) {
		}
		public DbSet<ModuleInfo> ModulesInfo { get; set; }
		public DbSet<ModelDifference> ModelDifferences { get; set; }
		public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
	    public DbSet<PermissionPolicyRole> Roles { get; set; }
	    public DbSet<Pets.Module.BusinessObjects.ApplicationUser> Users { get; set; }
        public DbSet<Pets.Module.BusinessObjects.ApplicationUserLoginInfo> UserLoginInfos { get; set; }
        public DbSet<AuditDataItemPersistent> AuditData { get; set; }
        public DbSet<AuditEFCoreWeakReference> AuditEFCoreWeakReference { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Pets.Module.BusinessObjects.ApplicationUserLoginInfo>(b => {
                b.HasIndex(nameof(DevExpress.ExpressApp.Security.ISecurityUserLoginInfo.LoginProviderName), nameof(DevExpress.ExpressApp.Security.ISecurityUserLoginInfo.ProviderUserKey)).IsUnique();
            });
        }
	}

    public class PetsAuditingDbContext : DbContext {
        public PetsAuditingDbContext(DbContextOptions<PetsAuditingDbContext> options) : base(options) {
        }
        public DbSet<AuditDataItemPersistent> AuditData { get; set; }
        public DbSet<AuditEFCoreWeakReference> AuditEFCoreWeakReference { get; set; }
    }
}
