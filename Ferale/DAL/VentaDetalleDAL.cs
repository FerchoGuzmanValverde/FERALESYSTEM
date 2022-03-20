using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class VentaDetalleDAL
    {
        #region Atributos y Constructores

        public VentaDetalle VentaDetalle { get; set; }

        public VentaDetalleDAL()
        {

        }

        public VentaDetalleDAL(VentaDetalle VentaDetalle)
        {
            this.VentaDetalle = VentaDetalle;
        }

        #endregion

        public void Insert(VentaDetalle detalle)
        {
            string query = "INSERT INTO DetalleVenta (idVenta, idProducto, cantidad, precioUnitario) VALUES (@idVenta, @idProducto, @cantidad, @precioUnitario)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@idVenta", Methods.GetActIdTable("Venta"));
                cmd.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                cmd.Parameters.AddWithValue("@precioUnitario", detalle.PrecioUnitario);

                //Actualizamos el stock - 0 suma, 1 resta
                ProductoDAL.UpdateStock(1, detalle.IdProducto, detalle.Cantidad, detalle.IdVenta);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(VentaDetalle detalle)
        {
            string query = "exec dbo.uspUpdateDetalleVenta @idVenta, @idProducto, @cantidad, @precioUnitario, @estado";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idVenta", detalle.IdVenta);
                cmd.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                cmd.Parameters.AddWithValue("@precioUnitario", detalle.PrecioUnitario);
                cmd.Parameters.AddWithValue("@estado", detalle.Estado);

                //Actualizamos el stock - 0 suma, 1 resta
                ProductoDAL.UpdateStock(2, detalle.IdProducto, detalle.Cantidad, detalle.IdVenta);

                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(VentaDetalle detalle)
        {
            string query = "UPDATE DetalleVenta SET estado=@estado WHERE idVenta=@idVenta AND idProducto=@idProducto";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@estado", 0);
                cmd.Parameters.AddWithValue("@idVenta", detalle.IdVenta);
                cmd.Parameters.AddWithValue("@idProducto", detalle.IdProducto);

                //Actualizamos el stock - 0 suma, 1 resta
                ProductoDAL.UpdateStock(0, detalle.IdProducto, detalle.Cantidad, detalle.IdVenta);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VentaDetalle> SelectDetails(int id)
        {
            List<VentaDetalle> result = new List<VentaDetalle>();
            
            string query = @"SELECT D.idVenta, D.idProducto, P.descripcionProducto AS 'Producto', D.cantidad AS 'Cantidad', D.precioUnitario AS 'Precio Unitario', D.estado FROM DetalleVenta D INNER JOIN Producto P ON P.idProducto = D.idProducto WHERE D.idVenta = @id AND D.estado=1";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    result.Add(new VentaDetalle(int.Parse(dr[0].ToString()), short.Parse(dr[1].ToString()), dr[2].ToString(), short.Parse(dr[3].ToString()), double.Parse(dr[4].ToString()), byte.Parse(dr[5].ToString())));
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

        public static List<VentaDetalle> GetDetails(int id)
        {
            List<VentaDetalle> result = new List<VentaDetalle>();

            string query = @"SELECT idVenta, idProducto, cantidad, precioUnitario, estado FROM DetalleVenta WHERE idVenta = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    result.Add(new VentaDetalle(int.Parse(dr[0].ToString()), short.Parse(dr[1].ToString()), short.Parse(dr[2].ToString()), double.Parse(dr[3].ToString()), byte.Parse(dr[4].ToString())));
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
