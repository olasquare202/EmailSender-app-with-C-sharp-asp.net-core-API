using SendmailAPI.Models;

namespace SendmailAPI.Interfaces
{
    public class EmailSender: ITestClass
    {
        private readonly IMailServices _mailServices;

        public EmailSender(IMailServices mailServices)
        {
            _mailServices = mailServices;
        }
        public void Sending(EmailReceiver emailReceiver)
        {
            _mailServices.SendEmail(emailReceiver);
        }
    }
}
