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
    public sealed class ProductoDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Producto Producto { get; set; }

        public ProductoDAL()
        {

        }

        public ProductoDAL(Producto Producto)
        {
            this.Producto = Producto;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = @"INSERT INTO Producto (descripcionProducto, precioBase, fotoProducto, indicaciones, stock, variedad, idTipoProducto) 
                            VALUES (@descripcionProducto, @precioBase, @fotoProducto, @indicaciones, @stock, @variedad, @idTipoProducto)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@descripcionProducto", Producto.DescripcionProducto);
                cmd.Parameters.AddWithValue("@precioBase", Producto.PrecioBase);
                cmd.Parameters.AddWithValue("@fotoProducto", Producto.Foto);
                cmd.Parameters.AddWithValue("@indicaciones", Producto.Indicaciones);
                cmd.Parameters.AddWithValue("@stock", Producto.Stock);
                cmd.Parameters.AddWithValue("@variedad", Producto.Variedad);
                cmd.Parameters.AddWithValue("@idTipoProducto", Producto.IdTipoProducto);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Producto");
                cmd.Parameters.AddWithValue("@crud", "C");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Methods.GetActIdTable("Producto") + " Producto insertado");
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.idUsuario);
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update()
        {
            string query = "UPDATE Producto SET descripcionProducto=@descripcion, precioBase=@precioBase, fotoProducto=@foto, indicaciones=@indicaciones, stock=@stock, variedad=@variedad, idTipoProducto=@idTipo WHERE idProducto=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Producto.IdProducto);
                cmd.Parameters.AddWithValue("@descripcion", Producto.DescripcionProducto);
                cmd.Parameters.AddWithValue("@precioBase", Producto.PrecioBase);
                cmd.Parameters.AddWithValue("@foto", Producto.Foto);
                cmd.Parameters.AddWithValue("@indicaciones", Producto.Indicaciones);
                cmd.Parameters.AddWithValue("@stock", Producto.Stock);
                cmd.Parameters.AddWithValue("@variedad", Producto.Variedad);
                cmd.Parameters.AddWithValue("@idTipo", Producto.IdTipoProducto);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Producto");
                cmd.Parameters.AddWithValue("@crud", "U");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Producto.IdProducto + " Producto modificado");
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.idUsuario);
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete()
        {
            string query = "UPDATE Producto SET estado=0 WHERE idProducto=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Producto.IdProducto);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Producto");
                cmd.Parameters.AddWithValue("@crud", "D");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Producto.IdProducto + "Producto eliminado");
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.idUsuario);
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
            string query = "SELECT * FROM vwProducto ORDER BY 2";
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

        public Producto Get(short id)
        {
            Producto producto = null;

            string query = @"SELECT idProducto, descripcionProducto, precioBase, fotoProducto, indicaciones, stock, variedad, idTipoProducto, estado FROM Producto WHERE idProducto = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    producto = new Producto(short.Parse(dr[0].ToString()), dr[1].ToString(), double.Parse(dr[2].ToString()), byte.Parse(dr[8].ToString()), (byte[])dr[3], dr[4].ToString(), short.Parse(dr[5].ToString()), dr[6].ToString(), byte.Parse(dr[7].ToString()));
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

            return producto;
        }

        public DataTable SelectByIdName(byte tipo)
        {
            DataTable res = new DataTable();

            try
            {
                string query = "SELECT idProducto, descripcionProducto FROM Producto WHERE estado = 1 AND idTipoProducto = @idTipo";

                SqlCommand cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idTipo", tipo);
                res = Methods.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }

        public static void UpdateStock(byte operacion, short idProducto, short cantidad, int idVenta)
        {
            string query = "exec dbo.uspUpdateStock @idOperacion, @idProducto, @cantidad, @idVenta";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idOperacion", operacion);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateStockProduccion(byte operacion, short idProducto,int idProduccion, short cantidad)
        {
            string query = "exec dbo.uspUpdateStockProducto @idOperacion, @idProducto, @idProduccion, @cantidad";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idOperacion", operacion);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.Parameters.AddWithValue("@idProduccion", idProduccion);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
