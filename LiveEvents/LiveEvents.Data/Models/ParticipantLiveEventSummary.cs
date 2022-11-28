namespace LiveEvents.Data.Models
{
    public record ParticipantLiveEventSummary(
        int Id,
        string Name,
        DateTime StartDate,
        ParticipantStatus ParticipantStatus
    );
}
