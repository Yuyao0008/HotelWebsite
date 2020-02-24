using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FIT5032_Assign1_v6.Email
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var message = new MailMessage();
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "notification");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
            
        }

    }

}