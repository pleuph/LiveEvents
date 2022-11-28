using LiveEvents.Data.Models;

namespace LiveEvents.Models
{
    public record UpsertLiveEventParticipantRequest(
        int LiveEventId,
        ParticipantStatus Status
    );
}
