using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;

namespace SmtpWeb
{
    public class MailMessage
    {
        [BsonId]
        public ObjectId Id { get; set; }

      

         
        public string Subject { get; set; }
        public string HtmlBody { get; set; }
        public MailAddress FromName { get; set; }
        public bool IsHtml { get; set; }
        public List<MailAddress> ToAddress
        {
            get; set; 
            
        }

        public string ToAddressAsString
        {
            get { return string.Join(",", ToAddress.Select(x=>x.Email).ToList());   }
        }


        public DateTimeOffset Sent { get; set; }

        public string SerializedObjectId
        {
            get { return Id.ToString(); }
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Subject)}: {Subject}, {nameof(HtmlBody)}: {HtmlBody}, {nameof(FromName)}: {FromName}, {nameof(IsHtml)}: {IsHtml}, {nameof(ToAddress)}: {ToAddress}";
        }
    }
}