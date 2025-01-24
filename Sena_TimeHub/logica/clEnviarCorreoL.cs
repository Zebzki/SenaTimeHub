using System;
using System.Net;
using System.Net.Mail;

namespace Sena_TimeHub.logica
{
    public class clEnviarCorreoL
    {
        public bool enviarCorreo(string Destinatario, string nombre, string asunto, string cuerpo)
        {
            bool validacion = false;
            try
            {
                var remitente = new MailAddress("senatimehub@gmail.com", "Atención al cliente SenaTimeHub");
                var destinatario = new MailAddress(Destinatario, nombre);
                const string contrasenaRemitente = "zfnt lkuc tget gnac";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(remitente.Address, contrasenaRemitente)
                };

                using (var mensaje = new MailMessage(remitente, destinatario)
                {
                    Subject = asunto,
                    Body = cuerpo
                })
                {
                    smtp.Send(mensaje);
                    validacion = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en enviarCorreo: {ex.Message}");
                validacion = false;
            }

            return validacion;
        }
    }
}
