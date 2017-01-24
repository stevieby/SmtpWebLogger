using System.Threading;
using System.Threading.Tasks;
using SmtpServer;

namespace SmtpWeb
{
    public class HandledSmtpServer
    {
        public async Task Start()
        {
            var options = new OptionsBuilder()
                .ServerName("localhost")
                .Port(25, 587)
                .MessageStore(new ConsoleMessageStore())
                .Build();

            var smtpServer = new SmtpServer.SmtpServer(options);
            await smtpServer.StartAsync(CancellationToken.None);
        }

        public void Stop()
        {
        }
    }
}