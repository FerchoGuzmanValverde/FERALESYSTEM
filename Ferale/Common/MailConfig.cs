using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear configuraciones del correo
    /// </summary>
    public class MailConfig
    {
        #region Atributos y Propiedades
        /// <summary>
        /// Smtp del cliente
        /// </summary>
        public static SmtpClient smtpCliente;
        /// <summary>
        /// Email del que envia el correo
        /// </summary>
        public static string senderMail { get; set; }
        /// <summary>
        /// Contraseña del correo
        /// </summary>
        public static string password { get; set; }
        /// <summary>
        /// host
        /// </summary>
        public static string host { get; set; }
        /// <summary>
        /// Puerto
        /// </summary>
        public static int port { get; set; }
        /// <summary>
        /// SSL
        /// </summary>
        public static bool ssl { get; set; }
        #endregion

        #region Contructores y metodos
        /// <summary>
        /// Contructor por defecto
        /// </summary>
        public static void initializaSmtp()
        {
            smtpCliente = new SmtpClient();
            smtpCliente.Credentials = new NetworkCredential(senderMail, password);
            smtpCliente.Host = host;
            smtpCliente.Port = port;
            smtpCliente.EnableSsl = ssl;
        }
        #endregion
    }
}
