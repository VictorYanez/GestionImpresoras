using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace GestionImpresoras.Services
{
    public class EmailService
    {
        public async Task SendEmail(string toSend, string subject, string message)
        {
           
            toSend = "correos.vmt@gmail.com";
            subject = "Prueba de envio de correo";
            message = "Cuerpo del correo ";

            //  await client.AuthenticateAsync("correos.vmt@gmail.com", "ktjigqekuwmquzzw");
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Test envio email", "correos.vmt@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("Test enviado toSend", toSend));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain")
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.Auto);
                await client.AuthenticateAsync("correos.vmt@gmail.com", "ktjigqekuwmquzzw");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
