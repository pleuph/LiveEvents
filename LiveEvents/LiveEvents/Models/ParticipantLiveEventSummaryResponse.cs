using LiveEvents.Data.Models;

namespace LiveEvents.Models
{
    public record ParticipantLiveEventSummaryResponse(
        int Id,
        string Name,
        DateTime StartDate,
        ParticipantStatus ParticipantStatus
    );
}