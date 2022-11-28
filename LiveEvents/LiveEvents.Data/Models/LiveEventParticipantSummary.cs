namespace LiveEvents.Data.Models
{
    public record LiveEventParticipantSummary(
        int Id,
        string Name,
        DateTime StartDate,
        ParticipantStatus ParticipantStatus
    );
}
