using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace BancoSena.Modelo
{
    public class Correo
    {
        public string destinataerio { get; set; }
        public string mensaje { get; set; }
        public string asunto { get; set; }
        public string remitente { get; set; }
        public bool estado { get; set; }
        public string error { get; set; }
        MailMessage email = new MailMessage();

        public Correo()
        {

        }
        /// <summary>
        /// Constructor clase correo. 
        /// </summary>
        /// <param name="destinatario">destinatario@servidor.com</param>
        /// <param name="remitente">remitente@servidor.com</param>
        /// <param name="asunto">titulo del mensjae</param>
        /// <param name="mensaje">Cuerpo del mensaje</param>
        public Correo(string destinatario, string remitente, string asunto, string mensaje)
        {                   
            email.To.Add(destinatario);
            //aquí colocar nombre de ustedes
            email.From = new MailAddress(remitente, "Nombre del remitente", System.Text.Encoding.UTF8);
            email.Subject = asunto;
            email.SubjectEncoding = System.Text.Encoding.UTF8;
            email.Body = mensaje;
            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.IsBodyHtml = true;           
        }
        public bool envioCorreo()
        {
            bool enviado = false;
            SmtpClient protocolo = new SmtpClient();
            //dirección de correo electrónico que permite el envío del correo aquí colocar su cuenta de correo y clave
            protocolo.Credentials = new System.Net.NetworkCredential("correo de gmail", "password del correo");
            protocolo.Port = 587;
            protocolo.Host = "smtp.gmail.com";
            protocolo.EnableSsl = true;
            try
            {
                protocolo.Send(email);
                estado = true;
            }
            catch (SmtpException ex)
            {
                estado = false;
                error = ex.Message;
            }
            return enviado;
        }
    }
}