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
    public sealed class VentaDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Venta Venta { get; set; }
        public VentaDetalleDAL ventaDetalleDal { get; set; }

        public VentaDAL()
        {
            ventaDetalleDal = new VentaDetalleDAL();
        }

        public VentaDAL(Venta Venta)
        {
            this.Venta = Venta;
            ventaDetalleDal = new VentaDetalleDAL();
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query;
            if (Venta.IdCliente == 0)
            {
                query = @"INSERT INTO Venta (montoTotalFinal, descuento, estadoEntrega, adelanto, idEmpleado) 
                            VALUES (@montoTotalFinal, @descuento, @estadoEntrega, @adelanto, @idEmpleado)";
            }
            else
            {
                query = @"INSERT INTO Venta (montoTotalFinal, descuento, estadoEntrega, adelanto, idEmpleado, idCliente) 
                            VALUES (@montoTotalFinal, @descuento, @estadoEntrega, @adelanto, @idEmpleado, @idCliente)";
            }
             
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@montoTotalFinal", Venta.MontoTotalVenta);
                cmd.Parameters.AddWithValue("@descuento", Venta.Descuento);
                cmd.Parameters.AddWithValue("@estadoEntrega", Venta.EstadoEntrega);
                cmd.Parameters.AddWithValue("@adelanto", Venta.Adelanto);
                cmd.Parameters.AddWithValue("@idEmpleado", Venta.IdEmpleado);
                if (Venta.IdCliente != 0)
                { cmd.Parameters.AddWithValue("@idCliente", Venta.IdCliente); }
                

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);

                //Insertamos lod detalles
                foreach (VentaDetalle detalle in Venta.Detalles)
                {
                    ventaDetalleDal.Insert(detalle);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update()
        {
            string query;
            if (Venta.IdCliente == 0)
            {
                query="UPDATE Venta SET montoTotalFinal=@montoTotalFinal, descuento=@descuento, estadoEntrega=@estadoEntrega, adelanto=@adelanto, idEmpleado=@idEmpleado WHERE idVenta=@id";
            }
            else
            {
                query = "UPDATE Venta SET montoTotalFinal=@montoTotalFinal, descuento=@descuento, estadoEntrega=@estadoEntrega, adelanto=@adelanto, idEmpleado=@idEmpleado, idCliente=@idCliente WHERE idVenta=@id";
            }
                
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@montoTotalFinal", Venta.MontoTotalVenta);
                cmd.Parameters.AddWithValue("@descuento", Venta.Descuento);
                cmd.Parameters.AddWithValue("@estadoEntrega", Venta.EstadoEntrega);
                cmd.Parameters.AddWithValue("@adelanto", Venta.Adelanto);
                cmd.Parameters.AddWithValue("@idEmpleado", Venta.IdEmpleado);
                if (Venta.IdCliente != 0)
                { cmd.Parameters.AddWithValue("@idCliente", Venta.IdCliente); }
                cmd.Parameters.AddWithValue("@id", Venta.IdVenta);

                //Insertamos lod detalles
                foreach (VentaDetalle detalle in Venta.Detalles)
                {
                    ventaDetalleDal.Update(detalle);
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
            string query = "UPDATE Venta SET estado=0 WHERE idVenta=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Venta.IdVenta);

                foreach (VentaDetalle detalle in Venta.Detalles)
                {
                    ventaDetalleDal.Delete(detalle);
                }

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
            string query = "SELECT * FROM vwVenta ORDER BY 2";
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

        public Venta Get(int id)
        {
            Venta venta = null;

            string query = @"SELECT idVenta, fechaHoraVenta, montoTotalFinal, descuento, estadoEntrega, adelanto, idEmpleado, ISNULL(idCliente, 0), estado FROM Venta WHERE idVenta = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    venta = new Venta(int.Parse(dr[0].ToString()), DateTime.Parse(dr[1].ToString()), double.Parse(dr[2].ToString()), byte.Parse(dr[3].ToString()), byte.Parse(dr[4].ToString()), double.Parse(dr[5].ToString()), byte.Parse(dr[8].ToString()), int.Parse(dr[7].ToString()), int.Parse(dr[6].ToString()), VentaDetalleDAL.GetDetails(id));
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

            return venta;
        }

        #endregion
    }
}
