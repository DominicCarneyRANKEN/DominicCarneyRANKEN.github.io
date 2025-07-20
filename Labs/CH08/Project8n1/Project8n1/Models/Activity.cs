namespace Project8n1.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string? ActivityName { get; set; }
        public string? Description { get; set; }
        public int? TripId { get; set; }
        public Trip? Trip { get; set; }

    }
}
