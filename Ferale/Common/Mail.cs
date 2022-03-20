using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear correos
    /// </summary>
    public class Mail
    {
        #region Atributos y Propiedades
        /// <summary>
        /// Motivo del correo
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Cuerpo del correo
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Destinatario del correo
        /// </summary>
        public string RecipientEmail { get; set; }
        #endregion

        #region Contructores y Metodos
        /// <summary>
        /// contructor por defecto
        /// </summary>
        public Mail()
        {

        }
        /// <summary>
        /// Contructor para el Insert
        /// </summary>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <param name="RecipientEmail"></param>
        public Mail(string Subject, string Body, string RecipientEmail)
        {
            this.Subject = Subject;
            this.Body = Body;
            this.RecipientEmail = RecipientEmail;
        }
        #endregion
    }
}
