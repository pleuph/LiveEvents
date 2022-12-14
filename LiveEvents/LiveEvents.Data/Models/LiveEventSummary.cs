namespace LiveEvents.Data.Models
{
    public record LiveEventSummary(
        int Id,
        string Name,
        DateTime StartDate,
        int ParticipantCount
    );
}
