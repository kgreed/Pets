using DevExpress.Persistent.BaseImpl.EFCore.AuditTrail;
using Microsoft.EntityFrameworkCore;
using System;

namespace Pets.Module.BusinessObjects
{
    public class PetsAuditingDbContext : DbContext
    {
        public PetsAuditingDbContext(DbContextOptions<PetsAuditingDbContext> options) : base(options)
        {
        }
        public DbSet<AuditDataItemPersistent> AuditData { get; set; }
        public DbSet<AuditEFCoreWeakReference> AuditEFCoreWeakReference { get; set; }
    }
}
