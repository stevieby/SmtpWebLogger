using System.IO;
using System.Linq;
using System.Text;
using LiteDB;
using MimeKit;
using SmtpServer.Mail;

namespace SmtpWeb
{
    public  class MimeParserUtility
    {


        public static MailMessage Parse(IMimeMessage message)
        {
            var parser = new MimeParser(GenerateStreamFromString(message.Mime.ToString()), MimeFormat.Entity);
            var objectParsed =  parser.ParseMessage();

            var fromAddress = objectParsed.From.Mailboxes.First();
            var toAddress =
                objectParsed.To.Mailboxes.Select(x => new MailAddress() {Name = x.Name, Email = x.Address}).ToList();

            var textBody = objectParsed.HtmlBody;
            bool isHtml = true;
            if (string.IsNullOrWhiteSpace(textBody))
            {
                textBody = objectParsed.TextBody;
                isHtml = false;
            }

       
            return new MailMessage() {Subject = objectParsed.Subject, FromName = new MailAddress() { Email = fromAddress.Address, Name = fromAddress.Name}, ToAddress = toAddress,
                HtmlBody = textBody, IsHtml = isHtml, Sent = objectParsed.Date, Id = ObjectId.NewObjectId()
            };

        }

        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }
    }
}