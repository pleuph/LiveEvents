using LiveEvents.Models;

namespace LiveEvents.Services
{
    public interface ILiveEventAdminService
    {
        Task<int> AddLiveEvent(AddLiveEventRequest addLiveEventRequest, int userId);
        Task<IEnumerable<LiveEventSummaryResponse>> GetLiveEventSummaries(bool onlyFutureEvents);
        Task<IEnumerable<ParticipantSummaryResponse>> GetParticipantSummaries(int liveEventId);
    }
}