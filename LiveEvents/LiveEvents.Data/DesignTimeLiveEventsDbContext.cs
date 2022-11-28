using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LiveEvents.Data
{
    public class DesignTimeLiveEventsDbContext : IDesignTimeDbContextFactory<LiveEventsDbContext>
    {
        public LiveEventsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LiveEventsDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=LiveEvents;Integrated Security=True;TrustServerCertificate=True;",
                a => a.MigrationsHistoryTable("__EFMigrationsHistory"));

            var context = Activator.CreateInstance(typeof(LiveEventsDbContext), optionsBuilder.Options) as LiveEventsDbContext;
            return context;
        }
    }
}
