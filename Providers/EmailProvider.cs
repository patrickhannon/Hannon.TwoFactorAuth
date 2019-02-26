using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;


namespace hannon.TwoFactorAuth.Providers
{
    internal class EmailProvider
    {
        private string _smtpHost;
        private string _fromEmail;
        public EmailProvider(string smtpHost, string fromEmail)
        {
            ArgumentValidator.ThrowOnNullOrEmpty("smtpHost", smtpHost);
            ArgumentValidator.ThrowOnNullOrEmpty("fromEmail", fromEmail);
            _smtpHost = smtpHost;
            _fromEmail = fromEmail;
        }

        internal bool SendEmail(string email, string subject, string body)
        {
            ArgumentValidator.ThrowOnNullEmptyOrWhitespace("email", email);
            ArgumentValidator.ThrowOnNullEmptyOrWhitespace("subject", subject);

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
            return false;
        }
    }
}
