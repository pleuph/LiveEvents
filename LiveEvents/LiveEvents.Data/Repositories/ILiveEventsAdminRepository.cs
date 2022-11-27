using LiveEvents.Data.Models;

namespace LiveEvents.Data.Repositories
{
    public interface ILiveEventsAdminRepository
    {
        Task<IEnumerable<LiveEventSummary>> GetLiveEventSummaries(bool onlyFutureEvents);
    }
}