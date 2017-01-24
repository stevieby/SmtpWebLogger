using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace SmtpWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
             
                x.Service<DualServiceManager>(s =>
                {
                    s.ConstructUsing(name => new DualServiceManager(new NancySelfHost(), new HandledSmtpServer()));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("Nancy-SelfHost example");
                x.SetDisplayName("Nancy-SelfHost Service");
                x.SetServiceName("Nancy-SelfHost");
            });
        }


    }
}
