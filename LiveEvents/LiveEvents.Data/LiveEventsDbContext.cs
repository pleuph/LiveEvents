using LiveEvents.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LiveEvents.Data
{
    public class LiveEventsDbContext : DbContext
    {
        public DbSet<LiveEvent> LiveEvents { get; set; }
        public DbSet<LiveEventParticipant> LiveEventParticipants { get; set; }

        public LiveEventsDbContext(DbContextOptions<LiveEventsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LiveEvent>(a => {
                a.ToTable("LiveEvent");
                a.Property(b => b.Description).IsRequired();
                a.Property(b => b.Name).IsRequired();
                a.Property(b => b.CreatedDate).HasDefaultValueSql("getutcdate()");
                a.Property(b => b.UpdatedDate).HasDefaultValueSql("getutcdate()");
            });

            modelBuilder.Entity<LiveEventParticipant>(a => {
                a.ToTable("LiveEventParticipant");
                a.HasKey(b => new { b.LiveEventId, b.UserId });
                a.Property(b => b.CreatedDate).HasDefaultValueSql("getutcdate()");
                a.Property(b => b.UpdatedDate).HasDefaultValueSql("getutcdate()");
            });
        }
    }
}
