using System;
using System.Threading;
using System.Threading.Tasks;
using LiteDB;
using SmtpServer;
using SmtpServer.Mail;
using SmtpServer.Protocol;
using SmtpServer.Storage;
using Topshelf.Logging;

namespace SmtpWeb
{
    public class ConsoleMessageStore : IMessageStore, IMessageStoreFactory
    {
        public Task<SmtpResponse> SaveAsync(ISessionContext context, IMimeMessage message,
            CancellationToken cancellationToken)
        {
            Console.WriteLine("message recived");

            var mailMessage = MimeParserUtility.Parse(message);

            Console.WriteLine(mailMessage.ToString());
            foreach (var address in mailMessage.ToAddress)
            {
                Console.WriteLine(address);
            }

            EmailRepository.Write(mailMessage);

            return Task.FromResult(SmtpResponse.Ok);
        }

        public IMessageStore CreateInstance(ISessionContext context)
        {
            return new ConsoleMessageStore();
        }

        
    }


}