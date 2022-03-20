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
    public sealed class MesDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Mes Mes { get; set; }

        public MesDAL()
        {

        }

        public MesDAL(Mes Mes)
        {
            this.Mes = Mes;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = "INSERT INTO Mes (mes, anio) VALUES (@mes, @anio)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@mes", Mes.NombreMes);
                cmd.Parameters.AddWithValue("@anio", DateTime.Now.Year);

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
            string query = "UPDATE Mes SET mes=@mes, anio=@anio WHERE idMes=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@mes", Mes.NombreMes);
                cmd.Parameters.AddWithValue("@anio", DateTime.Now.Year);
                cmd.Parameters.AddWithValue("@id", Mes.IdMes);

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
            string query = "UPDATE Mes SET estado=0 WHERE idMes=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Mes.IdMes);

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
            string query = "SELECT * FROM vwMes ORDER BY 2";
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

        public Mes Get(short id)
        {
            Mes mes = null;

            string query = @"SELECT idMes, mes, anio, estado FROM Mes WHERE idMes = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    mes = new Mes(short.Parse(dr[0].ToString()), dr[1].ToString(), short.Parse(dr[2].ToString()), byte.Parse(dr[3].ToString()));
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

            return mes;
        }

        public DataTable SelectByIdName()
        {
            DataTable result = new DataTable();
            string query = "SELECT idMes, mes FROM Mes WHERE estado = 1";
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

        #endregion
    }
}
