using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DALC;
using Entities;

namespace Logic.GrupoFournier
{
    public class MailLogic
    {
        public void EnviarEmail(long usuarioID, string contraseña, Cross.Common.Global.MailsTypes tipoMail)
        {
            UsuarioDalc usuDalc = new UsuarioDalc();
            Usuario usu = usuDalc.GetByID(usuarioID);

            string HTML = "";

            //Envio el mail
            MailMessage mail = new MailMessage();
            switch (tipoMail)
            {
                case Cross.Common.Global.MailsTypes.REGISTRO:
                    HTML = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("../MailsTemplate/email_registro.html"));
                    //email's subject
                    mail.Subject = "Aprendizaje 2.0 - Bienvenido";
                    break;
                case Cross.Common.Global.MailsTypes.CAMBIO_CONTRASEÑA:
                    HTML = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("../MailsTemplate/email_cambio_contraseña.html"));
                    //email's subject
                    mail.Subject = "Aprendizaje 2.0 - Cambio de contraseña";
                    break;
                case Cross.Common.Global.MailsTypes.CURSO_FINALIZADO:
                    HTML = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("../../MailsTemplate/email_curso_finalizado.html"));
                    //email's subject
                    mail.Subject = "Aprendizaje 2.0 - Curso finalizado";
                    break;
                default:
                    break;
            }


            mail.To.Add(usu.Mail);

            mail.From = new MailAddress("info@sempait.com.ar", "Aprendizaje 2.0");
            //email's body, this is going to be html. note that we attach the image as using cid
            mail.Body = HTML;
            //set email's body to html
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;
            //client.EnableSsl = true; 

            SmtpClient smtp = new SmtpClient();
            smtp.Host =  "localhost"; //Cambiar hardcodeo
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
