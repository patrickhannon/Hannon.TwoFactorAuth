using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace hannon.TwoFactorAuth.Providers
{
    internal class EmailProvider
    {
        private string _smtpHost;
        private string _fromEmail;
        private string _emailPassword;
        public EmailProvider(string smtpHost, string fromEmail, string emailPassword)
        {
            ArgumentValidator.ThrowOnNullOrEmpty("smtpHost", smtpHost);
            ArgumentValidator.ThrowOnNullOrEmpty("fromEmail", fromEmail);
            ArgumentValidator.ThrowOnNullOrEmpty("emailPassword", emailPassword);

            _smtpHost = smtpHost;
            _fromEmail = fromEmail;
            _emailPassword = emailPassword;
        }

        internal bool SendEmail(string email, string subject, string body)
        {
            ArgumentValidator.ThrowOnNullEmptyOrWhitespace("email", email);
            ArgumentValidator.ThrowOnNullEmptyOrWhitespace("subject", subject);
            /*
            using (SmtpClient mailClient = new SmtpClient(_smtpHost))
            {
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress(_fromEmail);
                message.To.Add(new MailAddress(email));

                message.Subject = subject;
                message.Body = body;

                mailClient.Send(message);
                return true;
            }
            */
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_fromEmail);
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_fromEmail, _emailPassword),
                    Timeout = 20000
                };

                using (var message = new MailMessage(_fromEmail, email)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                return true;

                //using (SmtpClient smtp = new SmtpClient(_smtpHost, 587))
                //{
                //    Host = "smtp.gmail.com",
                //    Port = 587,
                //    EnableSsl = true,
                //    DeliveryMethod = SmtpDeliveryMethod.Network,
                //    UseDefaultCredentials = false,
                //    smtp.Credentials = new NetworkCredential(_fromEmail, _emailPassword);
                //    //smtp.EnableSsl = true;
                //    smtp.Send(mail);
                //}
            }

            return false;
        }
    }
}
