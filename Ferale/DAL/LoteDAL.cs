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
    public sealed class LoteDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Lote Lote { get; set; }

        public LoteDAL()
        {

        }

        public LoteDAL(Lote Lote)
        {
            this.Lote = Lote;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = "INSERT INTO Lote (nroLote) VALUES (@nroLote)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@nroLote", Lote.NroLote);

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
            string query = "UPDATE Lote SET nroLote=@nroLote WHERE idLote=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@nroLote", Lote.NroLote);
                cmd.Parameters.AddWithValue("@id", Lote.IdLote);

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
            string query = "UPDATE Lote SET estado=0 WHERE idLote=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Lote.IdLote);

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
            string query = "SELECT * FROM vwLote ORDER BY 2";
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

        public Lote Get(int id)
        {
            Lote lote = null;

            string query = @"SELECT idLote, nroLote, estado FROM Lote WHERE idLote = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    lote = new Lote(byte.Parse(dr[0].ToString()), dr[1].ToString(), byte.Parse(dr[2].ToString()));
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

            return lote;
        }

        public static void GenerarLote()
        {
            string query = "INSERT INTO Lote (nroLote) VALUES (@nroLote)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@nroLote", DateTime.Now);

                //Ejecutamos el comando
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
