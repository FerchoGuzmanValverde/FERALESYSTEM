using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.SqlClient;

namespace DAL
{
    public sealed class MateriaProduccionDAL
    {
        #region Atributos y constructores
        public MateriaProduccion MateriaProduccion { get; set; }

        public MateriaProduccionDAL()
        {

        }

        public MateriaProduccionDAL(MateriaProduccion MateriaProduccion)
        {
            this.MateriaProduccion = MateriaProduccion;
        }
        #endregion

        #region Metodos

        public void Insert(MateriaProduccion detalle)
        {
            string query = "INSERT INTO MateriaProduccion (idMateriaPrima, idProduccion, cantidadMateria) VALUES (@idMateriaPrima, @idProduccion, @cantidad)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@idMateriaPrima", detalle.IdMateria);
                cmd.Parameters.AddWithValue("@idProduccion", Methods.GetActIdTable("Produccion"));
                cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);

                //Actualizamos el stock - 0 suma, 1 resta
                MateriaPrimaDAL.UpdateStock(1, detalle.IdMateria, detalle.Cantidad, detalle.IdProduccion);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(MateriaProduccion detalle)
        {
            string query = "UPDATE MateriaProduccion SET cantidadMateria = @cantidad, idMateriaPrima = @idMateriaPrima WHERE @idProduccion = idProduccion";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@idMateriaPrima", detalle.IdMateria);
                cmd.Parameters.AddWithValue("@idProduccion", detalle.IdProduccion);
                cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);

                //Actualizamos el stock - 0 suma, 1 resta
                MateriaPrimaDAL.UpdateStock(2, detalle.IdMateria, detalle.Cantidad, detalle.IdProduccion);
                

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(MateriaProduccion detalle)
        {
            string query = "UPDATE MateriaProduccion SET estado = 0 WHERE @idMateriaPrima = idMateriaPrima AND @idProduccion = idProduccion";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@idMateriaPrima", detalle.IdMateria);
                cmd.Parameters.AddWithValue("@idProduccion", detalle.IdProduccion);

                //Actualizamos el stock - 0 suma, 1 resta
                MateriaPrimaDAL.UpdateStock(0, detalle.IdMateria, detalle.Cantidad, detalle.IdProduccion);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<MateriaProduccion> GetDetails(int id)
        {
            List<MateriaProduccion> result = new List<MateriaProduccion>();

            string query = @"SELECT idProduccion, idMateriaPrima, cantidadMateria, estado FROM MateriaProduccion WHERE idProduccion = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    result.Add(new MateriaProduccion(short.Parse(dr[1].ToString()), int.Parse(dr[0].ToString()), double.Parse(dr[2].ToString()), byte.Parse(dr[3].ToString())));
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

            return result;
        }
        #endregion
    }
}
