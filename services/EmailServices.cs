using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using SendmailAPI.Interfaces;
using SendmailAPI.Models;
using System.Security.Cryptography;

namespace SendmailAPI.services
{
    public class EmailServices : IMailServices
    {
        private readonly Appsetting _appsetting;

        public EmailServices(IServiceProvider provider)
        {
            _appsetting = provider.GetRequiredService<Appsetting>();
        }
        public void SendEmail(EmailReceiver emailReceiver)
        {
            
            
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_appsetting.EmailUserName));
            email.To.Add(MailboxAddress.Parse(emailReceiver.To));
            email.Subject = emailReceiver.Subject;
            email.Body = new TextPart(TextFormat.Plain) { Text = emailReceiver.Body};
            using var smtp = new SmtpClient();
            smtp.Connect(_appsetting.EmailHost, _appsetting.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_appsetting.EmailUserName, _appsetting.EmailPassword);
            smtp.Send(email);
            smtp.Disconnect(true);


            

        }
        //public static string OTP()
        //{
        //    var random = new Random();
        //    string OTP = string.Empty;
        //    for (int i = 0; i < 5; i++)
        //    {
        //        OTP = String.Concat(OTP, random.Next(5).ToString());
        //    }    
        //    return OTP;
        //}
    }
}
