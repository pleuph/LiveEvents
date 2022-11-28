using LiveEvents.Data.Models;

namespace LiveEvents.Models
{
    public record ParticipantSummaryResponse(int UserId, ParticipantStatus Status);
}
