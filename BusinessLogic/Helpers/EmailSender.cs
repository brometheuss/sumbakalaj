using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BusinessLogic.Helpers
{
    public class EmailSender : IEmailSender
    {
        private int port;
        private string from;
        private string password;
        private string host;

        public EmailSender(int port, string from, string password, string host)
        {
            this.port = port;
            this.from = from;
            this.password = password;
            this.host = host;
        }

        public string ToEmail { get; set; } 
        public string Subject { get; set; } 
        public string Body { get; set; } 

        public void Send()
        {
            var smtp = new SmtpClient
            {
                Port = port,
                Host = host,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, password)
            };

            using (var message = new MailMessage(from, ToEmail)
            {
                Subject = Subject,
                Body = Body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
