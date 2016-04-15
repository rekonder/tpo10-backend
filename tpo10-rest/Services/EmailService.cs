using Microsoft.AspNet.Identity;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace tpo10_rest.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return ConfigSendGridasync(message);
        }

        private Task ConfigSendGridasync(IdentityMessage message)
        {
            var email = ConfigurationManager.AppSettings["sendgrid_email"];
            var name = ConfigurationManager.AppSettings["sendgrid_name"];
            var apikey = ConfigurationManager.AppSettings["sendgrid_apikey"];

            var msg = new SendGridMessage();
            msg.AddTo(message.Destination);
            msg.From = new MailAddress(email, name);
            msg.Subject = message.Subject;
            msg.Text = message.Body;
            msg.Html = message.Body;

            var transportWeb = new Web(apikey);
            if (transportWeb != null)
            {
                return transportWeb.DeliverAsync(msg);
            }
            else
            {
                return Task.FromResult(0);
            }
        }
    }
}