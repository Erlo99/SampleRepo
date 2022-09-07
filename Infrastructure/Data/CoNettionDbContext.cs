using Domain.Common;
using Domain.Entities.GoodsReceivedNotes;
using Domain.Entities.Users;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class CoNettionDbContext : DbContext
    {
        private readonly ILogger _logger;

        public CoNettionDbContext(DbContextOptions options, ILogger<CoNettionDbContext> logger) : base(options)
        {
            _logger = logger;
        }

        public virtual DbSet<GoodsReceivedNote> GoodsReceivedNotes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            {
                var entries = ChangeTracker
                    .Entries()
                    .Where(e => e.Entity is AuditableEntity &&
                                (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

                var userName = "username";

                foreach (var entityEntry in entries)
                {
                    if (entityEntry.State == EntityState.Deleted)
                    {
                        _logger.LogInformation($"User {userName} deleted: " +
                                               entityEntry.OriginalValues.ToObject().ToString());
                        continue;
                    }

                    ((AuditableEntity) entityEntry.Entity).LastModifiedAt = DateTime.UtcNow;
                    ((AuditableEntity) entityEntry.Entity).LastModifiedBy = userName;

                    if (entityEntry.State == EntityState.Added)
                    {
                        ((AuditableEntity) entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                        ((AuditableEntity) entityEntry.Entity).CreatedBy = userName;
                    }
                }

                return base.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
