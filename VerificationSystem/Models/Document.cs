namespace VerificationSystem.Models
{
    public class Document
    {
        public int Id { get; set; }
        public int UserId { get; set; } // forigen key one-mant

        public string Title { get; set; }
        public string FilePath { get; set; }
        public string VerificationCode { get; set; } = Guid.NewGuid().ToString(); //auto generated

        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; } //referencce
        public ICollection<VerificationLog> VerificationLogs { get; set; }
    }
}
