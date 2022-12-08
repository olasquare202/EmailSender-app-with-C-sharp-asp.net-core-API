using SendmailAPI.Models;

namespace SendmailAPI.Interfaces
{
    public interface IMailServices
    {
        public void SendEmail(EmailReceiver emailReceiver);
    }
}
