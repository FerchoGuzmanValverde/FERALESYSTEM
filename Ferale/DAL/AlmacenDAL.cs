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
    public sealed class AlmacenDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Almacen Almacen { get; set; }

        public AlmacenDAL()
        {

        }

        public AlmacenDAL(Almacen Almacen)
        {
            this.Almacen = Almacen;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = "INSERT INTO Almacen (nombre, latitud, longitud, direccion) VALUES (@nombre, @latitud, @longitud, @direccion)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@nombre", Almacen.NombreAlmacen);
                cmd.Parameters.AddWithValue("@latitud", Almacen.Latitud);
                cmd.Parameters.AddWithValue("@longitud", Almacen.Longitud);
                cmd.Parameters.AddWithValue("@direccion", Almacen.Direccion);

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
            string query = @"UPDATE Almacen 
                            SET nombre=@nombre, direccion=@direccion, latitud=@latitud, longitud=@longitud
                            WHERE idAlmacen=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@nombre", Almacen.NombreAlmacen);
                cmd.Parameters.AddWithValue("@direccion", Almacen.Direccion);
                cmd.Parameters.AddWithValue("@latitud", Almacen.Latitud);
                cmd.Parameters.AddWithValue("@longitud", Almacen.Longitud);
                cmd.Parameters.AddWithValue("@id", Almacen.IdAlmacen);

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
            string query = "UPDATE Almacen SET estado=0 WHERE idAlmacen=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Almacen.IdAlmacen);

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
            string query = "SELECT * FROM vwAlmacen ORDER BY 2";
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

        public Almacen Get(byte id)
        {
            Almacen almacen = null;

            string query = @"SELECT idAlmacen, nombre, latitud, longitud, direccion, estado 
                            FROM Almacen 
                            WHERE idAlmacen = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                
                while (dr.Read())
                {
                    almacen = new Almacen(byte.Parse(dr[0].ToString()), dr[1].ToString(), float.Parse(dr[2].ToString()), float.Parse(dr[3].ToString()), dr[4].ToString(), byte.Parse(dr[5].ToString()));
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

            return almacen;
        }

        public DataTable SelectIdName()
        {
            DataTable res = new DataTable();

            string query = "SELECT idAlmacen, nombre FROM Almacen WHERE estado = 1";
            try
            {
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
