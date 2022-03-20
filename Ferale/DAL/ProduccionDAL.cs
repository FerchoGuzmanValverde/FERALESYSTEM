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
    public sealed class ProduccionDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Produccion Produccion { get; set; }
        public MateriaProduccionDAL materiaProduccionDAL { get; set; }

        public ProduccionDAL()
        {

        }

        public ProduccionDAL(Produccion Produccion)
        {
            this.Produccion = Produccion;
            materiaProduccionDAL = new MateriaProduccionDAL();
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = @"INSERT INTO Produccion (idProducto, cantidad, fechaVencimiento, idLote) 
                                VALUES (@idProducto, @cantidad, @fechaVencimiento, @idLote)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                
                //Generamos Lote
                LoteDAL.GenerarLote();

                //Los parametros
                cmd.Parameters.AddWithValue("@idProducto", Produccion.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", Produccion.Cantidad);
                cmd.Parameters.AddWithValue("@fechaVencimiento", Produccion.FechaVencimiento);
                cmd.Parameters.AddWithValue("@idLote", Methods.GetActIdTable("Lote"));

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);

                //Insertamos lod detalles
                foreach (MateriaProduccion detalle in Produccion.Detalles)
                {
                    materiaProduccionDAL.Insert(detalle);
                }

                //Actualizando el stock
                ProductoDAL.UpdateStockProduccion(1, Produccion.IdProducto, Methods.GetActIdTable("Produccion"), Produccion.Cantidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update()
        {
            string query = "UPDATE Produccion SET idProducto=@idProducto, cantidad=@cantidad, fechaVencimiento=@fechaVencimiento WHERE idProduccion=@idProduccion";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@idProduccion", Produccion.IdProduccion);
                cmd.Parameters.AddWithValue("@idProducto", Produccion.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", Produccion.Cantidad);
                cmd.Parameters.AddWithValue("@fechaVencimiento", Produccion.FechaVencimiento);

                //Insertamos lod detalles
                foreach (MateriaProduccion detalle in Produccion.Detalles)
                {
                    materiaProduccionDAL.Update(detalle);
                }

                //Actualizando el stock
                ProductoDAL.UpdateStockProduccion(2, Produccion.IdProducto, Produccion.IdProduccion, Produccion.Cantidad);

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
            string query = "UPDATE Produccion SET estado=0 WHERE idProduccion=@idProduccion";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@idProduccion", Produccion.IdProduccion);

                //Insertamos lod detalles
                foreach (MateriaProduccion detalle in Produccion.Detalles)
                {
                    materiaProduccionDAL.Delete(detalle);
                }

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);

                //Actualizando el stock
                ProductoDAL.UpdateStockProduccion(0, Produccion.IdProducto, Produccion.IdProduccion, Produccion.Cantidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataTable Select()
        {
            DataTable result = new DataTable();
            string query = "SELECT * FROM vwProduccion ORDER BY 3";
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

        public Produccion Get(int idProduccion)
        {
            Produccion produccion = null;

            string query = @"SELECT idProduccion, idProducto, cantidad, fechaProduccion, fechaVencimiento, idLote, estado FROM Produccion WHERE idProduccion = @idProduccion";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idProduccion", idProduccion);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    produccion = new Produccion(int.Parse(dr[0].ToString()), short.Parse(dr[1].ToString()), short.Parse(dr[2].ToString()), DateTime.Parse(dr[3].ToString()), DateTime.Parse(dr[4].ToString()), int.Parse(dr[5].ToString()), byte.Parse(dr[6].ToString()), MateriaProduccionDAL.GetDetails(idProduccion));
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

            return produccion;
        }

        #endregion
    }
}
