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
    public sealed class LimpiezaDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Limpieza Limpieza { get; set; }

        public LimpiezaDAL()
        {

        }

        public LimpiezaDAL(Limpieza Limpieza)
        {
            this.Limpieza = Limpieza;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = "INSERT INTO Limpieza (fechaHoraLimpieza, idTipoLimpieza, idEstablecimiento) VALUES (@fechaHora, @idTipo, @idEstablecimiento)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@fechaHora", Limpieza.FechaHoraLimpieza);
                cmd.Parameters.AddWithValue("@idTipo", Limpieza.IdTipoLimpieza);
                cmd.Parameters.AddWithValue("@idEstablecimiento", Limpieza.IdEstablecimiento);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);

                //Insertamos El empleado que hizo la limpieza
                LimpiezaEmpleadoDAL.Insert(Limpieza.EmpleadoEncargado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertPlaga(Limpieza limpieza)
        {
            string query = "INSERT INTO Limpieza (fechaHoraLimpieza, idTipoLimpieza, idEstablecimiento) VALUES (@fechaHora, @idTipo, @idEstablecimiento)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@fechaHora", limpieza.FechaHoraLimpieza);
                cmd.Parameters.AddWithValue("@idTipo", limpieza.IdTipoLimpieza);
                cmd.Parameters.AddWithValue("@idEstablecimiento", limpieza.IdEstablecimiento);

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
            string query = "UPDATE Limpieza SET fechaHoraLimpieza=@fechaHora, idTipoLimpieza=@idTipo, idEstablecimiento=@idEstablecimiento WHERE idLimpieza=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@fechaHora", Limpieza.FechaHoraLimpieza);
                cmd.Parameters.AddWithValue("@idTipo", Limpieza.IdTipoLimpieza);
                cmd.Parameters.AddWithValue("@idEstablecimiento", Limpieza.IdEstablecimiento);
                cmd.Parameters.AddWithValue("@id", Limpieza.IdLimpieza);

                //Actualizamos el empleado
                Limpieza.EmpleadoEncargado.IdLimpieza = Limpieza.IdLimpieza;
                LimpiezaEmpleadoDAL.Update(Limpieza.EmpleadoEncargado);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePlaga(Limpieza limpieza)
        {
            string query = "UPDATE Limpieza SET fechaHoraLimpieza=@fechaHora, idTipoLimpieza=@idTipo, idEstablecimiento=@idEstablecimiento WHERE idLimpieza=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@fechaHora", limpieza.FechaHoraLimpieza);
                cmd.Parameters.AddWithValue("@idTipo", limpieza.IdTipoLimpieza);
                cmd.Parameters.AddWithValue("@idEstablecimiento", limpieza.IdEstablecimiento);
                cmd.Parameters.AddWithValue("@id", limpieza.IdLimpieza);

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
            string query = "UPDATE Limpieza SET estado=0 WHERE idLimpieza=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Limpieza.IdLimpieza);

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
            string query = "SELECT * FROM vwLimpieza ORDER BY 2";
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

        public Limpieza Get(int id)
        {
            Limpieza limpieza = null;

            string query = @"SELECT idLimpieza, fechaHoraLimpieza, idTipoLimpieza, idEstablecimiento, estado FROM Limpieza WHERE idLimpieza = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    limpieza = new Limpieza(int.Parse(dr[0].ToString()), DateTime.Parse(dr[1].ToString()), byte.Parse(dr[2].ToString()), byte.Parse(dr[3].ToString()), byte.Parse(dr[4].ToString()));
                }

                //Obtenemos el empleado
                 limpieza.EmpleadoEncargado = LimpiezaEmpleadoDAL.GetIdEmpleado(limpieza.IdLimpieza);

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

            return limpieza;
        }

        public static DBFeraleDataSet ObtenerListaLimpiezaReporte1(DateTime fechaInicio, DateTime fechaFin)
        {
            DBFeraleDataSet DbFeraleDataSet = new DBFeraleDataSet();
            Common.DBFeraleDataSetTableAdapters.LimpiezaListaTableAdapter limpiezaAdapter = new Common.DBFeraleDataSetTableAdapters.LimpiezaListaTableAdapter();
            try
            {
                limpiezaAdapter.Fill(DbFeraleDataSet.Tables["LimpiezaLista"] as DBFeraleDataSet.LimpiezaListaDataTable, fechaInicio, fechaFin, 0, 0); ;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DbFeraleDataSet;
        }

        public static DBFeraleDataSet ObtenerListaLimpiezaReporte2(byte idEstablecimiento)
        {
            DBFeraleDataSet DbFeraleDataSet = new DBFeraleDataSet();
            Common.DBFeraleDataSetTableAdapters.LimpiezaListaTableAdapter limpiezaAdapter = new Common.DBFeraleDataSetTableAdapters.LimpiezaListaTableAdapter();
            try
            {
                limpiezaAdapter.Fill(DbFeraleDataSet.Tables["LimpiezaLista"] as DBFeraleDataSet.LimpiezaListaDataTable, DateTime.Parse("1/1/1753"), DateTime.Parse("1/1/1753"), idEstablecimiento, 0); ;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DbFeraleDataSet;
        }

        public static DBFeraleDataSet ObtenerListaLimpiezaReporte3(byte idTipoLimpieza)
        {
            DBFeraleDataSet DbFeraleDataSet = new DBFeraleDataSet();
            Common.DBFeraleDataSetTableAdapters.LimpiezaListaTableAdapter limpiezaAdapter = new Common.DBFeraleDataSetTableAdapters.LimpiezaListaTableAdapter();
            try
            {
                limpiezaAdapter.Fill(DbFeraleDataSet.Tables["LimpiezaLista"] as DBFeraleDataSet.LimpiezaListaDataTable, DateTime.Parse("1/1/1753"), DateTime.Parse("1/1/1753"), 0, idTipoLimpieza); ;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DbFeraleDataSet;
        }

        #endregion
    }
}
