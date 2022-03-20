using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class MailDAL
    {
        Mail mail;

        public MailDAL(Mail email)
        {
            this.mail = email;
        }

        public void sendMail()
        {
            var mailMessage = new MailMessage();
            try
            {
                SmtpClient cliente = new SmtpClient();
                cliente.Credentials = new NetworkCredential(MailConfig.senderMail, MailConfig.password);
                cliente.EnableSsl = MailConfig.ssl;
                cliente.Host = MailConfig.host;
                cliente.Port = MailConfig.port;


                mailMessage.From = new MailAddress(MailConfig.senderMail);
                mailMessage.To.Add(mail.RecipientEmail);
                mailMessage.Subject = mail.Subject;
                mailMessage.Body = mail.Body;
                mailMessage.Priority = MailPriority.High;

                cliente.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
