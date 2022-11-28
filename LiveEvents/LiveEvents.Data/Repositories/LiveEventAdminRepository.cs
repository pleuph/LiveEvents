using LiveEvents.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LiveEvents.Data.Repositories
{
    public class LiveEventAdminRepository : ILiveEventAdminRepository
    {
        readonly LiveEventsDbContext liveEventsDbContext;

        public LiveEventAdminRepository(LiveEventsDbContext liveEventsDbContext)
        {
            this.liveEventsDbContext = liveEventsDbContext;
        }

        public async Task<IEnumerable<LiveEventSummary>> GetLiveEventSummaries(bool onlyFutureEvents)
        {
            var query = liveEventsDbContext.LiveEvents.AsQueryable();

            if (onlyFutureEvents)
                query = query.Where(a => a.StartDate > DateTime.UtcNow);

            var summaries = query
                .OrderBy(a => a.StartDate)
                .Select(a => new LiveEventSummary(
                    a.Id,
                    a.Name,
                    a.StartDate,
                    a.Participants.Count(b => b.Status == ParticipantStatus.Participating))
                );

            return await summaries.ToArrayAsync();
        }

        public async Task<int> AddLiveEvent(LiveEvent liveEvent)
        {
            liveEventsDbContext.LiveEvents.Add(liveEvent);
            await liveEventsDbContext.SaveChangesAsync();
            return liveEvent.Id;
        }

        public async Task<IEnumerable<ParticipantSummary>> GetParticipantSummaries(int liveEventId)
        {
            var query =
                from participant in liveEventsDbContext.LiveEventParticipants
                where participant.LiveEventId == liveEventId
                orderby participant.Status, participant.UserId
                select new ParticipantSummary(participant.UserId, participant.Status);

            return await query.ToArrayAsync();
        }
    }
}
