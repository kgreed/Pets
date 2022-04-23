using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EFCore.AuditTrail;
using Microsoft.EntityFrameworkCore;
using System;

namespace Pets.Module.BusinessObjects
{
    [TypesInfoInitializer(typeof(PetsContextInitializer))]
    public class PetsEFCoreDbContext : DbContext
    {
        public PetsEFCoreDbContext(DbContextOptions<PetsEFCoreDbContext> options) : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Kitten> Kittens { get; set; }
        public DbSet<Puppy> Puppys { get; set; }

        public DbSet<ModuleInfo> ModulesInfo { get; set; }
        public DbSet<ModelDifference> ModelDifferences { get; set; }
        public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
        public DbSet<PermissionPolicyRole> Roles { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationUserLoginInfo> UserLoginInfos { get; set; }
        public DbSet<AuditDataItemPersistent> AuditData { get; set; }
        public DbSet<AuditEFCoreWeakReference> AuditEFCoreWeakReference { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserLoginInfo>(b =>
            {
                b.HasIndex(nameof(DevExpress.ExpressApp.Security.ISecurityUserLoginInfo.LoginProviderName), nameof(DevExpress.ExpressApp.Security.ISecurityUserLoginInfo.ProviderUserKey)).IsUnique();
            });
            modelBuilder.Entity<Pet>()
              .HasDiscriminator<bool?>("IsCat")
              .HasValue<Cat>(true)
              .HasValue<Dog>(false);

            modelBuilder.Entity<BabyPet>()
              .HasDiscriminator<bool?>("IsCat")
              .HasValue<Kitten>(true)
              .HasValue<Puppy>(false);
        }
    }
}
