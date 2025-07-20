namespace TripsLog.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }

        public string Name { get; set; }

        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
