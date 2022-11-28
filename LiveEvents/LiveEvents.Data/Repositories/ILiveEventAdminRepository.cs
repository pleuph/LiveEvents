using LiveEvents.Data.Models;

namespace LiveEvents.Data.Repositories
{
    public interface ILiveEventAdminRepository
    {
        Task<int> AddLiveEvent(LiveEvent liveEvent);
        Task<IEnumerable<LiveEventSummary>> GetLiveEventSummaries(bool onlyFutureEvents);
        Task<IEnumerable<ParticipantSummary>> GetParticipantSummaries(int liveEventId);
    }
}