using mailSender_api.Infra.Services;
using mailSender_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace mailSender_api.Controllers
{
    [Route("mails")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public IActionResult SendMail([FromHeader] string emailFromAdress, [FromHeader] int portNumber,
        [FromHeader] string smtpAdress, [FromHeader] string password, [FromBody] SendMailModel sendMailModel)
        {
            try
            {

                try
                {
                    if (!_mailService.IsValidEmail(emailFromAdress)) throw new Exception("Email de remetente inválido");
                    if (portNumber <= 0) throw new Exception("Porta inválida");
                    if (string.IsNullOrEmpty(smtpAdress)) throw new Exception( "Endereço SMTP é inválido");
                    if (string.IsNullOrEmpty(password)) throw new Exception("Senha inválida");
                    if (sendMailModel.Emails==null ||sendMailModel.Emails.Length==0 ) throw new Exception("Informe ao menos um email para envio");
                    if (string.IsNullOrEmpty(sendMailModel.Body)) throw new Exception("Corpo da requisição vazio");
                    if (string.IsNullOrEmpty(sendMailModel.Subject)) throw new Exception("Informe o título.");

                }
                catch (Exception e)
                {
                    HttpContext.Response.StatusCode =400;
                    throw e;
                }


                SendMailHeaderModel emailHeader = new SendMailHeaderModel();
                emailHeader.EmailFromAddress = emailFromAdress;
                emailHeader.PortNumber = portNumber;
                emailHeader.SmtpAddress = smtpAdress;
                emailHeader.Password = password;
                _mailService.SendMail(emailHeader, sendMailModel);

                return Ok();
            }
            catch (Exception e)
            {   
               HttpContext.Response.StatusCode =500;
               throw e;
            }
        }
    }
}
