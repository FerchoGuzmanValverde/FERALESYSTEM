using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Esta clase no Hereda de OperacionesAbstractDAL
    /// </summary>
    public sealed class CompraDetalleDAL
    {
        public static void Insert(CompraDetalle detalle)
        {
            string query = "INSERT INTO CompraDetalle (idCompra, idMateria, cantidad, precioUnitario) VALUES (@idCompra, @idMateria, @cantidad, @precioUnitario)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@idCompra", Methods.GetActIdTable("Compra"));
                cmd.Parameters.AddWithValue("@idMateria", detalle.IdMateria);
                cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                cmd.Parameters.AddWithValue("@precioUnitario", detalle.PrecioUnitario);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Update(CompraDetalle detalle)
        {
            string query = "UPDATE CompraDetalle SET cantidad=@cantidad, precioUnitario=@precioUnitario WHERE idCompra=@idCompra AND idMateria=@idMateria";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                cmd.Parameters.AddWithValue("@precioUnitario", detalle.PrecioUnitario);
                cmd.Parameters.AddWithValue("@idCompra", detalle.IdCompra);
                cmd.Parameters.AddWithValue("@idMateria", detalle.IdMateria);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CompraDetalle> SelectDetails(int id)
        {
            List<CompraDetalle> result = new List<CompraDetalle>();

            string query = @"SELECT idCompra, idMateria, cantidad, precioUnitario FROM CompraDetalle WHERE idCompra = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    result.Add(new CompraDetalle(int.Parse(dr[0].ToString()), short.Parse(dr[1].ToString()), double.Parse(dr[2].ToString()), double.Parse(dr[3].ToString())));
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
    }
}
