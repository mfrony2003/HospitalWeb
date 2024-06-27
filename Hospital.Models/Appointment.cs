namespace Hospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime Time { get; set; }

        public ApplicationUser Doctor { get; set; }
        public ApplicationUser Patient { get; set; }

        
    }
}