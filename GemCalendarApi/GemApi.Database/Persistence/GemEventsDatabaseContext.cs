using GemApi.Application.Common.Inteerfaces;
using GemApi.Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GemApi.Database.Persistence
{
    public class GemEventsDatabaseContext : DbContext, IApplicationDbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = @$"{System.AppContext.BaseDirectory}DatabaseFile\GemEventsDatabase.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GemEvent>()
                .HasKey(ge => ge.Id)
                .HasName("GemEvent_PK");

            modelBuilder.Entity<GemEvent>()
                .HasOne(ge => ge.GemEventCategory)
                .WithMany(cat => cat.GemEvents)
                .HasForeignKey(ge => ge.GemEventCategoryId);

            modelBuilder.Entity<GemEventCategory>()
                .HasKey(cat => cat.Id)
                .HasName("GemEventCategory_PK");
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<GemEvent> GemEvent { get; set; }
        public DbSet<GemEventCategory> GemCategory { get; set; }
    }
}
