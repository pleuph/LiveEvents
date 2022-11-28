namespace LiveEvents.Data.Models
{
    public class LiveEventParticipant
    {
        public int LiveEventId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ParticipantStatus Status { get; set; }

        public LiveEvent LiveEvent { get; set; }
    }
}
