namespace _42MailLibray.Entities
{
    public class Mail
    {
        public int Id { get; set; }

        public string? Subject { get; set; }
        
        public string? Body { get; set; }

        public DateTime SentDate { get; set; }
    }
}
