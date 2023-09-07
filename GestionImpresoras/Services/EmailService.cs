using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using GestionImpresoras.Models;
using GestionImpresoras.DTOs;

namespace GestionImpresoras.Services
{
    public class EmailService
    {
        public async Task SendEmail(string tipo, Solicitud solicitud, EmailData emailData)
        {
            String toSend = solicitud.Solicitante;
            String mailToSend = solicitud.Email;

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Test envio email", "correos.vmt@gmail.com"));
            emailMessage.To.Add(new MailboxAddress(toSend, mailToSend));

            // Crear el cuerpo y el asunto del correo en función del tipo de correo
            var emailBodyAndSubject = CreateEmailBodyAndSubject(tipo, solicitud, emailData);

            emailMessage.Subject = emailBodyAndSubject.Subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailBodyAndSubject.Body;
            emailMessage.Body = bodyBuilder.ToMessageBody();

            // Enviar el correo electrónico
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.Auto);
                await client.AuthenticateAsync("correos.vmt@gmail.com", "ktjigqekuwmquzzw");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

        public EmailBodyAndSubject CreateEmailBodyAndSubject(string tipo, Solicitud solicitud, EmailData emailData)
        {
            string body = "";
            string subject = "";

            if (tipo == "registro")
            {
                body = $"Se ha registrado una nueva solicitud con los siguientes datos:\n" +
                       $"Fecha de Solicitud: {emailData.FechaSolicitud}\n" +
                       $"Solicitante: {emailData.Solicitante}\n" +
                       $"Correo: {emailData.Correo}\n" +
                       $"Impresora: {emailData.ImpresoraCodigo}\n" +
                       $"Color: {emailData.ColorNombre}\n" +
                       $"Estado Solicitud: {emailData.EstadoSolicitudNombre}";
                subject = "Correo de registro de Solicitud";
            }
            else if (tipo == "recepcion")
            {
                body = $"Se ha recibido el tóner solicitado con los siguientes datos:\n" +
                       $"Fecha de Solicitud: {solicitud.FechaSolicitud}\n" +
                       $"Correo: {solicitud.Email}\n" + // Corregir la propiedad Email
                       $"Solicitante: {solicitud.Solicitante}\n" +
                       $"ImpresoraId: {solicitud.Impresora.CodigoActivoFijo}\n" + // Aquí se incluye el CodigoActivoFijo
                       $"Color: {solicitud.Color}";
                subject = "Correo de recepción de tóner";
            }

            return new EmailBodyAndSubject { Body = body, Subject = subject };
        }

    }

    public class EmailBodyAndSubject
    {
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
