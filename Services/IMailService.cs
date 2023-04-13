
using mailSender_api.Model;

namespace mailSender_api.Infra.Services
{
    public interface IMailService
    {
        void SendMail(SendMailHeaderModel sendMailHeaderModel,SendMailModel sendMailViewModel);
        bool IsValidEmail(string email);
    }
}
