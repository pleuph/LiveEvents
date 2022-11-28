using LiveEvents.Models;

namespace LiveEvents.Services
{
    public interface ILiveEventsAdminService
    {
        Task<int> AddLiveEvent(AddLiveEventRequest addLiveEventRequest, int userId);
        Task<IEnumerable<LiveEventSummaryResponse>> GetLiveEventSummaries(bool onlyFutureEvents);
    }
}