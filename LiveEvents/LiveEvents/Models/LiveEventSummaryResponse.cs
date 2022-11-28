namespace LiveEvents.Models
{
    public record LiveEventSummaryResponse(
        int Id,
        string Name,
        DateTime StartDate,
        int ParticipantCount
    );
}