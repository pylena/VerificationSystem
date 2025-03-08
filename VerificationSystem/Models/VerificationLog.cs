namespace VerificationSystem.Models
{
    public class VerificationLog
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }

        public string VerifiedBy { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow; 
        public string Status { get; set; }

        public Document Document { get; set; } //refernce
    }
}
