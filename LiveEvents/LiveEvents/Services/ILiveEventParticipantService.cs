using LiveEvents.Models;

namespace LiveEvents.Services
{
    public interface ILiveEventParticipantService
    {
        Task<IEnumerable<LiveEventParticipantSummaryResponse>> GetFutureLiveEventParticipantSummaries(int userId);
        Task UpsertLiveEventParticipant(UpsertLiveEventParticipantRequest request, int userId);
    }
}