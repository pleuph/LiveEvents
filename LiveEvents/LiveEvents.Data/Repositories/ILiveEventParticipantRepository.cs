using LiveEvents.Data.Models;

namespace LiveEvents.Data.Repositories
{
    public interface ILiveEventParticipantRepository
    {
        Task<IEnumerable<ParticipantLiveEventSummary>> GetFutureLiveEventParticipantSummaries(int userId);
        Task UpsertLiveEventParticipant(LiveEventParticipant liveEventParticipant);
    }
}