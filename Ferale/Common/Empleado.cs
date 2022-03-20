using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de empleado
    /// </summary>
    public class Empleado
    {
        #region Atributos y Propiedades de la clase
        /// <summary>
        /// ID del empleado
        /// </summary>
        public int IdEmpleado { get; set; }
        /// <summary>
        /// Nombres del empleado
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Primer apellido del empleado
        /// </summary>
        public string PrimerApellido { get; set; }
        /// <summary>
        /// Segundo apellido del empleado
        /// </summary>
        public string SegundoApellido { get; set; }
        /// <summary>
        /// CI del empleado
        /// </summary>
        public string CedulaIdentidad { get; set; }
        /// <summary>
        /// Fecha nacimiento del empleado
        /// </summary>
        public DateTime FechaNacimiento { get; set; }
        /// <summary>
        /// Sexo del empleado
        /// </summary>
        public byte Sexo { get; set; }
        /// <summary>
        /// Nro de cuneta bancaria del empleado
        /// </summary>
        public int NroCuentaBancaria { get; set; }
        /// <summary>
        /// ID del area de la empresa del empleado
        /// </summary>
        public byte IdAreaEmpresa { get; set; }
        /// <summary>
        /// Telefono del empleado
        /// </summary>
        public string Telefono { get; set; }
        /// <summary>
        /// Estado del empleado
        /// </summary>
        public byte Estado { get; set; }
        /// <summary>
        /// Login del empleado
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Contraseña del empleado
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Foto de perfil del empleado
        /// </summary>
        public byte[] FotoPerfil { get; set; }
        /// <summary>
        /// Direccion de domicilio del empleado
        /// </summary>
        public string Domicilio { get; set; }
        /// <summary>
        /// Email del empleado
        /// </summary>
        public string Correo { get; set; }
        /// <summary>
        /// Usuario del empleado
        /// </summary>
        public Usuario Usuario { get; set; }


        #endregion

        #region Constructores de la clase

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Empleado()
        {

        }

        /// <summary>
        /// Constructor GET
        /// </summary>
        /// <param name="IdEmpleado"></param>
        /// <param name="Nombre"></param>
        /// <param name="PrimerApellido"></param>
        /// <param name="SegundoApellido"></param>
        /// <param name="CedulaIdentidad"></param>
        /// <param name="FechaNacimiento"></param>
        /// <param name="Sexo"></param>
        /// <param name="NroCuentaBancaria"></param>
        /// <param name="IdAreaEmpresa"></param>
        /// <param name="Telefono"></param>
        /// <param name="Estado"></param>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <param name="FotoPerfil"></param>
        /// <param name="Domicilio"></param>
        public Empleado(int IdEmpleado, string Nombre, string PrimerApellido, string SegundoApellido, string CedulaIdentidad,
                        DateTime FechaNacimiento, byte Sexo, int NroCuentaBancaria, byte IdAreaEmpresa,
                        string Telefono, byte Estado, byte[] FotoPerfil, string Domicilio, string correo, Usuario user)
        {
            this.IdEmpleado = IdEmpleado;
            this.Nombre = Nombre;
            this.PrimerApellido = PrimerApellido;
            this.SegundoApellido = SegundoApellido;
            this.CedulaIdentidad = CedulaIdentidad;
            this.FechaNacimiento = FechaNacimiento;
            this.Sexo = Sexo;
            this.NroCuentaBancaria = NroCuentaBancaria;
            this.IdAreaEmpresa = IdAreaEmpresa;
            this.Telefono = Telefono;
            this.Estado = Estado;
            this.Login = Login;
            this.Password = Password;
            this.FotoPerfil = FotoPerfil;
            this.Domicilio = Domicilio;
            this.Correo = correo;
            this.Usuario = user;
        }

        /// <summary>
        /// Constructor INSERTAR
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="PrimerApellido"></param>
        /// <param name="SegundoApellido"></param>
        /// <param name="CedulaIdentidad"></param>
        /// <param name="FechaNacimiento"></param>
        /// <param name="Sexo"></param>
        /// <param name="NroCuentaBancaria"></param>
        /// <param name="IdAreaEmpresa"></param>
        /// <param name="Telefono"></param>
        /// <param name="FotoPerfil"></param>
        /// <param name="Domicilio"></param>
        public Empleado(string Nombre, string PrimerApellido, string SegundoApellido, string CedulaIdentidad,
                        DateTime FechaNacimiento, byte Sexo, int NroCuentaBancaria, byte IdAreaEmpresa,
                        string Telefono, byte[] FotoPerfil, string Domicilio, string correo, Usuario user)
        {
            this.Nombre = Nombre;
            this.PrimerApellido = PrimerApellido;
            this.SegundoApellido = SegundoApellido;
            this.CedulaIdentidad = CedulaIdentidad;
            this.FechaNacimiento = FechaNacimiento;
            this.Sexo = Sexo;
            this.NroCuentaBancaria = NroCuentaBancaria;
            this.IdAreaEmpresa = IdAreaEmpresa;
            this.Telefono = Telefono;
            this.Login = Login;
            this.Password = Password;
            this.FotoPerfil = FotoPerfil;
            this.Domicilio = Domicilio;
            this.Correo = correo;
            this.Usuario = user;
        }

        #endregion
    }
}
