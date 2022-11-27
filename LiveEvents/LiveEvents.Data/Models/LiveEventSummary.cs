namespace LiveEvents.Data.Models
{
    public class LiveEventSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int ParticipantCount { get; set; }
    }
}
