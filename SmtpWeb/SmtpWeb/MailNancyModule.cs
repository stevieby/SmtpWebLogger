using System;
using System.IO;
using System.Linq;
using System.Reflection;
using LiteDB;
using Nancy;
using Nancy.Conventions;
using Nancy.Responses;

namespace SmtpWeb
{
    public class MailNancyModule : NancyModule
    {

        public MailNancyModule() 
        {

            Get["/emails"] = parameters =>
            {
                var messages = EmailRepository.Get().FindAll().ToList();
                return Response.AsJson(messages);
            };

            Get["/emails/{id}"] = parameters =>
            {
                MailMessage messages = EmailRepository.GetById(parameters.id);
                return Response.AsJson(messages);
            };


            //  yes I know this breaks rest but its easier doing from browser
            Get["/clear/emails"] = parameters =>
            {
                EmailRepository.Clear();
                return Response.AsJson(true); 
            };

            Get["/"] = v =>
            {
                var messages = EmailRepository.Get().FindAll().ToList();
                return View["views/index.html", messages]; 
            };
                                                           

        }
    }

      
   
}