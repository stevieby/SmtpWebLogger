using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using LiteDB;

namespace SmtpWeb
{
    public class EmailRepository
    {
        private const string DBlocation = @"Emails.db";
        private const string Emails = "messages";

        public static void Write(MailMessage message)
        {
            using (var db = new LiteDatabase(DBlocation))
            {
                var mails = db.GetCollection<MailMessage>(Emails);

                mails.Insert(message);

            }
 
        }

        public static MailMessage GetById(string objectId)
        {
            using (var db = new LiteDatabase(DBlocation))
            {
                LiteCollection<MailMessage> mails = db.GetCollection<MailMessage>(Emails);

                return mails.FindById(new ObjectId(objectId));

            }
        }

        public static LiteCollection<MailMessage> Get()
        {
            using (var db = new LiteDatabase(DBlocation))
            {
                LiteCollection<MailMessage> mails = db.GetCollection<MailMessage>(Emails);

                return mails;

            }
        }

        public static void Clear()
        {
            using (var db = new LiteDatabase(DBlocation))
            {
                LiteCollection<MailMessage> mails = db.GetCollection<MailMessage>(Emails);

                mails.Delete(Query.All());

            }
        }
    }
}