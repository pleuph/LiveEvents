using LiveEvents.Data.Models;

namespace LiveEvents.Models
{
    public record UpsertParticipantRequest(
        int LiveEventId,
        ParticipantStatus Status
    );
}
