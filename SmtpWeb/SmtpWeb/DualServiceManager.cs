namespace SmtpWeb
{
    public class DualServiceManager
    {
        private readonly NancySelfHost service1;
        private readonly HandledSmtpServer service2;

        public DualServiceManager(NancySelfHost service1, HandledSmtpServer service2)
        {
            this.service1 = service1;
            this.service2 = service2;
        }

        public void Start()
        {
            service1.Start();
            service2.Start();
        }

        public void Stop()
        {
            service1.Stop();
            service2.Stop();
        }
    }
}