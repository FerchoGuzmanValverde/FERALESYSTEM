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
    public sealed class PlagaDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Plaga Plaga { get; set; }
        public LimpiezaDAL limpiezaDal { get; set; }

        public PlagaDAL()
        {

        }

        public PlagaDAL(Plaga Plaga)
        {
            this.Plaga = Plaga;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = "INSERT INTO Plaga (idPlaga, descripcionPlaga, tratamiento) VALUES (@idPlaga, @descripcion, @tratamiento)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Insertamos Limpieza
                LimpiezaDAL.InsertPlaga(Plaga as Limpieza);

                //Los parametros
                cmd.Parameters.AddWithValue("@idPlaga", Methods.GetActIdTable("Limpieza"));
                cmd.Parameters.AddWithValue("@descripcion", Plaga.DescripcionPlaga);
                cmd.Parameters.AddWithValue("@tratamiento", Plaga.Tratamiento);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);

                //Insertamos El empleado que hizo la limpieza
                LimpiezaEmpleadoDAL.Insert(Plaga.EmpleadoEncargado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update()
        {
            string query = "UPDATE Plaga SET descripcionPlaga=@descripcion, tratamiento=@tratamiento WHERE idPlaga=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Actualizamos Limpieza
                LimpiezaDAL.UpdatePlaga(Plaga as Limpieza);

                //Los parametros
                cmd.Parameters.AddWithValue("@descripcion", Plaga.DescripcionPlaga);
                cmd.Parameters.AddWithValue("@tratamiento", Plaga.Tratamiento);
                cmd.Parameters.AddWithValue("@id", Plaga.IdPlaga);

                //Actualizamos el empleado
                Plaga.EmpleadoEncargado.IdLimpieza = Plaga.IdLimpieza;
                LimpiezaEmpleadoDAL.Update(Plaga.EmpleadoEncargado);

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
                cmd.Parameters.AddWithValue("@id", Plaga.IdPlaga);

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
            string query = "SELECT * FROM vwPlaga ORDER BY 2";
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

        public Plaga Get(int id)
        {
            Plaga plaga = null;

            string query = @"SELECT idPlaga, descripcionPlaga, tratamiento FROM Plaga WHERE idPlaga = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                limpiezaDal = new LimpiezaDAL();
                //Obtenemos Limpieza
                Limpieza limpieza = limpiezaDal.Get(id);

                while (dr.Read())
                {
                    plaga = new Plaga(limpieza.IdLimpieza, limpieza.FechaHoraLimpieza, limpieza.IdTipoLimpieza, limpieza.IdEstablecimiento, limpieza.Estado, int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), limpieza.EmpleadoEncargado);
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

            return plaga;
        }

        #endregion
    }
}
