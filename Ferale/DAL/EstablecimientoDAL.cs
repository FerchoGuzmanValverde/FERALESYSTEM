using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class EstablecimientoDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Establecimiento Establecimiento { get; set; }

        public EstablecimientoDAL()
        {

        }

        public EstablecimientoDAL(Establecimiento Establecimiento)
        {
            this.Establecimiento = Establecimiento;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = "INSERT INTO Establecimiento (nombreEstablecimiento, latitud, longitud) VALUES (@nombre, @latitud, @longitud)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@nombre", Establecimiento.NombreEstablecimiento);
                cmd.Parameters.AddWithValue("@latitud", Establecimiento.Latitud);
                cmd.Parameters.AddWithValue("@longitud", Establecimiento.Longitud);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update()
        {
            string query = "UPDATE Establecimiento SET nombreEstablecimiento=@nombre, latitud=@latitud, longitud=@longitud WHERE idEstablecimiento=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@nombre", Establecimiento.NombreEstablecimiento);
                cmd.Parameters.AddWithValue("@latitud", Establecimiento.Latitud);
                cmd.Parameters.AddWithValue("@longitud", Establecimiento.Longitud);
                cmd.Parameters.AddWithValue("@id", Establecimiento.IdEstablecimiento);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete()
        {
            string query = "UPDATE Establecimiento SET estado=0 WHERE idEstablecimiento=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Establecimiento.IdEstablecimiento);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataTable Select()
        {
            DataTable result = new DataTable();
            string query = "SELECT * FROM vwEstablecimiento";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                result = Methods.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Establecimiento Get(byte id)
        {
            Establecimiento establecimiento = null;

            string query = @"SELECT idEstablecimiento, nombreEstablecimiento, latitud, longitud, estado FROM Establecimiento WHERE idEstablecimiento = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    establecimiento = new Establecimiento(byte.Parse(dr[0].ToString()), dr[1].ToString(), float.Parse(dr[2].ToString()), float.Parse(dr[3].ToString()), byte.Parse(dr[4].ToString()));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                dr.Close();
            }

            return establecimiento;
        }

        public DataTable SelectIdName()
        {
            DataTable res = new DataTable();

            try
            {
                string query = "SELECT idEstablecimiento, nombreEstablecimiento FROM Establecimiento WHERE estado = 1";

                SqlCommand cmd = Methods.CreateBasicCommand(query);
                res = Methods.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }

        #endregion
    }
}
