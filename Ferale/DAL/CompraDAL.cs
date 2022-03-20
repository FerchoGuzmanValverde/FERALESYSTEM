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
    public sealed class CompraDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Compra Compra { get; set; }

        public CompraDAL()
        {

        }

        public CompraDAL(Compra Compra)
        {
            this.Compra = Compra;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = @"INSERT INTO Compra (montoTotalCompra, nroFactura, nroAutorizacion, codigoControl, idProveedor, idEmpleado)
                          VALUES (@montoTotalCompra, @nroFactura, @nroAutorizacion, @codigoControl, @idProveedor, @idEmpleado)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@montoTotalCompra", Compra.MontoTotalCompra);
                cmd.Parameters.AddWithValue("@nroFactura", Compra.NroFactura);
                cmd.Parameters.AddWithValue("@nroAutorizacion", Compra.NroAutorizacion);
                cmd.Parameters.AddWithValue("@codigoControl", Compra.CodigoControl);
                cmd.Parameters.AddWithValue("@idProveedor", Compra.IdProveedor);
                cmd.Parameters.AddWithValue("@idEmpleado", Compra.IdEmpleado);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);

                //Insertamos lod detalles
                foreach (CompraDetalle detalle in Compra.Detalles)
                {
                    CompraDetalleDAL.Insert(detalle);

                    //Actualizamos el Stock
                    MateriaPrimaDAL.UpdateStock(detalle.IdMateria, detalle.Cantidad, 1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update()
        {
            string query = "UPDATE Compra SET fechaCompra=@fechaCompra, montoTotalCompra=@montoTotalCompra, nroFactura=@nroFactura, nroAutorizacion=@nroAutorizacion, codigoControl=@codigoControl, idProveedor=@idProveedor, idEmpleado=@idEmpleado WHERE idCompra=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Compra.IdCompra);
                cmd.Parameters.AddWithValue("@fechaCompra", Compra.FechaHoraCompra);
                cmd.Parameters.AddWithValue("@montoTotalCompra", Compra.MontoTotalCompra);
                cmd.Parameters.AddWithValue("@nroFactura", Compra.NroFactura);
                cmd.Parameters.AddWithValue("@nroAutorizacion", Compra.NroAutorizacion);
                cmd.Parameters.AddWithValue("@codigoControl", Compra.CodigoControl);
                cmd.Parameters.AddWithValue("@idProveedor", Compra.IdProveedor);
                cmd.Parameters.AddWithValue("@idEmpleado", Compra.IdEmpleado);

                //Actualizamos los detalles
                foreach (CompraDetalle detalle in Compra.Detalles)
                {
                    //CompraDetalleDAL.Update(detalle, Compra.IdCompra);

                    //Actualizamos el Stock
                    //MateriaPrimaDAL.UpdateStock(detalle.IdMateria, detalle.Cantidad, 0);
                }

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
            string query = "UPDATE Compra SET estado=0 WHERE idCompra=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Compra.IdCompra);

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
            string query = "SELECT * FROM vwCompra ORDER BY 2";
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

        public Compra Get(int id)
        {
            Compra compra = null;

            string query = @"SELECT idCompra, fechaCompra, montoTotalCompra, nroFactura, nroAutorizacion, codigoControl, idProveedor, idEmpleado, estado FROM Compra WHERE idCompra = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                //Obtenemos los detalles
                List<CompraDetalle> detalles = CompraDetalleDAL.SelectDetails(id);

                while (dr.Read())
                {
                    compra = new Compra(int.Parse(dr[0].ToString()), DateTime.Parse(dr[1].ToString()), double.Parse(dr[2].ToString()), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), short.Parse(dr[6].ToString()), int.Parse(dr[7].ToString()), byte.Parse(dr[8].ToString()), detalles);
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

            return compra;
        }

        #endregion
    }
}
