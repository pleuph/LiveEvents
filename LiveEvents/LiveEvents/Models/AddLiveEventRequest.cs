namespace LiveEvents.Models
{
    public record AddLiveEventRequest(        
        string Name,
        string Description,
        DateTime CreatedDate,
        DateTime StartDate,
        DateTime EndDate
    );
}
