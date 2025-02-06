using Newtonsoft.Json;
using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sena_TimeHub.vista
{
    
    public partial class horariosInstructor : System.Web.UI.Page
    {
        private static clHorarioInstructorL horarioL = new clHorarioInstructorL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<object> ObtenerFechas()
        {
            int idInstructor = Convert.ToInt32(HttpContext.Current.Session["idUsuario"]);
            List<clHorario> horarios = horarioL.mtdHorarioInstructor(idInstructor);

           
            var resultado = horarios.Select(h => new
            {
                fecha = h.fechaInicio.ToString("yyyy-MM-dd"), // Fecha
                horaInicio = h.horaInicio.ToString(@"hh\:mm"), // Hora inicial (formato HH:MM)
                horaFin = h.horaFinal.ToString(@"hh\:mm"), // Hora final (formato HH:MM)
                ficha = h.ficha, // Número de ficha
                ambiente = h.ambiente, // Ambiente asignado
                dias = h.dias,
                esCancelada = h.esCancelada,
                idHorario = h.idHorario
                
            }).ToList();

            return resultado.Cast<object>().ToList();
        }

        [WebMethod]
        public static bool CancelarClases(int idHorario, DateTime fecha, string motivo)
        {
           
            try
            {
               
                bool resultado = horarioL.mtdCancelarClasesPorFecha(idHorario, fecha, motivo);

                if (resultado) {
                    int idFicha = horarioL.mtdObtenerFichaPorHorario(idHorario);
                    List<string> correos = horarioL.mtdObtenerCorreos(idFicha);

                    string asunto = "Clase Cancelada";
                    string mensaje = "la clase programada para la fecha: " +  fecha.ToString("dd/MM/yyyy") + " ha sido cancelada por el siguiente motivo:"+" "+ motivo;
                   
                    foreach (string correo in correos) { 
                    EnviarCorreo (correo, asunto,mensaje);
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CancelarClases: " + ex.Message);
                return false;
            }
           
        }
        private static void EnviarCorreo(string destinatario, string asunto, string mensaje)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("senatimehubinformacion@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = asunto;
                mail.Body = mensaje;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587; // Puerto del servidor SMTP
                smtpClient.Credentials = new System.Net.NetworkCredential("senatimehubinformacion@gmail.com", "jkhh xolw ifgv yxzf");
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtpClient.Send(mail);
                Console.WriteLine("Correo enviado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en EnviarCorreo: " + ex.Message);
            }
        }
        //[WebMethod]
        //public static void EliminarHorario(clHorario oData)
        //{
        //    clHorarioInstructorL horarioL = new clHorarioInstructorL();
        //   bool resultado = horarioL.mtdCancelarClase(oData);
        //    if (!resultado)
        //    {
        //        throw new Exception("No se pudo cancelar la clase.");
        //    }
        //}





    }
}