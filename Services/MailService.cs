using System.Net;
using System.Net.Mail;
using mailSender_api.Model;

namespace mailSender_api.Infra.Services
{
    public class MailService : IMailService
    {


        public void AddEmailsToMailMessage(MailMessage mailMessage, string[] emails)
        {
            foreach (var email in emails)
            {
                mailMessage.To.Add(email);
            }
        }

        public void SendMail(SendMailHeaderModel sendMailHeaderModel, SendMailModel sendMailModel)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(sendMailHeaderModel.EmailFromAddress);
                AddEmailsToMailMessage(mailMessage, sendMailModel.Emails);
                mailMessage.Subject = sendMailModel.Subject;
                mailMessage.Body = sendMailModel.Body;
                mailMessage.IsBodyHtml = sendMailModel.IsHtml;
                using (SmtpClient smtp = new SmtpClient(sendMailHeaderModel.SmtpAddress, sendMailHeaderModel.PortNumber))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(sendMailHeaderModel.EmailFromAddress, sendMailHeaderModel.Password);
                    smtp.Send(mailMessage);
                }
            }
        }
       public bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; 
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
