using MailKit.Net.Smtp;
using MimeKit;

namespace GestionImpresoras.Services
{
    public class EmailService
    {
        public void SendEmail(string toName, string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test envio email", "joseandresmont@gmail.com.co"));
            message.To.Add(new MailboxAddress(toName, toEmail));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465);
                client.Authenticate("joseandresmonto@gmail.com", "elite8359*");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
