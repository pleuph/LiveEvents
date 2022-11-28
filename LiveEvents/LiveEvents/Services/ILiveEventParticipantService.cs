using LiveEvents.Models;

namespace LiveEvents.Services
{
    public interface ILiveEventParticipantService
    {
        Task<IEnumerable<ParticipantLiveEventSummaryResponse>> GetFutureLiveEventParticipantSummaries(int userId);
        Task UpsertLiveEventParticipant(UpsertParticipantRequest request, int userId);
    }
}