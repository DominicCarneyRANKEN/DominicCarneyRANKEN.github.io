namespace AppointmentHOT.Models
{
    public class Appointments
    {
        public int Id { get; set; }

        public DateTime AppointmentDate { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public bool FutureAppointment()
        {
            return AppointmentDate > DateTime.Now;
        }

        public bool Available(AppointmentDbContext context)  
        {
            return !context.Appointments.Any(a => a.AppointmentDate == AppointmentDate && a.CustomerId == CustomerId);  // Ensure to check for both date and customer
        }
    }
}
