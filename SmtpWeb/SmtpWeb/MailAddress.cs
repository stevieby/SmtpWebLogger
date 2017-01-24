namespace SmtpWeb
{
    public class MailAddress
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Email)}: {Email}";
        }
    }
}