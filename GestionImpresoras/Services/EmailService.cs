using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using GestionImpresoras.Models;

namespace GestionImpresoras.Services
{
    public class EmailService
    {
        public async Task SendEmail(string tipo, Solicitud solicitud)
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

            // Crear el cuerpo del correo en formato de texto plano
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = CreateEmailBody(tipo, solicitud.FechaSolicitud.ToString(), solicitud.Correo, solicitud.Solicitante, solicitud.ImpresoraId.ToString(), solicitud.Color);
            email.Body = bodyBuilder.ToMessageBody();

            // Enviar el correo electrónico


            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.Auto);
                await client.AuthenticateAsync("correos.vmt@gmail.com", "ktjigqekuwmquzzw");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

        public string CreateEmailBody(string tipo, string fechaSolicitud, string correo, string solicitante, string impresoraId, string color)
        {
            // Crear el cuerpo del correo en función del tipo de correo
            string body = "";
            if (tipo == "registro")
            {
                body = $"Se ha registrado una nueva solicitud con los siguientes datos:\n" +
                       $"Fecha de Solicitud: {fechaSolicitud}\n" +
                       $"Correo: {correo}\n" +
                       $"Solicitante: {solicitante}\n" +
                       $"ImpresoraId: {impresoraId}\n" +
                       $"Color: {color}";
            }
            else if (tipo == "recepcion")
            {
                body = $"Se ha recibido el tóner solicitado con los siguientes datos:\n" +
                       $"Fecha de Solicitud: {fechaSolicitud}\n" +
                       $"Correo: {correo}\n" +
                       $"Solicitante: {solicitante}\n" +
                       $"ImpresoraId: {impresoraId}\n" +
                       $"Color: {color}";
            }
            return body;
        }
    }
}
