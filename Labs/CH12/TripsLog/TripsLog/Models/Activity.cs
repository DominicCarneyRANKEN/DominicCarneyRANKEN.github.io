namespace TripsLog.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }

        public ICollection<TripActivity> TripActivities { get; set; } = new List<TripActivity>();
    }

}
