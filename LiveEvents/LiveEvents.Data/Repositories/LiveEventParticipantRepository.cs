using LiveEvents.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LiveEvents.Data.Repositories
{
    public class LiveEventParticipantRepository : ILiveEventParticipantRepository
    {
        readonly LiveEventsDbContext liveEventsDbContext;

        public LiveEventParticipantRepository(LiveEventsDbContext liveEventsDbContext)
        {
            this.liveEventsDbContext = liveEventsDbContext;
        }

        public async Task<IEnumerable<LiveEventParticipantSummary>> GetFutureLiveEventParticipantSummaries(int userId)
        {
            var query =
                from liveEvent in liveEventsDbContext.LiveEvents
                where liveEvent.StartDate > DateTime.UtcNow
                let participantStatus =
                    liveEvent.Participants
                        .Where(a => a.UserId == userId)
                        .Select(a => a.Status)
                        .FirstOrDefault()
                orderby liveEvent.StartDate
                select new LiveEventParticipantSummary(
                    liveEvent.Id,
                    liveEvent.Name,
                    liveEvent.StartDate,
                    participantStatus);

            return await query.ToArrayAsync();
        }

        public async Task UpsertLiveEventParticipant(LiveEventParticipant liveEventParticipant)
        {
            var dbLiveEventParticipant =
                liveEventsDbContext.LiveEventParticipants.FirstOrDefault(a =>
                    a.LiveEventId == liveEventParticipant.LiveEventId &&
                    a.UserId == liveEventParticipant.UserId);

            if (dbLiveEventParticipant == null)
                liveEventsDbContext.LiveEventParticipants.Add(liveEventParticipant);
            else
            {
                dbLiveEventParticipant.Status = liveEventParticipant.Status;
                dbLiveEventParticipant.UpdatedDate = DateTime.UtcNow;
            }

            await liveEventsDbContext.SaveChangesAsync();
        }
    }
}
