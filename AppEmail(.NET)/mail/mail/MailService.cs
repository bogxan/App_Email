using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace mail
{
    public class MailService
    {
        static string MAIL_FROM;
        static string MAIL_PASSWORD;
        public MailService(string from, string password)
        {
            MAIL_FROM = from;
            MAIL_PASSWORD = password;
        }
        public void SendMailMessage(string toMail, string subject, string body, bool isBodyHtml = false, ICollection<Attachment> attachments = null)
        {
            MailAddress mailFrom = new MailAddress(MAIL_FROM);
            MailAddress mailTo = new MailAddress(toMail);
            MailMessage mailMessage = new MailMessage(mailFrom, mailTo)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = isBodyHtml,
            };
            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    mailMessage.Attachments.Add(attachment);
                }
            }
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(MAIL_FROM, MAIL_PASSWORD),
            };
            smtpClient.Send(mailMessage);
        }
    }
}
