using LiveEvents.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LiveEvents.Data.Repositories
{
    public class LiveEventsAdminRepository : ILiveEventsAdminRepository
    {
        readonly LiveEventsDbContext liveEventsDbContext;

        public LiveEventsAdminRepository(LiveEventsDbContext liveEventsDbContext)
        {
            this.liveEventsDbContext = liveEventsDbContext;
        }

        public async Task<IEnumerable<LiveEventSummary>> GetLiveEventSummaries(bool onlyFutureEvents)
        {
            var query = liveEventsDbContext.LiveEvents.AsQueryable();

            if (onlyFutureEvents)
                query = query.Where(a => a.StartDate > DateTime.UtcNow);

            var summaries =
                query.Select(a => new LiveEventSummary
                {
                    Id = a.Id,
                    Name = a.Name,
                    StartDate = a.StartDate,
                    ParticipantCount = a.Participants.Count(b => b.Status == ParticipantStatus.Participating)
                }).OrderBy(a => a.StartDate);

            return await summaries.ToArrayAsync();
        }

        public async Task<int> AddLiveEvent(LiveEvent liveEvent)
        {
            liveEventsDbContext.LiveEvents.Add(liveEvent);
            await liveEventsDbContext.SaveChangesAsync();
            return liveEvent.Id;
        }
    }
}
