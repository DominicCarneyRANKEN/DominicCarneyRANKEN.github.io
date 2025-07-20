using System.ComponentModel.DataAnnotations;

namespace TripsLog.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        [Required(ErrorMessage = "Yoohoo, the Name field is required.")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]

        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]

        public DateTime EndDate { get; set; }

       
        public int DestinationId { get; set; }
        public Destination? Destination { get; set; }

        
        public int AccommodationId { get; set; }
        public Accommodation? Accommodation { get; set; }

        public ICollection<TripActivity> TripActivities { get; set; } = new List<TripActivity>();
    }
}
