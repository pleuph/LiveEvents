namespace LiveEvents.Data.Models
{
    public class LiveEvent
    {
        public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<LiveEventParticipant> Participants { get; set; } = new List<LiveEventParticipant>();
    }
}
