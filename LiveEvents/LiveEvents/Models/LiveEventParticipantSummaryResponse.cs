using LiveEvents.Data.Models;

namespace LiveEvents.Models
{
    public record LiveEventParticipantSummaryResponse(
        int Id,
        string Name,
        DateTime StartDate,
        ParticipantStatus ParticipantStatus
    );
}