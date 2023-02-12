namespace Web.Models
{
    public class AppointmentDetails
    {
        public int AppId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime Date { get; set; }
    }
}
