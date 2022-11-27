using LiveEvents.Models;

namespace LiveEvents.Services
{
    public interface ILiveEventsAdminService
    {
        Task<IEnumerable<LiveEventSummaryDto>> GetLiveEventSummaries(bool onlyFutureEvents);
    }
}